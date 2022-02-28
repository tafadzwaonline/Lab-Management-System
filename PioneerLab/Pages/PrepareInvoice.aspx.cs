using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Pages;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x0200002C RID: 44
	public class PrepareInvoice : Page
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0000DC34 File Offset: 0x0000BE34
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Session["JobOrderDetailsList"] = null;
				this.Session["WorkOrderList"] = null;
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.flJobOrderMaster.DataBind();
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000DCA0 File Offset: 0x0000BEA0
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				long num2 = Convert.ToInt64(this.lblActiveMasterId.Text);
				if (num > 0L || num2 > 0L)
				{
					this.JobOrderMasterDS.Update();
				}
				else
				{
					this.JobOrderMasterDS.Insert();
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00002F68 File Offset: 0x00001168
		protected void JobOrderMasterDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			new JobOrderMaster();
			e.InputParameters["entity"] = this.GetMasterEntity(0L);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00002F88 File Offset: 0x00001188
		protected void JobOrderMasterDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000DD44 File Offset: 0x0000BF44
		protected void JobOrderMasterDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			long masterID = Convert.ToInt64(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000DD7C File Offset: 0x0000BF7C
		private JobOrderMaster GetMasterEntity(long MasterID)
		{
			long num = Convert.ToInt64(this.lblActiveMasterId.Text);
			if (num > 0L)
			{
				MasterID = num;
			}
			JobOrderMaster result;
			if (MasterID > 0L)
			{
				result = new JobOrderMasterDB().GetByID(MasterID);
			}
			else
			{
				result = new JobOrderMaster();
			}
			return result;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00002FC4 File Offset: 0x000011C4
		protected void JobOrderMasterDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00003000 File Offset: 0x00001200
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("JobOrderManage.aspx");
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000DDC4 File Offset: 0x0000BFC4
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

		// Token: 0x06000188 RID: 392 RVA: 0x0000DE60 File Offset: 0x0000C060
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
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000DFA8 File Offset: 0x0000C1A8
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
				return;
			}
			e.Cancel = true;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000E1C8 File Offset: 0x0000C3C8
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
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00002071 File Offset: 0x00000271
		protected void flRefresh_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000E300 File Offset: 0x0000C500
		protected void GdvJobOrderDetailsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (e.CellType == GridViewTableCommandCellType.Data && e.ButtonID == "btnWorkOrder")
			{
				int id = Convert.ToInt32(this.GdvJobOrderDetailsList.GetRowValues(e.VisibleIndex, new string[]
				{
					"FKPriceUnitID"
				}));
				if (new PriceUnitListDB().GetByID(id).UnitType == 2)
				{
					e.Visible = DefaultBoolean.False;
				}
			}
		}

		// Token: 0x0400022D RID: 557
		protected HtmlGenericControl ultitle;

		// Token: 0x0400022E RID: 558
		protected ASPxButton BtnSave;

		// Token: 0x0400022F RID: 559
		protected ASPxButton BtnBack;

		// Token: 0x04000230 RID: 560
		protected HtmlGenericControl divmsg;

		// Token: 0x04000231 RID: 561
		protected ASPxLabel LblError;

		// Token: 0x04000232 RID: 562
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000233 RID: 563
		protected ASPxLabel lblMasterId;

		// Token: 0x04000234 RID: 564
		protected ASPxLabel lblActiveMasterId;

		// Token: 0x04000235 RID: 565
		protected ASPxFormLayout flJobOrderMaster;

		// Token: 0x04000236 RID: 566
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x04000237 RID: 567
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x04000238 RID: 568
		protected ASPxDateEdit dtExpiryDate;

		// Token: 0x04000239 RID: 569
		protected ASPxDateEdit dtTransactionDate;

		// Token: 0x0400023A RID: 570
		protected ASPxButton btnSearch;

		// Token: 0x0400023B RID: 571
		protected ASPxGridView GdvJobOrderDetailsList;

		// Token: 0x0400023C RID: 572
		protected GridViewCommandColumnCustomButton btnWorkOrder;

		// Token: 0x0400023D RID: 573
		protected ASPxTextBox txtWorkOrderNo;

		// Token: 0x0400023E RID: 574
		protected ASPxDateEdit dtTransDate;

		// Token: 0x0400023F RID: 575
		protected ASPxTextBox txtFKAgreementID;

		// Token: 0x04000240 RID: 576
		protected ASPxMemo txtRemarks;

		// Token: 0x04000241 RID: 577
		protected ASPxButton ASPxButton1;

		// Token: 0x04000242 RID: 578
		protected ObjectDataSource QuotationMasterDS;

		// Token: 0x04000243 RID: 579
		protected ObjectDataSource MaterialsTypesDS;

		// Token: 0x04000244 RID: 580
		protected ObjectDataSource AllMaterialsListDS;

		// Token: 0x04000245 RID: 581
		protected ObjectDataSource MaterialsListDS;

		// Token: 0x04000246 RID: 582
		protected ObjectDataSource CustomersListDS;

		// Token: 0x04000247 RID: 583
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x04000248 RID: 584
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x04000249 RID: 585
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x0400024A RID: 586
		protected ObjectDataSource TestPriceUnitListDS;

		// Token: 0x0400024B RID: 587
		protected ObjectDataSource TestsListDS;

		// Token: 0x0400024C RID: 588
		protected ObjectDataSource JobOrderDetailsDS;
	}
}
