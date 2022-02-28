using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x0200000D RID: 13
	public class LinksCategoryDB
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00003D1D File Offset: 0x00001F1D
		public List<ADMLinkCategory> GetAll()
		{
			return this.dbContext.ADMLinkCategory.ToList<ADMLinkCategory>();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003D38 File Offset: 0x00001F38
		public ADMLinkCategory GetByID(int id)
		{
			return this.dbContext.ADMLinkCategory.FirstOrDefault((ADMLinkCategory j) => j.LinkCategoryID == id);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003DB8 File Offset: 0x00001FB8
		public bool Insert(ADMLinkCategory entity)
		{
			bool result;
			try
			{
				entity.LinkCategoryID = this.GetNewLinkCategoryId();
				this.dbContext.ADMLinkCategory.Add(entity);
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

		// Token: 0x06000099 RID: 153 RVA: 0x00003E10 File Offset: 0x00002010
		public bool Update(ADMLinkCategory entity)
		{
			bool result;
			try
			{
				ADMLinkCategory byID = this.GetByID(entity.LinkCategoryID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMLinkCategory>(byID);
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

		// Token: 0x0600009A RID: 154 RVA: 0x00003E7C File Offset: 0x0000207C
		public bool Delete(ADMLinkCategory entity)
		{
			bool result;
			try
			{
				this.dbContext.Entry<ADMLinkCategory>(entity).State = EntityState.Deleted;
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

		// Token: 0x0600009B RID: 155 RVA: 0x00003ED0 File Offset: 0x000020D0
		public List<ADMLinkCategory> GetByCategoryMasterId(int id)
		{
			return (from category in this.dbContext.ADMLinkCategory
			where category.FKCategoryMasterID == id
			select category).ToList<ADMLinkCategory>();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003F54 File Offset: 0x00002154
		private int GetNewLinkCategoryId()
		{
			if (this.dbContext.ADMLinkCategory.Count<ADMLinkCategory>() != 0)
			{
				return this.dbContext.ADMLinkCategory.Max((ADMLinkCategory x) => x.LinkCategoryID) + 1;
			}
			return 1;
		}

		// Token: 0x04000033 RID: 51
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
