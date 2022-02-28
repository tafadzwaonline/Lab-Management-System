using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using DevExpress.Compression;
using DevExpress.Spreadsheet;

namespace BusinessLayer.Pages
{
	public class ExcelHandlingCLS
	{
        //public const string SampleNumber = "Sample Number";
        //public const string ReceiveDate = "Receive Date";
        //public const string RSSNumber = "RSS Number";
        //public const string JobOrderNumber = "Job Order Number";
        //public const string Customer = "Customer";
        //public const string Project = "Project";
        //public const string ProjectNumber = "Project Number";
        //public const string ProjectOwner = "Project Owner";
        //public const string ProjectContractor = "Project Contractor";
        //public const string ProjectType = "Project Type";
        //public const string ProjectLocation = "Project Location";
        //public const string ProjectConsultant = "Project Consultant";
        //public const string ConsultantName = "Consultant Name";
        //public const string ConsultantMobileNo = "Consultant Mobile No";
        //public const string ContactPersonatSite = "Contact Person at Site";
        //public const string ContactPersonMobileNo = "Contact Person Mobile No";
        //public const string DelivererName = "Deliverer Name";
        //public const string DelivererMobileNo = "Deliverer Mobile No";
        //public const string Supplier = "Supplier";
        //public const string Source = "Source";
        //public const string SamplingDate = "Sampling Date";
        //public const string SampleDescription = "Sample Description";
        //public const string SampleLocation = "Sample Location";
        //public const string Sampledby = "Sampled by";
        //public const string SampleByName = "Sample By Name";
        //public const string SiteRefNo = "Site Ref No";
        //public const string Samplebroughtinby = "Sample brought in by";
        //public const string BroughtinbyName = "Brought in by Name";
        //public const string BroughtinDate = "Brought in Date";
        //public const string LayerNo = "Layer No";
        //public const string ServiceSection = "Service Section";
        //public const string MaterialDetails = "Material Details";
        //public const string MaterialClass = "Material Class";
        //public const string ReceivedQty = "Received Qty";
        //public const string Unit = "Unit";
        //public const string Retentionperiod = "Retention period";
        //public const string SampleCondition = "Sample Condition";
        //public const string ConditionDetails = "Condition Details";
        //public const string SampleTemperature = "Sample Temperature";

        public bool GenerateXlsBySampleID(long SampleID)
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Expected O, but got Unknown
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			try
			{
                SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
                SampleReceiveList sampleReceive = sampleReceiveListDB.GetByID(SampleID);

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
				List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
				DataTable sampleFieldsBySampleID = sampleReceiveTestListDB.GetSampleFieldsBySampleID(SampleID);
                string destinationPath = System.Configuration.ConfigurationManager.AppSettings["SampleFilePath"];
                foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
                    if (testsList == null || testsList.TestExcelMapping == null)
                        continue;

					List<TestExcelMapping> source = testsList.TestExcelMapping.ToList();
                    if (source.Count == 0)
                        continue;

					Workbook val = new Workbook();
                    string sourceFile = "";
                    string destinationFileName = "";

                    if (!string.IsNullOrWhiteSpace(testsList.WorkFormFileName) && !string.IsNullOrWhiteSpace(testsList.WorkFormWorksheet))
                    {
                        sourceFile = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.WorkFormFileName);
                        if (File.Exists(sourceFile))
                        {
                            destinationFileName = string.Format(@"{0}\{1}\{2}{3}", destinationPath, sampleReceive.SampleNo, item.SampleReceiveTestID, Path.GetExtension(testsList.WorkFormFileName)); //testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
                                                                                                                                                                                                      //destinationFullName = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + destinationFileName);
                            FileInfo dest = new FileInfo(destinationFileName);
                            val.LoadDocument(sourceFile, DocumentFormat.Xlsx);
                            Worksheet val2 = val.Worksheets[testsList.WorkFormWorksheet];
                            foreach (TestExcelMapping item2 in source.Where((TestExcelMapping x) => !x.IsForReport).ToList())
                            {
                                val2.Cells[item2.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString());
                            }

                            if (!dest.Directory.Exists)
                                dest.Directory.Create();

                            val.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        }
                    }

                    if (string.IsNullOrWhiteSpace(testsList.ReportFileName) || string.IsNullOrWhiteSpace(testsList.ReportWorksheet))
                    {
                        sourceFile = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.ReportFileName);
                        if (File.Exists(sourceFile))
                        {
                            val = new Workbook();
                            destinationFileName = string.Format("{0}/{1}/{2}{3}", destinationPath, sampleReceive.SampleNo, item.SampleReceiveTestID, Path.GetExtension(testsList.ReportFileName)); //testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
                                                                                                                                                                                                   //destinationFullName = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + destinationFileName);
                            FileInfo dest = new FileInfo(destinationFileName);
                            val.LoadDocument(sourceFile, DocumentFormat.Xlsx);
                            Worksheet val2 = val.Worksheets[testsList.ReportWorksheet];
                            foreach (TestExcelMapping item3 in source.Where((TestExcelMapping x) => x.IsForReport).ToList())
                            {
                                val2.Cells[item3.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString());
                            }

                            if (!dest.Directory.Exists)
                                dest.Directory.Create();

                            val.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        }
                    }
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool GenerateSingleXlsBySampleID(long SampleID)
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
				List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
				DataTable sampleFieldsBySampleID = sampleReceiveTestListDB.GetSampleFieldsBySampleID(SampleID);
				foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
					List<TestExcelMapping> source = testsList.TestExcelMapping.ToList();
					Workbook val = new Workbook();
					Workbook val2 = new Workbook();
					string text = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.WorkFormFileName);
					string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					string text2 = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.LoadDocument(text, DocumentFormat.Xlsx);
					Worksheet val3 = val.Worksheets[testsList.WorkFormWorksheet];
					foreach (TestExcelMapping item2 in source.Where((TestExcelMapping x) => !x.IsForReport).ToList())
					{
						val3.Cells[item2.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString());
					}
					val2.Worksheets.Add(testsList.WorkFormWorksheet);
					val2.Worksheets[testsList.WorkFormWorksheet].CopyFrom(val3);
					val.SaveDocument(text2, DocumentFormat.Xlsx);
					val = new Workbook();
					text = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.ReportFileName);
					str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					text2 = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.LoadDocument(text, DocumentFormat.Xlsx);
					val3 = val.Worksheets[testsList.ReportWorksheet];
					foreach (TestExcelMapping item3 in source.Where((TestExcelMapping x) => x.IsForReport).ToList())
					{
						val3.Cells[item3.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString());
					}
					val.SaveDocument(text2, DocumentFormat.Xlsx);
					val2.Worksheets.Add(testsList.ReportWorksheet);
					val2.Worksheets[testsList.ReportWorksheet].CopyFrom(val3);
					val2.SaveDocument(HttpContext.Current.Server.MapPath("~/SavedDocuments/Output.xlsx"), DocumentFormat.Xlsx);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string GetReportListPathBySampleID(long SampleID)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
			List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
			ZipArchive val = new ZipArchive();
			try
			{
				foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
					string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					string text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
					str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
				}
				val.Save(HttpContext.Current.Server.MapPath("~/Temp/GeneratedFiles.zip"));
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return HttpContext.Current.Server.MapPath("~/Temp/GeneratedFiles.zip");
		}

		public MemoryStream GetReportListStreamBySampleID(long SampleID)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			MemoryStream memoryStream = new MemoryStream();
			SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
			List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
			ZipArchive val = new ZipArchive();
			try
			{
				foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
					string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					string text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
					str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
				}
				val.Save((Stream)memoryStream);
				return memoryStream;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}
}
