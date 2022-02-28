using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x0200000A RID: 10
	public class ModuleDB
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000033C0 File Offset: 0x000015C0
		public List<ADMModules> GetAll()
		{
			return (from c in this.dbContext.ADMModules
			where c.OrderNo != (int?)0
			orderby c.OrderNo
			select c).ToList<ADMModules>();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000034BC File Offset: 0x000016BC
		public List<ADMModules> GetAllByRoles(List<ADMUserRoles> userRoles)
		{
			List<ADMModules> list = new List<ADMModules>();
			foreach (ADMUserRoles admuserRoles in userRoles)
			{
				ADMModules byID = this.GetByID(admuserRoles.ADMRoles.FKModuleID.Value);
				if (!list.Contains(byID))
				{
					list.Add(byID);
				}
			}
			return (from c in list
			where c.OrderNo != 0
			orderby c.OrderNo
			select c).ToList<ADMModules>();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003588 File Offset: 0x00001788
		public ADMModules GetByID(int ID)
		{
			return this.dbContext.ADMModules.First((ADMModules moduleEntity) => moduleEntity.ModuleID == ID);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003610 File Offset: 0x00001810
		public int GetIDByName(string ModuleName)
		{
			int result;
			try
			{
				result = this.dbContext.ADMModules.SingleOrDefault((ADMModules e) => e.ModuleEName == ModuleName).ModuleID;
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0400002E RID: 46
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
