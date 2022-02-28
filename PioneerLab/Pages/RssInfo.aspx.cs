using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x0200001D RID: 29
	public class RssInfo : Page
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x000093E8 File Offset: 0x000075E8
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
			if (!base.IsPostBack)
			{
				this.Session["RSSDetails"] = null;
				this.Session["RSSDetList"] = null;
				long num = Convert.ToInt64(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				if (num != 0L)
				{
					this.SetEditMode(num);
					this.flRSSMaster.DataBind();
					this.cmbFKJobOrderMasterID.Value = new RSSMasterDB().GetByID(num).FKJobOrderMasterID;
					this.cmbFKJobOrderMasterID_SelectedIndexChanged(this.cmbFKJobOrderMasterID, new EventArgs());
					return;
				}
				RSSMasterDB rssmasterDB = new RSSMasterDB();
				this.txtRSSNumber.Text = rssmasterDB.GetNewSerial();
				object obj = this.Session["CurrentUser"];
				this.dtRSSDate.Value = DateTime.Today.Date;
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000095CC File Offset: 0x000077CC
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.gdvRSSTestList.UpdateEdit();
						this.RSSMasterDS.Update();
						base.Response.Redirect("RssManage.aspx");
					}
					else
					{
						this.BtnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = "You dont have permission to Update";
					}
				}
				else if (this.lblAdd.Text == "True")
				{
					this.gdvRSSTestList.UpdateEdit();
					this.RSSMasterDS.Insert();
					base.Response.Redirect("RssManage.aspx");
				}
				else
				{
					this.BtnSave.Enabled = false;
					this.divmsg.Attributes["class"] = "alert alert-info";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = "You dont have permission to Add";
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00009764 File Offset: 0x00007964
		private RSSMaster GetMasterEntity(int MasterID)
		{
			RSSMaster rssmaster;
			if (MasterID > 0)
			{
				rssmaster = new RSSMasterDB().GetByID((long)MasterID);
				rssmaster.RSSNumber = this.txtRSSNumber.Text;
			}
			else
			{
				rssmaster = new RSSMaster();
				rssmaster.RSSNumber = new RSSMasterDB().GetNewSerial();
			}
			rssmaster.RSSDate = (DateTime)this.dtRSSDate.Value;
			rssmaster.FKJobOrderMasterID = (long)Convert.ToInt32(this.cmbFKJobOrderMasterID.Value);
			rssmaster.ContactMobile = this.txtContactMobile.Text;
			rssmaster.ContactPersonAtSite = this.txtContactPersonAtSite.Text;
			rssmaster.FkEmpId = new int?(Convert.ToInt32(this.CmbTechnician.Value));
			rssmaster.Note = this.txtNote.Text;
			rssmaster.RequestBy = this.txtRequestBy.Text;
			rssmaster.RequestDate = (DateTime?)this.dtRequestDate.Value;
			rssmaster.RequestTestDate = (DateTime?)this.dtRequestTestDate.Value;
			rssmaster.SiteLocation = this.txtSiteLocation.Text;
			if (this.tdTestTime.Value != null)
			{
				DateTime today = DateTime.Today;
				DateTime dateTime = DateTime.Parse(this.tdTestTime.Value.ToString());
				DateTime value = new DateTime(today.Year, today.Month, today.Day, dateTime.Hour, dateTime.Minute, 0);
				rssmaster.TestTime = new DateTime?(value);
			}
			else
			{
				rssmaster.TestTime = null;
			}
			ADMUsers admusers = this.Session["CurrentUser"] as ADMUsers;
			rssmaster.ReportedBy = admusers.EName;
			List<object> selectedFieldValues = this.gdvRSSTestList.GetSelectedFieldValues(new string[]
			{
				"FkTestId"
			});
			List<RSSDetails> list = new List<RSSDetails>();
			foreach (object obj in selectedFieldValues)
			{
				list.Add(new RSSDetails
				{
					RSSDteailsId = (long)(list.Count + 1),
					FkTestId = new int?((int)obj)
				});
			}
			this.Session["RSSDetList"] = list;
			return rssmaster;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002B08 File Offset: 0x00000D08
		protected void RSSMasterDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00002B21 File Offset: 0x00000D21
		protected void RSSMasterDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000099B8 File Offset: 0x00007BB8
		protected void RSSMasterDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00002B5D File Offset: 0x00000D5D
		protected void RSSMasterDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00002B99 File Offset: 0x00000D99
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("RssManage.aspx");
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000099F0 File Offset: 0x00007BF0
		protected void cmbFKJobOrderMasterID_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Session["RSSDetails"] = null;
			long id = Convert.ToInt64(this.cmbFKJobOrderMasterID.Value);
			JobOrderMaster byID = new JobOrderMasterDB().GetByID(id);
			this.cmbFKProjectID.Value = byID.FKProjectID;
			int fkprojectID = byID.FKProjectID;
			if (fkprojectID > 0)
			{
				ProjectsList byID2 = new ProjectsListDB().GetByID(fkprojectID);
				this.txtProjectContractor.Text = byID2.ContractorsList.ContractorName;
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00002071 File Offset: 0x00000271
		protected void cmbFKProjectID_DataBound(object sender, EventArgs e)
		{
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00002071 File Offset: 0x00000271
		protected void gdvRSSTestList_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
		{
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00009A70 File Offset: 0x00007C70
		protected void gdvRSSTestList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox || e.ButtonType == ColumnCommandButtonType.Edit)
			{
				bool flag = Convert.ToBoolean(this.gdvRSSTestList.GetRowValues(e.VisibleIndex, new string[]
				{
					"IsEnabled"
				}));
				e.Enabled = flag;
				if (!flag)
				{
					this.gdvRSSTestList.CancelEdit();
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00002071 File Offset: 0x00000271
		protected void gdvRSSTestList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00009ACC File Offset: 0x00007CCC
		protected void gdvRSSTestList_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
		{
			Convert.ToInt64(e.CommandArgs.CommandArgument);
			RSSDetails item = (RSSDetails)this.gdvRSSTestList.GetRow(e.VisibleIndex);
			List<RSSDetails> list = (List<RSSDetails>)this.Session["InvoiceSelectedSession"];
			list.Insert(list.Count, item);
			this.Session["RSSDetailsSelectedSession"] = list;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00002071 File Offset: 0x00000271
		protected void gdvRSSTestList_SelectionChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00009B38 File Offset: 0x00007D38
		private void SetEditMode(long MasterID)
		{
			this.cmbFKJobOrderMasterID.ReadOnly = true;
			this.CmbTechnician.ReadOnly = true;
			this.gdvRSSTestList.Selection.UnselectAll();
			List<RSSDetails> byMaster = new RSSDetailsDB().GetByMaster(MasterID);
			List<long> list = (from x in byMaster
			select x.RSSDteailsId).ToList<long>();
			foreach (long num in list)
			{
				this.gdvRSSTestList.Selection.SelectRowByKey(num);
			}
		}

		// Token: 0x040000FE RID: 254
		protected HtmlGenericControl ultitle;

		// Token: 0x040000FF RID: 255
		protected ASPxLabel lblView;

		// Token: 0x04000100 RID: 256
		protected ASPxLabel lblEdite;

		// Token: 0x04000101 RID: 257
		protected ASPxLabel lblDelete;

		// Token: 0x04000102 RID: 258
		protected ASPxLabel lblAdd;

		// Token: 0x04000103 RID: 259
		protected ASPxButton BtnSave;

		// Token: 0x04000104 RID: 260
		protected ASPxButton BtnBack;

		// Token: 0x04000105 RID: 261
		protected HtmlGenericControl divmsg;

		// Token: 0x04000106 RID: 262
		protected ASPxLabel LblError;

		// Token: 0x04000107 RID: 263
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000108 RID: 264
		protected ASPxLabel lblMasterId;

		// Token: 0x04000109 RID: 265
		protected ASPxFormLayout flRSSMaster;

		// Token: 0x0400010A RID: 266
		protected ASPxTextBox txtRSSNumber;

		// Token: 0x0400010B RID: 267
		protected ASPxDateEdit dtRSSDate;

		// Token: 0x0400010C RID: 268
		protected ASPxComboBox cmbFKJobOrderMasterID;

		// Token: 0x0400010D RID: 269
		protected ASPxTextBox txtProjectContractor;

		// Token: 0x0400010E RID: 270
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x0400010F RID: 271
		protected ASPxTextBox txtContactPersonAtSite;

		// Token: 0x04000110 RID: 272
		protected ASPxDateEdit dtRequestDate;

		// Token: 0x04000111 RID: 273
		protected ASPxTextBox txtContactMobile;

		// Token: 0x04000112 RID: 274
		protected ASPxTextBox txtRequestBy;

		// Token: 0x04000113 RID: 275
		protected ASPxDateEdit dtRequestTestDate;

		// Token: 0x04000114 RID: 276
		protected ASPxTimeEdit tdTestTime;

		// Token: 0x04000115 RID: 277
		protected ASPxTextBox txtSiteLocation;

		// Token: 0x04000116 RID: 278
		protected ASPxComboBox CmbTechnician;

		// Token: 0x04000117 RID: 279
		protected ASPxTextBox txtNote;

		// Token: 0x04000118 RID: 280
		protected ASPxHiddenField hf;

		// Token: 0x04000119 RID: 281
		protected ASPxGridView gdvRSSTestList;

		// Token: 0x0400011A RID: 282
		protected ObjectDataSource RSSMasterDS;

		// Token: 0x0400011B RID: 283
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x0400011C RID: 284
		protected ObjectDataSource RSSTestListDS;

		// Token: 0x0400011D RID: 285
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x0400011E RID: 286
		protected ObjectDataSource EmpListDS;

		// Token: 0x0400011F RID: 287
		protected ObjectDataSource TestsListDS;
	}
}
