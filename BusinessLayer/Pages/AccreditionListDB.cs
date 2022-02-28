using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class AccreditionListDB : DBBase<AccreditionList, List<AccreditionList>, int>
	{
		public override List<AccreditionList> GetAll()
		{
			return ((IEnumerable<AccreditionList>)dbContext.AccreditionList).ToList();
		}

		public override AccreditionList GetByID(int id)
		{
			return ((IQueryable<AccreditionList>)dbContext.AccreditionList).FirstOrDefault((AccreditionList j) => j.AccreditionID == id);
		}

		public override bool Insert(AccreditionList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.AccreditionList.Add(entity);
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

		public override bool Update(AccreditionList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				AccreditionList byID = this.GetByID(entity.AccreditionID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<AccreditionList>(byID);
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

		public override bool Delete(AccreditionList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<AccreditionList>(entity).State = EntityState.Deleted;
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

		public bool Insert(AccreditionList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(AccreditionList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(AccreditionList entity)
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
