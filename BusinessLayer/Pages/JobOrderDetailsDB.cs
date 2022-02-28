using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class JobOrderDetailsDB : DBBase<JobOrderDetails, List<JobOrderDetails>, long>
	{
		public override List<JobOrderDetails> GetAll()
		{
			return ((IEnumerable<JobOrderDetails>)dbContext.JobOrderDetails).ToList();
		}

		public override JobOrderDetails GetByID(long id)
		{
			return ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).FirstOrDefault((JobOrderDetails j) => j.JobOrderDetailsID == id);
		}

		public override bool Insert(JobOrderDetails entity, out string message)
		{
			message = "";
			try
			{
				dbContext.JobOrderDetails.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "InsertError";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(JobOrderDetails entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				JobOrderDetails byID = this.GetByID(entity.JobOrderDetailsID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<JobOrderDetails>(byID);
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
			catch (Exception ex)
			{
                var vv = ex.ToString();
				//message = ex
				result = false;
			}
			return result;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x000196B0 File Offset: 0x000178B0
		public override bool Delete(JobOrderDetails entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<JobOrderDetails>(entity).State = EntityState.Deleted;
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

		public bool Insert(JobOrderDetails entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(JobOrderDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(JobOrderDetails entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteByMasterId(long masterId)
		{
			string message = "";
			List<JobOrderDetails> list = ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).Where((JobOrderDetails j) => j.FKJobOrderMasterID == masterId).ToList();
			foreach (JobOrderDetails item in list)
			{
				if (!Delete(item, out message))
				{
					throw new Exception(message);
				}
			}
			return true;
		}

		public List<JobOrderDetails> GetByMasterIDWithSession(long masterId)
		{
			List<JobOrderDetails> list;
			if (masterId > 0)
			{
				list = ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).Where((JobOrderDetails j) => j.FKJobOrderMasterID == masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["JobOrderDetailsList"];
				if (obj == null)
				{
					list = new List<JobOrderDetails>();
					HttpContext.Current.Session["JobOrderDetailsList"] = list;
				}
				else
				{
					list = obj as List<JobOrderDetails>;
				}
			}
			return list;
		}

		public bool InsertWithSession(JobOrderDetails entity)
		{
			string message = "";
			if (entity.FKJobOrderMasterID == 0)
			{
				object obj = HttpContext.Current.Session["JobOrderDetailsList"];
				List<JobOrderDetails> list = ((obj != null) ? (obj as List<JobOrderDetails>) : new List<JobOrderDetails>());
				entity.JobOrderDetailsID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["JobOrderDetailsList"] = list;
				return true;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(JobOrderDetails entity)
		{
			string message = "";
			if (entity.FKJobOrderMasterID == 0)
			{
				object obj = HttpContext.Current.Session["JobOrderDetailsList"];
				List<JobOrderDetails> list = ((obj == null) ? new List<JobOrderDetails>() : (obj as List<JobOrderDetails>));
				JobOrderDetails jobOrderDetails = list.First((JobOrderDetails x) => x.JobOrderDetailsID == entity.JobOrderDetailsID);
				jobOrderDetails.FKPriceUnitID = entity.FKPriceUnitID;
				jobOrderDetails.Remarks = entity.Remarks;
				HttpContext.Current.Session["JobOrderDetailsList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(JobOrderDetails entity, long original_JobOrderDetailsID)
		{
			string message = "";
			if (entity.FKJobOrderMasterID == 0)
			{
				object obj = HttpContext.Current.Session["JobOrderDetailsList"];
				List<JobOrderDetails> list = ((obj == null) ? new List<JobOrderDetails>() : (obj as List<JobOrderDetails>));
				JobOrderDetails jobOrderDetails = list.First((JobOrderDetails x) => x.JobOrderDetailsID == entity.JobOrderDetailsID);
				jobOrderDetails.FKPriceUnitID = entity.FKPriceUnitID;
				jobOrderDetails.Price = entity.Price;
				jobOrderDetails.MinQty = entity.MinQty;
				jobOrderDetails.ExpiryDate = entity.ExpiryDate;
				jobOrderDetails.Remarks = entity.Remarks;
				HttpContext.Current.Session["JobOrderDetailsList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(JobOrderDetails entity)
		{
			string message = "";
			if (entity.FKTestID == 0)
			{
				object obj = HttpContext.Current.Session["JobOrderDetailsList"];
				List<JobOrderDetails> list;
				if (obj != null)
				{
					list = obj as List<JobOrderDetails>;
					list.RemoveAll((JobOrderDetails x) => x.JobOrderDetailsID == entity.JobOrderDetailsID);
				}
				else
				{
					list = new List<JobOrderDetails>();
				}
				HttpContext.Current.Session["JobOrderDetailsList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool InsertList(List<JobOrderDetails> entityList)
		{
			if (entityList.Count > 0)
			{
				long fKJobOrderMasterID = entityList.First().FKJobOrderMasterID;
				if (fKJobOrderMasterID > 0)
				{
					List<JobOrderDetails> CurrentList = GetByMasterIDWithSession(fKJobOrderMasterID);
					List<JobOrderDetails> list = CurrentList.Where((JobOrderDetails x) => !entityList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (JobOrderDetails item2 in list)
					{
						Delete(item2);
					}
					foreach (JobOrderDetails item3 in entityList.Where((JobOrderDetails x) => !CurrentList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						string message = "";
						if (!Insert(item3, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["JobOrderDetailsList"];
					List<JobOrderDetails> JobOrderDetailsList;
					if (obj == null)
					{
						JobOrderDetailsList = new List<JobOrderDetails>();
					}
					else
					{
						JobOrderDetailsList = obj as List<JobOrderDetails>;
					}
					List<JobOrderDetails> list2 = JobOrderDetailsList.Where((JobOrderDetails x) => !entityList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (JobOrderDetails item in list2)
					{
						List<JobOrderDetails> list3 = JobOrderDetailsList;
						Predicate<JobOrderDetails> match = (JobOrderDetails X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (JobOrderDetails item4 in entityList.Where((JobOrderDetails x) => !JobOrderDetailsList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.JobOrderDetailsID = JobOrderDetailsList.Count + 1;
						JobOrderDetailsList.Add(item4);
					}
					HttpContext.Current.Session["JobOrderDetailsList"] = JobOrderDetailsList;
				}
			}
			return true;
		}

		public List<JobOrderDetails> GetByMasterIDFromSession(long masterId)
		{
			object obj = HttpContext.Current.Session["JobOrderDetailsList"];
			List<JobOrderDetails> list = ((obj != null) ? (obj as List<JobOrderDetails>) : ((masterId <= 0) ? new List<JobOrderDetails>() : ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).Where((JobOrderDetails j) => j.FKJobOrderMasterID == masterId).GroupBy(i => i.FKQuotationDetailsID).Select(i => i.FirstOrDefault()).ToList()));
			HttpContext.Current.Session["JobOrderDetailsList"] = list;
            return list;
		}

		public List<JobOrderDetails> GetByCustomerMasterIDFromSession(long masterId)
		{
			object obj = HttpContext.Current.Session["NewJobOrderDetailsList"];
			List<JobOrderDetails> list = ((obj != null) ? (obj as List<JobOrderDetails>) : ((masterId <= 0) ? new List<JobOrderDetails>() : ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).Where((JobOrderDetails j) => j.FKJobOrderMasterID == masterId).ToList()));
			HttpContext.Current.Session["NewJobOrderDetailsList"] = list;
			return list;
		}

		public bool InsertListToSession(List<JobOrderDetails> entityList)
		{
			if (entityList.Count > 0)
			{
				long fKJobOrderMasterID = entityList.First().FKJobOrderMasterID;
				if (fKJobOrderMasterID > 0)
				{
					List<JobOrderDetails> CurrentList = GetByMasterIDWithSession(fKJobOrderMasterID);
					List<JobOrderDetails> list = CurrentList.Where((JobOrderDetails x) => !entityList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (JobOrderDetails item2 in list)
					{
						Delete(item2);
					}
					foreach (JobOrderDetails item3 in entityList.Where((JobOrderDetails x) => !CurrentList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						string message = "";
						if (!Insert(item3, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["JobOrderDetailsList"];
					List<JobOrderDetails> JobOrderDetailsList;
					if (obj == null)
					{
						JobOrderDetailsList = new List<JobOrderDetails>();
					}
					else
					{
						JobOrderDetailsList = obj as List<JobOrderDetails>;
					}
					List<JobOrderDetails> list2 = JobOrderDetailsList.Where((JobOrderDetails x) => !entityList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (JobOrderDetails item in list2)
					{
						List<JobOrderDetails> list3 = JobOrderDetailsList;
						Predicate<JobOrderDetails> match = (JobOrderDetails X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (JobOrderDetails item4 in entityList.Where((JobOrderDetails x) => !JobOrderDetailsList.Select((JobOrderDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.JobOrderDetailsID = JobOrderDetailsList.Count + 1;
						JobOrderDetailsList.Add(item4);
					}
					HttpContext.Current.Session["JobOrderDetailsList"] = JobOrderDetailsList;
				}
			}
			return true;
		}

		public bool UpdateToSession(JobOrderDetails entity, long original_JobOrderDetailsID)
		{
			object obj = HttpContext.Current.Session["JobOrderDetailsList"];
			if (obj != null)
			{
				List<JobOrderDetails> list = obj as List<JobOrderDetails>;
				JobOrderDetails jobOrderDetails = list.First((JobOrderDetails x) => x.JobOrderDetailsID == entity.JobOrderDetailsID);
				jobOrderDetails.FKPriceUnitID = entity.FKPriceUnitID;
				jobOrderDetails.Price = entity.Price;
				jobOrderDetails.MinQty = entity.MinQty;
				jobOrderDetails.ExpiryDate = entity.ExpiryDate;
				jobOrderDetails.Remarks = entity.Remarks;
                jobOrderDetails.IsEnable = entity.IsEnable;
                if (entity.FKJobOrderMasterID == 0)
				{
					jobOrderDetails.RowStatus = 1;
				}
				else
				{
					jobOrderDetails.RowStatus = 2;
				}
                Update(jobOrderDetails);
                HttpContext.Current.Session["JobOrderDetailsList"] = list;
			}
			return true;
		}

		public bool UpdateDetailsFromSession(long JobOrderMasterID)
		{
			object obj = HttpContext.Current.Session["JobOrderDetailsList"];
			if (obj != null)
			{
				List<JobOrderDetails> source = obj as List<JobOrderDetails>;
				foreach (JobOrderDetails entity in source.Where((JobOrderDetails x) => x.RowStatus == 1 || x.FKJobOrderMasterID==0).Distinct().ToList())
				{
					if (((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).Count((JobOrderDetails x) => x.FKJobOrderMasterID == JobOrderMasterID && x.FKTestID == entity.FKTestID && x.FKMaterialTypeID == entity.FKMaterialTypeID && x.FKMaterialDetailsID == entity.FKMaterialDetailsID) == 0)
					{
						entity.FKJobOrderMasterID = JobOrderMasterID;
						Insert(entity);
						continue;
					}
					JobOrderDetails jobOrderDetails = ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).Single((JobOrderDetails x) => x.FKJobOrderMasterID == JobOrderMasterID && x.FKTestID == entity.FKTestID && x.FKMaterialTypeID == entity.FKMaterialTypeID && x.FKMaterialDetailsID == entity.FKMaterialDetailsID);
					jobOrderDetails.FKPriceUnitID = entity.FKPriceUnitID;
					jobOrderDetails.Price = entity.Price;
					jobOrderDetails.MinQty = entity.MinQty;
					Update(jobOrderDetails);
				}
				foreach (JobOrderDetails item in source.Where((JobOrderDetails x) => x.RowStatus == 2).ToList())
				{
					Update(item);
				}
				foreach (JobOrderDetails item2 in source.Where((JobOrderDetails x) => x.RowStatus == 3).ToList())
				{
					Delete(item2);
				}
			}
			HttpContext.Current.Session["JobOrderDetailsList"] = null;
			return true;
		}

		public List<ViewJobOrderTestList> GetViewJobOrderTestList(long masterId)
		{
			return ((IQueryable<ViewJobOrderTestList>)dbContext.ViewJobOrderTestList).Where((ViewJobOrderTestList j) => j.JobOrderMasterID == masterId).ToList();
		}

		public JobOrderDetails GetOrderTestDetailByTestID(int TestID)
		{
			return ((IQueryable<JobOrderDetails>)dbContext.JobOrderDetails).FirstOrDefault((JobOrderDetails x) => x.FKTestID == TestID);
		}

        public bool UpdateEnable(int jobOrderDetailId, bool isEnable)
        {
            JobOrderDetails byID = this.GetByID(jobOrderDetailId);
            byID.IsEnable = isEnable;
            return Update(byID);
        }
    }
}
