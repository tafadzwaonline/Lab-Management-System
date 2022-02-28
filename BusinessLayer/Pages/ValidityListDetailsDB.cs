using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class ValidityListDetailsDB : DBBase<ValidityListDetails, List<ValidityListDetails>, int>
	{
		public override List<ValidityListDetails> GetAll()
		{
			return ((IEnumerable<ValidityListDetails>)dbContext.ValidityListDetails).ToList();
		}

		public override ValidityListDetails GetByID(int id)
		{
			return ((IQueryable<ValidityListDetails>)dbContext.ValidityListDetails).FirstOrDefault((ValidityListDetails j) => j.ValidityDetailsID == id);
		}

		public override bool Insert(ValidityListDetails entity, out string message)
		{
			message = "";
			try
			{
				if (entity.ExpiryDate >= entity.EntryDate || !entity.ExpiryDate.HasValue)
				{
					dbContext.ValidityListDetails.Add(entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "InsertError";
					return false;
				}
				message = "Expiry date must not be  earlier than Entry date";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(ValidityListDetails entity, out string message)
		{
			message = "";
			try
			{
				ValidityListDetails byID = GetByID(entity.ValidityDetailsID);
				if (entity.ExpiryDate >= entity.EntryDate || !entity.ExpiryDate.HasValue)
				{
					DbEntityEntry val = ((DbContext)dbContext).Entry<ValidityListDetails>(byID);
					val.State = (EntityState)16;
					val.CurrentValues.SetValues((object)entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "UpdateError";
					return false;
				}
				message = "Expiry date must not be  earlier than Entry date";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(ValidityListDetails entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ValidityListDetails>(entity).State = (EntityState)8;
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

		public List<ValidityListDetails> GetByFKValidityID(int FKValidityID)
		{
			List<ValidityListDetails> list = ((IQueryable<ValidityListDetails>)dbContext.ValidityListDetails).Where((ValidityListDetails e) => e.FKValidityID == FKValidityID).ToList();
			foreach (ValidityListDetails item in list)
			{
				if (item.ExpiryDate > DateTime.Today)
				{
					item.Status = "Valid";
				}
				if (item.ExpiryDate < DateTime.Today)
				{
					item.Status = "Expired";
				}
				if (item.ExpiryDate < DateTime.Today.AddMonths(1) && item.ExpiryDate >= DateTime.Today)
				{
					item.Status = "late";
				}
			}
			return list;
		}

		public bool Insert(ValidityListDetails entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ValidityListDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ValidityListDetails entity)
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
