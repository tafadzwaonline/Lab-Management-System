using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x02000009 RID: 9
	public class AppSettingsDB
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00002C8A File Offset: 0x00000E8A
		public List<ADMAppSettings> GetAll()
		{
			return this.dbContext.ADMAppSettings.ToList<ADMAppSettings>();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002CA4 File Offset: 0x00000EA4
		public ADMAppSettings GetByID(int ID)
		{
			return this.dbContext.ADMAppSettings.First((ADMAppSettings roleLink) => roleLink.SettingID == ID);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002D24 File Offset: 0x00000F24
		public bool Insert(ADMAppSettings entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMAppSettings.Add(entity);
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

		// Token: 0x06000073 RID: 115 RVA: 0x00002D84 File Offset: 0x00000F84
		public bool Update(ADMAppSettings entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMAppSettings byID = this.GetByID(int.Parse(entity.SettingID.ToString()));
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMAppSettings>(byID);
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

		// Token: 0x06000074 RID: 116 RVA: 0x00002E14 File Offset: 0x00001014
		public bool Delete(ADMAppSettings entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMAppSettings>(entity).State = EntityState.Deleted;
				result = (this.dbContext.SaveChanges() > 0);
			}
			catch
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002E68 File Offset: 0x00001068
		public bool Insert(ADMAppSettings entity)
		{
			string message = "";
			if (this.Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002E90 File Offset: 0x00001090
		public bool Update(ADMAppSettings entity)
		{
			string message = "";
			if (this.Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002EB8 File Offset: 0x000010B8
		public bool Delete(ADMAppSettings entity)
		{
			string message = "";
			if (this.Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002EE0 File Offset: 0x000010E0
		public List<string> GetSettingsNameList()
		{
			return (from z in this.dbContext.ADMAppSettings
			where z.SettingKey != null
			select z into x
			select x.SettingKey).Distinct<string>().ToList<string>();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002F9C File Offset: 0x0000119C
		public bool CheckAppPassword(string pwd)
		{
			return pwd == "@ct@123";
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002FB4 File Offset: 0x000011B4
		public bool ApplyActivation(string UserString, string ValueString, string DateString)
		{
			string password = "act123";
			string activation = CryptoHelper.Encrypt("activation", password);
			ADMAppSettings admappSettings = this.dbContext.ADMAppSettings.SingleOrDefault((ADMAppSettings e) => e.SettingKey == activation);
			if (admappSettings == null)
			{
				admappSettings = new ADMAppSettings();
				admappSettings.SettingKey = CryptoHelper.Encrypt("activation", password);
				admappSettings.DefaultValue = CryptoHelper.Encrypt(UserString, password);
				admappSettings.SettingValue = CryptoHelper.Encrypt(ValueString, password);
				admappSettings.SettingPossibleValues = CryptoHelper.Encrypt(DateString, password);
				this.dbContext.ADMAppSettings.Add(admappSettings);
				return this.dbContext.SaveChanges() > 0;
			}
			DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMAppSettings>(admappSettings);
			admappSettings.DefaultValue = CryptoHelper.Encrypt(UserString, password);
			admappSettings.SettingValue = CryptoHelper.Encrypt(ValueString, password);
			admappSettings.SettingPossibleValues = CryptoHelper.Encrypt(DateString, password);
			dbEntityEntry.State = EntityState.Modified;
			dbEntityEntry.CurrentValues.SetValues(admappSettings);
			return this.dbContext.SaveChanges() > 0;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003120 File Offset: 0x00001320
		public bool ClearActivation(string ValueString)
		{
			string password = "act123";
			string activation = CryptoHelper.Encrypt("activation", password);
			ADMAppSettings admappSettings = this.dbContext.ADMAppSettings.SingleOrDefault((ADMAppSettings e) => e.SettingKey == activation);
			if (admappSettings != null)
			{
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMAppSettings>(admappSettings);
				admappSettings.SettingValue = CryptoHelper.Encrypt(ValueString, password);
				dbEntityEntry.State = EntityState.Modified;
				dbEntityEntry.CurrentValues.SetValues(admappSettings);
				return this.dbContext.SaveChanges() > 0;
			}
			return false;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003214 File Offset: 0x00001414
		public bool CheckActivation(out string user)
		{
			string password = "act123";
			string activation = CryptoHelper.Encrypt("activation", password);
			ADMAppSettings admappSettings = this.dbContext.ADMAppSettings.SingleOrDefault((ADMAppSettings e) => e.SettingKey == activation);
			user = CryptoHelper.Decrypt(admappSettings.DefaultValue, password);
			if (admappSettings != null)
			{
				string text = CryptoHelper.Decrypt(admappSettings.SettingValue, password);
				string a;
				if ((a = text) != null)
				{
					if (a == "00")
					{
						return false;
					}
					if (a == "01")
					{
						string period = CryptoHelper.Decrypt(admappSettings.SettingPossibleValues, password);
						return this.CheckPeriod(period);
					}
					if (a == "10")
					{
						string period = CryptoHelper.Decrypt(admappSettings.SettingPossibleValues, password);
						return this.CheckPeriod(period);
					}
					if (a == "11")
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000334C File Offset: 0x0000154C
		private bool CheckPeriod(string period)
		{
			string text = period.Substring(period.Length / 2);
			DateTime t = new DateTime(int.Parse(text.Substring(4)), int.Parse(text.Substring(2, 2)), int.Parse(text.Substring(0, 2)));
			return !(t < DateTime.Today.Date);
		}

		// Token: 0x0400002D RID: 45
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
