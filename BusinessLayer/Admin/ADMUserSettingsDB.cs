using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x02000008 RID: 8
	public class ADMUserSettingsDB
	{
		// Token: 0x06000065 RID: 101 RVA: 0x000028B8 File Offset: 0x00000AB8
		public List<ADMUserSettings> GetAll()
		{
			return this.dbContext.ADMUserSettings.ToList<ADMUserSettings>();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000028D4 File Offset: 0x00000AD4
		public ADMUserSettings GetByID(int ID)
		{
			return this.dbContext.ADMUserSettings.First((ADMUserSettings roleLink) => roleLink.UserSettingsID == (long)ID);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002964 File Offset: 0x00000B64
		public bool Insert(ADMUserSettings entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMUserSettings.Add(entity);
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
			catch
			{
				message = "InsertError";
				result = false;
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000029C4 File Offset: 0x00000BC4
		public bool Update(ADMUserSettings entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMUserSettings byID = this.GetByID(int.Parse(entity.UserSettingsID.ToString()));
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMUserSettings>(byID);
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
			catch
			{
				message = "UpdateError";
				result = false;
			}
			return result;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002A54 File Offset: 0x00000C54
		public bool Delete(ADMUserSettings entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMUserSettings>(entity).State = EntityState.Deleted;
				result = (this.dbContext.SaveChanges() > 0);
			}
			catch
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public bool Insert(ADMUserSettings entity)
		{
			string message = "";
			if (this.Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public bool Update(ADMUserSettings entity)
		{
			string message = "";
			if (this.Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002AF8 File Offset: 0x00000CF8
		public bool Delete(ADMUserSettings entity)
		{
			string message = "";
			if (this.Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002B20 File Offset: 0x00000D20
		public List<string> GetSettingsNameList()
		{
			return (from z in this.dbContext.ADMUserSettings
			where z.SettingsName != null
			select z into x
			select x.SettingsName).Distinct<string>().ToList<string>();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002BE4 File Offset: 0x00000DE4
		public List<ADMUserSettings> GetAllUserSettings(int UserId)
		{
			return (from x in this.dbContext.ADMUserSettings
			where x.FKUserID == (int?)UserId
			select x).ToList<ADMUserSettings>();
		}

		// Token: 0x0400002C RID: 44
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
