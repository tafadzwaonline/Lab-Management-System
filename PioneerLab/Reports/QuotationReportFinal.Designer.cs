using DevExpress.DataAccess;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;

namespace PioneerLab.Reports
{
	public class QuotationReportFinal : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private XRLabel xrLabel1;

		private XRLabel xrLabel2;

		private XRLabel xrLabel3;

		private XRLabel xrLabel35;

		private SqlDataSource sqlDataSource1;

		private ReportHeaderBand reportHeaderBand1;

		private XRControlStyle Title;

		private XRControlStyle FieldCaption;

		private XRControlStyle PageInfo;

		private XRControlStyle DataField;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableRow xrTableRow2;

		private XRTableCell xrTableCell2;

		private XRTableRow xrTableRow3;

		private XRTableCell xrTableCell3;

		private XRTableRow xrTableRow4;

		private XRTableCell xrTableCell4;

		private XRTableRow xrTableRow5;

		private XRTableCell xrTableCell5;

		private XRTableRow xrTableRow6;

		private XRTableCell xrTableCell6;

		private XRTableRow xrTableRow7;

		private XRTableCell xrTableCell7;

		private XRTable xrTable2;

		private XRTableRow xrTableRow8;

		private XRTableCell xrTableCell8;

		private XRTableRow xrTableRow9;

		private XRTableCell xrTableCell9;

		private DetailReportBand DetailReport;

		private DetailBand Detail1;

		private GroupHeaderBand GroupHeader1;

		private XRTable xrTable3;

		private XRTableRow xrTableRow10;

		private XRTableCell xrTableCell10;

		private XRTableCell xrTableCell11;

		private XRTableCell xrTableCell12;

		private XRTableCell xrTableCell13;

		private XRTableCell xrTableCell14;

		private XRTableCell xrTableCell15;

		private XRTableCell xrTableCell16;

		private XRTable xrTable4;

		private XRTableRow xrTableRow11;

		private XRTableCell xrTableCell18;

		private XRTableCell xrTableCell19;

		private XRTableCell xrTableCell20;

		private XRTableCell xrTableCell21;

		private XRTableCell xrTableCell22;

		private XRTableCell xrTableCell23;

		private XRTableCell xrTableCell24;

		private DetailReportBand DetailReport1;

		private DetailBand Detail2;

		private XRTableCell xrTableCell17;

		private XRLabel xrLabel28;

		private XRTableCell xrTableCell25;

		private XRTableCell xrTableCell27;

		private XRTableCell xrTableCell26;

		private CalculatedField calculatedField1;

		private XRTableCell xrTableCell28;

		private XRTableCell xrTableCell29;

		private XRTableCell xrTableCell30;

		private XRTableCell xrTableCell31;

		private XRTableCell xrTableCell32;

		private XRTableCell xrTableCell33;

		private XRTableCell xrTableCell34;

		private CalculatedField ExpiresDay;

		private ReportFooterBand ReportFooter;

		private DetailReportBand DetailReport2;

		private DetailBand Detail3;

		private XRLabel xrLabel4;

		private Parameter QID;

		private XRTable xrTable7;

		private XRTableRow xrTableRow16;

		private XRTableCell xrTableCell49;

		private XRTableCell xrTableCell38;

		private XRTableCell xrTableCell40;

		private CalculatedField calculatedField2;

		private XRPageInfo xrPageInfo4;

		private PageHeaderBand PageHeader;

		private DetailReportBand DetailReport3;

		private DetailBand Detail4;

		private XRLabel xrLabel5;

		private XRTable xrTable5;

		private XRTableRow xrTableRow12;

		private XRTableCell xrTableCell35;

		private XRTableCell xrTableCell36;

		private XRTableCell xrTableCell37;

		private XRTableCell xrTableCell39;

		private XRLabel xrLabel21;

		private XRTable xrTable9;

		private XRTableRow xrTableRow15;

		private XRTableCell xrTableCell43;

		private XRLabel xrLabel22;

		private XRLabel xrLabel26;

		public QuotationReportFinal()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuotationReportFinal));
			CustomSqlQuery str = new CustomSqlQuery();
			SelectQuery selectQuery = new SelectQuery();
			Column column = new Column();
			ColumnExpression columnExpression = new ColumnExpression();
			Table table = new Table();
			Column column1 = new Column();
			ColumnExpression columnExpression1 = new ColumnExpression();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo1 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo1 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSetting = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell28 = new XRTableCell();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell29 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell30 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell31 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableRow5 = new XRTableRow();
			this.xrTableCell32 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableRow6 = new XRTableRow();
			this.xrTableCell33 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableRow7 = new XRTableRow();
			this.xrTableCell34 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTable2 = new XRTable();
			this.xrTableRow8 = new XRTableRow();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrLabel28 = new XRLabel();
			this.xrTableRow9 = new XRTableRow();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell25 = new XRTableCell();
			this.xrLabel1 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel35 = new XRLabel();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.xrPageInfo4 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable4 = new XRTable();
			this.xrTableRow11 = new XRTableRow();
			this.xrTableCell38 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell23 = new XRTableCell();
			this.xrTableCell24 = new XRTableCell();
			this.xrTableCell27 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable3 = new XRTable();
			this.xrTableRow10 = new XRTableRow();
			this.xrTableCell40 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell16 = new XRTableCell();
			this.xrTableCell26 = new XRTableCell();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrLabel4 = new XRLabel();
			this.xrTable7 = new XRTable();
			this.xrTableRow16 = new XRTableRow();
			this.xrTableCell49 = new XRTableCell();
			this.ReportFooter = new ReportFooterBand();
			this.DetailReport2 = new DetailReportBand();
			this.Detail3 = new DetailBand();
			this.calculatedField1 = new CalculatedField();
			this.ExpiresDay = new CalculatedField();
			this.QID = new Parameter();
			this.calculatedField2 = new CalculatedField();
			this.PageHeader = new PageHeaderBand();
			this.xrLabel5 = new XRLabel();
			this.DetailReport3 = new DetailReportBand();
			this.Detail4 = new DetailBand();
			this.xrTableCell39 = new XRTableCell();
			this.xrTableCell37 = new XRTableCell();
			this.xrTableCell36 = new XRTableCell();
			this.xrTableCell35 = new XRTableCell();
			this.xrTableRow12 = new XRTableRow();
			this.xrTable5 = new XRTable();
			this.xrLabel21 = new XRLabel();
			this.xrTableCell43 = new XRTableCell();
			this.xrTableRow15 = new XRTableRow();
			this.xrTable9 = new XRTable();
			this.xrLabel22 = new XRLabel();
			this.xrLabel26 = new XRLabel();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this.xrTable3).BeginInit();
			((ISupportInitialize)this.xrTable7).BeginInit();
			((ISupportInitialize)this.xrTable5).BeginInit();
			((ISupportInitialize)this.xrTable9).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "QuotationMaster";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			str.Name = "QuotationDetails";
			str.Sql = componentResourceManager.GetString("customSqlQuery2.Sql");
			columnExpression.ColumnName = "ContactPerson";
			table.MetaSerializable = "30|30|125|360";
			table.Name = "EnquiryMaster";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression1.ColumnName = "EnquiryMasterID";
			columnExpression1.Table = table;
			column1.Expression = columnExpression1;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column1);
			selectQuery.Name = "EnquiryMaster";
			selectQuery.Tables.Add(table);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { customSqlQuery, str, selectQuery });
			masterDetailInfo.DetailQueryName = "QuotationDetails";
			relationColumnInfo.NestedKeyColumn = "FKQuotationMasterID";
			relationColumnInfo.ParentKeyColumn = "QuotationMasterID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo);
			masterDetailInfo.MasterQueryName = "QuotationMaster";
			masterDetailInfo1.DetailQueryName = "EnquiryMaster";
			relationColumnInfo1.NestedKeyColumn = "EnquiryMasterID";
			relationColumnInfo1.ParentKeyColumn = "FKEnquiryMasterID";
			masterDetailInfo1.KeyColumns.Add(relationColumnInfo1);
			masterDetailInfo1.MasterQueryName = "QuotationMaster";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[] { masterDetailInfo, masterDetailInfo1 });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			XRControlCollection controls = this.Detail.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrTable1, this.xrTable2, this.xrLabel1, this.xrLabel2, this.xrLabel3, this.xrLabel35 };
			controls.AddRange(xRControlArrays);
			this.Detail.Dpi = 100f;
			this.Detail.Font = new System.Drawing.Font("Times New Roman", 10.4f);
			this.Detail.HeightF = 268.75f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.SnapLinePadding = new PaddingInfo(10, 10, 50, 10, 100f);
			this.Detail.StylePriority.UseFont = false;
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTable1.LocationFloat = new PointFloat(22.58333f, 10.00001f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection rows = this.xrTable1.Rows;
			XRTableRow[] xRTableRowArray = new XRTableRow[] { this.xrTableRow1, this.xrTableRow2, this.xrTableRow3, this.xrTableRow4, this.xrTableRow5, this.xrTableRow6, this.xrTableRow7 };
			rows.AddRange(xRTableRowArray);
			this.xrTable1.SizeF = new System.Drawing.SizeF(347.5367f, 138.5417f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			XRTableCellCollection cells = this.xrTableRow1.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell28, this.xrTableCell1 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1;
			this.xrTableCell28.Borders = BorderSide.All;
			this.xrTableCell28.Dpi = 100f;
			this.xrTableCell28.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell28.Name = "xrTableCell28";
			this.xrTableCell28.StylePriority.UseBorders = false;
			this.xrTableCell28.StylePriority.UseFont = false;
			this.xrTableCell28.Text = "To,";
			this.xrTableCell28.Weight = 0.654192570415936;
			this.xrTableCell1.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseBorders = false;
			this.xrTableCell1.Weight = 1.34580742958406;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow2.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell29, this.xrTableCell2 };
			xRTableCellCollections.AddRange(xRTableCellArray1);
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 1;
			this.xrTableCell29.Borders = BorderSide.All;
			this.xrTableCell29.Dpi = 100f;
			this.xrTableCell29.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell29.Name = "xrTableCell29";
			this.xrTableCell29.StylePriority.UseBorders = false;
			this.xrTableCell29.StylePriority.UseFont = false;
			this.xrTableCell29.Text = "Customer Name:";
			this.xrTableCell29.Weight = 0.654192570415936;
			this.xrTableCell2.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection dataBindings = this.xrTableCell2.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.CustomerName") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.StylePriority.UseBorders = false;
			this.xrTableCell2.StylePriority.UseFont = false;
			this.xrTableCell2.Weight = 1.34580742958406;
			XRTableCellCollection cells1 = this.xrTableRow3.Cells;
			XRTableCell[] xRTableCellArray2 = new XRTableCell[] { this.xrTableCell30, this.xrTableCell3 };
			cells1.AddRange(xRTableCellArray2);
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 1;
			this.xrTableCell30.Borders = BorderSide.All;
			this.xrTableCell30.Dpi = 100f;
			this.xrTableCell30.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell30.Name = "xrTableCell30";
			this.xrTableCell30.StylePriority.UseBorders = false;
			this.xrTableCell30.StylePriority.UseFont = false;
			this.xrTableCell30.Text = "P.O.Box:";
			this.xrTableCell30.Weight = 0.654192570415936;
			this.xrTableCell3.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection xRBindingCollections = this.xrTableCell3.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.POBox") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.StylePriority.UseBorders = false;
			this.xrTableCell3.Weight = 1.34580742958406;
			XRTableCellCollection xRTableCellCollections1 = this.xrTableRow4.Cells;
			XRTableCell[] xRTableCellArray3 = new XRTableCell[] { this.xrTableCell31, this.xrTableCell4 };
			xRTableCellCollections1.AddRange(xRTableCellArray3);
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 1;
			this.xrTableCell31.Borders = BorderSide.All;
			this.xrTableCell31.Dpi = 100f;
			this.xrTableCell31.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell31.Name = "xrTableCell31";
			this.xrTableCell31.StylePriority.UseBorders = false;
			this.xrTableCell31.StylePriority.UseFont = false;
			this.xrTableCell31.Text = "Address: ";
			this.xrTableCell31.Weight = 0.654192570415936;
			this.xrTableCell4.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection dataBindings1 = this.xrTableCell4.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.Address") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.StylePriority.UseBorders = false;
			this.xrTableCell4.Weight = 1.34580742958406;
			XRTableCellCollection cells2 = this.xrTableRow5.Cells;
			XRTableCell[] xRTableCellArray4 = new XRTableCell[] { this.xrTableCell32, this.xrTableCell5 };
			cells2.AddRange(xRTableCellArray4);
			this.xrTableRow5.Dpi = 100f;
			this.xrTableRow5.Name = "xrTableRow5";
			this.xrTableRow5.Weight = 1;
			this.xrTableCell32.Borders = BorderSide.All;
			this.xrTableCell32.Dpi = 100f;
			this.xrTableCell32.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell32.Name = "xrTableCell32";
			this.xrTableCell32.StylePriority.UseBorders = false;
			this.xrTableCell32.StylePriority.UseFont = false;
			this.xrTableCell32.Text = "Telephone No: ";
			this.xrTableCell32.Weight = 0.654192570415936;
			this.xrTableCell5.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell5.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.PhoneNumber") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.StylePriority.UseBorders = false;
			this.xrTableCell5.StylePriority.UseFont = false;
			this.xrTableCell5.Weight = 1.34580742958406;
			XRTableCellCollection xRTableCellCollections2 = this.xrTableRow6.Cells;
			XRTableCell[] xRTableCellArray5 = new XRTableCell[] { this.xrTableCell33, this.xrTableCell6 };
			xRTableCellCollections2.AddRange(xRTableCellArray5);
			this.xrTableRow6.Dpi = 100f;
			this.xrTableRow6.Name = "xrTableRow6";
			this.xrTableRow6.Weight = 1;
			this.xrTableCell33.Borders = BorderSide.All;
			this.xrTableCell33.Dpi = 100f;
			this.xrTableCell33.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell33.Name = "xrTableCell33";
			this.xrTableCell33.StylePriority.UseBorders = false;
			this.xrTableCell33.StylePriority.UseFont = false;
			this.xrTableCell33.Text = "Fax No: ";
			this.xrTableCell33.Weight = 0.654192570415936;
			this.xrTableCell6.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection dataBindings2 = this.xrTableCell6.DataBindings;
			XRBinding[] xRBinding2 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.FaxNumber") };
			dataBindings2.AddRange(xRBinding2);
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.StylePriority.UseBorders = false;
			this.xrTableCell6.StylePriority.UseFont = false;
			this.xrTableCell6.Weight = 1.34580742958406;
			XRTableCellCollection cells3 = this.xrTableRow7.Cells;
			XRTableCell[] xRTableCellArray6 = new XRTableCell[] { this.xrTableCell34, this.xrTableCell7 };
			cells3.AddRange(xRTableCellArray6);
			this.xrTableRow7.Dpi = 100f;
			this.xrTableRow7.Name = "xrTableRow7";
			this.xrTableRow7.Weight = 1;
			this.xrTableCell34.Borders = BorderSide.All;
			this.xrTableCell34.Dpi = 100f;
			this.xrTableCell34.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell34.Name = "xrTableCell34";
			this.xrTableCell34.StylePriority.UseBorders = false;
			this.xrTableCell34.StylePriority.UseFont = false;
			this.xrTableCell34.Text = "Email: ";
			this.xrTableCell34.Weight = 0.654192570415936;
			this.xrTableCell7.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection xRBindingCollections2 = this.xrTableCell7.DataBindings;
			XRBinding[] xRBindingArray2 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.Email") };
			xRBindingCollections2.AddRange(xRBindingArray2);
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.StylePriority.UseBorders = false;
			this.xrTableCell7.StylePriority.UseFont = false;
			this.xrTableCell7.Weight = 1.34580742958406;
			this.xrTable2.Borders = BorderSide.All;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTable2.LocationFloat = new PointFloat(567.3432f, 10.00001f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			XRTableRowCollection xRTableRowCollections = this.xrTable2.Rows;
			XRTableRow[] xRTableRowArray1 = new XRTableRow[] { this.xrTableRow8, this.xrTableRow9 };
			xRTableRowCollections.AddRange(xRTableRowArray1);
			this.xrTable2.SizeF = new System.Drawing.SizeF(259.0685f, 42f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UsePadding = false;
			XRTableCellCollection xRTableCellCollections3 = this.xrTableRow8.Cells;
			XRTableCell[] xRTableCellArray7 = new XRTableCell[] { this.xrTableCell8, this.xrTableCell17 };
			xRTableCellCollections3.AddRange(xRTableCellArray7);
			this.xrTableRow8.Dpi = 100f;
			this.xrTableRow8.Name = "xrTableRow8";
			this.xrTableRow8.Weight = 1;
			this.xrTableCell8.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.StylePriority.UseBorders = false;
			this.xrTableCell8.StylePriority.UseFont = false;
			this.xrTableCell8.StylePriority.UseTextAlignment = false;
			this.xrTableCell8.Text = "Date :";
			this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell8.Weight = 2.00537075514242;
			this.xrTableCell17.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			this.xrTableCell17.Controls.AddRange(new XRControl[] { this.xrLabel28 });
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.StylePriority.UseBorders = false;
			this.xrTableCell17.Text = "xrTableCell17";
			this.xrTableCell17.Weight = 5.66461634869524;
			XRBindingCollection dataBindings3 = this.xrLabel28.DataBindings;
			XRBinding[] xRBinding3 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.EntryDate", "{0:dd MMMM yyyy}") };
			dataBindings3.AddRange(xRBinding3);
			this.xrLabel28.Dpi = 100f;
			this.xrLabel28.Font = new System.Drawing.Font("Arial", 10f);
			this.xrLabel28.LocationFloat = new PointFloat(9.999974f, 1.791668f);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel28.SizeF = new System.Drawing.SizeF(138.9853f, 18f);
			this.xrLabel28.StyleName = "DataField";
			this.xrLabel28.StylePriority.UseFont = false;
			this.xrLabel28.Text = "xrLabel37";
			XRTableCellCollection cells4 = this.xrTableRow9.Cells;
			XRTableCell[] xRTableCellArray8 = new XRTableCell[] { this.xrTableCell9, this.xrTableCell25 };
			cells4.AddRange(xRTableCellArray8);
			this.xrTableRow9.Dpi = 100f;
			this.xrTableRow9.Name = "xrTableRow9";
			this.xrTableRow9.Weight = 1;
			this.xrTableCell9.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Font = new System.Drawing.Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.StylePriority.UseBorders = false;
			this.xrTableCell9.StylePriority.UseFont = false;
			this.xrTableCell9.StylePriority.UseTextAlignment = false;
			this.xrTableCell9.Text = "Ref: QTN_";
			this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrTableCell9.Weight = 2.1020275275207;
			this.xrTableCell25.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection xRBindingCollections3 = this.xrTableCell25.DataBindings;
			XRBinding[] xRBindingArray3 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationNo") };
			xRBindingCollections3.AddRange(xRBindingArray3);
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.StylePriority.UseBorders = false;
			this.xrTableCell25.StylePriority.UseFont = false;
			this.xrTableCell25.Weight = 5.56795957631696;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.Font = new System.Drawing.Font("Arial", 10f);
			this.xrLabel1.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel1.LocationFloat = new PointFloat(22.83334f, 164.0834f);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(104.7601f, 17.99998f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Kind Attention:";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new System.Drawing.Font("Arial", 10f);
			this.xrLabel2.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel2.LocationFloat = new PointFloat(21.20844f, 194.3333f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(148.9951f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Dear Sir/Madam,";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new System.Drawing.Font("Arial", 11f);
			this.xrLabel3.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel3.LocationFloat = new PointFloat(24.79482f, 226.0417f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(794.1586f, 32.58328f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "Thank you for providing us the opportunity to quote our competitive prices for your requirement of laboratory services.";
			this.xrLabel35.Borders = BorderSide.None;
			XRBindingCollection dataBindings4 = this.xrLabel35.DataBindings;
			XRBinding[] xRBinding4 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterEnquiryMaster.ContactPerson") };
			dataBindings4.AddRange(xRBinding4);
			this.xrLabel35.Dpi = 100f;
			this.xrLabel35.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold);
			this.xrLabel35.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel35.LocationFloat = new PointFloat(143.9734f, 164.0834f);
			this.xrLabel35.Name = "xrLabel35";
			this.xrLabel35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel35.SizeF = new System.Drawing.SizeF(386.1617f, 18f);
			this.xrLabel35.StyleName = "DataField";
			this.xrLabel35.StylePriority.UseBorders = false;
			this.xrLabel35.StylePriority.UseFont = false;
			this.xrLabel35.StylePriority.UseForeColor = false;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 0f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Controls.AddRange(new XRControl[] { this.xrPageInfo4 });
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 24f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrPageInfo4.Dpi = 100f;
			this.xrPageInfo4.Format = "Page {0} of {1}";
			this.xrPageInfo4.LocationFloat = new PointFloat(513.0784f, 0.9583156f);
			this.xrPageInfo4.Name = "xrPageInfo4";
			this.xrPageInfo4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo4.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo4.StyleName = "PageInfo";
			this.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 3.125f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.Title.BackColor = Color.Transparent;
			this.Title.BorderColor = Color.Black;
			this.Title.Borders = BorderSide.None;
			this.Title.BorderWidth = 1f;
			this.Title.Font = new System.Drawing.Font("Times New Roman", 20f, FontStyle.Bold);
			this.Title.ForeColor = Color.Maroon;
			this.Title.Name = "Title";
			this.FieldCaption.BackColor = Color.Transparent;
			this.FieldCaption.BorderColor = Color.Black;
			this.FieldCaption.Borders = BorderSide.None;
			this.FieldCaption.BorderWidth = 1f;
			this.FieldCaption.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold);
			this.FieldCaption.ForeColor = Color.Maroon;
			this.FieldCaption.Name = "FieldCaption";
			this.PageInfo.BackColor = Color.Transparent;
			this.PageInfo.BorderColor = Color.Black;
			this.PageInfo.Borders = BorderSide.None;
			this.PageInfo.BorderWidth = 1f;
			this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10f, FontStyle.Bold);
			this.PageInfo.ForeColor = Color.Black;
			this.PageInfo.Name = "PageInfo";
			this.DataField.BackColor = Color.Transparent;
			this.DataField.BorderColor = Color.Black;
			this.DataField.Borders = BorderSide.None;
			this.DataField.BorderWidth = 1f;
			this.DataField.Font = new System.Drawing.Font("Times New Roman", 10f);
			this.DataField.ForeColor = Color.Black;
			this.DataField.Name = "DataField";
			this.DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			BandCollection bands = this.DetailReport.Bands;
			DevExpress.XtraReports.UI.Band[] detail1 = new DevExpress.XtraReports.UI.Band[] { this.Detail1, this.GroupHeader1 };
			bands.AddRange(detail1);
			this.DetailReport.DataMember = "QuotationMaster.QuotationMasterQuotationDetails";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[] { this.xrTable4 });
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable4.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTable4.LocationFloat = new PointFloat(22.58333f, 0f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Padding = new PaddingInfo(0, 0, 2, 0, 100f);
			this.xrTable4.Rows.AddRange(new XRTableRow[] { this.xrTableRow11 });
			this.xrTable4.SizeF = new System.Drawing.SizeF(796.2034f, 25f);
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UsePadding = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections4 = this.xrTableRow11.Cells;
			XRTableCell[] xRTableCellArray9 = new XRTableCell[] { this.xrTableCell38, this.xrTableCell18, this.xrTableCell19, this.xrTableCell20, this.xrTableCell21, this.xrTableCell22, this.xrTableCell23, this.xrTableCell24, this.xrTableCell27 };
			xRTableCellCollections4.AddRange(xRTableCellArray9);
			this.xrTableRow11.Dpi = 100f;
			this.xrTableRow11.Name = "xrTableRow11";
			this.xrTableRow11.Weight = 11.5;
			XRBindingCollection xRBindingCollections4 = this.xrTableCell38.DataBindings;
			XRBinding[] xRBindingArray4 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.No") };
			xRBindingCollections4.AddRange(xRBindingArray4);
			this.xrTableCell38.Dpi = 100f;
			this.xrTableCell38.Name = "xrTableCell38";
			this.xrTableCell38.Weight = 0.0387657185513503;
			XRBindingCollection dataBindings5 = this.xrTableCell18.DataBindings;
			XRBinding[] xRBinding5 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.MaterialName") };
			dataBindings5.AddRange(xRBinding5);
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Weight = 0.122486378741137;
			XRBindingCollection xRBindingCollections5 = this.xrTableCell19.DataBindings;
			XRBinding[] xRBindingArray5 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.MaterialName_MaterialName") };
			xRBindingCollections5.AddRange(xRBindingArray5);
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Weight = 0.152176005879698;
			XRBindingCollection dataBindings6 = this.xrTableCell20.DataBindings;
			XRBinding[] xRBinding6 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.TestName") };
			dataBindings6.AddRange(xRBinding6);
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Weight = 0.379770715494035;
			XRBindingCollection xRBindingCollections6 = this.xrTableCell21.DataBindings;
			XRBinding[] xRBindingArray6 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.StandardNumber") };
			xRBindingCollections6.AddRange(xRBindingArray6);
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Weight = 0.108915204310462;
			XRBindingCollection dataBindings7 = this.xrTableCell22.DataBindings;
			XRBinding[] xRBinding7 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.UnitName") };
			dataBindings7.AddRange(xRBinding7);
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Weight = 0.0680291726514987;
			XRBindingCollection xRBindingCollections7 = this.xrTableCell23.DataBindings;
			XRBinding[] xRBindingArray7 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.Price", "{0:#.00}") };
			xRBindingCollections7.AddRange(xRBindingArray7);
			this.xrTableCell23.Dpi = 100f;
			this.xrTableCell23.Name = "xrTableCell23";
			this.xrTableCell23.Weight = 0.0979873741036357;
			XRBindingCollection dataBindings8 = this.xrTableCell24.DataBindings;
			XRBinding[] xRBinding8 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.MinQty", "{0:#}") };
			dataBindings8.AddRange(xRBinding8);
			this.xrTableCell24.Dpi = 100f;
			this.xrTableCell24.Name = "xrTableCell24";
			this.xrTableCell24.Weight = 0.0460661124181471;
			XRBindingCollection xRBindingCollections8 = this.xrTableCell27.DataBindings;
			XRBinding[] xRBindingArray8 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.calculatedField1", "{0:#.00}") };
			xRBindingCollections8.AddRange(xRBindingArray8);
			this.xrTableCell27.Dpi = 100f;
			this.xrTableCell27.Name = "xrTableCell27";
			this.xrTableCell27.Weight = 0.11123989390433;
			this.GroupHeader1.Controls.AddRange(new XRControl[] { this.xrTable3 });
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 39.58333f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable3.Borders = BorderSide.All;
			this.xrTable3.Dpi = 100f;
			this.xrTable3.Font = new System.Drawing.Font("Arial", 9f, FontStyle.Bold);
			this.xrTable3.LocationFloat = new PointFloat(22.58333f, 0f);
			this.xrTable3.Name = "xrTable3";
			this.xrTable3.Padding = new PaddingInfo(0, 0, 2, 0, 100f);
			this.xrTable3.Rows.AddRange(new XRTableRow[] { this.xrTableRow10 });
			this.xrTable3.SizeF = new System.Drawing.SizeF(796.1201f, 39.58333f);
			this.xrTable3.StylePriority.UseBorders = false;
			this.xrTable3.StylePriority.UseFont = false;
			this.xrTable3.StylePriority.UsePadding = false;
			this.xrTable3.StylePriority.UseTextAlignment = false;
			this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection cells5 = this.xrTableRow10.Cells;
			XRTableCell[] xRTableCellArray10 = new XRTableCell[] { this.xrTableCell40, this.xrTableCell10, this.xrTableCell11, this.xrTableCell12, this.xrTableCell13, this.xrTableCell14, this.xrTableCell15, this.xrTableCell16, this.xrTableCell26 };
			cells5.AddRange(xRTableCellArray10);
			this.xrTableRow10.Dpi = 100f;
			this.xrTableRow10.Name = "xrTableRow10";
			this.xrTableRow10.Weight = 11.5;
			this.xrTableCell40.Dpi = 100f;
			this.xrTableCell40.Name = "xrTableCell40";
			this.xrTableCell40.Text = "#";
			this.xrTableCell40.Weight = 0.0351623024336843;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Service Section";
			this.xrTableCell10.Weight = 0.11852859272608;
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "Material Details";
			this.xrTableCell11.Weight = 0.145040376128622;
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Text = "Services Name";
			this.xrTableCell12.Weight = 0.362032291386243;
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "Standard Number";
			this.xrTableCell13.Weight = 0.103931154390867;
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "Unit ";
			this.xrTableCell14.Weight = 0.0648461011680272;
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.Text = "Rate";
			this.xrTableCell15.Weight = 0.0933017209788606;
			this.xrTableCell16.Dpi = 100f;
			this.xrTableCell16.Name = "xrTableCell16";
			this.xrTableCell16.Text = "Min Qty";
			this.xrTableCell16.Weight = 0.0439060401014066;
			this.xrTableCell26.Dpi = 100f;
			this.xrTableCell26.Multiline = true;
			this.xrTableCell26.Name = "xrTableCell26";
			this.xrTableCell26.Text = "Total Amount\r\nQAR";
			this.xrTableCell26.Weight = 0.10591561159235;
			BandCollection bandCollections = this.DetailReport1.Bands;
			DevExpress.XtraReports.UI.Band[] detail2 = new DevExpress.XtraReports.UI.Band[] { this.Detail2, this.ReportFooter, this.DetailReport2 };
			bandCollections.AddRange(detail2);
			this.DetailReport1.DataMember = "QuotationMaster";
			this.DetailReport1.DataSource = this.sqlDataSource1;
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.FilterString = "[QuotationMasterID] = ?QID";
			this.DetailReport1.Level = 1;
			this.DetailReport1.Name = "DetailReport1";
			XRControlCollection xRControlCollection = this.Detail2.Controls;
			XRControl[] xRControlArrays1 = new XRControl[] { this.xrLabel4, this.xrTable7 };
			xRControlCollection.AddRange(xRControlArrays1);
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 91.79169f;
			this.Detail2.Name = "Detail2";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new System.Drawing.Font("Arial", 11f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel4.LocationFloat = new PointFloat(22.58333f, 9.999974f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(149.5f, 18f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Remarks:";
			this.xrTable7.Borders = BorderSide.All;
			this.xrTable7.Dpi = 100f;
			this.xrTable7.Font = new System.Drawing.Font("Arial", 9.75f);
			this.xrTable7.LocationFloat = new PointFloat(22.58333f, 39.16664f);
			this.xrTable7.Name = "xrTable7";
			this.xrTable7.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable7.Rows.AddRange(new XRTableRow[] { this.xrTableRow16 });
			this.xrTable7.SizeF = new System.Drawing.SizeF(809.5833f, 48.41342f);
			this.xrTable7.StylePriority.UseBorders = false;
			this.xrTable7.StylePriority.UseFont = false;
			this.xrTable7.StylePriority.UsePadding = false;
			this.xrTableRow16.Cells.AddRange(new XRTableCell[] { this.xrTableCell49 });
			this.xrTableRow16.Dpi = 100f;
			this.xrTableRow16.Name = "xrTableRow16";
			this.xrTableRow16.Weight = 1;
			this.xrTableCell49.Borders = BorderSide.None;
			XRBindingCollection dataBindings9 = this.xrTableCell49.DataBindings;
			XRBinding[] xRBinding9 = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.Remarks") };
			dataBindings9.AddRange(xRBinding9);
			this.xrTableCell49.Dpi = 100f;
			this.xrTableCell49.Font = new System.Drawing.Font("Arial", 9f);
			this.xrTableCell49.Multiline = true;
			this.xrTableCell49.Name = "xrTableCell49";
			this.xrTableCell49.StylePriority.UseBorders = false;
			this.xrTableCell49.StylePriority.UseFont = false;
			this.xrTableCell49.Weight = 3.72689774549723;
			this.ReportFooter.Dpi = 100f;
			this.ReportFooter.HeightF = 2.083333f;
			this.ReportFooter.Name = "ReportFooter";
			this.ReportFooter.Visible = false;
			this.DetailReport2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { this.Detail3 });
			this.DetailReport2.DataMember = "QuotationMaster";
			this.DetailReport2.DataSource = this.sqlDataSource1;
			this.DetailReport2.Dpi = 100f;
			this.DetailReport2.FilterString = "[QuotationMasterID] = ?QID";
			this.DetailReport2.Level = 0;
			this.DetailReport2.Name = "DetailReport2";
			this.DetailReport2.Padding = new PaddingInfo(0, 0, 50, 0, 100f);
			XRControlCollection controls1 = this.Detail3.Controls;
			xRControlArrays = new XRControl[] { this.xrTable5, this.xrLabel21, this.xrTable9, this.xrLabel22, this.xrLabel26 };
			controls1.AddRange(xRControlArrays);
			this.Detail3.Dpi = 100f;
			this.Detail3.HeightF = 204.4168f;
			this.Detail3.KeepTogether = true;
			this.Detail3.Name = "Detail3";
			this.calculatedField1.DataMember = "QuotationMaster.QuotationMasterQuotationDetails";
			this.calculatedField1.Expression = "[Price] * [MinQty]";
			this.calculatedField1.Name = "calculatedField1";
			this.ExpiresDay.DataMember = "QuotationMaster";
			this.ExpiresDay.Expression = "DateDiffDay( [EntryDate],[ExpiryDate])";
			this.ExpiresDay.Name = "ExpiresDay";
			this.QID.Description = "Parameter1";
			dynamicListLookUpSetting.DataAdapter = null;
			dynamicListLookUpSetting.DataMember = "QuotationMaster";
			dynamicListLookUpSetting.DataSource = this.sqlDataSource1;
			dynamicListLookUpSetting.DisplayMember = "QuotationNo";
			dynamicListLookUpSetting.FilterString = null;
			dynamicListLookUpSetting.ValueMember = "QuotationMasterID";
			this.QID.LookUpSettings = dynamicListLookUpSetting;
			this.QID.Name = "QID";
			this.QID.Type = typeof(int);
			this.QID.ValueInfo = "0";
			this.calculatedField2.DataMember = "QuotationMaster.QuotationMasterQuotationDetails";
			this.calculatedField2.Name = "calculatedField2";
			XRControlCollection xRControlCollection1 = this.PageHeader.Controls;
			xRControlArrays = new XRControl[] { this.xrLabel5 };
			xRControlCollection1.AddRange(xRControlArrays);
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 75f;
			this.PageHeader.Name = "PageHeader";
			this.xrLabel5.BorderWidth = 0f;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.LocationFloat = new PointFloat(312.0418f, 10.00001f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(100f, 59.16665f);
			this.xrLabel5.StylePriority.UseBorderWidth = false;
			BandCollection bands1 = this.DetailReport3.Bands;
			detail1 = new DevExpress.XtraReports.UI.Band[] { this.Detail4 };
			bands1.AddRange(detail1);
			this.DetailReport3.Dpi = 100f;
			this.DetailReport3.Expanded = false;
			this.DetailReport3.Level = 2;
			this.DetailReport3.Name = "DetailReport3";
			this.Detail4.Dpi = 100f;
			this.Detail4.HeightF = 100f;
			this.Detail4.Name = "Detail4";
			this.xrTableCell39.Borders = BorderSide.None;
			XRBindingCollection xRBindingCollections9 = this.xrTableCell39.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.ExpiryDate", "{0:dd MMM yyyy}") };
			xRBindingCollections9.AddRange(xRBinding);
			this.xrTableCell39.Dpi = 100f;
			this.xrTableCell39.Name = "xrTableCell39";
			this.xrTableCell39.StylePriority.UseBorders = false;
			this.xrTableCell39.StylePriority.UseTextAlignment = false;
			this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell39.Weight = 1.43571167334888;
			this.xrTableCell37.Borders = BorderSide.None;
			this.xrTableCell37.Dpi = 100f;
			this.xrTableCell37.Name = "xrTableCell37";
			this.xrTableCell37.StylePriority.UseBorders = false;
			this.xrTableCell37.Text = " days from the date of receipt.       Expiry date : ";
			this.xrTableCell37.Weight = 1.39157204320154;
			this.xrTableCell36.Borders = BorderSide.None;
			XRBindingCollection dataBindings10 = this.xrTableCell36.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.ExpiresDay") };
			dataBindings10.AddRange(xRBinding);
			this.xrTableCell36.Dpi = 100f;
			this.xrTableCell36.Name = "xrTableCell36";
			this.xrTableCell36.StylePriority.UseBorders = false;
			this.xrTableCell36.StylePriority.UseTextAlignment = false;
			this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell36.Weight = 0.137791935944092;
			this.xrTableCell35.Borders = BorderSide.None;
			this.xrTableCell35.Dpi = 100f;
			this.xrTableCell35.Name = "xrTableCell35";
			this.xrTableCell35.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell35.StylePriority.UseBorders = false;
			this.xrTableCell35.StylePriority.UsePadding = false;
			this.xrTableCell35.Text = "This Quotation is valid for  ";
			this.xrTableCell35.Weight = 0.762579090229777;
			XRTableCellCollection xRTableCellCollections5 = this.xrTableRow12.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell35, this.xrTableCell36, this.xrTableCell37, this.xrTableCell39 };
			xRTableCellCollections5.AddRange(xRTableCellArray);
			this.xrTableRow12.Dpi = 100f;
			this.xrTableRow12.Name = "xrTableRow12";
			this.xrTableRow12.Weight = 1;
			this.xrTable5.Borders = BorderSide.None;
			this.xrTable5.Dpi = 100f;
			this.xrTable5.Font = new System.Drawing.Font("Arial", 9f);
			this.xrTable5.LocationFloat = new PointFloat(24.87815f, 42.1416f);
			this.xrTable5.Name = "xrTable5";
			this.xrTable5.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			XRTableRowCollection rows1 = this.xrTable5.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow12 };
			rows1.AddRange(xRTableRowArray);
			this.xrTable5.SizeF = new System.Drawing.SizeF(771.2569f, 15.00001f);
			this.xrTable5.StylePriority.UseBorders = false;
			this.xrTable5.StylePriority.UseFont = false;
			this.xrTable5.StylePriority.UsePadding = false;
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.Font = new System.Drawing.Font("Arial", 11f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel21.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel21.LocationFloat = new PointFloat(22.83334f, 12.5f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new System.Drawing.SizeF(162f, 18f);
			this.xrLabel21.StyleName = "FieldCaption";
			this.xrLabel21.StylePriority.UseFont = false;
			this.xrLabel21.StylePriority.UseForeColor = false;
			this.xrLabel21.Text = "Terms & Conditions:";
			this.xrTableCell43.Borders = BorderSide.None;
			XRBindingCollection xRBindingCollections10 = this.xrTableCell43.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.Description") };
			xRBindingCollections10.AddRange(xRBinding);
			this.xrTableCell43.Dpi = 100f;
			this.xrTableCell43.Font = new System.Drawing.Font("Arial", 9f);
			this.xrTableCell43.Multiline = true;
			this.xrTableCell43.Name = "xrTableCell43";
			this.xrTableCell43.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell43.StylePriority.UseBorders = false;
			this.xrTableCell43.StylePriority.UseFont = false;
			this.xrTableCell43.StylePriority.UsePadding = false;
			this.xrTableCell43.Weight = 2.23613909959395;
			XRTableCellCollection cells6 = this.xrTableRow15.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell43 };
			cells6.AddRange(xRTableCellArray);
			this.xrTableRow15.Dpi = 100f;
			this.xrTableRow15.Name = "xrTableRow15";
			this.xrTableRow15.Weight = 1;
			this.xrTable9.Dpi = 100f;
			this.xrTable9.Font = new System.Drawing.Font("Times New Roman", 9f);
			this.xrTable9.LocationFloat = new PointFloat(24.79482f, 57.14162f);
			this.xrTable9.Name = "xrTable9";
			this.xrTable9.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			XRTableRowCollection xRTableRowCollections1 = this.xrTable9.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow15 };
			xRTableRowCollections1.AddRange(xRTableRowArray);
			this.xrTable9.SizeF = new System.Drawing.SizeF(771.3402f, 38.54167f);
			this.xrTable9.StylePriority.UseFont = false;
			this.xrTable9.StylePriority.UsePadding = false;
			this.xrLabel22.Dpi = 100f;
			this.xrLabel22.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel22.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel22.LocationFloat = new PointFloat(24.79482f, 112.9968f);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel22.SizeF = new System.Drawing.SizeF(162f, 18f);
			this.xrLabel22.StyleName = "FieldCaption";
			this.xrLabel22.StylePriority.UseFont = false;
			this.xrLabel22.StylePriority.UseForeColor = false;
			this.xrLabel22.Text = "Thanks & Regards";
			XRBindingCollection dataBindings11 = this.xrLabel26.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "QuotationMaster.ApprovedBy") };
			dataBindings11.AddRange(xRBinding);
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold);
			this.xrLabel26.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel26.LocationFloat = new PointFloat(24.79482f, 175.8301f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new System.Drawing.SizeF(162f, 18f);
			this.xrLabel26.StyleName = "FieldCaption";
			this.xrLabel26.StylePriority.UseFont = false;
			this.xrLabel26.StylePriority.UseForeColor = false;
			BandCollection bandCollections1 = base.Bands;
			detail1 = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.reportHeaderBand1, this.DetailReport, this.DetailReport1, this.PageHeader, this.DetailReport3 };
			bandCollections1.AddRange(detail1);
			CalculatedFieldCollection calculatedFields = base.CalculatedFields;
			CalculatedField[] expiresDay = new CalculatedField[] { this.calculatedField1, this.ExpiresDay, this.calculatedField2 };
			calculatedFields.AddRange(expiresDay);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "QuotationMaster";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[QuotationMasterID] = ?QID";
			base.Margins = new System.Drawing.Printing.Margins(2, 9, 0, 24);
			base.Parameters.AddRange(new Parameter[] { this.QID });
			XRControlStyleSheet styleSheet = base.StyleSheet;
			XRControlStyle[] title = new XRControlStyle[] { this.Title, this.FieldCaption, this.PageInfo, this.DataField };
			styleSheet.AddRange(title);
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this.xrTable3).EndInit();
			((ISupportInitialize)this.xrTable7).EndInit();
			((ISupportInitialize)this.xrTable5).EndInit();
			((ISupportInitialize)this.xrTable9).EndInit();
			((ISupportInitialize)this).EndInit();
		}
	}
}