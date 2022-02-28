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
	// Token: 0x0200002A RID: 42
	public class TimeSheet : Page
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000CF40 File Offset: 0x0000B140
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Session["WorkOrderTimeSheetList"] = null;
				this.Session["Bind"] = null;
				this.Session["FkWorkOrderID"] = null;
				int num = Convert.ToInt32(base.Request["id"]);
				if (num > 0)
				{
					this.Session["FkWorkOrderID"] = num;
					if (base.Request["mode"] != null && base.Request["mode"] == "Check")
					{
						this.lblMode.Text = base.Request["mode"].ToString();
						this.SelectAll.Visible = true;
						this.btnApplay.Visible = false;
						this.btnInvoice.Visible = false;
						this.tbApplay.Visible = false;
					}
					else if (base.Request["mode"] != null && base.Request["mode"] == "View")
					{
						this.lblMode.Text = base.Request["mode"].ToString();
					}
					else if (base.Request["mode"] != null && base.Request["mode"] == "Approve")
					{
						this.lblMode.Text = base.Request["mode"].ToString();
						this.SelectAll.Visible = true;
						this.btnApplay.Visible = false;
						this.btnInvoice.Visible = false;
						this.tbApplay.Visible = false;
					}
					this.lblMasterId.Text = num.ToString();
					WorkOrderList byID = new WorkOrderListDB().GetByID((long)num);
					this.cmbJobOrder.Value = byID.FKJobOrderDetailsID;
					this.cmbWorkOrder.Value = byID.WorkOrderID;
					this.dtFromdate.Value = byID.StartDate;
					this.dtTodate.Value = byID.EndDate;
				}
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrderWorkSheet_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvJobOrderWorkSheet_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000D188 File Offset: 0x0000B388
		protected void BindGrid()
		{
			WorkOrderTimeSheetDB workOrderTimeSheetDB = new WorkOrderTimeSheetDB();
			long num = Convert.ToInt64(this.cmbWorkOrder.Value);
			this.Session["FkWorkOrderID"] = num;
			long num2 = new WorkOrderTimeSheetDB().GetLastID(num).Value;
			List<WorkOrderTimeSheet> list = new List<WorkOrderTimeSheet>();
			DateTime date = this.dtFromdate.Date;
			DateTime date2 = this.dtTodate.Date;
			DateTime dateTime = date;
			while (dateTime <= date2)
			{
				WorkOrderTimeSheet byWorkOrderByDate = workOrderTimeSheetDB.GetByWorkOrderByDate(dateTime, num);
				if (byWorkOrderByDate == null)
				{
					WorkOrderTimeSheet workOrderTimeSheet = new WorkOrderTimeSheet();
					workOrderTimeSheet.WorkOrderTimeSheetId = num2 + 1L;
					num2 += 1L;
					workOrderTimeSheet.FkWorkOrderID = num;
					workOrderTimeSheet.StartDate = new DateTime?(dateTime);
					workOrderTimeSheet.EndDate = new DateTime?(dateTime);
					workOrderTimeSheet.Day = dateTime.DayOfWeek.ToString();
					workOrderTimeSheet.Breake = new decimal?(0m);
					workOrderTimeSheet.EndTime = null;
					workOrderTimeSheet.FkEmpID = null;
					workOrderTimeSheet.InvoiceNumber = "";
					workOrderTimeSheet.IsInvoiced = new bool?(false);
					workOrderTimeSheet.IsRamadan = new bool?(false);
					workOrderTimeSheet.Remarks = null;
					workOrderTimeSheet.StartTime = null;
					workOrderTimeSheet.WorkHrs = new decimal?(0m);
					workOrderTimeSheet.WorkStatus = null;
					workOrderTimeSheet.ShiftStatus = null;
					list.Add(workOrderTimeSheet);
				}
				else
				{
					list.Add(byWorkOrderByDate);
				}
				dateTime = dateTime.AddDays(1.0);
			}
			this.Session["WorkOrderTimeSheetList"] = list;
			this.GdvJobOrderWorkSheet.DataBind();
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00002F28 File Offset: 0x00001128
		private void ClearGrid()
		{
			this.Session["WorkOrderTimeSheetList"] = null;
			this.GdvJobOrderWorkSheet.DataBind();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000D354 File Offset: 0x0000B554
		protected void cmbWorkOrder_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ClearGrid();
			WorkOrderListDB workOrderListDB = new WorkOrderListDB();
			WorkOrderList byID = workOrderListDB.GetByID(long.Parse(this.cmbWorkOrder.Value.ToString()));
			this.dtFromdate.Date = byID.StartDate.Value;
			this.dtTodate.Date = byID.EndDate.Value;
			this.lblMasterId.Text = byID.WorkOrderID.ToString();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			if (base.Request["mode"] != null && (base.Request["mode"] == "Check" || base.Request["mode"] == "Approve" || base.Request["mode"] == "Edit" || base.Request["mode"] == "View"))
			{
				base.Response.Redirect("WorkOrderTimeSheetManage.aspx");
				return;
			}
			base.Response.Redirect("WorkOrderManage.aspx");
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000D48C File Offset: 0x0000B68C
		protected void btnApprove_Click(object sender, EventArgs e)
		{
			this.GdvJobOrderWorkSheet.UpdateEdit();
			if (base.Request["mode"] != null && base.Request["mode"] == "Check")
			{
				new WorkOrderListDB().GetByID((long)Convert.ToInt32(base.Request["id"]));
				this.divmsg.Attributes["class"] = "alert alert-success";
				this.LblError.ForeColor = Color.Green;
				this.LblError.Text = "Data has been Updated successfully!";
				return;
			}
			if (base.Request["mode"] != null && base.Request["mode"] == "Approve")
			{
				WorkOrderList byID = new WorkOrderListDB().GetByID((long)Convert.ToInt32(base.Request["id"]));
				if (new WorkOrderListDB().Update(byID))
				{
					this.divmsg.Attributes["class"] = "alert alert-success";
					this.LblError.ForeColor = Color.Green;
					this.LblError.Text = "Data has been Updated successfully!";
					this.GeneratePayslip();
				}
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000D5D0 File Offset: 0x0000B7D0
		public void GeneratePayslip()
		{
			WorkOrderList byID = new WorkOrderListDB().GetByID(Convert.ToInt64(this.cmbWorkOrder.Value));
			List<WorkOrderTimeSheet> byWorkOrderID = new WorkOrderTimeSheetDB().GetByWorkOrderID(byID.WorkOrderID);
			int num = 0;
			decimal? num2 = new decimal?(0m);
			decimal? num3 = new decimal?(0m);
			decimal? num4 = new decimal?(0m);
			foreach (WorkOrderTimeSheet workOrderTimeSheet in byWorkOrderID)
			{
				if (workOrderTimeSheet.WorkHrs > 0m)
				{
					num++;
					if (workOrderTimeSheet.IsRamadan == true)
					{
						num3 += workOrderTimeSheet.WorkHrs;
						num4 += byID.RamadanWorkHrs - workOrderTimeSheet.WorkHrs;
					}
					else
					{
						num2 += workOrderTimeSheet.WorkHrs;
						num4 += byID.RegularWorkHrs - workOrderTimeSheet.WorkHrs;
					}
				}
			}
			TimesheetPaySlip timesheetPaySlip = new TimesheetPaySlip();
			TimesheetPaySlipDB timesheetPaySlipDB = new TimesheetPaySlipDB();
			timesheetPaySlip.FKWorkOrderId = byID.WorkOrderID;
			timesheetPaySlip.HourlyRate = byID.MonthlyRate / (byID.RegularWorkHrs * 30m);
			timesheetPaySlip.NoOfWorkingDays = new int?(num);
			timesheetPaySlip.NormalWorkingHours = num2;
			timesheetPaySlip.OTRate = byID.ExtraWorkHourRate;
			timesheetPaySlip.OTWorkingHours = num4;
			timesheetPaySlip.RamadanWorkingHours = num3;
			timesheetPaySlipDB.Insert(timesheetPaySlip);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00002071 File Offset: 0x00000271
		protected void JobOrderWorkSheetDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00002F46 File Offset: 0x00001146
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			this.Session["Bind"] = "True";
			this.GdvJobOrderWorkSheet.DataBind();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000D938 File Offset: 0x0000BB38
		protected void GdvJobOrderWorkSheet_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.CellType == GridViewTableCommandCellType.Data && e.ButtonID == "btnClear")
			{
				List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
				foreach (ADMUserSettings admuserSettings in allUserSettings)
				{
					if (admuserSettings.SettingsName == "Delete Time Sheet" && admuserSettings.SettingsValue == "True")
					{
						if (e.ButtonID == "btnClear")
						{
							e.Enabled = true;
						}
					}
					else if (admuserSettings.SettingsName == "Delete Time Sheet" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnClear")
					{
						e.Enabled = false;
					}
				}
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000DA48 File Offset: 0x0000BC48
		protected void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.GdvJobOrderWorkSheet.UpdateEdit();
				this.BindGrid();
				this.divmsg.Attributes["class"] = "alert alert-success";
				this.LblError.ForeColor = Color.Green;
				this.LblError.Text = "Data has been Updated successfully!";
				this.GeneratePayslip();
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

		// Token: 0x040001FE RID: 510
		protected HtmlGenericControl ultitle;

		// Token: 0x040001FF RID: 511
		protected ASPxLabel lblView;

		// Token: 0x04000200 RID: 512
		protected ASPxLabel lblEdite;

		// Token: 0x04000201 RID: 513
		protected ASPxLabel lblDelete;

		// Token: 0x04000202 RID: 514
		protected ASPxLabel lblAdd;

		// Token: 0x04000203 RID: 515
		protected ASPxLabel lblMode;

		// Token: 0x04000204 RID: 516
		protected ASPxLabel lblAlowUpdate;

		// Token: 0x04000205 RID: 517
		protected ASPxButton btnSave;

		// Token: 0x04000206 RID: 518
		protected ASPxButton btnCancel;

		// Token: 0x04000207 RID: 519
		protected HtmlGenericControl divmsg;

		// Token: 0x04000208 RID: 520
		protected ASPxLabel LblError;

		// Token: 0x04000209 RID: 521
		protected ASPxLabel lblMasterId;

		// Token: 0x0400020A RID: 522
		protected ASPxLabel lblJobOrder;

		// Token: 0x0400020B RID: 523
		protected ASPxComboBox cmbJobOrder;

		// Token: 0x0400020C RID: 524
		protected ASPxLabel lblWorkOrder;

		// Token: 0x0400020D RID: 525
		protected ASPxComboBox cmbWorkOrder;

		// Token: 0x0400020E RID: 526
		protected ASPxLabel lblDate;

		// Token: 0x0400020F RID: 527
		protected ASPxDateEdit dtFromdate;

		// Token: 0x04000210 RID: 528
		protected ASPxLabel lblToDate;

		// Token: 0x04000211 RID: 529
		protected ASPxDateEdit dtTodate;

		// Token: 0x04000212 RID: 530
		protected ASPxButton btnSearch;

		// Token: 0x04000213 RID: 531
		protected ASPxButton btnInvoice;

		// Token: 0x04000214 RID: 532
		protected HtmlTable tbApplay;

		// Token: 0x04000215 RID: 533
		protected ASPxLabel ASPxLabel2;

		// Token: 0x04000216 RID: 534
		protected ASPxComboBox CmbTechnician;

		// Token: 0x04000217 RID: 535
		protected ASPxLabel ASPxLabel4;

		// Token: 0x04000218 RID: 536
		protected ASPxTimeEdit tdStartTime;

		// Token: 0x04000219 RID: 537
		protected ASPxLabel ASPxLabel1;

		// Token: 0x0400021A RID: 538
		protected ASPxTimeEdit tdEndTime;

		// Token: 0x0400021B RID: 539
		protected ASPxLabel ASPxLabel3;

		// Token: 0x0400021C RID: 540
		protected ASPxComboBox cmbWorkStatus;

		// Token: 0x0400021D RID: 541
		protected ASPxLabel ASPxLabel7;

		// Token: 0x0400021E RID: 542
		protected ASPxComboBox cmbShiftStatus;

		// Token: 0x0400021F RID: 543
		protected ASPxLabel ASPxLabel5;

		// Token: 0x04000220 RID: 544
		protected ASPxTextBox txtBreak;

		// Token: 0x04000221 RID: 545
		protected ASPxCheckBox ckIsRamadan;

		// Token: 0x04000222 RID: 546
		protected ASPxButton btnApplay;

		// Token: 0x04000223 RID: 547
		protected ASPxLoadingPanel ASPxLoadingPanel1;

		// Token: 0x04000224 RID: 548
		protected ASPxGridView GdvJobOrderWorkSheet;

		// Token: 0x04000225 RID: 549
		protected GridViewCommandColumnCustomButton btnClear;

		// Token: 0x04000226 RID: 550
		protected ASPxCheckBox SelectAll;

		// Token: 0x04000227 RID: 551
		protected HtmlGenericControl divConfirmSection;

		// Token: 0x04000228 RID: 552
		protected ASPxButton btnApprove;

		// Token: 0x04000229 RID: 553
		protected ObjectDataSource JobOrderWorkSheetDS;

		// Token: 0x0400022A RID: 554
		protected ObjectDataSource EmpListDS;

		// Token: 0x0400022B RID: 555
		protected ObjectDataSource JobOrderDS;

		// Token: 0x0400022C RID: 556
		protected ObjectDataSource WorkOrderDS;
	}
}
