using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class JobOrderMasterDB : DBBase<JobOrderMaster, List<JobOrderMaster>, long>
	{
		public override List<JobOrderMaster> GetAll()
		{
			return ((IQueryable<JobOrderMaster>)dbContext.JobOrderMaster).OrderByDescending((JobOrderMaster x) => x.JobOrderMasterID).ToList();
		}

		public override JobOrderMaster GetByID(long id)
		{
			return ((IQueryable<JobOrderMaster>)dbContext.JobOrderMaster).FirstOrDefault((JobOrderMaster j) => j.JobOrderMasterID == id);
		}

		public override bool Insert(JobOrderMaster entity, out string message)
		{
			message = "";
			try
			{
				if (entity.ExpiryDate >= entity.TransactionDate)
				{
					decimal? receiveCreditLimit = entity.ReceiveCreditLimit;
					if (receiveCreditLimit.GetValueOrDefault() < 0m && receiveCreditLimit.HasValue)
					{
						decimal? reportCreditLimit = entity.ReportCreditLimit;
						if (reportCreditLimit.GetValueOrDefault() < 0m && reportCreditLimit.HasValue)
						{
							message = "Not Accepted Negative Numbers....!";
							return false;
						}
					}
					if (entity.ReceiveCreditLimit >= entity.ReportCreditLimit)
					{
						dbContext.JobOrderMaster.Add(entity);
						if (((DbContext)dbContext).SaveChanges() > 0)
						{
							return true;
						}
						message = "InsertError";
						return false;
					}
					message = "Report credit limit should be less than Received limit....!";
					return false;
				}
				message = "Expiry Date should be greater than Received Date....!";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(JobOrderMaster entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				JobOrderMaster byID = this.GetByID(entity.JobOrderMasterID);
				if (entity.ExpiryDate >= entity.TransactionDate)
				{
					if (entity.ReceiveCreditLimit < 0m && entity.ReportCreditLimit < 0m)
					{
						message = "Not Accepted Negative Numbers....!";
						result = false;
					}
					else if (entity.ReceiveCreditLimit >= entity.ReportCreditLimit)
					{
						DbEntityEntry dbEntityEntry = this.dbContext.Entry<JobOrderMaster>(byID);
						dbEntityEntry.State = EntityState.Modified;
						dbEntityEntry.CurrentValues.SetValues(entity);
						if (this.dbContext.SaveChanges() > 0)
						{
							result = true;
						}
						else
						{
							message = "UpdateError";
							result = false;
						}
					}
					else
					{
						message = "Report credit limit should be less than Received limit....!";
						result = false;
					}
				}
				else
				{
					message = "Expiry Date should be greater than Received Date....!";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "";
				result = false;
			}
			return result;
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001B170 File Offset: 0x00019370
		public override bool Delete(JobOrderMaster entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<JobOrderMaster>(entity).State = EntityState.Deleted;
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					message = "DeleteError";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		public bool Insert(JobOrderMaster entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["JobOrderDetailsList"];
			if (obj != null)
			{
				List<JobOrderDetails> list = obj as List<JobOrderDetails>;
				if (list.Count > 0)
				{
					object obj2 = HttpContext.Current.Session["WorkOrderList"];
					if (obj2 != null)
					{
						List<WorkOrderList> source = obj2 as List<WorkOrderList>;
						foreach (JobOrderDetails item in list)
						{
							if (source.Count((WorkOrderList x) => x.FKJobOrderDetailsID == item.JobOrderDetailsID) > 0)
							{
								item.WorkOrderList = source.Where((WorkOrderList x) => x.FKJobOrderDetailsID == item.JobOrderDetailsID).ToList();
							}
						}
					}
					entity.JobOrderDetails = list;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(JobOrderMaster entity)
		{
			string message = "";
			new JobOrderDetailsDB().UpdateDetailsFromSession(entity.JobOrderMasterID);
			new WorkOrderListDB().UpdateDetailsFromSession();
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(JobOrderMaster entity)
		{
			string message = "";
			List<WorkOrderList> byJobOrderID = new WorkOrderListDB().GetByJobOrderID(entity.JobOrderMasterID);
			if (byJobOrderID.Count > 0)
			{
				foreach (WorkOrderList item in byJobOrderID)
				{
					new WorkOrderListDB().Delete(item);
				}
			}
			List<SampleReceiveList> byJobOrderID2 = new SampleReceiveListDB().GetByJobOrderID(entity.JobOrderMasterID);
			if (byJobOrderID2.Count > 0)
			{
				message = "You can not delete this job order becouse it have Sample Receive  ";
				throw new Exception(message);
			}
			new JobOrderDetailsDB().DeleteByMasterId(entity.JobOrderMasterID);
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string GetActiveJobOrderID(int CustomerID, int ProjectID)
		{
			JobOrderMaster jobOrderMaster = ((IQueryable<JobOrderMaster>)dbContext.JobOrderMaster).FirstOrDefault((JobOrderMaster x) => x.FKCustomerID == CustomerID && x.FKProjectID == ProjectID && x.IsActive == true && (DateTime)x.ExpiryDate >= (DateTime)(DateTime?)DateTime.Today);
			if (jobOrderMaster != null)
			{
				return jobOrderMaster.JobOrderNumber;
			}
			return "0";
		}

		public List<JobOrderMaster> GetActiveJobOrder()
		{
			return (from x in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
				where x.IsActive == true && x.StatusID == 1 && (DateTime)x.ExpiryDate >= (DateTime)(DateTime?)DateTime.Today
                    orderby x.JobOrderMasterID descending
				select x).ToList();
		}

		public List<ViewJobOrderList> GetActiveJobOrderFromView()
		{
			return (from x in (IQueryable<ViewJobOrderList>)dbContext.ViewJobOrderList
				where x.IsActive == true
				orderby x.JobOrderMasterID descending
				select x).ToList();
		}

		public List<ViewJobOrderMaster> GetActiveViewJobOrder()
		{
			return (from x in (IQueryable<ViewJobOrderMaster>)dbContext.ViewJobOrderMaster
				where x.IsActive == true
				orderby x.JobOrderMasterID descending
				select x).ToList();
		}

		public ViewJobOrderList GetActiveJobOrderFromViewById(int id)
		{
			return ((IQueryable<ViewJobOrderList>)dbContext.ViewJobOrderList).Where((ViewJobOrderList x) => x.IsActive == true && x.JobOrderDetailsID == (long)id).FirstOrDefault();
		}

		public string GetNewSerial()
		{
			string maxJobOrderNumber = GetMaxJobOrderNumber();
			if (int.Parse(maxJobOrderNumber) > 0)
			{
				return (Convert.ToInt32(maxJobOrderNumber) + 1).ToString();
			}
			return "1";
		}

		private string GetMaxJobOrderNumber()
		{
			long? num = ((IQueryable<JobOrderMaster>)dbContext.JobOrderMaster).Max((Expression<Func<JobOrderMaster, long?>>)((JobOrderMaster entity) => entity.JobOrderMasterID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).JobOrderNumber;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}

		public List<JobOrderMaster> GetAllPending()
		{
			return (from x in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
				where x.StatusID == 0
				orderby x.JobOrderMasterID descending
				select x).ToList();
		}

		public List<JobOrderMaster> GetAllApproved()
		{
			return (from x in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
				where x.StatusID == 1 && (DateTime)x.ExpiryDate >= (DateTime)(DateTime?)DateTime.Today
				orderby x.JobOrderMasterID descending
				select x).ToList();
		}

		public List<JobOrderMaster> GetAllExpired()
		{
			return (from x in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
				where (DateTime)x.ExpiryDate < (DateTime)(DateTime?)DateTime.Today
				orderby x.JobOrderMasterID descending
				select x).ToList();
		}

        public List<JobOrderMaster> GetActiveNonExpiredJobOrder()
        {
            return (from x in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
                    where x.IsActive == true && x.StatusID == 1 && (DateTime)x.ExpiryDate > (DateTime)(DateTime?)DateTime.Today
                    orderby x.JobOrderMasterID descending
                    select x).ToList();
        }

        public List<ViewJobOrderPendingToInvoicer> GetAllPendingInvoice()
		{
			return ((IQueryable<ViewJobOrderPendingToInvoicer>)dbContext.ViewJobOrderPendingToInvoicer).OrderByDescending((ViewJobOrderPendingToInvoicer x) => x.JobOrderMasterID).ToList();
		}

		public List<ViewIdelJobOrder> GetAllIdleJobOrder()
		{
			return ((IQueryable<ViewIdelJobOrder>)dbContext.ViewIdelJobOrder).OrderByDescending((ViewIdelJobOrder x) => x.JobOrderMasterID).ToList();
		}
	}
}
