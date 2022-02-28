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
	// Token: 0x0200003B RID: 59
	public class CustomerEnquiryManage : Page
	{
		// Token: 0x06000246 RID: 582 RVA: 0x00014AB0 File Offset: 0x00012CB0
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/CustomerEnquiryManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
			else
			{
				this.btnPrint.Enabled = true;
			}
			if (this.lblAdd.Text == "false")
			{
				this.btnAddNew.Enabled = false;
				this.btnAddNew.ToolTip = "You  dont have Permission to Add";
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00014C24 File Offset: 0x00012E24
		protected void GdvCustomerEnquiry_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "can not delete, alredy converted to Quotation")
			{
				e.ErrorText = "can not delete, alredy converted to Quotation";
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00003477 File Offset: 0x00001677
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("CustomerEnquiry.aspx");
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00003489 File Offset: 0x00001689
		protected void GdvCustomerEnquiry_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("CustomerEnquiry.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00014C78 File Offset: 0x00012E78
		protected void GdvCustomerEnquiry_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.ButtonID == "btnView")
			{
				if (this.lblView.Text == "True")
				{
					e.Enabled = true;
				}
				else
				{
					e.Enabled = false;
				}
			}
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Customer Enquiry Copy" && admuserSettings.SettingsValue == "True")
				{
					if (e.ButtonID == "btnNewVersion")
					{
						e.Enabled = true;
					}
				}
				else if (admuserSettings.SettingsName == "Customer Enquiry Copy" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnNewVersion")
				{
					e.Enabled = false;
				}
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00014DA0 File Offset: 0x00012FA0
		protected void GdvCustomerEnquiry_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x04000398 RID: 920
		protected HtmlGenericControl ultitle;

		// Token: 0x04000399 RID: 921
		protected ASPxLabel lblView;

		// Token: 0x0400039A RID: 922
		protected ASPxLabel lblEdite;

		// Token: 0x0400039B RID: 923
		protected ASPxLabel lblDelete;

		// Token: 0x0400039C RID: 924
		protected ASPxLabel lblAdd;

		// Token: 0x0400039D RID: 925
		protected ASPxButton btnAddNew;

		// Token: 0x0400039E RID: 926
		protected ASPxButton btnPrint;

		// Token: 0x0400039F RID: 927
		protected ASPxGridView GdvCustomerEnquiry;

		// Token: 0x040003A0 RID: 928
		protected GridViewCommandColumnCustomButton btnNewVersion;

		// Token: 0x040003A1 RID: 929
		protected ObjectDataSource EnquiryMasterDS;

		// Token: 0x040003A2 RID: 930
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040003A3 RID: 931
		protected ObjectDataSource ProjectsListDS;
	}
}
