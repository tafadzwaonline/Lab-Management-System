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
	// Token: 0x0200001B RID: 27
	public class PaymentInAdvanceManage : Page
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00009034 File Offset: 0x00007234
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/PaymentInAdvanceManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060000E5 RID: 229 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvSampleReceiveList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002A3E File Offset: 0x00000C3E
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("PaymentInfo.aspx?mode=NewLinkAdvanced");
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00002A50 File Offset: 0x00000C50
		protected void GdvPaymentHistory_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("PaymentInfo.aspx?id=" + e.KeyValue.ToString() + "&mode=ViewLinkAdvanced");
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00002A71 File Offset: 0x00000C71
		protected void GdvPaymentHistory_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000919C File Offset: 0x0000739C
		protected void GdvPaymentHistory_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060000EA RID: 234 RVA: 0x00002AA3 File Offset: 0x00000CA3
		protected void GdvPaymentHistory_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvPaymentHistory.JSProperties["cpFilter"] = this.GdvPaymentHistory.FilterExpression;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00002AC5 File Offset: 0x00000CC5
		protected void GdvPendingAdvancedPayment_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("PaymentInfo.aspx?id=" + e.KeyValue.ToString() + "&mode=NewLinkAdvanced");
		}

		// Token: 0x040000E6 RID: 230
		protected HtmlGenericControl ultitle;

		// Token: 0x040000E7 RID: 231
		protected ASPxLabel lblView;

		// Token: 0x040000E8 RID: 232
		protected ASPxLabel lblEdite;

		// Token: 0x040000E9 RID: 233
		protected ASPxLabel lblDelete;

		// Token: 0x040000EA RID: 234
		protected ASPxLabel lblAdd;

		// Token: 0x040000EB RID: 235
		protected ASPxButton btnAddNew;

		// Token: 0x040000EC RID: 236
		protected ASPxButton btnPrint;

		// Token: 0x040000ED RID: 237
		protected ASPxGridView GdvPendingAdvancedPayment;

		// Token: 0x040000EE RID: 238
		protected GridViewCommandColumnCustomButton btnConvert;

		// Token: 0x040000EF RID: 239
		protected ASPxGridView GdvPaymentHistory;

		// Token: 0x040000F0 RID: 240
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040000F1 RID: 241
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040000F2 RID: 242
		protected ObjectDataSource PaymentHistoryDS;

		// Token: 0x040000F3 RID: 243
		protected ObjectDataSource JobOrderDS;

		// Token: 0x040000F4 RID: 244
		protected ObjectDataSource PendingAvancedPaymentDS;
	}
}
