using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class PriceUnitListDB : DBBase<PriceUnitList, List<PriceUnitList>, int>
	{
		public override List<PriceUnitList> GetAll()
		{
			return ((IEnumerable<PriceUnitList>)dbContext.PriceUnitList).ToList();
		}

		public override PriceUnitList GetByID(int id)
		{
			return ((IQueryable<PriceUnitList>)dbContext.PriceUnitList).FirstOrDefault((PriceUnitList j) => j.PriceUnitID == id);
		}

		public override bool Insert(PriceUnitList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.PriceUnitList.Add(entity);
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

		public override bool Update(PriceUnitList entity, out string message)
		{
			message = "";
			try
			{
				PriceUnitList byID = GetByID(entity.PriceUnitID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<PriceUnitList>(byID);
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

		public override bool Delete(PriceUnitList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<PriceUnitList>(entity).State = (EntityState)8;
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

		public bool Insert(PriceUnitList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(PriceUnitList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(PriceUnitList entity)
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
