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
	// Token: 0x02000048 RID: 72
	public class EmployeeInfo : Page
	{
		// Token: 0x060002EB RID: 747 RVA: 0x000190EC File Offset: 0x000172EC
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/EmployeeInfo.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002EC RID: 748 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvEmployeesList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00019254 File Offset: 0x00017454
		protected void GdvEmployeesList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["EmpCode"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCode")).Text;
			e.NewValues["EmpName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["Profession"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtProfession")).Text;
			e.NewValues["QID"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtQid")).Text;
			e.NewValues["PhoneNumber"] = ((ASPxSpinEdit)aspxGridView.FindEditFormTemplateControl("txtTel")).Text;
			if (((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtNormalWH")).Text != "")
			{
				e.NewValues["NormalWorkHrs"] = int.Parse(((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtNormalWH")).Text);
			}
			if (((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtRamadanWH")).Text != "")
			{
				e.NewValues["RamadanWorkHrs"] = int.Parse(((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtRamadanWH")).Text);
			}
			e.NewValues["IsLocked"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsLocked")).Checked;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000193EC File Offset: 0x000175EC
		protected void GdvEmployeesList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["EmpCode"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCode")).Text;
			e.NewValues["EmpName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["Profession"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtProfession")).Text;
			e.NewValues["QID"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtQid")).Text;
			e.NewValues["PhoneNumber"] = ((ASPxSpinEdit)aspxGridView.FindEditFormTemplateControl("txtTel")).Text;
			if (((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtNormalWH")).Text != "")
			{
				e.NewValues["NormalWorkHrs"] = int.Parse(((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtNormalWH")).Text);
			}
			if (((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtRamadanWH")).Text != "")
			{
				e.NewValues["RamadanWorkHrs"] = int.Parse(((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtRamadanWH")).Text);
			}
			e.NewValues["IsLocked"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsLocked")).Checked;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00003BB6 File Offset: 0x00001DB6
		protected void GdvEmployeesList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvEmployeesList.JSProperties["cpFilter"] = this.GdvEmployeesList.FilterExpression;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00003BD8 File Offset: 0x00001DD8
		protected void GdvEmployeesList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00019584 File Offset: 0x00017784
		protected void GdvEmployeesList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x040004B0 RID: 1200
		protected HtmlGenericControl ultitle;

		// Token: 0x040004B1 RID: 1201
		protected ASPxLabel lblView;

		// Token: 0x040004B2 RID: 1202
		protected ASPxLabel lblEdite;

		// Token: 0x040004B3 RID: 1203
		protected ASPxLabel lblDelete;

		// Token: 0x040004B4 RID: 1204
		protected ASPxLabel lblAdd;

		// Token: 0x040004B5 RID: 1205
		protected ASPxButton btnAddNew;

		// Token: 0x040004B6 RID: 1206
		protected ASPxButton btnPrint;

		// Token: 0x040004B7 RID: 1207
		protected ASPxGridView GdvEmployeesList;

		// Token: 0x040004B8 RID: 1208
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040004B9 RID: 1209
		protected ObjectDataSource EmployeesListDS;
	}
}
