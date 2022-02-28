using DevExpress.Data;
using DevExpress.Data.PivotGrid;
using DevExpress.DataAccess;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;

namespace PioneerLab.Reports
{
	public class SampleReceiptReport : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell2;

		private XRTableCell xrTableCell4;

		private XRTableCell xrTableCell3;

		private SqlDataSource sqlDataSource1;

		private XRControlStyle Title;

		private XRControlStyle FieldCaption;

		private XRControlStyle PageInfo;

		private XRControlStyle DataField;

		private XRLabel xrLabel1;

		private XRTable xrTable10;

		private XRTableRow xrTableRow21;

		private XRTableCell xrTableCell28;

		private XRTableCell xrTableCell32;

		private XRTableCell xrTableCell55;

		private XRTableCell xrTableCell59;

		private XRTableCell xrTableCell51;

		private XRTableCell xrTableCell60;

		private XRTable xrTable9;

		private XRTableRow xrTableRow20;

		private XRTableCell xrTableCell27;

		private XRTable xrTable8;

		private XRTableRow xrTableRow11;

		private XRTableCell xrTableCell25;

		private XRTableCell xrTableCell26;

		private XRTableRow xrTableRow12;

		private XRTableCell xrTableCell29;

		private XRTableCell xrTableCell30;

		private XRTableCell xrTableCell71;

		private XRTableCell xrTableCell31;

		private XRTableRow xrTableRow14;

		private XRTableCell xrTableCell72;

		private XRTableCell xrTableCell39;

		private XRTableCell xrTableCell63;

		private XRTableCell xrTableCell40;

		private XRTableRow xrTableRow15;

		private XRTableCell xrTableCell41;

		private XRTableCell xrTableCell42;

		private XRTableCell xrTableCell73;

		private XRTableCell xrTableCell43;

		private XRTableCell xrTableCell64;

		private XRTableCell xrTableCell44;

		private XRTableRow xrTableRow16;

		private XRTableCell xrTableCell45;

		private XRTableCell xrTableCell46;

		private XRTableCell xrTableCell74;

		private XRTableCell xrTableCell47;

		private XRTableCell xrTableCell65;

		private XRTableCell xrTableCell48;

		private XRTableRow xrTableRow18;

		private XRTableCell xrTableCell53;

		private XRTableCell xrTableCell54;

		private XRTableCell xrTableCell66;

		private XRTableCell xrTableCell56;

		private XRTableRow xrTableRow19;

		private XRTableCell xrTableCell57;

		private XRTableCell xrTableCell58;

		private XRTableRow xrTableRow17;

		private XRTableCell xrTableCell49;

		private XRTableCell xrTableCell50;

		private XRTableRow xrTableRow13;

		private XRTableCell xrTableCell33;

		private XRTableCell xrTableCell34;

		private XRTableCell xrTableCell78;

		private XRTableCell xrTableCell35;

		private XRTableCell xrTableCell69;

		private XRTableCell xrTableCell36;

		private XRTable xrTable7;

		private XRTableRow xrTableRow10;

		private XRTableCell xrTableCell24;

		private XRTable xrTable5;

		private XRTableRow xrTableRow6;

		private XRTableCell xrTableCell10;

		private XRTableCell xrTableCell11;

		private XRTableRow xrTableRow8;

		private XRTableCell xrTableCell16;

		private XRTableCell xrTableCell17;

		private XRTableCell xrTableCell18;

		private XRTableCell xrTableCell20;

		private XRTableRow xrTableRow7;

		private XRTableCell xrTableCell13;

		private XRTableCell xrTableCell14;

		private XRTableCell xrTableCell15;

		private XRTableCell xrTableCell21;

		private XRTable xrTable4;

		private XRTableRow xrTableRow5;

		private XRTableCell xrTableCell9;

		private XRTable xrTable2;

		private XRTableRow xrTableRow3;

		private XRTableCell xrTableCell7;

		private DetailReportBand DetailReport;

		private DetailBand Detail1;

		private GroupHeaderBand GroupHeader1;

		private DetailReportBand DetailReport1;

		private DetailBand Detail2;

		private XRTable xrTable11;

		private XRTableRow xrTableRow22;

		private XRTableCell xrTableCell61;

		private XRTableCell xrTableCell62;

		private XRTableCell xrTableCell84;

		private XRTableCell xrTableCell67;

		private XRTableCell xrTableCell88;

		private XRTableCell xrTableCell92;

		private XRTableRow xrTableRow24;

		private XRTableCell xrTableCell77;

		private XRTableCell xrTableCell79;

		private XRTableCell xrTableCell85;

		private XRTableCell xrTableCell80;

		private XRTableCell xrTableCell89;

		private XRTableCell xrTableCell93;

		private XRTableRow xrTableRow23;

		private XRTableCell xrTableCell70;

		private XRTableCell xrTableCell75;

		private XRTableCell xrTableCell87;

		private XRTableCell xrTableCell76;

		private XRTableCell xrTableCell91;

		private XRTableCell xrTableCell95;

		private XRTableCell xrTableCell96;

		private RealTimeSource realTimeSource1;

		private FormattingRule formattingRule1;

		private XRTableCell xrTableCell97;

		private XRTableCell xrTableCell98;

		private XRTable xrTable12;

		private XRTableRow xrTableRow26;

		private XRTableCell xrTableCell37;

		private XRTableCell xrTableCell38;

		private XRTableCell xrTableCell100;

		private XRTableCell xrTableCell101;

		private XRTableCell xrTableCell102;

		private XRTableCell xrTableCell104;

		private XRTable xrTable13;

		private XRTableRow xrTableRow27;

		private XRTableCell xrTableCell105;

		private XRTableCell xrTableCell106;

		private XRTableCell xrTableCell108;

		private XRTableCell xrTableCell109;

		private XRTableCell xrTableCell110;

		private XRTableCell xrTableCell112;

		private XRTableCell xrTableCell22;

		private XRTableCell xrTableCell8;

		private Parameter FilterExpression;

		private Parameter Id;

		private BackgroundWorker backgroundWorker1;

		private XRPivotGridField xrPivotGridField5;

		private XRPivotGridField xrPivotGridField6;

		private XRPivotGridField xrPivotGridField1;

		private XRPivotGridField xrPivotGridField2;

		private XRPivotGridField xrPivotGridField3;

		private XRPivotGridField xrPivotGridField4;

		private XRPivotGridField xrPivotGridField9;

		private XRPivotGridField xrPivotGridField10;

		private XRPivotGridField xrPivotGridField7;

		private XRPivotGridField xrPivotGridField8;

		private ReportFooterBand ReportFooter;

		private XRTable xrTable14;

		private XRTableRow xrTableRow25;

		private XRTableCell xrTableCell86;

		private ReportHeaderBand ReportHeader;

		private PageHeaderBand PageHeader;

		private XRPivotGridField xrPivotGridField11;

		private XRPivotGridField xrPivotGridField12;

		private XRPivotGrid xrPivotGrid1;

		private XRPivotGridField ggg;

		private XRPivotGridField fieldRowIndex;

		private XRPivotGridField fieldValue;

		private XRPivotGrid xrPivotGrid3;

		private XRPivotGridField xrPivotGridField14;

		private XRPivotGridField xrPivotGridField15;

		private XRPivotGridField xrPivotGridField16;

		private XRPivotGridField xrPivotGridField13;

		private XRTable xrTable3;

		private XRTableRow xrTableRow9;

		private XRTableCell xrTableCell90;

		private XRTableCell xrTableCell94;

		private PageFooterBand PageFooter;

		private XRTableRow xrTableRow2;

		private XRTableCell xrTableCell5;

		private XRTableCell xrTableCell6;

		private XRTableCell xrTableCell19;

		private XRTableCell xrTableCell12;

		public SampleReceiptReport()
		{
			this.InitializeComponent();
			this.BeforePrint += new PrintEventHandler(this.SampleReceiptReport_BeforePrint);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SampleReceiptReport));
			SelectQuery selectQuery = new SelectQuery();
			Column column = new Column();
			ColumnExpression columnExpression = new ColumnExpression();
			Table table = new Table();
			Column column1 = new Column();
			ColumnExpression columnExpression1 = new ColumnExpression();
			Column column2 = new Column();
			ColumnExpression columnExpression2 = new ColumnExpression();
			Column column3 = new Column();
			ColumnExpression columnExpression3 = new ColumnExpression();
			Column column4 = new Column();
			ColumnExpression columnExpression4 = new ColumnExpression();
			Column column5 = new Column();
			ColumnExpression columnExpression5 = new ColumnExpression();
			Column column6 = new Column();
			ColumnExpression columnExpression6 = new ColumnExpression();
			Table table1 = new Table();
			Column column7 = new Column();
			ColumnExpression columnExpression7 = new ColumnExpression();
			Column column8 = new Column();
			ColumnExpression columnExpression8 = new ColumnExpression();
			Column column9 = new Column();
			ColumnExpression columnExpression9 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			SelectQuery selectQuery1 = new SelectQuery();
			Column column10 = new Column();
			ColumnExpression columnExpression10 = new ColumnExpression();
			Table table2 = new Table();
			Column column11 = new Column();
			ColumnExpression columnExpression11 = new ColumnExpression();
			Column column12 = new Column();
			ColumnExpression columnExpression12 = new ColumnExpression();
			Column column13 = new Column();
			ColumnExpression columnExpression13 = new ColumnExpression();
			Column column14 = new Column();
			ColumnExpression columnExpression14 = new ColumnExpression();
			Column column15 = new Column();
			ColumnExpression columnExpression15 = new ColumnExpression();
			Table table3 = new Table();
			Column column16 = new Column();
			ColumnExpression columnExpression16 = new ColumnExpression();
			Column column17 = new Column();
			ColumnExpression columnExpression17 = new ColumnExpression();
			Column column18 = new Column();
			ColumnExpression columnExpression18 = new ColumnExpression();
			Column column19 = new Column();
			ColumnExpression columnExpression19 = new ColumnExpression();
			Column column20 = new Column();
			ColumnExpression columnExpression20 = new ColumnExpression();
			Join join1 = new Join();
			RelationColumnInfo relationColumnInfo1 = new RelationColumnInfo();
			CustomSqlQuery str = new CustomSqlQuery();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo1 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo3 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo2 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo4 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSetting = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrTable3 = new XRTable();
			this.xrTableRow9 = new XRTableRow();
			this.xrTableCell90 = new XRTableCell();
			this.xrTableCell94 = new XRTableCell();
			this.xrLabel1 = new XRLabel();
			this.xrTable10 = new XRTable();
			this.xrTableRow21 = new XRTableRow();
			this.xrTableCell28 = new XRTableCell();
			this.xrTableCell32 = new XRTableCell();
			this.xrTableCell55 = new XRTableCell();
			this.xrTableCell59 = new XRTableCell();
			this.xrTableCell51 = new XRTableCell();
			this.xrTableCell60 = new XRTableCell();
			this.xrTable9 = new XRTable();
			this.xrTableRow20 = new XRTableRow();
			this.xrTableCell27 = new XRTableCell();
			this.xrTable8 = new XRTable();
			this.xrTableRow11 = new XRTableRow();
			this.xrTableCell25 = new XRTableCell();
			this.xrTableCell26 = new XRTableCell();
			this.xrTableRow12 = new XRTableRow();
			this.xrTableCell29 = new XRTableCell();
			this.xrTableCell96 = new XRTableCell();
			this.xrTableCell30 = new XRTableCell();
			this.xrTableCell71 = new XRTableCell();
			this.xrTableCell31 = new XRTableCell();
			this.xrTableRow14 = new XRTableRow();
			this.xrTableCell72 = new XRTableCell();
			this.xrTableCell39 = new XRTableCell();
			this.xrTableCell63 = new XRTableCell();
			this.xrTableCell40 = new XRTableCell();
			this.xrTableRow15 = new XRTableRow();
			this.xrTableCell41 = new XRTableCell();
			this.xrTableCell42 = new XRTableCell();
			this.xrTableCell73 = new XRTableCell();
			this.xrTableCell43 = new XRTableCell();
			this.xrTableCell64 = new XRTableCell();
			this.xrTableCell44 = new XRTableCell();
			this.xrTableRow16 = new XRTableRow();
			this.xrTableCell45 = new XRTableCell();
			this.xrTableCell46 = new XRTableCell();
			this.xrTableCell74 = new XRTableCell();
			this.xrTableCell47 = new XRTableCell();
			this.xrTableCell65 = new XRTableCell();
			this.xrTableCell48 = new XRTableCell();
			this.xrTableRow18 = new XRTableRow();
			this.xrTableCell53 = new XRTableCell();
			this.xrTableCell54 = new XRTableCell();
			this.xrTableCell66 = new XRTableCell();
			this.xrTableCell56 = new XRTableCell();
			this.xrTableRow19 = new XRTableRow();
			this.xrTableCell57 = new XRTableCell();
			this.xrTableCell58 = new XRTableCell();
			this.xrTableRow17 = new XRTableRow();
			this.xrTableCell49 = new XRTableCell();
			this.xrTableCell97 = new XRTableCell();
			this.xrTableCell98 = new XRTableCell();
			this.xrTableCell50 = new XRTableCell();
			this.xrTableRow13 = new XRTableRow();
			this.xrTableCell33 = new XRTableCell();
			this.xrTableCell34 = new XRTableCell();
			this.xrTableCell78 = new XRTableCell();
			this.xrTableCell35 = new XRTableCell();
			this.xrTableCell69 = new XRTableCell();
			this.xrTableCell36 = new XRTableCell();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTable7 = new XRTable();
			this.xrTableRow10 = new XRTableRow();
			this.xrTableCell24 = new XRTableCell();
			this.xrTable5 = new XRTable();
			this.xrTableRow6 = new XRTableRow();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableRow8 = new XRTableRow();
			this.xrTableCell16 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableRow7 = new XRTableRow();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTable4 = new XRTable();
			this.xrTableRow5 = new XRTableRow();
			this.xrTableCell9 = new XRTableCell();
			this.xrTable2 = new XRTable();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell7 = new XRTableCell();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.xrTable11 = new XRTable();
			this.xrTableRow22 = new XRTableRow();
			this.xrTableCell61 = new XRTableCell();
			this.xrTableCell62 = new XRTableCell();
			this.xrTableCell84 = new XRTableCell();
			this.xrTableCell67 = new XRTableCell();
			this.xrTableCell88 = new XRTableCell();
			this.xrTableCell92 = new XRTableCell();
			this.xrTableRow24 = new XRTableRow();
			this.xrTableCell77 = new XRTableCell();
			this.xrTableCell79 = new XRTableCell();
			this.xrTableCell85 = new XRTableCell();
			this.xrTableCell80 = new XRTableCell();
			this.xrTableCell89 = new XRTableCell();
			this.xrTableCell93 = new XRTableCell();
			this.xrTableRow23 = new XRTableRow();
			this.xrTableCell70 = new XRTableCell();
			this.xrTableCell75 = new XRTableCell();
			this.xrTableCell87 = new XRTableCell();
			this.xrTableCell76 = new XRTableCell();
			this.xrTableCell91 = new XRTableCell();
			this.xrTableCell95 = new XRTableCell();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable12 = new XRTable();
			this.xrTableRow26 = new XRTableRow();
			this.xrTableCell37 = new XRTableCell();
			this.xrTableCell38 = new XRTableCell();
			this.xrTableCell100 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell101 = new XRTableCell();
			this.xrTableCell102 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell104 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable13 = new XRTable();
			this.xrTableRow27 = new XRTableRow();
			this.xrTableCell105 = new XRTableCell();
			this.xrTableCell106 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell108 = new XRTableCell();
			this.xrTableCell109 = new XRTableCell();
			this.xrTableCell110 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell112 = new XRTableCell();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrPivotGrid3 = new XRPivotGrid();
			this.xrPivotGridField14 = new XRPivotGridField();
			this.xrPivotGridField15 = new XRPivotGridField();
			this.xrPivotGridField16 = new XRPivotGridField();
			this.xrPivotGrid1 = new XRPivotGrid();
			this.ggg = new XRPivotGridField();
			this.fieldValue = new XRPivotGridField();
			this.fieldRowIndex = new XRPivotGridField();
			this.xrTable14 = new XRTable();
			this.xrTableRow25 = new XRTableRow();
			this.xrTableCell86 = new XRTableCell();
			this.ReportFooter = new ReportFooterBand();
			this.realTimeSource1 = new RealTimeSource();
			this.formattingRule1 = new FormattingRule();
			this.FilterExpression = new Parameter();
			this.Id = new Parameter();
			this.backgroundWorker1 = new BackgroundWorker();
			this.ReportHeader = new ReportHeaderBand();
			this.PageHeader = new PageHeaderBand();
			this.PageFooter = new PageFooterBand();
			this.xrPivotGridField1 = new XRPivotGridField();
			this.xrPivotGridField2 = new XRPivotGridField();
			this.xrPivotGridField3 = new XRPivotGridField();
			this.xrPivotGridField4 = new XRPivotGridField();
			this.xrPivotGridField5 = new XRPivotGridField();
			this.xrPivotGridField6 = new XRPivotGridField();
			this.xrPivotGridField7 = new XRPivotGridField();
			this.xrPivotGridField8 = new XRPivotGridField();
			this.xrPivotGridField9 = new XRPivotGridField();
			this.xrPivotGridField10 = new XRPivotGridField();
			this.xrPivotGridField11 = new XRPivotGridField();
			this.xrPivotGridField12 = new XRPivotGridField();
			this.xrPivotGridField13 = new XRPivotGridField();
			((ISupportInitialize)this.xrTable3).BeginInit();
			((ISupportInitialize)this.xrTable10).BeginInit();
			((ISupportInitialize)this.xrTable9).BeginInit();
			((ISupportInitialize)this.xrTable8).BeginInit();
			((ISupportInitialize)this.xrTable7).BeginInit();
			((ISupportInitialize)this.xrTable5).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable11).BeginInit();
			((ISupportInitialize)this.xrTable12).BeginInit();
			((ISupportInitialize)this.xrTable13).BeginInit();
			((ISupportInitialize)this.xrTable14).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "SampleReceiveList";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			columnExpression.ColumnName = "CustomFieldID";
			table.MetaSerializable = "185|30|125|160";
			table.Name = "MaterialTypesCustomFields";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression1.ColumnName = "FKMaterialTypeID";
			columnExpression1.Table = table;
			column1.Expression = columnExpression1;
			columnExpression2.ColumnName = "CustomFieldName";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "DataType";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "IsRequired";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "IsLocked";
			columnExpression5.Table = table;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "SampleReceiveCFLinkID";
			table1.MetaSerializable = "30|30|125|120";
			table1.Name = "SampleReceiveMaterialCustomField";
			columnExpression6.Table = table1;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "FkSampleID";
			columnExpression7.Table = table1;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "FkCustomFieldID";
			columnExpression8.Table = table1;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "Value";
			columnExpression9.Table = table1;
			column9.Expression = columnExpression9;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column1);
			selectQuery.Columns.Add(column2);
			selectQuery.Columns.Add(column3);
			selectQuery.Columns.Add(column4);
			selectQuery.Columns.Add(column5);
			selectQuery.Columns.Add(column6);
			selectQuery.Columns.Add(column7);
			selectQuery.Columns.Add(column8);
			selectQuery.Columns.Add(column9);
			selectQuery.Name = "SampleReceiveMaterialCustomField";
			relationColumnInfo.NestedKeyColumn = "CustomFieldID";
			relationColumnInfo.ParentKeyColumn = "FkCustomFieldID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table;
			join.Parent = table1;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table1);
			selectQuery.Tables.Add(table);
			columnExpression10.ColumnName = "SampleReceiveTCFLinkID";
			table2.MetaSerializable = "30|30|125|140";
			table2.Name = "SampleReceiveMaterialTableCustomField";
			columnExpression10.Table = table2;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "FkSampleID";
			columnExpression11.Table = table2;
			column11.Expression = columnExpression11;
			columnExpression12.ColumnName = "FkCustomFieldID";
			columnExpression12.Table = table2;
			column12.Expression = columnExpression12;
			columnExpression13.ColumnName = "Value";
			columnExpression13.Table = table2;
			column13.Expression = columnExpression13;
			columnExpression14.ColumnName = "RowIndex";
			columnExpression14.Table = table2;
			column14.Expression = columnExpression14;
			columnExpression15.ColumnName = "CustomFieldID";
			table3.MetaSerializable = "185|30|125|160";
			table3.Name = "MaterialTypesCustomFields";
			columnExpression15.Table = table3;
			column15.Expression = columnExpression15;
			columnExpression16.ColumnName = "FKMaterialTypeID";
			columnExpression16.Table = table3;
			column16.Expression = columnExpression16;
			columnExpression17.ColumnName = "CustomFieldName";
			columnExpression17.Table = table3;
			column17.Expression = columnExpression17;
			columnExpression18.ColumnName = "DataType";
			columnExpression18.Table = table3;
			column18.Expression = columnExpression18;
			columnExpression19.ColumnName = "IsRequired";
			columnExpression19.Table = table3;
			column19.Expression = columnExpression19;
			columnExpression20.ColumnName = "IsLocked";
			columnExpression20.Table = table3;
			column20.Expression = columnExpression20;
			selectQuery1.Columns.Add(column10);
			selectQuery1.Columns.Add(column11);
			selectQuery1.Columns.Add(column12);
			selectQuery1.Columns.Add(column13);
			selectQuery1.Columns.Add(column14);
			selectQuery1.Columns.Add(column15);
			selectQuery1.Columns.Add(column16);
			selectQuery1.Columns.Add(column17);
			selectQuery1.Columns.Add(column18);
			selectQuery1.Columns.Add(column19);
			selectQuery1.Columns.Add(column20);
			selectQuery1.Name = "SampleReceiveMaterialTableCustomField";
			relationColumnInfo1.NestedKeyColumn = "CustomFieldID";
			relationColumnInfo1.ParentKeyColumn = "FkCustomFieldID";
			join1.KeyColumns.Add(relationColumnInfo1);
			join1.Nested = table3;
			join1.Parent = table2;
			selectQuery1.Relations.Add(join1);
			selectQuery1.Tables.Add(table2);
			selectQuery1.Tables.Add(table3);
			str.Name = "SampleReceiveTestList";
			str.Sql = componentResourceManager.GetString("customSqlQuery2.Sql");
			SqlQueryCollection queries = this.sqlDataSource1.Queries;
			SqlQuery[] sqlQueryArray = new SqlQuery[] { customSqlQuery, selectQuery, selectQuery1, str };
			queries.AddRange(sqlQueryArray);
			masterDetailInfo.DetailQueryName = "SampleReceiveTestList";
			relationColumnInfo2.NestedKeyColumn = "FKSampleID";
			relationColumnInfo2.ParentKeyColumn = "SampleID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo2);
			masterDetailInfo.MasterQueryName = "SampleReceiveList";
			masterDetailInfo.Name = "FK_SampleReceiveTestList_SampleReceiveList";
			masterDetailInfo1.DetailQueryName = "SampleReceiveMaterialTableCustomField";
			relationColumnInfo3.NestedKeyColumn = "FkSampleID";
			relationColumnInfo3.ParentKeyColumn = "SampleID";
			masterDetailInfo1.KeyColumns.Add(relationColumnInfo3);
			masterDetailInfo1.MasterQueryName = "SampleReceiveList";
			masterDetailInfo1.Name = "FK_SampleReceiveMaterialTableCustomField_SampleReceiveList";
			masterDetailInfo2.DetailQueryName = "SampleReceiveMaterialCustomField";
			relationColumnInfo4.NestedKeyColumn = "FkSampleID";
			relationColumnInfo4.ParentKeyColumn = "SampleID";
			masterDetailInfo2.KeyColumns.Add(relationColumnInfo4);
			masterDetailInfo2.MasterQueryName = "SampleReceiveList";
			masterDetailInfo2.Name = "FK_SampleReceiveMaterialCustomField_SampleReceiveList";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[] { masterDetailInfo, masterDetailInfo1, masterDetailInfo2 });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.BackColor = Color.SteelBlue;
			XRControlCollection controls = this.Detail.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrTable3, this.xrLabel1, this.xrTable10, this.xrTable9, this.xrTable8, this.xrTable7, this.xrTable5, this.xrTable4, this.xrTable2, this.xrTable1 };
			controls.AddRange(xRControlArrays);
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 509.875f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.StylePriority.UseBackColor = false;
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTable3.BackColor = Color.White;
			this.xrTable3.BorderColor = Color.LightGray;
			this.xrTable3.Borders = BorderSide.All;
			this.xrTable3.Dpi = 100f;
			this.xrTable3.LocationFloat = new PointFloat(495.7084f, 25f);
			this.xrTable3.Name = "xrTable3";
			this.xrTable3.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection rows = this.xrTable3.Rows;
			XRTableRow[] xRTableRowArray = new XRTableRow[] { this.xrTableRow9 };
			rows.AddRange(xRTableRowArray);
			this.xrTable3.SizeF = new System.Drawing.SizeF(267.2499f, 25f);
			this.xrTable3.StylePriority.UseBackColor = false;
			this.xrTable3.StylePriority.UseBorderColor = false;
			this.xrTable3.StylePriority.UseBorders = false;
			this.xrTable3.StylePriority.UsePadding = false;
			XRTableCellCollection cells = this.xrTableRow9.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell90, this.xrTableCell94 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow9.Dpi = 100f;
			this.xrTableRow9.Name = "xrTableRow9";
			this.xrTableRow9.Weight = 1;
			this.xrTableCell90.Dpi = 100f;
			this.xrTableCell90.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell90.Name = "xrTableCell90";
			this.xrTableCell90.StylePriority.UseFont = false;
			this.xrTableCell90.StylePriority.UseTextAlignment = false;
			this.xrTableCell90.Text = "Date Entered";
			this.xrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell90.Weight = 1;
			XRBindingCollection dataBindings = this.xrTableCell94.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SamplingDate", "{0:dd MMM yyyy}") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell94.Dpi = 100f;
			this.xrTableCell94.Name = "xrTableCell94";
			this.xrTableCell94.StylePriority.UseTextAlignment = false;
			this.xrTableCell94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell94.Weight = 1.71090400087792;
			this.xrLabel1.BackColor = Color.White;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel1.ForeColor = Color.CornflowerBlue;
			this.xrLabel1.LocationFloat = new PointFloat(328.3922f, 486.875f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(177.0833f, 22.99997f);
			this.xrLabel1.StylePriority.UseBackColor = false;
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "Tests On Sample";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTable10.BackColor = Color.White;
			this.xrTable10.BorderColor = Color.LightGray;
			this.xrTable10.Borders = BorderSide.All;
			this.xrTable10.Dpi = 100f;
			this.xrTable10.LocationFloat = new PointFloat(5.666765f, 456.25f);
			this.xrTable10.Name = "xrTable10";
			this.xrTable10.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection xRTableRowCollections = this.xrTable10.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow21 };
			xRTableRowCollections.AddRange(xRTableRowArray);
			this.xrTable10.SizeF = new System.Drawing.SizeF(798.5401f, 25f);
			this.xrTable10.SnapLineMargin = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable10.StylePriority.UseBackColor = false;
			this.xrTable10.StylePriority.UseBorderColor = false;
			this.xrTable10.StylePriority.UseBorders = false;
			this.xrTable10.StylePriority.UsePadding = false;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow21.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell28, this.xrTableCell32, this.xrTableCell55, this.xrTableCell59, this.xrTableCell51, this.xrTableCell60 };
			xRTableCellCollections.AddRange(xRTableCellArray);
			this.xrTableRow21.Dpi = 100f;
			this.xrTableRow21.Name = "xrTableRow21";
			this.xrTableRow21.Weight = 1;
			this.xrTableCell28.Dpi = 100f;
			this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell28.Name = "xrTableCell28";
			this.xrTableCell28.StylePriority.UseFont = false;
			this.xrTableCell28.Text = "Service Section";
			this.xrTableCell28.Weight = 0.78407433417001;
			XRBindingCollection xRBindingCollections = this.xrTableCell32.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.MaterialName") };
			xRBindingCollections.AddRange(xRBinding);
			this.xrTableCell32.Dpi = 100f;
			this.xrTableCell32.Name = "xrTableCell32";
			this.xrTableCell32.Weight = 0.776600644655785;
			this.xrTableCell55.Dpi = 100f;
			this.xrTableCell55.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell55.Name = "xrTableCell55";
			this.xrTableCell55.StylePriority.UseFont = false;
			this.xrTableCell55.Text = "Material Details";
			this.xrTableCell55.Weight = 0.780337477233649;
			XRBindingCollection dataBindings1 = this.xrTableCell59.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.MaterialsDetails_MaterialName", "{0}") };
			dataBindings1.AddRange(xRBinding);
			this.xrTableCell59.Dpi = 100f;
			this.xrTableCell59.Name = "xrTableCell59";
			this.xrTableCell59.Weight = 0.780337820776377;
			this.xrTableCell51.Dpi = 100f;
			this.xrTableCell51.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell51.Name = "xrTableCell51";
			this.xrTableCell51.StylePriority.UseFont = false;
			this.xrTableCell51.Text = "Class";
			this.xrTableCell51.Weight = 0.768678541111652;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell60.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.MaterialClass") };
			xRBindingCollections1.AddRange(xRBinding);
			this.xrTableCell60.Dpi = 100f;
			this.xrTableCell60.Name = "xrTableCell60";
			this.xrTableCell60.Weight = 0.791995625946995;
			this.xrTable9.Dpi = 100f;
			this.xrTable9.LocationFloat = new PointFloat(5.666765f, 435.4167f);
			this.xrTable9.Name = "xrTable9";
			XRTableRowCollection rows1 = this.xrTable9.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow20 };
			rows1.AddRange(xRTableRowArray);
			this.xrTable9.SizeF = new System.Drawing.SizeF(797.54f, 20.83334f);
			XRTableCellCollection cells1 = this.xrTableRow20.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell27 };
			cells1.AddRange(xRTableCellArray);
			this.xrTableRow20.Dpi = 100f;
			this.xrTableRow20.Name = "xrTableRow20";
			this.xrTableRow20.Weight = 1;
			this.xrTableCell27.BackColor = Color.LightBlue;
			this.xrTableCell27.BorderColor = Color.Black;
			this.xrTableCell27.Dpi = 100f;
			this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell27.ForeColor = Color.Black;
			this.xrTableCell27.Name = "xrTableCell27";
			this.xrTableCell27.StylePriority.UseBackColor = false;
			this.xrTableCell27.StylePriority.UseBorderColor = false;
			this.xrTableCell27.StylePriority.UseFont = false;
			this.xrTableCell27.StylePriority.UseForeColor = false;
			this.xrTableCell27.StylePriority.UseTextAlignment = false;
			this.xrTableCell27.Text = "Material Details";
			this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell27.Weight = 2.82928664873679;
			this.xrTable8.BackColor = Color.White;
			this.xrTable8.BorderColor = Color.LightGray;
			this.xrTable8.Borders = BorderSide.All;
			this.xrTable8.Dpi = 100f;
			this.xrTable8.LocationFloat = new PointFloat(6.666851f, 167.7083f);
			this.xrTable8.Name = "xrTable8";
			this.xrTable8.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection xRTableRowCollections1 = this.xrTable8.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow11, this.xrTableRow12, this.xrTableRow14, this.xrTableRow15, this.xrTableRow16, this.xrTableRow18, this.xrTableRow19, this.xrTableRow17, this.xrTableRow13, this.xrTableRow2 };
			xRTableRowCollections1.AddRange(xRTableRowArray);
			this.xrTable8.SizeF = new System.Drawing.SizeF(796.8749f, 265f);
			this.xrTable8.StylePriority.UseBackColor = false;
			this.xrTable8.StylePriority.UseBorderColor = false;
			this.xrTable8.StylePriority.UseBorders = false;
			this.xrTable8.StylePriority.UsePadding = false;
			XRTableCellCollection xRTableCellCollections1 = this.xrTableRow11.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell25, this.xrTableCell26 };
			xRTableCellCollections1.AddRange(xRTableCellArray);
			this.xrTableRow11.Dpi = 100f;
			this.xrTableRow11.Name = "xrTableRow11";
			this.xrTableRow11.Weight = 1;
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.StylePriority.UseFont = false;
			this.xrTableCell25.Text = "Sample Description";
			this.xrTableCell25.Weight = 1;
			XRBindingCollection dataBindings2 = this.xrTableCell26.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleDescription") };
			dataBindings2.AddRange(xRBinding);
			this.xrTableCell26.Dpi = 100f;
			this.xrTableCell26.Name = "xrTableCell26";
			this.xrTableCell26.Weight = 5;
			XRTableCellCollection cells2 = this.xrTableRow12.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell29, this.xrTableCell96, this.xrTableCell30, this.xrTableCell71, this.xrTableCell31 };
			cells2.AddRange(xRTableCellArray);
			this.xrTableRow12.Dpi = 100f;
			this.xrTableRow12.Name = "xrTableRow12";
			this.xrTableRow12.Weight = 1;
			this.xrTableCell29.Dpi = 100f;
			this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell29.Name = "xrTableCell29";
			this.xrTableCell29.StylePriority.UseFont = false;
			this.xrTableCell29.Text = "Source";
			this.xrTableCell29.Weight = 0.0159617398730478;
			this.xrTableCell96.Dpi = 100f;
			this.xrTableCell96.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell96.Name = "xrTableCell96";
			this.xrTableCell96.StylePriority.UseFont = false;
			this.xrTableCell96.Text = "Source";
			this.xrTableCell96.Weight = 0.98643236766758;
			XRBindingCollection xRBindingCollections2 = this.xrTableCell30.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.Source") };
			xRBindingCollections2.AddRange(xRBinding);
			this.xrTableCell30.Dpi = 100f;
			this.xrTableCell30.Name = "xrTableCell30";
			this.xrTableCell30.Weight = 1.99521178491874;
			this.xrTableCell71.Dpi = 100f;
			this.xrTableCell71.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell71.Name = "xrTableCell71";
			this.xrTableCell71.StylePriority.UseFont = false;
			this.xrTableCell71.Text = "Supplier";
			this.xrTableCell71.Weight = 0.999999561599059;
			XRBindingCollection dataBindings3 = this.xrTableCell31.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.Supplier") };
			dataBindings3.AddRange(xRBinding);
			this.xrTableCell31.Dpi = 100f;
			this.xrTableCell31.Name = "xrTableCell31";
			this.xrTableCell31.Weight = 2.00239454594157;
			XRTableCellCollection xRTableCellCollections2 = this.xrTableRow14.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell72, this.xrTableCell39, this.xrTableCell63, this.xrTableCell40 };
			xRTableCellCollections2.AddRange(xRTableCellArray);
			this.xrTableRow14.Dpi = 100f;
			this.xrTableRow14.Name = "xrTableRow14";
			this.xrTableRow14.Weight = 1;
			this.xrTableCell72.Dpi = 100f;
			this.xrTableCell72.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell72.Name = "xrTableCell72";
			this.xrTableCell72.StylePriority.UseFont = false;
			this.xrTableCell72.Text = "Sampling Date";
			this.xrTableCell72.Weight = 1.0047886534822;
			XRBindingCollection xRBindingCollections3 = this.xrTableCell39.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SamplingDate", "{0:dd MMM yyyy}") };
			xRBindingCollections3.AddRange(xRBinding);
			this.xrTableCell39.Dpi = 100f;
			this.xrTableCell39.Name = "xrTableCell39";
			this.xrTableCell39.Weight = 1.99521178491874;
			this.xrTableCell63.Dpi = 100f;
			this.xrTableCell63.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell63.Name = "xrTableCell63";
			this.xrTableCell63.StylePriority.UseFont = false;
			this.xrTableCell63.Text = "Receive Date";
			this.xrTableCell63.Weight = 0.999999561599059;
			XRBindingCollection dataBindings4 = this.xrTableCell40.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ReceiveDate", "{0:dd MMM yyyy}") };
			dataBindings4.AddRange(xRBinding);
			this.xrTableCell40.Dpi = 100f;
			this.xrTableCell40.Name = "xrTableCell40";
			this.xrTableCell40.Weight = 2;
			XRTableCellCollection cells3 = this.xrTableRow15.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell41, this.xrTableCell42, this.xrTableCell73, this.xrTableCell43, this.xrTableCell64, this.xrTableCell44 };
			cells3.AddRange(xRTableCellArray);
			this.xrTableRow15.Dpi = 100f;
			this.xrTableRow15.Name = "xrTableRow15";
			this.xrTableRow15.Weight = 1.59999969482422;
			this.xrTableCell41.Dpi = 100f;
			this.xrTableCell41.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell41.Name = "xrTableCell41";
			this.xrTableCell41.StylePriority.UseFont = false;
			this.xrTableCell41.Text = "Quantity";
			this.xrTableCell41.Weight = 1;
			XRBindingCollection xRBindingCollections4 = this.xrTableCell42.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ReceivedQty", "{0:#.}") };
			xRBindingCollections4.AddRange(xRBinding);
			this.xrTableCell42.Dpi = 100f;
			this.xrTableCell42.Name = "xrTableCell42";
			this.xrTableCell42.Weight = 1;
			this.xrTableCell73.Dpi = 100f;
			this.xrTableCell73.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell73.Multiline = true;
			this.xrTableCell73.Name = "xrTableCell73";
			this.xrTableCell73.StylePriority.UseFont = false;
			this.xrTableCell73.Text = "Sample Received\r\nTemperature";
			this.xrTableCell73.Weight = 1;
			XRBindingCollection dataBindings5 = this.xrTableCell43.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleTemperature", "{0:n1}") };
			dataBindings5.AddRange(xRBinding);
			this.xrTableCell43.Dpi = 100f;
			this.xrTableCell43.Name = "xrTableCell43";
			this.xrTableCell43.Weight = 0.997606769261255;
			this.xrTableCell64.Dpi = 100f;
			this.xrTableCell64.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell64.Name = "xrTableCell64";
			this.xrTableCell64.StylePriority.UseFont = false;
			this.xrTableCell64.Text = "Unit";
			this.xrTableCell64.Weight = 1.00239323073875;
			XRBindingCollection xRBindingCollections5 = this.xrTableCell44.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.UnitName") };
			xRBindingCollections5.AddRange(xRBinding);
			this.xrTableCell44.Dpi = 100f;
			this.xrTableCell44.Name = "xrTableCell44";
			this.xrTableCell44.Weight = 1;
			XRTableCellCollection xRTableCellCollections3 = this.xrTableRow16.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell45, this.xrTableCell46, this.xrTableCell74, this.xrTableCell47, this.xrTableCell65, this.xrTableCell48 };
			xRTableCellCollections3.AddRange(xRTableCellArray);
			this.xrTableRow16.Dpi = 100f;
			this.xrTableRow16.Name = "xrTableRow16";
			this.xrTableRow16.Weight = 1;
			this.xrTableCell45.Dpi = 100f;
			this.xrTableCell45.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell45.Name = "xrTableCell45";
			this.xrTableCell45.StylePriority.UseFont = false;
			this.xrTableCell45.Text = "Sample Condition";
			this.xrTableCell45.Weight = 1.0047886534822;
			XRBindingCollection dataBindings6 = this.xrTableCell46.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleCondition") };
			dataBindings6.AddRange(xRBinding);
			this.xrTableCell46.Dpi = 100f;
			this.xrTableCell46.Name = "xrTableCell46";
			this.xrTableCell46.Weight = 0.995211346517803;
			this.xrTableCell74.Dpi = 100f;
			this.xrTableCell74.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell74.Name = "xrTableCell74";
			this.xrTableCell74.StylePriority.UseFont = false;
			this.xrTableCell74.Text = "Retention Period";
			this.xrTableCell74.Weight = 1;
			XRBindingCollection xRBindingCollections6 = this.xrTableCell47.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.Column82") };
			xRBindingCollections6.AddRange(xRBinding);
			this.xrTableCell47.Dpi = 100f;
			this.xrTableCell47.Name = "xrTableCell47";
			this.xrTableCell47.Weight = 0.995211784918745;
			this.xrTableCell65.Dpi = 100f;
			this.xrTableCell65.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell65.Name = "xrTableCell65";
			this.xrTableCell65.StylePriority.UseFont = false;
			this.xrTableCell65.Text = "Condition Details";
			this.xrTableCell65.Weight = 1.00478821508126;
			XRBindingCollection dataBindings7 = this.xrTableCell48.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ConditionDetails") };
			dataBindings7.AddRange(xRBinding);
			this.xrTableCell48.Dpi = 100f;
			this.xrTableCell48.Name = "xrTableCell48";
			this.xrTableCell48.Weight = 1;
			XRTableCellCollection cells4 = this.xrTableRow18.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell53, this.xrTableCell54, this.xrTableCell66, this.xrTableCell56 };
			cells4.AddRange(xRTableCellArray);
			this.xrTableRow18.Dpi = 100f;
			this.xrTableRow18.Name = "xrTableRow18";
			this.xrTableRow18.Weight = 1;
			this.xrTableCell53.Dpi = 100f;
			this.xrTableCell53.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell53.Name = "xrTableCell53";
			this.xrTableCell53.StylePriority.UseFont = false;
			this.xrTableCell53.Text = "Site Ref";
			this.xrTableCell53.Weight = 1;
			XRBindingCollection xRBindingCollections7 = this.xrTableCell54.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SiteRefNo") };
			xRBindingCollections7.AddRange(xRBinding);
			this.xrTableCell54.Dpi = 100f;
			this.xrTableCell54.Name = "xrTableCell54";
			this.xrTableCell54.Weight = 2.99281723897718;
			this.xrTableCell66.Dpi = 100f;
			this.xrTableCell66.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell66.Name = "xrTableCell66";
			this.xrTableCell66.StylePriority.UseFont = false;
			this.xrTableCell66.Text = "Layer No";
			this.xrTableCell66.Weight = 1.00718276102282;
			XRBindingCollection dataBindings8 = this.xrTableCell56.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.LayerNo") };
			dataBindings8.AddRange(xRBinding);
			this.xrTableCell56.Dpi = 100f;
			this.xrTableCell56.Name = "xrTableCell56";
			this.xrTableCell56.Weight = 1;
			XRTableCellCollection xRTableCellCollections4 = this.xrTableRow19.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell57, this.xrTableCell58 };
			xRTableCellCollections4.AddRange(xRTableCellArray);
			this.xrTableRow19.Dpi = 100f;
			this.xrTableRow19.Name = "xrTableRow19";
			this.xrTableRow19.Weight = 1;
			this.xrTableCell57.Dpi = 100f;
			this.xrTableCell57.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell57.Name = "xrTableCell57";
			this.xrTableCell57.StylePriority.UseFont = false;
			this.xrTableCell57.Text = "Sample Location";
			this.xrTableCell57.Weight = 1.0047886534822;
			XRBindingCollection xRBindingCollections8 = this.xrTableCell58.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleLocation") };
			xRBindingCollections8.AddRange(xRBinding);
			this.xrTableCell58.Dpi = 100f;
			this.xrTableCell58.Font = new System.Drawing.Font("Times New Roman", 9.75f);
			this.xrTableCell58.Name = "xrTableCell58";
			this.xrTableCell58.StylePriority.UseFont = false;
			this.xrTableCell58.Weight = 4.9952113465178;
			XRTableCellCollection cells5 = this.xrTableRow17.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell49, this.xrTableCell97, this.xrTableCell98, this.xrTableCell50 };
			cells5.AddRange(xRTableCellArray);
			this.xrTableRow17.Dpi = 100f;
			this.xrTableRow17.Name = "xrTableRow17";
			this.xrTableRow17.Weight = 1;
			this.xrTableCell49.Dpi = 100f;
			this.xrTableCell49.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell49.Name = "xrTableCell49";
			this.xrTableCell49.StylePriority.UseFont = false;
			this.xrTableCell49.Text = "Brought in by Name:";
			this.xrTableCell49.Weight = 1;
			XRBindingCollection dataBindings9 = this.xrTableCell97.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleBroughtInByName") };
			dataBindings9.AddRange(xRBinding);
			this.xrTableCell97.Dpi = 100f;
			this.xrTableCell97.Name = "xrTableCell97";
			this.xrTableCell97.Weight = 2.00430108957722;
			this.xrTableCell98.Dpi = 100f;
			this.xrTableCell98.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell98.Name = "xrTableCell98";
			this.xrTableCell98.StylePriority.UseFont = false;
			this.xrTableCell98.Text = "Brought in Date:";
			this.xrTableCell98.Weight = 0.988516411882106;
			XRBindingCollection xRBindingCollections9 = this.xrTableCell50.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleBroughtInDate", "{0:dd MMM yyyy}") };
			xRBindingCollections9.AddRange(xRBinding);
			this.xrTableCell50.Dpi = 100f;
			this.xrTableCell50.Name = "xrTableCell50";
			this.xrTableCell50.Weight = 2.00718249854067;
			XRTableCellCollection xRTableCellCollections5 = this.xrTableRow13.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell33, this.xrTableCell34, this.xrTableCell78, this.xrTableCell35, this.xrTableCell69, this.xrTableCell36 };
			xRTableCellCollections5.AddRange(xRTableCellArray);
			this.xrTableRow13.Dpi = 100f;
			this.xrTableRow13.Name = "xrTableRow13";
			this.xrTableRow13.Weight = 1.00000030517578;
			this.xrTableCell33.Dpi = 100f;
			this.xrTableCell33.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell33.Name = "xrTableCell33";
			this.xrTableCell33.StylePriority.UseFont = false;
			this.xrTableCell33.Text = "Contact Person at Site:";
			this.xrTableCell33.Weight = 1.0023943267411;
			XRBindingCollection dataBindings10 = this.xrTableCell34.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SiteContactPerson") };
			dataBindings10.AddRange(xRBinding);
			this.xrTableCell34.Dpi = 100f;
			this.xrTableCell34.Name = "xrTableCell34";
			this.xrTableCell34.Weight = 0.997605673258902;
			this.xrTableCell78.Dpi = 100f;
			this.xrTableCell78.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell78.Name = "xrTableCell78";
			this.xrTableCell78.StylePriority.UseFont = false;
			this.xrTableCell78.Text = "Contact Person Mobile No";
			this.xrTableCell78.Weight = 1;
			XRBindingCollection xRBindingCollections10 = this.xrTableCell35.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SiteContactMobile") };
			xRBindingCollections10.AddRange(xRBinding);
			this.xrTableCell35.Dpi = 100f;
			this.xrTableCell35.Name = "xrTableCell35";
			this.xrTableCell35.Weight = 1;
			this.xrTableCell69.Dpi = 100f;
			this.xrTableCell69.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell69.Name = "xrTableCell69";
			this.xrTableCell69.StylePriority.UseFont = false;
			this.xrTableCell69.Text = "Sampled By Name";
			this.xrTableCell69.Weight = 1;
			XRBindingCollection dataBindings11 = this.xrTableCell36.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampledByName") };
			dataBindings11.AddRange(xRBinding);
			this.xrTableCell36.Dpi = 100f;
			this.xrTableCell36.Name = "xrTableCell36";
			this.xrTableCell36.Weight = 1;
			XRTableCellCollection cells6 = this.xrTableRow2.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell5, this.xrTableCell6 };
			cells6.AddRange(xRTableCellArray);
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 1.00000030517578;
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.StylePriority.UseFont = false;
			this.xrTableCell5.Text = "Sampled By";
			this.xrTableCell5.Weight = 1.0023943267411;
			XRBindingCollection xRBindingCollections11 = this.xrTableCell6.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampledBy") };
			xRBindingCollections11.AddRange(xRBinding);
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Weight = 4.9976056732589;
			this.xrTable7.Dpi = 100f;
			this.xrTable7.LocationFloat = new PointFloat(6.666851f, 146.875f);
			this.xrTable7.Name = "xrTable7";
			XRTableRowCollection rows2 = this.xrTable7.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow10 };
			rows2.AddRange(xRTableRowArray);
			this.xrTable7.SizeF = new System.Drawing.SizeF(797.54f, 20.83333f);
			XRTableCellCollection xRTableCellCollections6 = this.xrTableRow10.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell24 };
			xRTableCellCollections6.AddRange(xRTableCellArray);
			this.xrTableRow10.Dpi = 100f;
			this.xrTableRow10.Name = "xrTableRow10";
			this.xrTableRow10.Weight = 1;
			this.xrTableCell24.BackColor = Color.LightBlue;
			this.xrTableCell24.BorderColor = Color.Black;
			this.xrTableCell24.Dpi = 100f;
			this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell24.ForeColor = Color.Black;
			this.xrTableCell24.Name = "xrTableCell24";
			this.xrTableCell24.StylePriority.UseBackColor = false;
			this.xrTableCell24.StylePriority.UseBorderColor = false;
			this.xrTableCell24.StylePriority.UseFont = false;
			this.xrTableCell24.StylePriority.UseForeColor = false;
			this.xrTableCell24.StylePriority.UseTextAlignment = false;
			this.xrTableCell24.Text = "Sample Details";
			this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell24.Weight = 2.84271668464968;
			this.xrTable5.BackColor = Color.White;
			this.xrTable5.BorderColor = Color.LightGray;
			this.xrTable5.Borders = BorderSide.All;
			this.xrTable5.Dpi = 100f;
			this.xrTable5.LocationFloat = new PointFloat(6.666851f, 70.83334f);
			this.xrTable5.Name = "xrTable5";
			this.xrTable5.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection xRTableRowCollections2 = this.xrTable5.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow6, this.xrTableRow8, this.xrTableRow7 };
			xRTableRowCollections2.AddRange(xRTableRowArray);
			this.xrTable5.SizeF = new System.Drawing.SizeF(796.8749f, 74.99999f);
			this.xrTable5.StylePriority.UseBackColor = false;
			this.xrTable5.StylePriority.UseBorderColor = false;
			this.xrTable5.StylePriority.UseBorders = false;
			this.xrTable5.StylePriority.UsePadding = false;
			XRTableCellCollection cells7 = this.xrTableRow6.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell10, this.xrTableCell11 };
			cells7.AddRange(xRTableCellArray);
			this.xrTableRow6.Dpi = 100f;
			this.xrTableRow6.Name = "xrTableRow6";
			this.xrTableRow6.Weight = 1;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.StylePriority.UseFont = false;
			this.xrTableCell10.StylePriority.UseTextAlignment = false;
			this.xrTableCell10.Text = "Project Name";
			this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell10.Weight = 0.478070736275194;
			XRBindingCollection dataBindings12 = this.xrTableCell11.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ProjectName") };
			dataBindings12.AddRange(xRBinding);
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Weight = 3.25660781400609;
			XRTableCellCollection xRTableCellCollections7 = this.xrTableRow8.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell16, this.xrTableCell17, this.xrTableCell18, this.xrTableCell20 };
			xRTableCellCollections7.AddRange(xRTableCellArray);
			this.xrTableRow8.Dpi = 100f;
			this.xrTableRow8.Name = "xrTableRow8";
			this.xrTableRow8.Weight = 1;
			this.xrTableCell16.Dpi = 100f;
			this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell16.Name = "xrTableCell16";
			this.xrTableCell16.StylePriority.UseFont = false;
			this.xrTableCell16.StylePriority.UseTextAlignment = false;
			this.xrTableCell16.Text = "Project No";
			this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell16.Weight = 0.4764756453092;
			XRBindingCollection xRBindingCollections12 = this.xrTableCell17.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.AshghalCode") };
			xRBindingCollections12.AddRange(xRBinding);
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.Weight = 1.53149937883548;
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.StylePriority.UseFont = false;
			this.xrTableCell18.StylePriority.UseTextAlignment = false;
			this.xrTableCell18.Text = "Project Client";
			this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell18.Weight = 0.499800010329804;
			XRBindingCollection dataBindings13 = this.xrTableCell20.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ProjectOwner") };
			dataBindings13.AddRange(xRBinding);
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Weight = 1.2269035158068;
			XRTableCellCollection cells8 = this.xrTableRow7.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell13, this.xrTableCell14, this.xrTableCell15, this.xrTableCell21 };
			cells8.AddRange(xRTableCellArray);
			this.xrTableRow7.Dpi = 100f;
			this.xrTableRow7.Name = "xrTableRow7";
			this.xrTableRow7.Weight = 1;
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.StylePriority.UseFont = false;
			this.xrTableCell13.StylePriority.UseTextAlignment = false;
			this.xrTableCell13.Text = "Project Type";
			this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell13.Weight = 0.478070736275194;
			XRBindingCollection xRBindingCollections13 = this.xrTableCell14.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ProjectTypeName") };
			xRBindingCollections13.AddRange(xRBinding);
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Weight = 1.52990428786949;
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.StylePriority.UseFont = false;
			this.xrTableCell15.StylePriority.UseTextAlignment = false;
			this.xrTableCell15.Text = "Project Location";
			this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell15.Weight = 0.498204627445877;
			XRBindingCollection dataBindings14 = this.xrTableCell21.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ProjectLocation") };
			dataBindings14.AddRange(xRBinding);
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Weight = 1.22849889869073;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.LocationFloat = new PointFloat(403.33f, 0f);
			this.xrTable4.Name = "xrTable4";
			XRTableRowCollection rows3 = this.xrTable4.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow5 };
			rows3.AddRange(xRTableRowArray);
			this.xrTable4.SizeF = new System.Drawing.SizeF(400.2119f, 25f);
			XRTableCellCollection xRTableCellCollections8 = this.xrTableRow5.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell9 };
			xRTableCellCollections8.AddRange(xRTableCellArray);
			this.xrTableRow5.Dpi = 100f;
			this.xrTableRow5.Name = "xrTableRow5";
			this.xrTableRow5.Weight = 1;
			this.xrTableCell9.BackColor = Color.LightBlue;
			this.xrTableCell9.BorderColor = Color.Black;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 14f, FontStyle.Bold);
			this.xrTableCell9.ForeColor = Color.Black;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.StylePriority.UseBackColor = false;
			this.xrTableCell9.StylePriority.UseBorderColor = false;
			this.xrTableCell9.StylePriority.UseFont = false;
			this.xrTableCell9.StylePriority.UseForeColor = false;
			this.xrTableCell9.StylePriority.UseTextAlignment = false;
			this.xrTableCell9.Text = "Sample Receipt Report";
			this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell9.Weight = 2.98000736765337;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.LocationFloat = new PointFloat(6.00001f, 50f);
			this.xrTable2.Name = "xrTable2";
			XRTableRowCollection xRTableRowCollections3 = this.xrTable2.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow3 };
			xRTableRowCollections3.AddRange(xRTableRowArray);
			this.xrTable2.SizeF = new System.Drawing.SizeF(797.5419f, 20.83334f);
			XRTableCellCollection cells9 = this.xrTableRow3.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell7 };
			cells9.AddRange(xRTableCellArray);
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 1;
			this.xrTableCell7.BackColor = Color.LightBlue;
			this.xrTableCell7.BorderColor = Color.Black;
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell7.ForeColor = Color.Black;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.StylePriority.UseBackColor = false;
			this.xrTableCell7.StylePriority.UseBorderColor = false;
			this.xrTableCell7.StylePriority.UseFont = false;
			this.xrTableCell7.StylePriority.UseForeColor = false;
			this.xrTableCell7.StylePriority.UseTextAlignment = false;
			this.xrTableCell7.Text = "Project Details";
			this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell7.Weight = 3;
			this.xrTable1.BackColor = Color.White;
			this.xrTable1.BorderColor = Color.LightGray;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.LocationFloat = new PointFloat(6.00001f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection rows4 = this.xrTable1.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow1 };
			rows4.AddRange(xRTableRowArray);
			this.xrTable1.SizeF = new System.Drawing.SizeF(394.3333f, 25f);
			this.xrTable1.StylePriority.UseBackColor = false;
			this.xrTable1.StylePriority.UseBorderColor = false;
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UsePadding = false;
			XRTableCellCollection xRTableCellCollections9 = this.xrTableRow1.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell1, this.xrTableCell2, this.xrTableCell4, this.xrTableCell3 };
			xRTableCellCollections9.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseFont = false;
			this.xrTableCell1.StylePriority.UseTextAlignment = false;
			this.xrTableCell1.Text = "Sample No";
			this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell1.Weight = 1;
			XRBindingCollection xRBindingCollections14 = this.xrTableCell2.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.SampleNo") };
			xRBindingCollections14.AddRange(xRBinding);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.StylePriority.UseTextAlignment = false;
			this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell2.Weight = 1;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.StylePriority.UseFont = false;
			this.xrTableCell4.StylePriority.UseTextAlignment = false;
			this.xrTableCell4.Text = "RSS No.";
			this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell4.Weight = 1;
			XRBindingCollection dataBindings15 = this.xrTableCell3.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.RSSNumber") };
			dataBindings15.AddRange(xRBinding);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.StylePriority.UseTextAlignment = false;
			this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTableCell3.Weight = 1;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 1f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 1f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTable11.BorderColor = Color.LightGray;
			this.xrTable11.Borders = BorderSide.All;
			this.xrTable11.Dpi = 100f;
			this.xrTable11.LocationFloat = new PointFloat(5.195562f, 0f);
			this.xrTable11.Name = "xrTable11";
			this.xrTable11.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection xRTableRowCollections4 = this.xrTable11.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow22, this.xrTableRow24, this.xrTableRow23 };
			xRTableRowCollections4.AddRange(xRTableRowArray);
			this.xrTable11.SizeF = new System.Drawing.SizeF(841.8759f, 75f);
			this.xrTable11.StylePriority.UseBorderColor = false;
			this.xrTable11.StylePriority.UseBorders = false;
			this.xrTable11.StylePriority.UsePadding = false;
			XRTableCellCollection cells10 = this.xrTableRow22.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell61, this.xrTableCell62, this.xrTableCell84, this.xrTableCell67, this.xrTableCell88, this.xrTableCell92 };
			cells10.AddRange(xRTableCellArray);
			this.xrTableRow22.Dpi = 100f;
			this.xrTableRow22.Name = "xrTableRow22";
			this.xrTableRow22.Weight = 1;
			this.xrTableCell61.Dpi = 100f;
			this.xrTableCell61.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell61.Name = "xrTableCell61";
			this.xrTableCell61.StylePriority.UseFont = false;
			this.xrTableCell61.Text = "Delivered Name";
			this.xrTableCell61.Weight = 1;
			XRBindingCollection xRBindingCollections15 = this.xrTableCell62.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.DelivererName") };
			xRBindingCollections15.AddRange(xRBinding);
			this.xrTableCell62.Dpi = 100f;
			this.xrTableCell62.Name = "xrTableCell62";
			this.xrTableCell62.Weight = 1;
			this.xrTableCell84.Dpi = 100f;
			this.xrTableCell84.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell84.Name = "xrTableCell84";
			this.xrTableCell84.StylePriority.UseFont = false;
			this.xrTableCell84.Text = "Received By";
			this.xrTableCell84.Weight = 1;
			XRBindingCollection dataBindings16 = this.xrTableCell67.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ReceiveByName") };
			dataBindings16.AddRange(xRBinding);
			this.xrTableCell67.Dpi = 100f;
			this.xrTableCell67.Name = "xrTableCell67";
			this.xrTableCell67.Weight = 1;
			this.xrTableCell88.Dpi = 100f;
			this.xrTableCell88.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell88.Name = "xrTableCell88";
			this.xrTableCell88.StylePriority.UseFont = false;
			this.xrTableCell88.Text = "Consultant Name";
			this.xrTableCell88.Weight = 1;
			XRBindingCollection xRBindingCollections16 = this.xrTableCell92.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ConsultantName") };
			xRBindingCollections16.AddRange(xRBinding);
			this.xrTableCell92.Dpi = 100f;
			this.xrTableCell92.Name = "xrTableCell92";
			this.xrTableCell92.Weight = 1;
			XRTableCellCollection xRTableCellCollections10 = this.xrTableRow24.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell77, this.xrTableCell79, this.xrTableCell85, this.xrTableCell80, this.xrTableCell89, this.xrTableCell93 };
			xRTableCellCollections10.AddRange(xRTableCellArray);
			this.xrTableRow24.Dpi = 100f;
			this.xrTableRow24.Name = "xrTableRow24";
			this.xrTableRow24.Weight = 1;
			this.xrTableCell77.Dpi = 100f;
			this.xrTableCell77.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell77.Name = "xrTableCell77";
			this.xrTableCell77.StylePriority.UseFont = false;
			this.xrTableCell77.Text = "Mobile No";
			this.xrTableCell77.Weight = 1;
			XRBindingCollection dataBindings17 = this.xrTableCell79.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.DelivererMobile") };
			dataBindings17.AddRange(xRBinding);
			this.xrTableCell79.Dpi = 100f;
			this.xrTableCell79.Name = "xrTableCell79";
			this.xrTableCell79.Weight = 1;
			this.xrTableCell85.Dpi = 100f;
			this.xrTableCell85.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell85.Name = "xrTableCell85";
			this.xrTableCell85.StylePriority.UseFont = false;
			this.xrTableCell85.Weight = 1;
			this.xrTableCell80.Dpi = 100f;
			this.xrTableCell80.Name = "xrTableCell80";
			this.xrTableCell80.Weight = 1;
			this.xrTableCell89.Dpi = 100f;
			this.xrTableCell89.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell89.Multiline = true;
			this.xrTableCell89.Name = "xrTableCell89";
			this.xrTableCell89.StylePriority.UseFont = false;
			this.xrTableCell89.Text = "Mobile No";
			this.xrTableCell89.Weight = 1;
			XRBindingCollection xRBindingCollections17 = this.xrTableCell93.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.ConsultantMobile") };
			xRBindingCollections17.AddRange(xRBinding);
			this.xrTableCell93.Dpi = 100f;
			this.xrTableCell93.Name = "xrTableCell93";
			this.xrTableCell93.Weight = 1;
			XRTableCellCollection cells11 = this.xrTableRow23.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell70, this.xrTableCell75, this.xrTableCell87, this.xrTableCell76, this.xrTableCell91, this.xrTableCell95 };
			cells11.AddRange(xRTableCellArray);
			this.xrTableRow23.Dpi = 100f;
			this.xrTableRow23.Name = "xrTableRow23";
			this.xrTableRow23.Weight = 1;
			this.xrTableCell70.Dpi = 100f;
			this.xrTableCell70.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell70.Name = "xrTableCell70";
			this.xrTableCell70.StylePriority.UseFont = false;
			this.xrTableCell70.Text = "Signature";
			this.xrTableCell70.Weight = 1.00237620130782;
			this.xrTableCell75.Dpi = 100f;
			this.xrTableCell75.Name = "xrTableCell75";
			this.xrTableCell75.Weight = 0.997623798692185;
			this.xrTableCell87.Dpi = 100f;
			this.xrTableCell87.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell87.Name = "xrTableCell87";
			this.xrTableCell87.StylePriority.UseFont = false;
			this.xrTableCell87.Text = "Signature";
			this.xrTableCell87.Weight = 1;
			this.xrTableCell76.Dpi = 100f;
			this.xrTableCell76.Name = "xrTableCell76";
			this.xrTableCell76.Weight = 1;
			this.xrTableCell91.Dpi = 100f;
			this.xrTableCell91.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell91.Name = "xrTableCell91";
			this.xrTableCell91.StylePriority.UseFont = false;
			this.xrTableCell91.Text = "Signature";
			this.xrTableCell91.Weight = 1;
			this.xrTableCell95.Dpi = 100f;
			this.xrTableCell95.Name = "xrTableCell95";
			this.xrTableCell95.Weight = 1;
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
			this.DetailReport.DataMember = "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			XRControlCollection xRControlCollection = this.Detail1.Controls;
			xRControlArrays = new XRControl[] { this.xrTable12 };
			xRControlCollection.AddRange(xRControlArrays);
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable12.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable12.Dpi = 100f;
			this.xrTable12.LocationFloat = new PointFloat(4.333242f, 0f);
			this.xrTable12.Name = "xrTable12";
			this.xrTable12.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			XRTableRowCollection rows5 = this.xrTable12.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow26 };
			rows5.AddRange(xRTableRowArray);
			this.xrTable12.SizeF = new System.Drawing.SizeF(798.8735f, 25f);
			this.xrTable12.StylePriority.UseBorders = false;
			this.xrTable12.StylePriority.UsePadding = false;
			this.xrTable12.StylePriority.UseTextAlignment = false;
			this.xrTable12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections11 = this.xrTableRow26.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell37, this.xrTableCell38, this.xrTableCell100, this.xrTableCell22, this.xrTableCell101, this.xrTableCell102, this.xrTableCell19, this.xrTableCell104 };
			xRTableCellCollections11.AddRange(xRTableCellArray);
			this.xrTableRow26.Dpi = 100f;
			this.xrTableRow26.Name = "xrTableRow26";
			this.xrTableRow26.Weight = 11.5;
			XRBindingCollection dataBindings18 = this.xrTableCell37.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.TestName") };
			dataBindings18.AddRange(xRBinding);
			this.xrTableCell37.Dpi = 100f;
			this.xrTableCell37.Name = "xrTableCell37";
			this.xrTableCell37.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell37.StylePriority.UsePadding = false;
			this.xrTableCell37.Weight = 1.95556291988666;
			XRBindingCollection xRBindingCollections18 = this.xrTableCell38.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.StandardNumber") };
			xRBindingCollections18.AddRange(xRBinding);
			this.xrTableCell38.Dpi = 100f;
			this.xrTableCell38.Name = "xrTableCell38";
			this.xrTableCell38.Weight = 1.50410077817279;
			XRBindingCollection dataBindings19 = this.xrTableCell100.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.WitnessName") };
			dataBindings19.AddRange(xRBinding);
			this.xrTableCell100.Dpi = 100f;
			this.xrTableCell100.Name = "xrTableCell100";
			this.xrTableCell100.Weight = 2.69286489701708;
			XRBindingCollection xRBindingCollections19 = this.xrTableCell22.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.SubContractorName") };
			xRBindingCollections19.AddRange(xRBinding);
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Weight = 1.77146260027566;
			XRBindingCollection dataBindings20 = this.xrTableCell101.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.UnitName") };
			dataBindings20.AddRange(xRBinding);
			this.xrTableCell101.Dpi = 100f;
			this.xrTableCell101.Name = "xrTableCell101";
			this.xrTableCell101.Weight = 1.37283595828911;
			XRBindingCollection xRBindingCollections20 = this.xrTableCell102.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.Qty", "{0:#}") };
			xRBindingCollections20.AddRange(xRBinding);
			this.xrTableCell102.Dpi = 100f;
			this.xrTableCell102.Name = "xrTableCell102";
			this.xrTableCell102.Weight = 1.12560903618701;
			XRBindingCollection dataBindings21 = this.xrTableCell19.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.ReportNumber") };
			dataBindings21.AddRange(xRBinding);
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Weight = 1.67023921305542;
			XRBindingCollection xRBindingCollections21 = this.xrTableCell104.DataBindings;
			xRBinding = new XRBinding[] { new XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.Remarks") };
			xRBindingCollections21.AddRange(xRBinding);
			this.xrTableCell104.Dpi = 100f;
			this.xrTableCell104.Name = "xrTableCell104";
			this.xrTableCell104.Weight = 3.78172242891209;
			XRControlCollection controls1 = this.GroupHeader1.Controls;
			xRControlArrays = new XRControl[] { this.xrTable13 };
			controls1.AddRange(xRControlArrays);
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25.41669f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable13.BackColor = Color.LightGray;
			this.xrTable13.Borders = BorderSide.All;
			this.xrTable13.Dpi = 100f;
			this.xrTable13.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable13.LocationFloat = new PointFloat(0f, 0.4166921f);
			this.xrTable13.Name = "xrTable13";
			XRTableRowCollection xRTableRowCollections5 = this.xrTable13.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow27 };
			xRTableRowCollections5.AddRange(xRTableRowArray);
			this.xrTable13.SizeF = new System.Drawing.SizeF(803.2067f, 25f);
			this.xrTable13.StylePriority.UseBackColor = false;
			this.xrTable13.StylePriority.UseBorders = false;
			this.xrTable13.StylePriority.UseFont = false;
			this.xrTable13.StylePriority.UseTextAlignment = false;
			this.xrTable13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection cells12 = this.xrTableRow27.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell105, this.xrTableCell106, this.xrTableCell8, this.xrTableCell108, this.xrTableCell109, this.xrTableCell110, this.xrTableCell12, this.xrTableCell112 };
			cells12.AddRange(xRTableCellArray);
			this.xrTableRow27.Dpi = 100f;
			this.xrTableRow27.Name = "xrTableRow27";
			this.xrTableRow27.Weight = 11.5;
			this.xrTableCell105.Dpi = 100f;
			this.xrTableCell105.Name = "xrTableCell105";
			this.xrTableCell105.Text = "Services Name";
			this.xrTableCell105.Weight = 1.96173828125;
			this.xrTableCell106.Dpi = 100f;
			this.xrTableCell106.Name = "xrTableCell106";
			this.xrTableCell106.StylePriority.UseBackColor = false;
			this.xrTableCell106.Text = "Std No";
			this.xrTableCell106.Weight = 1.50885009765625;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Wtns. Name";
			this.xrTableCell8.Weight = 2.70136913832802;
			this.xrTableCell108.Dpi = 100f;
			this.xrTableCell108.Name = "xrTableCell108";
			this.xrTableCell108.Text = "Cont. Name";
			this.xrTableCell108.Weight = 1.77705600229004;
			this.xrTableCell109.Dpi = 100f;
			this.xrTableCell109.Name = "xrTableCell109";
			this.xrTableCell109.Text = "UnitName";
			this.xrTableCell109.Weight = 1.37717116847412;
			this.xrTableCell110.Dpi = 100f;
			this.xrTableCell110.Name = "xrTableCell110";
			this.xrTableCell110.Text = "Qty";
			this.xrTableCell110.Weight = 1.1291635981859;
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Text = "Report No";
			this.xrTableCell12.Weight = 1.67551329880961;
			this.xrTableCell112.Dpi = 100f;
			this.xrTableCell112.Name = "xrTableCell112";
			this.xrTableCell112.Text = "Remarks";
			this.xrTableCell112.Weight = 3.79366411587671;
			BandCollection bandCollections = this.DetailReport1.Bands;
			detail1 = new DevExpress.XtraReports.UI.Band[] { this.Detail2, this.ReportFooter };
			bandCollections.AddRange(detail1);
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.Level = 1;
			this.DetailReport1.Name = "DetailReport1";
			XRControlCollection xRControlCollection1 = this.Detail2.Controls;
			xRControlArrays = new XRControl[] { this.xrPivotGrid3, this.xrPivotGrid1, this.xrTable14 };
			xRControlCollection1.AddRange(xRControlArrays);
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 185.8334f;
			this.Detail2.Name = "Detail2";
			this.xrPivotGrid3.DataMember = "SampleReceiveList.FK_SampleReceiveMaterialCustomField_SampleReceiveList";
			this.xrPivotGrid3.DataSource = this.sqlDataSource1;
			this.xrPivotGrid3.Dpi = 100f;
			XRPivotGridFieldCollection fields = this.xrPivotGrid3.Fields;
			XRPivotGridField[] xRPivotGridFieldArray = new XRPivotGridField[] { this.xrPivotGridField14, this.xrPivotGridField15, this.xrPivotGridField16 };
			fields.AddRange(xRPivotGridFieldArray);
			this.xrPivotGrid3.LocationFloat = new PointFloat(6.00001f, 40.25002f);
			this.xrPivotGrid3.Name = "xrPivotGrid3";
			this.xrPivotGrid3.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid3.SizeF = new System.Drawing.SizeF(141.4489f, 65.7917f);
			this.xrPivotGridField14.AllowedAreas = PivotGridAllowedAreas.RowArea;
			this.xrPivotGridField14.Appearance.Cell.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField14.Appearance.Cell.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField14.AreaIndex = 0;
			this.xrPivotGridField14.Caption = "Material  Custom Field";
			this.xrPivotGridField14.FieldName = "CustomFieldName";
			this.xrPivotGridField14.Name = "xrPivotGridField14";
			this.xrPivotGridField14.Options.ShowCustomTotals = false;
			this.xrPivotGridField14.Options.ShowGrandTotal = false;
			this.xrPivotGridField14.Options.ShowTotals = false;
			this.xrPivotGridField14.SortOrder = PivotSortOrder.Descending;
			this.xrPivotGridField14.SummaryType = PivotSummaryType.Custom;
			this.xrPivotGridField14.Visible = false;
			this.xrPivotGridField14.Width = 132;
			this.xrPivotGridField15.Appearance.Cell.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.Cell.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.CustomTotalCell.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.CustomTotalCell.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldHeader.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldHeader.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldValue.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldValue.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldValueGrandTotal.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldValueTotal.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.FieldValueTotal.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.GrandTotalCell.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.GrandTotalCell.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Appearance.TotalCell.TextHorizontalAlignment = HorzAlignment.Center;
			this.xrPivotGridField15.Appearance.TotalCell.TextVerticalAlignment = VertAlignment.Center;
			this.xrPivotGridField15.Area = PivotArea.DataArea;
			this.xrPivotGridField15.AreaIndex = 0;
			this.xrPivotGridField15.FieldName = "Value";
			this.xrPivotGridField15.Name = "xrPivotGridField15";
			this.xrPivotGridField15.Options.ShowCustomTotals = false;
			this.xrPivotGridField15.Options.ShowGrandTotal = false;
			this.xrPivotGridField15.Options.ShowTotals = false;
			this.xrPivotGridField15.SummaryType = PivotSummaryType.Max;
			this.xrPivotGridField16.Area = PivotArea.RowArea;
			this.xrPivotGridField16.AreaIndex = 0;
			this.xrPivotGridField16.FieldName = "RowIndex";
			this.xrPivotGridField16.MinWidth = 0;
			this.xrPivotGridField16.Name = "xrPivotGridField16";
			this.xrPivotGridField16.Options.ShowCustomTotals = false;
			this.xrPivotGridField16.Options.ShowGrandTotal = false;
			this.xrPivotGridField16.Options.ShowTotals = false;
			this.xrPivotGridField16.Width = 0;
			this.xrPivotGrid1.DataMember = "SampleReceiveList.FK_SampleReceiveMaterialTableCustomField_SampleReceiveList";
			this.xrPivotGrid1.DataSource = this.sqlDataSource1;
			this.xrPivotGrid1.Dpi = 100f;
			XRPivotGridFieldCollection xRPivotGridFieldCollection = this.xrPivotGrid1.Fields;
			xRPivotGridFieldArray = new XRPivotGridField[] { this.ggg, this.fieldValue, this.fieldRowIndex };
			xRPivotGridFieldCollection.AddRange(xRPivotGridFieldArray);
			this.xrPivotGrid1.LocationFloat = new PointFloat(0f, 112.2917f);
			this.xrPivotGrid1.Name = "xrPivotGrid1";
			this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(834.8044f, 71.87502f);
			this.ggg.Appearance.Cell.TextHorizontalAlignment = HorzAlignment.Center;
			this.ggg.Appearance.Cell.TextVerticalAlignment = VertAlignment.Center;
			this.ggg.Area = PivotArea.ColumnArea;
			this.ggg.AreaIndex = 0;
			this.ggg.Caption = "Material Table Custom Field";
			this.ggg.FieldName = "CustomFieldName";
			this.ggg.Name = "ggg";
			this.ggg.Options.ShowCustomTotals = false;
			this.ggg.Options.ShowGrandTotal = false;
			this.ggg.Options.ShowTotals = false;
			this.ggg.SortOrder = PivotSortOrder.Descending;
			this.ggg.SummaryType = PivotSummaryType.Custom;
			this.ggg.Width = 75;
			this.fieldValue.Appearance.Cell.TextHorizontalAlignment = HorzAlignment.Center;
			this.fieldValue.Appearance.Cell.TextVerticalAlignment = VertAlignment.Center;
			this.fieldValue.Area = PivotArea.DataArea;
			this.fieldValue.AreaIndex = 0;
			this.fieldValue.FieldName = "Value";
			this.fieldValue.Name = "fieldValue";
			this.fieldValue.Options.ShowCustomTotals = false;
			this.fieldValue.Options.ShowGrandTotal = false;
			this.fieldValue.Options.ShowTotals = false;
			this.fieldValue.SummaryType = PivotSummaryType.Max;
			this.fieldRowIndex.Area = PivotArea.RowArea;
			this.fieldRowIndex.AreaIndex = 0;
			this.fieldRowIndex.FieldName = "RowIndex";
			this.fieldRowIndex.MinWidth = 0;
			this.fieldRowIndex.Name = "fieldRowIndex";
			this.fieldRowIndex.Options.ShowCustomTotals = false;
			this.fieldRowIndex.Options.ShowGrandTotal = false;
			this.fieldRowIndex.Options.ShowTotals = false;
			this.fieldRowIndex.Width = 0;
			this.xrTable14.Dpi = 100f;
			this.xrTable14.LocationFloat = new PointFloat(5.199996f, 9.000015f);
			this.xrTable14.Name = "xrTable14";
			XRTableRowCollection rows6 = this.xrTable14.Rows;
			xRTableRowArray = new XRTableRow[] { this.xrTableRow25 };
			rows6.AddRange(xRTableRowArray);
			this.xrTable14.SizeF = new System.Drawing.SizeF(799.0068f, 20.83334f);
			XRTableCellCollection xRTableCellCollections12 = this.xrTableRow25.Cells;
			xRTableCellArray = new XRTableCell[] { this.xrTableCell86 };
			xRTableCellCollections12.AddRange(xRTableCellArray);
			this.xrTableRow25.Dpi = 100f;
			this.xrTableRow25.Name = "xrTableRow25";
			this.xrTableRow25.Weight = 1;
			this.xrTableCell86.BackColor = Color.LightBlue;
			this.xrTableCell86.BorderColor = Color.Black;
			this.xrTableCell86.Dpi = 100f;
			this.xrTableCell86.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell86.ForeColor = Color.Black;
			this.xrTableCell86.Name = "xrTableCell86";
			this.xrTableCell86.StylePriority.UseBackColor = false;
			this.xrTableCell86.StylePriority.UseBorderColor = false;
			this.xrTableCell86.StylePriority.UseFont = false;
			this.xrTableCell86.StylePriority.UseForeColor = false;
			this.xrTableCell86.StylePriority.UseTextAlignment = false;
			this.xrTableCell86.Text = "Additional Information";
			this.xrTableCell86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell86.Weight = 2.98582668351353;
			XRControlCollection controls2 = this.ReportFooter.Controls;
			xRControlArrays = new XRControl[] { this.xrTable11 };
			controls2.AddRange(xRControlArrays);
			this.ReportFooter.Dpi = 100f;
			this.ReportFooter.HeightF = 80.20834f;
			this.ReportFooter.Name = "ReportFooter";
			this.realTimeSource1.DisplayableProperties = null;
			this.realTimeSource1.UseWeakEventHandler = true;
			this.formattingRule1.Name = "formattingRule1";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.Id.Description = "Id";
			dynamicListLookUpSetting.DataAdapter = null;
			dynamicListLookUpSetting.DataMember = "SampleReceiveList";
			dynamicListLookUpSetting.DataSource = this.sqlDataSource1;
			dynamicListLookUpSetting.DisplayMember = "SampleNo";
			dynamicListLookUpSetting.ValueMember = "SampleID";
			this.Id.LookUpSettings = dynamicListLookUpSetting;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			this.ReportHeader.Dpi = 100f;
			this.ReportHeader.Expanded = false;
			this.ReportHeader.HeightF = 0f;
			this.ReportHeader.KeepTogether = true;
			this.ReportHeader.Name = "ReportHeader";
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 59.74998f;
			this.PageHeader.Name = "PageHeader";
			this.PageFooter.Dpi = 100f;
			this.PageFooter.HeightF = 10.41667f;
			this.PageFooter.Name = "PageFooter";
			this.xrPivotGridField1.Area = PivotArea.DataArea;
			this.xrPivotGridField1.AreaIndex = 0;
			this.xrPivotGridField1.Name = "xrPivotGridField1";
			this.xrPivotGridField2.Area = PivotArea.RowArea;
			this.xrPivotGridField2.AreaIndex = 0;
			this.xrPivotGridField2.Name = "xrPivotGridField2";
			this.xrPivotGridField3.Area = PivotArea.ColumnArea;
			this.xrPivotGridField3.AreaIndex = 0;
			this.xrPivotGridField3.FieldName = "CustomFieldName";
			this.xrPivotGridField3.Name = "xrPivotGridField3";
			this.xrPivotGridField4.Area = PivotArea.ColumnArea;
			this.xrPivotGridField4.AreaIndex = 1;
			this.xrPivotGridField4.FieldName = "RowIndex";
			this.xrPivotGridField4.Name = "xrPivotGridField4";
			this.xrPivotGridField5.Area = PivotArea.ColumnArea;
			this.xrPivotGridField5.AreaIndex = 0;
			this.xrPivotGridField5.FieldName = "CustomFieldName";
			this.xrPivotGridField5.Name = "xrPivotGridField5";
			this.xrPivotGridField6.Area = PivotArea.RowArea;
			this.xrPivotGridField6.AreaIndex = 0;
			this.xrPivotGridField6.FieldName = "RowIndex";
			this.xrPivotGridField6.Name = "xrPivotGridField6";
			this.xrPivotGridField7.Area = PivotArea.ColumnArea;
			this.xrPivotGridField7.AreaIndex = 0;
			this.xrPivotGridField7.FieldName = "CustomFieldName";
			this.xrPivotGridField7.Name = "xrPivotGridField7";
			this.xrPivotGridField8.Area = PivotArea.RowArea;
			this.xrPivotGridField8.AreaIndex = 0;
			this.xrPivotGridField8.FieldName = "RowIndex";
			this.xrPivotGridField8.Name = "xrPivotGridField8";
			this.xrPivotGridField9.Area = PivotArea.ColumnArea;
			this.xrPivotGridField9.AreaIndex = 0;
			this.xrPivotGridField9.FieldName = "CustomFieldName";
			this.xrPivotGridField9.Name = "xrPivotGridField9";
			this.xrPivotGridField10.Area = PivotArea.RowArea;
			this.xrPivotGridField10.AreaIndex = 0;
			this.xrPivotGridField10.FieldName = "RowIndex";
			this.xrPivotGridField10.Name = "xrPivotGridField10";
			this.xrPivotGridField11.Area = PivotArea.RowArea;
			this.xrPivotGridField11.AreaIndex = 0;
			this.xrPivotGridField11.Name = "xrPivotGridField11";
			this.xrPivotGridField12.Area = PivotArea.RowArea;
			this.xrPivotGridField12.AreaIndex = 1;
			this.xrPivotGridField12.Name = "xrPivotGridField12";
			this.xrPivotGridField13.Area = PivotArea.DataArea;
			this.xrPivotGridField13.AreaIndex = 0;
			this.xrPivotGridField13.FieldName = "Value";
			this.xrPivotGridField13.Name = "xrPivotGridField13";
			this.xrPivotGridField13.Options.ShowCustomTotals = false;
			this.xrPivotGridField13.Options.ShowGrandTotal = false;
			this.xrPivotGridField13.Options.ShowTotals = false;
			this.xrPivotGridField13.SummaryType = PivotSummaryType.Max;
			BandCollection bands1 = base.Bands;
			detail1 = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.DetailReport, this.DetailReport1, this.ReportHeader, this.PageHeader, this.PageFooter };
			bands1.AddRange(detail1);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "SampleReceiveList";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[SampleID] = ?Id";
			base.FormattingRuleSheet.AddRange(new FormattingRule[] { this.formattingRule1 });
			base.Margins = new System.Drawing.Printing.Margins(0, 0, 1, 1);
			ParameterCollection parameters = base.Parameters;
			Parameter[] filterExpression = new Parameter[] { this.FilterExpression, this.Id };
			parameters.AddRange(filterExpression);
			XRControlStyleSheet styleSheet = base.StyleSheet;
			XRControlStyle[] title = new XRControlStyle[] { this.Title, this.FieldCaption, this.PageInfo, this.DataField };
			styleSheet.AddRange(title);
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable3).EndInit();
			((ISupportInitialize)this.xrTable10).EndInit();
			((ISupportInitialize)this.xrTable9).EndInit();
			((ISupportInitialize)this.xrTable8).EndInit();
			((ISupportInitialize)this.xrTable7).EndInit();
			((ISupportInitialize)this.xrTable5).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable11).EndInit();
			((ISupportInitialize)this.xrTable12).EndInit();
			((ISupportInitialize)this.xrTable13).EndInit();
			((ISupportInitialize)this.xrTable14).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		private void SampleReceiptReport_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
				return;
			}
			if (this.Id.Value.ToString() == "0")
			{
				this.FilterString = "";
			}
		}
	}
}