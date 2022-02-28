using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x02000013 RID: 19
	public class RolesDB
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x000056AE File Offset: 0x000038AE
		public List<ADMRoles> GetAll()
		{
			return this.dbContext.ADMRoles.ToList<ADMRoles>();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000056C8 File Offset: 0x000038C8
		public ADMRoles GetByID(int id)
		{
			return this.dbContext.ADMRoles.First((ADMRoles role) => role.RoleID == id);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005748 File Offset: 0x00003948
		public bool Insert(ADMRoles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				if (this.CheckCodeExist(entity.Code))
				{
					message = "CodeExist";
					result = false;
				}
				else
				{
					this.dbContext.ADMRoles.Add(entity);
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
			}
			catch
			{
				message = "InsertError";
				result = false;
			}
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000057C4 File Offset: 0x000039C4
		public bool Update(ADMRoles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMRoles byID = this.GetByID(int.Parse(entity.RoleID.ToString()));
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMRoles>(byID);
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

		// Token: 0x060000D9 RID: 217 RVA: 0x00005854 File Offset: 0x00003A54
		public bool Delete(ADMRoles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMRoles>(entity).State = EntityState.Deleted;
				result = (this.dbContext.SaveChanges() > 0);
			}
			catch
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000058A8 File Offset: 0x00003AA8
		public bool Delete(int id, out string message)
		{
			return this.Delete(this.GetByID(id), out message);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005910 File Offset: 0x00003B10
		public List<ADMRoles> GetByCodeAndNamesContains(string code, string name)
		{
			List<ADMRoles> list = this.GetAll();
			if (code != "")
			{
				list = list.FindAll((ADMRoles roleEntity) => roleEntity.Code.Contains(code));
			}
			if (name != "")
			{
				list = list.FindAll((ADMRoles roleEntity) => roleEntity.RoleAName.ToLower().Contains(name.ToLower()) || roleEntity.RoleEName.ToLower().Contains(name.ToLower()));
			}
			return list;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000599C File Offset: 0x00003B9C
		public bool CheckCodeExist(string code)
		{
			return (from entity in this.dbContext.ADMRoles
			where entity.Code == code
			select entity).Count<ADMRoles>() > 0;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005A8C File Offset: 0x00003C8C
		public bool CheckForExist(string code, string name)
		{
			bool flag = false;
			bool flag2 = false;
			List<ADMRoles> all = this.GetAll();
			List<ADMRoles> list = all.FindAll((ADMRoles roleEntity) => roleEntity.Code.Contains(code));
			if (list.Count > 0)
			{
				flag = true;
			}
			list = all.FindAll((ADMRoles roleEntity) => roleEntity.RoleAName.ToLower() == name.ToLower() || roleEntity.RoleEName.ToLower() == name.ToLower());
			if (list.Count > 0)
			{
				flag2 = true;
			}
			return flag || flag2;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005B90 File Offset: 0x00003D90
		public bool CheckForEdit(string code, string name, int id)
		{
			bool flag = false;
			bool flag2 = false;
			List<ADMRoles> all = this.GetAll();
			List<ADMRoles> list = all.FindAll((ADMRoles roleEntity) => roleEntity.Code.Contains(code) && roleEntity.RoleID != id);
			if (list.Count > 0)
			{
				flag = true;
			}
			list = all.FindAll((ADMRoles roleEntity) => (roleEntity.RoleAName.ToLower() == name.ToLower() || roleEntity.RoleEName.ToLower() == name.ToLower()) && roleEntity.RoleID != id);
			if (list.Count > 0)
			{
				flag2 = true;
			}
			return flag || flag2;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005C0E File Offset: 0x00003E0E
		[DataObjectMethod(DataObjectMethodType.Select)]
		public List<ADMCategoryMaster> GetAllCategories()
		{
			return this.dbContext.ADMCategoryMaster.ToList<ADMCategoryMaster>();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005C28 File Offset: 0x00003E28
		public List<ADMRoles> GetByModuleId(int moduleId)
		{
			return (from role in this.dbContext.ADMRoles
			where role.FKModuleID == (int?)moduleId
			select role).ToList<ADMRoles>();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005CC4 File Offset: 0x00003EC4
		public List<ViewUserRolesList> GetUserTypeRoles(int UserType)
		{
			return (from i in this.dbContext.ViewUserRolesList
			where i.UserType == UserType
			select i).ToList<ViewUserRolesList>();
		}

		// Token: 0x04000049 RID: 73
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
