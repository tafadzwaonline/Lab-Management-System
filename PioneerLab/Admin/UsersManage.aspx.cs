using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;

namespace PioneerLab.Admin
{
	// Token: 0x02000008 RID: 8
	public class UsersManage : Page
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00002071 File Offset: 0x00000271
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000229E File Offset: 0x0000049E
		protected void btnNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("Users.aspx?id=0");
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00006160 File Offset: 0x00004360
		protected void GdvUsers_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
		{
			UsersDB usersDB = new UsersDB();
			if (e.CommandArgs.CommandName == "CmdEdit")
			{
				base.Response.Redirect("Users.aspx?Id=" + e.CommandArgs.CommandArgument);
				return;
			}
			if (e.CommandArgs.CommandName == "CmdDelete")
			{
				string resourceKey = "";
				int id = Convert.ToInt32(e.CommandArgs.CommandArgument);
				ADMUsers byID = usersDB.GetByID(id);
				byID.IsRemoved = true;
				if (usersDB.Update(byID, out resourceKey))
				{
					this.GdvUsers.DataBind();
				}
				else
				{
					string value = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
					((ASPxGridView)sender).JSProperties["cpDeleteError"] = value;
				}
				this.GdvUsers.DataBind();
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000047A0 File Offset: 0x000029A0
		protected void GdvUsers_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = e.Exception.InnerException.Message;
				return;
			}
			e.ErrorText = base.GetGlobalResourceObject("GLobalMessages", "GeneralError").ToString();
		}

		// Token: 0x04000041 RID: 65
		protected HtmlGenericControl ultitle;

		// Token: 0x04000042 RID: 66
		protected ASPxButton btnNew;

		// Token: 0x04000043 RID: 67
		protected ASPxGridView GdvUsers;

		// Token: 0x04000044 RID: 68
		protected ObjectDataSource UsersDS;
	}
}
