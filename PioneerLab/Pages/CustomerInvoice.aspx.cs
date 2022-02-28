using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
	// Token: 0x02000024 RID: 36
	public class CustomerInvoice : Page
	{
        // Token: 0x06000136 RID: 310 RVA: 0x0000B1F4 File Offset: 0x000093F4
        private LabSysEntities db = new LabSysEntities();
        public SqlConnection myConnection = new SqlConnection();

        public SqlDataAdapter adp;
        public SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/InvoiceManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
				this.Session["WorkOrderTimeSheetList"] = null;
				this.Session["WorkOrderInvoice"] = null;
				this.Session["SampleReceiveTestListInvoiced"] = null;
				this.Session["FkWorkOrderID"] = null;
				this.Session["SampleReceiveTestInvoice"] = null;
				this.Session["WorkOrderID"] = 0;
				if (base.Request["mode"] != null && base.Request["mode"] == "Convert")
				{
					JobOrderMaster byID = new JobOrderMasterDB().GetByID(Convert.ToInt64(base.Request["id"]));
					this.flInvoice.DataSourceID = null;
					this.cmbJobOrderMaster.Value = Convert.ToInt64(base.Request["id"]);
					this.cmbFKCustomerID.Value = byID.FKCustomerID;
					this.cmbFKProjectID.Value = byID.FKProjectID;
					this.GdvSampleReceiveTests.DataSource = new SampleReceiveTestListDB().GetViewSampleReceiveTestsByJobOrderMasterID(default(DateTime), default(DateTime), int.Parse(this.cmbJobOrderMaster.Value.ToString()), int.Parse(this.lblMasterId.Value.ToString())).Distinct<ViewSampleReceiveTests>();
					this.GdvSampleReceiveTests.DataBind();
					this.GdvWorkOrderHistory.DataSource = new WorkOrderListDB().GetAllWorkOrderbyJobOrderMasterID(default(DateTime), default(DateTime), int.Parse(this.cmbJobOrderMaster.Value.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
					this.GdvWorkOrderHistory.DataBind();
					this.cmbJobOrderMaster.ClientEnabled = false;
					this.dtInvoiceDate.Value = DateTime.Today;
                    this.txtInvoiceNumber.Text = new InvoiceDB().GetNewSerial();
                    this.txtLastInvoiceNumber.Text = new InvoiceDB().GetlastSerial();
					return;
				}
				int num = Convert.ToInt32(base.Request["id"]);
				if (num > 0)
				{
					this.lblMasterId.Text = num.ToString();
					Invoice byID2 = new InvoiceDB().GetByID(long.Parse(this.lblMasterId.Text));
					this.GdvSampleReceiveTests.DataSource = new SampleReceiveTestListDB().GetViewSampleReceiveTestsByJobOrderMasterID(DateTime.Parse(byID2.InvoiceStartDate.ToString()), DateTime.Parse(byID2.InvoiceEndDate.ToString()), int.Parse(byID2.FKJobOrderMasterID.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
					this.GdvSampleReceiveTests.DataBind();
					this.GdvWorkOrderHistory.DataSource = new WorkOrderListDB().GetAllWorkOrderbyJobOrderMasterID(DateTime.Parse(byID2.InvoiceStartDate.ToString()), DateTime.Parse(byID2.InvoiceEndDate.ToString()), int.Parse(byID2.FKJobOrderMasterID.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
					this.GdvWorkOrderHistory.DataBind();
					this.cmbJobOrderMaster.ClientEnabled = false;
					this.btnSave.Visible = false;
					this.SelectAllSR.Enabled = false;
					this.SelectAllWO.Enabled = false;
					return;
				}
				this.dtInvoiceDate.Value = DateTime.Today;
				this.txtInvoiceNumber.Text = new InvoiceDB().GetNewSerial();
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvJobOrder_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00002DB0 File Offset: 0x00000FB0
		protected void GdvActiveWorkOrder_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("TimeSheet.aspx?id=" + e.KeyValue.ToString() + "&mode=Edit");
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00008464 File Offset: 0x00006664
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

		// Token: 0x0600013A RID: 314 RVA: 0x00002DD1 File Offset: 0x00000FD1
		protected void GdvWorkOrderHistory_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("TimeSheet.aspx?id=" + e.KeyValue.ToString() + "&mode=View");
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000B6BC File Offset: 0x000098BC
		protected void GdvPendingCheckedWorkOrder_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(this.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Check Time Sheet" && admuserSettings.SettingsValue == "True")
				{
					if (e.ButtonID == "btnChecked")
					{
						e.Enabled = true;
					}
				}
				else if (admuserSettings.SettingsName == "Check Time Sheet" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnChecked")
				{
					e.Enabled = false;
				}
				if (admuserSettings.SettingsName == "Approve Time Sheet" && admuserSettings.SettingsValue == "True")
				{
					if (e.ButtonID == "btnApprove")
					{
						e.Enabled = true;
					}
				}
				else if (admuserSettings.SettingsName == "Approve Time Sheet" && admuserSettings.SettingsValue != "True" && e.ButtonID == "btnApprove")
				{
					e.Enabled = false;
				}
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00002DF2 File Offset: 0x00000FF2
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("InvoiceManage.aspx");
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000B834 File Offset: 0x00009A34
		protected void cmbFKCustomerID_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GdvSampleReceiveTests.DataSource = new SampleReceiveTestListDB().GetViewSampleReceiveTestsByJobOrderMasterID(DateTime.Parse(this.dtFromdate.Value.ToString()), DateTime.Parse(this.dtTodate.Value.ToString()), int.Parse(this.cmbJobOrderMaster.Value.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
			this.GdvSampleReceiveTests.DataBind();
			this.GdvWorkOrderHistory.DataSource = new WorkOrderListDB().GetAllWorkOrderbyJobOrderMasterID(DateTime.Parse(this.dtFromdate.Value.ToString()), DateTime.Parse(this.dtTodate.Value.ToString()), int.Parse(this.cmbJobOrderMaster.Value.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
			this.GdvWorkOrderHistory.DataBind();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000B92C File Offset: 0x00009B2C
		protected void popupPaySlip_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
			this.flTimesheetPaySlip.DataSourceID = null;
			int id = int.Parse(e.Parameter);
			this.flTimesheetPaySlip.DataSource = new WorkOrderListDB().GetByIdFromView(id);
			this.flTimesheetPaySlip.DataBind();
		}
        public static string lastFirst(int firstName)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select wor from ViewWorkOrderList where ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.CommandTimeout = 0;
            reader = sqlCmd.ExecuteReader();

            var accDetails = new List<ViewWorkOrderList>();

            //WriteErrorLog("getearners ");
            while (reader.Read())
            {
                var accountDetails = new ViewWorkOrderList
                {

                    WorkOrderID = Convert.ToInt32(reader.GetValue(0).ToString()),


                };
                accDetails.Add(accountDetails);


            }

            myConnection.Close();

            return "1";
        }

        // Token: 0x0600013F RID: 319 RVA: 0x0000B974 File Offset: 0x00009B74
        protected void btnSave_Click(object sender, EventArgs e)
		{
        
            Invoice byID2 = new InvoiceDB().GetByID(long.Parse(this.lblMasterId.Text));
            var sample = new SampleReceiveTestListDB().GetViewSampleReceiveTestsByJobOrderMasterID(DateTime.Parse(byID2.InvoiceStartDate.ToString()), DateTime.Parse(byID2.InvoiceEndDate.ToString()), int.Parse(byID2.FKJobOrderMasterID.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
            var work = new WorkOrderListDB().GetAllWorkOrderbyJobOrderMasterID(DateTime.Parse(byID2.InvoiceStartDate.ToString()), DateTime.Parse(byID2.InvoiceEndDate.ToString()), int.Parse(byID2.FKJobOrderMasterID.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
            var test = new WorkOrderTimeSheetDB().test(int.Parse(this.cmbJobOrderMaster.Value.ToString())).Select(a=>a.WorkOrderID).ToArray();
            var job = new JobOrderMasterDB().GetActiveJobOrderFromView();
            lastFirst(Convert.ToInt32(test));
           


            int num1 = 0;
            try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num == 0L)
				{
                    foreach (ViewSampleReceiveTests item in sample)
                    {
                        foreach (ViewJobOrderList item2 in job)
                        {
                            foreach (WorkOrderList item3 in work)
                            {
                                if(item.JobOrderMasterID==item2.JobOrderMasterID && item.JobOrderNumber==item2.JobOrderNumber && item2.JobOrderDetailsID==item3.FKJobOrderDetailsID)
                                {
                                    if (this.lblAdd.Text == "True")

                                    {
                                         num1 = (from x in new WorkOrderTimeSheetDB().GetByWorkOrderID(item3.WorkOrderID)
                                                   where x.IsChecked == true && x.IsApproved == true
                                                   select x).Count();
                                       if (num1 > 0)
                                        {
                                            if (this.IsValid())
                                            {
                                                this.GdvWorkOrderHistory.UpdateEdit();
                                                this.GdvSampleReceiveTests.UpdateEdit();
                                            }
                                            else
                                            {
                                                this.divmsg.Attributes["class"] = "alert alert-info";
                                                this.LblErrorMessage.ForeColor = Color.Red;
                                                this.LblErrorMessage.Text = "The invoice number is present";
                                            }
                                        }
                                        else
                                        {
                                            ASPxLabel2.Text = "work order data is not entered for the selected invoice period"; ;
                                        }
  
                                    }
                                    else
                                    {
                                        this.btnSave.Enabled = false;
                                        this.divmsg.Attributes["class"] = "alert alert-info";
                                        this.LblErrorMessage.ForeColor = Color.Red;
                                        this.LblErrorMessage.Text = "You dont have permission to Add";
                                    }

                                }
                                else
                                {
                                    continue;
                                }

                            }

                        }

                    }
                        
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblErrorMessage.ForeColor = Color.Red;
				this.LblErrorMessage.Text = ex.Message;
				this.btnSave.Enabled = false;
				if (ex.InnerException != null)
				{
					this.LblErrorMessage.Text = ex.InnerException.Message;
				}
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00002E04 File Offset: 0x00001004
		protected new bool IsValid()
		{
			return !new InvoiceDB().CheckExist(this.txtInvoiceNumber.Text);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		protected void GdvSampleReceiveTests_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
		{
			Invoice masterEntity = this.GetMasterEntity(0);
			masterEntity.SampleReceiveTestInvoice = this.UpdateSampleReceiveTestInvoice(e.UpdateValues);
			masterEntity.WorkOrderInvoice = (this.Session["WorkOrderInvoiced"] as List<WorkOrderInvoice>);
			this.Session["WorkOrderInvoiced"] = null;
			if (new InvoiceDB().Insert(masterEntity))
			{
				base.Response.Redirect("InvoiceManage.aspx");
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000BB40 File Offset: 0x00009D40
		protected List<SampleReceiveTestInvoice> UpdateSampleReceiveTestInvoice(List<ASPxDataUpdateValues> list)
		{
			List<SampleReceiveTestInvoice> list2 = new List<SampleReceiveTestInvoice>();
			foreach (ASPxDataUpdateValues aspxDataUpdateValues in list)
			{
				list2.Add(new SampleReceiveTestInvoice
				{
					FkSampleReceiveTestID = (long)Convert.ToInt32(aspxDataUpdateValues.Keys["SampleReceiveTestID"])
				});
			}
			return list2;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000BBB8 File Offset: 0x00009DB8
		protected void GdvWorkOrderHistory_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
		{
			List<WorkOrderInvoice> value = this.UpdateWorkOrderInvoice(e.UpdateValues);
			this.Session["WorkOrderInvoiced"] = value;
			e.Handled = true;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000BBEC File Offset: 0x00009DEC
		protected List<WorkOrderInvoice> UpdateWorkOrderInvoice(List<ASPxDataUpdateValues> list)
		{
			List<WorkOrderInvoice> list2 = new List<WorkOrderInvoice>();
			foreach (ASPxDataUpdateValues aspxDataUpdateValues in list)
			{
				list2.Add(new WorkOrderInvoice
				{
					FkWorkOrderId = (long)Convert.ToInt32(aspxDataUpdateValues.Keys["WorkOrderID"]),
					StartDate = (DateTime)aspxDataUpdateValues.NewValues["StartDate"],
					EndDate = (DateTime)aspxDataUpdateValues.NewValues["EndDate"]
				});
			}
			return list2;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00002E20 File Offset: 0x00001020
		protected void InvoiceDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00002E39 File Offset: 0x00001039
		protected void InvoiceDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblErrorMessage.ForeColor = Color.Green;
			this.LblErrorMessage.Text = "Data has been saved successfully!";
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000BC9C File Offset: 0x00009E9C
		private Invoice GetMasterEntity(int MasterID)
		{
			Invoice invoice;
			if (MasterID > 0)
			{
				invoice = new InvoiceDB().GetByID((long)MasterID);
				invoice.InvoiceNumber = this.txtInvoiceNumber.Text;
			}
			else
			{
				invoice = new Invoice();
				invoice.InvoiceNumber = this.txtInvoiceNumber.Text;
			}
			invoice.InvoiceDate = new DateTime?((DateTime)this.dtInvoiceDate.Value);
			invoice.InvoiceRefNo = this.txtInvoiceRefNo.Text;
			invoice.InvoiceTotal = (decimal?)this.txtInvoiceTotal.Value;
			invoice.NetAmount = (decimal?)this.txtNetAmount.Value;
			invoice.SRTTotal = (decimal?)this.txtSRTTotal.Value;
			invoice.TSTotal = (decimal?)this.txtTSTotal.Value;
			invoice.Disount = (decimal?)this.txtDiscount.Value;
			invoice.FKJobOrderMasterID = (long)this.cmbJobOrderMaster.Value;
			invoice.ProvideDescription = this.txtDescription.Text;
			invoice.InvoiceStartDate = new DateTime?((DateTime)this.dtFromdate.Value);
			invoice.InvoiceEndDate = new DateTime?((DateTime)this.dtTodate.Value);
			return invoice;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000BDDC File Offset: 0x00009FDC
		public void ClearAll()
		{
			this.txtDiscount.Text = "";
			this.txtDiscountP.Text = "";
			this.txtDueAmount.Text = "";
			this.txtHourlyRate.Text = "";
			this.txtInvoiceNumber.Text = "";
			this.txtInvoiceRefNo.Text = "";
			this.txtInvoiceTotal.Text = "";
			this.txtNetAmount.Text = "";
			this.txtNoOfWorkingDays.Text = "";
			this.txtNormalWorkingHours.Text = "";
			this.txtOTRate.Text = "";
			this.txtOTWorkingHours.Text = "";
			this.txtRamadanWorkHrs.Text = "";
			this.txtRate.Text = "";
			this.txtSRTTotal.Text = "";
			this.txtTSTotal.Text = "";
			this.txtWorkOrderNo.Text = "";
			this.cmbJobOrderMaster.SelectedIndex = -1;
			this.cmbJobOrderMaster.Value = null;
			this.txtLastInvoiceNumber.Text = "";
			this.txtDescription.Text = "";
			this.dtTodate.Value = null;
			this.dtFromdate.Value = null;
			this.GdvSampleReceiveTests.DataBind();
			this.GdvWorkOrderHistory.DataBind();
			this.ckbReport.SelectedIndex = -1;
			this.cmbFKCustomerID.Value = null;
			this.cmbFKProjectID.Value = null;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00002E75 File Offset: 0x00001075
		protected void txtInvoiceNumber_TextChanged(object sender, EventArgs e)
		{
			this.lblErrorMassage.Visible = false;
			if (new InvoiceDB().CheckExist(this.txtInvoiceNumber.Text))
			{
				this.lblErrorMassage.Visible = true;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000B834 File Offset: 0x00009A34
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			this.GdvSampleReceiveTests.DataSource = new SampleReceiveTestListDB().GetViewSampleReceiveTestsByJobOrderMasterID(DateTime.Parse(this.dtFromdate.Value.ToString()), DateTime.Parse(this.dtTodate.Value.ToString()), int.Parse(this.cmbJobOrderMaster.Value.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
			this.GdvSampleReceiveTests.DataBind();
			this.GdvWorkOrderHistory.DataSource = new WorkOrderListDB().GetAllWorkOrderbyJobOrderMasterID(DateTime.Parse(this.dtFromdate.Value.ToString()), DateTime.Parse(this.dtTodate.Value.ToString()), int.Parse(this.cmbJobOrderMaster.Value.ToString()), int.Parse(this.lblMasterId.Value.ToString()));
			this.GdvWorkOrderHistory.DataBind();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00002071 File Offset: 0x00000271
		protected void CkSelectAll_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00002071 File Offset: 0x00000271
		protected void dtFromdate_DateChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0400017F RID: 383
		protected HtmlGenericControl ultitle;

		// Token: 0x04000180 RID: 384
		protected ASPxLabel lblView;

		// Token: 0x04000181 RID: 385
		protected ASPxLabel lblEdite;

		// Token: 0x04000182 RID: 386
		protected ASPxLabel lblDelete;

		// Token: 0x04000183 RID: 387
		protected ASPxLabel lblAdd;

		// Token: 0x04000184 RID: 388
		protected ASPxLabel lblAlowUpdate;

		// Token: 0x04000185 RID: 389
		protected ASPxButton btnSave;

		// Token: 0x04000186 RID: 390
		protected ASPxButton btnCancel;

		// Token: 0x04000187 RID: 391
		protected HtmlGenericControl divmsg;

		// Token: 0x04000188 RID: 392
		protected ASPxLabel LblErrorMessage;

		// Token: 0x04000189 RID: 393
		protected ASPxLabel lblMasterId;

		// Token: 0x0400018A RID: 394
		protected ASPxLabel lblQid;

		// Token: 0x0400018B RID: 395
		protected ASPxFormLayout flInvoice;

		// Token: 0x0400018C RID: 396
		protected ASPxTextBox txtInvoiceNumber;

		// Token: 0x0400018D RID: 397
		protected ASPxLabel lblErrorMassage;

		// Token: 0x0400018E RID: 398
		protected ASPxTextBox txtLastInvoiceNumber;

		// Token: 0x0400018F RID: 399
		protected ASPxDateEdit dtInvoiceDate;

		// Token: 0x04000190 RID: 400
		protected ASPxTextBox txtInvoiceRefNo;

		// Token: 0x04000191 RID: 401
		protected ASPxComboBox cmbJobOrderMaster;

		// Token: 0x04000192 RID: 402
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x04000193 RID: 403
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x04000194 RID: 404
		protected ASPxDateEdit dtFromdate;

		// Token: 0x04000195 RID: 405
		protected ASPxDateEdit dtTodate;

		// Token: 0x04000196 RID: 406
		protected CheckBoxList ckbReport;

		// Token: 0x04000197 RID: 407
		protected ASPxButton btnSearch;

		// Token: 0x04000198 RID: 408
		protected ASPxLoadingPanel ASPxLoadingPanel1;

		// Token: 0x04000199 RID: 409
		protected ASPxHiddenField hf;

		// Token: 0x0400019A RID: 410
		protected ASPxGridView GdvSampleReceiveTests;

		// Token: 0x0400019B RID: 411
		protected ASPxCheckBox SelectAllSR;

		// Token: 0x0400019C RID: 412
		protected ASPxSpinEdit txtSRTTotal;

		// Token: 0x0400019D RID: 413
		protected ASPxLabel lblError;

		// Token: 0x0400019E RID: 414
		protected ASPxHiddenField ASPxHiddenField1;

		// Token: 0x0400019F RID: 415
		protected ASPxGridView GdvWorkOrderHistory;

		// Token: 0x040001A0 RID: 416
		protected ASPxCheckBox SelectAllWO;

		// Token: 0x040001A1 RID: 417
		protected ASPxSpinEdit txtTSTotal;

		// Token: 0x040001A2 RID: 418
		protected ASPxTextBox txtDescription;

		// Token: 0x040001A3 RID: 419
		protected ASPxSpinEdit txtInvoiceTotal;

		// Token: 0x040001A4 RID: 420
		protected ASPxSpinEdit txtDiscount;

		// Token: 0x040001A5 RID: 421
		protected ASPxSpinEdit txtDiscountP;

		// Token: 0x040001A6 RID: 422
		protected ASPxLabel ASPxLabel1;

		// Token: 0x040001A7 RID: 423
		protected ASPxSpinEdit txtNetAmount;

		// Token: 0x040001A8 RID: 424
		protected new ASPxLabel Error;

		// Token: 0x040001A9 RID: 425
		protected ASPxPopupControl popupPaySlip;

		// Token: 0x040001AA RID: 426
		protected PopupControlContentControl PopupControlContentControl1;

		// Token: 0x040001AB RID: 427
		protected ASPxCallbackPanel cpnl;

		// Token: 0x040001AC RID: 428
		protected ASPxFormLayout flTimesheetPaySlip;

		// Token: 0x040001AD RID: 429
		protected ASPxComboBox cmbFKJobOrderMasterID;

		// Token: 0x040001AE RID: 430
		protected ASPxTextBox txtWorkOrderNo;

		// Token: 0x040001AF RID: 431
		protected ASPxDateEdit dtStartDate;

		// Token: 0x040001B0 RID: 432
		protected ASPxDateEdit dtEndDate;

		// Token: 0x040001B1 RID: 433
		protected ASPxTextBox txtNoOfWorkingDays;

		// Token: 0x040001B2 RID: 434
		protected ASPxSpinEdit txtNormalWorkingHours;

		// Token: 0x040001B3 RID: 435
		protected ASPxSpinEdit txtRate;

		// Token: 0x040001B4 RID: 436
		protected ASPxSpinEdit txtRamadanWorkHrs;

		// Token: 0x040001B5 RID: 437
		protected ASPxSpinEdit txtHourlyRate;

		// Token: 0x040001B6 RID: 438
		protected ASPxSpinEdit txtOTWorkingHours;

		// Token: 0x040001B7 RID: 439
		protected ASPxSpinEdit txtOTRate;

		// Token: 0x040001B8 RID: 440
		protected ASPxSpinEdit txtDueAmount;

		// Token: 0x040001B9 RID: 441
		protected ObjectDataSource SampleReceiveTestsDS;

		// Token: 0x040001BA RID: 442
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x040001BB RID: 443
		protected ObjectDataSource TestsListDS;

		// Token: 0x040001BC RID: 444
		protected ObjectDataSource WorkOrderDS;

		// Token: 0x040001BD RID: 445
		protected ObjectDataSource JobOrderDS;
        protected ASPxLabel ASPxLabel2;
        // Token: 0x040001BE RID: 446
        protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x040001BF RID: 447
		protected ObjectDataSource InvoiceDS;

		// Token: 0x040001C0 RID: 448
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040001C1 RID: 449
		protected ObjectDataSource TimesheetPaySlipDS;

		// Token: 0x040001C2 RID: 450
		protected ObjectDataSource ProjectsListDS;
	}
}
