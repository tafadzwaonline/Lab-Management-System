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
	public class SampleResiveTestInvoiced : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private SqlDataSource sqlDataSource1;

		private ReportHeaderBand ReportHeader;

		private XRRichText xrRichText1;

		private PageFooterBand PageFooter;

		private XRPageInfo xrPageInfo2;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell2;

		private XRTableRow xrTableRow2;

		private XRTableCell xrTableCell4;

		private XRTableCell xrTableCell5;

		private DetailReportBand DetailReport;

		private DetailBand Detail1;

		private XRTable xrTable2;

		private XRTableRow xrTableRow3;

		private XRTableCell xrTableCell3;

		private XRTableCell xrTableCell6;

		private XRTableCell xrTableCell7;

		private XRTableCell xrTableCell8;

		private XRTableCell xrTableCell9;

		private XRTableCell xrTableCell10;

		private XRTableCell xrTableCell11;

		private XRTableCell xrTableCell12;

		private PageHeaderBand PageHeader;

		private Parameter InvoiceId;

		private DetailReportBand DetailReport1;

		private DetailBand Detail2;

		private XRLabel xrLabel19;

		private XRLabel xrLabel21;

		private XRTableCell xrTableCell21;

		private XRTable xrTable3;

		private XRTableRow xrTableRow4;

		private XRTableCell xrTableCell13;

		private XRTableCell xrTableCell14;

		private XRTableCell xrTableCell15;

		private XRTableCell xrTableCell16;

		private XRTableCell xrTableCell22;

		private XRTableCell xrTableCell17;

		private XRTableCell xrTableCell18;

		private XRTableCell xrTableCell19;

		private XRTableCell xrTableCell20;

		private GroupHeaderBand GroupHeader1;

		public SampleResiveTestInvoiced()
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SampleResiveTestInvoiced));
			SelectQuery selectQuery = new SelectQuery();
			Column column = new Column();
			ColumnExpression columnExpression = new ColumnExpression();
			Table table = new Table();
			Column column1 = new Column();
			ColumnExpression columnExpression1 = new ColumnExpression();
			Table table1 = new Table();
			Column column2 = new Column();
			ColumnExpression columnExpression2 = new ColumnExpression();
			Table table2 = new Table();
			Column column3 = new Column();
			ColumnExpression columnExpression3 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			Table table3 = new Table();
			Join join1 = new Join();
			RelationColumnInfo relationColumnInfo1 = new RelationColumnInfo();
			Table table4 = new Table();
			Join join2 = new Join();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			Table table5 = new Table();
			Join join3 = new Join();
			RelationColumnInfo relationColumnInfo3 = new RelationColumnInfo();
			Join join4 = new Join();
			RelationColumnInfo relationColumnInfo4 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo5 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSetting = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.ReportHeader = new ReportHeaderBand();
			this.PageFooter = new PageFooterBand();
			this.xrPageInfo2 = new XRPageInfo();
			this.xrRichText1 = new XRRichText();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable3 = new XRTable();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell16 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.PageHeader = new PageHeaderBand();
			this.InvoiceId = new Parameter();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrLabel19 = new XRLabel();
			this.xrLabel21 = new XRLabel();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrRichText1).BeginInit();
			((ISupportInitialize)this.xrTable3).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "Sample Resive Invoice";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			columnExpression.ColumnName = "InvoiceId";
			table.MetaSerializable = "30|30|125|300";
			table.Name = "Invoice";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression1.ColumnName = "CustomerName";
			table1.MetaSerializable = "650|30|125|300";
			table1.Name = "CustomersList";
			columnExpression1.Table = table1;
			column1.Expression = columnExpression1;
			columnExpression2.ColumnName = "ProjectName";
			table2.MetaSerializable = "805|30|125|280";
			table2.Name = "ProjectsList";
			columnExpression2.Table = table2;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "SRTTotal";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column1);
			selectQuery.Columns.Add(column2);
			selectQuery.Columns.Add(column3);
			selectQuery.Distinct = true;
			selectQuery.FilterString = "";
			selectQuery.GroupFilterString = "";
			selectQuery.Name = "Invoice";
			relationColumnInfo.NestedKeyColumn = "FkInvoiceId";
			relationColumnInfo.ParentKeyColumn = "InvoiceId";
			join.KeyColumns.Add(relationColumnInfo);
			table3.MetaSerializable = "185|30|125|100";
			table3.Name = "SampleReceiveTestInvoice";
			join.Nested = table3;
			join.Parent = table;
			relationColumnInfo1.NestedKeyColumn = "SampleReceiveTestID";
			relationColumnInfo1.ParentKeyColumn = "FkSampleReceiveTestID";
			join1.KeyColumns.Add(relationColumnInfo1);
			table4.MetaSerializable = "340|30|125|440";
			table4.Name = "SampleReceiveTestList";
			join1.Nested = table4;
			join1.Parent = table3;
			relationColumnInfo2.NestedKeyColumn = "JobOrderMasterID";
			relationColumnInfo2.ParentKeyColumn = "FKJobOrderMasterID";
			join2.KeyColumns.Add(relationColumnInfo2);
			table5.MetaSerializable = "495|30|125|360";
			table5.Name = "JobOrderMaster";
			join2.Nested = table5;
			join2.Parent = table;
			relationColumnInfo3.NestedKeyColumn = "CustomerID";
			relationColumnInfo3.ParentKeyColumn = "FKCustomerID";
			join3.KeyColumns.Add(relationColumnInfo3);
			join3.Nested = table1;
			join3.Parent = table5;
			relationColumnInfo4.NestedKeyColumn = "ProjectID";
			relationColumnInfo4.ParentKeyColumn = "FKProjectID";
			join4.KeyColumns.Add(relationColumnInfo4);
			join4.Nested = table2;
			join4.Parent = table5;
			selectQuery.Relations.Add(join);
			selectQuery.Relations.Add(join1);
			selectQuery.Relations.Add(join2);
			selectQuery.Relations.Add(join3);
			selectQuery.Relations.Add(join4);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table3);
			selectQuery.Tables.Add(table4);
			selectQuery.Tables.Add(table5);
			selectQuery.Tables.Add(table1);
			selectQuery.Tables.Add(table2);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { customSqlQuery, selectQuery });
			masterDetailInfo.DetailQueryName = "Sample Resive Invoice";
			relationColumnInfo5.NestedKeyColumn = "FkInvoiceId";
			relationColumnInfo5.ParentKeyColumn = "InvoiceId";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo5);
			masterDetailInfo.MasterQueryName = "Invoice";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[] { masterDetailInfo });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[] { this.xrTable1 });
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 60.41667f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.LocationFloat = new PointFloat(21.45833f, 2.083333f);
			this.xrTable1.Name = "xrTable1";
			XRTableRowCollection rows = this.xrTable1.Rows;
			XRTableRow[] xRTableRowArray = new XRTableRow[] { this.xrTableRow1, this.xrTableRow2 };
			rows.AddRange(xRTableRowArray);
			this.xrTable1.SizeF = new System.Drawing.SizeF(805f, 50f);
			XRTableCellCollection cells = this.xrTableRow1.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell1, this.xrTableCell2 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1;
			this.xrTableCell1.Borders = BorderSide.All;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseBorders = false;
			this.xrTableCell1.StylePriority.UseTextAlignment = false;
			this.xrTableCell1.Text = "Creditor Name";
			this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell1.Weight = 0.309738857774849;
			this.xrTableCell2.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection dataBindings = this.xrTableCell2.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "Invoice.CustomerName") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell2.StylePriority.UseBorders = false;
			this.xrTableCell2.StylePriority.UseFont = false;
			this.xrTableCell2.StylePriority.UsePadding = false;
			this.xrTableCell2.Weight = 1.69026114222515;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow2.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell4, this.xrTableCell5 };
			xRTableCellCollections.AddRange(xRTableCellArray1);
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 1;
			this.xrTableCell4.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.StylePriority.UseBorders = false;
			this.xrTableCell4.StylePriority.UseTextAlignment = false;
			this.xrTableCell4.Text = "Project Name";
			this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell4.Weight = 0.309738857774849;
			this.xrTableCell5.Borders = BorderSide.Right | BorderSide.Bottom;
			XRBindingCollection xRBindingCollections = this.xrTableCell5.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "Invoice.ProjectName") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell5.StylePriority.UseBorders = false;
			this.xrTableCell5.StylePriority.UseFont = false;
			this.xrTableCell5.StylePriority.UsePadding = false;
			this.xrTableCell5.Weight = 1.69026114222515;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 88.29166f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 0f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.ReportHeader.Dpi = 100f;
			this.ReportHeader.HeightF = 2.083333f;
			this.ReportHeader.Name = "ReportHeader";
			this.PageFooter.Controls.AddRange(new XRControl[] { this.xrPageInfo2 });
			this.PageFooter.Dpi = 100f;
			this.PageFooter.HeightF = 54.16667f;
			this.PageFooter.Name = "PageFooter";
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(275.5416f, 31.16665f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo2.StylePriority.UseTextAlignment = false;
			this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrRichText1.Dpi = 100f;
			this.xrRichText1.Font = new System.Drawing.Font("Times New Roman", 20f);
			this.xrRichText1.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrRichText1.LocationFloat = new PointFloat(258.3333f, 0f);
			this.xrRichText1.Name = "xrRichText1";
			this.xrRichText1.SerializableRtfString = componentResourceManager.GetString("xrRichText1.SerializableRtfString");
			this.xrRichText1.SizeF = new System.Drawing.SizeF(330.2083f, 48f);
			this.xrRichText1.StylePriority.UseFont = false;
			this.xrRichText1.StylePriority.UseForeColor = false;
			BandCollection bands = this.DetailReport.Bands;
			DevExpress.XtraReports.UI.Band[] detail1 = new DevExpress.XtraReports.UI.Band[] { this.Detail1, this.GroupHeader1 };
			bands.AddRange(detail1);
			this.DetailReport.DataMember = "Invoice.InvoiceSample Resive Invoice";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[] { this.xrTable3 });
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable3.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable3.Dpi = 100f;
			this.xrTable3.LocationFloat = new PointFloat(21.45833f, 0f);
			this.xrTable3.Name = "xrTable3";
			this.xrTable3.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
			this.xrTable3.Rows.AddRange(new XRTableRow[] { this.xrTableRow4 });
			this.xrTable3.SizeF = new System.Drawing.SizeF(805f, 25f);
			this.xrTable3.StylePriority.UseBorders = false;
			this.xrTable3.StylePriority.UsePadding = false;
			this.xrTable3.StylePriority.UseTextAlignment = false;
			this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection cells1 = this.xrTableRow4.Cells;
			XRTableCell[] xRTableCellArray2 = new XRTableCell[] { this.xrTableCell13, this.xrTableCell14, this.xrTableCell15, this.xrTableCell16, this.xrTableCell22, this.xrTableCell17, this.xrTableCell18, this.xrTableCell19, this.xrTableCell20 };
			cells1.AddRange(xRTableCellArray2);
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 11.5;
			XRBindingCollection dataBindings1 = this.xrTableCell13.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.ReceiveDate", "{0:dd MMM yyyy}") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "xrTableCell13";
			this.xrTableCell13.Weight = 2.10941865312269;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell14.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.SampleNo") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "xrTableCell14";
			this.xrTableCell14.Weight = 1.51519932225054;
			XRBindingCollection dataBindings2 = this.xrTableCell15.DataBindings;
			XRBinding[] xRBinding2 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.MaterialDescription") };
			dataBindings2.AddRange(xRBinding2);
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.Text = "xrTableCell15";
			this.xrTableCell15.Weight = 3.06950161431447;
			XRBindingCollection xRBindingCollections2 = this.xrTableCell16.DataBindings;
			XRBinding[] xRBindingArray2 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.TestName") };
			xRBindingCollections2.AddRange(xRBindingArray2);
			this.xrTableCell16.Dpi = 100f;
			this.xrTableCell16.Name = "xrTableCell16";
			this.xrTableCell16.Text = "xrTableCell16";
			this.xrTableCell16.Weight = 6.54160075814184;
			XRBindingCollection dataBindings3 = this.xrTableCell22.DataBindings;
			XRBinding[] xRBinding3 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.ReportNumber") };
			dataBindings3.AddRange(xRBinding3);
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Weight = 1.48133269081182;
			XRBindingCollection xRBindingCollections3 = this.xrTableCell17.DataBindings;
			XRBinding[] xRBindingArray3 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.Qty", "{0:#}") };
			xRBindingCollections3.AddRange(xRBindingArray3);
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.Text = "xrTableCell17";
			this.xrTableCell17.Weight = 0.660340216316005;
			XRBindingCollection dataBindings4 = this.xrTableCell18.DataBindings;
			XRBinding[] xRBinding4 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.unit") };
			dataBindings4.AddRange(xRBinding4);
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "xrTableCell18";
			this.xrTableCell18.Weight = 1.07453906452333;
			XRBindingCollection xRBindingCollections4 = this.xrTableCell19.DataBindings;
			XRBinding[] xRBindingArray4 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.Rate", "{0:#.00}") };
			xRBindingCollections4.AddRange(xRBindingArray4);
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Padding = new PaddingInfo(2, 10, 0, 0, 100f);
			this.xrTableCell19.StylePriority.UsePadding = false;
			this.xrTableCell19.StylePriority.UseTextAlignment = false;
			this.xrTableCell19.Text = "xrTableCell19";
			this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrTableCell19.Weight = 1.55460233725455;
			XRBindingCollection dataBindings5 = this.xrTableCell20.DataBindings;
			XRBinding[] xRBinding5 = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.Price", "{0:#.00}") };
			dataBindings5.AddRange(xRBinding5);
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Padding = new PaddingInfo(2, 10, 0, 0, 100f);
			this.xrTableCell20.StylePriority.UsePadding = false;
			this.xrTableCell20.StylePriority.UseTextAlignment = false;
			this.xrTableCell20.Text = "xrTableCell20";
			this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrTableCell20.Weight = 1.66556453737576;
			this.GroupHeader1.Controls.AddRange(new XRControl[] { this.xrTable2 });
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 27.08333f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable2.BackColor = Color.WhiteSmoke;
			this.xrTable2.Borders = BorderSide.All;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable2.LocationFloat = new PointFloat(21.45833f, 2.083333f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new XRTableRow[] { this.xrTableRow3 });
			this.xrTable2.SizeF = new System.Drawing.SizeF(805f, 25f);
			this.xrTable2.StylePriority.UseBackColor = false;
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UseTextAlignment = false;
			this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections1 = this.xrTableRow3.Cells;
			XRTableCell[] xRTableCellArray3 = new XRTableCell[] { this.xrTableCell3, this.xrTableCell6, this.xrTableCell7, this.xrTableCell8, this.xrTableCell21, this.xrTableCell9, this.xrTableCell10, this.xrTableCell11, this.xrTableCell12 };
			xRTableCellCollections1.AddRange(xRTableCellArray3);
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 11.5;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Recieved Date";
			this.xrTableCell3.Weight = 2.46116404446588;
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Text = "Sample No";
			this.xrTableCell6.Weight = 1.7678592694939;
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "Material Description";
			this.xrTableCell7.Weight = 3.58134122381085;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Test Name";
			this.xrTableCell8.Weight = 7.6324156801516;
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Text = "Report No";
			this.xrTableCell21.Weight = 1.72834550467621;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Text = "Qty";
			this.xrTableCell9.Weight = 0.770453966853558;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Unit";
			this.xrTableCell10.Weight = 1.25371891039929;
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "Rate";
			this.xrTableCell11.Weight = 1.8138330427701;
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Text = "Price";
			this.xrTableCell12.Weight = 1.94329730814527;
			this.PageHeader.Controls.AddRange(new XRControl[] { this.xrRichText1 });
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 64.58334f;
			this.PageHeader.Name = "PageHeader";
			this.InvoiceId.Description = "Parameter1";
			dynamicListLookUpSetting.DataAdapter = null;
			dynamicListLookUpSetting.DataMember = "Invoice";
			dynamicListLookUpSetting.DataSource = this.sqlDataSource1;
			dynamicListLookUpSetting.DisplayMember = "InvoiceId";
			dynamicListLookUpSetting.FilterString = null;
			dynamicListLookUpSetting.ValueMember = "InvoiceId";
			this.InvoiceId.LookUpSettings = dynamicListLookUpSetting;
			this.InvoiceId.Name = "InvoiceId";
			this.InvoiceId.Type = typeof(int);
			this.InvoiceId.ValueInfo = "0";
			this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { this.Detail2 });
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.Level = 1;
			this.DetailReport1.Name = "DetailReport1";
			XRControlCollection controls = this.Detail2.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrLabel19, this.xrLabel21 };
			controls.AddRange(xRControlArrays);
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 27.08333f;
			this.Detail2.Name = "Detail2";
			this.xrLabel19.BackColor = Color.WhiteSmoke;
			this.xrLabel19.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel19.LocationFloat = new PointFloat(563.0759f, 0f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new System.Drawing.SizeF(141.0598f, 20.64583f);
			this.xrLabel19.StylePriority.UseBackColor = false;
			this.xrLabel19.StylePriority.UseBorders = false;
			this.xrLabel19.StylePriority.UseFont = false;
			this.xrLabel19.StylePriority.UsePadding = false;
			this.xrLabel19.StylePriority.UseTextAlignment = false;
			this.xrLabel19.Text = "TOTAL(QAR):";
			this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrLabel21.BackColor = Color.WhiteSmoke;
			this.xrLabel21.Borders = BorderSide.All;
			XRBindingCollection xRBindingCollections5 = this.xrLabel21.DataBindings;
			XRBinding[] xRBindingArray5 = new XRBinding[] { new XRBinding("Text", null, "Invoice.SRTTotal", "{0:n2}") };
			xRBindingCollections5.AddRange(xRBindingArray5);
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel21.LocationFloat = new PointFloat(704.1356f, 0f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 10, 0, 0, 100f);
			this.xrLabel21.SizeF = new System.Drawing.SizeF(122.3227f, 20.64583f);
			this.xrLabel21.StylePriority.UseBackColor = false;
			this.xrLabel21.StylePriority.UseBorders = false;
			this.xrLabel21.StylePriority.UseFont = false;
			this.xrLabel21.StylePriority.UsePadding = false;
			this.xrLabel21.StylePriority.UseTextAlignment = false;
			this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			BandCollection bandCollections = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.ReportHeader, this.PageFooter, this.DetailReport, this.PageHeader, this.DetailReport1 };
			bandCollections.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "Invoice";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[InvoiceId] = ?InvoiceId";
			base.Margins = new System.Drawing.Printing.Margins(0, 0, 88, 0);
			base.Parameters.AddRange(new Parameter[] { this.InvoiceId });
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrRichText1).EndInit();
			((ISupportInitialize)this.xrTable3).EndInit();
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this).EndInit();
		}
	}
}