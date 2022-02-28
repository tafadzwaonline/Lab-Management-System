using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class EquipmentsListDB : DBBase<EquipmentsList, List<EquipmentsList>, int>
	{
		public override List<EquipmentsList> GetAll()
		{
			return ((IEnumerable<EquipmentsList>)dbContext.EquipmentsList).ToList();
		}

		public override EquipmentsList GetByID(int id)
		{
			return ((IQueryable<EquipmentsList>)dbContext.EquipmentsList).FirstOrDefault((EquipmentsList j) => j.EquipmentID == id);
		}

		public override bool Insert(EquipmentsList entity, out string message)
		{
			message = "";
			try
			{
				if (entity.ExpiryDate > entity.CalibrationDate || !entity.ExpiryDate.HasValue)
				{
					dbContext.EquipmentsList.Add(entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "InsertError";
					return false;
				}
				message = "Expiry date should be later date than Calibration";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(EquipmentsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				EquipmentsList byID = this.GetByID(entity.EquipmentID);
				if (entity.ExpiryDate > entity.CalibrationDate || entity.ExpiryDate == null)
				{
					DbEntityEntry dbEntityEntry = this.dbContext.Entry<EquipmentsList>(byID);
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
					message = "Expiry date should be later date than Calibration";
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

		public override bool Delete(EquipmentsList entity, out string message)
		{

			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<EquipmentsList>(entity).State = EntityState.Deleted;
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

		public List<EquipmentsList> GetByLabId(int FKLabID)
		{
			return ((IQueryable<EquipmentsList>)dbContext.EquipmentsList).Where((EquipmentsList x) => x.FKLabID == FKLabID).ToList();
		}

		public bool Insert(EquipmentsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(EquipmentsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(EquipmentsList entity)
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
