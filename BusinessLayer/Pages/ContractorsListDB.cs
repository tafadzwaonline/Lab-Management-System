using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Pages
{
	public class ContractorsListDB : DBBase<ContractorsList, List<ContractorsList>, int>
	{
		public override List<ContractorsList> GetAll()
		{
			return ((IEnumerable<ContractorsList>)dbContext.ContractorsList).ToList();
		}

		public override ContractorsList GetByID(int id)
		{
			return ((IQueryable<ContractorsList>)dbContext.ContractorsList).FirstOrDefault((ContractorsList j) => j.ContractorID == id);
		}

		public override bool Insert(ContractorsList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ContractorsList.Add(entity);
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

		public override bool Update(ContractorsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ContractorsList byID = this.GetByID(entity.ContractorID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ContractorsList>(byID);
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

		public override bool Delete(ContractorsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ContractorsList>(entity).State =  EntityState.Deleted;
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

		public bool Insert(ContractorsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ContractorsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ContractorsList entity)
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
			string maxContractorCode = GetMaxContractorCode();
			string format = "0000";
			if (int.Parse(maxContractorCode) > 0)
			{
				return (Convert.ToInt32(maxContractorCode) + 1).ToString(format);
			}
			return "0001";
		}

		private string GetMaxContractorCode()
		{
			int? num = ((IQueryable<ContractorsList>)dbContext.ContractorsList).Max((Expression<Func<ContractorsList, int?>>)((ContractorsList entity) => entity.ContractorID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).ContractorCode;
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
