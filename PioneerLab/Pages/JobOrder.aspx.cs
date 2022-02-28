using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x02000036 RID: 54
	public class JobOrder : Page
	{
        // Token: 0x060001E9 RID: 489 RVA: 0x00010B78 File Offset: 0x0000ED78
        protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/JobOrderManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
			string.IsNullOrEmpty(this.Session["JOWorkOrderNumber"] as string).ToString();
			if (HttpContext.Current.Session["JOWorkOrderNumber"] == null)
			{
				this.Session["JOWorkOrderNumber"] = new WorkOrderListDB().GetMaxWorkOrderNo();
			}
			if (!base.IsPostBack)
			{
				this.Session["JobOrderDetailsList"] = null;
				this.Session["NewJobOrderDetailsList"] = null;
				this.Session["WorkOrderList"] = null;
				this.Session["NewWorkOrderList"] = null;
				this.Session["QuotaionMasterId"] = null;
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.flJobOrderMaster.DataBind();
				if (num > 0)
				{
					if (base.Request["mode"] != null && base.Request["mode"] == "Expired")
					{
						this.divConfirmSection.Visible = false;
						this.btnAddQuotation.Visible = false;
					}
					else if (base.Request["mode"] != null && base.Request["mode"] == "confirm")
					{
						this.divConfirmSection.Visible = true;
						this.btnAddQuotation.Visible = true;
					}
					else
					{
						this.btnAddQuotation.Visible = true;
						this.BtnSave.Text = "Update";
					}
					JobOrderMasterDB jobOrderMasterDB = new JobOrderMasterDB();
					JobOrderMaster byID = jobOrderMasterDB.GetByID((long)num);
					this.cmbFKQuotationMasterID.ReadOnly = true;
					this.Session["QuotaionMasterId"] = byID.FKQuotationMasterID;
					this.flCustomerJobOrderMaster.DataBind();
					this.lblQutaionMasterId.Text = byID.FKQuotationMasterID.ToString();
					return;
				}
				JobOrderMasterDB jobOrderMasterDB2 = new JobOrderMasterDB();
				this.txtJobOrderNumber.Text = jobOrderMasterDB2.GetNewSerial();
				this.dtTransactionDate.Date = DateTime.Today.Date;
				this.IsActive.Checked = true;
				this.btnAddQuotation.Visible = false;
			}            
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00010EC4 File Offset: 0x0000F0C4
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				long num2 = Convert.ToInt64(this.lblActiveMasterId.Text);
				if (num > 0L || num2 > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.JobOrderMasterDS.Update();
						base.Response.Redirect("JobOrderManage.aspx");
					}
					else
					{
						this.BtnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = "You dont have permission to Update";
					}
				}
				else
				{
					if (this.lblAdd.Text == "True")
					{
						this.JobOrderMasterDS.Insert();
						base.Response.Redirect("JobOrderManage.aspx");
					}
					else
					{
						this.BtnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = "You dont have permission to Add";
					}
					this.Clearpage();
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

		// Token: 0x060001EB RID: 491 RVA: 0x00003288 File Offset: 0x00001488
		protected void JobOrderMasterDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			new JobOrderMaster();
			e.InputParameters["entity"] = this.GetMasterEntity(0L);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000032A8 File Offset: 0x000014A8
		protected void JobOrderMasterDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00011080 File Offset: 0x0000F280
		protected void JobOrderMasterDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			long masterID = Convert.ToInt64(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000110B8 File Offset: 0x0000F2B8
		private JobOrderMaster GetMasterEntity(long MasterID)
		{
			long num = Convert.ToInt64(this.lblActiveMasterId.Text);
			if (num > 0L)
			{
				MasterID = num;
			}
			JobOrderMaster jobOrderMaster;
			if (MasterID > 0L)
			{
				jobOrderMaster = new JobOrderMasterDB().GetByID(MasterID);
				if (this.Session["action"] != null)
				{
					jobOrderMaster.StatusID = Convert.ToInt32(this.Session["action"]);
				}
				jobOrderMaster.JobOrderNumber = this.txtJobOrderNumber.Text;
			}
			else
			{
				jobOrderMaster = new JobOrderMaster();
				jobOrderMaster.JobOrderNumber = new JobOrderMasterDB().GetNewSerial();
			}
			if (num <= 0L)
			{
				jobOrderMaster.TransactionDate = (DateTime?)this.dtTransactionDate.Value;
				jobOrderMaster.LPONumber = this.txtLPONumber.Text;
				jobOrderMaster.ReceiveCreditLimit = (decimal?)this.txtReceiveCreditLimit.Value;
				jobOrderMaster.ReportCreditLimit = (decimal?)this.txtReportCreditLimit.Value;
				jobOrderMaster.UnpaidReceiveLimit = ((this.txtUnpaidReceiveLimit.Value == null) ? null : new int?(Convert.ToInt32(this.txtUnpaidReceiveLimit.Value)));
				jobOrderMaster.ExpiryDate = (DateTime?)this.dtExpiryDate.Value;
				jobOrderMaster.FKQuotationMasterID = new long?(Convert.ToInt64(this.cmbFKQuotationMasterID.Value));
				jobOrderMaster.FKCustomerID = Convert.ToInt32(this.cmbFKCustomerID.Value);
				jobOrderMaster.FKProjectID = Convert.ToInt32(this.cmbFKProjectID.Value);
				jobOrderMaster.Remarks = this.txtRemarks.Text;
				jobOrderMaster.IsActive = this.IsActive.Checked;
            }
			return jobOrderMaster;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00011254 File Offset: 0x0000F454
		protected void JobOrderMasterDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
			base.Response.Redirect("JobOrderManage.aspx");
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00003000 File Offset: 0x00001200
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("JobOrderManage.aspx");
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000112AC File Offset: 0x0000F4AC
		protected void lstTests_DataBound(object sender, EventArgs e)
		{
			ASPxCheckBoxList aspxCheckBoxList = (ASPxCheckBoxList)sender;
			List<JobOrderDetails> source = this.JobOrderDetailsDS.Select() as List<JobOrderDetails>;
			List<int> list = (from x in source
			select x.FKTestID).ToList<int>();
			for (int i = 0; i < aspxCheckBoxList.Items.Count; i++)
			{
				aspxCheckBoxList.Items[i].Selected = list.Contains((int)aspxCheckBoxList.Items[i].Value);
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00002071 File Offset: 0x00000271
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00011340 File Offset: 0x0000F540
		protected void JobOrderDetailsDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			List<object> selectedFieldValues = this.GdvLabTestsList.GetSelectedFieldValues(new string[]
			{
				"TestID"
			});
			List<JobOrderDetails> list = new List<JobOrderDetails>();
			foreach (object value in selectedFieldValues)
			{
				JobOrderDetails jobOrderDetails = new JobOrderDetails();
				jobOrderDetails.FKJobOrderMasterID = (long)num;
				jobOrderDetails.FKTestID = Convert.ToInt32(value);
				jobOrderDetails.FKPriceUnitID = new TestPricesDB().GetFirstPriceUnitByTestID(jobOrderDetails.FKTestID).FKPriceUnitID;
				list.Add(jobOrderDetails);
			}
			if (list.Count == 0)
			{
				list.Add(new JobOrderDetails
				{
					FKJobOrderMasterID = (long)num,
					FKTestID = 0
				});
			}
			e.InputParameters["entityList"] = list;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000032E4 File Offset: 0x000014E4
		protected void JobOrderDetailsDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.popTestLists.ShowOnPageLoad = false;
			this.GdvJobOrderDetailsList.DataBind();
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000032FD File Offset: 0x000014FD
		protected void popTestLists_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
			this.lstTests.DataBind();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0001143C File Offset: 0x0000F63C
		protected void GdvJobOrderDetailsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			if (e.Column.FieldName == "FKPriceUnitID")
			{
				object rowValues = this.GdvJobOrderDetailsList.GetRowValues(e.VisibleIndex, new string[]
				{
					"FKTestID"
				});
				ASPxComboBox aspxComboBox = e.Editor as ASPxComboBox;
				aspxComboBox.DataSourceID = null;
				aspxComboBox.DataSource = new TestPricesDB().GetTestPriceUnitList((int)rowValues);
				aspxComboBox.ValueField = "PriceUnitID";
				aspxComboBox.ValueType = typeof(int);
				aspxComboBox.TextField = "UnitName";
				aspxComboBox.DataBindItems();
			}            
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000DE60 File Offset: 0x0000C060
		protected void GdvJobOrderDetailsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			this.Session["NewJobOrderDetailsID"] = e.Keys["JobOrderDetailsID"];
			this.Session["NewFKTestID"] = e.NewValues["FKTestID"];
			this.Session["FKMaterialTypeID"] = e.NewValues["FKMaterialTypeID"];
			this.Session["FKMaterialDetailsID"] = e.NewValues["FKMaterialDetailsID"];
			this.Session["NewFKPriceUnitID"] = e.NewValues["FKPriceUnitID"];
			this.Session["NewPrice"] = e.NewValues["Price"];
			this.Session["NewMinQty"] = e.NewValues["MinQty"];
            this.Session["NewExpiryDate"] = e.NewValues["ExpiryDate"];
			this.Session["NewRemarks"] = ((e.NewValues["Remarks"] == null) ? "" : e.NewValues["Remarks"]);
            this.Session["NewIsEnable"] = e.NewValues["IsEnable"];
        }

		// Token: 0x060001F8 RID: 504 RVA: 0x000114D8 File Offset: 0x0000F6D8
		protected void JobOrderDetailsDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			if (this.Session["NewJobOrderDetailsID"] != null)
			{
				long fkjobOrderMasterID = Convert.ToInt64(this.lblMasterId.Text);
				JobOrderDetails jobOrderDetails = new JobOrderDetails();
				jobOrderDetails.JobOrderDetailsID = (long)Convert.ToInt32(this.Session["NewJobOrderDetailsID"]);
				jobOrderDetails.FKJobOrderMasterID = fkjobOrderMasterID;
				jobOrderDetails.FKTestID = Convert.ToInt32(this.Session["NewFKTestID"]);
				jobOrderDetails.FKMaterialTypeID = new int?(Convert.ToInt32(this.Session["FKMaterialTypeID"]));
				jobOrderDetails.FKMaterialDetailsID = new int?(Convert.ToInt32(this.Session["FKMaterialDetailsID"]));
				jobOrderDetails.FKPriceUnitID = Convert.ToInt32(this.Session["NewFKPriceUnitID"]);
				jobOrderDetails.Price = new decimal?(Convert.ToDecimal(this.Session["NewPrice"]));
				jobOrderDetails.MinQty = (decimal?)this.Session["NewMinQty"];
				jobOrderDetails.ExpiryDate = (DateTime?)this.Session["NewExpiryDate"];
				jobOrderDetails.Remarks = this.Session["NewRemarks"].ToString();
                jobOrderDetails.IsEnable = (bool)this.Session["NewIsEnable"];
				e.InputParameters["entity"] = jobOrderDetails;
				e.InputParameters["original_JobOrderDetailsID"] = Convert.ToInt32(this.Session["NewJobOrderDetailsID"]);
				this.Session["NewJobOrderDetailsID"] = null;
				this.Session["NewFKTestID"] = null;
				this.Session["FKMaterialTypeID"] = null;
				this.Session["FKMaterialDetailsID"] = null;
				this.Session["NewFKPriceUnitID"] = null;
				this.Session["NewPrice"] = null;
				this.Session["NewMinQty"] = null;
				this.Session["NewExpiryDate"] = null;
				this.Session["NewRemarks"] = null;
                this.Session["NewIsEnable"] = null;
                return;
			}
			e.Cancel = true;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000116F8 File Offset: 0x0000F8F8
		protected void GdvLabTestsList_DataBound(object sender, EventArgs e)
		{
			List<JobOrderDetails> source = this.JobOrderDetailsDS.Select() as List<JobOrderDetails>;
			List<int> list = (from x in source
			select x.FKTestID).ToList<int>();
			foreach (int num in list)
			{
				this.GdvLabTestsList.Selection.SelectRowByKey(num);
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00011790 File Offset: 0x0000F990
		protected void cmbFKQuotationMasterID_SelectedIndexChanged(object sender, EventArgs e)
		{
			long num = Convert.ToInt64(this.cmbFKQuotationMasterID.Value);
			QuotationMaster byID = new QuotationMasterDB().GetByID(num);
			this.cmbFKCustomerID.Value = byID.FKCustomerID;
			this.cmbFKProjectID.Value = byID.FKProjectID;
			List<ViewQuotationDetails> byMasterIDWithSession = new QuotationDetailsDB().GetByMasterIDWithSession(num);
			List<JobOrderDetails> list = new List<JobOrderDetails>();
			List<WorkOrderList> list2 = new List<WorkOrderList>();
			new TestPricesDB();
			foreach (ViewQuotationDetails viewQuotationDetails in byMasterIDWithSession)
			{
				QuotationDetails byID2 = new QuotationDetailsDB().GetByID(viewQuotationDetails.QuotationDetailsID);
				JobOrderDetails jobOrderDetails = new JobOrderDetails();
				jobOrderDetails.JobOrderDetailsID = (long)(list.Count + 1);
				jobOrderDetails.FKQuotationDetailsID = new long?(viewQuotationDetails.QuotationDetailsID);
				jobOrderDetails.FKTestID = viewQuotationDetails.FKTestID;
				jobOrderDetails.FKMaterialTypeID = viewQuotationDetails.FKMaterialTypeID;
				jobOrderDetails.FKMaterialDetailsID = viewQuotationDetails.FKMaterialDetailsID;
				jobOrderDetails.FKPriceUnitID = viewQuotationDetails.FKPriceUnitID;
				jobOrderDetails.Remarks = viewQuotationDetails.Remarks;
				jobOrderDetails.Price = viewQuotationDetails.Price;
				jobOrderDetails.MinQty = viewQuotationDetails.MinQty;
				jobOrderDetails.IsEnable = true;

				jobOrderDetails.RowStatus = 1;
				foreach (QuotationWorkOrderList quotationWorkOrderList in byID2.QuotationWorkOrderList)
				{
					list2.Add(new WorkOrderList
					{
						WorkOrderID = (long)(list2.Count + 1),
						EndDate = quotationWorkOrderList.EndDate,
						ExtraWorkHourRate = quotationWorkOrderList.ExtraWorkHourRate,
						FKAgreementID = quotationWorkOrderList.FKAgreementID,
						FKJobOrderDetailsID = new long?((long)(list.Count + 1)),
						MonthlyRate = quotationWorkOrderList.MonthlyRate,
						NightShiftPerc = quotationWorkOrderList.NightShiftPerc,
						Description = quotationWorkOrderList.Description,
						RamadanWorkHrs = quotationWorkOrderList.RamadanWorkHrs,
						RegularWorkHrs = quotationWorkOrderList.RegularWorkHrs,
						ShiftStatus = quotationWorkOrderList.ShiftStatus,
						SiteName = quotationWorkOrderList.SiteName,
						StartDate = quotationWorkOrderList.StartDate,
						TransDate = quotationWorkOrderList.TransDate,
						WorkOrderNo = new WorkOrderListDB().GetWorkOrderNo()
					});
				}
				list.Add(jobOrderDetails);
			}
			this.Session["WorkOrderList"] = list2;
			this.Session["JobOrderDetailsList"] = list;
			this.GdvJobOrderDetailsList.DataBind();
			this.lblActiveMasterId.Text = new JobOrderMasterDB().GetActiveJobOrderID(byID.FKCustomerID, byID.FKProjectID).ToString();
			if (this.lblActiveMasterId.Text != "0")
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Font.Bold = true;
				this.LblError.Text = " There is an active Job Order Number (" + this.lblActiveMasterId.Text + ") present for the selected Customer and Project! \n Please Update the order";
				this.BtnSave.ClientEnabled = false;
				return;
			}
			this.BtnSave.ClientEnabled = true;
			this.divmsg.Attributes["class"] = "hidden";
			this.LblError.Text = "";
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00011B50 File Offset: 0x0000FD50
		protected void BtnSaveVersion_Click(object sender, EventArgs e)
		{
			try
			{
				object obj = this.Session["JobOrderDetailsList"];
				if (obj != null)
				{
					List<JobOrderDetails> list = new List<JobOrderDetails>();
					foreach (JobOrderDetails jobOrderDetails in (obj as List<JobOrderDetails>))
					{
						list.Add(new JobOrderDetails
						{
							FKQuotationDetailsID = jobOrderDetails.FKQuotationDetailsID,
							FKTestID = jobOrderDetails.FKTestID,
							FKPriceUnitID = jobOrderDetails.FKPriceUnitID,
							Price = jobOrderDetails.Price,
							MinQty = jobOrderDetails.MinQty,
							ExpiryDate = jobOrderDetails.ExpiryDate,
							Remarks = jobOrderDetails.Remarks
                        });
					}
					this.Session["JobOrderDetailsList"] = list;
				}
				this.JobOrderMasterDS.Insert();
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

		// Token: 0x060001FC RID: 508 RVA: 0x00011CA8 File Offset: 0x0000FEA8
		protected void btnUpdateWorkOrder_Click(object sender, EventArgs e)
		{
			long num = Convert.ToInt64(this.sid.Text);
			if (num > 0L)
			{
				try
				{
					this.WorkOrderListDS.Update();
					this.lblErrorMessage.Visible = false;
					return;
				}
				catch (Exception ex)
				{
					this.lblErrorMessage.ForeColor = Color.Red;
					this.lblErrorMessage.Text = ex.Message;
					if (ex.InnerException != null)
					{
						this.lblErrorMessage.Text = ex.InnerException.Message;
					}
					return;
				}
			}
			this.WorkOrderListDS.Insert();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000330A File Offset: 0x0000150A
		protected void WorkOrderListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetWorkOrderEntity();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000330A File Offset: 0x0000150A
		protected void WorkOrderListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetWorkOrderEntity();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00011D44 File Offset: 0x0000FF44
		private bool checkValidate(WorkOrderList entity)
		{
			DateTime dateTime = (DateTime)this.dtStartDate.Value;
			DateTime dateTime2 = (DateTime)this.dtEndDate.Value;
			DateTime value = entity.StartDate.Value;
			DateTime value2 = entity.EndDate.Value;
			if (dateTime > value)
			{
				DateTime dateTime3 = value;
				while (dateTime3 <= dateTime)
				{
					WorkOrderTimeSheet byWorkOrderByDate = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(dateTime3, entity.WorkOrderID);
					if (byWorkOrderByDate != null)
					{
						return false;
					}
					dateTime3 = dateTime3.AddDays(1.0);
				}
				return true;
			}
			if (dateTime2 < value2)
			{
				DateTime dateTime4 = dateTime2;
				while (dateTime4 <= value2)
				{
					WorkOrderTimeSheet byWorkOrderByDate2 = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(dateTime4, entity.WorkOrderID);
					if (byWorkOrderByDate2 != null)
					{
						return false;
					}
					dateTime4 = dateTime4.AddDays(1.0);
				}
				return true;
			}
			return true;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00011E20 File Offset: 0x00010020
		private WorkOrderList GetWorkOrderEntity()
		{
			long num = Convert.ToInt64(this.sid.Text);
			long fkjobOrderMasterID = Convert.ToInt64(this.lblMasterId.Text);
			WorkOrderList workOrderList;
			if (num > 0L)
			{
				workOrderList = new WorkOrderListDB().GetByIDFromSession(num);
			}
			else
			{
				workOrderList = new WorkOrderList();
				workOrderList.WorkOrderNo = new WorkOrderListDB().GetWorkOrderNo();
				workOrderList.TransDate = new DateTime?(DateTime.Now);
			}
			workOrderList.FKJobOrderDetailsID = new long?(Convert.ToInt64(this.vid.Text));
			workOrderList.StartDate = (DateTime?)this.dtStartDate.Value;
			workOrderList.EndDate = (DateTime?)this.dtEndDate.Value;
			workOrderList.SiteName = this.txtSiteName.Text;
			workOrderList.ShiftStatus = (int?)this.cmbShiftStatus.Value;
			workOrderList.RegularWorkHrs = (decimal?)this.txtRegularWorkHrs.Value;
			workOrderList.RamadanWorkHrs = (decimal?)this.txtRamadanWorkHrs.Value;
			workOrderList.MonthlyRate = (decimal?)this.txtMonthlyRate.Value;
			workOrderList.UnitOfAddition = this.txtUnitOfAddition.Text;
			workOrderList.ExtraWorkHourRate = (decimal?)this.txtExtraWorkHourRate.Value;
			workOrderList.NightShiftPerc = (decimal?)this.txtNightShiftPerc.Value;
			workOrderList.Description = this.txtDescription.Text;
			workOrderList.FKJobOrderMasterID = fkjobOrderMasterID;
			return workOrderList;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00003322 File Offset: 0x00001522
		protected void GdvWorkOrderList_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
		{
			this.GdvWorkOrderList.DataBind();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00002071 File Offset: 0x00000271
		protected void flRefresh_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00011F90 File Offset: 0x00010190
		protected void GdvJobOrderDetailsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.CellType == GridViewTableCommandCellType.Data)
			{
				if (e.ButtonID == "btnWorkOrder")
				{
					int id = Convert.ToInt32(this.GdvJobOrderDetailsList.GetRowValues(e.VisibleIndex, new string[]
					{
						"FKPriceUnitID"
					}));
					if (new PriceUnitListDB().GetByID(id).UnitType == 0)
					{
						e.Visible = DefaultBoolean.False;
						return;
					}
				}
				else if (e.ButtonID == "btnWarning")
				{
					int num = Convert.ToInt32(this.GdvJobOrderDetailsList.GetRowValues(e.VisibleIndex, new string[]
					{
						"Status"
					}));
					if (num == 1)
					{
						e.Visible = DefaultBoolean.True;
						this.lblWarning.Text = "Warning: Duplicate service! Price and Minimum Quantity will be overwritten from new service.";
					}
				}
			}
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001206C File Offset: 0x0001026C
		protected void btnAddQuotaion_Click(object sender, EventArgs e)
		{
			List<JobOrderDetails> list = this.Session["NewJobOrderDetailsList"] as List<JobOrderDetails>;
			List<JobOrderDetails> list2 = this.Session["JobOrderDetailsList"] as List<JobOrderDetails>;
            //var num2 = (from x in list
            //             select x.IsEnable).FirstOrDefault();

            //var xx1 = list.Where(s => s.IsEnable == false).FirstOrDefault();
            var xx2 = list.FirstOrDefault();
            var xx1 = list2.FirstOrDefault();

            //if (xx2.IsEnable == true && xx1.IsEnable ==true)
            //{
            //    //ASPxButton1.visible = true;

            //    ASPxLabel2.Text="Inactive the active existing same service to update qoutation";
            //}
            //else
            //{
            var existfile = list2.ToArray();
            var newfile = list.ToArray();

            foreach (var rr in existfile)
                {
                    foreach (var rr1 in newfile)
                    {
                        if (rr.IsEnable == true && rr.FKTestID == rr1.FKTestID && rr.FKMaterialDetailsID==rr1.FKMaterialDetailsID)
                        {
                            //throw new Exception(message);
                            ASPxLabel2.Text = "Inactive the active existing same service to update qoutation";
                            continue;

                        }

                        else
                        {
                            foreach (JobOrderDetails jobOrderDetails in list2)
                            {
                                foreach (JobOrderDetails jobOrderDetails2 in list)
                                {
                                    if (jobOrderDetails.FKMaterialDetailsID == jobOrderDetails2.FKMaterialDetailsID && jobOrderDetails.FKMaterialTypeID == jobOrderDetails2.FKMaterialTypeID && jobOrderDetails.FKTestID == jobOrderDetails2.FKTestID)
                                    {
                                        jobOrderDetails.Price = jobOrderDetails2.Price;
                                        jobOrderDetails.MinQty = jobOrderDetails2.MinQty;
                                        jobOrderDetails.FKPriceUnitID = 3;
                                        jobOrderDetails.RowStatus = 2;
                                    jobOrderDetails.IsEnable = true;
                                        object obj = this.Session["WorkOrderList"];
                                        if (this.Session["NewWorkOrderList"] != null)
                                        {
                                            List<WorkOrderList> list3 = this.Session["NewWorkOrderList"] as List<WorkOrderList>;
                                            foreach (WorkOrderList workOrderList in list3)
                                            {
                                                if (workOrderList.FKJobOrderDetailsID == jobOrderDetails2.JobOrderDetailsID && jobOrderDetails.WorkOrderList.Count > 0)
                                                {
                                                    workOrderList.FKJobOrderDetailsID = jobOrderDetails.WorkOrderList.FirstOrDefault<WorkOrderList>().FKJobOrderDetailsID;
                                                    jobOrderDetails.WorkOrderList.Add(workOrderList);
                                                }
                                            }
                                            this.Session["NewWorkOrderList"] = list3;
                                        }
                                        jobOrderDetails2.RowStatus = 2;
                                    }
                                }
                            }

                            using (List<JobOrderDetails>.Enumerator enumerator4 = list.GetEnumerator())
                            {
                                while (enumerator4.MoveNext())
                                {
                                    JobOrderDetails item = enumerator4.Current;
                                    if (item.RowStatus != 2)
                                    {
                                        if (this.Session["NewWorkOrderList"] != null)
                                        {
                                            List<WorkOrderList> source = this.Session["NewWorkOrderList"] as List<WorkOrderList>;
                                            item.WorkOrderList = (from x in source
                                                                  where x.FKJobOrderDetailsID == item.JobOrderDetailsID
                                                                  select x).ToList<WorkOrderList>();
                                        }
                                        list2.Add(item);
                                    }
                                }
                            }
                            if (this.Session["NewWorkOrderList"] != null)
                            {
                                List<WorkOrderList> collection = this.Session["NewWorkOrderList"] as List<WorkOrderList>;
                                List<WorkOrderList> list4 = this.Session["WorkOrderList"] as List<WorkOrderList>;
                                list4.AddRange(collection);
                                this.Session["WorkOrderList"] = list4;
                            }
                            this.Session["JobOrderDetailsList"] = list2;
                            this.PopQutaion.ShowOnPageLoad = false;
                            this.GdvJobOrderDetailsList.DataBind();
                            this.WorkOrderListDS.DataBind();
                            long? num = (from x in list
                                         select x.FKQuotationDetailsID).FirstOrDefault<long?>();
                            if (num != null)
                            {
                                long fkquotationMasterID = new QuotationDetailsDB().GetByID(num.Value).FKQuotationMasterID;
                                QuotationMaster byID = new QuotationMasterDB().GetByID(fkquotationMasterID);
                                byID.IsAddedTojo = new bool?(true);
                                byID.IsActive = true;
                                new QuotationMasterDB().Update(byID);
                            }
                        }
                    }
                this.PopQutaion.ShowOnPageLoad = false;
            }
            

        }

		// Token: 0x06000205 RID: 517 RVA: 0x00002071 File Offset: 0x00000271
		protected void PopQutaion_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000124B0 File Offset: 0x000106B0
		protected void CmbQuotation_SelectedIndexChanged(object sender, EventArgs e)
		{
			long num = Convert.ToInt64(this.CmbQuotation.Value);
			this.lblQutaionMasterId.Text = num.ToString();
			QuotationMaster byID = new QuotationMasterDB().GetByID(num);
			this.cmbCustomer.Value = byID.FKCustomerID;
			this.cmbProject.Value = byID.FKProjectID;
			List<ViewQuotationDetails> byMasterIDWithSession = new QuotationDetailsDB().GetByMasterIDWithSession(num);
			List<JobOrderDetails> list = new List<JobOrderDetails>();
			List<WorkOrderList> list2 = new List<WorkOrderList>();
			new TestPricesDB();
			foreach (ViewQuotationDetails viewQuotationDetails in byMasterIDWithSession)
			{
				QuotationDetails byID2 = new QuotationDetailsDB().GetByID(viewQuotationDetails.QuotationDetailsID);
				JobOrderDetails jobOrderDetails = new JobOrderDetails();
				jobOrderDetails.JobOrderDetailsID = (long)(list.Count + 1);
				jobOrderDetails.FKQuotationDetailsID = new long?(viewQuotationDetails.QuotationDetailsID);
				jobOrderDetails.FKTestID = viewQuotationDetails.FKTestID;
				jobOrderDetails.FKMaterialTypeID = viewQuotationDetails.FKMaterialTypeID;
				jobOrderDetails.FKMaterialDetailsID = viewQuotationDetails.FKMaterialDetailsID;
				jobOrderDetails.FKPriceUnitID = viewQuotationDetails.FKPriceUnitID;
				jobOrderDetails.Remarks = viewQuotationDetails.Remarks;
				jobOrderDetails.Price = viewQuotationDetails.Price;
				jobOrderDetails.MinQty = viewQuotationDetails.MinQty;
				jobOrderDetails.RowStatus = 1;
                jobOrderDetails.IsEnable = true;
                foreach (QuotationWorkOrderList quotationWorkOrderList in byID2.QuotationWorkOrderList)
				{
					list2.Add(new WorkOrderList
					{
						WorkOrderID = (long)(list2.Count + 1),
						EndDate = quotationWorkOrderList.EndDate,
						ExtraWorkHourRate = quotationWorkOrderList.ExtraWorkHourRate,
						FKAgreementID = quotationWorkOrderList.FKAgreementID,
						FKJobOrderDetailsID = new long?((long)(list.Count + 1)),
						MonthlyRate = quotationWorkOrderList.MonthlyRate,
						NightShiftPerc = quotationWorkOrderList.NightShiftPerc,
						Description = quotationWorkOrderList.Description,
						RamadanWorkHrs = quotationWorkOrderList.RamadanWorkHrs,
						RegularWorkHrs = quotationWorkOrderList.RegularWorkHrs,
						ShiftStatus = quotationWorkOrderList.ShiftStatus,
						SiteName = quotationWorkOrderList.SiteName,
						StartDate = quotationWorkOrderList.StartDate,
						TransDate = quotationWorkOrderList.TransDate,
						WorkOrderNo = new WorkOrderListDB().GetWorkOrderNo(),
						RowStatus = 1
					});
				}
				list.Add(jobOrderDetails);
			}
			this.Session["NewJobOrderDetailsList"] = list;
			this.GdvCustomerQuotaion.DataBind();
			this.Session["NewWorkOrderList"] = list2;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvCustomerQuotaion_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000127A8 File Offset: 0x000109A8
		protected void GdvCustomerQuotaion_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.CellType == GridViewTableCommandCellType.Data)
			{
				if (e.ButtonID == "btnCustomerWorkOrder")
				{
					int id = Convert.ToInt32(this.GdvCustomerQuotaion.GetRowValues(e.VisibleIndex, new string[]
					{
						"FKPriceUnitID"
					}));
					if (new PriceUnitListDB().GetByID(id).UnitType == 1)
					{
						e.Visible = DefaultBoolean.True;
						return;
					}
				}
				else if (e.ButtonID == "btnWarning")
				{
					int num = Convert.ToInt32(this.GdvCustomerQuotaion.GetRowValues(e.VisibleIndex, new string[]
					{
						"Status"
					}));
					if (num == 1)
					{
						e.Visible = DefaultBoolean.True;
						this.lblWarning.Text = "Warning: Duplicate service! Price and Minimum Quantity will be overwritten from new service.";
					}
				}
			}
		}

        protected void chk_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;
            chk.ClientSideEvents.CheckedChanged = String.Format("function (s, e) {{ cb.PerformCallback('{0}|' + s.GetChecked()); }}", container.KeyValue);
        }

        protected void cb_Callback(object source, CallbackEventArgs e)
        {
            string[] values = e.Parameter.Split('|');
            if (values.Length < 1)
                return;

            int jobOrderDetailId = 0;
            if (!int.TryParse(values[0], out jobOrderDetailId))
                return;

            bool isEnable = false;
            if (!bool.TryParse(values[1], out isEnable))
                return;
           
            new JobOrderDetailsDB().UpdateEnable(jobOrderDetailId, isEnable);
        }

        // Token: 0x06000209 RID: 521 RVA: 0x00012884 File Offset: 0x00010A84
        protected void btnApprove_Click(object sender, EventArgs e)
		{
			int num;
			if ((sender as ASPxButton).ID == "btnApprove")
			{
				num = 1;
			}
			else
			{
				num = 2;
			}
			this.Session["action"] = num;
			this.JobOrderMasterDS.Update();
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000128D4 File Offset: 0x00010AD4
		public void Clearpage()
		{
			this.txtExtraWorkHourRate.Text = "";
			this.txtJobOrderNumber.Text = "";
			this.txtLPONumber.Text = "";
			this.txtMonthlyRate.Text = "";
			this.txtNightShiftPerc.Text = "";
			this.txtRamadanWorkHrs.Text = "";
			this.txtReceiveCreditLimit.Text = "";
			this.txtRegularWorkHrs.Text = "";
			this.txtRemarks.Text = "";
			this.txtReportCreditLimit.Text = "";
			this.txtSiteName.Text = "";
			this.txtUnitOfAddition.Text = "";
			this.txtUnpaidReceiveLimit.Text = "";
			this.txtWorkOrderNo.Text = "";
			this.cmbCustomer.Value = null;
			this.cmbFKCustomerID.Value = null;
			this.cmbFKProjectID.Value = null;
			this.cmbFKQuotationMasterID.Value = null;
			this.cmbProject.Value = null;
			this.CmbQuotation.Value = null;
			this.cmbShiftStatus.Value = null;
			this.IsActive.Checked = false;
			this.lblMasterId.Text = "0";
			this.Session["NewJobOrderDetailsList"] = null;
			this.GdvCustomerQuotaion.DataBind();
			this.dtExpiryDate.Value = null;
		}

		// Token: 0x040002CD RID: 717
		protected HtmlGenericControl ultitle;

		// Token: 0x040002CE RID: 718
		protected ASPxLabel lblView;

		// Token: 0x040002CF RID: 719
		protected ASPxLabel lblEdite;

		// Token: 0x040002D0 RID: 720
		protected ASPxLabel lblDelete;

		// Token: 0x040002D1 RID: 721
		protected ASPxLabel lblAdd;

		// Token: 0x040002D2 RID: 722
		protected ASPxButton BtnSave;

		// Token: 0x040002D3 RID: 723
		protected ASPxButton BtnBack;

		// Token: 0x040002D4 RID: 724
		protected HtmlGenericControl divmsg;

		// Token: 0x040002D5 RID: 725
		protected ASPxLabel LblError;

		// Token: 0x040002D6 RID: 726
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x040002D7 RID: 727
		protected ASPxLabel lblMasterId;

		// Token: 0x040002D8 RID: 728
		protected ASPxLabel lblQutaionMasterId;

		// Token: 0x040002D9 RID: 729
		protected ASPxLabel lblActiveMasterId;

		// Token: 0x040002DA RID: 730
		protected ASPxFormLayout flJobOrderMaster;

		// Token: 0x040002DB RID: 731
		protected ASPxCheckBox IsActive;

		// Token: 0x040002DC RID: 732
		protected ASPxTextBox txtJobOrderNumber;

		// Token: 0x040002DD RID: 733
		protected ASPxDateEdit dtTransactionDate;

		// Token: 0x040002DE RID: 734
		protected ASPxComboBox cmbFKQuotationMasterID;

		// Token: 0x040002DF RID: 735
		protected ASPxButton btnAddQuotation;

		// Token: 0x040002E0 RID: 736
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x040002E1 RID: 737
		protected ASPxTextBox txtLPONumber;

		// Token: 0x040002E2 RID: 738
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x040002E3 RID: 739
		protected ASPxDateEdit dtExpiryDate;

		// Token: 0x040002E4 RID: 740
		protected ASPxMemo txtRemarks;

		// Token: 0x040002E5 RID: 741
		protected ASPxButton btnAddNewDetail;

		// Token: 0x040002E6 RID: 742
		protected ASPxGridView GdvJobOrderDetailsList;

		// Token: 0x040002E7 RID: 743
		protected GridViewCommandColumnCustomButton btnWarning;

		// Token: 0x040002E8 RID: 744
		protected GridViewCommandColumnCustomButton btnWorkOrder;

		// Token: 0x040002E9 RID: 745
		protected ASPxLabel lblWarning;
        protected ASPxLabel ASPxLabel2;

        

        // Token: 0x040002EA RID: 746
        protected ASPxSpinEdit txtReceiveCreditLimit;

		// Token: 0x040002EB RID: 747
		protected ASPxSpinEdit txtReportCreditLimit;

		// Token: 0x040002EC RID: 748
		protected ASPxSpinEdit txtUnpaidReceiveLimit;

		// Token: 0x040002ED RID: 749
		protected ASPxPopupControl PopQutaion;

		// Token: 0x040002EE RID: 750
		protected PopupControlContentControl PopupControlContentControl2;

		// Token: 0x040002EF RID: 751
		protected ASPxCallbackPanel ASPxCallbackPanel1;

		// Token: 0x040002F0 RID: 752
		protected ASPxFormLayout flCustomerJobOrderMaster;

		// Token: 0x040002F1 RID: 753
		protected ASPxComboBox CmbQuotation;

		// Token: 0x040002F2 RID: 754
		protected ASPxComboBox cmbCustomer;

		// Token: 0x040002F3 RID: 755
		protected ASPxComboBox cmbProject;

		// Token: 0x040002F4 RID: 756
		protected ASPxGridView GdvCustomerQuotaion;

		// Token: 0x040002F5 RID: 757
		protected GridViewCommandColumnCustomButton btnCustomerWorkOrder;

		// Token: 0x040002F6 RID: 758
		protected ASPxPopupControl popTestLists;

		// Token: 0x040002F7 RID: 759
		protected PopupControlContentControl PopupControlContentControl;

		// Token: 0x040002F8 RID: 760
		protected ASPxCheckBoxList lstTests;

		// Token: 0x040002F9 RID: 761
		protected ASPxGridView GdvLabTestsList;

		// Token: 0x040002FA RID: 762
		protected ASPxPopupControl popupWorkOrder;

		// Token: 0x040002FB RID: 763
		protected PopupControlContentControl PopupControlContentControl1;

		// Token: 0x040002FC RID: 764
		protected ASPxValidationSummary ASPxValidationSummary2;

		// Token: 0x040002FD RID: 765
		protected ASPxTextBox vi;

		// Token: 0x040002FE RID: 766
		protected ASPxTextBox vid;

		// Token: 0x040002FF RID: 767
		protected ASPxTextBox sid;

		// Token: 0x04000300 RID: 768
		protected ASPxButton flRefresh;

		// Token: 0x04000301 RID: 769
		protected ASPxCallbackPanel cpnl;

		// Token: 0x04000302 RID: 770
		protected ASPxFormLayout flWorkOrder;

		// Token: 0x04000303 RID: 771
		protected ASPxTextBox txtWorkOrderNo;

		// Token: 0x04000304 RID: 772
		protected ASPxDateEdit dtTransDate;

		// Token: 0x04000305 RID: 773
		protected ASPxDateEdit dtStartDate;

		// Token: 0x04000306 RID: 774
		protected ASPxDateEdit dtEndDate;

		// Token: 0x04000307 RID: 775
		protected ASPxTextBox txtSiteName;

		// Token: 0x04000308 RID: 776
		protected ASPxComboBox cmbShiftStatus;

		// Token: 0x04000309 RID: 777
		protected ASPxSpinEdit txtRegularWorkHrs;

		// Token: 0x0400030A RID: 778
		protected ASPxSpinEdit txtRamadanWorkHrs;

		// Token: 0x0400030B RID: 779
		protected ASPxSpinEdit txtMonthlyRate;

		// Token: 0x0400030C RID: 780
		protected ASPxTextBox txtUnitOfAddition;

		// Token: 0x0400030D RID: 781
		protected ASPxSpinEdit txtExtraWorkHourRate;

		// Token: 0x0400030E RID: 782
		protected ASPxSpinEdit txtNightShiftPerc;

		// Token: 0x0400030F RID: 783
		protected ASPxTextBox txtDescription;

		// Token: 0x04000310 RID: 784
		protected ASPxLabel lblErrorMessage;

		// Token: 0x04000311 RID: 785
		protected ASPxButton btnUpdateWorkOrder;

		// Token: 0x04000312 RID: 786
		protected ASPxButton btnCancelUpdateWorkOrder;

		// Token: 0x04000313 RID: 787
		protected ASPxGridView GdvWorkOrderList;

		// Token: 0x04000314 RID: 788
		protected GridViewCommandColumnCustomButton WorkOrderEdit;

		// Token: 0x04000315 RID: 789
		protected HtmlGenericControl divConfirmSection;

		// Token: 0x04000316 RID: 790
		protected ASPxButton btnApprove;

		// Token: 0x04000317 RID: 791
		protected ObjectDataSource QuotationMasterDS;

		// Token: 0x04000318 RID: 792
		protected ObjectDataSource CustomerQuotaionDS;

		// Token: 0x04000319 RID: 793
		protected ObjectDataSource MaterialsTypesDS;

		// Token: 0x0400031A RID: 794
		protected ObjectDataSource AllMaterialsListDS;

		// Token: 0x0400031B RID: 795
		protected ObjectDataSource MaterialsListDS;

		// Token: 0x0400031C RID: 796
		protected ObjectDataSource CustomersListDS;

		// Token: 0x0400031D RID: 797
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x0400031E RID: 798
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x0400031F RID: 799
		protected ObjectDataSource CustomerJobOrderMasterDS;

		// Token: 0x04000320 RID: 800
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x04000321 RID: 801
		protected ObjectDataSource TestPriceUnitListDS;

		// Token: 0x04000322 RID: 802
		protected ObjectDataSource TestsListDS;

		// Token: 0x04000323 RID: 803
		protected ObjectDataSource JobOrderDetailsDS;

		// Token: 0x04000324 RID: 804
		protected ObjectDataSource CustomerJobOrderDetailsDS;

		// Token: 0x04000325 RID: 805
		protected ObjectDataSource WorkOrderDS;

		// Token: 0x04000326 RID: 806
		protected ObjectDataSource WorkOrderListDS;
	}
}
