using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class EmployeesListDB : DBBase<EmployeesList, List<EmployeesList>, int>
	{
		public override List<EmployeesList> GetAll()
		{
			return ((IEnumerable<EmployeesList>)dbContext.EmployeesList).ToList();
		}

		public override EmployeesList GetByID(int id)
		{
			return ((IQueryable<EmployeesList>)dbContext.EmployeesList).FirstOrDefault((EmployeesList j) => j.EmpID == id);
		}

		public override bool Insert(EmployeesList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.EmployeesList.Add(entity);
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

		public override bool Update(EmployeesList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				EmployeesList byID = this.GetByID(entity.EmpID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<EmployeesList>(byID);
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

		public override bool Delete(EmployeesList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<EmployeesList>(entity).State = EntityState.Deleted;
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

		public bool Insert(EmployeesList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(EmployeesList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(EmployeesList entity)
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
