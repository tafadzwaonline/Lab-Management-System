using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Utils;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x02000035 RID: 53
	public class JobOrderManage : Page
	{
		// Token: 0x060001DC RID: 476 RVA: 0x00010788 File Offset: 0x0000E988
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/JobOrderManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060001DD RID: 477 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00003207 File Offset: 0x00001407
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("JobOrder.aspx");
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00003219 File Offset: 0x00001419
		protected void GdvJobOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("JobOrder.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000108F0 File Offset: 0x0000EAF0
		protected void GdvJobOrder_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.CellType == GridViewTableCommandCellType.Data)
			{
				int num = Convert.ToInt32(this.GdvJobOrder.GetRowValues(e.VisibleIndex, new string[]
				{
					"StatusID"
				}));
				if (e.ButtonID == "btnApprove")
				{
					if (num != 0)
					{
						e.Visible = DefaultBoolean.False;
					}
					List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
					foreach (ADMUserSettings admuserSettings in allUserSettings)
					{
						if (admuserSettings.SettingsName == "Approve Job Order" && admuserSettings.SettingsValue == "True")
						{
							if (e.ButtonID == "btnApprove")
							{
								e.Enabled = true;
							}
						}
						else if (admuserSettings.SettingsName == "Approve Job Order" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnApprove")
						{
							e.Enabled = false;
						}
					}
				}
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00003219 File Offset: 0x00001419
		protected void GdvApprovedJobOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("JobOrder.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00003235 File Offset: 0x00001435
		protected void GdvExpiredJobOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("JobOrder.aspx?id=" + e.KeyValue.ToString() + "&mode=Expired");
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00010A30 File Offset: 0x0000EC30
		protected void GdvExpiredJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "You can not delete this job order becouse it have Work Order ")
			{
				e.ErrorText = "You can not delete this job order becouse it have Work Order ";
			}
			if (e.Exception.InnerException.Message == "You can not delete this job order becouse it have Sample Receive  ")
			{
				e.ErrorText = "You can not delete this job order becouse it have Sample Receive  ";
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00010AA8 File Offset: 0x0000ECA8
		protected void GdvJobOrder_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060001E5 RID: 485 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvApprovedJobOrder_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00003256 File Offset: 0x00001456
		protected void GdvExpiredJobOrder_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00010B04 File Offset: 0x0000ED04
		protected void GdvJobOrder_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
		{
			if (e.RowType == GridViewRowType.Data)
			{
				ASPxGridView aspxGridView = (ASPxGridView)sender;
				HtmlGenericControl htmlGenericControl = (HtmlGenericControl)aspxGridView.FindRowCellTemplateControlByKey(e.KeyValue, (GridViewDataColumn)aspxGridView.Columns["Attachment"], "attchCount");
				AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
				htmlGenericControl.InnerText = attachedFilesDB.GetAttachmentsCount(Convert.ToInt64(e.KeyValue), 11111).ToString();
			}
		}

		// Token: 0x040002BC RID: 700
		protected HtmlGenericControl ultitle;

		// Token: 0x040002BD RID: 701
		protected ASPxLabel lblView;

		// Token: 0x040002BE RID: 702
		protected ASPxLabel lblEdite;

		// Token: 0x040002BF RID: 703
		protected ASPxLabel lblDelete;

		// Token: 0x040002C0 RID: 704
		protected ASPxLabel lblAdd;

		// Token: 0x040002C1 RID: 705
		protected ASPxButton btnAddNew;

		// Token: 0x040002C2 RID: 706
		protected ASPxButton btnPrint;

		// Token: 0x040002C3 RID: 707
		protected ASPxGridView GdvJobOrder;

		// Token: 0x040002C4 RID: 708
		protected GridViewCommandColumnCustomButton btnApprove;

		// Token: 0x040002C5 RID: 709
		protected ASPxGridView GdvApprovedJobOrder;

		// Token: 0x040002C6 RID: 710
		protected ASPxGridView GdvExpiredJobOrder;

		// Token: 0x040002C7 RID: 711
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040002C8 RID: 712
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x040002C9 RID: 713
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040002CA RID: 714
		protected ObjectDataSource ApprovedJobOrderMasterDS;

		// Token: 0x040002CB RID: 715
		protected ObjectDataSource ExpiredJobOrderMasterDS;

		// Token: 0x040002CC RID: 716
		protected ObjectDataSource ProjectsListDS;
	}
}
