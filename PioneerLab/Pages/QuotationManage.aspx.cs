using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Utils;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x02000038 RID: 56
	public class QuotationManage : Page
	{
		// Token: 0x06000211 RID: 529 RVA: 0x00012A90 File Offset: 0x00010C90
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.Page.IsPostBack)
			{
				List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/QuotationManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
				this.GdvQuotation.DataBind();
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00012C10 File Offset: 0x00010E10
		protected void GdvQuotation_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
				return;
			}
			if (e.Exception.InnerException.Message == "You can not delete this job order becouse it have Sample Receive  ")
			{
				e.ErrorText = "You can not delete this job order becouse it have Sample Receive  ";
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000333F File Offset: 0x0000153F
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("Quotation.aspx");
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00003351 File Offset: 0x00001551
		protected void GdvQuotation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("Quotation.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00012C64 File Offset: 0x00010E64
		protected void GdvQuotation_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.CellType == GridViewTableCommandCellType.Data)
			{
				int num = Convert.ToInt32(this.GdvQuotation.GetRowValues(e.VisibleIndex, new string[]
				{
					"StatusID"
				}));
				if (e.ButtonID == "btnApprove" && num != 0)
				{
					e.Visible = DefaultBoolean.False;
				}
			}
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Approve Quotation" && admuserSettings.SettingsValue == "True")
				{
					if (e.ButtonID == "btnApprove")
					{
						e.Enabled = true;
					}
				}
				else if (admuserSettings.SettingsName == "Approve Quotation" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnApprove")
				{
					e.Enabled = false;
				}
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00012DA0 File Offset: 0x00010FA0
		protected void GdvQuotation_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x06000217 RID: 535 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvQuotationHistory_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00012DFC File Offset: 0x00010FFC
		protected void GdvQuotationHistory_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
		{
            SpGetAllQuotationMasterHistory_Result viewGetAllQuotationMasterHistory = (SpGetAllQuotationMasterHistory_Result)this.GdvQuotationHistory.GetRow(e.VisibleIndex);
			if (e.CommandArgs.CommandName == "View")
			{
				base.Response.Redirect("Quotation.aspx?id=" + viewGetAllQuotationMasterHistory.QuotationMasterID + "&mode=View");
				return;
			}
			if (e.CommandArgs.CommandName == "Revise")
			{
				base.Response.Redirect("Quotation.aspx?id=" + viewGetAllQuotationMasterHistory.QuotationMasterID + "&mode=revise");
				return;
			}
			if (e.CommandArgs.CommandName == "Print")
            {
                base.Response.Redirect("ReportViwer.aspx?source=QuotationReport2&id=" + viewGetAllQuotationMasterHistory.QuotationMasterID +"&Filter=");
                return;
            }
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00002071 File Offset: 0x00000271
		protected void btnView2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400032B RID: 811
		protected HtmlGenericControl ultitle;

		// Token: 0x0400032C RID: 812
		protected ASPxLabel lblView;

		// Token: 0x0400032D RID: 813
		protected ASPxLabel lblEdite;

		// Token: 0x0400032E RID: 814
		protected ASPxLabel lblDelete;

		// Token: 0x0400032F RID: 815
		protected ASPxLabel lblAdd;

		// Token: 0x04000330 RID: 816
		protected ASPxGridView GdvCustomerEnquiry;

		// Token: 0x04000331 RID: 817
		protected GridViewCommandColumnCustomButton btnConvert;

		// Token: 0x04000332 RID: 818
		protected ASPxGridView GdvQuotation;

		// Token: 0x04000333 RID: 819
		protected GridViewCommandColumnCustomButton btnApprove;

		// Token: 0x04000334 RID: 820
		protected ASPxButton btnAddNew;

		// Token: 0x04000335 RID: 821
		protected ASPxButton btnPrint;

		// Token: 0x04000336 RID: 822
		protected ASPxGridView GdvQuotationHistory;

		// Token: 0x04000337 RID: 823
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x04000338 RID: 824
		protected GridViewCommandColumnCustomButton btnRevise;

		// Token: 0x04000339 RID: 825
		protected GridViewCommandColumnCustomButton btnprintR;

		// Token: 0x0400033A RID: 826
		protected ObjectDataSource QuotationMasterDS;

		// Token: 0x0400033B RID: 827
		protected ObjectDataSource PendingQuotationMasterDS;

		// Token: 0x0400033C RID: 828
		protected ObjectDataSource EnquiryMasterDS;

		// Token: 0x0400033D RID: 829
		protected ObjectDataSource AllEnquiryMasterDS;
    }
}
