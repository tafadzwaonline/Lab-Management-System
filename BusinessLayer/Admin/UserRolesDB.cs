using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;

namespace BusinessLayer.Admin
{
	// Token: 0x02000014 RID: 20
	public class UserRolesDB
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x00005D5B File Offset: 0x00003F5B
		public List<ADMUserRoles> GetAll()
		{
			return this.dbContext.ADMUserRoles.ToList<ADMUserRoles>();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005D78 File Offset: 0x00003F78
		public ADMUserRoles GetByID(int ID)
		{
			return this.dbContext.ADMUserRoles.First((ADMUserRoles roleLink) => roleLink.UserRoleID == ID);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00005E00 File Offset: 0x00004000
		public List<ADMUserRoles> GetByUserAndRoleId(int userId, int roleId)
		{
			return (from userRole in this.dbContext.ADMUserRoles
			where userRole.FKUserID == userId && userRole.FKRoleID == roleId
			select userRole).ToList<ADMUserRoles>();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00005EC8 File Offset: 0x000040C8
		public List<ADMUserRoles> GetByUserId(int userId)
		{
			return (from userRole in this.dbContext.ADMUserRoles
			where userRole.FKUserID == userId
			select userRole).ToList<ADMUserRoles>();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00005F54 File Offset: 0x00004154
		public bool DeleteAllUserRoles(int userId)
		{
			bool result = false;
			using (TransactionScope transactionScope = new TransactionScope())
			{
				List<ADMUserRoles> list = (from userRole in this.dbContext.ADMUserRoles
				where userRole.FKUserID == userId
				select userRole).ToList<ADMUserRoles>();
				for (int i = 0; i < list.Count; i++)
				{
					this.dbContext.ADMUserRoles.Remove(list[i]);
				}
				try
				{
					this.dbContext.SaveChanges();
					transactionScope.Complete();
					result = true;
				}
				catch
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006058 File Offset: 0x00004258
		public bool Insert(ADMUserRoles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMUserRoles.Add(entity);
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

		// Token: 0x060000E9 RID: 233 RVA: 0x000060B8 File Offset: 0x000042B8
		public bool Update(ADMUserRoles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMUserRoles byID = this.GetByID(int.Parse(entity.UserRoleID.ToString()));
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMUserRoles>(byID);
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

		// Token: 0x060000EA RID: 234 RVA: 0x00006148 File Offset: 0x00004348
		public bool Delete(ADMUserRoles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMUserRoles>(entity).State = EntityState.Deleted;
				result = (this.dbContext.SaveChanges() > 0);
			}
			catch
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000061B0 File Offset: 0x000043B0
		public bool IsKGCoordinator(int userId)
		{
			List<ADMUserRoles> byUserId = this.GetByUserId(userId);
			List<string> list = (from x in byUserId
			select x.ADMRoles.RoleEName.ToLower()).ToList<string>();
			return list.Contains("kg coordinators") | list.Contains("school admin") | list.Contains("senior users");
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00006224 File Offset: 0x00004424
		public bool IsGradeCoordinator(int userId)
		{
			List<ADMUserRoles> byUserId = this.GetByUserId(userId);
			List<string> list = (from x in byUserId
			select x.ADMRoles.RoleEName.ToLower()).ToList<string>();
			return list.Contains("grade coordinators") | list.Contains("school admin") | list.Contains("senior users");
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00006298 File Offset: 0x00004498
		public bool IsEventsCoUsers(int userId)
		{
			List<ADMUserRoles> byUserId = this.GetByUserId(userId);
			List<string> list = (from x in byUserId
			select x.ADMRoles.RoleEName.ToLower()).ToList<string>();
			return list.Contains("reward coupon") | list.Contains("elite of the week") | list.Contains("certifacte nomination") | list.Contains("school admin") | list.Contains("senior users");
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00006324 File Offset: 0x00004524
		public bool IsSchoolAdmin(int userId)
		{
			List<ADMUserRoles> byUserId = this.GetByUserId(userId);
			List<string> list = (from x in byUserId
			select x.ADMRoles.RoleEName.ToLower()).ToList<string>();
			return list.Contains("school admin") | list.Contains("senior users");
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006384 File Offset: 0x00004584
		public List<UserLinkOptionsView> GetAllOptionsForLink(string PageName, long userId)
		{
			return (from ulo in this.dbContext.UserLinkOptionsView
			where ulo.Url == PageName && (long)ulo.UserID == userId
			select ulo).ToList<UserLinkOptionsView>();
		}

		// Token: 0x0400004A RID: 74
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
