using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BusinessLayer
{
	// Token: 0x02000007 RID: 7
	public class AdminDB
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00002370 File Offset: 0x00000570
		[WebMethod(EnableSession = true)]
		public static string ConnectionStringMethod()
		{
			string text = ConfigurationManager.ConnectionStrings["SMSEntities"].ConnectionString;
			if (HttpContext.Current.Session != null)
			{
				if (HttpContext.Current.Session["DataBaseName"] != null)
				{
					string newValue = HttpContext.Current.Session["DataBaseName"].ToString();
					text = text.Replace("SMSElite", newValue);
				}
				return text;
			}
			return text;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000023DE File Offset: 0x000005DE
		public List<ADMModules> GetModules()
		{
			return this.dbContext.ADMModules.ToList<ADMModules>();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000023F8 File Offset: 0x000005F8
		public ADMModules GetModuleByID(int moduleid)
		{
			return this.dbContext.ADMModules.First((ADMModules x) => x.ModuleID == moduleid);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002480 File Offset: 0x00000680
		public List<ADMCategoryMaster> GetCategoryMasterByModule(int moduleId)
		{
			return (from x in this.dbContext.ADMCategoryMaster
			where x.FKModuleId == (int?)moduleId
			select x).ToList<ADMCategoryMaster>();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000251C File Offset: 0x0000071C
		public List<ADMLinkCategory> GetLinkCategoryByCatMaster(int CatMasterId)
		{
			return (from x in this.dbContext.ADMLinkCategory
			where x.FKCategoryMasterID == CatMasterId
			select x).ToList<ADMLinkCategory>();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000025A8 File Offset: 0x000007A8
		public List<ADMLinks> GetLinksByCategoryId(int CatId)
		{
			return (from x in this.dbContext.ADMLinks
			where x.FKLinkCategoryID == CatId
			select x).ToList<ADMLinks>();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002634 File Offset: 0x00000834
		public List<ADMUsers> UserLogin(string code, string password, int UserType)
		{
            List<ADMUsers> users = (from user in this.dbContext.ADMUsers
			where user.Code.ToLower() == code.ToLower() && user.Password == password
			select user).ToList();

            return users;
        }

		// Token: 0x06000062 RID: 98 RVA: 0x00002754 File Offset: 0x00000954
		public ADMUsers GetUserTypeByTeacherId(int UserId)
		{
			return (from x in this.dbContext.ADMUsers
			where x.UserID == UserId
			select x).FirstOrDefault<ADMUsers>();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000027E4 File Offset: 0x000009E4
		public bool ChangeAdminPassword(int UserId, string Password)
		{
			ADMUsers admusers = this.dbContext.ADMUsers.SingleOrDefault((ADMUsers x) => x.UserID == UserId);
			admusers.Password = Password;
			DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMUsers>(admusers);
			dbEntityEntry.State = EntityState.Modified;
			dbEntityEntry.CurrentValues.SetValues(admusers);
			return this.dbContext.SaveChanges() > 0;
		}

		// Token: 0x0400002B RID: 43
		public ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
