using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class ItemsListDB : DBBase<ItemsList, List<ItemsList>, int>
	{
		public override List<ItemsList> GetAll()
		{
			return ((IEnumerable<ItemsList>)dbContext.ItemsList).ToList();
		}

		public override ItemsList GetByID(int id)
		{
			return ((IQueryable<ItemsList>)dbContext.ItemsList).FirstOrDefault((ItemsList j) => j.ItemID == id);
		}

		public override bool Insert(ItemsList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ItemsList.Add(entity);
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

		public override bool Update(ItemsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ItemsList byID = this.GetByID(entity.ItemID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ItemsList>(byID);
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

		// Token: 0x060008F1 RID: 2289 RVA: 0x000272D8 File Offset: 0x000254D8
		public override bool Delete(ItemsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ItemsList>(entity).State = EntityState.Deleted;
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

		public bool Insert(ItemsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ItemsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ItemsList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}
	}
}
