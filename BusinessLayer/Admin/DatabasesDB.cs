using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x0200000B RID: 11
	public class DatabasesDB
	{
		// Token: 0x06000086 RID: 134 RVA: 0x000036D4 File Offset: 0x000018D4
		public List<ADMDatabases> GetAll()
		{
			return (from i in this.dbContext.ADMDatabases
			orderby i.DatabaseId descending
			select i).ToList<ADMDatabases>();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000373C File Offset: 0x0000193C
		public ADMDatabases GetByID(int id)
		{
			return this.dbContext.ADMDatabases.FirstOrDefault((ADMDatabases j) => j.DatabaseId == id);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000037C4 File Offset: 0x000019C4
		public int GetByDesc(string Desc)
		{
			return this.dbContext.ADMDatabases.FirstOrDefault((ADMDatabases j) => j.DatabaseDescription == Desc).DatabaseId;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003858 File Offset: 0x00001A58
		public bool Insert(ADMDatabases entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMDatabases.Add(entity);
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					message = "InsertError";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "InsertError";
				result = false;
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000038B8 File Offset: 0x00001AB8
		public bool Update(ADMDatabases entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMDatabases byID = this.GetByID(entity.DatabaseId);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMDatabases>(byID);
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

		// Token: 0x0600008B RID: 139 RVA: 0x0000393C File Offset: 0x00001B3C
		public bool Delete(ADMDatabases entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMDatabases>(entity).State = EntityState.Deleted;
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

		// Token: 0x0600008C RID: 140 RVA: 0x0000399C File Offset: 0x00001B9C
		public string GetLastYearDesc()
		{
			return (from i in this.dbContext.ADMDatabases
			orderby i.DatabaseId descending
			select i).FirstOrDefault<ADMDatabases>().DatabaseDescription;
		}

		// Token: 0x04000031 RID: 49
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
