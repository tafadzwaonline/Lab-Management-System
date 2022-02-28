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
	// Token: 0x02000013 RID: 19
	public class AccreditionStatus : Page
	{
		// Token: 0x0600009F RID: 159 RVA: 0x000071BC File Offset: 0x000053BC
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/AccreditionStatus.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060000A0 RID: 160 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvAccreditionList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002754 File Offset: 0x00000954
		protected void GdvAccreditionList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvAccreditionList.JSProperties["cpFilter"] = this.GdvAccreditionList.FilterExpression;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00007384 File Offset: 0x00005584
		protected void GdvAccreditionList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060000A3 RID: 163 RVA: 0x00002071 File Offset: 0x00000271
		protected void btnPrint_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400007A RID: 122
		protected HtmlGenericControl ultitle;

		// Token: 0x0400007B RID: 123
		protected ASPxLabel lblView;

		// Token: 0x0400007C RID: 124
		protected ASPxLabel lblEdite;

		// Token: 0x0400007D RID: 125
		protected ASPxLabel lblDelete;

		// Token: 0x0400007E RID: 126
		protected ASPxLabel lblAdd;

		// Token: 0x0400007F RID: 127
		protected ASPxButton btnAddNew;

		// Token: 0x04000080 RID: 128
		protected ASPxButton btnPrint;

		// Token: 0x04000081 RID: 129
		protected ASPxGridView GdvAccreditionList;

		// Token: 0x04000082 RID: 130
		protected ObjectDataSource AccreditionListDS;
	}
}
