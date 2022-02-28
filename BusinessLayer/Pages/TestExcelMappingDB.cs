using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DevExpress.Spreadsheet;

namespace BusinessLayer.Pages
{
	public class TestExcelMappingDB : DBBase<TestExcelMapping, List<TestExcelMapping>, int>
	{
		public override List<TestExcelMapping> GetAll()
		{
			return ((IEnumerable<TestExcelMapping>)dbContext.TestExcelMapping).ToList();
		}

		public override TestExcelMapping GetByID(int id)
		{
			return ((IQueryable<TestExcelMapping>)dbContext.TestExcelMapping).FirstOrDefault((TestExcelMapping j) => j.TestColMapID == id);
		}

		public override bool Insert(TestExcelMapping entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TestExcelMapping.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "InsertError";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(TestExcelMapping entity, out string message)
		{
			message = "";
			try
			{
				TestExcelMapping byID = GetByID(entity.TestColMapID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TestExcelMapping>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "UpdateError";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(TestExcelMapping entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TestExcelMapping>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "DeleteError";
				return false;
			}
			catch (Exception)
			{
				message = "DeleteError";
				return false;
			}
		}

		public List<ExcelMappingFieldList> GetFieldList()
		{
			return ((IEnumerable<ExcelMappingFieldList>)dbContext.ExcelMappingFieldList).ToList();
		}

		public List<ViewExcelCellFieldMapping> GetFieldCellMappingListByTestId(int TestID)
		{
			return ((IQueryable<ViewExcelCellFieldMapping>)dbContext.ViewExcelCellFieldMapping).Where((ViewExcelCellFieldMapping x) => x.FKTestID == TestID || (int?)x.FKTestID == null).ToList();
		}

		public List<ViewExcelCellFieldMapping> GetMappingListByMasterIDWithSession(int masterId, bool IsReport)
		{
			if (masterId > 0)
			{
				return (from x in GetFieldCellMappingListByTestId(masterId)
					where x.IsForReport == IsReport
					select x).ToList();
			}
			object obj = HttpContext.Current.Session["TestExcelMappingList"];
			if (obj == null)
			{
				obj = GetFieldCellMappingListByTestId(masterId);
				HttpContext.Current.Session["TestExcelMappingList"] = obj;
			}
			return ((List<ViewExcelCellFieldMapping>)obj).Where((ViewExcelCellFieldMapping x) => x.IsForReport == IsReport).ToList();
		}

		public bool UpdateMappingWithSession(ViewExcelCellFieldMapping entity)
		{
			if (entity.FKTestID == 0)
			{
				object obj = HttpContext.Current.Session["TestExcelMappingList"];
				List<ViewExcelCellFieldMapping> list = ((obj == null) ? GetFieldCellMappingListByTestId(entity.FKTestID) : (obj as List<ViewExcelCellFieldMapping>));
				ViewExcelCellFieldMapping viewExcelCellFieldMapping = list.First((ViewExcelCellFieldMapping x) => x.ExcelMappingFieldId == entity.ExcelMappingFieldId && x.IsForReport == entity.IsForReport);
				viewExcelCellFieldMapping.ExcelCell = entity.ExcelCell;
				HttpContext.Current.Session["TestExcelMappingList"] = list;
				return true;
			}
			TestExcelMapping testExcelMapping = ((IQueryable<TestExcelMapping>)dbContext.TestExcelMapping).FirstOrDefault((TestExcelMapping x) => x.FKTestID == entity.FKTestID && x.IsForReport == entity.IsForReport && x.FieldName == entity.FieldName);
			if (testExcelMapping != null)
			{
				testExcelMapping.ExcelCell = entity.ExcelCell;
			}
			else
			{
				testExcelMapping = new TestExcelMapping();
				testExcelMapping.FKTestID = entity.FKTestID;
				testExcelMapping.IsForReport = entity.IsForReport;
				testExcelMapping.FieldName = GetFieldNameById(entity.ExcelMappingFieldId);
				testExcelMapping.ExcelCell = entity.ExcelCell;
				dbContext.TestExcelMapping.Add(testExcelMapping);
			}
			return ((DbContext)dbContext).SaveChanges() > 0;
		}

		private string GetFieldNameById(int id)
		{
			return ((IQueryable<ExcelMappingFieldList>)dbContext.ExcelMappingFieldList).FirstOrDefault((ExcelMappingFieldList x) => x.ExcelMappingFieldId == id).FieldName;
		}

		public bool UpdateMapping(ViewExcelCellFieldMapping entity)
		{
			return true;
		}

		public bool CheckValidateWorkbookCell(string Cell, int FKTestID, string WorkFormFileName, string WorkFormWorksheet)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			if (FKTestID > 0)
			{
				TestsList byID = new TestsListDB().GetByID(FKTestID);
				Workbook val = new Workbook();
				string text = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + byID.WorkFormFileName);
				val.LoadDocument(text, DocumentFormat.Xlsx);
				Worksheet val2 = val.Worksheets[byID.WorkFormWorksheet];
				string text2 = Convert.ToString(((Range)val2.Cells[Cell]).Value);
				if ((text2 == null || text2 == "") && !((Formatting)val2.Cells[Cell]).Protection.Locked)
				{
					return true;
				}
				return false;
			}
			Workbook val3 = new Workbook();
			string text3 = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + WorkFormFileName);
			val3.LoadDocument(text3, DocumentFormat.Xlsx);
			Worksheet val4 = val3.Worksheets[WorkFormWorksheet];
			string text4 = Convert.ToString(((Range)val4.Cells[Cell]).Value);
			if ((text4 == null || text4 == "") && !((Formatting)val4.Cells[Cell]).Protection.Locked)
			{
				return true;
			}
			return false;
		}

		public bool CheckValidateReportCell(string Cell, int FKTestID, string ReportFileName, string ReportWorksheet)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			if (FKTestID > 0)
			{
				TestsList byID = new TestsListDB().GetByID(FKTestID);
				Workbook val = new Workbook();
				string text = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + byID.ReportFileName);
				val.LoadDocument(text, DocumentFormat.Xlsx);
				Worksheet val2 = val.Worksheets[byID.ReportWorksheet];
				string text2 = Convert.ToString(((Range)val2.Cells[Cell]).Value);
				if ((text2 == null || text2 == "") && !((Formatting)val2.Cells[Cell]).Protection.Locked)
				{
					return true;
				}
				return false;
			}
			Workbook val3 = new Workbook();
			string text3 = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + ReportFileName);
			val3.LoadDocument(text3, DocumentFormat.Xlsx);
			Worksheet val4 = val3.Worksheets[ReportWorksheet];
			string text4 = Convert.ToString(((Range)val4.Cells[Cell]).Value);
			if ((text4 == null || text4 == "") && !((Formatting)val4.Cells[Cell]).Protection.Locked)
			{
				return true;
			}
			return false;
		}

		public TestExcelMapping GetFieldCellMappingListByTestIdAndFieldName(long FKTestID, bool IsForReport, string FieldName)
		{
			return ((IQueryable<TestExcelMapping>)dbContext.TestExcelMapping).FirstOrDefault((TestExcelMapping x) => (long)x.FKTestID == FKTestID && x.IsForReport == IsForReport && x.FieldName == FieldName);
		}
	}
}
