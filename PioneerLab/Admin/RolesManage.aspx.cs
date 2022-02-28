using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Admin
{
	// Token: 0x02000006 RID: 6
	public class RolesManage : Page
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002071 File Offset: 0x00000271
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005938 File Offset: 0x00003B38
		protected void GdvRoles_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
			RolesDB rolesDB = new RolesDB();
			string resourceKey = "";
			int id = Convert.ToInt32(e.Keys[this.GdvRoles.KeyFieldName].ToString());
			if (rolesDB.Delete(id, out resourceKey))
			{
				this.GdvRoles.DataBind();
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
			string value = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
			((ASPxGridView)sender).JSProperties["cpDeleteError"] = value;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000059DC File Offset: 0x00003BDC
		protected void GdvRoles_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			RolesDB rolesDB = new RolesDB();
			ADMRoles admroles = new ADMRoles();
			admroles.RoleID = Convert.ToInt32(e.Keys[this.GdvRoles.KeyFieldName]);
			admroles.Code = e.NewValues["Code"].ToString();
			admroles.RoleEName = e.NewValues["RoleEName"].ToString();
			admroles.RoleAName = e.NewValues["RoleAName"].ToString();
			admroles.UserType = Convert.ToInt32(e.NewValues["UserType"]);
			admroles.FKModuleID = new int?(Convert.ToInt32(e.NewValues["FKModuleID"]));
			if (e.NewValues["Notes"] == null)
			{
				admroles.Notes = string.Empty;
			}
			else
			{
				admroles.Notes = e.NewValues["Notes"].ToString();
			}
			string resourceKey = "";
			if (rolesDB.Update(admroles, out resourceKey))
			{
				this.GdvRoles.CancelEdit();
				this.GdvRoles.DataBind();
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
			string message = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
			throw new Exception("SaveError", new Exception(message));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000047A0 File Offset: 0x000029A0
		protected void GdvRoles_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = e.Exception.InnerException.Message;
				return;
			}
			e.ErrorText = base.GetGlobalResourceObject("GLobalMessages", "GeneralError").ToString();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005B50 File Offset: 0x00003D50
		protected void GdvRoles_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			RolesDB rolesDB = new RolesDB();
			string resourceKey = "";
			ADMRoles admroles = new ADMRoles();
			admroles.Code = e.NewValues["Code"].ToString();
			admroles.RoleEName = e.NewValues["RoleEName"].ToString();
			admroles.RoleAName = e.NewValues["RoleAName"].ToString();
			admroles.UserType = Convert.ToInt32(e.NewValues["UserType"]);
			admroles.FKModuleID = new int?(Convert.ToInt32(e.NewValues["FKModuleID"]));
			if (e.NewValues["Notes"] == null)
			{
				admroles.Notes = string.Empty;
			}
			else
			{
				admroles.Notes = e.NewValues["Notes"].ToString();
			}
			if (rolesDB.Insert(admroles, out resourceKey))
			{
				this.GdvRoles.CancelEdit();
				this.GdvRoles.DataBind();
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
			string message = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
			throw new Exception("SaveError", new Exception(message));
		}

		// Token: 0x0400001D RID: 29
		protected HtmlGenericControl ultitle;

		// Token: 0x0400001E RID: 30
		protected ASPxButton Button1;

		// Token: 0x0400001F RID: 31
		protected ASPxGridView GdvRoles;

		// Token: 0x04000020 RID: 32
		protected ObjectDataSource RolesDS;

		// Token: 0x04000021 RID: 33
		protected ObjectDataSource CategoryMasterDS;
	}
}
