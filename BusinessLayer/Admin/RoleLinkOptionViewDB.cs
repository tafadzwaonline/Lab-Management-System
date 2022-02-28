using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x02000010 RID: 16
	public class RoleLinkOptionViewDB
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x000050D3 File Offset: 0x000032D3
		public List<RoleLinkOptionView> GetAll()
		{
			return this.dbContext.RoleLinkOptionView.ToList<RoleLinkOptionView>();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000050E5 File Offset: 0x000032E5
		public RoleLinkOptionView GetByID(int id)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000050EC File Offset: 0x000032EC
		public bool Insert(RoleLinkOptionView entity, out string message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000050F3 File Offset: 0x000032F3
		public bool Update(RoleLinkOptionView entity, out string message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000050FA File Offset: 0x000032FA
		public bool Delete(RoleLinkOptionView entity, out string message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000510C File Offset: 0x0000330C
		public List<RoleLinkOptionView> GetByRoleIdAndLinkId(int roleId, int linkId)
		{
			return (from rloView in this.dbContext.RoleLinkOptionView
			where rloView.RoleID == roleId && rloView.LinksID == linkId
			select rloView).ToList<RoleLinkOptionView>();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000051D4 File Offset: 0x000033D4
		public List<RoleLinkOptionView> GetByRoleId(int roleId, int opionId)
		{
			return (from rloView in this.dbContext.RoleLinkOptionView
			where rloView.RoleID == roleId && rloView.OptionID == opionId
			select rloView).ToList<RoleLinkOptionView>();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000529C File Offset: 0x0000349C
		public List<RoleLinkOptionView> CheckOption(string pageName, int roleID, RoleOptions option)
		{
			return (from rloView in this.dbContext.RoleLinkOptionView
			where rloView.Url == pageName && rloView.RoleID == roleID && rloView.OptionEName == option.ToString()
			select rloView).ToList<RoleLinkOptionView>();
		}

		// Token: 0x04000042 RID: 66
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
