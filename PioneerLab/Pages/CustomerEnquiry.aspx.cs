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
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x0200003C RID: 60
	public class CustomerEnquiry : Page
	{
		// Token: 0x0600024D RID: 589 RVA: 0x00014DFC File Offset: 0x00012FFC
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
				this.Session["EnquiryDetailsList"] = null;
				long num = Convert.ToInt64(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				if (num != 0L)
				{
					this.flEnquiryMaster.DataBind();
					return;
				}
				EnquiryMasterDB enquiryMasterDB = new EnquiryMasterDB();
				this.txtEnquiryCode.Text = enquiryMasterDB.GetNewSerial();
				ADMUsers admusers = this.Session["CurrentUser"] as ADMUsers;
				this.dtEntryDate.Value = DateTime.Today.Date;
				this.txtEnterdBy.Text = ((admusers != null) ? admusers.EName : "");
				if (base.Request["cid"] != null)
				{
					this.CopyEnquiry(Convert.ToInt64(base.Request["cid"]));
				}
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00014FE8 File Offset: 0x000131E8
		private void CopyEnquiry(long MasterID)
		{
			this.BtnSave.Text = "Save Copy";
			EnquiryMaster byID = new EnquiryMasterDB().GetByID(MasterID);
			this.cmbEnquiryMethodID.Value = byID.EnquiryMethodID;
			this.txtCustomerReference.Text = byID.CustomerReference;
			this.txtContactPerson.Text = byID.ContactPerson;
			this.txtContactNumber.Text = byID.ContactNumber;
			this.txtContactJobTitle.Text = byID.ContactJobTitle;
			this.txtContactEmail.Text = byID.ContactEmail;
			this.cmbPaymentMode.Value = byID.CustomersList.PaymentMode;
			this.cmbFKCustomerID.Value = byID.FKCustomerID;
			this.cmbFKProjectID.Value = byID.FKProjectID;
			this.txtRemarks.Text = byID.Remarks;
			List<EnquiryDetails> list = new List<EnquiryDetails>();
			foreach (EnquiryDetails enquiryDetails in byID.EnquiryDetails.ToList<EnquiryDetails>())
			{
				list.Add(new EnquiryDetails
				{
					EnquiryDetailsID = (long)(list.Count + 1),
					FKEnquiryMasterID = 0L,
					FKMaterialTypeID = enquiryDetails.FKMaterialTypeID,
					FKMaterialDetailsID = enquiryDetails.FKMaterialDetailsID,
					FKTestID = enquiryDetails.FKTestID,
					FKPriceUnitID = enquiryDetails.FKPriceUnitID,
					Remarks = enquiryDetails.Remarks
				});
			}
			this.Session["EnquiryDetailsList"] = list;
			this.GdvEnquiryDetailsList.DataBind();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0001519C File Offset: 0x0001339C
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.EnquiryMasterDS.Update();
						base.Response.Redirect("CustomerEnquiryManage.aspx");
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
					this.EnquiryMasterDS.Insert();
					base.Response.Redirect("CustomerEnquiryManage.aspx");
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

		// Token: 0x06000250 RID: 592 RVA: 0x0001531C File Offset: 0x0001351C
		private EnquiryMaster GetMasterEntity(int MasterID)
		{
			EnquiryMaster enquiryMaster;
			if (MasterID > 0)
			{
				enquiryMaster = new EnquiryMasterDB().GetByID((long)MasterID);
				enquiryMaster.EnquiryCode = this.txtEnquiryCode.Text;
			}
			else
			{
				enquiryMaster = new EnquiryMaster();
				enquiryMaster.EnquiryCode = new EnquiryMasterDB().GetNewSerial();
			}
			enquiryMaster.TransactionDate = DateTime.Today;
			enquiryMaster.EntryDate = (DateTime?)this.dtEntryDate.Value;
			enquiryMaster.EnquiryMethodID = new int?(Convert.ToInt32(this.cmbEnquiryMethodID.Value));
			enquiryMaster.CustomerReference = this.txtCustomerReference.Text;
			enquiryMaster.ContactPerson = this.txtContactPerson.Text;
			enquiryMaster.ContactNumber = this.txtContactNumber.Text;
			enquiryMaster.ContactJobTitle = this.txtContactJobTitle.Text;
			enquiryMaster.ContactEmail = this.txtContactEmail.Text;
			enquiryMaster.FKCustomerID = Convert.ToInt32(this.cmbFKCustomerID.Value);
			enquiryMaster.FKProjectID = Convert.ToInt32(this.cmbFKProjectID.Value);
			enquiryMaster.Remarks = this.txtRemarks.Text;
			enquiryMaster.EnterdBy = this.txtEnterdBy.Text;
			enquiryMaster.IsClosed = false;
			enquiryMaster.ReceivingDate = (DateTime?)this.dtEntryDate.Value;
			return enquiryMaster;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000034A5 File Offset: 0x000016A5
		protected void EnquiryMasterDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000034BE File Offset: 0x000016BE
		protected void EnquiryMasterDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00015460 File Offset: 0x00013660
		protected void EnquiryMasterDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000034FA File Offset: 0x000016FA
		protected void EnquiryMasterDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00003536 File Offset: 0x00001736
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("CustomerEnquiryManage.aspx");
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00015498 File Offset: 0x00013698
		protected void lstTests_DataBound(object sender, EventArgs e)
		{
			ASPxCheckBoxList aspxCheckBoxList = (ASPxCheckBoxList)sender;
			List<EnquiryDetails> source = this.EnquiryDetailsDS.Select() as List<EnquiryDetails>;
			List<int> list = (from x in source
			select x.FKTestID).ToList<int>();
			for (int i = 0; i < aspxCheckBoxList.Items.Count; i++)
			{
				aspxCheckBoxList.Items[i].Selected = list.Contains((int)aspxCheckBoxList.Items[i].Value);
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00003548 File Offset: 0x00001748
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			this.EnquiryDetailsDS.Insert();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0001552C File Offset: 0x0001372C
		protected void EnquiryDetailsDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			object value = this.cmbFKMaterialTypeID.Value;
			object value2 = this.cmbFKMaterialDetailsID.Value;
			object value3 = this.CmbUnit.Value;
			List<object> selectedFieldValues = this.GdvLabTestsList.GetSelectedFieldValues(new string[]
			{
				"TestID"
			});
			List<EnquiryDetails> list = new List<EnquiryDetails>();
			foreach (object value4 in selectedFieldValues)
			{
				EnquiryDetails enquiryDetails = new EnquiryDetails();                
                enquiryDetails.FKEnquiryMasterID = (long)num;
				enquiryDetails.FKMaterialTypeID = (int?)value;
				enquiryDetails.FKMaterialDetailsID = (int?)value2;
				enquiryDetails.FKTestID = Convert.ToInt32(value4);
                if (value3 != null)
                {
                    enquiryDetails.FKPriceUnitID = (int)value3;
                }
                else
                {
                    enquiryDetails.FKPriceUnitID = new TestPricesDB().GetFirstPriceUnitByTestID(enquiryDetails.FKTestID).FKPriceUnitID;
                }
                list.Add(enquiryDetails);

                TestsList mandatoryTest = new TestsListDB().GetByID(Convert.ToInt32(value4));
                EnquiryDetails mandatoryEnquiryDetails = new EnquiryDetails();
                if (mandatoryTest != null && mandatoryTest.FKTestID.HasValue && enquiryDetails != null)
                {
                    mandatoryEnquiryDetails.FKEnquiryMasterID = enquiryDetails.FKEnquiryMasterID;
                    mandatoryEnquiryDetails.FKMaterialTypeID = enquiryDetails.FKMaterialTypeID;
                    mandatoryEnquiryDetails.FKMaterialDetailsID = enquiryDetails.FKMaterialDetailsID;
                    mandatoryEnquiryDetails.FKTestID = Convert.ToInt32(mandatoryTest.FKTestID);
                    if (enquiryDetails.FKPriceUnitID != 0)
                        mandatoryEnquiryDetails.FKPriceUnitID = enquiryDetails.FKPriceUnitID;
                    else
                        mandatoryEnquiryDetails.FKPriceUnitID = new TestPricesDB().GetFirstPriceUnitByTestID(mandatoryEnquiryDetails.FKTestID).FKPriceUnitID;

                    list.Add(mandatoryEnquiryDetails);
                }
            }
			if (list.Count == 0)
			{
				list.Add(new EnquiryDetails
				{
					FKEnquiryMasterID = (long)num,
					FKTestID = 0
				});
			}
			e.InputParameters["entityList"] = list;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00003556 File Offset: 0x00001756
		protected void EnquiryDetailsDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.popTestLists.ShowOnPageLoad = false;
			this.GdvEnquiryDetailsList.DataBind();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000356F File Offset: 0x0000176F
		protected void popTestLists_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
			this.lstTests.DataBind();
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00015684 File Offset: 0x00013884
		protected void GdvEnquiryDetailsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			if (e.Column.FieldName == "FKPriceUnitID")
			{
				object rowValues = this.GdvEnquiryDetailsList.GetRowValues(e.VisibleIndex, new string[]
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

		// Token: 0x0600025C RID: 604 RVA: 0x00015720 File Offset: 0x00013920
		protected void EnquiryDetailsDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			if (this.Session["NewEnquiryDetailsID"] != null)
			{
				long fkenquiryMasterID = Convert.ToInt64(this.lblMasterId.Text);
				EnquiryDetails enquiryDetails = new EnquiryDetails();
				enquiryDetails.EnquiryDetailsID = (long)Convert.ToInt32(this.Session["NewEnquiryDetailsID"]);
				enquiryDetails.FKEnquiryMasterID = fkenquiryMasterID;
				enquiryDetails.FKTestID = Convert.ToInt32(this.Session["NewFKTestID"]);
				enquiryDetails.FKMaterialTypeID = (int?)this.Session["FKMaterialTypeID"];
				enquiryDetails.FKMaterialDetailsID = (int?)this.Session["FKMaterialDetailsID"];
				enquiryDetails.FKPriceUnitID = Convert.ToInt32(this.Session["NewFKPriceUnitID"]);
				enquiryDetails.Remarks = this.Session["NewRemarks"].ToString();
				e.InputParameters["entity"] = enquiryDetails;
				e.InputParameters["original_EnquiryDetailsID"] = Convert.ToInt32(this.Session["NewEnquiryDetailsID"]);
				this.Session["NewEnquiryDetailsID"] = null;
				this.Session["NewFKTestID"] = null;
				this.Session["FKMaterialTypeID"] = null;
				this.Session["FKMaterialDetailsID"] = null;
				this.Session["NewFKPriceUnitID"] = null;
				this.Session["NewRemarks"] = null;
				return;
			}
			e.Cancel = true;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000158AC File Offset: 0x00013AAC
		protected void GdvEnquiryDetailsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			this.Session["NewEnquiryDetailsID"] = e.Keys["EnquiryDetailsID"];
			this.Session["NewFKTestID"] = e.NewValues["FKTestID"];
			this.Session["FKMaterialTypeID"] = e.NewValues["FKMaterialTypeID"];
			this.Session["FKMaterialDetailsID"] = e.NewValues["FKMaterialDetailsID"];
			this.Session["NewFKPriceUnitID"] = e.NewValues["FKPriceUnitID"];
			this.Session["NewRemarks"] = ((e.NewValues["Remarks"] == null) ? "" : e.NewValues["Remarks"]);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000357C File Offset: 0x0000177C
		protected void GdvLabTestsList_DataBound(object sender, EventArgs e)
		{
			this.GdvLabTestsList.Selection.UnselectAll();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000358E File Offset: 0x0000178E
		protected void cmbFKCustomerID_Callback(object sender, CallbackEventArgsBase e)
		{
			this.cmbFKCustomerID.DataBind();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000359B File Offset: 0x0000179B
		protected void cmbFKMaterialTypeID_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cmbFKMaterialDetailsID.Value = null;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00015994 File Offset: 0x00013B94
		protected void EnquiryDetailsDS_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			if (this.Session["NewEnquiryDetailsID"] != null)
			{
				long fkenquiryMasterID = Convert.ToInt64(this.lblMasterId.Text);
				EnquiryDetails enquiryDetails = new EnquiryDetails();
				enquiryDetails.EnquiryDetailsID = (long)Convert.ToInt32(this.Session["NewEnquiryDetailsID"]);
				enquiryDetails.FKEnquiryMasterID = fkenquiryMasterID;
				e.InputParameters["entity"] = enquiryDetails;
				e.InputParameters["original_EnquiryDetailsID"] = Convert.ToInt32(this.Session["NewEnquiryDetailsID"]);
				this.Session["NewEnquiryDetailsID"] = null;
				return;
			}
			e.Cancel = true;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000035A9 File Offset: 0x000017A9
		protected void GdvEnquiryDetailsList_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
			this.Session["NewEnquiryDetailsID"] = e.Keys["EnquiryDetailsID"];
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00015A44 File Offset: 0x00013C44
		protected void GdvEnquiryDetailsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "can not delete, alredy converted to Quotation")
			{
				e.ErrorText = "can not delete, alredy converted to Quotation";
			}
			if (e.ErrorText == "can not delete, alredy converted to Quotation")
			{
				e.ErrorText = "can not delete, alredy converted to Quotation";
			}
		}

		// Token: 0x040003A4 RID: 932
		protected HtmlGenericControl ultitle;

		// Token: 0x040003A5 RID: 933
		protected ASPxLabel lblView;

		// Token: 0x040003A6 RID: 934
		protected ASPxLabel lblEdite;

		// Token: 0x040003A7 RID: 935
		protected ASPxLabel lblDelete;

		// Token: 0x040003A8 RID: 936
		protected ASPxLabel lblAdd;

		// Token: 0x040003A9 RID: 937
		protected ASPxButton BtnSave;

		// Token: 0x040003AA RID: 938
		protected ASPxButton BtnBack;

		// Token: 0x040003AB RID: 939
		protected HtmlGenericControl divmsg;

		// Token: 0x040003AC RID: 940
		protected ASPxLabel LblError;

		// Token: 0x040003AD RID: 941
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x040003AE RID: 942
		protected ASPxLabel lblMasterId;

		// Token: 0x040003AF RID: 943
		protected ASPxFormLayout flEnquiryMaster;

		// Token: 0x040003B0 RID: 944
		protected ASPxTextBox txtEnquiryCode;

		// Token: 0x040003B1 RID: 945
		protected ASPxDateEdit dtEntryDate;

		// Token: 0x040003B2 RID: 946
		protected ASPxComboBox cmbEnquiryMethodID;

		// Token: 0x040003B3 RID: 947
		protected ASPxTextBox txtCustomerReference;

		// Token: 0x040003B4 RID: 948
		protected ASPxTextBox txtContactPerson;

		// Token: 0x040003B5 RID: 949
		protected ASPxTextBox txtContactNumber;

		// Token: 0x040003B6 RID: 950
		protected ASPxTextBox txtContactJobTitle;

		// Token: 0x040003B7 RID: 951
		protected ASPxTextBox txtContactEmail;

		// Token: 0x040003B8 RID: 952
		protected ASPxDateEdit dtReceivingDate;

		// Token: 0x040003B9 RID: 953
		protected ASPxComboBox cmbPaymentMode;

		// Token: 0x040003BA RID: 954
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x040003BB RID: 955
		protected ASPxButton btnAddNewCustomer;

		// Token: 0x040003BC RID: 956
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x040003BD RID: 957
		protected ASPxButton btnAddNewProject;

		// Token: 0x040003BE RID: 958
		protected ASPxMemo txtRemarks;

		// Token: 0x040003BF RID: 959
		protected ASPxTextBox txtEnterdBy;

		// Token: 0x040003C0 RID: 960
		protected ASPxButton btnAddNewDetail;

		// Token: 0x040003C1 RID: 961
		protected ASPxGridView GdvEnquiryDetailsList;

		// Token: 0x040003C2 RID: 962
		protected ASPxPopupControl popTestLists;

		// Token: 0x040003C3 RID: 963
		protected PopupControlContentControl PopupControlContentControl;

		// Token: 0x040003C4 RID: 964
		protected ASPxCheckBoxList lstTests;

		// Token: 0x040003C5 RID: 965
		protected ASPxComboBox cmbFKMaterialTypeID;

		// Token: 0x040003C6 RID: 966
		protected ASPxComboBox cmbFKMaterialDetailsID;

		// Token: 0x040003C7 RID: 967
		protected ASPxComboBox CmbUnit;

		// Token: 0x040003C8 RID: 968
		protected ASPxGridView GdvLabTestsList;

		// Token: 0x040003C9 RID: 969
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040003CA RID: 970
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x040003CB RID: 971
		protected ObjectDataSource MaterialsTypesDS;

		// Token: 0x040003CC RID: 972
		protected ObjectDataSource AllMaterialsListDS;

		// Token: 0x040003CD RID: 973
		protected ObjectDataSource MaterialsListDS;

		// Token: 0x040003CE RID: 974
		protected ObjectDataSource EnquiryMasterDS;

		// Token: 0x040003CF RID: 975
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x040003D0 RID: 976
		protected ObjectDataSource TestPriceUnitListDS;

		// Token: 0x040003D1 RID: 977
		protected ObjectDataSource TestsListDS;

		// Token: 0x040003D2 RID: 978
		protected ObjectDataSource ServiceListDS;

		// Token: 0x040003D3 RID: 979
		protected ObjectDataSource EnquiryDetailsDS;
	}
}
