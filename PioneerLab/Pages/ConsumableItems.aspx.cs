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
	// Token: 0x02000016 RID: 22
	public class ConsumableItems : Page
	{
		// Token: 0x060000BE RID: 190 RVA: 0x00007C0C File Offset: 0x00005E0C
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ConsumableItems.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060000BF RID: 191 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvItemsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002897 File Offset: 0x00000A97
		protected void GdvItemsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvItemsList.JSProperties["cpFilter"] = this.GdvItemsList.FilterExpression;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00007D74 File Offset: 0x00005F74
		protected void GdvItemsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060000C2 RID: 194 RVA: 0x000028B9 File Offset: 0x00000AB9
		protected void GdvItemsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x04000098 RID: 152
		protected HtmlGenericControl ultitle;

		// Token: 0x04000099 RID: 153
		protected ASPxLabel lblView;

		// Token: 0x0400009A RID: 154
		protected ASPxLabel lblEdite;

		// Token: 0x0400009B RID: 155
		protected ASPxLabel lblDelete;

		// Token: 0x0400009C RID: 156
		protected ASPxLabel lblAdd;

		// Token: 0x0400009D RID: 157
		protected ASPxButton btnAddNew;

		// Token: 0x0400009E RID: 158
		protected ASPxButton btnPrint;

		// Token: 0x0400009F RID: 159
		protected ASPxGridView GdvItemsList;

		// Token: 0x040000A0 RID: 160
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040000A1 RID: 161
		protected ObjectDataSource ItemsListDS;
	}
}
