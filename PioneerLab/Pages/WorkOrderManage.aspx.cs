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
	// Token: 0x02000026 RID: 38
	public class WorkOrderManage : Page
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0000C24C File Offset: 0x0000A44C
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

		// Token: 0x06000159 RID: 345 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00002BE1 File Offset: 0x00000DE1
		protected void GdvActiveWorkOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("TimeSheet.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00008464 File Offset: 0x00006664
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

		// Token: 0x0600015C RID: 348 RVA: 0x0000C34C File Offset: 0x0000A54C
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

		// Token: 0x040001D5 RID: 469
		protected HtmlGenericControl ultitle;

		// Token: 0x040001D6 RID: 470
		protected ASPxLabel lblView;

		// Token: 0x040001D7 RID: 471
		protected ASPxLabel lblEdite;

		// Token: 0x040001D8 RID: 472
		protected ASPxLabel lblDelete;

		// Token: 0x040001D9 RID: 473
		protected ASPxLabel lblAdd;

		// Token: 0x040001DA RID: 474
		protected ASPxGridView GdvActiveWorkOrder;

		// Token: 0x040001DB RID: 475
		protected ASPxGridView GdvPendingExpiredWorkOrder;

		// Token: 0x040001DC RID: 476
		protected ASPxGridView ASPxGridView1;

		// Token: 0x040001DD RID: 477
		protected ASPxGridView GdvFinishedExpiredWorkOrder;

		// Token: 0x040001DE RID: 478
		protected ObjectDataSource PendingActiveWorkOrderDS;

		// Token: 0x040001DF RID: 479
		protected ObjectDataSource FinshedActiveWorkOrderDS;

		// Token: 0x040001E0 RID: 480
		protected ObjectDataSource PendingExpiredWorkOrderDS;

		// Token: 0x040001E1 RID: 481
		protected ObjectDataSource FinishedExpiredWorkOrderDS;

		// Token: 0x040001E2 RID: 482
		protected ObjectDataSource JobOrderDS;

		// Token: 0x040001E3 RID: 483
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x040001E4 RID: 484
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040001E5 RID: 485
		protected ObjectDataSource ApprovedJobOrderMasterDS;

		// Token: 0x040001E6 RID: 486
		protected ObjectDataSource ExpiredJobOrderMasterDS;

		// Token: 0x040001E7 RID: 487
		protected ObjectDataSource ProjectsListDS;
	}
}
