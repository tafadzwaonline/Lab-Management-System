using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x0200001C RID: 28
	public class ReportGroup : Page
	{
		// Token: 0x060000ED RID: 237 RVA: 0x000091F8 File Offset: 0x000073F8
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

		// Token: 0x060000EE RID: 238 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvAccreditionList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002AE6 File Offset: 0x00000CE6
		protected void GdvServiceGroupList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvServiceGroupList.JSProperties["cpFilter"] = this.GdvServiceGroupList.FilterExpression;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00009360 File Offset: 0x00007560
		protected void GdvServiceGroupList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060000F1 RID: 241 RVA: 0x00002071 File Offset: 0x00000271
		protected void btnPrint_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000093BC File Offset: 0x000075BC
		protected void GdvServiceGroupList_InitNewRow(object sender, ASPxDataInitNewRowEventArgs e)
		{
			ReportGroupDB reportGroupDB = new ReportGroupDB();
			e.NewValues["GroupNumber"] = reportGroupDB.GetNewSerial();
		}

		// Token: 0x040000F5 RID: 245
		protected HtmlGenericControl ultitle;

		// Token: 0x040000F6 RID: 246
		protected ASPxLabel lblView;

		// Token: 0x040000F7 RID: 247
		protected ASPxLabel lblEdite;

		// Token: 0x040000F8 RID: 248
		protected ASPxLabel lblDelete;

		// Token: 0x040000F9 RID: 249
		protected ASPxLabel lblAdd;

		// Token: 0x040000FA RID: 250
		protected ASPxButton btnAddNew;

		// Token: 0x040000FB RID: 251
		protected ASPxButton btnPrint;

		// Token: 0x040000FC RID: 252
		protected ASPxGridView GdvServiceGroupList;

		// Token: 0x040000FD RID: 253
		protected ObjectDataSource ServiceGroupDS;
	}
}
