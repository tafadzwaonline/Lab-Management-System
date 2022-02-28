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
	// Token: 0x02000023 RID: 35
	public class PaymentManage : Page
	{
		// Token: 0x0600012E RID: 302 RVA: 0x0000B030 File Offset: 0x00009230
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/PaymentManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x0600012F RID: 303 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvSampleReceiveList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002D2E File Offset: 0x00000F2E
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("PaymentInfo.aspx");
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002D40 File Offset: 0x00000F40
		protected void GdvPaymentHistory_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("PaymentInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002D5C File Offset: 0x00000F5C
		protected void GdvPaymentHistory_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000B198 File Offset: 0x00009398
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

		// Token: 0x06000134 RID: 308 RVA: 0x00002D8E File Offset: 0x00000F8E
		protected void GdvPaymentHistory_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvPaymentHistory.JSProperties["cpFilter"] = this.GdvPaymentHistory.FilterExpression;
		}

		// Token: 0x04000170 RID: 368
		protected HtmlGenericControl ultitle;

		// Token: 0x04000171 RID: 369
		protected ASPxLabel lblView;

		// Token: 0x04000172 RID: 370
		protected ASPxLabel lblEdite;

		// Token: 0x04000173 RID: 371
		protected ASPxLabel lblDelete;

		// Token: 0x04000174 RID: 372
		protected ASPxLabel lblAdd;

		// Token: 0x04000175 RID: 373
		protected ASPxButton btnAddNew;

		// Token: 0x04000176 RID: 374
		protected ASPxButton btnPrint;

		// Token: 0x04000177 RID: 375
		protected ASPxGridView GdvPendingPayment;

		// Token: 0x04000178 RID: 376
		protected GridViewCommandColumnCustomButton btnConvert;

		// Token: 0x04000179 RID: 377
		protected ASPxGridView GdvPaymentHistory;

		// Token: 0x0400017A RID: 378
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x0400017B RID: 379
		protected ObjectDataSource CustomersListDS;

		// Token: 0x0400017C RID: 380
		protected ObjectDataSource PaymentHistoryDS;

		// Token: 0x0400017D RID: 381
		protected ObjectDataSource PendingPaymentDS;

		// Token: 0x0400017E RID: 382
		protected ObjectDataSource JobOrderDS;
	}
}
