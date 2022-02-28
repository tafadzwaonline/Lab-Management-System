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
	// Token: 0x02000046 RID: 70
	public class MaterialGroups : Page
	{
		// Token: 0x060002D5 RID: 725 RVA: 0x000188F8 File Offset: 0x00016AF8
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/MaterialGroups.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002D6 RID: 726 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvMaterialsTypes_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00003AFE File Offset: 0x00001CFE
		protected void GdvMaterialTypesCustomFields_BeforePerformDataSelect(object sender, EventArgs e)
		{
			this.Session["FKMaterialTypeID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00018A60 File Offset: 0x00016C60
		protected void GdvMaterialTypesCustomFields_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["FKMaterialTypeID"] = Convert.ToInt32(aspxGridView.GetMasterRowKeyValue());
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00018A94 File Offset: 0x00016C94
		protected void GdvMaterialTypesCustomFields_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["FKMaterialTypeID"] = Convert.ToInt32(aspxGridView.GetMasterRowKeyValue());
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00018AC8 File Offset: 0x00016CC8
		protected void GdvMaterialsTypes_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060002DB RID: 731 RVA: 0x00018AC8 File Offset: 0x00016CC8
		protected void GdvMaterialTypesCustomFields_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x060002DC RID: 732 RVA: 0x00003B1B File Offset: 0x00001D1B
		protected void GdvMaterialsTypes_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvMaterialsTypes.JSProperties["cpFilter"] = this.GdvMaterialsTypes.FilterExpression;
		}

		// Token: 0x04000496 RID: 1174
		protected HtmlGenericControl ultitle;

		// Token: 0x04000497 RID: 1175
		protected ASPxLabel lblView;

		// Token: 0x04000498 RID: 1176
		protected ASPxLabel lblEdite;

		// Token: 0x04000499 RID: 1177
		protected ASPxLabel lblDelete;

		// Token: 0x0400049A RID: 1178
		protected ASPxLabel lblAdd;

		// Token: 0x0400049B RID: 1179
		protected ASPxButton btnAddNew;

		// Token: 0x0400049C RID: 1180
		protected ASPxButton btnPrint;

		// Token: 0x0400049D RID: 1181
		protected ASPxGridView GdvMaterialsTypes;

		// Token: 0x0400049E RID: 1182
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x0400049F RID: 1183
		protected ObjectDataSource MaterialsTypesDS;

		// Token: 0x040004A0 RID: 1184
		protected ObjectDataSource LabsListDS;

		// Token: 0x040004A1 RID: 1185
		protected ObjectDataSource MaterialTypesCustomFieldsDS;

		// Token: 0x040004A2 RID: 1186
		protected ObjectDataSource MaterialTypesCustomTableFieldsDS;
	}
}
