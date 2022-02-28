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
	// Token: 0x0200004A RID: 74
	public class PriceUnit : Page
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x00019884 File Offset: 0x00017A84
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/PriceUnit.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002F9 RID: 761 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvPriceUnitList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x000199EC File Offset: 0x00017BEC
		protected void GdvPriceUnitList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
			{
				e.Enabled = false;
			}
			if (this.lblDelete.Text == "false" && e.ButtonType == ColumnCommandButtonType.Delete)
			{
				e.Enabled = false;
			}
			if (this.lblAdd.Text == "false" && e.ButtonType == ColumnCommandButtonType.New)
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00003C2C File Offset: 0x00001E2C
		protected void GdvPriceUnitList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvPriceUnitList.JSProperties["cpFilter"] = this.GdvPriceUnitList.FilterExpression;
		}

		// Token: 0x040004C3 RID: 1219
		protected HtmlGenericControl ultitle;

		// Token: 0x040004C4 RID: 1220
		protected ASPxLabel lblView;

		// Token: 0x040004C5 RID: 1221
		protected ASPxLabel lblEdite;

		// Token: 0x040004C6 RID: 1222
		protected ASPxLabel lblDelete;

		// Token: 0x040004C7 RID: 1223
		protected ASPxLabel lblAdd;

		// Token: 0x040004C8 RID: 1224
		protected ASPxButton btnAddNew;

		// Token: 0x040004C9 RID: 1225
		protected ASPxButton btnPrint;

		// Token: 0x040004CA RID: 1226
		protected ASPxGridView GdvPriceUnitList;

		// Token: 0x040004CB RID: 1227
		protected ObjectDataSource PriceUnitListDS;
	}
}
