using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
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
	// Token: 0x0200002F RID: 47
	public class SampleReceive : Page
	{
        // Token: 0x17000033 RID: 51
        public const int TransactionTypeID = 22222;
        
        // Token: 0x17000034 RID: 52
        public long TransactionID
        {
            get
            {
                if (this.Session[this._attachTransIDSessionString] != null)
                {
                    return long.Parse(this.Session[this._attachTransIDSessionString].ToString());
                }
                return long.Parse(this.lblMasterId.Text);
            }
            set
            {
                this.Session[this._attachTransIDSessionString] = value.ToString();
                this.lblTransID.Text = value.ToString();
            }
        }

        // Token: 0x17000035 RID: 53
        // (get) Token: 0x060000A9 RID: 169 RVA: 0x000027C8 File Offset: 0x000009C8
        // (set) Token: 0x060000AA RID: 170 RVA: 0x000027D5 File Offset: 0x000009D5
        public string UploadDirectory
        {
            get
            {
                return this.lblUploadDirectory.Text;
            }
            set
            {
                this.lblUploadDirectory.Text = value;
            }
        }

        // Token: 0x0600019C RID: 412 RVA: 0x0000E850 File Offset: 0x0000CA50
        protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/SampleReceiveManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
			base.Response.Clear();
			if (!base.IsPostBack)
			{
				long num = Convert.ToInt64(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.dtReceiveDate.Date = DateTime.Today;
				this.dtReceiveDate.MinDate = DateTime.Today.AddDays(-4.0);
				this.Session["SampleReceiveTestList"] = null;
				this.Session["SampleMaterialCustomFieldList"] = null;
				this.Session["SampleMaterialTableCustomFieldList"] = null;
                this.Session["SampleID"] = null;
                this.Session["NewSRAttachment"] = null;
                this.Session[this._fileListSessionString] = null;
                this.Session[this._unSavedFileListSessionString] = null;
                this.flSampleReceiveList.DataBind();
                //AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                //this.lblTransTypeID.Text = base.Request["TransTypeID"];
                //this.TransactionID = long.Parse(base.Request["TransID"].ToString());
                this.lblTransTypeID.Text = TransactionTypeID.ToString();
                this.TransactionID = long.Parse(lblMasterId.Text);
                //this.txtKeywords.Text = attachedFilesDB.GetKeywords(this.TransactionID, this.TransactionTypeID);
                if (num > 0)
                    this.gdvfiles.DataBind();
                else
                    this.gdvSessionFiles.DataBind();
               
				if (num > 0L)
				{
					this.SetEditMode(num);
					this.CreateCustomTableFieldsColumn();
					this.gdvCustomTableFields.DataBind();
					return;
				}
				this.txtSampleNo.Text = new SampleReceiveListDB().GetNewSerial();
				this.txtRetentionperiod.SelectedIndex = 0;
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000EA3C File Offset: 0x0000CC3C
		private void SetEditMode(long MasterID)
		{
			this.cmbFKJobOrderMasterID.ReadOnly = true;
			this.cmbFKMaterialTypeID.ReadOnly = true;
			this.cmbFKMaterialDetailsID.ReadOnly = true;
			this.BtnDownload.ClientVisible = true;
            this.divattachfile.Visible = true;
            this.divsessionattachfile.Visible = false;
            this.gdvSampleTestList.Selection.UnselectAll();
			this.lblFKMaterialTypeID.Text = new SampleReceiveListDB().GetByID(MasterID).FKMaterialTypeID.ToString();
			List<SampleReceiveTestList> byMasterID = new SampleReceiveTestListDB().GetByMasterID(MasterID);
			List<long> list = (from x in byMasterID
			select x.SampleReceiveTestID).ToList<long>();
			foreach (long num in list)
			{
				this.gdvSampleTestList.Selection.SelectRowByKey(num);
			}
			new SampleReceiveListDB().GetByID(MasterID);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00003094 File Offset: 0x00001294
		protected void BtnBack_Click(object sender, EventArgs e)
		{
            this.Session["NewSRAttachment"] = null;
            base.Response.Redirect("SampleReceiveManage.aspx");
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000EB44 File Offset: 0x0000CD44
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.Session["LastReportNumber"] = new SampleReceiveTestListDB().GetMaxReportNumber();
				long num = Convert.ToInt64(this.lblMasterId.Text);
				string text = this.IsValidData();
				if (text == "")
				{
					string text2 = this.checkReceivingCapability();
					if (text2 == "")
					{
						if (num > 0L)
						{
							if (this.lblEdite.Text == "True")
							{
								this.gdvCustomFields.UpdateEdit();
								this.gdvCustomTableFields.UpdateEdit();
								this.gdvSampleTestList.UpdateEdit();
								if (this.SampleReceiveListDS.Update() > 0)
								{
                                    AttachmentSave();
                                    base.Response.Redirect("SampleReceiveManage.aspx");
								}
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
							this.gdvCustomFields.UpdateEdit();
							this.gdvCustomTableFields.UpdateEdit();
							this.gdvSampleTestList.UpdateEdit();
                            this.SampleReceiveListDS.Insert();
                            int masterId = Convert.ToInt32(Session["SampleID"]);
                            if (masterId > 0)
							{
                                List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
                                if (Session["NewSRAttachment"] != null)
                                {
                                    attachedFiles = (List<AttachedFiles>)Session["NewSRAttachment"];
                                }

                                foreach (AttachedFiles attachedFile in attachedFiles)
                                {
                                    AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                                    attachedFilesDB.Insert(new AttachedFiles
                                    {
                                        FileContent = attachedFile.FileContent,
                                        FileExtention = Path.GetExtension(attachedFile.FileName),
                                        FileName = attachedFile.FileName,
                                        FileSize = attachedFile.FileSize,
                                        FileUrl = "",
                                        FKTransID = masterId,
                                        FKTransTypeID = TransactionTypeID,
                                        IsUrl = false,
                                        Keywords = ""
                                    });
                                }
                                base.Response.Redirect("SampleReceiveManage.aspx");
							}
							this.ClearPage();
						}
						else
						{
							this.BtnSave.Enabled = false;
							this.divmsg.Attributes["class"] = "alert alert-info";
							this.LblError.ForeColor = Color.Red;
							this.LblError.Text = "You dont have permission to Add";
						}
					}
					else
					{
						this.divmsg.Attributes["class"] = "alert alert-danger";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = text2;
					}
				}
				else
				{
					this.divmsg.Attributes["class"] = "alert alert-danger";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = text;
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
				this.BtnSave.Enabled = false;
				if (ex.InnerException != null)
				{
					this.LblError.Text = ex.InnerException.Message;
				}
				if (ex.InnerException != null && ex.InnerException.Message == "Sample Receive Added Sucessfully ,but Workform Excel Faild, Please Add Information Link In Service Information Page ")
				{
					this.ClearPage();
					this.divmsg.Attributes["class"] = "alert alert-danger";
					this.LblError.ForeColor = Color.Orange;
					this.LblError.Text = "Sample Receive Added Sucessfully";
					this.lblErroe2.ForeColor = Color.Red;
					this.lblErroe2.Text = ", Workform Excel Faild, Please Add Information Link In Service Information Page";
				}
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000EE80 File Offset: 0x0000D080
		protected string checkReceivingCapability()
		{
			long fksampleID = Convert.ToInt64(this.lblMasterId.Text);
			int num = new SampleReceiveListDB().GetNOfUnpaidBills((long)this.cmbFKJobOrderMasterID.Value).No_of_PendingPayment ?? 0;
			int num2 = new JobOrderMasterDB().GetByID((long)this.cmbFKJobOrderMasterID.Value).UnpaidReceiveLimit ?? 0;
			decimal? reportCreditLimit = new JobOrderMasterDB().GetByID((long)this.cmbFKJobOrderMasterID.Value).ReportCreditLimit;
			if (reportCreditLimit != null)
			{
				reportCreditLimit.GetValueOrDefault();
			}
			decimal d = new JobOrderMasterDB().GetByID((long)this.cmbFKJobOrderMasterID.Value).ReceiveCreditLimit ?? 0m;
			decimal d2 = new SampleReceiveListDB().GetNOfUnpaidBills((long)this.cmbFKJobOrderMasterID.Value).TotalPendingAmount ?? 0m;
			decimal notSampleReceiveTestsByJobOrderID = new SampleReceiveTestListDB().GetNotSampleReceiveTestsByJobOrderID((long)this.cmbFKJobOrderMasterID.Value, fksampleID);
			decimal allWorkOrderbyDueAmountJobOrderMasterID = new WorkOrderListDB().GetAllWorkOrderbyDueAmountJobOrderMasterID((long)this.cmbFKJobOrderMasterID.Value);
			decimal allPendingEntryAmount = new WorkOrderListDB().GetAllPendingEntryAmount((long)this.cmbFKJobOrderMasterID.Value);
			decimal num3 = d2 + notSampleReceiveTestsByJobOrderID + allWorkOrderbyDueAmountJobOrderMasterID + allPendingEntryAmount;
			decimal d3 = new PaymentMasterDB().GetAllPendingAvancedPaymentAmountForJobOrder((long)this.cmbFKJobOrderMasterID.Value) ?? 0m;
			decimal num4 = 0m;
			num4 += this.GetTotalPricesTest();
			num3 += num4;
			decimal num5 = d + d3;
			if (d - num3 + d3 <= 0m)
			{
				return string.Concat(new string[]
				{
					"Cant Receiving , Receive Amount (",
					string.Format(" {0:F3}", num3),
					") Exceeds the Receive Created Limit (",
					string.Format(" {0:F3}", num5),
					")"
				});
			}
			if (num >= num2)
			{
				return string.Concat(new string[]
				{
					"Cant Receiving , Unpaid Bills (",
					string.Format(" {0:F3}", num),
					") Exceeds the Unpaid Receive Limit (",
					string.Format(" {0:F3}", num2),
					")"
				});
			}
			return "";
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000F154 File Offset: 0x0000D354
		protected bool checkReportCapability()
		{
			long fksampleID = Convert.ToInt64(this.lblMasterId.Text);
			decimal? reportCreditLimit = new JobOrderMasterDB().GetByID((long)this.cmbFKJobOrderMasterID.Value).ReportCreditLimit;
			decimal? totalPendingAmount = new SampleReceiveListDB().GetNOfUnpaidBills((long)this.cmbFKJobOrderMasterID.Value).TotalPendingAmount;
			if (totalPendingAmount == null)
			{
				totalPendingAmount = new decimal?(0m);
			}
			decimal? num = new decimal?(new SampleReceiveTestListDB().GetNotSampleReceiveTestsByJobOrderID((long)this.cmbFKJobOrderMasterID.Value, fksampleID));
			decimal? num2 = new decimal?(new WorkOrderListDB().GetAllWorkOrderbyDueAmountJobOrderMasterID((long)this.cmbFKJobOrderMasterID.Value));
			decimal? num3 = new decimal?(new WorkOrderListDB().GetAllPendingEntryAmount((long)this.cmbFKJobOrderMasterID.Value));
			return !(totalPendingAmount + num + num2 + num3 > reportCreditLimit);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000F314 File Offset: 0x0000D514
		private string IsValidData()
		{
			string text = "Validation Errors:";
			new TestsListDB();
			List<SampleReceiveTestList> list = this.SampleReceiveTestListDS.Select() as List<SampleReceiveTestList>;
			new List<SampleReceiveTestList>(list);
			List<object> selectedTestList = this.gdvSampleTestList.GetSelectedFieldValues(new string[]
			{
				"SampleReceiveTestID"
			});
			if (selectedTestList.Count == 0)
			{
				text += "\n\t You should select Service";
			}
			list.RemoveAll((SampleReceiveTestList x) => !selectedTestList.ConvertAll<long>(new Converter<object, long>(SampleReceive.ObjectToLong)).Contains(x.SampleReceiveTestID));
			if (this.txtRetentionperiod.Text != "")
			{
				int num = Convert.ToInt32(this.txtRetentionperiod.Value);
				if (num < 0)
				{
					text += "\n\t Retention period should not have negative  value ";
				}
			}
			decimal d = Convert.ToDecimal(this.txtReceivedQty.Text);
			if (d <= 0m)
			{
				text += "\n\tReceived Qty should not have negative and zero value ";
			}
			long num2 = Convert.ToInt64(this.lblMasterId.Text);
			if (num2 == 0L && this.dtSamplingDate.Date < DateTime.Today.Date.AddDays(-4.0) && this.dtSamplingDate.Value != null)
			{
				text += "\n\tSampling Date should not exceeds more than 4 days Back ";
			}
			if (text == "Validation Errors:")
			{
				this.Session["SampleReceiveTestList"] = list;
				text = "";
			}
			return text;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000F48C File Offset: 0x0000D68C
		protected void SampleReceiveListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			SampleReceiveList masterEntity = this.GetMasterEntity(0);
			e.InputParameters["entity"] = masterEntity;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000F4B4 File Offset: 0x0000D6B4
		protected void SampleReceiveListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000F4EC File Offset: 0x0000D6EC
		private SampleReceiveList GetMasterEntity(int MasterID)
		{
			SampleReceiveList sampleReceiveList;
			if (MasterID > 0)
			{
				sampleReceiveList = new SampleReceiveListDB().GetByID((long)MasterID);
				sampleReceiveList.SampleNo = this.txtSampleNo.Text;
			}
			else
			{
				sampleReceiveList = new SampleReceiveList();
				sampleReceiveList.SampleNo = new SampleReceiveListDB().GetNewSerial();
			}
			sampleReceiveList.ReceiveDate = new DateTime?(this.dtReceiveDate.Date);
			sampleReceiveList.FKJobOrderMasterID = new long?((long)this.cmbFKJobOrderMasterID.Value);
			sampleReceiveList.FKCustomerID = new int?((int)this.cmbFKCustomerID.Value);
			sampleReceiveList.FKProjectID = new int?((int)this.cmbFKProjectID.Value);
			sampleReceiveList.ConsultantName = this.txtConsultantName.Text;
			sampleReceiveList.ConsultantMobile = this.txtConsultantMobileNo.Text;
			sampleReceiveList.SiteContactPerson = this.txtSiteContactPerson.Text;
			sampleReceiveList.SiteContactMobile = this.txtSiteContactMobile.Text;
			sampleReceiveList.DelivererName = this.txtDelivererName.Text;
			sampleReceiveList.DelivererMobile = this.txtDelivererMobile.Text;
			sampleReceiveList.Supplier = this.txtSupplier.Text;
			sampleReceiveList.Source = this.txtSource.Text;
			sampleReceiveList.SamplingDate = new DateTime?(this.dtSamplingDate.Date);
			sampleReceiveList.SampleDescription = this.txtSampleDescription.Text;
			sampleReceiveList.SampleLocation = this.txtSampleLocation.Text;
			sampleReceiveList.SampledByID = this.tknSampledByID.Value.ToString();
			sampleReceiveList.SampledByName = this.txtSampledByName.Text;
			sampleReceiveList.SiteRefNo = this.txtSiteRefNo.Text;
			sampleReceiveList.SampleBroughtInByID = this.tknSampleBroughtInByID.Value.ToString();
			sampleReceiveList.SampleBroughtInDate = new DateTime?(this.dtBroughtinDate.Date);
			sampleReceiveList.SamplingDate = new DateTime?(this.dtSamplingDate.Date);
			sampleReceiveList.LayerNo = this.txtLayerNo.Text;
			sampleReceiveList.FKMaterialDetailsID = (int?)this.cmbFKMaterialDetailsID.Value;
			sampleReceiveList.FKMaterialTypeID = (int?)this.cmbFKMaterialTypeID.Value;
			sampleReceiveList.MaterialClass = this.txtMaterialClass.Text;
			sampleReceiveList.ReceivedQty = new decimal?(Convert.ToDecimal(this.txtReceivedQty.Text));
			sampleReceiveList.FKPriceUnitID = (int?)this.cmbFKPriceUnitID.Value;
			sampleReceiveList.RetentionPeriod = new int?(Convert.ToInt32(this.txtRetentionperiod.Value));
			sampleReceiveList.SampleCondition = this.txtSampleCondition.Text;
			sampleReceiveList.ConditionDetails = this.txtConditionDetails.Text;
			sampleReceiveList.SampleTemperature = (decimal?)this.txtSampleTemperature.Value;
			sampleReceiveList.SampleBroughtInByName = this.txtSampleBroughtInByName.Text;
			if (this.cmbRSSNumber.Value != null)
			{
				sampleReceiveList.FKRSSMasterId = new long?((long)int.Parse(this.cmbRSSNumber.Value.ToString()));
			}
			else
			{
				sampleReceiveList.FKRSSMasterId = null;
			}
			ADMUsers byID = new UsersDB().GetByID(int.Parse(this.Session["UserId"].ToString()));
			sampleReceiveList.ReceiveByName = byID.EName;
			return sampleReceiveList;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000030A6 File Offset: 0x000012A6
		private static long ObjectToLong(object id)
		{
			return Convert.ToInt64(id);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000030AE File Offset: 0x000012AE
		protected void SampleReceiveListDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000030EA File Offset: 0x000012EA
		protected void SampleReceiveListDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000F828 File Offset: 0x0000DA28
		protected void GdvTestItemsList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			if (num > 0)
			{
				e.NewValues["FKTestID"] = num;
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000F860 File Offset: 0x0000DA60
		protected void cmbFKJobOrderMasterID_SelectedIndexChanged(object sender, EventArgs e)
		{
			long id = Convert.ToInt64(this.cmbFKJobOrderMasterID.Value);
			JobOrderMaster byID = new JobOrderMasterDB().GetByID(id);
			this.cmbFKCustomerID.Value = byID.FKCustomerID;
			this.cmbFKProjectID.Value = byID.FKProjectID;
			this.SetProjectInfo();
			this.Session["SampleReceiveTestList"] = null;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000F8D0 File Offset: 0x0000DAD0
		protected void SetProjectInfo()
		{
			int num = Convert.ToInt32(this.cmbFKProjectID.Value);
			if (num > 0)
			{
				ProjectsList byID = new ProjectsListDB().GetByID(num);
				this.txtAshghalCode.Text = (byID.AshghalCode ?? "");
				this.txtProjectContractor.Text = (byID.ContractorsList.ContractorName ?? "");
				this.txtProjectType.Text = (byID.ProjectsTypes.ProjectTypeName ?? "");
				this.txtProjectConsultant.Text = (byID.ProjectConsultant ?? "");
				this.txtProjectLocation.Text = (byID.ProjectLocation ?? "");
				this.txtProjectOwner.Text = (byID.ProjectOwner ?? "");
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000F9A8 File Offset: 0x0000DBA8
		public List<SampleReceive.Sampled> GetSampledList()
		{
			return new List<SampleReceive.Sampled>
			{
				new SampleReceive.Sampled
				{
					Name = "Contractor",
					Value = 1
				},
				new SampleReceive.Sampled
				{
					Name = "Consultant",
					Value = 2
				},
				new SampleReceive.Sampled
				{
					Name = "Lab Tech",
					Value = 3
				},
				new SampleReceive.Sampled
				{
					Name = "Client",
					Value = 4
				}
			};
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000FA3C File Offset: 0x0000DC3C
		protected void gdvSampleTestList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			if (e.Column.FieldName != "FKSubContractorID")
			{
				return;
			}
			ASPxComboBox aspxComboBox = (ASPxComboBox)e.Editor;
			aspxComboBox.ClientInstanceName = "SubContractorEditor";
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000FA78 File Offset: 0x0000DC78
		protected void cmbMaterials_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((sender as ASPxComboBox).ID == "cmbFKMaterialTypeID")
			{
				this.cmbFKMaterialDetailsID.Value = null;
				this.Session["SampleMaterialCustomFieldList"] = null;
				this.Session["SampleMaterialTableCustomFieldList"] = null;
				this.lblFKMaterialTypeID.Text = this.cmbFKMaterialTypeID.Value.ToString();
				this.gdvCustomFields.DataBind();
				this.gdvCustomTableFields.DataBind();
				this.CreateCustomTableFieldsColumn();
			}
			this.Session["SampleReceiveTestList"] = null;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000FB14 File Offset: 0x0000DD14
		protected void gdvSampleTestList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox || e.ButtonType == ColumnCommandButtonType.Edit)
			{
				bool flag = Convert.ToBoolean(this.gdvSampleTestList.GetRowValues(e.VisibleIndex, new string[]
				{
					"IsEnabled"
				}));
				e.Enabled = flag;
				if (!flag)
				{
					this.gdvSampleTestList.CancelEdit();
				}
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00003126 File Offset: 0x00001326
		protected void cmbFKProjectID_DataBound(object sender, EventArgs e)
		{
			this.SetProjectInfo();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00002071 File Offset: 0x00000271
		protected void gdvSampleTestList_RowValidating(object sender, ASPxDataValidationEventArgs e)
		{
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000215C File Offset: 0x0000035C
		private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
		{
			if (errors.ContainsKey(column))
			{
				return;
			}
			errors[column] = errorText;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00002071 File Offset: 0x00000271
		protected void btn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000FB70 File Offset: 0x0000DD70
		protected void BtnDownload_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.checkReportCapability())
				{
					string url = "DownloadFiles.aspx?id=" + Convert.ToInt32(this.lblMasterId.Text).ToString();
					base.Response.Redirect(url);
				}
				else
				{
					this.divmsg.Attributes["class"] = "alert alert-danger";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = "Cant Download , Unpaid Amount Exceeds the Report Created Limit";
				}
			}
			catch (Exception ex)
			{
				this.LogError(ex);
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message + ((ex.InnerException == null) ? "" : ("IE: " + ex.InnerException.Message));
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		private void LogError(Exception ex)
		{
			string text = string.Format("Time: {0}", DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt"));
			text += Environment.NewLine;
			text += "-----------------------------------------------------------";
			text += Environment.NewLine;
			text += string.Format("Message: {0}", ex.Message);
			text += Environment.NewLine;
			text += string.Format("StackTrace: {0}", ex.StackTrace);
			text += Environment.NewLine;
			text += string.Format("Source: {0}", ex.Source);
			text += Environment.NewLine;
			text += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
			text += Environment.NewLine;
			if (ex.InnerException != null)
			{
				text += string.Format("InnerException: {0}", ex.InnerException.Message);
				text += Environment.NewLine;
			}
			text += "-----------------------------------------------------------";
			text += Environment.NewLine;
			string path = base.Server.MapPath("~/ErrorLogs/ErrorLog.txt");
			using (StreamWriter streamWriter = new StreamWriter(path, true))
			{
				streamWriter.WriteLine(text);
				streamWriter.Close();
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000FC70 File Offset: 0x0000DE70
		protected void gdvCustomFields_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			long num = Convert.ToInt64(this.lblMasterId.Text);
			e.NewValues["FkSampleID"] = num;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000FCA4 File Offset: 0x0000DEA4
		protected void ClearPage()
		{
			this.dtReceiveDate.Date = DateTime.Today;
			this.Session["SampleReceiveTestList"] = null;
			this.flSampleReceiveList.DataBind();
			this.cmbFKJobOrderMasterID.Value = null;
			this.cmbFKMaterialDetailsID.Value = null;
			this.cmbFKMaterialTypeID.Value = null;
			this.cmbFKPriceUnitID.Value = null;
			this.cmbFKProjectID.Value = null;
			this.cmbFKCustomerID.Value = null;
			this.txtProjectOwner.Text = null;
			this.txtAshghalCode.Text = null;
			this.txtConditionDetails.Text = null;
			this.txtConsultantMobileNo.Text = null;
			this.txtConsultantName.Text = null;
			this.txtDelivererMobile.Text = null;
			this.txtDelivererName.Text = null;
			this.txtLayerNo.Text = null;
			this.txtMaterialClass.Text = null;
			this.txtProjectConsultant.Text = null;
			this.txtProjectContractor.Text = null;
			this.txtProjectLocation.Text = null;
			this.txtProjectType.Text = null;
			this.txtReceivedQty.Text = null;
			this.txtRetentionperiod.Value = null;
			this.cmbRSSNumber.Value = null;
			this.txtSampleBroughtInByName.Text = null;
			this.txtSampleCondition.Text = null;
			this.txtSampledByName.Text = null;
			this.txtSampleDescription.Text = null;
			this.txtSampleLocation.Text = null;
			this.txtSampleNo.Text = null;
			this.txtSiteContactMobile.Text = null;
			this.txtSiteContactPerson.Text = null;
			this.txtSiteRefNo.Text = null;
			this.txtSource.Text = null;
			this.txtSupplier.Text = null;
			this.txtSampleNo.Text = new SampleReceiveListDB().GetNewSerial();
			this.tknSampledByID.Text = "";
			this.tknSampleBroughtInByID.Text = "";
			this.dtSamplingDate.Value = null;
			this.txtSampleTemperature.Text = "";
			this.Session["SampleMaterialCustomFieldList"] = null;
			this.Session["SampleMaterialTableCustomFieldList"] = null;
			this.gdvCustomFields.DataSourceID = null;
			this.gdvCustomFields.DataSource = new SampleReceiveMaterialCustomFieldDB().GetNonTableFieldsByFKMaterialTypeIDWithSession(0, 0L);
			this.gdvCustomFields.DataBind();
			this.gdvCustomTableFields.DataSourceID = null;
			this.gdvCustomTableFields.DataSource = new SampleReceiveMaterialTableCustomFieldDB().GetTableFieldsByFKMaterialTypeIDWithSession(0, 0L);
			this.gdvCustomTableFields.DataBind();
			this.gdvCustomTableFields.Columns.Clear();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000312E File Offset: 0x0000132E
		protected void gdvCustomTableFields_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			this.UpdateItem(e.Keys, e.NewValues);
			e.Cancel = true;
			this.gdvCustomTableFields.CancelEdit();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000FF4C File Offset: 0x0000E14C
		private void CreateCustomTableFieldsColumn()
		{
			List<MaterialTypesCustomFields> tableFieldsByFKMaterialTypeID = new MaterialTypesCustomFieldsDB().GetTableFieldsByFKMaterialTypeID(Convert.ToInt32(this.lblFKMaterialTypeID.Text));
			int num = 1;
			List<string> list = new List<string>();
			foreach (object obj in this.gdvCustomTableFields.Columns)
			{
				GridViewColumn gridViewColumn = (GridViewColumn)obj;
				if (gridViewColumn != null)
				{
					GridViewColumn gridViewColumn2 = gridViewColumn;
					list.Add(gridViewColumn2.Name);
				}
			}
			foreach (string text in list)
			{
				if (text != "CommandColumn")
				{
					GridViewColumn column = this.gdvCustomTableFields.Columns[text];
					this.gdvCustomTableFields.Columns.Remove(column);
				}
			}
			foreach (MaterialTypesCustomFields materialTypesCustomFields in tableFieldsByFKMaterialTypeID)
			{
				GridViewDataTextColumn gridViewDataTextColumn = new GridViewDataTextColumn();
				gridViewDataTextColumn.Caption = materialTypesCustomFields.CustomFieldName;
				gridViewDataTextColumn.FieldName = materialTypesCustomFields.CustomFieldID.ToString();
				gridViewDataTextColumn.VisibleIndex = num;
				this.gdvCustomTableFields.Columns.Add(gridViewDataTextColumn);
				num++;
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00002071 File Offset: 0x00000271
		protected void gdvSampleTestList_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
		{
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000100D0 File Offset: 0x0000E2D0
		protected void OnItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
		{
			int id;
			if (e.Value == null || !int.TryParse(e.Value.ToString(), out id))
			{
				return;
			}
			ASPxComboBox aspxComboBox = source as ASPxComboBox;
			aspxComboBox.DataSource = from x in new SubcontractorsListDB().GetAll()
			where x.SubContractorID == id
			select x;
			aspxComboBox.DataBind();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00010134 File Offset: 0x0000E334
		protected void OnItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
		{
			ASPxComboBox aspxComboBox = source as ASPxComboBox;
			int currentTest = this.GetCurrentTest();
			List<SubcontractorsList> testContractorsList = new TestContractorsDB().GetTestContractorsList(currentTest);
			aspxComboBox.DataSource = testContractorsList;
			aspxComboBox.DataBind();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00010168 File Offset: 0x0000E368
		private int GetCurrentTest()
		{
			object value = null;
			if (this.hf.TryGet("CurrentTest", out value))
			{
				return Convert.ToInt32(value);
			}
			return -1;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00010194 File Offset: 0x0000E394
		private int GetTotalPricesTest()
		{
			object value = null;
			if (this.hfT.TryGet("TotalTestPrices", out value))
			{
				return Convert.ToInt32(value);
			}
			return 0;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000101C0 File Offset: 0x0000E3C0
		protected void gdvCustomTableFields_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
		{
			foreach (ASPxDataInsertValues aspxDataInsertValues in e.InsertValues)
			{
				this.InsertItem(aspxDataInsertValues.NewValues);
			}
			foreach (ASPxDataUpdateValues aspxDataUpdateValues in e.UpdateValues)
			{
				this.UpdateItem(aspxDataUpdateValues.Keys, aspxDataUpdateValues.NewValues);
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00010268 File Offset: 0x0000E468
		protected SampleReceiveMaterialTableCustomField UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
		{
			List<SampleReceiveMaterialTableCustomField> source = new List<SampleReceiveMaterialTableCustomField>();
			List<SampleReceiveMaterialTableCustomField> list = new List<SampleReceiveMaterialTableCustomField>();
			SampleReceiveMaterialTableCustomField sampleReceiveMaterialTableCustomField = new SampleReceiveMaterialTableCustomField();
			source = new SampleReceiveMaterialTableCustomFieldDB().GetTableFieldsByFKMaterialTypeIDWithSession(int.Parse(this.lblFKMaterialTypeID.Text.ToString()), long.Parse(this.lblMasterId.Text.ToString()));
			int id = Convert.ToInt32(keys["RowIndex"]);
			List<int?> list2 = (from x in source
			select x.FkCustomFieldID).Distinct<int?>().ToList<int?>();
			using (List<int?>.Enumerator enumerator = list2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int? item = enumerator.Current;
					sampleReceiveMaterialTableCustomField = source.First((SampleReceiveMaterialTableCustomField j) => j.RowIndex == id && j.FkCustomFieldID == item);
					SampleReceiveMaterialTableCustomField det = sampleReceiveMaterialTableCustomField;
					int? item2 = item;
					this.LoadNewValues(det, newValues, int.Parse(item2.ToString()));
					sampleReceiveMaterialTableCustomField.RowStatus = 2;
					list.Add(sampleReceiveMaterialTableCustomField);
				}
			}
			this.Session["SampleMaterialTableCustomFieldList"] = list;
			return sampleReceiveMaterialTableCustomField;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000103BC File Offset: 0x0000E5BC
		protected void InsertItem(OrderedDictionary newValues)
		{
			List<SampleReceiveMaterialTableCustomField> list;
			if (this.Session["SampleMaterialTableCustomFieldList"] == null)
			{
				list = new SampleReceiveMaterialTableCustomFieldDB().GetTableFieldsByFKMaterialTypeIDWithSession(Convert.ToInt32(this.lblFKMaterialTypeID.Text), (long)Convert.ToInt32(this.lblMasterId.Text));
			}
			else
			{
				list = (this.Session["SampleMaterialTableCustomFieldList"] as List<SampleReceiveMaterialTableCustomField>);
			}
			int? num = list.Max((SampleReceiveMaterialTableCustomField entity) => entity.RowIndex);
			if (num == null)
			{
				num = new int?(int.Parse(new SampleReceiveMaterialTableCustomFieldDB().getLastRowIndex()));
			}
			num++;
			List<int?> list2 = (from x in list
			select x.FkCustomFieldID).Distinct<int?>().ToList<int?>();
			list.RemoveAll((SampleReceiveMaterialTableCustomField x) => x.RowIndex == null);
			foreach (int? num2 in list2)
			{
				if (num2 != null)
				{
					SampleReceiveMaterialTableCustomField sampleReceiveMaterialTableCustomField = new SampleReceiveMaterialTableCustomField();
					this.LoadNewValues(sampleReceiveMaterialTableCustomField, newValues, int.Parse(num2.ToString()));
					sampleReceiveMaterialTableCustomField.RowIndex = num;
					sampleReceiveMaterialTableCustomField.RowStatus = 1;
					list.Add(sampleReceiveMaterialTableCustomField);
				}
			}
			this.Session["SampleMaterialTableCustomFieldList"] = list;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0001056C File Offset: 0x0000E76C
		private void LoadNewValues(SampleReceiveMaterialTableCustomField det, OrderedDictionary values, int FkCustomFieldID)
		{
			if (values[FkCustomFieldID.ToString()] == null)
			{
				det.Value = "";
			}
			else
			{
				det.Value = values[FkCustomFieldID.ToString()].ToString();
			}
			det.FkCustomFieldID = new int?(FkCustomFieldID);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00003155 File Offset: 0x00001355
		protected void gdvCustomTableFields_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			e.Cancel = true;
			this.gdvCustomTableFields.CancelEdit();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00003169 File Offset: 0x00001369
		protected void ASPxButton1_Click(object sender, EventArgs e)
		{
			this.gdvCustomTableFields.UpdateEdit();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00003176 File Offset: 0x00001376
		protected void gdvCustomTableFields_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
			this.DeleteItem(e.Keys);
			e.Cancel = true;
			this.gdvCustomTableFields.CancelEdit();
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000105BC File Offset: 0x0000E7BC
		protected void DeleteItem(OrderedDictionary keys)
		{
			int rowindex = Convert.ToInt32(keys["RowIndex"]);
			List<SampleReceiveMaterialTableCustomField> byRowindex = new SampleReceiveMaterialTableCustomFieldDB().GetByRowindex(rowindex);
			(from x in byRowindex
			select x.FkCustomFieldID).Distinct<int?>().ToList<int?>();
			foreach (SampleReceiveMaterialTableCustomField entity in byRowindex)
			{
				new SampleReceiveMaterialTableCustomFieldDB().Delete(entity);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0001065C File Offset: 0x0000E85C
		protected void cmbRSSNumber_SelectedIndexChanged(object sender, EventArgs e)
		{
			RSSMaster byID = new RSSMasterDB().GetByID((long)int.Parse(this.cmbRSSNumber.Value.ToString()));
			this.cmbFKJobOrderMasterID.Value = byID.FKJobOrderMasterID;
			this.cmbFKJobOrderMasterID.Enabled = false;
			this.cmbFKJobOrderMasterID_SelectedIndexChanged(this.cmbFKJobOrderMasterID, new EventArgs());
			JobOrderMaster byID2 = new JobOrderMasterDB().GetByID(byID.FKJobOrderMasterID);
			this.cmbFKCustomerID.Value = byID2.FKCustomerID;
			this.cmbFKProjectID.Value = byID2.FKProjectID;
			this.SetProjectInfo();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00002071 File Offset: 0x00000271
		protected void gdvSampleTestList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
		}

        protected void gdvSampleTestList_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView gv = sender as ASPxGridView;

            string[] paramVals = e.Parameters.Split(',');
            if (paramVals.Length < 2)
                return;

            int selectedIndex = 0;
            int.TryParse(paramVals[0], out selectedIndex);
            if (selectedIndex <= -1)
                return;

            bool selected = false;
            bool.TryParse(paramVals[1], out selected);

            SampleReceiveTestList obj = gv.GetRow(selectedIndex) as SampleReceiveTestList;            
            TestsList mandatoryTest = new TestsListDB().GetByID(Convert.ToInt32(obj.FKTestID));
            if (mandatoryTest != null && mandatoryTest.FKTestID.HasValue)
            {
                List<SampleReceiveTestList> samples = (List<SampleReceiveTestList>)SampleReceiveTestListDS.Select();
                if (samples != null)
                {
                    SampleReceiveTestList mandatoryObj = samples.Where(s => s.FKTestID == mandatoryTest.FKTestID.Value).FirstOrDefault();
                    if (mandatoryObj != null && mandatoryObj.IsEnabled)
                    {
                        GridViewSelection selectedVal = gv.Selection;
                        selectedVal.SelectRowByKey(mandatoryObj.SampleReceiveTestID);
                    }
                }
            }
        }

        // Token: 0x060000AC RID: 172 RVA: 0x000074D4 File Offset: 0x000056D4
        protected void AttachmentSave()
        {
            try
            {
                if (this.Session[this._fileListSessionString] != null)
                {
                    //foreach (AttachedFiles attachedFiles in ((List<AttachedFiles>)this.Session[this._fileListSessionString]))
                    //{
                    //    attachedFiles.Keywords = this.txtKeywords.Text;
                    //}
                }
                string text = this.SaveAttachments();
                if (text == "")
                {
                    this.divmsg.Attributes["class"] = "alert alert-success";
                    this.LblError.ForeColor = Color.Green;
                    this.LblError.Text = "Attachments saved successfully!";
                   // base.Response.Write("<script language='javascript'> {window.close();}</script>");
                }
                else
                {
                    this.divmsg.Attributes["class"] = "alert alert-danger";
                    this.LblError.ForeColor = Color.Red;
                    this.LblError.Text = text;
                }
            }
            catch (Exception ex)
            {
                this.divmsg.Attributes["class"] = "alert alert-danger";
                this.LblError.ForeColor = Color.Red;
                this.LblError.Text = ex.Message;
            }
        }

        // Token: 0x060000AD RID: 173 RVA: 0x00002071 File Offset: 0x00000271
        protected void btnAttachmentClose_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060000AE RID: 174 RVA: 0x000027E3 File Offset: 0x000009E3
        protected void AttachmentPopup_Load(object sender, EventArgs e)
        {
            this.gdvfiles.DataBind();
            this.gdvfiles.ClientVisible = (this.gdvfiles.VisibleRowCount != 0);
        }

        // Token: 0x060000AF RID: 175 RVA: 0x00007638 File Offset: 0x00005838
        protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string fileName = e.UploadedFile.FileName;
            string text = (e.UploadedFile.ContentLength / 1024L).ToString() + " KB";
            byte[] fileBytes = e.UploadedFile.FileBytes;
            AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
            attachedFilesDB.Insert(new AttachedFiles
            {
                FileContent = fileBytes,
                FileExtention = Path.GetExtension(e.UploadedFile.FileName),
                FileName = fileName,
                FileSize = text,
                FileUrl = "",
                //FKTransID = long.Parse(base.Request["TransID"].ToString()),
                //FKTransTypeID = int.Parse(base.Request["TransTypeID"].ToString()),
                FKTransID = long.Parse(lblMasterId.Text),
                FKTransTypeID = TransactionTypeID,
                IsUrl = false,
                Keywords = ""
            });
            this.gdvfiles.DataBind();
            e.CallbackData = fileName + "|" + text;
        }           

        // Token: 0x060000B0 RID: 176 RVA: 0x0000280C File Offset: 0x00000A0C
        protected void gdvfiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        // Token: 0x060000B1 RID: 177 RVA: 0x00007744 File Offset: 0x00005944
        protected void gdvfiles_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "download")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    string fileUrl = attachedFiles.FileUrl;
                    string str = attachedFiles.FileName.Replace(" ", "_");
                    byte[] fileContent = attachedFiles.FileContent;
                    //System.IO.File.WriteAllBytes("d:\\hello.pdf", fileContent);
                    base.Response.Clear();
                    base.Response.ClearHeaders();
                    base.Response.AddHeader("Content-Type", "Application/octet-stream");
                    base.Response.AddHeader("Content-Length", fileContent.Length.ToString());
                    base.Response.AddHeader("Content-Disposition", "attachment;   filename=" + str);
                    base.Response.BinaryWrite(fileContent);
                    base.Response.Flush();
                    base.Response.End();
                }
            }
            else if (e.CommandArgs.CommandName == "delete")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    bool result = attachedFilesDB.Delete(attachedFiles);
                    this.ClearSessions();
                    this.gdvfiles.DataBind();
                }
            }
        }

        protected void UploadControl_SessionFileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string fileName = e.UploadedFile.FileName;
            string size = (e.UploadedFile.ContentLength / 1024L).ToString() + " KB";
            byte[] fileBytes = e.UploadedFile.FileBytes;
            long FKTransId = long.Parse(lblMasterId.Text);

            SessionAttachedFilesDB attachedFilesDB = new SessionAttachedFilesDB();
            attachedFilesDB.Insert(new AttachedFiles
            {
                FileContent = fileBytes,
                FileExtention = Path.GetExtension(e.UploadedFile.FileName),
                FileName = fileName,
                FileSize = size,
                FileUrl = "",
                FKTransID = FKTransId,
                FKTransTypeID = TransactionTypeID,
                IsUrl = false,
                Keywords = ""
            });

            this.gdvSessionFiles.DataBind();
            e.CallbackData = fileName + "|" + size;
        }

        protected void gdvSessionFiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        protected void gdvSessionFiles_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "delete")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                SessionAttachedFilesDB attachedFilesDB = new SessionAttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    bool result = attachedFilesDB.Delete(attachedFiles);
                    this.ClearSessions();
                    this.gdvSessionFiles.DataBind();
                }
            }
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00007850 File Offset: 0x00005A50
        public List<AttachedFiles> GetAttachmentList()
        {
            List<AttachedFiles> result = new List<AttachedFiles>();
            if (this.Session[this._fileListSessionString] != null)
            {
                result = (List<AttachedFiles>)this.Session[this._fileListSessionString];
            }
            return result;
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00007890 File Offset: 0x00005A90
        public string SaveAttachments()
        {
            AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
            string result = "";
            if (this.TransactionID != 0L && TransactionTypeID != 0)
            {
                List<AttachedFiles> attachmentList = this.GetAttachmentList();
                if (attachmentList.Count > 0)
                {
                    result = attachedFilesDB.SaveAttachments(attachmentList, this.TransactionID);
                    this.ClearSessions();
                }
            }
            else
            {
                result = "Set 'TransactionID' before calling 'SaveAttachments()' Method.";
            }
            return result;
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x000078E8 File Offset: 0x00005AE8
        public string DeleteAllAttachments()
        {
            AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
            string result;
            if (this.TransactionID != 0L && TransactionTypeID != 0)
            {
                result = attachedFilesDB.DeleteAll(this.TransactionID, TransactionTypeID);
            }
            else
            {
                result = "Set 'TransactionID' before calling 'DeleteAllAttachments()' Method.";
            }
            return result;
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x00007930 File Offset: 0x00005B30
        private void AddToGrid(string name, string sizeText)
        {
            object obj = this.Session[this._unSavedFileListSessionString];
            if (this.Session[this._fileListSessionString] != null)
            {
                string a = "";
                List<AttachedFiles> list = (List<AttachedFiles>)this.Session[this._fileListSessionString];
                AttachedFiles attachedFiles = new AttachedFiles();
                attachedFiles.FileName = name;
                attachedFiles.FileSize = sizeText;
                attachedFiles.FKTransTypeID = TransactionTypeID;
                attachedFiles.FKTransID = this.TransactionID;
                //attachedFiles.Keywords = this.txtKeywords.Text;
                if (this.TransactionID == 0L)
                {
                    attachedFiles.FileID = (long)(list.Count + 1);
                }
                else
                {
                    AttachedFiles attachedFiles2 = attachedFiles;
                    long fileID;
                    if (list.Count <= 0)
                    {
                        fileID = 1L;
                    }
                    else
                    {
                        fileID = list.Max((AttachedFiles x) => x.FileID) + 1L;
                    }
                    attachedFiles2.FileID = fileID;
                }
                if (a == "")
                {
                    list.Add(attachedFiles);
                }
                if (obj == null)
                {
                    obj = new List<AttachedFiles>();
                }
                ((List<AttachedFiles>)obj).Add(attachedFiles);
                this.Session[this._unSavedFileListSessionString] = obj;
            }
            this.gdvfiles.DataBind();
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x00007A5C File Offset: 0x00005C5C
        //private void UpdateKeywords(List<AttachedFiles> files)
        //{
        //    AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
        //    string text = "";
        //    foreach (AttachedFiles attachedFiles in files)
        //    {
        //        attachedFiles.Keywords = this.txtKeywords.Text;
        //        if (this.TransactionID != 0L)
        //        {
        //            attachedFilesDB.Update(attachedFiles, out text);
        //        }
        //    }
        //}

        // Token: 0x060000B7 RID: 183 RVA: 0x00007AD4 File Offset: 0x00005CD4
        private void InsertItems(List<AttachedFiles> unsavedfiles)
        {
            AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
            string text = "";
            foreach (AttachedFiles entity in unsavedfiles)
            {
                if (this.TransactionID != 0L)
                {
                    attachedFilesDB.Insert(entity, out text);
                }
            }
            this.Session[this._unSavedFileListSessionString] = null;
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x00007B50 File Offset: 0x00005D50
        private void RemoveUnsavedItems()
        {
            object obj = this.Session[this._unSavedFileListSessionString];
            object obj2 = this.Session[this._fileListSessionString];
            if (obj != null)
            {
                using (List<AttachedFiles>.Enumerator enumerator = ((List<AttachedFiles>)obj).GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        AttachedFiles file = enumerator.Current;
                        ((List<AttachedFiles>)obj2).Remove(((List<AttachedFiles>)obj2).FirstOrDefault((AttachedFiles x) => x.FileID == file.FileID));
                    }
                }
            }
            this.Session[this._unSavedFileListSessionString] = null;
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x00002819 File Offset: 0x00000A19
        public void ClearSessions()
        {
            this.Session[this._fileListSessionString] = null;
            this.Session[this._attachTransIDSessionString] = null;
            this.Session[this._unSavedFileListSessionString] = null;
        }
       
        // Token: 0x04000262 RID: 610
        protected HtmlGenericControl ultitle;

		// Token: 0x04000263 RID: 611
		protected ASPxLabel lblView;

		// Token: 0x04000264 RID: 612
		protected ASPxLabel lblEdite;

		// Token: 0x04000265 RID: 613
		protected ASPxLabel lblDelete;

		// Token: 0x04000266 RID: 614
		protected ASPxLabel lblAdd;

		// Token: 0x04000267 RID: 615
		protected ASPxLabel txtTotalTestPrices;

		// Token: 0x04000268 RID: 616
		protected ASPxButton BtnSave;

		// Token: 0x04000269 RID: 617
		protected ASPxButton BtnBack;

		// Token: 0x0400026A RID: 618
		protected ASPxButton BtnDownload;

		// Token: 0x0400026B RID: 619
		protected ASPxButton BtnPrint;

		// Token: 0x0400026C RID: 620
		protected HtmlGenericControl divmsg;

		// Token: 0x0400026D RID: 621
		protected ASPxLabel LblError;

		// Token: 0x0400026E RID: 622
		protected ASPxLabel lblErroe2;

		// Token: 0x0400026F RID: 623
		protected ASPxLabel lblErrorMessage;

		// Token: 0x04000270 RID: 624
		protected ASPxLabel lblMasterId;

		// Token: 0x04000271 RID: 625
		protected ASPxLabel lblFKMaterialTypeID;

		// Token: 0x04000272 RID: 626
		protected ASPxFormLayout flSampleReceiveList;

		// Token: 0x04000273 RID: 627
		protected ASPxTextBox txtSampleNo;

		// Token: 0x04000274 RID: 628
		protected ASPxDateEdit dtReceiveDate;

		// Token: 0x04000275 RID: 629
		protected ASPxComboBox cmbRSSNumber;

		// Token: 0x04000276 RID: 630
		protected ASPxComboBox cmbFKJobOrderMasterID;

		// Token: 0x04000277 RID: 631
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x04000278 RID: 632
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x04000279 RID: 633
		protected ASPxTextBox txtAshghalCode;

		// Token: 0x0400027A RID: 634
		protected ASPxTextBox txtProjectOwner;

		// Token: 0x0400027B RID: 635
		protected ASPxTextBox txtProjectContractor;

		// Token: 0x0400027C RID: 636
		protected ASPxTextBox txtProjectType;

		// Token: 0x0400027D RID: 637
		protected ASPxTextBox txtProjectLocation;

		// Token: 0x0400027E RID: 638
		protected ASPxTextBox txtProjectConsultant;

		// Token: 0x0400027F RID: 639
		protected ASPxTextBox txtConsultantName;

		// Token: 0x04000280 RID: 640
		protected ASPxTextBox txtConsultantMobileNo;

		// Token: 0x04000281 RID: 641
		protected ASPxTextBox txtSiteContactPerson;

		// Token: 0x04000282 RID: 642
		protected ASPxTextBox txtSiteContactMobile;

		// Token: 0x04000283 RID: 643
		protected ASPxTextBox txtDelivererName;

		// Token: 0x04000284 RID: 644
		protected ASPxTextBox txtDelivererMobile;

		// Token: 0x04000285 RID: 645
		protected ASPxTextBox txtSupplier;

		// Token: 0x04000286 RID: 646
		protected ASPxTextBox txtSource;

		// Token: 0x04000287 RID: 647
		protected ASPxDateEdit dtSamplingDate;

		// Token: 0x04000288 RID: 648
		protected ASPxTextBox txtSampleDescription;

		// Token: 0x04000289 RID: 649
		protected ASPxTextBox txtSampleLocation;

		// Token: 0x0400028A RID: 650
		protected ASPxTokenBox tknSampledByID;

		// Token: 0x0400028B RID: 651
		protected ASPxTextBox txtSampledByName;

		// Token: 0x0400028C RID: 652
		protected ASPxTextBox txtSiteRefNo;

		// Token: 0x0400028D RID: 653
		protected ASPxTokenBox tknSampleBroughtInByID;

		// Token: 0x0400028E RID: 654
		protected ASPxTextBox txtSampleBroughtInByName;

		// Token: 0x0400028F RID: 655
		protected ASPxDateEdit dtBroughtinDate;

		// Token: 0x04000290 RID: 656
		protected ASPxTextBox txtLayerNo;

		// Token: 0x04000291 RID: 657
		protected ASPxComboBox cmbFKMaterialTypeID;

		// Token: 0x04000292 RID: 658
		protected ASPxComboBox cmbFKMaterialDetailsID;

		// Token: 0x04000293 RID: 659
		protected ASPxTextBox txtMaterialClass;

		// Token: 0x04000294 RID: 660
		protected ASPxSpinEdit txtReceivedQty;

		// Token: 0x04000295 RID: 661
		protected ASPxComboBox cmbFKPriceUnitID;

		// Token: 0x04000296 RID: 662
		protected ASPxComboBox txtRetentionperiod;

		// Token: 0x04000297 RID: 663
		protected ASPxTextBox txtSampleCondition;

		// Token: 0x04000298 RID: 664
		protected ASPxTextBox txtConditionDetails;

		// Token: 0x04000299 RID: 665
		protected ASPxSpinEdit txtSampleTemperature;

		// Token: 0x0400029A RID: 666
		protected ASPxGridView gdvCustomFields;

		// Token: 0x0400029B RID: 667
		protected ASPxHiddenField hf;

		// Token: 0x0400029C RID: 668
		protected ASPxHiddenField hfT;

		// Token: 0x0400029D RID: 669
		protected ASPxGridView gdvSampleTestList;

		// Token: 0x0400029E RID: 670
		protected ASPxGridView gdvCustomTableFields;

		// Token: 0x0400029F RID: 671
		protected ObjectDataSource SubcontractorsListDS;

		// Token: 0x040002A0 RID: 672
		protected ObjectDataSource JobOrderMasterDS;

		// Token: 0x040002A1 RID: 673
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040002A2 RID: 674
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x040002A3 RID: 675
		protected ObjectDataSource SampledDS;

		// Token: 0x040002A4 RID: 676
		protected ObjectDataSource MaterialsTypesDS;

		// Token: 0x040002A5 RID: 677
		protected ObjectDataSource MaterialsListDS;

		// Token: 0x040002A6 RID: 678
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x040002A7 RID: 679
		protected ObjectDataSource SampleReceiveMaterialCustomFieldDS;

		// Token: 0x040002A8 RID: 680
		protected ObjectDataSource SampleReceiveMaterialTableCustomFieldDS;

		// Token: 0x040002A9 RID: 681
		protected ObjectDataSource MaterialTypesCustomFieldsDS;

		// Token: 0x040002AA RID: 682
		protected ObjectDataSource SampleReceiveListDS;

		// Token: 0x040002AB RID: 683
		protected ObjectDataSource SampleReceiveTestListDS;

		// Token: 0x040002AC RID: 684
		protected ObjectDataSource TestsListDS;

		// Token: 0x040002AD RID: 685
		protected ObjectDataSource ServiceListDS;

		// Token: 0x040002AE RID: 686
		protected ObjectDataSource RSSMasterDS;

        // Token: 0x040002AE RID: 687
        protected HtmlGenericControl divattachfile;

        protected HtmlGenericControl divsessionattachfile;

        // Token: 0x04000083 RID: 688
        private string _fileListSessionString = "_appattachfiles";

        // Token: 0x04000084 RID: 689
        private string _attachTransIDSessionString = "_appattachTransID";

        // Token: 0x04000085 RID: 690
        private string _unSavedFileListSessionString = "_appattachUnsavedfiles";

        // Token: 0x04000088 RID: 691
        protected ASPxLabel lblTransTypeID;

        // Token: 0x04000089 RID: 692
        protected ASPxLabel lblUploadDirectory;

        // Token: 0x04000088 RID: 693
        protected ASPxLabel lblTransID;

        // Token: 0x04000092 RID: 694
        protected ASPxGridView gdvfiles;

        protected ASPxGridView gdvSessionFiles;

        // Token: 0x04000092 RID: 695
        protected ASPxUploadControl UploadControl;

        // Token: 0x04000092 RID: 696
        protected ObjectDataSource TransactionAttachmentsDS;

        protected ASPxRoundPanel FilContents;

        // Token: 0x02000030 RID: 48
        public class Sampled
		{
			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060001D0 RID: 464 RVA: 0x000031AE File Offset: 0x000013AE
			// (set) Token: 0x060001D1 RID: 465 RVA: 0x000031B6 File Offset: 0x000013B6
			public string Name { get; set; }

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060001D2 RID: 466 RVA: 0x000031BF File Offset: 0x000013BF
			// (set) Token: 0x060001D3 RID: 467 RVA: 0x000031C7 File Offset: 0x000013C7
			public int Value { get; set; }
		}
	}
}
