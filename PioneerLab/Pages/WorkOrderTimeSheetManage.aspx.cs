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
	// Token: 0x02000027 RID: 39
	public class WorkOrderTimeSheetManage : Page
	{
		// Token: 0x0600015E RID: 350 RVA: 0x0000C3A8 File Offset: 0x0000A5A8
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/WorkOrderTimeSheet.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x0600015F RID: 351 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00002DB0 File Offset: 0x00000FB0
		protected void GdvActiveWorkOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("TimeSheet.aspx?id=" + e.KeyValue.ToString() + "&mode=Edit");
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008464 File Offset: 0x00006664
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

		// Token: 0x06000162 RID: 354 RVA: 0x00002DD1 File Offset: 0x00000FD1
		protected void GdvWorkOrderHistory_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("TimeSheet.aspx?id=" + e.KeyValue.ToString() + "&mode=View");
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000B6BC File Offset: 0x000098BC
		protected void GdvPendingCheckedWorkOrder_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Check Time Sheet" && admuserSettings.SettingsValue == "True")
				{
					if (e.ButtonID == "btnChecked")
					{
						e.Enabled = true;
					}
				}
				else if (admuserSettings.SettingsName == "Check Time Sheet" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnChecked")
				{
					e.Enabled = false;
				}
				if (admuserSettings.SettingsName == "Approve Time Sheet" && admuserSettings.SettingsValue == "True")
				{
					if (e.ButtonID == "btnApprove")
					{
						e.Enabled = true;
					}
				}
				else if (admuserSettings.SettingsName == "Approve Time Sheet" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnApprove")
				{
					e.Enabled = false;
				}
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvPendingCheckedWorkOrder_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
		}

		// Token: 0x040001E8 RID: 488
		protected HtmlGenericControl ultitle;

		// Token: 0x040001E9 RID: 489
		protected ASPxLabel lblView;

		// Token: 0x040001EA RID: 490
		protected ASPxLabel lblEdite;

		// Token: 0x040001EB RID: 491
		protected ASPxLabel lblDelete;

		// Token: 0x040001EC RID: 492
		protected ASPxLabel lblAdd;

		// Token: 0x040001ED RID: 493
		protected ASPxGridView GdvPendingCheckedWorkOrder;

		// Token: 0x040001EE RID: 494
		protected GridViewCommandColumnCustomButton btnChecked;

		// Token: 0x040001EF RID: 495
		protected ASPxGridView GdvPendingApproveWorkOrder;

		// Token: 0x040001F0 RID: 496
		protected GridViewCommandColumnCustomButton btnApprove;

		// Token: 0x040001F1 RID: 497
		protected ASPxGridView GdvWorkOrderHistory;

		// Token: 0x040001F2 RID: 498
		protected ObjectDataSource PendingCheckedWorkOrderDS;

		// Token: 0x040001F3 RID: 499
		protected ObjectDataSource PendingApprovedWorkOrderDS;

		// Token: 0x040001F4 RID: 500
		protected ObjectDataSource CheckedApprovedWorkOrderDS;

		// Token: 0x040001F5 RID: 501
		protected ObjectDataSource JobOrderDS;

		// Token: 0x040001F6 RID: 502
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x040001F7 RID: 503
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040001F8 RID: 504
		protected ObjectDataSource ApprovedJobOrderMasterDS;

		// Token: 0x040001F9 RID: 505
		protected ObjectDataSource ExpiredJobOrderMasterDS;

		// Token: 0x040001FA RID: 506
		protected ObjectDataSource ProjectsListDS;
	}
}
