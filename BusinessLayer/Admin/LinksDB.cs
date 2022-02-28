using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Admin
{
	// Token: 0x0200000E RID: 14
	public class LinksDB
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003FD5 File Offset: 0x000021D5
		public List<ADMLinks> GetAll()
		{
			return this.dbContext.ADMLinks.ToList<ADMLinks>();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003FF0 File Offset: 0x000021F0
		public ADMLinks GetByID(int id)
		{
			return this.dbContext.ADMLinks.FirstOrDefault((ADMLinks j) => j.LinksID == id);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004070 File Offset: 0x00002270
		public bool Insert(ADMLinks entity)
		{
			bool result;
			try
			{
				entity.LinksID = this.GetNewLinkId();
				this.dbContext.ADMLinks.Add(entity);
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000040C8 File Offset: 0x000022C8
		public bool Update(ADMLinks entity)
		{
			bool result;
			try
			{
				ADMLinks byID = this.GetByID(entity.LinksID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMLinks>(byID);
				dbEntityEntry.State = EntityState.Modified;
				dbEntityEntry.CurrentValues.SetValues(entity);
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004134 File Offset: 0x00002334
		public bool Delete(ADMLinks entity)
		{
			bool result;
			try
			{
				this.dbContext.Entry<ADMLinks>(entity).State = EntityState.Deleted;
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004188 File Offset: 0x00002388
		public List<ADMLinks> GetByFKCategoryId(int categoryId)
		{
			return (from linKentity in this.dbContext.ADMLinks
			where linKentity.FKLinkCategoryID == categoryId
			orderby linKentity.LinksID, linKentity.LinksEName
			select linKentity).ToList<ADMLinks>();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004298 File Offset: 0x00002498
		public List<ADMLinks> GetActiveLinks()
		{
			return (from linKentity in this.dbContext.ADMLinks
			where linKentity.ActiveLink == true
			orderby linKentity.LinksEName
			select linKentity).ToList<ADMLinks>();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004358 File Offset: 0x00002558
		public bool IsLinkExist(string PageName)
		{
			return (from e in this.dbContext.ADMLinks
			where e.Url == PageName
			select e).Count<ADMLinks>() > 0;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004418 File Offset: 0x00002618
		public List<ADMLinks> GetLinksByCategoryforUserRoles(List<ViewUserRolesList> userRoleLst, int CategoryId)
		{
			List<ADMLinks> list = new List<ADMLinks>();
			for (int i = 0; i < userRoleLst.Count; i++)
			{
				LinksDB linksDB = new LinksDB();
				ADMLinks byID = linksDB.GetByID(userRoleLst[i].FKLinkID);
				if (this.CustomValidateLink(byID.Url) && !list.Contains(byID))
				{
					list.Add(byID);
				}
			}
			return (from e in list
			where e.FKLinkCategoryID == CategoryId
			select e into l
			orderby l.OrderNo, l.LinksEName
			select l).ToList<ADMLinks>();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000044E0 File Offset: 0x000026E0
		private bool CustomValidateLink(string Link)
		{
			return true;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004518 File Offset: 0x00002718
		public List<ADMLinks> GetLinksByCategoryforUserRoles(List<ADMUserRoles> userRoleLst, int CategoryId)
		{
			List<ADMLinks> list = new List<ADMLinks>();
			for (int i = 0; i < userRoleLst.Count; i++)
			{
				List<ADMRoleLink> list2 = userRoleLst[i].ADMRoles.ADMRoleLink.ToList<ADMRoleLink>();
				foreach (ADMRoleLink admroleLink in list2)
				{
					if (this.CustomValidateLink(admroleLink.ADMLinks.Url) && !list.Contains(admroleLink.ADMLinks))
					{
						list.Add(admroleLink.ADMLinks);
					}
				}
			}
			return (from e in list
			where e.FKLinkCategoryID == CategoryId
			select e into l
			orderby l.OrderNo, l.LinksEName
			select l).ToList<ADMLinks>();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004628 File Offset: 0x00002828
		public string CopyLink(int LinkId, int FKLinkCategoryID, int FKModuleID, bool IsMove)
		{
			string result;
			if (IsMove)
			{
				ADMLinks byID = this.GetByID(LinkId);
				byID.FKModuleID = FKModuleID;
				byID.FKLinkCategoryID = FKLinkCategoryID;
				if (this.Update(byID))
				{
					result = "Link Moved to the given category";
				}
				else
				{
					result = "Error in Moving the Link";
				}
			}
			else
			{
				ADMLinks byID2 = this.GetByID(LinkId);
				if (this.Insert(new ADMLinks
				{
					LinksID = this.GetNewLinkId(),
					FKModuleID = FKModuleID,
					FKLinkCategoryID = FKLinkCategoryID,
					LinksEName = byID2.LinksEName,
					LinksAName = byID2.LinksAName,
					Url = byID2.Url,
					Notes = byID2.Notes,
					LinkIcon = byID2.LinkIcon,
					MenuLink = byID2.MenuLink,
					ActiveLink = byID2.ActiveLink
				}))
				{
					result = "Link Copied to the given category";
				}
				else
				{
					result = "Error in Copying the Link";
				}
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004708 File Offset: 0x00002908
		private int GetNewLinkId()
		{
			if (this.dbContext.ADMLinks.Count<ADMLinks>() != 0)
			{
				return this.dbContext.ADMLinks.Max((ADMLinks x) => x.LinksID) + 1;
			}
			return 1;
		}

		// Token: 0x04000034 RID: 52
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
