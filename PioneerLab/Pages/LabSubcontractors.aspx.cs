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
	// Token: 0x02000049 RID: 73
	public class LabSubcontractors : Page
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x000195E0 File Offset: 0x000177E0
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/LabSubcontractors.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002F4 RID: 756 RVA: 0x00019748 File Offset: 0x00017948
		protected void GdvSubcontractorsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "Dublicate Code Number")
			{
				e.ErrorText = "Dublicate Code Number";
			}
			if (e.Exception.InnerException.Message == "negative number is  not allow")
			{
				e.ErrorText = "negative number is  not allow";
			}
			if (e.Exception.InnerException.Message == "alphabets is  not allow")
			{
				e.ErrorText = "alphabets is  not allow";
				return;
			}
			e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00019828 File Offset: 0x00017A28
		protected void GdvSubcontractorsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060002F6 RID: 758 RVA: 0x00003C0A File Offset: 0x00001E0A
		protected void GdvSubcontractorsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvSubcontractorsList.JSProperties["cpFilter"] = this.GdvSubcontractorsList.FilterExpression;
		}

		// Token: 0x040004BA RID: 1210
		protected HtmlGenericControl ultitle;

		// Token: 0x040004BB RID: 1211
		protected ASPxLabel lblView;

		// Token: 0x040004BC RID: 1212
		protected ASPxLabel lblEdite;

		// Token: 0x040004BD RID: 1213
		protected ASPxLabel lblDelete;

		// Token: 0x040004BE RID: 1214
		protected ASPxLabel lblAdd;

		// Token: 0x040004BF RID: 1215
		protected ASPxButton btnAddNew;

		// Token: 0x040004C0 RID: 1216
		protected ASPxButton btnPrint;

		// Token: 0x040004C1 RID: 1217
		protected ASPxGridView GdvSubcontractorsList;

		// Token: 0x040004C2 RID: 1218
		protected ObjectDataSource SubcontractorsListDS;
	}
}
