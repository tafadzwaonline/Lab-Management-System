using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x02000043 RID: 67
	public class ProjectInfoManage : Page
	{
		// Token: 0x060002BD RID: 701 RVA: 0x00017FB0 File Offset: 0x000161B0
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ProjectInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
			foreach (UserLinkOptionsView userLinkOptionsView in allOptionsForLink)
			{
				if (userLinkOptionsView.OptionEName == "Add")
				{
					this.lblAdd.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "Edit")
				{
					this.lblEdite.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "Delete")
				{
					this.lblDelete.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "View")
				{
					this.lblView.Text = "True";
				}
			}
			if (this.lblView.Text == "false")
			{
				this.btnPrint.Enabled = false;
				this.btnPrint.ToolTip = "You  dont have Permission to Print";
			}
			if (this.lblAdd.Text == "false")
			{
				this.btnAddNew.Enabled = false;
				this.btnAddNew.ToolTip = "You  dont have Permission to Add";
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvProjectsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000039A2 File Offset: 0x00001BA2
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("ProjectInfo.aspx");
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000039B4 File Offset: 0x00001BB4
		protected void GdvProjectsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("ProjectInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00018118 File Offset: 0x00016318
		protected void GdvProjectsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
			{
				e.Enabled = false;
			}
			if (this.lblDelete.Text == "false" && e.ButtonType == ColumnCommandButtonType.Delete)
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000039D0 File Offset: 0x00001BD0
		protected void GdvProjectsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvProjectsList.JSProperties["cpFilter"] = this.GdvProjectsList.FilterExpression;
		}

		// Token: 0x04000469 RID: 1129
		protected HtmlGenericControl ultitle;

		// Token: 0x0400046A RID: 1130
		protected ASPxLabel lblView;

		// Token: 0x0400046B RID: 1131
		protected ASPxLabel lblEdite;

		// Token: 0x0400046C RID: 1132
		protected ASPxLabel lblDelete;

		// Token: 0x0400046D RID: 1133
		protected ASPxLabel lblAdd;

		// Token: 0x0400046E RID: 1134
		protected ASPxButton btnAddNew;

		// Token: 0x0400046F RID: 1135
		protected ASPxButton btnPrint;

		// Token: 0x04000470 RID: 1136
		protected ASPxGridView GdvProjectsList;

		// Token: 0x04000471 RID: 1137
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x04000472 RID: 1138
		protected ObjectDataSource ProjectsListDS;
	}
}
