using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Pages;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x0200004C RID: 76
	public class TestPage : Page
	{
		// Token: 0x06000302 RID: 770 RVA: 0x00002071 File Offset: 0x00000271
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00019C34 File Offset: 0x00017E34
		protected void GdvAccreditionList_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
			string resourceKey = "";
			AccreditionListDB accreditionListDB = new AccreditionListDB();
			AccreditionList byID = accreditionListDB.GetByID(Convert.ToInt32(e.Keys[this.GdvAccreditionList.KeyFieldName]));
			if (accreditionListDB.Delete(byID, out resourceKey))
			{
				this.GdvAccreditionList.DataBind();
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
			string value = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
			((ASPxGridView)sender).JSProperties["cpDeleteError"] = value;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00019CD8 File Offset: 0x00017ED8
		protected void GdvAccreditionList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			AccreditionListDB accreditionListDB = new AccreditionListDB();
			string resourceKey = "";
			if (accreditionListDB.Update(new AccreditionList
			{
				AccreditionID = Convert.ToInt32(e.Keys[this.GdvAccreditionList.KeyFieldName]),
				AccreditionName = e.NewValues["AccreditionName"].ToString()
			}, out resourceKey))
			{
				this.GdvAccreditionList.CancelEdit();
				this.GdvAccreditionList.DataBind();
				this.GdvAccreditionList.SettingsText.PopupEditFormCaption = base.GetGlobalResourceObject("GlobalResource", "EditFormNew").ToString();
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
			string message = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
			throw new Exception("SaveError", new Exception(message));
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00019DC4 File Offset: 0x00017FC4
		protected void GdvAccreditionList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			string resourceKey = "";
			AccreditionList accreditionList = new AccreditionList();
			AccreditionListDB accreditionListDB = new AccreditionListDB();
			accreditionList.AccreditionName = e.NewValues["AccreditionName"].ToString();
			if (accreditionListDB.Insert(accreditionList, out resourceKey))
			{
				this.GdvAccreditionList.CancelEdit();
				this.GdvAccreditionList.DataBind();
				this.GdvAccreditionList.SettingsText.PopupEditFormCaption = base.GetGlobalResourceObject("GlobalResource", "EditFormNew").ToString();
				e.Cancel = true;
				return;
			}
			e.Cancel = true;
			string message = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
			throw new Exception("SaveError", new Exception(message));
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000047A0 File Offset: 0x000029A0
		protected void GdvAccreditionList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = e.Exception.InnerException.Message;
				return;
			}
			e.ErrorText = base.GetGlobalResourceObject("GLobalMessages", "GeneralError").ToString();
		}

		// Token: 0x040004D5 RID: 1237
		protected HtmlGenericControl ultitle;

		// Token: 0x040004D6 RID: 1238
		protected ASPxButton btnAddNew;

		// Token: 0x040004D7 RID: 1239
		protected ASPxGridView GdvAccreditionList;

		// Token: 0x040004D8 RID: 1240
		protected ObjectDataSource AccreditionListDS;
	}
}
