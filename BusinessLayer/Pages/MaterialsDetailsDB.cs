using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class MaterialsDetailsDB : DBBase<MaterialsDetails, List<MaterialsDetails>, int>
	{
		public override List<MaterialsDetails> GetAll()
		{
			return ((IEnumerable<MaterialsDetails>)dbContext.MaterialsDetails).ToList();
		}

		public override MaterialsDetails GetByID(int id)
		{
			return ((IQueryable<MaterialsDetails>)dbContext.MaterialsDetails).FirstOrDefault((MaterialsDetails j) => j.MaterialDetailsID == id);
		}

		public override bool Insert(MaterialsDetails entity, out string message)
		{
			message = "";
			try
			{
				dbContext.MaterialsDetails.Add(entity);
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

		public override bool Update(MaterialsDetails entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				MaterialsDetails byID = this.GetByID(entity.MaterialDetailsID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<MaterialsDetails>(byID);
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

		// Token: 0x0600085E RID: 2142 RVA: 0x0002394C File Offset: 0x00021B4C
		public override bool Delete(MaterialsDetails entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<MaterialsDetails>(entity).State = EntityState.Deleted;
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
			catch (Exception ex)
			{
				message = ex.Message + ((ex.InnerException == null) ? "" : (" ; IE:" + ex.InnerException.Message)) + ((ex.InnerException.InnerException == null) ? "" : (" ; IIE:" + ex.InnerException.InnerException.Message));
				if (message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
				{
					message = "This item is being used or contain details!";
				}
				result = false;
			}
			return result;
		}

		public List<MaterialsDetails> GetByFKMaterialTypeID(int FKMaterialTypeID)
		{
			return ((IQueryable<MaterialsDetails>)dbContext.MaterialsDetails).Where((MaterialsDetails x) => x.FKMaterialTypeID == FKMaterialTypeID).ToList();
		}

		public bool Insert(MaterialsDetails entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["MaterialsDetailsTestsList"];
			if (obj != null)
			{
				List<MaterialsDetailsTests> list = obj as List<MaterialsDetailsTests>;
				if (list.Count > 0)
				{
					entity.MaterialsDetailsTests = list;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(MaterialsDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(MaterialsDetails entity)
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
