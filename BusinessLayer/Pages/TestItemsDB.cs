using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class TestItemsDB : DBBase<TestItems, List<TestItems>, int>
	{
		public override List<TestItems> GetAll()
		{
			return ((IEnumerable<TestItems>)dbContext.TestItems).ToList();
		}

		public override TestItems GetByID(int id)
		{
			return ((IQueryable<TestItems>)dbContext.TestItems).FirstOrDefault((TestItems j) => j.TestItemsID == id);
		}

		public override bool Insert(TestItems entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TestItems.Add(entity);
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

		public override bool Update(TestItems entity, out string message)
		{
			message = "";
			try
			{
				TestItems byID = GetByID(entity.TestItemsID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TestItems>(byID);
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

		public override bool Delete(TestItems entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TestItems>(entity).State = (EntityState)8;
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

		public bool Insert(TestItems entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TestItems entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TestItems entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<TestItems> GetByMasterIDWithSession(int masterId)
		{
			List<TestItems> list;
			if (masterId > 0)
			{
				list = ((IQueryable<TestItems>)dbContext.TestItems).Where((TestItems j) => j.FKTestID == masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["TestItemsList"];
				if (obj == null)
				{
					list = new List<TestItems>();
					HttpContext.Current.Session["TestItemsList"] = list;
				}
				else
				{
					list = obj as List<TestItems>;
				}
			}
			return list;
		}

		public bool InsertWithSession(TestItems entity)
		{
			string message = "";
			if (entity.FKTestID == 0)
			{
				object obj = HttpContext.Current.Session["TestItemsList"];
				List<TestItems> list = ((obj != null) ? (obj as List<TestItems>) : new List<TestItems>());
				entity.TestItemsID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["TestItemsList"] = list;
				return true;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(TestItems entity)
		{
			string message = "";
			if (entity.FKTestID == 0)
			{
				object obj = HttpContext.Current.Session["TestItemsList"];
				List<TestItems> list = ((obj == null) ? new List<TestItems>() : (obj as List<TestItems>));
				TestItems testItems = list.First((TestItems x) => x.TestItemsID == entity.TestItemsID);
				testItems.FKItemID = entity.FKItemID;
				testItems.Qty = entity.Qty;
				HttpContext.Current.Session["TestItemsList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(TestItems entity)
		{
			string message = "";
			if (entity.FKTestID == 0)
			{
				object obj = HttpContext.Current.Session["TestItemsList"];
				List<TestItems> list;
				if (obj != null)
				{
					list = obj as List<TestItems>;
					list.RemoveAll((TestItems x) => x.TestItemsID == entity.TestItemsID);
				}
				else
				{
					list = new List<TestItems>();
				}
				HttpContext.Current.Session["TestItemsList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}
	}
}
