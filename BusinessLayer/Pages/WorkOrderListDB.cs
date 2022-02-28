using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class WorkOrderListDB : DBBase<WorkOrderList, List<WorkOrderList>, long>
	{
		public override List<WorkOrderList> GetAll()
		{
			return ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public override WorkOrderList GetByID(long id)
		{
			return ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).FirstOrDefault((WorkOrderList j) => j.WorkOrderID == id);
		}

		public override bool Insert(WorkOrderList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.WorkOrderList.Add(entity);
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

		public override bool Update(WorkOrderList entity, out string message)
		{
			message = "";
			try
			{
				WorkOrderList byID = GetByID(entity.WorkOrderID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<WorkOrderList>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "UpdateError";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(WorkOrderList entity, out string message)
		{
			message = "";
			try
			{
				List<WorkOrderTimeSheet> byWorkOrderID = new WorkOrderTimeSheetDB().GetByWorkOrderID(entity.WorkOrderID);
				if (byWorkOrderID.Count > 0)
				{
					message = "You can not delete this WorkOrder becouse it have Time Sheet ";
					return false;
				}
				((DbContext)dbContext).Entry<WorkOrderList>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "DeleteError";
				return false;
			}
			catch (Exception)
			{
				message = "DeleteError";
				return false;
			}
		}

		public bool Insert(WorkOrderList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(WorkOrderList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(WorkOrderList entity)
		{
			string message = "";
			if (Delete(entity.WorkOrderID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<WorkOrderList> GetByMasterIDWithSession(int masterId)
		{
			List<WorkOrderList> list;
			if (masterId > 0)
			{
				list = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList j) => j.FKJobOrderDetailsID == (long?)(long)masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["WorkOrderList"];
				if (obj == null)
				{
					list = new List<WorkOrderList>();
					HttpContext.Current.Session["WorkOrderList"] = list;
				}
				else
				{
					list = obj as List<WorkOrderList>;
				}
			}
			return list;
		}

		public bool InsertWithSession(WorkOrderList entity)
		{
			string message = "";
			if (entity.FKJobOrderDetailsID == 0)
			{
				object obj = HttpContext.Current.Session["WorkOrderList"];
				List<WorkOrderList> list = ((obj != null) ? (obj as List<WorkOrderList>) : new List<WorkOrderList>());
				entity.WorkOrderID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["WorkOrderList"] = list;
				return true;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(WorkOrderList entity)
		{
			string message = "";
			if (entity.FKJobOrderDetailsID == 0)
			{
				object obj = HttpContext.Current.Session["WorkOrderList"];
				List<WorkOrderList> list = ((obj == null) ? new List<WorkOrderList>() : (obj as List<WorkOrderList>));
				list.First((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID);
				HttpContext.Current.Session["WorkOrderList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(WorkOrderList entity)
		{
			string message = "";
			if (entity.FKJobOrderDetailsID == 0)
			{
				object obj = HttpContext.Current.Session["WorkOrderList"];
				List<WorkOrderList> list;
				if (obj != null)
				{
					list = obj as List<WorkOrderList>;
					list.RemoveAll((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID);
				}
				else
				{
					list = new List<WorkOrderList>();
				}
				HttpContext.Current.Session["WorkOrderList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<WorkOrderList> GetByMasterIDFromSession(long masterId, long mainMasterId)
		{
			object obj = HttpContext.Current.Session["WorkOrderList"];
			List<WorkOrderList> list;
			if (obj == null)
			{
				list = ((mainMasterId <= 0 || masterId <= 0) ? new List<WorkOrderList>() : ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList j) => j.FKJobOrderDetailsID == (long?)masterId).ToList());
			}
			else
			{
				list = obj as List<WorkOrderList>;
				if (mainMasterId > 0 && list.Count((WorkOrderList x) => x.FKJobOrderDetailsID == masterId) == 0)
				{
					list.AddRange(((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList j) => j.FKJobOrderDetailsID == (long?)masterId).ToList());
				}
			}
			foreach (WorkOrderList item in list)
			{
				item.FKJobOrderMasterID = mainMasterId;
			}
			HttpContext.Current.Session["WorkOrderList"] = list;
			return list.Where((WorkOrderList x) => x.FKJobOrderDetailsID == masterId && x.RowStatus != 3).ToList();
		}

		public WorkOrderList GetByIDFromSession(long id)
		{
			object obj = HttpContext.Current.Session["WorkOrderList"];
			List<WorkOrderList> source = ((obj == null) ? new List<WorkOrderList>() : (obj as List<WorkOrderList>));
			return source.FirstOrDefault((WorkOrderList j) => j.WorkOrderID == id);
		}

		public bool InsertToSession(WorkOrderList entity)
		{
			object obj = HttpContext.Current.Session["WorkOrderList"];
			if (obj != null)
			{
				List<WorkOrderList> list = obj as List<WorkOrderList>;
				entity.WorkOrderID = ((list.Count > 0) ? (list.Max((WorkOrderList x) => x.WorkOrderID) + 1) : 1);
				entity.RowStatus = 1;
				list.Add(entity);
				HttpContext.Current.Session["WorkOrderList"] = list;
			}
			return true;
		}

		public bool UpdateToSession(WorkOrderList entity)
		{
			object obj = HttpContext.Current.Session["WorkOrderList"];
			if (obj != null)
			{
				if (!checkValidate(entity))
				{
					throw new Exception("invalid date ,check timesheet");
				}
				List<WorkOrderList> list = obj as List<WorkOrderList>;
				list.RemoveAll((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID);
				if (entity.FKJobOrderMasterID == 0)
				{
					entity.RowStatus = 1;
				}
				else
				{
					entity.RowStatus = 2;
				}
				list.Add(entity);
				HttpContext.Current.Session["WorkOrderList"] = list;
			}
			return true;
		}

		public bool DeleteFromSession(long original_WorkOrderID)
		{
			object obj = HttpContext.Current.Session["WorkOrderList"];
			if (obj != null)
			{
				List<WorkOrderList> list = obj as List<WorkOrderList>;
				WorkOrderList entity = list.FirstOrDefault((WorkOrderList x) => x.WorkOrderID == original_WorkOrderID);
				if (entity.FKJobOrderMasterID == 0)
				{
					list.RemoveAll((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID);
				}
				WorkOrderList workOrderList = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID).FirstOrDefault();
				if (workOrderList == null)
				{
					list.RemoveAll((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID);
				}
				else
				{
					entity.RowStatus = 3;
				}
				HttpContext.Current.Session["WorkOrderList"] = list;
			}
			return true;
		}

		public bool UpdateDetailsFromSession()
		{
			object obj = HttpContext.Current.Session["WorkOrderList"];
			if (obj != null)
			{
				List<WorkOrderList> source = obj as List<WorkOrderList>;
				foreach (WorkOrderList item in source.Where((WorkOrderList x) => x.RowStatus == 1).ToList())
				{
					Insert(item);
				}
				foreach (WorkOrderList item2 in source.Where((WorkOrderList x) => x.RowStatus == 2).ToList())
				{
					Update(item2);
				}
				foreach (WorkOrderList item3 in source.Where((WorkOrderList x) => x.RowStatus == 3).ToList())
				{
					Delete(item3);
				}
			}
			HttpContext.Current.Session["WorkOrderList"] = null;
			return true;
		}

		private bool checkValidate(WorkOrderList entity)
		{
			WorkOrderList byID = GetByID(entity.WorkOrderID);
			if (byID != null)
			{
				DateTime value = entity.StartDate.Value;
				DateTime value2 = entity.EndDate.Value;
				DateTime value3 = byID.StartDate.Value;
				DateTime value4 = byID.EndDate.Value;
				if (value > value3)
				{
					DateTime dateTime = value3;
					while (dateTime <= value)
					{
						WorkOrderTimeSheet byWorkOrderByDate = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(dateTime, entity.WorkOrderID);
						if (byWorkOrderByDate != null)
						{
							return false;
						}
						dateTime = dateTime.AddDays(1.0);
					}
					return true;
				}
				if (value2 < value4)
				{
					DateTime dateTime2 = value2;
					while (dateTime2 <= value4)
					{
						WorkOrderTimeSheet byWorkOrderByDate2 = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(dateTime2, entity.WorkOrderID);
						if (byWorkOrderByDate2 != null)
						{
							return false;
						}
						dateTime2 = dateTime2.AddDays(1.0);
					}
					return true;
				}
			}
			return true;
		}

		public string GetMaxWorkOrderNo()
		{
			long maxNo = 0L;
			if (((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Count() > 0)
			{
				maxNo = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Max((WorkOrderList x) => x.WorkOrderID);
				maxNo = Convert.ToInt64(((IQueryable<WorkOrderList>)dbContext.WorkOrderList).FirstOrDefault((WorkOrderList x) => x.WorkOrderID == maxNo).WorkOrderNo);
			}
			return (maxNo + 1).ToString();
		}

		public string GetWorkOrderNo()
		{
			if (HttpContext.Current.Session["JOWorkOrderNumber"] != null)
			{
				string text = HttpContext.Current.Session["JOWorkOrderNumber"].ToString();
				long num = int.Parse(text) + 1;
				HttpContext.Current.Session["JOWorkOrderNumber"] = num;
				return text;
			}
			return "";
		}

		public List<long?> GetAllJobOrderID()
		{
			return ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Select((WorkOrderList x) => x.FKJobOrderDetailsID).Distinct().ToList();
		}

		public List<WorkOrderList> GetbyMasterId(long JobOrderDetailsID)
		{
			return (from x in (IQueryable<WorkOrderList>)dbContext.WorkOrderList
				where x.FKJobOrderDetailsID == (long?)JobOrderDetailsID
				orderby x.WorkOrderID descending
				select x).ToList();
		}

		public List<WorkOrderList> GetByJobOrderID(long id)
		{
			return (from j in (IQueryable<WorkOrderList>)dbContext.WorkOrderList
				where j.JobOrderDetails.FKJobOrderMasterID == id
				select j into x
				orderby x.WorkOrderID descending
				select x).ToList();
		}

		public List<WorkOrderList> GetAllPendingActive()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
			List<WorkOrderList> list2 = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => (DateTime)x.EndDate >= (DateTime)(DateTime?)DateTime.Today).ToList();
			foreach (WorkOrderList item in list2)
			{
				int num = new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID).Count();
				if ((double)num < (DateTime.Parse(item.EndDate.ToString()) - DateTime.Today).TotalDays)
				{
					list.Add(item);
				}
			}
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).Distinct().ToList();
		}

		public List<WorkOrderList> GetAllFinishedActive()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
			List<WorkOrderList> list2 = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => (DateTime)x.EndDate >= (DateTime)(DateTime?)DateTime.Today).ToList();
			foreach (WorkOrderList item in list2)
			{
				int num = new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID).Count();
				if ((double)num >= (DateTime.Parse(item.EndDate.ToString()) - DateTime.Today).TotalDays)
				{
					list.Add(item);
				}
			}
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public List<WorkOrderList> GetAllPendingExpired()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
			List<WorkOrderList> list2 = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => (DateTime)x.EndDate < (DateTime)(DateTime?)DateTime.Today).ToList();
			foreach (WorkOrderList item in list2)
			{
				int num = new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID).Count();
				if ((double)num < (DateTime.Parse(item.EndDate.ToString()) - DateTime.Parse(item.StartDate.ToString())).TotalDays)
				{
					list.Add(item);
				}
			}
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public List<WorkOrderList> GetAllFinishedExpired()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
			List<WorkOrderList> list2 = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => (DateTime)x.EndDate < (DateTime)(DateTime?)DateTime.Today).ToList();
			foreach (WorkOrderList item in list2)
			{
				double num = new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID).Count();
				double totalDays = (DateTime.Parse(item.EndDate.ToString()).AddDays(1.0) - DateTime.Parse(item.StartDate.ToString())).TotalDays;
				if (num == totalDays)
				{
					list.Add(item);
				}
			}
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public List<WorkOrderList> GetAllPendingCheckedFinishedExpiredWorkOrder()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
            List<WorkOrderList> list2 = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => x.WorkOrderTimeSheet.Any((WorkOrderTimeSheet y) => y.IsChecked == null || y.IsChecked.Value == false)).ToList();
                foreach (WorkOrderList item in list2)
                {
                    int num = (from x in new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID)
                               where x.IsChecked != true
                               select x).Count();
                    if (num > 0)
                    {
                        list.Add(item);
                    }
                }
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public List<WorkOrderList> GetAllPendingApproveFinishedExpiredWorkOrder()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
			List<WorkOrderList> list2 = ((IEnumerable<WorkOrderList>)dbContext.WorkOrderList).ToList();
			foreach (WorkOrderList item in list2)
			{
				int num = (from x in new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID)
					where x.IsChecked == true && x.IsApproved != true
					select x).Count();
				if (num > 0)
				{
					list.Add(item);
				}
			}
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public List<WorkOrderList> GetAllCheckedApproveFinishedExpiredWorkOrder()
		{
			List<WorkOrderList> list = new List<WorkOrderList>();
			List<WorkOrderList> list2 = ((IEnumerable<WorkOrderList>)dbContext.WorkOrderList).ToList();
			foreach (WorkOrderList item in list2)
			{
				if (item.EndDate.HasValue && item.StartDate.HasValue)
				{
					int num = (from x in new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID)
						where x.IsChecked == true && x.IsApproved == true
						select x).Count();
					if (num > 0)
					{
						list.Add(item);
					}
				}
			}
			return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
		}

		public List<WorkOrderList> GetAllWorkOrderbyJobOrderMasterID(DateTime FromDate, DateTime ToDate, int JobOrderMasterID, int masterId)
		{
			if (masterId > 0)
			{
				List<WorkOrderList> list = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => x.WorkOrderInvoice.Any((WorkOrderInvoice i) => i.FkInvoiceId == (long)masterId)).ToList();
				foreach (WorkOrderList item in list)
				{
					List<WorkOrderInvoice> byMasterID = new WorkOrderInvoiceDB().GetByMasterID(masterId);
					Func<WorkOrderInvoice, bool> predicate = (WorkOrderInvoice x) => x.FkWorkOrderId == item.WorkOrderID;
					DateTime startDate = byMasterID.Where(predicate).FirstOrDefault().StartDate;
					DateTime endDate = byMasterID.Where((WorkOrderInvoice x) => x.FkWorkOrderId == item.WorkOrderID).FirstOrDefault().EndDate;
					List<WorkOrderTimeSheet> source = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(startDate, endDate, item.WorkOrderID).ToList();
					item.StartDate = byMasterID.Where((WorkOrderInvoice x) => x.FkWorkOrderId == item.WorkOrderID).FirstOrDefault().StartDate;
					item.EndDate = byMasterID.Where((WorkOrderInvoice x) => x.FkWorkOrderId == item.WorkOrderID).FirstOrDefault().EndDate;
					if (item.ShiftStatus == 2)
					{
						item.DueAmount = source.ToList().Sum((WorkOrderTimeSheet x) => (x.TotalAdditionalPrice + x.TotalWorkingPrice) * (decimal?)(x.WorkOrderList.NightShiftPerc ?? 1m));
					}
					else
					{
						item.DueAmount = source.ToList().Sum((WorkOrderTimeSheet x) => x.TotalAdditionalPrice + x.TotalWorkingPrice);
					}
					item.IsInvoiced = true;
					item.IsChecked = true;
					item.IsEnabled = false;
					item.IsApproved = true;
				}
				return list.OrderByDescending((WorkOrderList x) => x.WorkOrderID).ToList();
			}
			List<WorkOrderList> list2 = new List<WorkOrderList>();
			List<SPGetWorkOrderToInvoice_Result> list3 = ((!(FromDate != default(DateTime)) || !(ToDate != default(DateTime))) ? ((IEnumerable<SPGetWorkOrderToInvoice_Result>)dbContext.SPGetWorkOrderToInvoice(null, null, JobOrderMasterID)).ToList() : ((IEnumerable<SPGetWorkOrderToInvoice_Result>)dbContext.SPGetWorkOrderToInvoice(FromDate, ToDate, JobOrderMasterID)).ToList());
			foreach (SPGetWorkOrderToInvoice_Result item2 in list3)
			{
				WorkOrderList byID = GetByID(item2.WorkOrderID);
				byID.IsApproved = Convert.ToBoolean(item2.IsApproved);
				byID.IsChecked = Convert.ToBoolean(item2.IsChecked);
				byID.IsInvoiced = false;
				if (Convert.ToBoolean(item2.IsApproved) && Convert.ToBoolean(item2.IsChecked))
				{
					byID.IsEnabled = true;
				}
				else
				{
					byID.IsEnabled = false;
				}
				byID.DueAmount = item2.DueAmount;
				byID.StartDate = item2.StartDate;
				byID.EndDate = item2.EndDate;
				list2.Add(byID);
			}
			return list2;
		}

		public decimal GetAllWorkOrderbyDueAmountJobOrderMasterID(long JobOrderMasterID)
		{
			List<WorkOrderTimeSheet> list = ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet x) => x.WorkOrderList.JobOrderDetails.FKJobOrderMasterID == JobOrderMasterID && x.IsInvoiced != (bool?)true).ToList();
			decimal? d = 0m;
			foreach (WorkOrderTimeSheet item in list)
			{
				if (item.TotalAdditionalPrice.HasValue && item.TotalWorkingPrice.HasValue)
				{
					if (item.WorkOrderList.ShiftStatus == 2)
					{
						decimal? num = (item.TotalAdditionalPrice + item.TotalWorkingPrice) * (decimal?)((item.WorkOrderList.NightShiftPerc ?? 0m) / 100m);
						d += (decimal?)(item.TotalAdditionalPrice.Value + item.TotalWorkingPrice.Value + num.Value);
					}
					else
					{
						d += (decimal?)(item.TotalAdditionalPrice.Value + item.TotalWorkingPrice.Value);
					}
				}
			}
			return d.Value;
		}

		public List<WorkOrderList> GetByIdFromView(int id)
		{
			return (from x in (IQueryable<WorkOrderList>)dbContext.WorkOrderList
				where x.WorkOrderID == (long)id
				orderby x.WorkOrderID descending
				select x).ToList();
		}

		public bool UpdateInvoiceedToSession(WorkOrderList entity)
		{
			object obj = HttpContext.Current.Session["WorkOrderListInvoiced"];
			List<WorkOrderList> list = ((obj != null) ? (obj as List<WorkOrderList>) : new List<WorkOrderList>());
			WorkOrderList item = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => x.WorkOrderID == entity.WorkOrderID).FirstOrDefault();
			list.Add(item);
			HttpContext.Current.Session["WorkOrderListInvoiced"] = list;
			return true;
		}

		public bool UpdateInvoiceedFromSession()
		{
			object obj = HttpContext.Current.Session["WorkOrderListInvoiced"];
			if (obj != null)
			{
				List<WorkOrderList> list = obj as List<WorkOrderList>;
				foreach (WorkOrderList item in list)
				{
					Update(item);
				}
			}
			HttpContext.Current.Session["WorkOrderListInvoiced"] = null;
			return true;
		}

		public decimal GetAllPendingEntryAmount(long JobOrderID)
		{
			List<WorkOrderList> list = ((IQueryable<WorkOrderList>)dbContext.WorkOrderList).Where((WorkOrderList x) => x.JobOrderDetails.FKJobOrderMasterID == JobOrderID).ToList();
			decimal? d = 0m;
			foreach (WorkOrderList item in list)
			{
				int num = new WorkOrderTimeSheetDB().GetByWorkOrderID(item.WorkOrderID).Count();
				int num2 = 0;
				if (!((double)num < (DateTime.Parse(item.EndDate.ToString()) - DateTime.Today).TotalDays))
				{
					continue;
				}
				num2 = ((num > 0) ? ((int)(item.EndDate.Value - item.StartDate.Value).TotalDays - num) : ((int)(item.EndDate.Value - item.StartDate.Value).TotalDays));
				decimal? regularWorkHrs = item.RegularWorkHrs;
				decimal? d2 = item.MonthlyRate / (regularWorkHrs * (decimal?)30m);
				new decimal?(0m);
				if (item.ShiftStatus == 2)
				{
					decimal? num3 = regularWorkHrs;
					decimal d3 = (item.NightShiftPerc ?? 0m) / 100m;
					if (num3.HasValue)
					{
						new decimal?(num3.GetValueOrDefault() * d3);
					}
					d += (regularWorkHrs = regularWorkHrs * d2 * (decimal?)num2);
				}
				else
				{
					d += (regularWorkHrs = regularWorkHrs * d2 * (decimal?)num2);
				}
			}
			return d.Value;
		}
	}
}
