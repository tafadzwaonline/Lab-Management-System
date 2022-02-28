using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Admin
{
	// Token: 0x02000004 RID: 4
	public class LinksManage : Page
	{
		// Token: 0x06000008 RID: 8 RVA: 0x0000207B File Offset: 0x0000027B
		protected void Page_Load(object sender, EventArgs e)
		{
			this.GdvCategoryMaster.JSProperties["cpDeleteError"] = "";
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002097 File Offset: 0x00000297
		protected void BtnAddNew_Click(object sender, EventArgs e)
		{
			this.GdvCategoryMaster.AddNewRow();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020A4 File Offset: 0x000002A4
		protected void GdvCategoryMaster_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			e.NewValues["FKModuleId"] = this.CmbFlowModules.Value;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020C1 File Offset: 0x000002C1
		protected void GdvCategoryMaster_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			e.NewValues["FKModuleId"] = this.CmbFlowModules.Value;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000047A0 File Offset: 0x000029A0
		protected void GdvCategoryMaster_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = e.Exception.InnerException.Message;
				return;
			}
			e.ErrorText = base.GetGlobalResourceObject("GLobalMessages", "GeneralError").ToString();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020DE File Offset: 0x000002DE
		protected void GdvLinkCategory_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			e.NewValues["FKCategoryMasterID"] = this.Session["FkMasterID"];
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002100 File Offset: 0x00000300
		protected void GdvLinkCategory_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			e.NewValues["FKCategoryMasterID"] = this.Session["FkMasterID"];
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002122 File Offset: 0x00000322
		protected void GdvLinkCategory_BeforePerformDataSelect(object sender, EventArgs e)
		{
			this.Session["FkMasterID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000047A0 File Offset: 0x000029A0
		protected void GdvLinkCategory_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = e.Exception.InnerException.Message;
				return;
			}
			e.ErrorText = base.GetGlobalResourceObject("GLobalMessages", "GeneralError").ToString();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000213F File Offset: 0x0000033F
		protected void GdvLinks_BeforePerformDataSelect(object sender, EventArgs e)
		{
			this.Session["FkCategoryID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000047F4 File Offset: 0x000029F4
		protected ADMLinks GetDetailsEditFormValues(ASPxGridView gdv, int key)
		{
			return new ADMLinks
			{
				LinksID = key,
				FKModuleID = Convert.ToInt32(this.CmbFlowModules.Value),
				FKLinkCategoryID = Convert.ToInt32(gdv.GetMasterRowKeyValue()),
				LinksEName = ((ASPxTextBox)gdv.FindEditFormTemplateControl("TxtNameEn")).Text,
				LinksAName = ((ASPxTextBox)gdv.FindEditFormTemplateControl("TxtNameAr")).Text,
				Url = ((ASPxTextBox)gdv.FindEditFormTemplateControl("TxtUrl")).Text,
				Notes = ((ASPxTextBox)gdv.FindEditFormTemplateControl("TxtNotes")).Text,
				MenuLink = ((ASPxCheckBox)gdv.FindEditFormTemplateControl("IsMenuLink")).Checked,
				ActiveLink = ((ASPxCheckBox)gdv.FindEditFormTemplateControl("IsActiveLink")).Checked,
				OrderNo = (int?)((ASPxSpinEdit)gdv.FindEditFormTemplateControl("OrderNo")).Value
			};
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000048F8 File Offset: 0x00002AF8
		protected void GdvLinks_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["LinksEName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNameEn")).Text;
			e.NewValues["FKModuleID"] = Convert.ToInt32(this.CmbFlowModules.Value);
			e.NewValues["FKLinkCategoryID"] = Convert.ToInt32(aspxGridView.GetMasterRowKeyValue());
			e.NewValues["LinksEName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNameEn")).Text;
			e.NewValues["LinksAName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNameAr")).Text;
			e.NewValues["Url"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtUrl")).Text;
			e.NewValues["Notes"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNotes")).Text;
			e.NewValues["LinkIcon"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtIcon")).Text;
			e.NewValues["MenuLink"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsMenuLink")).Checked;
			e.NewValues["ActiveLink"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsActiveLink")).Checked;
			e.NewValues["OrderNo"] = Convert.ToInt32(((ASPxSpinEdit)aspxGridView.FindEditFormTemplateControl("OrderNo")).Value);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00004AB4 File Offset: 0x00002CB4
		protected void GdvLinks_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["LinksEName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNameEn")).Text;
			e.NewValues["FKModuleID"] = Convert.ToInt32(this.CmbFlowModules.Value);
			e.NewValues["FKLinkCategoryID"] = Convert.ToInt32(aspxGridView.GetMasterRowKeyValue());
			e.NewValues["LinksEName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNameEn")).Text;
			e.NewValues["LinksAName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNameAr")).Text;
			e.NewValues["Url"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtUrl")).Text;
			e.NewValues["Notes"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtNotes")).Text;
			e.NewValues["LinkIcon"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("TxtIcon")).Text;
			e.NewValues["MenuLink"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsMenuLink")).Checked;
			e.NewValues["ActiveLink"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsActiveLink")).Checked;
			e.NewValues["OrderNo"] = Convert.ToInt32(((ASPxSpinEdit)aspxGridView.FindEditFormTemplateControl("OrderNo")).Value);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvLinks_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvLinks_RowValidating(object sender, ASPxDataValidationEventArgs e)
		{
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000215C File Offset: 0x0000035C
		private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
		{
			if (errors.ContainsKey(column))
			{
				return;
			}
			errors[column] = errorText;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000047A0 File Offset: 0x000029A0
		protected void GdvLinks_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = e.Exception.InnerException.Message;
				return;
			}
			e.ErrorText = base.GetGlobalResourceObject("GLobalMessages", "GeneralError").ToString();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004C70 File Offset: 0x00002E70
		protected void BtnSaveEditForm1_Click(object sender, EventArgs e)
		{
			LinksDB linksDB = new LinksDB();
			Control namingContainer = ((sender as ASPxButton).NamingContainer as ASPxFormLayout).NamingContainer.NamingContainer.NamingContainer.NamingContainer;
			ASPxComboBox aspxComboBox = ((sender as ASPxButton).NamingContainer as ASPxFormLayout).FindControl("CmbModules") as ASPxComboBox;
			((sender as ASPxButton).NamingContainer as ASPxFormLayout).FindControl("cmbCategoryMaster");
			ASPxComboBox aspxComboBox2 = ((sender as ASPxButton).NamingContainer as ASPxFormLayout).FindControl("cmbLinkCategory") as ASPxComboBox;
			ASPxLabel aspxLabel = ((sender as ASPxButton).NamingContainer as ASPxFormLayout).FindControl("msg") as ASPxLabel;
			int linkId = Convert.ToInt32((sender as ASPxButton).CommandArgument);
			int fkmoduleID = Convert.ToInt32(aspxComboBox.Value);
			int fklinkCategoryID = Convert.ToInt32(aspxComboBox2.Value);
			bool isMove = (sender as ASPxButton).CommandName == "Move";
			string text = linksDB.CopyLink(linkId, fklinkCategoryID, fkmoduleID, isMove);
			aspxLabel.Text = text;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002071 File Offset: 0x00000271
		protected void cmbCategoryMaster_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002071 File Offset: 0x00000271
		protected void cmbLinkCategory_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004D80 File Offset: 0x00002F80
		protected void cmbCategoryMaster_SelectedIndexChanged(object sender, EventArgs e)
		{
			ASPxComboBox aspxComboBox = sender as ASPxComboBox;
			ASPxComboBox aspxComboBox2 = ((sender as ASPxComboBox).NamingContainer as ASPxFormLayout).FindControl("cmbLinkCategory") as ASPxComboBox;
			aspxComboBox2.DataSource = new LinksCategoryDB().GetByCategoryMasterId(Convert.ToInt32(aspxComboBox.Value));
			aspxComboBox2.DataBind();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00004DD8 File Offset: 0x00002FD8
		protected void CmbModules_SelectedIndexChanged(object sender, EventArgs e)
		{
			ASPxComboBox aspxComboBox = sender as ASPxComboBox;
			ASPxComboBox aspxComboBox2 = ((sender as ASPxComboBox).NamingContainer as ASPxFormLayout).FindControl("cmbCategoryMaster") as ASPxComboBox;
			aspxComboBox2.DataSource = new CategoryMasterDB().GetByFKModuleID(Convert.ToInt32(aspxComboBox.Value));
			aspxComboBox2.DataBind();
		}

		// Token: 0x04000002 RID: 2
		protected HtmlGenericControl ultitle;

		// Token: 0x04000003 RID: 3
		protected ASPxButton Button1;

		// Token: 0x04000004 RID: 4
		protected ASPxLabel lblCompanyId;

		// Token: 0x04000005 RID: 5
		protected ASPxLabel LblError;

		// Token: 0x04000006 RID: 6
		protected ASPxLabel lblFlowModules;

		// Token: 0x04000007 RID: 7
		protected ASPxComboBox CmbFlowModules;

		// Token: 0x04000008 RID: 8
		protected ASPxGridView GdvCategoryMaster;

		// Token: 0x04000009 RID: 9
		protected ObjectDataSource RolesDS;

		// Token: 0x0400000A RID: 10
		protected ObjectDataSource ModulesDS;

		// Token: 0x0400000B RID: 11
		protected ObjectDataSource CategoryMasterDS;

		// Token: 0x0400000C RID: 12
		protected ObjectDataSource LinkCategoryDS;

		// Token: 0x0400000D RID: 13
		protected ObjectDataSource LinksDS;
	}
}
