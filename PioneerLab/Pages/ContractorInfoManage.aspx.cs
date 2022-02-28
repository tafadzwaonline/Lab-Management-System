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
	// Token: 0x02000018 RID: 24
	public class ContractorInfoManage : Page
	{
		// Token: 0x060000CE RID: 206 RVA: 0x000082A0 File Offset: 0x000064A0
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ContractorInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060000CF RID: 207 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvContractorsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000298E File Offset: 0x00000B8E
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("ContractorInfo.aspx");
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000029A0 File Offset: 0x00000BA0
		protected void GdvContractorsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("ContractorInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000029BC File Offset: 0x00000BBC
		protected void GdvContractorsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvContractorsList.JSProperties["cpFilter"] = this.GdvContractorsList.FilterExpression;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000029DE File Offset: 0x00000BDE
		protected void GdvContractorsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00008408 File Offset: 0x00006608
		protected void GdvContractorsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x040000BC RID: 188
		protected HtmlGenericControl ultitle;

		// Token: 0x040000BD RID: 189
		protected ASPxLabel lblView;

		// Token: 0x040000BE RID: 190
		protected ASPxLabel lblEdite;

		// Token: 0x040000BF RID: 191
		protected ASPxLabel lblDelete;

		// Token: 0x040000C0 RID: 192
		protected ASPxLabel lblAdd;

		// Token: 0x040000C1 RID: 193
		protected ASPxButton btnAddNew;

		// Token: 0x040000C2 RID: 194
		protected ASPxButton btnPrint;

		// Token: 0x040000C3 RID: 195
		protected ASPxGridView GdvContractorsList;

		// Token: 0x040000C4 RID: 196
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040000C5 RID: 197
		protected ObjectDataSource ContractorsListDS;
	}
}
