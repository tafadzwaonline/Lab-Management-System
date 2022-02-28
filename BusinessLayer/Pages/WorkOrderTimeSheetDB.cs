using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class WorkOrderTimeSheetDB : DBBase<WorkOrderTimeSheet, List<WorkOrderTimeSheet>, long>
	{
		public override List<WorkOrderTimeSheet> GetAll()
		{
			return ((IEnumerable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).ToList();
		}

		public override WorkOrderTimeSheet GetByID(long id)
		{
			return ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).FirstOrDefault((WorkOrderTimeSheet j) => j.WorkOrderTimeSheetId == id);
		}

		public override bool Insert(WorkOrderTimeSheet entity, out string message)
		{
			message = "";
			try
			{
				dbContext.WorkOrderTimeSheet.Add(entity);
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

		public override bool Update(WorkOrderTimeSheet entity, out string message)
		{
			message = "";
			try
			{
				WorkOrderTimeSheet byID = GetByID(entity.WorkOrderTimeSheetId);
				if (byID != null)
				{
					DbEntityEntry val = ((DbContext)dbContext).Entry<WorkOrderTimeSheet>(byID);
					val.State = (EntityState)16;
					val.CurrentValues.SetValues((object)entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "UpdateError";
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(WorkOrderTimeSheet entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<WorkOrderTimeSheet>(entity).State = (EntityState)8;
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

		public bool Insert(WorkOrderTimeSheet entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(WorkOrderTimeSheet entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(WorkOrderTimeSheet entity)
		{
			string message = "";
			if (Delete(entity.WorkOrderTimeSheetId, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<WorkOrderTimeSheet> GetByWorkOrderID(long WorkOrderID)
		{
			return ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet j) => j.FkWorkOrderID == WorkOrderID).ToList();
		}

		public List<WorkOrderTimeSheet> GetByWorkOrderIDWithSession(long WorkOrderID)
		{
			List<WorkOrderTimeSheet> byWorkOrderID = GetByWorkOrderID(WorkOrderID);
			List<WorkOrderTimeSheet> value;
			if (byWorkOrderID.Count > 0)
			{
				List<WorkOrderTimeSheet> list = HttpContext.Current.Session["WorkOrderTimeSheetList"] as List<WorkOrderTimeSheet>;
				if (list == null)
				{
					value = new List<WorkOrderTimeSheet>();
					HttpContext.Current.Session["WorkOrderTimeSheetList"] = value;
				}
				value = list;
			}
			else
			{
				object obj = HttpContext.Current.Session["WorkOrderTimeSheetList"];
				if (obj == null)
				{
					value = new List<WorkOrderTimeSheet>();
					HttpContext.Current.Session["WorkOrderTimeSheetList"] = value;
				}
				else
				{
					value = obj as List<WorkOrderTimeSheet>;
				}
			}
			return value;
		}

		public WorkOrderTimeSheet GetByWorkOrderByDate(DateTime StartDate, long WorkOrderID)
		{
			return ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet j) => (DateTime)j.StartDate == (DateTime)(DateTime?)StartDate && j.FkWorkOrderID == WorkOrderID).FirstOrDefault();
		}


        public List<WorkOrderTimeSheet> GetByWorkOrderListByDate(DateTime StartDate, long WorkOrderID)
        {
            return ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet j) => (DateTime)j.StartDate == (DateTime)(DateTime?)StartDate && j.FkWorkOrderID == WorkOrderID).ToList();
        }

        public List<ViewWorkOrderList> test(int id)
        {
            return ((IQueryable<ViewWorkOrderList>)dbContext.ViewWorkOrderList).Where((ViewWorkOrderList j) =>  j.WorkOrderID == id).ToList();
        }

        public List<WorkOrderTimeSheet> GetByWorkOrderByDate(DateTime StartDate, DateTime EndDate, long WorkOrderID)
		{
			List<WorkOrderTimeSheet> list = new List<WorkOrderTimeSheet>();
			WorkOrderList byID = new WorkOrderListDB().GetByID(WorkOrderID);
			DateTime value = StartDate;
			DateTime? startDate = byID.StartDate;
			if (value < startDate)
			{
				StartDate = byID.StartDate.Value;
			}
			DateTime? endDate = byID.EndDate;
			if (EndDate > endDate)
			{
				StartDate = byID.StartDate.Value;
			}
			long num = new WorkOrderTimeSheetDB().GetLastID(WorkOrderID).Value;
			DateTime dateTime = StartDate;
			while (dateTime <= EndDate)
			{
				WorkOrderTimeSheet byWorkOrderByDate = GetByWorkOrderByDate(dateTime, WorkOrderID);
				if (byWorkOrderByDate == null)
				{
					WorkOrderTimeSheet workOrderTimeSheet = new WorkOrderTimeSheet();
					workOrderTimeSheet.WorkOrderTimeSheetId = num + 1;
					num++;
					workOrderTimeSheet.FkWorkOrderID = WorkOrderID;
					workOrderTimeSheet.StartDate = dateTime;
					workOrderTimeSheet.EndDate = dateTime;
					workOrderTimeSheet.Day = dateTime.DayOfWeek.ToString();
					workOrderTimeSheet.Breake = 0m;
					workOrderTimeSheet.EndTime = null;
					workOrderTimeSheet.FkEmpID = null;
					workOrderTimeSheet.InvoiceNumber = "";
					workOrderTimeSheet.IsInvoiced = false;
					workOrderTimeSheet.IsRamadan = false;
					workOrderTimeSheet.Remarks = null;
					workOrderTimeSheet.StartTime = null;
					workOrderTimeSheet.WorkHrs = 0m;
					workOrderTimeSheet.WorkStatus = null;
					workOrderTimeSheet.ShiftStatus = null;
					list.Add(workOrderTimeSheet);
                    dbContext.SaveChanges();
                }
				else
				{
					list.Add(byWorkOrderByDate);
				}
				dateTime = dateTime.AddDays(1.0);
			}
			return list;
		}

		public List<WorkOrderTimeSheet> GetPendingCheckTimeSheet(DateTime StartDate, DateTime EndDate, long WorkOrderID)
		{
			List<WorkOrderTimeSheet> list = new List<WorkOrderTimeSheet>();
			if (StartDate != default(DateTime) && EndDate != default(DateTime))
			{
				DateTime dateTime = StartDate;
				while (dateTime <= EndDate)
				{
					List<WorkOrderTimeSheet> byWorkOrderByDate = GetByWorkOrderListByDate(dateTime, WorkOrderID);
                    foreach (WorkOrderTimeSheet work in byWorkOrderByDate)
                    {
                        if (work != null && work.IsChecked != true)
                        {
                            list.Add(work);
                        }
                    }
					dateTime = dateTime.AddDays(1.0);
				}
			}
			else
			{
				list = ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet x) => x.IsChecked != (bool?)true && x.FkWorkOrderID == WorkOrderID).ToList();
			}
			return list;
		}

		public List<WorkOrderTimeSheet> GetPendingApproveTimeSheet(DateTime StartDate, DateTime EndDate, long WorkOrderID)
		{
			List<WorkOrderTimeSheet> list = new List<WorkOrderTimeSheet>();
			if (StartDate != default(DateTime) && EndDate != default(DateTime))
			{
				DateTime dateTime = StartDate;
				while (dateTime <= EndDate)
				{
                    List<WorkOrderTimeSheet> byWorkOrderByDate = GetByWorkOrderListByDate(dateTime, WorkOrderID);
                    foreach (WorkOrderTimeSheet work in byWorkOrderByDate)
                    {
                        if (work != null && work.IsChecked == true && work.IsApproved != true)
                        {
                            list.Add(work);
                        }
                    }
                    dateTime = dateTime.AddDays(1.0);
                }
			}
			else
			{
				list = ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet x) => x.IsChecked == (bool?)true && x.IsApproved != (bool?)true && x.FkWorkOrderID == WorkOrderID).ToList();
			}
			return list;
		}

		public bool UpdateMappingWithSession(WorkOrderTimeSheet entity)
		{
			WorkOrderTimeSheet byID = GetByID(entity.WorkOrderTimeSheetId);
			long num = Convert.ToInt64(HttpContext.Current.Session["FkWorkOrderID"].ToString());
			if (byID != null && byID.FkWorkOrderID == num)
			{
				if (entity.FkEmpID.HasValue)
				{
					byID.WorkOrderTimeSheetId = entity.WorkOrderTimeSheetId;
					byID.Breake = entity.Breake;
					byID.Day = entity.Day;
					byID.EndDate = entity.EndDate;
					byID.FkEmpID = entity.FkEmpID;
					byID.FkWorkOrderID = num;
					byID.InvoiceNumber = entity.InvoiceNumber;
					byID.IsInvoiced = entity.IsInvoiced;
					byID.IsRamadan = entity.IsRamadan;
					byID.Remarks = "";
					byID.StartDate = entity.StartDate;
					byID.IsChecked = entity.IsChecked;
					if (entity.IsChecked == true)
					{
						byID.CheckedBy = long.Parse(HttpContext.Current.Session["UserId"].ToString());
						byID.CheckedDate = DateTime.Now;
					}
					byID.IsApproved = entity.IsApproved;
					if (entity.IsApproved == true)
					{
						byID.ApprovedBy = long.Parse(HttpContext.Current.Session["UserId"].ToString());
						byID.ApprovedDate = DateTime.Now;
						decimal? regularWorkHrs = new WorkOrderListDB().GetByID(num).RegularWorkHrs;
						decimal? ramadanWorkHrs = new WorkOrderListDB().GetByID(num).RamadanWorkHrs;
						decimal? monthlyRate = new WorkOrderListDB().GetByID(num).MonthlyRate;
						int value = DateTime.DaysInMonth(entity.StartDate.Value.Year, entity.StartDate.Value.Month);
						decimal? num3 = (byID.HourlyRate = monthlyRate / (regularWorkHrs * (decimal?)value));
						decimal? num4 = (byID.OTRate = new WorkOrderListDB().GetByID(num).ExtraWorkHourRate);
						if (byID.WorkStatus == "Holiday")
						{
							decimal? num6 = (byID.NormalWorkingHours = (byID.OTWorkingHours = byID.WorkHrs));
							byID.NormalWorkingHours = 0m;
							byID.RamadanWorkingHours = 0m;
						}
						else if (byID.IsRamadan == true)
						{
							if (byID.WorkHrs != ramadanWorkHrs)
							{
								byID.RamadanWorkingHours = ramadanWorkHrs;
							}
							else
							{
								byID.RamadanWorkingHours = byID.WorkHrs;
							}
							byID.OTWorkingHours = byID.WorkHrs - ramadanWorkHrs;
							decimal? oTWorkingHours = byID.OTWorkingHours;
							if (oTWorkingHours.GetValueOrDefault() < 0m && oTWorkingHours.HasValue)
							{
								byID.OTWorkingHours = 0m;
							}
							byID.NormalWorkingHours = 0m;
						}
						else
						{
							if (byID.WorkHrs != regularWorkHrs)
							{
								byID.NormalWorkingHours = regularWorkHrs;
							}
							else
							{
								byID.NormalWorkingHours = byID.WorkHrs;
							}
							byID.OTWorkingHours = byID.WorkHrs - regularWorkHrs;
							decimal? oTWorkingHours2 = byID.OTWorkingHours;
							if (oTWorkingHours2.GetValueOrDefault() < 0m && oTWorkingHours2.HasValue)
							{
								byID.OTWorkingHours = 0m;
							}
							byID.RamadanWorkingHours = 0m;
						}
						byID.TotalWorkingPrice = regularWorkHrs * byID.HourlyRate;
						byID.TotalAdditionalPrice = byID.OTWorkingHours * byID.OTRate;
					}
					if (entity.StartTime.HasValue)
					{
						DateTime dateTime = DateTime.Parse(entity.StartDate.ToString());
						DateTime dateTime2 = DateTime.Parse(entity.StartTime.ToString());
						DateTime value2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime2.Hour, dateTime2.Minute, 0);
						byID.StartTime = value2;
					}
					else
					{
						byID.StartTime = entity.StartTime;
					}
					if (entity.EndTime.HasValue)
					{
						DateTime dateTime3 = DateTime.Parse(entity.EndDate.ToString());
						DateTime dateTime4 = DateTime.Parse(entity.EndTime.ToString());
						DateTime value3 = new DateTime(dateTime3.Year, dateTime3.Month, dateTime3.Day, dateTime4.Hour, dateTime4.Minute, 0);
						byID.EndTime = value3;
					}
					else
					{
						byID.EndTime = entity.EndTime;
					}
					if (entity.EndTime.HasValue && entity.StartTime.HasValue)
					{
						TimeSpan timeSpan = TimeSpan.Parse((entity.EndTime - entity.StartTime).ToString(), CultureInfo.InvariantCulture);
						if (entity.Breake.HasValue)
						{
							WorkOrderTimeSheet workOrderTimeSheet = byID;
							decimal value4 = decimal.Parse(timeSpan.TotalHours.ToString());
							decimal? breake = entity.Breake;
							workOrderTimeSheet.WorkHrs = (decimal?)value4 - breake;
						}
						else
						{
							byID.WorkHrs = decimal.Parse(timeSpan.TotalHours.ToString());
						}
					}
					else
					{
						byID.WorkHrs = 0m;
					}
					byID.WorkStatus = entity.WorkStatus;
					byID.ShiftStatus = entity.ShiftStatus;
					Update(byID);
					return ((DbContext)dbContext).SaveChanges() > 0;
				}
				Delete(byID);
			}
			else if (entity.FkEmpID.HasValue)
			{
				byID = new WorkOrderTimeSheet();
				byID.Breake = entity.Breake;
				byID.Day = entity.Day;
				byID.EndDate = entity.EndDate;
				byID.FkEmpID = entity.FkEmpID;
				byID.FkWorkOrderID = num;
				byID.InvoiceNumber = entity.InvoiceNumber;
				byID.IsInvoiced = entity.IsInvoiced;
				byID.IsRamadan = entity.IsRamadan;
				byID.Remarks = "";
				byID.StartDate = entity.StartDate;
				if (entity.StartTime.HasValue)
				{
					DateTime dateTime5 = DateTime.Parse(entity.StartDate.ToString());
					DateTime dateTime6 = DateTime.Parse(entity.StartTime.ToString());
					DateTime value5 = new DateTime(dateTime5.Year, dateTime5.Month, dateTime5.Day, dateTime6.Hour, dateTime6.Minute, 0);
					byID.StartTime = value5;
				}
				else
				{
					byID.StartTime = entity.StartTime;
				}
				if (entity.EndTime.HasValue)
				{
					DateTime dateTime7 = DateTime.Parse(entity.EndDate.ToString());
					DateTime dateTime8 = DateTime.Parse(entity.EndTime.ToString());
					DateTime value6 = new DateTime(dateTime7.Year, dateTime7.Month, dateTime7.Day, dateTime8.Hour, dateTime8.Minute, 0);
					byID.EndTime = value6;
				}
				else
				{
					byID.EndTime = entity.EndTime;
				}
				byID.WorkHrs = entity.WorkHrs;
				byID.WorkStatus = entity.WorkStatus;
				byID.ShiftStatus = entity.ShiftStatus;
				if (byID.FkEmpID.HasValue)
				{
					Insert(byID);
					return ((DbContext)dbContext).SaveChanges() > 0;
				}
			}
			return ((DbContext)dbContext).SaveChanges() > 0;
		}

		public List<WorkOrderTimeSheet> GetAllExpired(long WorkOrderID)
		{
			return ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Where((WorkOrderTimeSheet x) => (DateTime)x.EndDate < (DateTime)(DateTime?)DateTime.Today && x.FkWorkOrderID == WorkOrderID).ToList();
		}

		public List<WorkOrderTimeSheet> GetAllActive(DateTime StartDate, DateTime EndDate, long WorkOrderID, string mode)
		{
			List<WorkOrderTimeSheet> result = new List<WorkOrderTimeSheet>();
            //var work = dbContext.WorkOrderList.Where(x=>x.WorkOrderID==WorkOrderID && x.EndDate <=EndDate).FirstOrDefault();

            //EndDate = Convert.ToDateTime(work.EndDate);
            if ((mode == "0" || mode == "View") && StartDate == default(DateTime) && EndDate == default(DateTime))
			{
				result = GetByWorkOrderIDWithSession(WorkOrderID);
			}
			else if ((mode == "0" || mode == "View") && StartDate != default(DateTime) && EndDate != default(DateTime) && HttpContext.Current.Session["Bind"] != null && HttpContext.Current.Session["Bind"] == "True")
			{
				result = GetByWorkOrderByDate(StartDate, EndDate, WorkOrderID);
			}
			else if ((mode == "0" || mode == "View") && StartDate != default(DateTime) && EndDate != default(DateTime) && HttpContext.Current.Session["Bind"] == null)
			{
				result = null;
			}
			else if (mode == "Check")
			{
				result = GetPendingCheckTimeSheet(StartDate, EndDate, WorkOrderID);
			}
			else if (mode == "Approve")
			{
				result = GetPendingApproveTimeSheet(StartDate, EndDate, WorkOrderID);
			}
			return result;
		}

		public long? GetLastID(long WorkOrderId)
		{
			return ((IQueryable<WorkOrderTimeSheet>)dbContext.WorkOrderTimeSheet).Max((Expression<Func<WorkOrderTimeSheet, long?>>)((WorkOrderTimeSheet entity) => entity.WorkOrderTimeSheetId)) ?? new long?(0L);
		}
	}
}
