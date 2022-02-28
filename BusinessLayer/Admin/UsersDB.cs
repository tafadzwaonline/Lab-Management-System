using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x02000015 RID: 21
	public class UsersDB
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x00006475 File Offset: 0x00004675
		public List<ADMUsers> GetAll()
		{
			return this.dbContext.ADMUsers.ToList<ADMUsers>();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006490 File Offset: 0x00004690
		public ADMUsers GetByID(int id)
		{
			return this.dbContext.ADMUsers.FirstOrDefault((ADMUsers j) => j.UserID == id);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00006510 File Offset: 0x00004710
		public bool Insert(ADMUsers entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMUsers.Add(entity);
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

		// Token: 0x060000F8 RID: 248 RVA: 0x00006570 File Offset: 0x00004770
		public bool Update(ADMUsers entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMUsers byID = this.GetByID(entity.UserID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMUsers>(byID);
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

		// Token: 0x060000F9 RID: 249 RVA: 0x000065F4 File Offset: 0x000047F4
		public bool Delete(ADMUsers entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMUsers>(entity).State = EntityState.Deleted;
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

		// Token: 0x060000FA RID: 250 RVA: 0x00006654 File Offset: 0x00004854
		public List<ADMUsers> GetUnRemoved()
		{
			return (from u in this.dbContext.ADMUsers
			where u.IsRemoved == false
			select u).ToList<ADMUsers>();
		}

		// Token: 0x0400004F RID: 79
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
