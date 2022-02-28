using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;

namespace BusinessLayer.Admin
{
	// Token: 0x0200000F RID: 15
	public class RoleLinkOptionDB
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00004789 File Offset: 0x00002989
		public List<ADMRoleLinkOptions> GetAll()
		{
			return this.dbContext.ADMRoleLinkOptions.ToList<ADMRoleLinkOptions>();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000047A4 File Offset: 0x000029A4
		public ADMRoleLinkOptions GetByID(int id)
		{
			return this.dbContext.ADMRoleLinkOptions.FirstOrDefault((ADMRoleLinkOptions j) => j.RoleLinkOptionID == (long)id);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004834 File Offset: 0x00002A34
		public bool Insert(ADMRoleLinkOptions entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.ADMRoleLinkOptions.Add(entity);
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

		// Token: 0x060000B3 RID: 179 RVA: 0x00004894 File Offset: 0x00002A94
		public bool Update(ADMRoleLinkOptions entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				ADMRoleLinkOptions byID = this.GetByID(entity.RoleLinkOptionID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<ADMRoleLinkOptions>(byID);
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

		// Token: 0x060000B4 RID: 180 RVA: 0x00004918 File Offset: 0x00002B18
		public bool Delete(ADMRoleLinkOptions entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<ADMRoleLinkOptions>(entity).State = EntityState.Deleted;
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

		// Token: 0x060000B5 RID: 181 RVA: 0x00004978 File Offset: 0x00002B78
		public bool Delete(int roleLinkId, int optionId)
		{
			string text = "";
			List<ADMRoleLinkOptions> byRoleLinkIdAndOpionId = this.GetByRoleLinkIdAndOpionId(roleLinkId, optionId);
			bool result = false;
			foreach (ADMRoleLinkOptions entity in byRoleLinkIdAndOpionId)
			{
				result = this.Delete(entity, out text);
			}
			this.dbContext.SaveChanges();
			return result;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000049F0 File Offset: 0x00002BF0
		public ADMRoleLinkOptions GetByID(long ID)
		{
			return this.dbContext.ADMRoleLinkOptions.First((ADMRoleLinkOptions rlo) => rlo.RoleLinkOptionID == ID);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004A78 File Offset: 0x00002C78
		public List<ADMRoleLinkOptions> GetByRoleLinkId(int rolelinkId)
		{
			return (from rlo in this.dbContext.ADMRoleLinkOptions
			where rlo.FKRoleLinkID == rolelinkId
			select rlo).ToList<ADMRoleLinkOptions>();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004B04 File Offset: 0x00002D04
		public List<ADMRoleLinkOptions> GetByRoleIdAndLinkId(int roleId, int linkId)
		{
			List<ADMRoleLink> roleLinkLst = (from roleLink in this.dbContext.ADMRoleLink
			where roleLink.FKRoleID == roleId && roleLink.FKLinkID == linkId
			select roleLink).ToList<ADMRoleLink>();
			if (roleLinkLst.Count > 0)
			{
				return (from rlo in this.dbContext.ADMRoleLinkOptions
				where rlo.FKRoleLinkID == roleLinkLst[0].RoleLinkID
				select rlo).ToList<ADMRoleLinkOptions>();
			}
			return new List<ADMRoleLinkOptions>();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004CA8 File Offset: 0x00002EA8
		public List<ADMRoleLinkOptions> GetByRoleLinkIdAndOpionId(int roleLinkId, int optionId)
		{
			return (from rlo in this.dbContext.ADMRoleLinkOptions
			where rlo.FKRoleLinkID == roleLinkId && rlo.FKOptionID == optionId
			select rlo).ToList<ADMRoleLinkOptions>();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004DC0 File Offset: 0x00002FC0
		public bool SaveLinkOptions(int roleLinkId, bool chkAdd, bool chkEdit, bool ChkDelete, bool ChkView)
		{
			bool result;
			try
			{
				string text = "";
				using (TransactionScope transactionScope = new TransactionScope())
				{
					if (chkAdd || chkEdit || ChkDelete || ChkView)
					{
						List<ADMRoleLinkOptions> byRoleLinkId = this.GetByRoleLinkId(roleLinkId);
						if (chkAdd)
						{
							List<ADMRoleLinkOptions> list = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 1);
							if (list.Count < 1)
							{
								this.Insert(new ADMRoleLinkOptions
								{
									FKOptionID = 1,
									FKRoleLinkID = roleLinkId
								}, out text);
							}
						}
						else
						{
							List<ADMRoleLinkOptions> list2 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 1);
							if (list2.Count > 0)
							{
								this.Delete(roleLinkId, 1);
							}
						}
						if (chkEdit)
						{
							List<ADMRoleLinkOptions> list3 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 2);
							if (list3.Count < 1)
							{
								this.Insert(new ADMRoleLinkOptions
								{
									FKOptionID = 2,
									FKRoleLinkID = roleLinkId
								}, out text);
							}
						}
						else
						{
							List<ADMRoleLinkOptions> list4 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 2);
							if (list4.Count > 0)
							{
								this.Delete(roleLinkId, 2);
							}
						}
						if (ChkDelete)
						{
							List<ADMRoleLinkOptions> list5 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 3);
							if (list5.Count < 1)
							{
								this.Insert(new ADMRoleLinkOptions
								{
									FKOptionID = 3,
									FKRoleLinkID = roleLinkId
								}, out text);
							}
						}
						else
						{
							List<ADMRoleLinkOptions> list6 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 3);
							if (list6.Count > 0)
							{
								this.Delete(roleLinkId, 3);
							}
						}
						if (ChkView)
						{
							List<ADMRoleLinkOptions> list7 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 4);
							if (list7.Count < 1)
							{
								this.Insert(new ADMRoleLinkOptions
								{
									FKOptionID = 4,
									FKRoleLinkID = roleLinkId
								}, out text);
							}
						}
						else
						{
							List<ADMRoleLinkOptions> list8 = byRoleLinkId.FindAll((ADMRoleLinkOptions r) => r.FKOptionID == 4);
							if (list8.Count > 0)
							{
								this.Delete(roleLinkId, 4);
							}
						}
					}
					if (!chkAdd && !chkEdit && !ChkDelete && !ChkView && roleLinkId > 0)
					{
						this.Delete(roleLinkId, 1);
						this.Delete(roleLinkId, 2);
						this.Delete(roleLinkId, 3);
						this.Delete(roleLinkId, 4);
						new RoleLinksDB().Delete(roleLinkId, out text);
					}
					transactionScope.Complete();
					result = true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000039 RID: 57
		private ActSysAdminEntities dbContext = new ActSysAdminEntities();
	}
}
