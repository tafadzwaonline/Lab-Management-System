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
	// Token: 0x02000044 RID: 68
	public class CustomerInfoManage : Page
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x00018174 File Offset: 0x00016374
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/CustomerInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
				this.btnPrint.ToolTip = "You  dont have Permission to Add";
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvEmployeesList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000039F2 File Offset: 0x00001BF2
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("CustomerInfo.aspx");
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00003A04 File Offset: 0x00001C04
		protected void GdvCustomersList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("CustomerInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00003A20 File Offset: 0x00001C20
		protected void GdvCustomersList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvCustomersList.JSProperties["cpFilter"] = this.GdvCustomersList.FilterExpression;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x000182DC File Offset: 0x000164DC
		protected void GdvCustomersList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060002CA RID: 714 RVA: 0x00003A42 File Offset: 0x00001C42
		protected void GdvCustomersList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x04000473 RID: 1139
		protected HtmlGenericControl ultitle;

		// Token: 0x04000474 RID: 1140
		protected ASPxLabel lblView;

		// Token: 0x04000475 RID: 1141
		protected ASPxLabel lblEdite;

		// Token: 0x04000476 RID: 1142
		protected ASPxLabel lblDelete;

		// Token: 0x04000477 RID: 1143
		protected ASPxLabel lblAdd;

		// Token: 0x04000478 RID: 1144
		protected ASPxButton btnAddNew;

		// Token: 0x04000479 RID: 1145
		protected ASPxButton btnPrint;

		// Token: 0x0400047A RID: 1146
		protected ASPxGridView GdvCustomersList;

		// Token: 0x0400047B RID: 1147
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x0400047C RID: 1148
		protected ObjectDataSource CustomersListDS;
	}
}
