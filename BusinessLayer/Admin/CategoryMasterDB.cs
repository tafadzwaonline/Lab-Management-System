using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x0200000C RID: 12
	public class CategoryMasterDB
	{
		// Token: 0x0600008E RID: 142 RVA: 0x00003A11 File Offset: 0x00001C11
		public List<ADMCategoryMaster> GetAll()
		{
			return this.dbContext.ADMCategoryMaster.ToList<ADMCategoryMaster>();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003A2C File Offset: 0x00001C2C
		public ADMCategoryMaster GetByID(int id)
		{
			return this.dbContext.ADMCategoryMaster.FirstOrDefault((ADMCategoryMaster j) => j.CategoryMasterID == id);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003AAC File Offset: 0x00001CAC
		public bool Insert(ADMCategoryMaster entity)
		{
			bool result;
			try
			{
				entity.CategoryMasterID = this.GetNewCategoryMasterId();
				this.dbContext.ADMCategoryMaster.Add(entity);
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003B04 File Offset: 0x00001D04
		public bool Update(ADMCategoryMaster entity)
		{
			bool result;
			try
			{
				ADMCategoryMaster byID = this.GetByID(entity.CategoryMasterID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMCategoryMaster>(byID);
				dbEntityEntry.State = EntityState.Modified;
				dbEntityEntry.CurrentValues.SetValues(entity);
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003B70 File Offset: 0x00001D70
		public bool Delete(ADMCategoryMaster entity)
		{
			bool result;
			try
			{
				this.dbContext.Entry<ADMCategoryMaster>(entity).State = EntityState.Deleted;
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003BC4 File Offset: 0x00001DC4
		public List<ADMCategoryMaster> GetByFKModuleID(int ID)
		{
			return (from category in this.dbContext.ADMCategoryMaster
			where category.FKModuleId == (int?)ID
			select category into c
			orderby c.OrderNo
			select c).ToList<ADMCategoryMaster>();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003C9C File Offset: 0x00001E9C
		private int GetNewCategoryMasterId()
		{
			if (this.dbContext.ADMCategoryMaster.Count<ADMCategoryMaster>() != 0)
			{
				return this.dbContext.ADMCategoryMaster.Max((ADMCategoryMaster x) => x.CategoryMasterID) + 1;
			}
			return 1;
		}

		// Token: 0x04000032 RID: 50
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
