using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class QuotationMasterDB : DBBase<QuotationMaster, List<QuotationMaster>, long>
	{
		public override List<QuotationMaster> GetAll()
		{
			return ((IQueryable<QuotationMaster>)dbContext.QuotationMaster).OrderByDescending((QuotationMaster x) => x.QuotationMasterID).ToList();
		}

		public override QuotationMaster GetByID(long id)
		{
			return ((IQueryable<QuotationMaster>)dbContext.QuotationMaster).FirstOrDefault((QuotationMaster j) => j.QuotationMasterID == id);
		}

		public QuotationMaster GetByEnquiryID(long id)
		{
			return ((IQueryable<QuotationMaster>)dbContext.QuotationMaster).FirstOrDefault((QuotationMaster j) => j.FKEnquiryMasterID == (long?)id);
		}

		public override bool Insert(QuotationMaster entity, out string message)
		{
			message = "";
			try
			{
				dbContext.QuotationMaster.Add(entity);
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

		public override bool Update(QuotationMaster entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				QuotationMaster byID = this.GetByID(entity.QuotationMasterID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<QuotationMaster>(byID);
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
			catch (Exception)
			{
				message = "";
				result = false;
			}
			return result;
		}

		public override bool Delete(QuotationMaster entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				entity = this.GetByID(entity.QuotationMasterID);
				long value = entity.FKEnquiryMasterID.Value;
				EnquiryMaster byID = new EnquiryMasterDB().GetByID(value);
				QuotationDetailsDB quotationDetailsDB = new QuotationDetailsDB();
				List<QuotationDetails> byMasterID = quotationDetailsDB.GetByMasterID(entity.QuotationMasterID);
				if (byMasterID.Count > 0)
				{
					foreach (QuotationDetails entity2 in byMasterID)
					{
						quotationDetailsDB.Delete(entity2);
					}
				}
				this.dbContext.Entry<QuotationMaster>(entity).State = EntityState.Deleted;
				if (this.dbContext.SaveChanges() > 0)
				{
					byID.IsClosed = true;
					new EnquiryMasterDB().Update(byID);
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

		public List<ViewNewQuotationMaster> GetAllNew()
		{
			return ((IQueryable<ViewNewQuotationMaster>)dbContext.ViewNewQuotationMaster).OrderByDescending((ViewNewQuotationMaster x) => x.QuotationMasterID).ToList();
		}

		public List<SpGetAllQuotationMasterHistory_Result> GetAllHistory()
		{
			int value = int.Parse(HttpContext.Current.Session["UserId"].ToString());
			return ((IEnumerable<SpGetAllQuotationMasterHistory_Result>)dbContext.SpGetAllQuotationMasterHistory(value)).OrderByDescending((SpGetAllQuotationMasterHistory_Result x) => x.QuotationMasterID).ToList();
		}

		public List<QuotationMaster> GetActivePending(long jobOrderMasterId)
		{
			List<long?> processedList = (from ep in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
				join e in (IEnumerable<JobOrderDetails>)dbContext.JobOrderDetails on ep.JobOrderMasterID equals e.FKJobOrderMasterID
				join t in (IEnumerable<QuotationDetails>)dbContext.QuotationDetails on e.FKQuotationDetailsID equals t.QuotationDetailsID
				where ep.JobOrderMasterID != jobOrderMasterId
				select new
				{
					QID = t.FKQuotationMasterID
				} into x
				select (long?)x.QID).Distinct().ToList();
			List<IGrouping<long?, QuotationMaster>> source = (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
				where x.StatusID == 1
				select x into a
				group a by a.FKEnquiryMasterID).ToList();
			List<QuotationMaster> list = source.SelectMany((IGrouping<long?, QuotationMaster> a) => a.Where((QuotationMaster b) => b.QuotationMasterID == a.Max((QuotationMaster c) => c.QuotationMasterID))).ToList();
			List<QuotationMaster> list2 = list;
			List<long> id = new List<long>();
			foreach (QuotationMaster item in list2)
			{
				id.Add(item.QuotationMasterID);
			}
			if (id.Count > 0)
			{
				return (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
					where x.IsActive == true && x.StatusID == 1 && !processedList.Contains(x.QuotationMasterID) && id.Contains(x.QuotationMasterID) && x.IsAddedTojo != (bool?)true
					orderby x.QuotationMasterID descending
					select x).ToList();
			}
			return (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
				where x.IsActive == true && x.StatusID == 1 && !processedList.Contains(x.QuotationMasterID) && x.IsAddedTojo != (bool?)true
				orderby x.QuotationMasterID descending
				select x).ToList();
		}

		public List<QuotationMaster> GetActivePendingByCustomerAndProject(long jobOrderMasterId)
		{
			JobOrderMaster Master = new JobOrderMasterDB().GetByID(jobOrderMasterId);
			if (Master != null)
			{
				return (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
					where x.IsActive == true && x.StatusID == 1 && x.FKCustomerID == Master.FKCustomerID && x.FKProjectID == Master.FKProjectID && x.IsAddedTojo != (bool?)true
					orderby x.QuotationMasterID descending
					select x).ToList();
			}
			return null;
		}

		public List<QuotationMaster> GetActivePendingByCustomerAndProject(long jobOrderMasterId, long QuotaionMasterId)
		{
			QuotationMaster Master = GetByID(QuotaionMasterId);
			List<long?> processedList = (from ep in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
				join e in (IEnumerable<JobOrderDetails>)dbContext.JobOrderDetails on ep.JobOrderMasterID equals e.FKJobOrderMasterID
				join t in (IEnumerable<QuotationDetails>)dbContext.QuotationDetails on e.FKQuotationDetailsID equals t.QuotationDetailsID
				where ep.JobOrderMasterID != jobOrderMasterId
				select new
				{
					QID = t.FKQuotationMasterID
				} into x
				select (long?)x.QID).Distinct().ToList();
			List<IGrouping<long?, QuotationMaster>> source = (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
				where x.StatusID == 1
				select x into a
				group a by a.FKEnquiryMasterID).ToList();
			List<QuotationMaster> list = source.SelectMany((IGrouping<long?, QuotationMaster> a) => a.Where((QuotationMaster b) => b.QuotationMasterID == a.Max((QuotationMaster c) => c.QuotationMasterID))).ToList();
			List<QuotationMaster> list2 = list;
			List<long> id = new List<long>();
			foreach (QuotationMaster item in list2)
			{
				id.Add(item.QuotationMasterID);
			}
			if (Master != null)
			{
				List<long?> MasterQuotation = (from ep in (IQueryable<JobOrderMaster>)dbContext.JobOrderMaster
					join e in (IEnumerable<JobOrderDetails>)dbContext.JobOrderDetails on ep.JobOrderMasterID equals e.FKJobOrderMasterID
					join t in (IEnumerable<QuotationDetails>)dbContext.QuotationDetails on e.FKQuotationDetailsID equals t.QuotationDetailsID
					where ep.JobOrderMasterID == jobOrderMasterId
					select new
					{
						QID = t.FKQuotationMasterID
					} into x
					select (long?)x.QID).Distinct().ToList();
				if (id.Count > 0)
				{
					return (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
						where x.IsActive == true && x.StatusID == 1 && !processedList.Contains(x.QuotationMasterID) && id.Contains(x.QuotationMasterID) && x.FKCustomerID == Master.FKCustomerID && x.FKProjectID == Master.FKProjectID && !MasterQuotation.Contains(x.QuotationMasterID)
						orderby x.QuotationMasterID descending
						select x).ToList();
				}
				return (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
					where x.IsActive == true && x.StatusID == 1 && !processedList.Contains(x.QuotationMasterID) && x.FKCustomerID == Master.FKCustomerID && x.FKProjectID == Master.FKProjectID && !MasterQuotation.Contains(x.QuotationMasterID)
					orderby x.QuotationMasterID descending
					select x).ToList();
			}
			return (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
				where x.IsActive == true && x.StatusID == 1 && !processedList.Contains(x.QuotationMasterID)
				orderby x.QuotationMasterID descending
				select x).ToList();
		}

		public bool Insert(QuotationMaster entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
			if (obj != null)
			{
				List<ViewQuotationDetails> list = obj as List<ViewQuotationDetails>;
				if (list.Count > 0)
				{
					List<QuotationDetails> list2 = new List<QuotationDetails>();
					foreach (ViewQuotationDetails item2 in list)
					{
						QuotationDetails quotationDetails = new QuotationDetails();
						quotationDetails.FKEnquiryDetailsID = item2.FKEnquiryDetailsID;
						quotationDetails.FKMaterialDetailsID = item2.FKMaterialDetailsID;
						quotationDetails.FKMaterialTypeID = item2.FKMaterialTypeID;
						quotationDetails.FKPriceUnitID = item2.FKPriceUnitID;
						quotationDetails.FKQuotationMasterID = item2.FKQuotationMasterID;
						quotationDetails.FKTestID = item2.FKTestID;
						quotationDetails.MinQty = item2.MinQty;
						quotationDetails.Price = item2.Price;
						quotationDetails.Remarks = item2.Remarks;
						quotationDetails.QuotationDetailsID = item2.QuotationDetailsID;
						list2.Add(quotationDetails);
					}
					object obj2 = HttpContext.Current.Session["QuotationWorkOrderList"];
					if (obj2 != null)
					{
						List<QuotationWorkOrderList> list3 = obj2 as List<QuotationWorkOrderList>;
						List<QuotationWorkOrderList> list4 = new List<QuotationWorkOrderList>();
						foreach (QuotationDetails item in list2)
						{
							Func<QuotationWorkOrderList, bool> predicate = (QuotationWorkOrderList x) => x.FkQuotationDetailsID == item.QuotationDetailsID;
							if (list3.Count(predicate) <= 0)
							{
								continue;
							}
							foreach (QuotationWorkOrderList item3 in list3)
							{
								QuotationWorkOrderList quotationWorkOrderList = new QuotationWorkOrderList();
								quotationWorkOrderList.EndDate = item3.EndDate;
								quotationWorkOrderList.ExtraWorkHourRate = item3.ExtraWorkHourRate;
								quotationWorkOrderList.FKAgreementID = item3.FKAgreementID;
								quotationWorkOrderList.FKQuotationMasterID = item3.FKQuotationMasterID;
								quotationWorkOrderList.MonthlyRate = item3.MonthlyRate;
								quotationWorkOrderList.NightShiftPerc = item3.NightShiftPerc;
								quotationWorkOrderList.Description = item3.Description;
								quotationWorkOrderList.RamadanWorkHrs = item3.RamadanWorkHrs;
								quotationWorkOrderList.RegularWorkHrs = item3.RegularWorkHrs;
								quotationWorkOrderList.RowStatus = item3.RowStatus;
								quotationWorkOrderList.ShiftStatus = item3.ShiftStatus;
								quotationWorkOrderList.SiteName = item3.SiteName;
								quotationWorkOrderList.StartDate = item3.StartDate;
								quotationWorkOrderList.TransDate = item3.TransDate;
								quotationWorkOrderList.UnitOfAddition = item3.UnitOfAddition;
								quotationWorkOrderList.FkQuotationDetailsID = item3.FkQuotationDetailsID;
								quotationWorkOrderList.WorkOrderNo = new QuotationWorkOrderListDB().GetWorkOrderNo();
								list4.Add(quotationWorkOrderList);
							}
							item.QuotationWorkOrderList = list4.Where((QuotationWorkOrderList x) => x.FkQuotationDetailsID == item.QuotationDetailsID).ToList();
						}
					}
					entity.QuotationDetails = list2;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(QuotationMaster entity)
		{
			string message = "";
			new QuotationDetailsDB().UpdateDetailsFromSession();
			new QuotationWorkOrderListDB().UpdateDetailsFromSession();
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(QuotationMaster entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ViewNewQuotationMaster entity)
		{
			string message = "";
			QuotationMaster byID = GetByID(entity.QuotationMasterID);
			if (Delete(byID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		private void DeActivateQuots(long EnquiryMasterID)
		{
			string message = "";
			List<QuotationMaster> list = ((IQueryable<QuotationMaster>)dbContext.QuotationMaster).Where((QuotationMaster x) => x.FKEnquiryMasterID == (long?)EnquiryMasterID).ToList();
			foreach (QuotationMaster item in list)
			{
				item.IsActive = false;
				Update(item, out message);
			}
		}

		public string GetNewQuotationNo(long EnquiryMasterID)
		{
			if (((IQueryable<QuotationMaster>)dbContext.QuotationMaster).Count((QuotationMaster x) => x.FKEnquiryMasterID == (long?)EnquiryMasterID) > 0)
			{
				string quotationNo = ((IQueryable<QuotationMaster>)dbContext.QuotationMaster).FirstOrDefault((QuotationMaster x) => x.FKEnquiryMasterID == (long?)EnquiryMasterID && !x.QuotationNo.Contains("-")).QuotationNo;
				return quotationNo + " - R" + ((IQueryable<QuotationMaster>)dbContext.QuotationMaster).Count((QuotationMaster x) => x.FKEnquiryMasterID == (long?)EnquiryMasterID);
			}
			QuotationMaster quotationMaster = (from x in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
				where !x.QuotationNo.Contains("-")
				orderby x.QuotationMasterID descending
				select x).FirstOrDefault();
			return (int.Parse(quotationMaster.QuotationNo.ToString()) + 1).ToString();
		}

		public List<string> GetPaymentTermsList()
		{
			return (from z in (IQueryable<QuotationMaster>)dbContext.QuotationMaster
				where z.PaymentTerms != null
				select z into x
				select x.PaymentTerms).Distinct().ToList();
		}
	}
}
