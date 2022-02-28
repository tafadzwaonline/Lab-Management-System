using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x0200001F RID: 31
	public class WorkOrderData : Page
	{
		// Token: 0x0600010D RID: 269 RVA: 0x00009E18 File Offset: 0x00008018
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/WorkOrderTimeSheetManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
			int num = Convert.ToInt32(base.Request["id"]);
			this.WOid.Text = num.ToString();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00002BE1 File Offset: 0x00000DE1
		protected void GdvActiveWorkOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("TimeSheet.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00008464 File Offset: 0x00006664
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

		// Token: 0x06000111 RID: 273 RVA: 0x00009F40 File Offset: 0x00008140
		protected void GdvActiveWorkOrder_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x06000112 RID: 274 RVA: 0x00009F9C File Offset: 0x0000819C
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.WOid.Text);
				if (num > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.WorkOrderDS.Update();
					}
					else
					{
						this.BtnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = "You dont have permission to Update";
					}
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
				if (ex.InnerException != null)
				{
					this.LblError.Text = ex.InnerException.Message;
				}
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00002BFD File Offset: 0x00000DFD
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("WorkOrderDataManage.aspx");
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000A098 File Offset: 0x00008298
		protected void WorkOrderDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			long workOrderId = Convert.ToInt64(this.WOid.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(workOrderId);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00002C0F File Offset: 0x00000E0F
		protected void WorkOrderDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000A0D0 File Offset: 0x000082D0
		private WorkOrderList GetMasterEntity(long WorkOrderId)
		{
			if (WorkOrderId > 0L)
			{
				WorkOrderList byID = new WorkOrderListDB().GetByID(WorkOrderId);
				byID.FKJobOrderDetailsID = byID.FKJobOrderDetailsID;
				byID.StartDate = (DateTime?)this.dtStartDate.Value;
				byID.EndDate = (DateTime?)this.dtEndDate.Value;
				byID.SiteName = this.txtSiteName.Text;
				byID.ShiftStatus = (int?)this.cmbShiftStatus.Value;
				byID.RegularWorkHrs = (decimal?)this.txtRegularWorkHrs.Value;
				byID.RamadanWorkHrs = (decimal?)this.txtRamadanWorkHrs.Value;
				byID.MonthlyRate = (decimal?)this.txtMonthlyRate.Value;
				byID.UnitOfAddition = this.txtUnitOfAddition.Text;
				byID.ExtraWorkHourRate = (decimal?)this.txtExtraWorkHourRate.Value;
				byID.NightShiftPerc = (decimal?)this.txtNightShiftPerc.Value;
				byID.Description = this.txtDescription.Text;
				byID.FKJobOrderMasterID = byID.FKJobOrderMasterID;
				return byID;
			}
			return null;
		}

		// Token: 0x0400012C RID: 300
		protected HtmlGenericControl ultitle;

		// Token: 0x0400012D RID: 301
		protected ASPxLabel lblView;

		// Token: 0x0400012E RID: 302
		protected ASPxLabel lblEdite;

		// Token: 0x0400012F RID: 303
		protected ASPxLabel lblDelete;

		// Token: 0x04000130 RID: 304
		protected ASPxLabel lblAdd;

		// Token: 0x04000131 RID: 305
		protected ASPxButton BtnSave;

		// Token: 0x04000132 RID: 306
		protected ASPxButton BtnBack;

		// Token: 0x04000133 RID: 307
		protected HtmlGenericControl divmsg;

		// Token: 0x04000134 RID: 308
		protected ASPxLabel LblError;

		// Token: 0x04000135 RID: 309
		protected ASPxTextBox WOid;

		// Token: 0x04000136 RID: 310
		protected ASPxFormLayout flWorkOrder;

		// Token: 0x04000137 RID: 311
		protected ASPxTextBox txtWorkOrderNo;

		// Token: 0x04000138 RID: 312
		protected ASPxDateEdit dtTransDate;

		// Token: 0x04000139 RID: 313
		protected ASPxDateEdit dtStartDate;

		// Token: 0x0400013A RID: 314
		protected ASPxDateEdit dtEndDate;

		// Token: 0x0400013B RID: 315
		protected ASPxTextBox txtSiteName;

		// Token: 0x0400013C RID: 316
		protected ASPxComboBox cmbShiftStatus;

		// Token: 0x0400013D RID: 317
		protected ASPxSpinEdit txtRegularWorkHrs;

		// Token: 0x0400013E RID: 318
		protected ASPxSpinEdit txtRamadanWorkHrs;

		// Token: 0x0400013F RID: 319
		protected ASPxSpinEdit txtMonthlyRate;

		// Token: 0x04000140 RID: 320
		protected ASPxTextBox txtUnitOfAddition;

		// Token: 0x04000141 RID: 321
		protected ASPxSpinEdit txtExtraWorkHourRate;

		// Token: 0x04000142 RID: 322
		protected ASPxSpinEdit txtNightShiftPerc;

		// Token: 0x04000143 RID: 323
		protected ASPxTextBox txtDescription;

		// Token: 0x04000144 RID: 324
		protected ASPxLabel lblErrorMessage;

		// Token: 0x04000145 RID: 325
		protected ObjectDataSource WorkOrderDS;
	}
}
