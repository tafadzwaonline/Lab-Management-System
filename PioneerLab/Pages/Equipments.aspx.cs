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
	// Token: 0x0200003D RID: 61
	public class Equipments : Page
	{
		// Token: 0x06000266 RID: 614 RVA: 0x00015AB4 File Offset: 0x00013CB4
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/Equipments.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x06000267 RID: 615 RVA: 0x00015C1C File Offset: 0x00013E1C
		protected void GdvEquipmentsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
			if (e.Exception.InnerException.Message == "Expiry date should be later date than Calibration")
			{
				e.ErrorText = "Expiry date should be later date than Calibration";
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00015CA4 File Offset: 0x00013EA4
		protected void GdvEquipmentsList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["EquipmentName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["FKLabID"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbFKLabID")).Value;
			e.NewValues["CalibrationDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtCalibrationDate")).Value;
			e.NewValues["ExpiryDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtExpiryDate")).Value;
			e.NewValues["FKEmpID"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbFKEmpID")).Value;
			e.NewValues["CalibratedBy"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCalibratedBy")).Text;
			e.NewValues["Remarks"] = ((ASPxMemo)aspxGridView.FindEditFormTemplateControl("txtRemarks")).Text;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00015DBC File Offset: 0x00013FBC
		protected void GdvEquipmentsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["EquipmentName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["FKLabID"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbFKLabID")).Value;
			e.NewValues["CalibrationDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtCalibrationDate")).Value;
			e.NewValues["ExpiryDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtExpiryDate")).Value;
			e.NewValues["FKEmpID"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbFKEmpID")).Value;
			e.NewValues["CalibratedBy"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCalibratedBy")).Text;
			e.NewValues["Remarks"] = ((ASPxMemo)aspxGridView.FindEditFormTemplateControl("txtRemarks")).Text;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x000035D3 File Offset: 0x000017D3
		protected void GdvEquipmentsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvEquipmentsList.JSProperties["cpFilter"] = this.GdvEquipmentsList.FilterExpression;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00015ED4 File Offset: 0x000140D4
		protected void GdvEquipmentsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x0600026C RID: 620 RVA: 0x000035F5 File Offset: 0x000017F5
		protected void GdvEquipmentsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x040003D5 RID: 981
		protected HtmlGenericControl ultitle;

		// Token: 0x040003D6 RID: 982
		protected ASPxLabel lblView;

		// Token: 0x040003D7 RID: 983
		protected ASPxLabel lblEdite;

		// Token: 0x040003D8 RID: 984
		protected ASPxLabel lblDelete;

		// Token: 0x040003D9 RID: 985
		protected ASPxLabel lblAdd;

		// Token: 0x040003DA RID: 986
		protected ASPxButton btnAddNew;

		// Token: 0x040003DB RID: 987
		protected ASPxButton btnPrint;

		// Token: 0x040003DC RID: 988
		protected ASPxGridView GdvEquipmentsList;

		// Token: 0x040003DD RID: 989
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040003DE RID: 990
		protected ObjectDataSource EquipmentsListDS;

		// Token: 0x040003DF RID: 991
		protected ObjectDataSource LabsListDS;

		// Token: 0x040003E0 RID: 992
		protected ObjectDataSource EmployeesListDS;
	}
}
