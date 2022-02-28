using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class MaterialTypesCustomFieldsDB : DBBase<MaterialTypesCustomFields, List<MaterialTypesCustomFields>, int>
	{
		public override List<MaterialTypesCustomFields> GetAll()
		{
			return ((IEnumerable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).ToList();
		}

		public override MaterialTypesCustomFields GetByID(int id)
		{
			return ((IQueryable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).FirstOrDefault((MaterialTypesCustomFields j) => j.CustomFieldID == id);
		}

		public override bool Insert(MaterialTypesCustomFields entity, out string message)
		{
			message = "";
			try
			{
				dbContext.MaterialTypesCustomFields.Add(entity);
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

		public override bool Update(MaterialTypesCustomFields entity, out string message)
		{
			message = "";
			try
			{
				MaterialTypesCustomFields byID = GetByID(entity.CustomFieldID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<MaterialTypesCustomFields>(byID);
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

		public override bool Delete(MaterialTypesCustomFields entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<MaterialTypesCustomFields>(entity).State = (EntityState)8;
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

		public List<MaterialTypesCustomFields> GetByFKMaterialTypeID(int FKMaterialTypeID)
		{
			return ((IQueryable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).Where((MaterialTypesCustomFields e) => e.FKMaterialTypeID == FKMaterialTypeID).ToList();
		}

		public List<MaterialTypesCustomFields> GetNonTableFieldsByFKMaterialTypeID(int FKMaterialTypeID)
		{
			return ((IQueryable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).Where((MaterialTypesCustomFields e) => e.FKMaterialTypeID == FKMaterialTypeID && e.DataType != 5).ToList();
		}

		public List<MaterialTypesCustomFields> GetTableFieldsByFKMaterialTypeID(int FKMaterialTypeID)
		{
			return ((IQueryable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).Where((MaterialTypesCustomFields e) => e.FKMaterialTypeID == FKMaterialTypeID && e.DataType == 5).ToList();
		}

		public bool Insert(MaterialTypesCustomFields entity)
		{
			string message = "";
			if (entity.DataType == 0)
			{
				entity.DataType = 5;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(MaterialTypesCustomFields entity)
		{
			string message = "";
			if (entity.DataType == 0)
			{
				entity.DataType = 5;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(MaterialTypesCustomFields entity)
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
