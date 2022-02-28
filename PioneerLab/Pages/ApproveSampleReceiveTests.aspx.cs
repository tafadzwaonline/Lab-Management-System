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
	// Token: 0x02000019 RID: 25
	public class ApproveSampleReceiveTests : Page
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00002071 File Offset: 0x00000271
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvSampleReceiveTests_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvActiveSampleReceiveTests_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00008464 File Offset: 0x00006664
		protected void GdvActiveWorkOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "You can not delete this WorkOrder becouse it have Time Sheet ")
			{
				e.ErrorText = "You can not delete this WorkOrder becouse it have Time Sheet ";
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00002071 File Offset: 0x00000271
		protected void BtnBack_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00002A10 File Offset: 0x00000C10
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			this.GdvPendingCheckedSampleReceiveTests.UpdateEdit();
			this.GdvPendingApproveSampleReceiveTests.UpdateEdit();
			this.GdvPendingApproveSampleReceiveTests.DataBind();
			this.GdvSampleReceiveTests.DataBind();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000084B8 File Offset: 0x000066B8
		protected void GdvPendingCheckedSampleReceiveTests_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Check Sample Receive Tests" && admuserSettings.SettingsValue == "True")
				{
					if (e.Column.FieldName == "IsChecked")
					{
						e.Editor.ReadOnly = false;
					}
				}
				else if (admuserSettings.SettingsName == "Check Sample Receive Tests" && admuserSettings.SettingsValue != "True" && e.Column.FieldName == "IsChecked")
				{
					e.Editor.ReadOnly = true;
				}
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000085BC File Offset: 0x000067BC
		protected void GdvPendingApproveSampleReceiveTests_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Approve Sample Receive Tests" && admuserSettings.SettingsValue == "True")
				{
					if (e.Column.FieldName == "IsApproved")
					{
						e.Editor.ReadOnly = false;
					}
				}
				else if (admuserSettings.SettingsName == "Approve Sample Receive Tests" && admuserSettings.SettingsValue != "True" && e.Column.FieldName == "IsApproved")
				{
					e.Editor.ReadOnly = true;
				}
			}
		}

		// Token: 0x040000C6 RID: 198
		protected HtmlGenericControl ultitle;

		// Token: 0x040000C7 RID: 199
		protected ASPxLabel lblView;

		// Token: 0x040000C8 RID: 200
		protected ASPxLabel lblEdite;

		// Token: 0x040000C9 RID: 201
		protected ASPxLabel lblDelete;

		// Token: 0x040000CA RID: 202
		protected ASPxLabel lblAdd;

		// Token: 0x040000CB RID: 203
		protected ASPxButton BtnSave;

		// Token: 0x040000CC RID: 204
		protected ASPxButton BtnBack;

		// Token: 0x040000CD RID: 205
		protected ASPxGridView GdvPendingCheckedSampleReceiveTests;

		// Token: 0x040000CE RID: 206
		protected ASPxGridView GdvPendingApproveSampleReceiveTests;

		// Token: 0x040000CF RID: 207
		protected ASPxGridView GdvSampleReceiveTests;

		// Token: 0x040000D0 RID: 208
		protected ObjectDataSource PendingCheckedSampleReceiveTestsDS;

		// Token: 0x040000D1 RID: 209
		protected ObjectDataSource PendingApprovedSampleReceiveTestsDS;

		// Token: 0x040000D2 RID: 210
		protected ObjectDataSource CheckedApprovedSampleReceiveTestsDS;

		// Token: 0x040000D3 RID: 211
		protected ObjectDataSource JobOrderDS;

		// Token: 0x040000D4 RID: 212
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040000D5 RID: 213
		protected ObjectDataSource ApprovedJobOrderMasterDS;

		// Token: 0x040000D6 RID: 214
		protected ObjectDataSource ExpiredJobOrderMasterDS;

		// Token: 0x040000D7 RID: 215
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x040000D8 RID: 216
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x040000D9 RID: 217
		protected ObjectDataSource TestsListDS;

		// Token: 0x040000DA RID: 218
		protected ObjectDataSource PriceUnitListDS;
	}
}
