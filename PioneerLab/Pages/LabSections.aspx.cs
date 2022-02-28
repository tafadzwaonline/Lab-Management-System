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
	// Token: 0x0200004B RID: 75
	public class LabSections : Page
	{
		// Token: 0x060002FD RID: 765 RVA: 0x00019A70 File Offset: 0x00017C70
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/LabSections.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002FE RID: 766 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvLabsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00019BD8 File Offset: 0x00017DD8
		protected void GdvLabsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x06000300 RID: 768 RVA: 0x00003C4E File Offset: 0x00001E4E
		protected void GdvLabsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvLabsList.JSProperties["cpFilter"] = this.GdvLabsList.FilterExpression;
		}

		// Token: 0x040004CC RID: 1228
		protected HtmlGenericControl ultitle;

		// Token: 0x040004CD RID: 1229
		protected ASPxLabel lblView;

		// Token: 0x040004CE RID: 1230
		protected ASPxLabel lblEdite;

		// Token: 0x040004CF RID: 1231
		protected ASPxLabel lblDelete;

		// Token: 0x040004D0 RID: 1232
		protected ASPxLabel lblAdd;

		// Token: 0x040004D1 RID: 1233
		protected ASPxButton btnAddNew;

		// Token: 0x040004D2 RID: 1234
		protected ASPxButton btnPrint;

		// Token: 0x040004D3 RID: 1235
		protected ASPxGridView GdvLabsList;

		// Token: 0x040004D4 RID: 1236
		protected ObjectDataSource LabsListDS;
	}
}
