using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x02000012 RID: 18
	public class RoleLinksDB
	{
		// Token: 0x060000CD RID: 205 RVA: 0x000053E3 File Offset: 0x000035E3
		public List<ADMRoleLink> GetAll()
		{
			return this.dbContext.ADMRoleLink.ToList<ADMRoleLink>();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005400 File Offset: 0x00003600
		public ADMRoleLink GetByID(int id)
		{
			return this.dbContext.ADMRoleLink.First((ADMRoleLink roleLink) => roleLink.RoleLinkID == id);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00005480 File Offset: 0x00003680
		public bool Insert(ADMRoleLink entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMRoleLink.Add(entity);
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

		// Token: 0x060000D0 RID: 208 RVA: 0x000054E0 File Offset: 0x000036E0
		public bool Update(ADMRoleLink entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMRoleLink byID = this.GetByID(entity.RoleLinkID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMRoleLink>(byID);
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

		// Token: 0x060000D1 RID: 209 RVA: 0x00005564 File Offset: 0x00003764
		public bool Delete(ADMRoleLink entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMRoleLink>(entity).State = EntityState.Deleted;
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

		// Token: 0x060000D2 RID: 210 RVA: 0x000055C4 File Offset: 0x000037C4
		public bool Delete(int id, out string message)
		{
			return this.Delete(this.GetByID(id), out message);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000055DC File Offset: 0x000037DC
		public List<ADMRoleLink> GetRoleLinkByRoleAndLink(int roleId, int linkId)
		{
			return (from roleLink in this.dbContext.ADMRoleLink
			where roleLink.FKRoleID == roleId && roleLink.FKLinkID == linkId
			select roleLink).ToList<ADMRoleLink>();
		}

		// Token: 0x04000048 RID: 72
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
