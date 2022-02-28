using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class TermsConditionListDB : DBBase<TermsConditionList, List<TermsConditionList>, int>
	{
		public override List<TermsConditionList> GetAll()
		{
			return ((IEnumerable<TermsConditionList>)dbContext.TermsConditionList).ToList();
		}

		public override TermsConditionList GetByID(int id)
		{
			return ((IQueryable<TermsConditionList>)dbContext.TermsConditionList).FirstOrDefault((TermsConditionList j) => j.TermConditionID == id);
		}

		public override bool Insert(TermsConditionList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TermsConditionList.Add(entity);
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

		public override bool Update(TermsConditionList entity, out string message)
		{
			message = "";
			try
			{
				TermsConditionList byID = GetByID(entity.TermConditionID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TermsConditionList>(byID);
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

		public override bool Delete(TermsConditionList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TermsConditionList>(entity).State = (EntityState)8;
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

		public bool Insert(TermsConditionList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TermsConditionList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TermsConditionList entity)
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
