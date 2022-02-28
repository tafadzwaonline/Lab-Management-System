using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Pages
{
	public class ValidityListDB : DBBase<ValidityList, List<ValidityList>, int>
	{
		public override List<ValidityList> GetAll()
		{
			return ((IEnumerable<ValidityList>)dbContext.ValidityList).ToList();
		}

		public override ValidityList GetByID(int id)
		{
			return ((IQueryable<ValidityList>)dbContext.ValidityList).FirstOrDefault((ValidityList j) => j.ValidityID == id);
		}

		public override bool Insert(ValidityList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ValidityList.Add(entity);
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

		public override bool Update(ValidityList entity, out string message)
		{
			message = "";
			try
			{
				ValidityList byID = GetByID(entity.ValidityID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<ValidityList>(byID);
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

		public override bool Delete(ValidityList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ValidityList>(entity).State = (EntityState)8;
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

		public bool Insert(ValidityList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ValidityList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ValidityList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string GetNewSerial()
		{
			string maxValidityCode = GetMaxValidityCode();
			string str = ((int.Parse(maxValidityCode) <= 0) ? "1" : (Convert.ToInt32(maxValidityCode) + 1).ToString());
			return str = "0" + str;
		}

		private string GetMaxValidityCode()
		{
			int? num = ((IQueryable<ValidityList>)dbContext.ValidityList).Max((Expression<Func<ValidityList, int?>>)((ValidityList entity) => entity.ValidityID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).ValidityCode;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}
	}
}
