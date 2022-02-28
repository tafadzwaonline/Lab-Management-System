using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class CustomersListDB : DBBase<CustomersList, List<CustomersList>, int>
	{
		public override List<CustomersList> GetAll()
		{
			return ((IEnumerable<CustomersList>)dbContext.CustomersList).ToList();
		}

		public override CustomersList GetByID(int id)
		{
			return ((IQueryable<CustomersList>)dbContext.CustomersList).FirstOrDefault((CustomersList j) => j.CustomerID == id);
		}

		public override bool Insert(CustomersList entity, out string message)
		{
			message = "";
			try
			{
				if (!CheckExist(entity.CustomerCode) || entity.CustomerCode == "")
				{
					dbContext.CustomersList.Add(entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "InsertError";
					return false;
				}
				message = "Customer Code is Exist";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(CustomersList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				CustomersList byID = this.GetByID(entity.CustomerID);
				if (!this.CheckExist(entity.CustomerCode) || byID.CustomerCode == entity.CustomerCode)
				{
					DbEntityEntry dbEntityEntry = this.dbContext.Entry<CustomersList>(byID);
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
				else
				{
					message = "Customer Code is Exist";
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

		public override bool Delete(CustomersList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<CustomersList>(entity).State = EntityState.Deleted;
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

		public List<CustomersList> GetAllByPaymentMode(int PaymentMode)
		{
			return ((IQueryable<CustomersList>)dbContext.CustomersList).Where((CustomersList x) => x.PaymentMode == PaymentMode && x.IsLocked == false).ToList();
		}

		public bool Insert(CustomersList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(CustomersList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(CustomersList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		private bool CheckExist(string CustomerCode)
		{
			CustomersList customersList = ((IQueryable<CustomersList>)dbContext.CustomersList).Where((CustomersList i) => i.CustomerCode == CustomerCode).FirstOrDefault();
			if (customersList == null)
			{
				return false;
			}
			return true;
		}
	}
}
