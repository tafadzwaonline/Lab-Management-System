using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x0200002E RID: 46
	public class TermsConditions : Page
	{
		// Token: 0x06000195 RID: 405 RVA: 0x0000E5CC File Offset: 0x0000C7CC
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/TermsConditions.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x06000196 RID: 406 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvTermsConditionsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000E734 File Offset: 0x0000C934
		protected void GdvTermsConditionsList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["TermName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["Description"] = ((ASPxMemo)aspxGridView.FindEditFormTemplateControl("txtDescription")).Text;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000E794 File Offset: 0x0000C994
		protected void GdvTermsConditionsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["TermName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["Description"] = ((ASPxMemo)aspxGridView.FindEditFormTemplateControl("txtDescription")).Text;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000E7F4 File Offset: 0x0000C9F4
		protected void GdvTermsConditionsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x0600019A RID: 410 RVA: 0x00003072 File Offset: 0x00001272
		protected void GdvTermsConditionsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvTermsConditionsList.JSProperties["cpFilter"] = this.GdvTermsConditionsList.FilterExpression;
		}

		// Token: 0x04000259 RID: 601
		protected HtmlGenericControl ultitle;

		// Token: 0x0400025A RID: 602
		protected ASPxLabel lblView;

		// Token: 0x0400025B RID: 603
		protected ASPxLabel lblEdite;

		// Token: 0x0400025C RID: 604
		protected ASPxLabel lblDelete;

		// Token: 0x0400025D RID: 605
		protected ASPxLabel lblAdd;

		// Token: 0x0400025E RID: 606
		protected ASPxButton btnAddNew;

		// Token: 0x0400025F RID: 607
		protected ASPxButton btnPrint;

		// Token: 0x04000260 RID: 608
		protected ASPxGridView GdvTermsConditionsList;

		// Token: 0x04000261 RID: 609
		protected ObjectDataSource TermsConditionsListDS;
	}
}
