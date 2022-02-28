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
	// Token: 0x02000020 RID: 32
	public class WorkOrderDataManage : Page
	{
		// Token: 0x06000118 RID: 280 RVA: 0x0000A1F0 File Offset: 0x000083F0
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/WorkOrderTimeSheetManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00002C4B File Offset: 0x00000E4B
		protected void GdvActiveWorkOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("WorkOrderData.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00008464 File Offset: 0x00006664
		protected void GdvActiveWorkOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "You can not delete this WorkOrder becouse it have Time Sheet ")
			{
				e.ErrorText = "You can not delete this WorkOrder becouse it have Time Sheet ";
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000A2F0 File Offset: 0x000084F0
		protected void GdvActiveWorkOrder_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x04000146 RID: 326
		protected HtmlGenericControl ultitle;

		// Token: 0x04000147 RID: 327
		protected ASPxLabel lblView;

		// Token: 0x04000148 RID: 328
		protected ASPxLabel lblEdite;

		// Token: 0x04000149 RID: 329
		protected ASPxLabel lblDelete;

		// Token: 0x0400014A RID: 330
		protected ASPxLabel lblAdd;

		// Token: 0x0400014B RID: 331
		protected HtmlGenericControl divmsg;

		// Token: 0x0400014C RID: 332
		protected ASPxLabel LblError;

		// Token: 0x0400014D RID: 333
		protected ASPxGridView GdvWorkOrder;

		// Token: 0x0400014E RID: 334
		protected ObjectDataSource WorkOrderDS;

		// Token: 0x0400014F RID: 335
		protected ObjectDataSource JobOrderDS;

		// Token: 0x04000150 RID: 336
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x04000151 RID: 337
		protected ObjectDataSource CustomersListDS;

		// Token: 0x04000152 RID: 338
		protected ObjectDataSource ProjectsListDS;
	}
}
