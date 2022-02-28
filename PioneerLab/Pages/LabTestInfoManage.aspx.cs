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
	// Token: 0x02000040 RID: 64
	public class LabTestInfoManage : Page
	{
		// Token: 0x06000297 RID: 663 RVA: 0x000172BC File Offset: 0x000154BC
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/LabTestInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x06000298 RID: 664 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvLabTestsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x000037AA File Offset: 0x000019AA
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("LabTestInfo.aspx");
		}

		// Token: 0x0600029A RID: 666 RVA: 0x000037BC File Offset: 0x000019BC
		protected void GdvLabTestsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("LabTestInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000037D8 File Offset: 0x000019D8
		protected void GdvLabTestsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvLabTestsList.JSProperties["cpFilter"] = this.GdvLabTestsList.FilterExpression;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000037FA File Offset: 0x000019FA
		protected void GdvLabTestsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00017424 File Offset: 0x00015624
		protected void GdvLabTestsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x0600029E RID: 670 RVA: 0x00002071 File Offset: 0x00000271
		protected void popupOptions_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
		}

		// Token: 0x04000430 RID: 1072
		protected HtmlGenericControl ultitle;

		// Token: 0x04000431 RID: 1073
		protected ASPxLabel lblView;

		// Token: 0x04000432 RID: 1074
		protected ASPxLabel lblEdite;

		// Token: 0x04000433 RID: 1075
		protected ASPxLabel lblDelete;

		// Token: 0x04000434 RID: 1076
		protected ASPxLabel lblAdd;

		// Token: 0x04000435 RID: 1077
		protected ASPxButton btnAddNew;

		// Token: 0x04000436 RID: 1078
		protected ASPxButton btnPrint;

		// Token: 0x04000437 RID: 1079
		protected ASPxPopupControl popupOptions;

		// Token: 0x04000438 RID: 1080
		protected PopupControlContentControl PopupControlContentControl2;

		// Token: 0x04000439 RID: 1081
		protected HtmlImage previewImage;

		// Token: 0x0400043A RID: 1082
		protected ASPxGridView GdvLabTestsList;

		// Token: 0x0400043B RID: 1083
		protected ObjectDataSource TestsListDS;
	}
}
