using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Data;
using DevExpress.Web.Demos;

namespace PioneerLab.Pages
{
	// Token: 0x0200003E RID: 62
	public class LabTestInfo : Page
	{
		// Token: 0x0600026E RID: 622 RVA: 0x00015F30 File Offset: 0x00014130
		protected void Page_Load(object sender, EventArgs e)
		{
			this.txtWorkform.Attributes.Add("onclick", "UploadButton_Click()");
			this.txtReport.Attributes.Add("onclick", "UploadReportButton_Click()");
			if (!base.IsPostBack)
			{
				this.Session["WorkformWorksheetList"] = null;
				this.Session["ReportWorksheetList"] = null;
				this.Session["TestItemsList"] = null;
				this.Session["TestPricesList"] = null;
				this.Session["TestExcelMappingList"] = null;
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.Session["lblMasterId"] = this.lblMasterId.Text;
				this.flTestsList.DataBind();
				if (num > 0)
				{
					TestsList byID = new TestsListDB().GetByID(num);
					if (byID.Image != null)
					{
						this.previewImage.Src = "../Uploaded/Tests/" + byID.Image;
						this.Session["Staff"] = byID.Image;
					}
				}
				else
				{
					this.Session["Staff"] = null;
				}
			}
			if (this.IsUnavailableTest.Checked)
			{
				this.IsSubcontractedTest.Checked = this.IsUnavailableTest.Checked;
				this.IsSubcontractedTest.ClientEnabled = !this.IsUnavailableTest.Checked;
			}
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/LabTestInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000161AC File Offset: 0x000143AC
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				string text = this.IsValidData();
				if (text == "")
				{
					if (num > 0L)
					{
						if (this.lblEdite.Text == "True")
						{
							this.TestEquipmentsDS.Update();
							this.TestContractorsDS.Update();
							this.TestsListDS.Update();
							this.PreviewImage();
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
						this.TestsListDS.Insert();
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

		// Token: 0x06000270 RID: 624 RVA: 0x0001637C File Offset: 0x0001457C
		private string IsValidData()
		{
			string text = "Validation Errors:";
			if (this.IsSubcontractedTest.Checked && this.lstSubContractors.SelectedValues.Count == 0)
			{
				text += "\n\tPlease select atleast one subcontractor!";
			}
			object obj = this.Session["TestPricesList"];
			if (this.GdvTestPriceList.VisibleRowCount == 0)
			{
				text += "\n\tPlease add atleaset one price unit!";
			}
			if (text == "Validation Errors:")
			{
				text = "";
			}
			return text;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000163F8 File Offset: 0x000145F8
		protected void TestsListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			TestsList masterEntity = this.GetMasterEntity(0);
			object obj = this.Session["TestItemsList"];
			if (obj != null)
			{
				List<TestItems> testItems = obj as List<TestItems>;
				masterEntity.TestItems = testItems;
			}
			object obj2 = this.Session["TestPricesList"];
			if (obj2 != null)
			{
				List<TestPrices> list = obj2 as List<TestPrices>;
				if (list.Count > 0)
				{
					masterEntity.TestPrices = list;
				}
			}
			SelectedValueCollection selectedValues = this.lstEquipmentList.SelectedValues;
			foreach (object value in ((IEnumerable)selectedValues))
			{
				TestEquipments testEquipments = new TestEquipments();
				testEquipments.FKEquipmentID = Convert.ToInt32(value);
				masterEntity.TestEquipments.Add(testEquipments);
			}
			SelectedValueCollection selectedValues2 = this.lstSubContractors.SelectedValues;
			foreach (object value2 in ((IEnumerable)selectedValues2))
			{
				TestContractors testContractors = new TestContractors();
				testContractors.FKSubContractorID = Convert.ToInt32(value2);
				masterEntity.TestContractors.Add(testContractors);
			}
			object obj3 = HttpContext.Current.Session["TestExcelMappingList"];
			if (obj3 != null)
			{
				List<ViewExcelCellFieldMapping> list2 = obj3 as List<ViewExcelCellFieldMapping>;
				foreach (ViewExcelCellFieldMapping viewExcelCellFieldMapping in list2)
				{
					if (!string.IsNullOrEmpty(viewExcelCellFieldMapping.ExcelCell))
					{
						TestExcelMapping testExcelMapping = new TestExcelMapping();
						testExcelMapping.IsForReport = viewExcelCellFieldMapping.IsForReport;
						testExcelMapping.FieldName = viewExcelCellFieldMapping.FieldName;
						testExcelMapping.ExcelCell = viewExcelCellFieldMapping.ExcelCell;
						masterEntity.TestExcelMapping.Add(testExcelMapping);
					}
				}
			}
			e.InputParameters["entity"] = masterEntity;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000165FC File Offset: 0x000147FC
		protected void TestsListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00016634 File Offset: 0x00014834
		private TestsList GetMasterEntity(int MasterID)
		{
			TestsList testsList;
			if (MasterID > 0)
			{
				testsList = new TestsListDB().GetByID(MasterID);
			}
			else
			{
				testsList = new TestsList();
			}
			testsList.StandardNumber = this.txtStandardNumber.Text;
			testsList.AshghalTestNumber = this.txtAshghalTestNumber.Text;
			testsList.TestName = this.txtTestName.Text;
			testsList.TestDescription = this.txtTestDescription.Text;
			testsList.ShortName = this.txtShortName.Text;
			testsList.FKAccreditionID = Convert.ToInt32(this.cmbFKAccreditionID.Value);
			testsList.FKLabID = Convert.ToInt32(this.cmbFKLabID.Value);
			testsList.ResultUnit = this.txtResultUnit.Text;
			testsList.ResultSpecs = this.txtResultSpecs.Text;
			testsList.SamplingMethod = this.txtSamplingMethod.Text;
			testsList.WorkFormFileName = this.txtWorkform.Text;
			testsList.WorkFormWorksheet = this.cmbWorkform.Text;
			testsList.ReportFileName = this.txtReport.Text;
			testsList.ReportWorksheet = this.cmbReport.Text;
			testsList.DefaultPrice = new decimal?(Convert.ToDecimal(this.txtDefaultPrice.Text));
			testsList.MinimumPrice = new decimal?(Convert.ToDecimal(this.txtMinimumPrice.Text));
			testsList.IsUnavailable = this.IsUnavailableTest.Checked;
			testsList.IsSubcontractedTest = this.IsSubcontractedTest.Checked;
			testsList.IsSiteTest = this.IsSiteTest.Checked;
			if (this.cmbFKTestID.Value != null)
			{
				testsList.FKTestID = new int?(Convert.ToInt32(this.cmbFKTestID.Value));
			}
			testsList.IsLocked = this.IsClosed.Checked;
			testsList.FkGroupId = (int?)this.cmbReportGroup.Value;
			if (this.Session["Test"] != null)
			{
				testsList.Image = this.Session["Test"].ToString();
			}
			else
			{
				testsList.Image = "no_image.png";
			}
			return testsList;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00003627 File Offset: 0x00001827
		protected void TestsListDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00003663 File Offset: 0x00001863
		protected void TestsListDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000369F File Offset: 0x0000189F
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("LabTestInfoManage.aspx");
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00016844 File Offset: 0x00014A44
		protected void uplWorkbookfile_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
		{
			try
			{
				string text = base.Server.MapPath("~/Uploaded/LabTestInfo/" + e.UploadedFile.FileName);
				this.txtWorkform.Text = e.UploadedFile.FileName;
				e.CallbackData = e.UploadedFile.FileName;
				e.UploadedFile.SaveAs(text);
				this.Session["WorkformWorksheetList"] = this.GetSheetListFromExcel(text);
			}
			catch (Exception ex)
			{
				this.LogError(ex);
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message + ((ex.InnerException == null) ? "" : ("IE: " + ex.InnerException.Message));
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000036B1 File Offset: 0x000018B1
		protected void cmbWorkform_Callback(object sender, CallbackEventArgsBase e)
		{
			this.cmbWorkform.DataBind();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0001693C File Offset: 0x00014B3C
		protected void uplReportfile_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
		{
			try
			{
				string text = base.Server.MapPath("~/Uploaded/LabTestInfo/" + e.UploadedFile.FileName);
				this.txtReport.Text = e.UploadedFile.FileName;
				e.CallbackData = e.UploadedFile.FileName;
				e.UploadedFile.SaveAs(text);
				this.Session["ReportWorksheetList"] = this.GetSheetListFromExcel(text);
			}
			catch (Exception ex)
			{
				this.LogError(ex);
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message + ((ex.InnerException == null) ? "" : ("IE: " + ex.InnerException.Message));
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000036BE File Offset: 0x000018BE
		protected void cmbReport_Callback(object sender, CallbackEventArgsBase e)
		{
			this.cmbReport.DataBind();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00016A34 File Offset: 0x00014C34
		private List<string> GetSheetListFromExcel(string FilePath)
		{
			Workbook workbook = new Workbook();
			workbook.InvalidFormatException += this.book_InvalidFormatException;
			workbook.LoadDocument(FilePath);
			return (from x in workbook.Worksheets
			select x.Name).ToList<string>();
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00016A90 File Offset: 0x00014C90
		private void book_InvalidFormatException(object sender, SpreadsheetInvalidFormatExceptionEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-danger";
			this.LblError.ForeColor = Color.Red;
			this.LblError.Text = e.Exception.Message;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000036CB File Offset: 0x000018CB
		private void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
		{
			e.Action = DataTableExporterAction.Continue;
			e.DataTableValue = null;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00016AE0 File Offset: 0x00014CE0
		protected void gdvColumnMapping_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			bool flag = Convert.ToBoolean(this.isreport.Text);
			e.NewValues["FKTestID"] = num;
			e.NewValues["IsForReport"] = flag;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00016B3C File Offset: 0x00014D3C
		protected void GdvTestItemsList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			if (num > 0)
			{
				e.NewValues["FKTestID"] = num;
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00016B74 File Offset: 0x00014D74
		protected void GdvTestItemsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			e.NewValues["FKTestID"] = num;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00016B3C File Offset: 0x00014D3C
		protected void GdvTestPriceList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			if (num > 0)
			{
				e.NewValues["FKTestID"] = num;
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00016B74 File Offset: 0x00014D74
		protected void GdvTestPriceList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			e.NewValues["FKTestID"] = num;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00016BA8 File Offset: 0x00014DA8
		protected void lstEquipmentList_DataBound(object sender, EventArgs e)
		{
			ASPxCheckBoxList aspxCheckBoxList = (ASPxCheckBoxList)sender;
			List<TestEquipments> source = this.TestEquipmentsDS.Select() as List<TestEquipments>;
			List<int> list = (from x in source
			select x.FKEquipmentID).ToList<int>();
			for (int i = 0; i < aspxCheckBoxList.Items.Count; i++)
			{
				aspxCheckBoxList.Items[i].Selected = list.Contains((int)aspxCheckBoxList.Items[i].Value);
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00016C3C File Offset: 0x00014E3C
		protected void TestEquipmentsDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int fktestID = Convert.ToInt32(this.lblMasterId.Text);
			SelectedValueCollection selectedValues = this.lstEquipmentList.SelectedValues;
			List<TestEquipments> list = new List<TestEquipments>();
			foreach (object value in ((IEnumerable)selectedValues))
			{
				list.Add(new TestEquipments
				{
					FKTestID = fktestID,
					FKEquipmentID = Convert.ToInt32(value)
				});
			}
			if (list.Count == 0)
			{
				list.Add(new TestEquipments
				{
					FKTestID = fktestID,
					FKEquipmentID = 0
				});
			}
			e.InputParameters["entityList"] = list;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00016D0C File Offset: 0x00014F0C
		protected void lstSubContractors_DataBound(object sender, EventArgs e)
		{
			ASPxCheckBoxList aspxCheckBoxList = (ASPxCheckBoxList)sender;
			List<TestContractors> source = this.TestContractorsDS.Select() as List<TestContractors>;
			List<int> list = (from x in source
			select x.FKSubContractorID).ToList<int>();
			for (int i = 0; i < aspxCheckBoxList.Items.Count; i++)
			{
				aspxCheckBoxList.Items[i].Selected = list.Contains((int)aspxCheckBoxList.Items[i].Value);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00016DA0 File Offset: 0x00014FA0
		protected void TestContractorsDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int fktestID = Convert.ToInt32(this.lblMasterId.Text);
			SelectedValueCollection selectedValues = this.lstSubContractors.SelectedValues;
			List<TestContractors> list = new List<TestContractors>();
			foreach (object value in ((IEnumerable)selectedValues))
			{
				list.Add(new TestContractors
				{
					FKTestID = fktestID,
					FKSubContractorID = Convert.ToInt32(value)
				});
			}
			if (list.Count == 0)
			{
				list.Add(new TestContractors
				{
					FKTestID = fktestID,
					FKSubContractorID = 0
				});
			}
			e.InputParameters["entityList"] = list;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
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

		// Token: 0x06000288 RID: 648 RVA: 0x00016E70 File Offset: 0x00015070
		protected void GdvTestPriceList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "Negative Numbers Not Accepted In Default Price and Minimum Price ")
			{
				e.ErrorText = "Negative Numbers  Not Accepted In Default Price and Minimum Price ";
			}
			if (e.Exception.InnerException.Message == "Default price should be same or more than Minimum price")
			{
				e.ErrorText = "Default price should be same or more than Minimum price";
			}
			if (e.Exception.InnerException.Message == "Cant repeate Unit  in same Test")
			{
				e.ErrorText = "Cant repeate Unit  in same Test";
			}
			if (e.Exception.InnerException.Message == "this unit is used !")
			{
				e.ErrorText = "this unit is used !";
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00016F38 File Offset: 0x00015138
		protected void gdvColumnMapping_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00016FB4 File Offset: 0x000151B4
		protected void gdvColumnMapping_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
		{
			foreach (ASPxDataUpdateValues aspxDataUpdateValues in e.UpdateValues)
			{
				this.UpdateItem(aspxDataUpdateValues.Keys, aspxDataUpdateValues.NewValues);
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00017014 File Offset: 0x00015214
		protected ViewExcelCellFieldMapping UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
		{
			List<ViewExcelCellFieldMapping> source = new List<ViewExcelCellFieldMapping>();
			new List<ViewExcelCellFieldMapping>();
			ViewExcelCellFieldMapping viewExcelCellFieldMapping = new ViewExcelCellFieldMapping();
			source = new TestExcelMappingDB().GetFieldCellMappingListByTestId(int.Parse(this.lblMasterId.Text.ToString()));
			int id = Convert.ToInt32(keys["ExcelMappingFieldId"]);
			viewExcelCellFieldMapping = source.First((ViewExcelCellFieldMapping j) => j.ExcelMappingFieldId == id);
			this.LoadNewValues(viewExcelCellFieldMapping, newValues);
			
            //string workFormFileName = "";
			//string workFormWorksheet = "";
			//string reportFileName = "";
			//string reportWorksheet = "";
			//if (viewExcelCellFieldMapping.FKTestID == 0)
			//{
			//	workFormFileName = this.txtWorkform.Text;
			//	workFormWorksheet = this.cmbWorkform.Text;
			//	reportFileName = this.txtReport.Text;
			//	reportWorksheet = this.cmbReport.Text;
			//}
			if (!viewExcelCellFieldMapping.IsForReport)
			{
				//if (!new TestExcelMappingDB().CheckValidateWorkbookCell(viewExcelCellFieldMapping.ExcelCell, viewExcelCellFieldMapping.FKTestID, workFormFileName, workFormWorksheet))
				//{
				//	this.lblMappingError.Visible = true;
				//	this.lblMappingError.Text = "Not Vaild Cell";
				//	string message = "Cell " + viewExcelCellFieldMapping.ExcelCell + " Not Vaild ";
				//	throw new Exception(message);
				//}
				new TestExcelMappingDB().UpdateMappingWithSession(viewExcelCellFieldMapping);
			}
			else
			{
				//if (!new TestExcelMappingDB().CheckValidateReportCell(viewExcelCellFieldMapping.ExcelCell, viewExcelCellFieldMapping.FKTestID, reportFileName, reportWorksheet))
				//{
				//	this.lblMappingError.Visible = true;
				//	this.lblMappingError.Text = "Not Vaild Cell";
				//	string message2 = "Cell " + viewExcelCellFieldMapping.ExcelCell + " Not Vaild ";
				//	throw new Exception(message2);
				//}
				new TestExcelMappingDB().UpdateMappingWithSession(viewExcelCellFieldMapping);
			}
			return viewExcelCellFieldMapping;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x000036DB File Offset: 0x000018DB
		private void LoadNewValues(ViewExcelCellFieldMapping det, OrderedDictionary values)
		{
			det.ExcelCell = values["ExcelCell"].ToString();
			det.IsForReport = Convert.ToBoolean(this.isreport.Text);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000171B8 File Offset: 0x000153B8
		protected void GdvTestPriceList_StartRowEditing(object sender, ASPxStartRowEditingEventArgs e)
		{
			GridViewDataComboBoxColumn gridViewDataComboBoxColumn = this.GdvTestPriceList.Columns["Unit"] as GridViewDataComboBoxColumn;
			gridViewDataComboBoxColumn.EditFormSettings.Visible = DefaultBoolean.False;
			gridViewDataComboBoxColumn.ReadOnly = true;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00003709 File Offset: 0x00001909
		protected void uplImage_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
		{
			e.CallbackData = this.SavePostedFile(e.UploadedFile);
			this.Session["Test"] = e.CallbackData;
			this.previewImage.Src = e.CallbackData;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000171F4 File Offset: 0x000153F4
		private string SavePostedFile(UploadedFile uploadedFile)
		{
			if (!uploadedFile.IsValid)
			{
				return string.Empty;
			}
			string text = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(uploadedFile.FileName);
			string fileName = Path.Combine(base.MapPath("../Uploaded/Tests/"), text);
			using (System.Drawing.Image image = System.Drawing.Image.FromStream(uploadedFile.FileContent))
			{
				using (System.Drawing.Image image2 = PhotoUtils.Inscribe(image, 150))
				{
					PhotoUtils.SaveToJpeg(image2, fileName);
				}
			}
			this.Session["Test"] = text;
			return text;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00003744 File Offset: 0x00001944
		private void PreviewImage()
		{
			if (this.Session["Test"] != null)
			{
				this.previewImage.Src = "../Uploaded/Tests/" + Convert.ToString(this.Session["Test"]);
			}
		}

		// Token: 0x040003E1 RID: 993
		private const string UploadDirectory = "../Uploaded/Tests/";

		// Token: 0x040003E2 RID: 994
		protected HtmlGenericControl ultitle;

		// Token: 0x040003E3 RID: 995
		protected ASPxLabel lblView;

		// Token: 0x040003E4 RID: 996
		protected ASPxLabel lblEdite;

		// Token: 0x040003E5 RID: 997
		protected ASPxLabel lblDelete;

		// Token: 0x040003E6 RID: 998
		protected ASPxLabel lblAdd;

		// Token: 0x040003E7 RID: 999
		protected ASPxButton BtnSave;

		// Token: 0x040003E8 RID: 1000
		protected ASPxButton BtnBack;

		// Token: 0x040003E9 RID: 1001
		protected ASPxButton BtnPrint;

		// Token: 0x040003EA RID: 1002
		protected HtmlGenericControl divmsg;

		// Token: 0x040003EB RID: 1003
		protected ASPxLabel LblError;

		// Token: 0x040003EC RID: 1004
		protected ASPxLabel lblMasterId;

		// Token: 0x040003ED RID: 1005
		protected ASPxFormLayout flTestsList;

		// Token: 0x040003EE RID: 1006
		protected HtmlImage previewImage;

		// Token: 0x040003EF RID: 1007
		protected ASPxLabel LblImageName;

		// Token: 0x040003F0 RID: 1008
		protected ASPxUploadControl uplImage;

		// Token: 0x040003F1 RID: 1009
		protected ASPxButton btnUpload;

		// Token: 0x040003F2 RID: 1010
		protected ASPxCheckBox IsUnavailableTest;

		// Token: 0x040003F3 RID: 1011
		protected ASPxCheckBox IsSubcontractedTest;

		// Token: 0x040003F4 RID: 1012
		protected ASPxCheckBox IsSiteTest;

		// Token: 0x040003F5 RID: 1013
		protected ASPxCheckBox IsClosed;

		// Token: 0x040003F6 RID: 1014
		protected ASPxTextBox txtTestID;

		// Token: 0x040003F7 RID: 1015
		protected ASPxTextBox txtAshghalTestNumber;

		// Token: 0x040003F8 RID: 1016
		protected ASPxTextBox txtStandardNumber;

		// Token: 0x040003F9 RID: 1017
		protected ASPxTextBox txtTestName;

		// Token: 0x040003FA RID: 1018
		protected ASPxTextBox txtShortName;

		// Token: 0x040003FB RID: 1019
		protected ASPxTextBox txtTestDescription;

		// Token: 0x040003FC RID: 1020
		protected ASPxComboBox cmbFKAccreditionID;

		// Token: 0x040003FD RID: 1021
		protected ASPxComboBox cmbFKLabID;

		// Token: 0x040003FE RID: 1022
		protected ASPxTextBox txtResultUnit;

		// Token: 0x040003FF RID: 1023
		protected ASPxTextBox txtResultSpecs;

		// Token: 0x04000400 RID: 1024
		protected ASPxTextBox txtSamplingMethod;

		// Token: 0x04000401 RID: 1025
		protected ASPxComboBox cmbFKTestID;

		// Token: 0x04000402 RID: 1026
		protected ASPxComboBox cmbReportGroup;

		// Token: 0x04000403 RID: 1027
		protected ASPxCheckBoxList lstEquipmentList;

		// Token: 0x04000404 RID: 1028
		protected ASPxCheckBoxList lstSubContractors;

		// Token: 0x04000405 RID: 1029
		protected ASPxTextBox txtWorkform;

		// Token: 0x04000406 RID: 1030
		protected ASPxUploadControl uplWorkbookfile;

		// Token: 0x04000407 RID: 1031
		protected ASPxComboBox cmbWorkform;

		// Token: 0x04000408 RID: 1032
		protected ASPxButton btnWorkform;

		// Token: 0x04000409 RID: 1033
		protected ASPxTextBox txtReport;

		// Token: 0x0400040A RID: 1034
		protected ASPxUploadControl uplReportfile;

		// Token: 0x0400040B RID: 1035
		protected ASPxComboBox cmbReport;

		// Token: 0x0400040C RID: 1036
		protected ASPxButton btnReport;

		// Token: 0x0400040D RID: 1037
		protected ASPxSpinEdit txtDefaultPrice;

		// Token: 0x0400040E RID: 1038
		protected ASPxSpinEdit txtMinimumPrice;

		// Token: 0x0400040F RID: 1039
		protected ASPxGridView GdvTestPriceList;

		// Token: 0x04000410 RID: 1040
		protected ASPxGridView GdvTestItemsList;

		// Token: 0x04000411 RID: 1041
		protected ASPxPopupControl popupMapping;

		// Token: 0x04000412 RID: 1042
		protected PopupControlContentControl PopupControlContentControl2;

		// Token: 0x04000413 RID: 1043
		protected ASPxValidationSummary ASPxValidationSummary2;

		// Token: 0x04000414 RID: 1044
		protected ASPxTextBox vi;

		// Token: 0x04000415 RID: 1045
		protected ASPxTextBox sid;

		// Token: 0x04000416 RID: 1046
		protected ASPxTextBox isreport;

		// Token: 0x04000417 RID: 1047
		protected ASPxGridView gdvColumnMapping;

		// Token: 0x04000418 RID: 1048
		protected ASPxButton btnOk;

		// Token: 0x04000419 RID: 1049
		protected ASPxButton btnPopCancel;

		// Token: 0x0400041A RID: 1050
		protected ASPxLabel lblMappingError;

		// Token: 0x0400041B RID: 1051
		protected ObjectDataSource AccreditionListDS;

		// Token: 0x0400041C RID: 1052
		protected ObjectDataSource LabsListDS;

		// Token: 0x0400041D RID: 1053
		protected ObjectDataSource ReportGroupDS;

		// Token: 0x0400041E RID: 1054
		protected ObjectDataSource RelatedTestsListDS;

		// Token: 0x0400041F RID: 1055
		protected ObjectDataSource TestsListDS;

		// Token: 0x04000420 RID: 1056
		protected ObjectDataSource EquipmentsListDS;

		// Token: 0x04000421 RID: 1057
		protected ObjectDataSource TestEquipmentsDS;

		// Token: 0x04000422 RID: 1058
		protected ObjectDataSource SubcontractorsListDS;

		// Token: 0x04000423 RID: 1059
		protected ObjectDataSource TestContractorsDS;

		// Token: 0x04000424 RID: 1060
		protected ObjectDataSource WorkformWorksheetListDS;

		// Token: 0x04000425 RID: 1061
		protected ObjectDataSource ReportWorksheetListDS;

		// Token: 0x04000426 RID: 1062
		protected ObjectDataSource ItemsListDS;

		// Token: 0x04000427 RID: 1063
		protected ObjectDataSource TestItemsDS;

		// Token: 0x04000428 RID: 1064
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x04000429 RID: 1065
		protected ObjectDataSource TestPricesDS;

		// Token: 0x0400042A RID: 1066
		protected ObjectDataSource FieldListDS;

		// Token: 0x0400042B RID: 1067
		protected ObjectDataSource ColumnMappingDS;
	}
}
