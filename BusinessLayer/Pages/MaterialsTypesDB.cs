using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class MaterialsTypesDB : DBBase<MaterialsTypes, List<MaterialsTypes>, int>
	{
		public override List<MaterialsTypes> GetAll()
		{
			return ((IEnumerable<MaterialsTypes>)dbContext.MaterialsTypes).ToList();
		}

		public override MaterialsTypes GetByID(int id)
		{
			return ((IQueryable<MaterialsTypes>)dbContext.MaterialsTypes).FirstOrDefault((MaterialsTypes j) => j.MaterialTypeID == id);
		}

		public override bool Insert(MaterialsTypes entity, out string message)
		{
			message = "";
			try
			{
				dbContext.MaterialsTypes.Add(entity);
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

		public override bool Update(MaterialsTypes entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				MaterialsTypes byID = this.GetByID(entity.MaterialTypeID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<MaterialsTypes>(byID);
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

		// Token: 0x060008CA RID: 2250 RVA: 0x00026658 File Offset: 0x00024858
		public override bool Delete(MaterialsTypes entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<MaterialsTypes>(entity).State = EntityState.Deleted;
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


		public bool Insert(MaterialsTypes entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(MaterialsTypes entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(MaterialsTypes entity)
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
