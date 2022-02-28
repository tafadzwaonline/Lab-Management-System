using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x02000047 RID: 71
	public class ValidityDetails : Page
	{
		// Token: 0x060002DE RID: 734 RVA: 0x00018B4C File Offset: 0x00016D4C
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ValidityDetails.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002DF RID: 735 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvValidityList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00003B3D File Offset: 0x00001D3D
		protected void GdvValidityListDetails_BeforePerformDataSelect(object sender, EventArgs e)
		{
			this.Session["FKValidityID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00018CB4 File Offset: 0x00016EB4
		protected void GdvValidityListDetails_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["FKValidityID"] = Convert.ToInt32(aspxGridView.GetMasterRowKeyValue());
			e.NewValues["CertificateName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCertificateName")).Text;
			e.NewValues["CertificateSerialNumber"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCertificateSerialNumber")).Text;
			e.NewValues["IDNumber"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtIDNumber")).Text;
			e.NewValues["EnteredBy"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtEnteredBy")).Text;
			e.NewValues["EntryDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtEntryDate")).Value;
			e.NewValues["ExpiryDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtExpiryDate")).Value;
			e.NewValues["Responsible"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbResponsible")).Value;
			e.NewValues["Remarks"] = ((ASPxMemo)aspxGridView.FindEditFormTemplateControl("txtRemarks")).Text;
			e.NewValues["CalibratedBy"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCalibratedBy")).Text;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00018E38 File Offset: 0x00017038
		protected void GdvValidityListDetails_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["FKValidityID"] = Convert.ToInt32(aspxGridView.GetMasterRowKeyValue());
			e.NewValues["CertificateName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCertificateName")).Text;
			e.NewValues["CertificateSerialNumber"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCertificateSerialNumber")).Text;
			e.NewValues["IDNumber"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtIDNumber")).Text;
			e.NewValues["EnteredBy"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtEnteredBy")).Text;
			e.NewValues["EntryDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtEntryDate")).Value;
			e.NewValues["ExpiryDate"] = ((ASPxDateEdit)aspxGridView.FindEditFormTemplateControl("dtExpiryDate")).Value;
			e.NewValues["Responsible"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbResponsible")).Value;
			e.NewValues["Remarks"] = ((ASPxMemo)aspxGridView.FindEditFormTemplateControl("txtRemarks")).Text;
			e.NewValues["CalibratedBy"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtCalibratedBy")).Text;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00018FBC File Offset: 0x000171BC
		protected void GdvValidityListDetails_InitNewRow(object sender, ASPxDataInitNewRowEventArgs e)
		{
			ADMUsers admusers = this.Session["CurrentUser"] as ADMUsers;
			e.NewValues["EnteredBy"] = admusers.EName;
			e.NewValues["EntryDate"] = DateTime.Now;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00019010 File Offset: 0x00017210
		protected void GdvValidityList_InitNewRow(object sender, ASPxDataInitNewRowEventArgs e)
		{
			ValidityListDB validityListDB = new ValidityListDB();
			e.NewValues["ValidityCode"] = validityListDB.GetNewSerial();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0001903C File Offset: 0x0001723C
		protected void GdvValidityListDetails_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "Expiry date must not be  earlier than Entry date")
			{
				e.ErrorText = "Expiry date must not be  earlier than Entry date";
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00003B5A File Offset: 0x00001D5A
		protected void GdvValidityList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvValidityList.JSProperties["cpFilter"] = this.GdvValidityList.FilterExpression;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00019090 File Offset: 0x00017290
		protected void GdvValidityList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060002E8 RID: 744 RVA: 0x00003B7C File Offset: 0x00001D7C
		protected void GdvValidityList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.ButtonID == "btnprintR")
			{
				if (this.lblView.Text == "false")
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00019090 File Offset: 0x00017290
		protected void GdvValidityListDetails_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x040004A3 RID: 1187
		protected HtmlGenericControl ultitle;

		// Token: 0x040004A4 RID: 1188
		protected ASPxLabel lblView;

		// Token: 0x040004A5 RID: 1189
		protected ASPxLabel lblEdite;

		// Token: 0x040004A6 RID: 1190
		protected ASPxLabel lblDelete;

		// Token: 0x040004A7 RID: 1191
		protected ASPxLabel lblAdd;

		// Token: 0x040004A8 RID: 1192
		protected ASPxButton btnAddNew;

		// Token: 0x040004A9 RID: 1193
		protected ASPxButton btnPrint;

		// Token: 0x040004AA RID: 1194
		protected ASPxGridView GdvValidityList;

		// Token: 0x040004AB RID: 1195
		protected GridViewCommandColumnCustomButton btnprintR;

		// Token: 0x040004AC RID: 1196
		protected ObjectDataSource EmployeesListDS;

		// Token: 0x040004AD RID: 1197
		protected ObjectDataSource ValidityListDS;

		// Token: 0x040004AE RID: 1198
		protected ObjectDataSource LabsListDS;

		// Token: 0x040004AF RID: 1199
		protected ObjectDataSource ValidityListDetailsDS;
	}
}
