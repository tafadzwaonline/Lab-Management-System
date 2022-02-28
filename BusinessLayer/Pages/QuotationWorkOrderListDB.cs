using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class QuotationWorkOrderListDB : DBBase<QuotationWorkOrderList, List<QuotationWorkOrderList>, long>
	{
		public override List<QuotationWorkOrderList> GetAll()
		{
			return ((IEnumerable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).ToList();
		}

		public override QuotationWorkOrderList GetByID(long id)
		{
			return ((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).FirstOrDefault((QuotationWorkOrderList j) => j.QuotationWorkOrderID == id);
		}

		public override bool Insert(QuotationWorkOrderList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.QuotationWorkOrderList.Add(entity);
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

		public override bool Update(QuotationWorkOrderList entity, out string message)
		{
			message = "";
			try
			{
				QuotationWorkOrderList byID = GetByID(entity.QuotationWorkOrderID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<QuotationWorkOrderList>(byID);
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

		public override bool Delete(QuotationWorkOrderList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<QuotationWorkOrderList>(entity).State = (EntityState)8;
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

		public bool Insert(QuotationWorkOrderList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(QuotationWorkOrderList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(QuotationWorkOrderList entity)
		{
			string message = "";
			if (Delete(entity.QuotationWorkOrderID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<QuotationWorkOrderList> GetByMasterIDWithSession(int masterId)
		{
			List<QuotationWorkOrderList> list;
			if (masterId > 0)
			{
				list = ((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Where((QuotationWorkOrderList j) => j.FkQuotationDetailsID == (long?)(long)masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
				if (obj == null)
				{
					list = new List<QuotationWorkOrderList>();
					HttpContext.Current.Session["QuotationWorkOrderList"] = list;
				}
				else
				{
					list = obj as List<QuotationWorkOrderList>;
				}
			}
			return list;
		}

		public bool InsertWithSession(QuotationWorkOrderList entity)
		{
			string message = "";
			if (entity.FkQuotationDetailsID == 0)
			{
				object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
				List<QuotationWorkOrderList> list = ((obj != null) ? (obj as List<QuotationWorkOrderList>) : new List<QuotationWorkOrderList>());
				entity.QuotationWorkOrderID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["QuotationWorkOrderList"] = list;
				return true;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(QuotationWorkOrderList entity)
		{
			string message = "";
			if (entity.FkQuotationDetailsID == 0)
			{
				object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
				List<QuotationWorkOrderList> list = ((obj == null) ? new List<QuotationWorkOrderList>() : (obj as List<QuotationWorkOrderList>));
				list.First((QuotationWorkOrderList x) => x.QuotationWorkOrderID == entity.QuotationWorkOrderID);
				HttpContext.Current.Session["QuotationWorkOrderList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(QuotationWorkOrderList entity)
		{
			string message = "";
			if (entity.FkQuotationDetailsID == 0)
			{
				object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
				List<QuotationWorkOrderList> list;
				if (obj != null)
				{
					list = obj as List<QuotationWorkOrderList>;
					list.RemoveAll((QuotationWorkOrderList x) => x.QuotationWorkOrderID == entity.QuotationWorkOrderID);
				}
				else
				{
					list = new List<QuotationWorkOrderList>();
				}
				HttpContext.Current.Session["QuotationWorkOrderList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<QuotationWorkOrderList> GetByMasterIDFromSession(long masterId, long mainMasterId)
		{
			object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
			List<QuotationWorkOrderList> list;
			if (obj == null)
			{
				list = ((mainMasterId <= 0 || masterId <= 0) ? new List<QuotationWorkOrderList>() : ((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Where((QuotationWorkOrderList j) => j.FkQuotationDetailsID == (long?)masterId).ToList());
			}
			else
			{
				list = obj as List<QuotationWorkOrderList>;
				if (mainMasterId > 0 && list.Count((QuotationWorkOrderList x) => x.FkQuotationDetailsID == masterId) == 0)
				{
					list.AddRange(((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Where((QuotationWorkOrderList j) => j.FkQuotationDetailsID == (long?)masterId).ToList());
				}
			}
			foreach (QuotationWorkOrderList item in list)
			{
				item.FKQuotationMasterID = mainMasterId;
			}
			HttpContext.Current.Session["QuotationWorkOrderList"] = list;
			return list.Where((QuotationWorkOrderList x) => x.FkQuotationDetailsID == masterId && x.RowStatus != 3).ToList();
		}

		public QuotationWorkOrderList GetByIDFromSession(long id)
		{
			object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
			List<QuotationWorkOrderList> source = ((obj == null) ? new List<QuotationWorkOrderList>() : (obj as List<QuotationWorkOrderList>));
			return source.Distinct().FirstOrDefault((QuotationWorkOrderList j) => j.QuotationWorkOrderID == id);
		}

		public bool InsertToSession(QuotationWorkOrderList entity)
		{
			object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
			if (obj != null)
			{
				List<QuotationWorkOrderList> list = obj as List<QuotationWorkOrderList>;
				entity.QuotationWorkOrderID = ((list.Count > 0) ? (list.Max((QuotationWorkOrderList x) => x.QuotationWorkOrderID) + 1) : 1);
				entity.RowStatus = 1;
				list.Add(entity);
				HttpContext.Current.Session["QuotationWorkOrderList"] = list;
			}
			return true;
		}

		public bool UpdateToSession(QuotationWorkOrderList entity)
		{
			object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
			if (obj != null)
			{
				List<QuotationWorkOrderList> list = obj as List<QuotationWorkOrderList>;
				list.RemoveAll((QuotationWorkOrderList x) => x.QuotationWorkOrderID == entity.QuotationWorkOrderID);
				if (entity.FKQuotationMasterID == 0)
				{
					entity.RowStatus = 1;
				}
				else
				{
					entity.RowStatus = 2;
				}
				list.Add(entity);
				HttpContext.Current.Session["QuotationWorkOrderList"] = list;
			}
			return true;
		}

		public bool DeleteFromSession(long original_QuotationWorkOrderID)
		{
			object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
			if (obj != null)
			{
				List<QuotationWorkOrderList> list = obj as List<QuotationWorkOrderList>;
				QuotationWorkOrderList entity = list.FirstOrDefault((QuotationWorkOrderList x) => x.QuotationWorkOrderID == original_QuotationWorkOrderID);
				if (entity.FKQuotationMasterID == 0)
				{
					list.RemoveAll((QuotationWorkOrderList x) => x.QuotationWorkOrderID == entity.QuotationWorkOrderID);
				}
				else
				{
					entity.RowStatus = 3;
				}
				HttpContext.Current.Session["QuotationWorkOrderList"] = list;
			}
			return true;
		}

		public bool UpdateDetailsFromSession()
		{
			object obj = HttpContext.Current.Session["QuotationWorkOrderList"];
			if (obj != null)
			{
				List<QuotationWorkOrderList> source = obj as List<QuotationWorkOrderList>;
				foreach (QuotationWorkOrderList item in source.Where((QuotationWorkOrderList x) => x.RowStatus == 1).Distinct().ToList())
				{
					Insert(item);
				}
				foreach (QuotationWorkOrderList item2 in source.Where((QuotationWorkOrderList x) => x.RowStatus == 2).Distinct().ToList())
				{
					Update(item2);
				}
				foreach (QuotationWorkOrderList item3 in source.Where((QuotationWorkOrderList x) => x.RowStatus == 3).ToList())
				{
					Delete(item3);
				}
			}
			HttpContext.Current.Session["QuotationWorkOrderList"] = null;
			return true;
		}

		public string GetMaxWorkOrderNo()
		{
			long maxNo = 0L;
			if (((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Count() > 0)
			{
				maxNo = ((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Max((QuotationWorkOrderList x) => x.QuotationWorkOrderID);
				maxNo = Convert.ToInt64(((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).FirstOrDefault((QuotationWorkOrderList x) => x.QuotationWorkOrderID == maxNo).WorkOrderNo);
			}
			return (maxNo + 1).ToString();
		}

		public string GetWorkOrderNo()
		{
			if (HttpContext.Current.Session["WorkOrderNumber"] != null)
			{
				string text = HttpContext.Current.Session["WorkOrderNumber"].ToString();
				long num = int.Parse(text) + 1;
				HttpContext.Current.Session["WorkOrderNumber"] = num;
				return text;
			}
			return "";
		}

		public List<long?> GetAllJobOrderID()
		{
			return ((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Select((QuotationWorkOrderList x) => x.FkQuotationDetailsID).Distinct().ToList();
		}

		public List<QuotationWorkOrderList> GetbyMasterId(long JobOrderDetailsID)
		{
			return ((IQueryable<QuotationWorkOrderList>)dbContext.QuotationWorkOrderList).Where((QuotationWorkOrderList x) => x.FkQuotationDetailsID == (long?)JobOrderDetailsID).ToList();
		}
	}
}
