using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Data;
using DevExpress.Data.PivotGrid;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;

namespace PioneerLab.Reports
{
    partial class SampleReceiptReportNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleReceiptReportNew));
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column7 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column9 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression9 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column10 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression10 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery2 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column11 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression11 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table3 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column12 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression12 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column13 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression13 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column14 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression14 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column15 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression15 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column16 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression16 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table4 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column17 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression17 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column18 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression18 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column19 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression19 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column20 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression20 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column21 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression21 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.Join join2 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo3 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo2 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo4 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo3 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo5 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable14 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow29 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell92 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldCustomFieldName = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldValueData = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.realTimeSource1 = new DevExpress.Data.RealTimeSource();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.FilterExpression = new DevExpress.XtraReports.Parameters.Parameter();
            this.Id = new DevExpress.XtraReports.Parameters.Parameter();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport5 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail6 = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.DetailReport6 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail7 = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ReportFooter1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrPivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField5 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField6 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField7 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField8 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField9 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField10 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField11 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField12 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField13 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField15 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField16 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField18 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField14 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField17 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.xrPivotGridField19 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "SampleReceiveList";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            columnExpression1.ColumnName = "CustomFieldID";
            table1.MetaSerializable = "185|30|125|160";
            table1.Name = "MaterialTypesCustomFields";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "FKMaterialTypeID";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "CustomFieldName";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "DataType";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "IsRequired";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "IsLocked";
            columnExpression6.Table = table1;
            column6.Expression = columnExpression6;
            columnExpression7.ColumnName = "SampleReceiveCFLinkID";
            table2.MetaSerializable = "30|30|125|120";
            table2.Name = "SampleReceiveMaterialCustomField";
            columnExpression7.Table = table2;
            column7.Expression = columnExpression7;
            columnExpression8.ColumnName = "FkSampleID";
            columnExpression8.Table = table2;
            column8.Expression = columnExpression8;
            columnExpression9.ColumnName = "FkCustomFieldID";
            columnExpression9.Table = table2;
            column9.Expression = columnExpression9;
            column10.Alias = "ValueData";
            columnExpression10.ColumnName = "Value";
            columnExpression10.Table = table2;
            column10.Expression = columnExpression10;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Columns.Add(column6);
            selectQuery1.Columns.Add(column7);
            selectQuery1.Columns.Add(column8);
            selectQuery1.Columns.Add(column9);
            selectQuery1.Columns.Add(column10);
            selectQuery1.FilterString = "[SampleReceiveMaterialCustomField.FkSampleID] = ?Id";
            selectQuery1.Name = "SampleReceiveMaterialCustomField";
            queryParameter1.Name = "Id";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.Id]", typeof(int));
            selectQuery1.Parameters.Add(queryParameter1);
            relationColumnInfo1.NestedKeyColumn = "CustomFieldID";
            relationColumnInfo1.ParentKeyColumn = "FkCustomFieldID";
            join1.KeyColumns.Add(relationColumnInfo1);
            join1.Nested = table1;
            join1.Parent = table2;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Tables.Add(table2);
            selectQuery1.Tables.Add(table1);
            columnExpression11.ColumnName = "SampleReceiveTCFLinkID";
            table3.MetaSerializable = "30|30|125|140";
            table3.Name = "SampleReceiveMaterialTableCustomField";
            columnExpression11.Table = table3;
            column11.Expression = columnExpression11;
            columnExpression12.ColumnName = "FkSampleID";
            columnExpression12.Table = table3;
            column12.Expression = columnExpression12;
            columnExpression13.ColumnName = "FkCustomFieldID";
            columnExpression13.Table = table3;
            column13.Expression = columnExpression13;
            column14.Alias = "ValueData";
            columnExpression14.ColumnName = "Value";
            columnExpression14.Table = table3;
            column14.Expression = columnExpression14;
            columnExpression15.ColumnName = "RowIndex";
            columnExpression15.Table = table3;
            column15.Expression = columnExpression15;
            columnExpression16.ColumnName = "CustomFieldID";
            table4.MetaSerializable = "185|30|125|160";
            table4.Name = "MaterialTypesCustomFields";
            columnExpression16.Table = table4;
            column16.Expression = columnExpression16;
            columnExpression17.ColumnName = "FKMaterialTypeID";
            columnExpression17.Table = table4;
            column17.Expression = columnExpression17;
            columnExpression18.ColumnName = "CustomFieldName";
            columnExpression18.Table = table4;
            column18.Expression = columnExpression18;
            columnExpression19.ColumnName = "DataType";
            columnExpression19.Table = table4;
            column19.Expression = columnExpression19;
            columnExpression20.ColumnName = "IsRequired";
            columnExpression20.Table = table4;
            column20.Expression = columnExpression20;
            columnExpression21.ColumnName = "IsLocked";
            columnExpression21.Table = table4;
            column21.Expression = columnExpression21;
            selectQuery2.Columns.Add(column11);
            selectQuery2.Columns.Add(column12);
            selectQuery2.Columns.Add(column13);
            selectQuery2.Columns.Add(column14);
            selectQuery2.Columns.Add(column15);
            selectQuery2.Columns.Add(column16);
            selectQuery2.Columns.Add(column17);
            selectQuery2.Columns.Add(column18);
            selectQuery2.Columns.Add(column19);
            selectQuery2.Columns.Add(column20);
            selectQuery2.Columns.Add(column21);
            selectQuery2.FilterString = "[SampleReceiveMaterialTableCustomField.FkSampleID] = ?Id";
            selectQuery2.Name = "SampleReceiveMaterialTableCustomField";
            queryParameter2.Name = "Id";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.Id]", typeof(int));
            selectQuery2.Parameters.Add(queryParameter2);
            relationColumnInfo2.NestedKeyColumn = "CustomFieldID";
            relationColumnInfo2.ParentKeyColumn = "FkCustomFieldID";
            join2.KeyColumns.Add(relationColumnInfo2);
            join2.Nested = table4;
            join2.Parent = table3;
            selectQuery2.Relations.Add(join2);
            selectQuery2.Tables.Add(table3);
            selectQuery2.Tables.Add(table4);
            customSqlQuery2.Name = "SampleReceiveTestList";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            selectQuery1,
            selectQuery2,
            customSqlQuery2});
            masterDetailInfo1.DetailQueryName = "SampleReceiveTestList";
            relationColumnInfo3.NestedKeyColumn = "FKSampleID";
            relationColumnInfo3.ParentKeyColumn = "SampleID";
            masterDetailInfo1.KeyColumns.Add(relationColumnInfo3);
            masterDetailInfo1.MasterQueryName = "SampleReceiveList";
            masterDetailInfo1.Name = "FK_SampleReceiveTestList_SampleReceiveList";
            masterDetailInfo2.DetailQueryName = "SampleReceiveMaterialTableCustomField";
            relationColumnInfo4.NestedKeyColumn = "FkSampleID";
            relationColumnInfo4.ParentKeyColumn = "SampleID";
            masterDetailInfo2.KeyColumns.Add(relationColumnInfo4);
            masterDetailInfo2.MasterQueryName = "SampleReceiveList";
            masterDetailInfo2.Name = "FK_SampleReceiveMaterialTableCustomField_SampleReceiveList";
            masterDetailInfo3.DetailQueryName = "SampleReceiveMaterialCustomField";
            relationColumnInfo5.NestedKeyColumn = "FkSampleID";
            relationColumnInfo5.ParentKeyColumn = "SampleID";
            masterDetailInfo3.KeyColumns.Add(relationColumnInfo5);
            masterDetailInfo3.MasterQueryName = "SampleReceiveList";
            masterDetailInfo3.Name = "FK_SampleReceiveMaterialCustomField_SampleReceiveList";
            this.sqlDataSource1.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1,
            masterDetailInfo2,
            masterDetailInfo3});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.BackColor = System.Drawing.Color.SteelBlue;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6,
            this.xrTable14,
            this.xrTable3,
            this.xrLabel1,
            this.xrTable10,
            this.xrTable9,
            this.xrTable8,
            this.xrTable7,
            this.xrTable5,
            this.xrTable4,
            this.xrTable2,
            this.xrTable1});
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 580.7083F;
            this.Detail.KeepTogether = true;
            this.Detail.KeepTogetherWithDetailReports = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.Detail.StylePriority.UseBackColor = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable6
            // 
            this.xrTable6.Dpi = 100F;
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable6.SizeF = new System.Drawing.SizeF(750.9999F, 20.83334F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23});
            this.xrTableRow4.Dpi = 100F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.BackColor = System.Drawing.Color.LightBlue;
            this.xrTableCell23.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell23.Dpi = 100F;
            this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBackColor = false;
            this.xrTableCell23.StylePriority.UseBorderColor = false;
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseForeColor = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "Customer Details";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell23.Weight = 3D;
            // 
            // xrTable14
            // 
            this.xrTable14.BackColor = System.Drawing.Color.White;
            this.xrTable14.BorderColor = System.Drawing.Color.Black;
            this.xrTable14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable14.Dpi = 100F;
            this.xrTable14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70.83334F);
            this.xrTable14.Name = "xrTable14";
            this.xrTable14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable14.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow29});
            this.xrTable14.SizeF = new System.Drawing.SizeF(750.5F, 24.99999F);
            this.xrTable14.StylePriority.UseBackColor = false;
            this.xrTable14.StylePriority.UseBorderColor = false;
            this.xrTable14.StylePriority.UseBorders = false;
            this.xrTable14.StylePriority.UsePadding = false;
            // 
            // xrTableRow29
            // 
            this.xrTableRow29.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell99,
            this.xrTableCell103,
            this.xrTableCell107,
            this.xrTableCell111});
            this.xrTableRow29.Dpi = 100F;
            this.xrTableRow29.Name = "xrTableRow29";
            this.xrTableRow29.Weight = 1D;
            // 
            // xrTableCell99
            // 
            this.xrTableCell99.Dpi = 100F;
            this.xrTableCell99.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell99.Name = "xrTableCell99";
            this.xrTableCell99.StylePriority.UseFont = false;
            this.xrTableCell99.StylePriority.UseTextAlignment = false;
            this.xrTableCell99.Text = "Customer Name";
            this.xrTableCell99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell99.Weight = 0.55476848397129663D;
            // 
            // xrTableCell103
            // 
            this.xrTableCell103.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.CustomerName")});
            this.xrTableCell103.Dpi = 100F;
            this.xrTableCell103.Name = "xrTableCell103";
            this.xrTableCell103.Weight = 0.93240024221500628D;
            // 
            // xrTableCell107
            // 
            this.xrTableCell107.Dpi = 100F;
            this.xrTableCell107.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell107.Name = "xrTableCell107";
            this.xrTableCell107.StylePriority.UseFont = false;
            this.xrTableCell107.StylePriority.UseTextAlignment = false;
            this.xrTableCell107.Text = "Job Order No";
            this.xrTableCell107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell107.Weight = 0.64220421413565021D;
            // 
            // xrTableCell111
            // 
            this.xrTableCell111.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.JobOrderNumber")});
            this.xrTableCell111.Dpi = 100F;
            this.xrTableCell111.Name = "xrTableCell111";
            this.xrTableCell111.Weight = 1.2269033837048247D;
            // 
            // xrTable3
            // 
            this.xrTable3.BackColor = System.Drawing.Color.White;
            this.xrTable3.BorderColor = System.Drawing.Color.LightGray;
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Dpi = 100F;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(504.7834F, 25F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.xrTable3.SizeF = new System.Drawing.SizeF(246.2166F, 25F);
            this.xrTable3.StylePriority.UseBackColor = false;
            this.xrTable3.StylePriority.UseBorderColor = false;
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell90,
            this.xrTableCell94});
            this.xrTableRow9.Dpi = 100F;
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell90.Dpi = 100F;
            this.xrTableCell90.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.StylePriority.UseBorderColor = false;
            this.xrTableCell90.StylePriority.UseFont = false;
            this.xrTableCell90.StylePriority.UseTextAlignment = false;
            this.xrTableCell90.Text = "Date Entered";
            this.xrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell90.Weight = 1.3906067751133528D;
            // 
            // xrTableCell94
            // 
            this.xrTableCell94.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell94.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SamplingDate", "{0:dd MMM yyyy}")});
            this.xrTableCell94.Dpi = 100F;
            this.xrTableCell94.Name = "xrTableCell94";
            this.xrTableCell94.StylePriority.UseBorderColor = false;
            this.xrTableCell94.StylePriority.UseTextAlignment = false;
            this.xrTableCell94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell94.Weight = 1.7109040008779157D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(328.3922F, 556.6666F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(177.0833F, 22.99997F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Tests On Sample";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTable10
            // 
            this.xrTable10.BackColor = System.Drawing.Color.White;
            this.xrTable10.BorderColor = System.Drawing.Color.Black;
            this.xrTable10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable10.Dpi = 100F;
            this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 526.0416F);
            this.xrTable10.Name = "xrTable10";
            this.xrTable10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow21});
            this.xrTable10.SizeF = new System.Drawing.SizeF(750.1647F, 25F);
            this.xrTable10.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable10.StylePriority.UseBackColor = false;
            this.xrTable10.StylePriority.UseBorderColor = false;
            this.xrTable10.StylePriority.UseBorders = false;
            this.xrTable10.StylePriority.UsePadding = false;
            // 
            // xrTableRow21
            // 
            this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28,
            this.xrTableCell32,
            this.xrTableCell55,
            this.xrTableCell59,
            this.xrTableCell51,
            this.xrTableCell60});
            this.xrTableRow21.Dpi = 100F;
            this.xrTableRow21.Name = "xrTableRow21";
            this.xrTableRow21.Weight = 1D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Dpi = 100F;
            this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.Text = "Service Section";
            this.xrTableCell28.Weight = 0.78407433417001D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.MaterialName")});
            this.xrTableCell32.Dpi = 100F;
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Weight = 0.77660064465578549D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Dpi = 100F;
            this.xrTableCell55.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.StylePriority.UseFont = false;
            this.xrTableCell55.Text = "Material Details";
            this.xrTableCell55.Weight = 0.78033747723364866D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.MaterialsDetails_MaterialName", "{0}")});
            this.xrTableCell59.Dpi = 100F;
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Weight = 0.78033782077637659D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Dpi = 100F;
            this.xrTableCell51.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseFont = false;
            this.xrTableCell51.Text = "Class";
            this.xrTableCell51.Weight = 0.76867854111165157D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.MaterialClass")});
            this.xrTableCell60.Dpi = 100F;
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Weight = 0.79199562594699457D;
            // 
            // xrTable9
            // 
            this.xrTable9.Dpi = 100F;
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 505.2083F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
            this.xrTable9.SizeF = new System.Drawing.SizeF(750.1647F, 20.83334F);
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27});
            this.xrTableRow20.Dpi = 100F;
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Weight = 1D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.BackColor = System.Drawing.Color.LightBlue;
            this.xrTableCell27.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell27.Dpi = 100F;
            this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseBackColor = false;
            this.xrTableCell27.StylePriority.UseBorderColor = false;
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.StylePriority.UseForeColor = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "Material Details";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell27.Weight = 2.8292866487367943D;
            // 
            // xrTable8
            // 
            this.xrTable8.BackColor = System.Drawing.Color.White;
            this.xrTable8.BorderColor = System.Drawing.Color.Black;
            this.xrTable8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable8.Dpi = 100F;
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 237.5F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11,
            this.xrTableRow12,
            this.xrTableRow14,
            this.xrTableRow15,
            this.xrTableRow16,
            this.xrTableRow18,
            this.xrTableRow19,
            this.xrTableRow17,
            this.xrTableRow13,
            this.xrTableRow2});
            this.xrTable8.SizeF = new System.Drawing.SizeF(750.4998F, 265F);
            this.xrTable8.StylePriority.UseBackColor = false;
            this.xrTable8.StylePriority.UseBorderColor = false;
            this.xrTable8.StylePriority.UseBorders = false;
            this.xrTable8.StylePriority.UsePadding = false;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell25,
            this.xrTableCell26});
            this.xrTableRow11.Dpi = 100F;
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Dpi = 100F;
            this.xrTableCell25.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.Text = "Sample Description";
            this.xrTableCell25.Weight = 0.99175730579486687D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleDescription")});
            this.xrTableCell26.Dpi = 100F;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Weight = 5.0082426942051335D;
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell29,
            this.xrTableCell96,
            this.xrTableCell30,
            this.xrTableCell71,
            this.xrTableCell31});
            this.xrTableRow12.Dpi = 100F;
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Dpi = 100F;
            this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseFont = false;
            this.xrTableCell29.Text = "Source";
            this.xrTableCell29.Weight = 0.015961739873047831D;
            // 
            // xrTableCell96
            // 
            this.xrTableCell96.Dpi = 100F;
            this.xrTableCell96.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.StylePriority.UseFont = false;
            this.xrTableCell96.Text = "Source";
            this.xrTableCell96.Weight = 0.9757682098541306D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.Source")});
            this.xrTableCell30.Dpi = 100F;
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Weight = 2.0093981925935123D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Dpi = 100F;
            this.xrTableCell71.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseFont = false;
            this.xrTableCell71.Text = "Supplier";
            this.xrTableCell71.Weight = 0.99647731173773979D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.Supplier")});
            this.xrTableCell31.Dpi = 100F;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Weight = 2.0023945459415691D;
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell72,
            this.xrTableCell39,
            this.xrTableCell63,
            this.xrTableCell40});
            this.xrTableRow14.Dpi = 100F;
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Weight = 1D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Dpi = 100F;
            this.xrTableCell72.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.StylePriority.UseFont = false;
            this.xrTableCell72.Text = "Sampling Date";
            this.xrTableCell72.Weight = 0.99175754278602912D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SamplingDate", "{0:dd MMM yyyy}")});
            this.xrTableCell39.Dpi = 100F;
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Weight = 2.009398375577037D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Dpi = 100F;
            this.xrTableCell63.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.StylePriority.UseFont = false;
            this.xrTableCell63.Text = "Receive Date";
            this.xrTableCell63.Weight = 0.99647725074323168D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ReceiveDate", "{0:dd MMM yyyy}")});
            this.xrTableCell40.Dpi = 100F;
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Weight = 2.0023668308937022D;
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell73,
            this.xrTableCell43,
            this.xrTableCell64,
            this.xrTableCell44});
            this.xrTableRow15.Dpi = 100F;
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Weight = 1.5999996948242188D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Dpi = 100F;
            this.xrTableCell41.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseFont = false;
            this.xrTableCell41.Text = "Quantity";
            this.xrTableCell41.Weight = 0.99175755397306531D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ReceivedQty", "{0:#.}")});
            this.xrTableCell42.Dpi = 100F;
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Weight = 1.0082424460269348D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Dpi = 100F;
            this.xrTableCell73.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell73.Multiline = true;
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.StylePriority.UseFont = false;
            this.xrTableCell73.Text = "Sample Received\r\nTemperature";
            this.xrTableCell73.Weight = 1.0011558459291736D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleTemperature", "{0:n1}")});
            this.xrTableCell43.Dpi = 100F;
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Weight = 0.99647721196508765D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Dpi = 100F;
            this.xrTableCell64.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.StylePriority.UseFont = false;
            this.xrTableCell64.Text = "Unit";
            this.xrTableCell64.Weight = 1.0023669421057384D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.UnitName")});
            this.xrTableCell44.Dpi = 100F;
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Weight = 1D;
            // 
            // xrTableRow16
            // 
            this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell74,
            this.xrTableCell47,
            this.xrTableCell65,
            this.xrTableCell48});
            this.xrTableRow16.Dpi = 100F;
            this.xrTableRow16.Name = "xrTableRow16";
            this.xrTableRow16.Weight = 0.99999999999999989D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Dpi = 100F;
            this.xrTableCell45.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseFont = false;
            this.xrTableCell45.Text = "Sample Condition";
            this.xrTableCell45.Weight = 0.99175754278602912D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleCondition")});
            this.xrTableCell46.Dpi = 100F;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Weight = 1.008242457213971D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Dpi = 100F;
            this.xrTableCell74.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.StylePriority.UseFont = false;
            this.xrTableCell74.Text = "Retention Period";
            this.xrTableCell74.Weight = 1.0011557239401574D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.Column82")});
            this.xrTableCell47.Dpi = 100F;
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Weight = 0.99647735996805464D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Dpi = 100F;
            this.xrTableCell65.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.StylePriority.UseFont = false;
            this.xrTableCell65.Text = "Condition Details";
            this.xrTableCell65.Weight = 1.0023669160917881D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ConditionDetails")});
            this.xrTableCell48.Dpi = 100F;
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Weight = 1D;
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrTableCell66,
            this.xrTableCell56});
            this.xrTableRow18.Dpi = 100F;
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Weight = 0.99999999999999989D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Dpi = 100F;
            this.xrTableCell53.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.StylePriority.UseFont = false;
            this.xrTableCell53.Text = "Site Ref";
            this.xrTableCell53.Weight = 0.99175737808883369D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SiteRefNo")});
            this.xrTableCell54.Dpi = 100F;
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Weight = 3.0058754383001722D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Dpi = 100F;
            this.xrTableCell66.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseFont = false;
            this.xrTableCell66.Text = "Layer No";
            this.xrTableCell66.Weight = 1.002367183610994D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.LayerNo")});
            this.xrTableCell56.Dpi = 100F;
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Weight = 1D;
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell57,
            this.xrTableCell58});
            this.xrTableRow19.Dpi = 100F;
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Weight = 1D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Dpi = 100F;
            this.xrTableCell57.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.StylePriority.UseFont = false;
            this.xrTableCell57.Text = "Sample Location";
            this.xrTableCell57.Weight = 0.99175729880799657D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleLocation")});
            this.xrTableCell58.Dpi = 100F;
            this.xrTableCell58.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.StylePriority.UseFont = false;
            this.xrTableCell58.Weight = 5.0082427011920041D;
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49,
            this.xrTableCell97,
            this.xrTableCell98,
            this.xrTableCell50});
            this.xrTableRow17.Dpi = 100F;
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Dpi = 100F;
            this.xrTableCell49.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseFont = false;
            this.xrTableCell49.Text = "Brought in by Name:";
            this.xrTableCell49.Weight = 0.99175749297855731D;
            // 
            // xrTableCell97
            // 
            this.xrTableCell97.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleBroughtInByName")});
            this.xrTableCell97.Dpi = 100F;
            this.xrTableCell97.Name = "xrTableCell97";
            this.xrTableCell97.Weight = 2.0093982318031158D;
            // 
            // xrTableCell98
            // 
            this.xrTableCell98.Dpi = 100F;
            this.xrTableCell98.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell98.Name = "xrTableCell98";
            this.xrTableCell98.StylePriority.UseFont = false;
            this.xrTableCell98.Text = "Brought in Date:";
            this.xrTableCell98.Weight = 0.9964771711059599D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleBroughtInDate", "{0:dd MMM yyyy}")});
            this.xrTableCell50.Dpi = 100F;
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Weight = 2.0023671041123676D;
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell78,
            this.xrTableCell35,
            this.xrTableCell69,
            this.xrTableCell36});
            this.xrTableRow13.Dpi = 100F;
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1.0000003051757811D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Dpi = 100F;
            this.xrTableCell33.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.StylePriority.UseFont = false;
            this.xrTableCell33.Text = "Contact Person at Site:";
            this.xrTableCell33.Weight = 0.991757555461802D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SiteContactPerson")});
            this.xrTableCell34.Dpi = 100F;
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Weight = 1.0082424445381979D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Dpi = 100F;
            this.xrTableCell78.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.StylePriority.UseFont = false;
            this.xrTableCell78.Text = "Contact Person Mobile No";
            this.xrTableCell78.Weight = 1.0011557239401574D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SiteContactMobile")});
            this.xrTableCell35.Dpi = 100F;
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Weight = 0.99647714019359979D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Dpi = 100F;
            this.xrTableCell69.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.StylePriority.UseFont = false;
            this.xrTableCell69.Text = "Sampled By Name";
            this.xrTableCell69.Weight = 1.0023671358662427D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampledByName")});
            this.xrTableCell36.Dpi = 100F;
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Weight = 1D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6});
            this.xrTableRow2.Dpi = 100F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1.0000003051757811D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "Sampled By";
            this.xrTableCell5.Weight = 0.99175737247827767D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampledBy")});
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 5.0082426275217218D;
            // 
            // xrTable7
            // 
            this.xrTable7.Dpi = 100F;
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 216.6667F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable7.SizeF = new System.Drawing.SizeF(751.1649F, 20.83333F);
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell24});
            this.xrTableRow10.Dpi = 100F;
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.BackColor = System.Drawing.Color.LightBlue;
            this.xrTableCell24.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell24.Dpi = 100F;
            this.xrTableCell24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell24.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBackColor = false;
            this.xrTableCell24.StylePriority.UseBorderColor = false;
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UseForeColor = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "Sample Details";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell24.Weight = 2.8427166846496781D;
            // 
            // xrTable5
            // 
            this.xrTable5.BackColor = System.Drawing.Color.White;
            this.xrTable5.BorderColor = System.Drawing.Color.Black;
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.Dpi = 100F;
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116.6667F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6,
            this.xrTableRow25,
            this.xrTableRow8,
            this.xrTableRow7});
            this.xrTable5.SizeF = new System.Drawing.SizeF(750F, 99.99999F);
            this.xrTable5.StylePriority.UseBackColor = false;
            this.xrTable5.StylePriority.UseBorderColor = false;
            this.xrTable5.StylePriority.UseBorders = false;
            this.xrTable5.StylePriority.UsePadding = false;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11});
            this.xrTableRow6.Dpi = 100F;
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Project Name";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell10.Weight = 0.55513825974009023D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ProjectName")});
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Weight = 2.8011380642866883D;
            // 
            // xrTableRow25
            // 
            this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell52,
            this.xrTableCell82,
            this.xrTableCell81,
            this.xrTableCell68});
            this.xrTableRow25.Dpi = 100F;
            this.xrTableRow25.Name = "xrTableRow25";
            this.xrTableRow25.Weight = 1D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Dpi = 100F;
            this.xrTableCell52.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.StylePriority.UseFont = false;
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            this.xrTableCell52.Text = "Project Contractor";
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell52.Weight = 0.55513825974009035D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ContractorName")});
            this.xrTableCell82.Dpi = 100F;
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.Weight = 0.9352596735104628D;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.Dpi = 100F;
            this.xrTableCell81.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.StylePriority.UseFont = false;
            this.xrTableCell81.Text = "Project Consultant";
            this.xrTableCell81.Weight = 0.64121239347691683D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ProjectConsultant")});
            this.xrTableCell68.Dpi = 100F;
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Weight = 1.2246659972993081D;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell20});
            this.xrTableRow8.Dpi = 100F;
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Dpi = 100F;
            this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "Project No";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell16.Weight = 0.55513827572844043D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.AshghalCode")});
            this.xrTableCell17.Dpi = 100F;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Weight = 0.93525938521066732D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Dpi = 100F;
            this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "Project Client";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell18.Weight = 0.64121266483021844D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ProjectOwner")});
            this.xrTableCell20.Dpi = 100F;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 1.2246659982574513D;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell21});
            this.xrTableRow7.Dpi = 100F;
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Dpi = 100F;
            this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "Project Type";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell13.Weight = 0.55513829912245349D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ProjectTypeName")});
            this.xrTableCell14.Dpi = 100F;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Weight = 0.935259354442883D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Dpi = 100F;
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "Project Location";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell15.Weight = 0.64121280430596794D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ProjectLocation")});
            this.xrTableCell21.Dpi = 100F;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Weight = 1.2246658661554735D;
            // 
            // xrTable4
            // 
            this.xrTable4.Dpi = 100F;
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(402.83F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable4.SizeF = new System.Drawing.SizeF(348.17F, 25F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9});
            this.xrTableRow5.Dpi = 100F;
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.LightBlue;
            this.xrTableCell9.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseForeColor = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Sample Receipt Report";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell9.Weight = 2.9800073676533683D;
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 100F;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95.83333F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(750.5F, 20.83334F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7});
            this.xrTableRow3.Dpi = 100F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BackColor = System.Drawing.Color.LightBlue;
            this.xrTableCell7.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBackColor = false;
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseForeColor = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Project Details";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell7.Weight = 3D;
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.White;
            this.xrTable1.BorderColor = System.Drawing.Color.LightGray;
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 100F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(399.8333F, 25F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.BorderColor = System.Drawing.Color.Black;
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell3});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBorderColor = false;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Sample No";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell1.Weight = 1.0414908036318344D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.SampleNo")});
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell2.Weight = 0.95850919636816556D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "RSS No.";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 0.965018686833762D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.RSSNumber")});
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell3.Weight = 1.034981313166238D;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 29.16667F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable11
            // 
            this.xrTable11.BorderColor = System.Drawing.Color.Black;
            this.xrTable11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable11.Dpi = 100F;
            this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.xrTable11.Name = "xrTable11";
            this.xrTable11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow22,
            this.xrTableRow24,
            this.xrTableRow23});
            this.xrTable11.SizeF = new System.Drawing.SizeF(750.165F, 75F);
            this.xrTable11.StylePriority.UseBorderColor = false;
            this.xrTable11.StylePriority.UseBorders = false;
            this.xrTable11.StylePriority.UsePadding = false;
            // 
            // xrTableRow22
            // 
            this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell61,
            this.xrTableCell62,
            this.xrTableCell84,
            this.xrTableCell67,
            this.xrTableCell88,
            this.xrTableCell92});
            this.xrTableRow22.Dpi = 100F;
            this.xrTableRow22.Name = "xrTableRow22";
            this.xrTableRow22.Weight = 1D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Dpi = 100F;
            this.xrTableCell61.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.StylePriority.UseFont = false;
            this.xrTableCell61.Text = "Delivered Name";
            this.xrTableCell61.Weight = 0.81440243248621891D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.DelivererName")});
            this.xrTableCell62.Dpi = 100F;
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Weight = 1.0860054830988533D;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.Dpi = 100F;
            this.xrTableCell84.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.StylePriority.UseFont = false;
            this.xrTableCell84.Text = "Received By";
            this.xrTableCell84.Weight = 0.69127760988219289D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ReceiveByName")});
            this.xrTableCell67.Dpi = 100F;
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Weight = 1.1296817040453351D;
            // 
            // xrTableCell88
            // 
            this.xrTableCell88.Dpi = 100F;
            this.xrTableCell88.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell88.Name = "xrTableCell88";
            this.xrTableCell88.StylePriority.UseFont = false;
            this.xrTableCell88.Text = "Consultant Name";
            this.xrTableCell88.Weight = 0.870318730948624D;
            // 
            // xrTableCell92
            // 
            this.xrTableCell92.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ConsultantName")});
            this.xrTableCell92.Dpi = 100F;
            this.xrTableCell92.Name = "xrTableCell92";
            this.xrTableCell92.Weight = 1.0956930438075798D;
            // 
            // xrTableRow24
            // 
            this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell77,
            this.xrTableCell79,
            this.xrTableCell85,
            this.xrTableCell80,
            this.xrTableCell89,
            this.xrTableCell93});
            this.xrTableRow24.Dpi = 100F;
            this.xrTableRow24.Name = "xrTableRow24";
            this.xrTableRow24.Weight = 1D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Dpi = 100F;
            this.xrTableCell77.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.StylePriority.UseFont = false;
            this.xrTableCell77.Text = "Mobile No";
            this.xrTableCell77.Weight = 0.81440243248621891D;
            // 
            // xrTableCell79
            // 
            this.xrTableCell79.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.DelivererMobile")});
            this.xrTableCell79.Dpi = 100F;
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.Weight = 1.0860054830988535D;
            // 
            // xrTableCell85
            // 
            this.xrTableCell85.Dpi = 100F;
            this.xrTableCell85.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell85.Name = "xrTableCell85";
            this.xrTableCell85.StylePriority.UseFont = false;
            this.xrTableCell85.Weight = 0.69127739238521335D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.Dpi = 100F;
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.Weight = 1.1296819130687872D;
            // 
            // xrTableCell89
            // 
            this.xrTableCell89.Dpi = 100F;
            this.xrTableCell89.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell89.Multiline = true;
            this.xrTableCell89.Name = "xrTableCell89";
            this.xrTableCell89.StylePriority.UseFont = false;
            this.xrTableCell89.Text = "Mobile No";
            this.xrTableCell89.Weight = 0.87031873942215143D;
            // 
            // xrTableCell93
            // 
            this.xrTableCell93.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.ConsultantMobile")});
            this.xrTableCell93.Dpi = 100F;
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.Weight = 1.0956930438075798D;
            // 
            // xrTableRow23
            // 
            this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell70,
            this.xrTableCell75,
            this.xrTableCell87,
            this.xrTableCell76,
            this.xrTableCell91,
            this.xrTableCell95});
            this.xrTableRow23.Dpi = 100F;
            this.xrTableRow23.Name = "xrTableRow23";
            this.xrTableRow23.Weight = 1D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Dpi = 100F;
            this.xrTableCell70.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.StylePriority.UseFont = false;
            this.xrTableCell70.Text = "Signature";
            this.xrTableCell70.Weight = 0.8144024792928799D;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.Dpi = 100F;
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Weight = 1.0860053966878829D;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.Dpi = 100F;
            this.xrTableCell87.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.StylePriority.UseFont = false;
            this.xrTableCell87.Text = "Signature";
            this.xrTableCell87.Weight = 0.69127764948650228D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.Dpi = 100F;
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.Weight = 1.1296819269409573D;
            // 
            // xrTableCell91
            // 
            this.xrTableCell91.Dpi = 100F;
            this.xrTableCell91.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell91.Name = "xrTableCell91";
            this.xrTableCell91.StylePriority.UseFont = false;
            this.xrTableCell91.Text = "Signature";
            this.xrTableCell91.Weight = 0.87031894304696067D;
            // 
            // xrTableCell95
            // 
            this.xrTableCell95.Dpi = 100F;
            this.xrTableCell95.Name = "xrTableCell95";
            this.xrTableCell95.Weight = 1.0956926088136207D;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1});
            this.DetailReport.DataMember = "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Dpi = 100F;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable12});
            this.Detail1.Dpi = 100F;
            this.Detail1.HeightF = 25F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTable12
            // 
            this.xrTable12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable12.Dpi = 100F;
            this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable12.Name = "xrTable12";
            this.xrTable12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow26});
            this.xrTable12.SizeF = new System.Drawing.SizeF(750.6647F, 25F);
            this.xrTable12.StylePriority.UseBorders = false;
            this.xrTable12.StylePriority.UsePadding = false;
            this.xrTable12.StylePriority.UseTextAlignment = false;
            this.xrTable12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow26
            // 
            this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell100,
            this.xrTableCell22,
            this.xrTableCell101,
            this.xrTableCell102,
            this.xrTableCell19,
            this.xrTableCell104});
            this.xrTableRow26.Dpi = 100F;
            this.xrTableRow26.Name = "xrTableRow26";
            this.xrTableRow26.Weight = 11.5D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.TestName")});
            this.xrTableCell37.Dpi = 100F;
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell37.StylePriority.UsePadding = false;
            this.xrTableCell37.Weight = 1.9661701645347642D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.StandardNumber")});
            this.xrTableCell38.Dpi = 100F;
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Weight = 1.5122588466797091D;
            // 
            // xrTableCell100
            // 
            this.xrTableCell100.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.WitnessName")});
            this.xrTableCell100.Dpi = 100F;
            this.xrTableCell100.Name = "xrTableCell100";
            this.xrTableCell100.Weight = 2.7074731009610415D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.SubContractorName")});
            this.xrTableCell22.Dpi = 100F;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Weight = 1.781070776043749D;
            // 
            // xrTableCell101
            // 
            this.xrTableCell101.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.UnitName")});
            this.xrTableCell101.Dpi = 100F;
            this.xrTableCell101.Name = "xrTableCell101";
            this.xrTableCell101.Weight = 1.3802826580065564D;
            // 
            // xrTableCell102
            // 
            this.xrTableCell102.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.Qty", "{0:#}")});
            this.xrTableCell102.Dpi = 100F;
            this.xrTableCell102.Name = "xrTableCell102";
            this.xrTableCell102.Weight = 1.1317132234067757D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.ReportNumber")});
            this.xrTableCell19.Dpi = 100F;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 1.6792997317100429D;
            // 
            // xrTableCell104
            // 
            this.xrTableCell104.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveTestList_SampleReceiveList.Remarks")});
            this.xrTableCell104.Dpi = 100F;
            this.xrTableCell104.Name = "xrTableCell104";
            this.xrTableCell104.Weight = 3.791612746675149D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable13});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 25.41669F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrTable13
            // 
            this.xrTable13.BackColor = System.Drawing.Color.LightGray;
            this.xrTable13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable13.Dpi = 100F;
            this.xrTable13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.4166921F);
            this.xrTable13.Name = "xrTable13";
            this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow27});
            this.xrTable13.SizeF = new System.Drawing.SizeF(751.1647F, 25F);
            this.xrTable13.StylePriority.UseBackColor = false;
            this.xrTable13.StylePriority.UseBorders = false;
            this.xrTable13.StylePriority.UseFont = false;
            this.xrTable13.StylePriority.UseTextAlignment = false;
            this.xrTable13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow27
            // 
            this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell105,
            this.xrTableCell106,
            this.xrTableCell8,
            this.xrTableCell108,
            this.xrTableCell109,
            this.xrTableCell110,
            this.xrTableCell12,
            this.xrTableCell112});
            this.xrTableRow27.Dpi = 100F;
            this.xrTableRow27.Name = "xrTableRow27";
            this.xrTableRow27.Weight = 11.5D;
            // 
            // xrTableCell105
            // 
            this.xrTableCell105.Dpi = 100F;
            this.xrTableCell105.Name = "xrTableCell105";
            this.xrTableCell105.Text = "Services Name";
            this.xrTableCell105.Weight = 1.96173828125D;
            // 
            // xrTableCell106
            // 
            this.xrTableCell106.Dpi = 100F;
            this.xrTableCell106.Name = "xrTableCell106";
            this.xrTableCell106.StylePriority.UseBackColor = false;
            this.xrTableCell106.Text = "Std No";
            this.xrTableCell106.Weight = 1.50885009765625D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Wtns. Name";
            this.xrTableCell8.Weight = 2.7013691383280243D;
            // 
            // xrTableCell108
            // 
            this.xrTableCell108.Dpi = 100F;
            this.xrTableCell108.Name = "xrTableCell108";
            this.xrTableCell108.Text = "Cont. Name";
            this.xrTableCell108.Weight = 1.777056002290037D;
            // 
            // xrTableCell109
            // 
            this.xrTableCell109.Dpi = 100F;
            this.xrTableCell109.Name = "xrTableCell109";
            this.xrTableCell109.Text = "UnitName";
            this.xrTableCell109.Weight = 1.3771711684741206D;
            // 
            // xrTableCell110
            // 
            this.xrTableCell110.Dpi = 100F;
            this.xrTableCell110.Name = "xrTableCell110";
            this.xrTableCell110.Text = "Qty";
            this.xrTableCell110.Weight = 1.1291635981858965D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Report No";
            this.xrTableCell12.Weight = 1.6755132988096118D;
            // 
            // xrTableCell112
            // 
            this.xrTableCell112.Dpi = 100F;
            this.xrTableCell112.Name = "xrTableCell112";
            this.xrTableCell112.Text = "Remarks";
            this.xrTableCell112.Weight = 3.7936641158767106D;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.BorderColor = System.Drawing.Color.Black;
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.BackColor = System.Drawing.Color.Silver;
            this.xrPivotGrid1.Appearance.FieldHeader.BorderColor = System.Drawing.Color.Black;
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrPivotGrid1.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.Lines.BorderColor = System.Drawing.Color.Black;
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.CellStyleName = "DataField";
            this.xrPivotGrid1.DataMember = "SampleReceiveMaterialTableCustomField";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Dpi = 100F;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldCustomFieldName,
            this.fieldValueData,
            this.pivotGridField1});
            this.xrPivotGrid1.FieldValueStyleName = "DataField";
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0.1646729F, 9.999974F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsDataField.ColumnValueLineCount = 3;
            this.xrPivotGrid1.OptionsDataField.RowValueLineCount = 3;
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(750.5F, 43.74994F);
            this.xrPivotGrid1.CustomRowHeight += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotCustomRowHeightEventArgs>(this.xrPivotGrid1_CustomRowHeight);
            // 
            // fieldCustomFieldName
            // 
            this.fieldCustomFieldName.Appearance.Cell.WordWrap = true;
            this.fieldCustomFieldName.Appearance.FieldHeader.BackColor = System.Drawing.Color.LightGray;
            this.fieldCustomFieldName.Appearance.FieldValue.BackColor = System.Drawing.Color.LightGray;
            this.fieldCustomFieldName.Appearance.FieldValue.WordWrap = true;
            this.fieldCustomFieldName.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldCustomFieldName.AreaIndex = 0;
            this.fieldCustomFieldName.FieldName = "CustomFieldName";
            this.fieldCustomFieldName.Name = "fieldCustomFieldName";
            this.fieldCustomFieldName.Options.HideEmptyVariationItems = true;
            this.fieldCustomFieldName.Options.ShowGrandTotal = false;
            this.fieldCustomFieldName.Options.ShowTotals = false;
            this.fieldCustomFieldName.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            this.fieldCustomFieldName.Width = 97;
            // 
            // fieldValueData
            // 
            this.fieldValueData.Appearance.Cell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldValueData.Appearance.Cell.WordWrap = true;
            this.fieldValueData.Appearance.CustomTotalCell.WordWrap = true;
            this.fieldValueData.Appearance.FieldHeader.BackColor = System.Drawing.Color.LightGray;
            this.fieldValueData.Appearance.FieldHeader.WordWrap = true;
            this.fieldValueData.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldValueData.Appearance.FieldValue.WordWrap = true;
            this.fieldValueData.Appearance.FieldValueGrandTotal.WordWrap = true;
            this.fieldValueData.Appearance.FieldValueTotal.WordWrap = true;
            this.fieldValueData.Appearance.GrandTotalCell.WordWrap = true;
            this.fieldValueData.Appearance.TotalCell.WordWrap = true;
            this.fieldValueData.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldValueData.AreaIndex = 0;
            this.fieldValueData.ColumnValueLineCount = 3;
            this.fieldValueData.FieldName = "ValueData";
            this.fieldValueData.Name = "fieldValueData";
            this.fieldValueData.Options.ShowGrandTotal = false;
            this.fieldValueData.Options.ShowTotals = false;
            this.fieldValueData.RowValueLineCount = 3;
            this.fieldValueData.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            this.fieldValueData.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Appearance.Cell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.pivotGridField1.Appearance.Cell.WordWrap = true;
            this.pivotGridField1.Appearance.FieldHeader.BackColor = System.Drawing.Color.LightGray;
            this.pivotGridField1.Appearance.FieldHeader.WordWrap = true;
            this.pivotGridField1.Appearance.FieldValue.WordWrap = true;
            this.pivotGridField1.Appearance.FieldValueGrandTotal.WordWrap = true;
            this.pivotGridField1.Appearance.FieldValueTotal.WordWrap = true;
            this.pivotGridField1.Appearance.GrandTotalCell.WordWrap = true;
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.ColumnValueLineCount = 2;
            this.pivotGridField1.FieldName = "RowIndex";
            this.pivotGridField1.MinWidth = 0;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.ShowGrandTotal = false;
            this.pivotGridField1.Options.ShowTotals = false;
            this.pivotGridField1.RowValueLineCount = 2;
            this.pivotGridField1.Width = 0;
            // 
            // realTimeSource1
            // 
            this.realTimeSource1.DisplayableProperties = null;
            this.realTimeSource1.UseWeakEventHandler = true;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // FilterExpression
            // 
            this.FilterExpression.Description = "FilterExpression";
            this.FilterExpression.Name = "FilterExpression";
            // 
            // Id
            // 
            this.Id.Description = "Id";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "SampleReceiveList";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "SampleNo";
            dynamicListLookUpSettings1.ValueMember = "SampleID";
            this.Id.LookUpSettings = dynamicListLookUpSettings1;
            this.Id.Name = "Id";
            this.Id.Type = typeof(int);
            this.Id.ValueInfo = "0";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.Expanded = false;
            this.ReportHeader.HeightF = 0F;
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            this.PageHeader.Dpi = 100F;
            this.PageHeader.Expanded = false;
            this.PageHeader.HeightF = 59.74998F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 10.41667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrTable15
            // 
            this.xrTable15.BackColor = System.Drawing.Color.LightGray;
            this.xrTable15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable15.Dpi = 100F;
            this.xrTable15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(0.1646729F, 10.00001F);
            this.xrTable15.Name = "xrTable15";
            this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow28});
            this.xrTable15.SizeF = new System.Drawing.SizeF(317.3304F, 25F);
            this.xrTable15.StylePriority.UseBackColor = false;
            this.xrTable15.StylePriority.UseBorders = false;
            this.xrTable15.StylePriority.UseFont = false;
            this.xrTable15.StylePriority.UseTextAlignment = false;
            this.xrTable15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow28
            // 
            this.xrTableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell83,
            this.xrTableCell86});
            this.xrTableRow28.Dpi = 100F;
            this.xrTableRow28.Name = "xrTableRow28";
            this.xrTableRow28.Weight = 11.5D;
            // 
            // xrTableCell83
            // 
            this.xrTableCell83.Dpi = 100F;
            this.xrTableCell83.Name = "xrTableCell83";
            this.xrTableCell83.Text = "Field Name";
            this.xrTableCell83.Weight = 3.1275448371088244D;
            // 
            // xrTableCell86
            // 
            this.xrTableCell86.Dpi = 100F;
            this.xrTableCell86.Name = "xrTableCell86";
            this.xrTableCell86.StylePriority.UseBackColor = false;
            this.xrTableCell86.Text = "Value";
            this.xrTableCell86.Weight = 2.2209287458169085D;
            // 
            // xrTable16
            // 
            this.xrTable16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable16.Dpi = 100F;
            this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(0.1646729F, 0F);
            this.xrTable16.Name = "xrTable16";
            this.xrTable16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow30});
            this.xrTable16.SizeF = new System.Drawing.SizeF(317.3304F, 25F);
            this.xrTable16.StylePriority.UseBorders = false;
            this.xrTable16.StylePriority.UsePadding = false;
            this.xrTable16.StylePriority.UseTextAlignment = false;
            this.xrTable16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow30
            // 
            this.xrTableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell113,
            this.xrTableCell114});
            this.xrTableRow30.Dpi = 100F;
            this.xrTableRow30.Name = "xrTableRow30";
            this.xrTableRow30.Weight = 11.5D;
            // 
            // xrTableCell113
            // 
            this.xrTableCell113.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveMaterialCustomField_SampleReceiveList.CustomFie" +
                    "ldName")});
            this.xrTableCell113.Dpi = 100F;
            this.xrTableCell113.Name = "xrTableCell113";
            this.xrTableCell113.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell113.StylePriority.UsePadding = false;
            this.xrTableCell113.StylePriority.UseTextAlignment = false;
            this.xrTableCell113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell113.Weight = 2.6462222734765057D;
            // 
            // xrTableCell114
            // 
            this.xrTableCell114.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleReceiveList.FK_SampleReceiveMaterialCustomField_SampleReceiveList.ValueData" +
                    "")});
            this.xrTableCell114.Dpi = 100F;
            this.xrTableCell114.Name = "xrTableCell114";
            this.xrTableCell114.StylePriority.UseTextAlignment = false;
            this.xrTableCell114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell114.Weight = 1.8791325619662675D;
            // 
            // DetailReport5
            // 
            this.DetailReport5.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail6,
            this.GroupHeader5});
            this.DetailReport5.DataMember = "SampleReceiveList.FK_SampleReceiveMaterialCustomField_SampleReceiveList";
            this.DetailReport5.DataSource = this.sqlDataSource1;
            this.DetailReport5.Dpi = 100F;
            this.DetailReport5.Level = 1;
            this.DetailReport5.Name = "DetailReport5";
            this.DetailReport5.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
            this.DetailReport5.ReportPrintOptions.PrintOnEmptyDataSource = false;
            // 
            // Detail6
            // 
            this.Detail6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable16});
            this.Detail6.Dpi = 100F;
            this.Detail6.HeightF = 25F;
            this.Detail6.Name = "Detail6";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable15});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 35.00001F;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // DetailReport6
            // 
            this.DetailReport6.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail7,
            this.GroupHeader4});
            this.DetailReport6.DataMember = "SampleReceiveList.FK_SampleReceiveMaterialTableCustomField_SampleReceiveList";
            this.DetailReport6.DataSource = this.sqlDataSource1;
            this.DetailReport6.Dpi = 100F;
            this.DetailReport6.Level = 2;
            this.DetailReport6.Name = "DetailReport6";
            this.DetailReport6.ReportPrintOptions.PrintOnEmptyDataSource = false;
            // 
            // Detail7
            // 
            this.Detail7.Dpi = 100F;
            this.Detail7.HeightF = 0F;
            this.Detail7.Name = "Detail7";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 53.74991F;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // ReportFooter1
            // 
            this.ReportFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable11});
            this.ReportFooter1.Dpi = 100F;
            this.ReportFooter1.HeightF = 85F;
            this.ReportFooter1.Name = "ReportFooter1";
            // 
            // xrPivotGridField1
            // 
            this.xrPivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField1.AreaIndex = 0;
            this.xrPivotGridField1.Name = "xrPivotGridField1";
            // 
            // xrPivotGridField2
            // 
            this.xrPivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField2.AreaIndex = 0;
            this.xrPivotGridField2.Name = "xrPivotGridField2";
            // 
            // xrPivotGridField3
            // 
            this.xrPivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField3.AreaIndex = 0;
            this.xrPivotGridField3.FieldName = "CustomFieldName";
            this.xrPivotGridField3.Name = "xrPivotGridField3";
            // 
            // xrPivotGridField4
            // 
            this.xrPivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField4.AreaIndex = 1;
            this.xrPivotGridField4.FieldName = "RowIndex";
            this.xrPivotGridField4.Name = "xrPivotGridField4";
            // 
            // xrPivotGridField5
            // 
            this.xrPivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField5.AreaIndex = 0;
            this.xrPivotGridField5.FieldName = "CustomFieldName";
            this.xrPivotGridField5.Name = "xrPivotGridField5";
            // 
            // xrPivotGridField6
            // 
            this.xrPivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField6.AreaIndex = 0;
            this.xrPivotGridField6.FieldName = "RowIndex";
            this.xrPivotGridField6.Name = "xrPivotGridField6";
            // 
            // xrPivotGridField7
            // 
            this.xrPivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField7.AreaIndex = 0;
            this.xrPivotGridField7.FieldName = "CustomFieldName";
            this.xrPivotGridField7.Name = "xrPivotGridField7";
            // 
            // xrPivotGridField8
            // 
            this.xrPivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField8.AreaIndex = 0;
            this.xrPivotGridField8.FieldName = "RowIndex";
            this.xrPivotGridField8.Name = "xrPivotGridField8";
            // 
            // xrPivotGridField9
            // 
            this.xrPivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.xrPivotGridField9.AreaIndex = 0;
            this.xrPivotGridField9.FieldName = "CustomFieldName";
            this.xrPivotGridField9.Name = "xrPivotGridField9";
            // 
            // xrPivotGridField10
            // 
            this.xrPivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField10.AreaIndex = 0;
            this.xrPivotGridField10.FieldName = "RowIndex";
            this.xrPivotGridField10.Name = "xrPivotGridField10";
            // 
            // xrPivotGridField11
            // 
            this.xrPivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField11.AreaIndex = 0;
            this.xrPivotGridField11.Name = "xrPivotGridField11";
            // 
            // xrPivotGridField12
            // 
            this.xrPivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.xrPivotGridField12.AreaIndex = 1;
            this.xrPivotGridField12.Name = "xrPivotGridField12";
            // 
            // xrPivotGridField13
            // 
            this.xrPivotGridField13.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField13.AreaIndex = 0;
            this.xrPivotGridField13.FieldName = "Value";
            this.xrPivotGridField13.Name = "xrPivotGridField13";
            this.xrPivotGridField13.Options.ShowCustomTotals = false;
            this.xrPivotGridField13.Options.ShowGrandTotal = false;
            this.xrPivotGridField13.Options.ShowTotals = false;
            this.xrPivotGridField13.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
            // 
            // xrPivotGridField15
            // 
            this.xrPivotGridField15.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField15.AreaIndex = 0;
            this.xrPivotGridField15.ColumnValueLineCount = 3;
            this.xrPivotGridField15.FieldName = "ValueData";
            this.xrPivotGridField15.Name = "xrPivotGridField15";
            this.xrPivotGridField15.Options.ShowTotals = false;
            this.xrPivotGridField15.RowValueLineCount = 3;
            // 
            // xrPivotGridField16
            // 
            this.xrPivotGridField16.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField16.AreaIndex = 0;
            this.xrPivotGridField16.ColumnValueLineCount = 3;
            this.xrPivotGridField16.FieldName = "ValueData";
            this.xrPivotGridField16.Name = "xrPivotGridField16";
            this.xrPivotGridField16.Options.ShowTotals = false;
            this.xrPivotGridField16.RowValueLineCount = 3;
            // 
            // xrPivotGridField18
            // 
            this.xrPivotGridField18.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField18.AreaIndex = 0;
            this.xrPivotGridField18.ColumnValueLineCount = 3;
            this.xrPivotGridField18.FieldName = "ValueData";
            this.xrPivotGridField18.Name = "xrPivotGridField18";
            this.xrPivotGridField18.Options.ShowTotals = false;
            this.xrPivotGridField18.RowValueLineCount = 3;
            this.xrPivotGridField18.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            // 
            // xrPivotGridField14
            // 
            this.xrPivotGridField14.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField14.AreaIndex = 0;
            this.xrPivotGridField14.ColumnValueLineCount = 3;
            this.xrPivotGridField14.FieldName = "ValueData";
            this.xrPivotGridField14.Name = "xrPivotGridField14";
            this.xrPivotGridField14.Options.ShowTotals = false;
            this.xrPivotGridField14.RowValueLineCount = 3;
            this.xrPivotGridField14.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            // 
            // xrPivotGridField17
            // 
            this.xrPivotGridField17.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField17.AreaIndex = 0;
            this.xrPivotGridField17.ColumnValueLineCount = 3;
            this.xrPivotGridField17.FieldName = "ValueData";
            this.xrPivotGridField17.Name = "xrPivotGridField17";
            this.xrPivotGridField17.Options.ShowTotals = false;
            this.xrPivotGridField17.RowValueLineCount = 3;
            this.xrPivotGridField17.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            // 
            // xrPivotGridField19
            // 
            this.xrPivotGridField19.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.xrPivotGridField19.AreaIndex = 0;
            this.xrPivotGridField19.ColumnValueLineCount = 3;
            this.xrPivotGridField19.FieldName = "ValueData";
            this.xrPivotGridField19.Name = "xrPivotGridField19";
            this.xrPivotGridField19.Options.ShowTotals = false;
            this.xrPivotGridField19.RowValueLineCount = 3;
            this.xrPivotGridField19.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
            // 
            // SampleReceiptReportNew
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.DetailReport,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter,
            this.DetailReport5,
            this.DetailReport6,
            this.ReportFooter1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "SampleReceiveList";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[SampleID] = ?Id";
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Margins = new System.Drawing.Printing.Margins(38, 38, 29, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FilterExpression,
            this.Id});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        // Token: 0x040009D6 RID: 2518
        //private IContainer components;

        // Token: 0x040009D7 RID: 2519
        //private DetailBand Detail;

        // Token: 0x040009D8 RID: 2520
        //private TopMarginBand TopMargin;

        // Token: 0x040009D9 RID: 2521
        //private BottomMarginBand BottomMargin;

        // Token: 0x040009DA RID: 2522
        private XRTable xrTable1;

        // Token: 0x040009DB RID: 2523
        private XRTableRow xrTableRow1;

        // Token: 0x040009DC RID: 2524
        private XRTableCell xrTableCell1;

        // Token: 0x040009DD RID: 2525
        private XRTableCell xrTableCell2;

        // Token: 0x040009DE RID: 2526
        private XRTableCell xrTableCell4;

        // Token: 0x040009DF RID: 2527
        private XRTableCell xrTableCell3;

        // Token: 0x040009E0 RID: 2528
        private SqlDataSource sqlDataSource1;

        // Token: 0x040009E1 RID: 2529
        private XRControlStyle Title;

        // Token: 0x040009E2 RID: 2530
        private XRControlStyle FieldCaption;

        // Token: 0x040009E3 RID: 2531
        private XRControlStyle PageInfo;

        // Token: 0x040009E4 RID: 2532
        private XRControlStyle DataField;

        // Token: 0x040009E5 RID: 2533
        private XRLabel xrLabel1;

        // Token: 0x040009E6 RID: 2534
        private XRTable xrTable10;

        // Token: 0x040009E7 RID: 2535
        private XRTableRow xrTableRow21;

        // Token: 0x040009E8 RID: 2536
        private XRTableCell xrTableCell28;

        // Token: 0x040009E9 RID: 2537
        private XRTableCell xrTableCell32;

        // Token: 0x040009EA RID: 2538
        private XRTableCell xrTableCell55;

        // Token: 0x040009EB RID: 2539
        private XRTableCell xrTableCell59;

        // Token: 0x040009EC RID: 2540
        private XRTableCell xrTableCell51;

        // Token: 0x040009ED RID: 2541
        private XRTableCell xrTableCell60;

        // Token: 0x040009EE RID: 2542
        private XRTable xrTable9;

        // Token: 0x040009EF RID: 2543
        private XRTableRow xrTableRow20;

        // Token: 0x040009F0 RID: 2544
        private XRTableCell xrTableCell27;

        // Token: 0x040009F1 RID: 2545
        private XRTable xrTable8;

        // Token: 0x040009F2 RID: 2546
        private XRTableRow xrTableRow11;

        // Token: 0x040009F3 RID: 2547
        private XRTableCell xrTableCell25;

        // Token: 0x040009F4 RID: 2548
        private XRTableCell xrTableCell26;

        // Token: 0x040009F5 RID: 2549
        private XRTableRow xrTableRow12;

        // Token: 0x040009F6 RID: 2550
        private XRTableCell xrTableCell29;

        // Token: 0x040009F7 RID: 2551
        private XRTableCell xrTableCell30;

        // Token: 0x040009F8 RID: 2552
        private XRTableCell xrTableCell71;

        // Token: 0x040009F9 RID: 2553
        private XRTableCell xrTableCell31;

        // Token: 0x040009FA RID: 2554
        private XRTableRow xrTableRow14;

        // Token: 0x040009FB RID: 2555
        private XRTableCell xrTableCell72;

        // Token: 0x040009FC RID: 2556
        private XRTableCell xrTableCell39;

        // Token: 0x040009FD RID: 2557
        private XRTableCell xrTableCell63;

        // Token: 0x040009FE RID: 2558
        private XRTableCell xrTableCell40;

        // Token: 0x040009FF RID: 2559
        private XRTableRow xrTableRow15;

        // Token: 0x04000A00 RID: 2560
        private XRTableCell xrTableCell41;

        // Token: 0x04000A01 RID: 2561
        private XRTableCell xrTableCell42;

        // Token: 0x04000A02 RID: 2562
        private XRTableCell xrTableCell73;

        // Token: 0x04000A03 RID: 2563
        private XRTableCell xrTableCell43;

        // Token: 0x04000A04 RID: 2564
        private XRTableCell xrTableCell64;

        // Token: 0x04000A05 RID: 2565
        private XRTableCell xrTableCell44;

        // Token: 0x04000A06 RID: 2566
        private XRTableRow xrTableRow16;

        // Token: 0x04000A07 RID: 2567
        private XRTableCell xrTableCell45;

        // Token: 0x04000A08 RID: 2568
        private XRTableCell xrTableCell46;

        // Token: 0x04000A09 RID: 2569
        private XRTableCell xrTableCell74;

        // Token: 0x04000A0A RID: 2570
        private XRTableCell xrTableCell47;

        // Token: 0x04000A0B RID: 2571
        private XRTableCell xrTableCell65;

        // Token: 0x04000A0C RID: 2572
        private XRTableCell xrTableCell48;

        // Token: 0x04000A0D RID: 2573
        private XRTableRow xrTableRow18;

        // Token: 0x04000A0E RID: 2574
        private XRTableCell xrTableCell53;

        // Token: 0x04000A0F RID: 2575
        private XRTableCell xrTableCell54;

        // Token: 0x04000A10 RID: 2576
        private XRTableCell xrTableCell66;

        // Token: 0x04000A11 RID: 2577
        private XRTableCell xrTableCell56;

        // Token: 0x04000A12 RID: 2578
        private XRTableRow xrTableRow19;

        // Token: 0x04000A13 RID: 2579
        private XRTableCell xrTableCell57;

        // Token: 0x04000A14 RID: 2580
        private XRTableCell xrTableCell58;

        // Token: 0x04000A15 RID: 2581
        private XRTableRow xrTableRow17;

        // Token: 0x04000A16 RID: 2582
        private XRTableCell xrTableCell49;

        // Token: 0x04000A17 RID: 2583
        private XRTableCell xrTableCell50;

        // Token: 0x04000A18 RID: 2584
        private XRTableRow xrTableRow13;

        // Token: 0x04000A19 RID: 2585
        private XRTableCell xrTableCell33;

        // Token: 0x04000A1A RID: 2586
        private XRTableCell xrTableCell34;

        // Token: 0x04000A1B RID: 2587
        private XRTableCell xrTableCell78;

        // Token: 0x04000A1C RID: 2588
        private XRTableCell xrTableCell35;

        // Token: 0x04000A1D RID: 2589
        private XRTableCell xrTableCell69;

        // Token: 0x04000A1E RID: 2590
        private XRTableCell xrTableCell36;

        // Token: 0x04000A1F RID: 2591
        private XRTable xrTable7;

        // Token: 0x04000A20 RID: 2592
        private XRTableRow xrTableRow10;

        // Token: 0x04000A21 RID: 2593
        private XRTableCell xrTableCell24;

        // Token: 0x04000A22 RID: 2594
        private XRTable xrTable5;

        // Token: 0x04000A23 RID: 2595
        private XRTableRow xrTableRow6;

        // Token: 0x04000A24 RID: 2596
        private XRTableCell xrTableCell10;

        // Token: 0x04000A25 RID: 2597
        private XRTableCell xrTableCell11;

        // Token: 0x04000A26 RID: 2598
        private XRTableRow xrTableRow8;

        // Token: 0x04000A27 RID: 2599
        private XRTableCell xrTableCell16;

        // Token: 0x04000A28 RID: 2600
        private XRTableCell xrTableCell17;

        // Token: 0x04000A29 RID: 2601
        private XRTableCell xrTableCell18;

        // Token: 0x04000A2A RID: 2602
        private XRTableCell xrTableCell20;

        // Token: 0x04000A2B RID: 2603
        private XRTableRow xrTableRow7;

        // Token: 0x04000A2C RID: 2604
        private XRTableCell xrTableCell13;

        // Token: 0x04000A2D RID: 2605
        private XRTableCell xrTableCell14;

        // Token: 0x04000A2E RID: 2606
        private XRTableCell xrTableCell15;

        // Token: 0x04000A2F RID: 2607
        private XRTableCell xrTableCell21;

        // Token: 0x04000A30 RID: 2608
        private XRTable xrTable4;

        // Token: 0x04000A31 RID: 2609
        private XRTableRow xrTableRow5;

        // Token: 0x04000A32 RID: 2610
        private XRTableCell xrTableCell9;

        // Token: 0x04000A33 RID: 2611
        private XRTable xrTable2;

        // Token: 0x04000A34 RID: 2612
        private XRTableRow xrTableRow3;

        // Token: 0x04000A35 RID: 2613
        private XRTableCell xrTableCell7;

        // Token: 0x04000A36 RID: 2614
        private DetailReportBand DetailReport;

        // Token: 0x04000A37 RID: 2615
        private DetailBand Detail1;

        // Token: 0x04000A38 RID: 2616
        private GroupHeaderBand GroupHeader1;

        // Token: 0x04000A3B RID: 2619
        private XRTable xrTable11;

        // Token: 0x04000A3C RID: 2620
        private XRTableRow xrTableRow22;

        // Token: 0x04000A3D RID: 2621
        private XRTableCell xrTableCell61;

        // Token: 0x04000A3E RID: 2622
        private XRTableCell xrTableCell62;

        // Token: 0x04000A3F RID: 2623
        private XRTableCell xrTableCell84;

        // Token: 0x04000A40 RID: 2624
        private XRTableCell xrTableCell67;

        // Token: 0x04000A41 RID: 2625
        private XRTableCell xrTableCell88;

        // Token: 0x04000A42 RID: 2626
        private XRTableCell xrTableCell92;

        // Token: 0x04000A43 RID: 2627
        private XRTableRow xrTableRow24;

        // Token: 0x04000A44 RID: 2628
        private XRTableCell xrTableCell77;

        // Token: 0x04000A45 RID: 2629
        private XRTableCell xrTableCell79;

        // Token: 0x04000A46 RID: 2630
        private XRTableCell xrTableCell85;

        // Token: 0x04000A47 RID: 2631
        private XRTableCell xrTableCell80;

        // Token: 0x04000A48 RID: 2632
        private XRTableCell xrTableCell89;

        // Token: 0x04000A49 RID: 2633
        private XRTableCell xrTableCell93;

        // Token: 0x04000A4A RID: 2634
        private XRTableRow xrTableRow23;

        // Token: 0x04000A4B RID: 2635
        private XRTableCell xrTableCell70;

        // Token: 0x04000A4C RID: 2636
        private XRTableCell xrTableCell75;

        // Token: 0x04000A4D RID: 2637
        private XRTableCell xrTableCell87;

        // Token: 0x04000A4E RID: 2638
        private XRTableCell xrTableCell76;

        // Token: 0x04000A4F RID: 2639
        private XRTableCell xrTableCell91;

        // Token: 0x04000A50 RID: 2640
        private XRTableCell xrTableCell95;

        // Token: 0x04000A51 RID: 2641
        private XRTableCell xrTableCell96;

        // Token: 0x04000A52 RID: 2642
        private RealTimeSource realTimeSource1;

        // Token: 0x04000A53 RID: 2643
        private FormattingRule formattingRule1;

        // Token: 0x04000A54 RID: 2644
        private XRTableCell xrTableCell97;

        // Token: 0x04000A55 RID: 2645
        private XRTableCell xrTableCell98;

        // Token: 0x04000A56 RID: 2646
        private XRTable xrTable12;

        // Token: 0x04000A57 RID: 2647
        private XRTableRow xrTableRow26;

        // Token: 0x04000A58 RID: 2648
        private XRTableCell xrTableCell37;

        // Token: 0x04000A59 RID: 2649
        private XRTableCell xrTableCell38;

        // Token: 0x04000A5A RID: 2650
        private XRTableCell xrTableCell100;

        // Token: 0x04000A5B RID: 2651
        private XRTableCell xrTableCell101;

        // Token: 0x04000A5C RID: 2652
        private XRTableCell xrTableCell102;

        // Token: 0x04000A5D RID: 2653
        private XRTableCell xrTableCell104;

        // Token: 0x04000A5E RID: 2654
        private XRTable xrTable13;

        // Token: 0x04000A5F RID: 2655
        private XRTableRow xrTableRow27;

        // Token: 0x04000A60 RID: 2656
        private XRTableCell xrTableCell105;

        // Token: 0x04000A61 RID: 2657
        private XRTableCell xrTableCell106;

        // Token: 0x04000A62 RID: 2658
        private XRTableCell xrTableCell108;

        // Token: 0x04000A63 RID: 2659
        private XRTableCell xrTableCell109;

        // Token: 0x04000A64 RID: 2660
        private XRTableCell xrTableCell110;

        // Token: 0x04000A65 RID: 2661
        private XRTableCell xrTableCell112;

        // Token: 0x04000A66 RID: 2662
        private XRTableCell xrTableCell22;

        // Token: 0x04000A67 RID: 2663
        private XRTableCell xrTableCell8;

        // Token: 0x04000A68 RID: 2664
        private Parameter FilterExpression;

        // Token: 0x04000A69 RID: 2665
        private Parameter Id;

        // Token: 0x04000A6A RID: 2666
        private BackgroundWorker backgroundWorker1;

        // Token: 0x04000A6B RID: 2667
        private XRPivotGridField xrPivotGridField5;

        // Token: 0x04000A6C RID: 2668
        private XRPivotGridField xrPivotGridField6;

        // Token: 0x04000A6D RID: 2669
        private XRPivotGridField xrPivotGridField1;

        // Token: 0x04000A6E RID: 2670
        private XRPivotGridField xrPivotGridField2;

        // Token: 0x04000A6F RID: 2671
        private XRPivotGridField xrPivotGridField3;

        // Token: 0x04000A70 RID: 2672
        private XRPivotGridField xrPivotGridField4;

        // Token: 0x04000A71 RID: 2673
        private XRPivotGridField xrPivotGridField9;

        // Token: 0x04000A72 RID: 2674
        private XRPivotGridField xrPivotGridField10;

        // Token: 0x04000A73 RID: 2675
        private XRPivotGridField xrPivotGridField7;

        // Token: 0x04000A74 RID: 2676
        private XRPivotGridField xrPivotGridField8;

        // Token: 0x04000A79 RID: 2681
        private ReportHeaderBand ReportHeader;

        // Token: 0x04000A7A RID: 2682
        private PageHeaderBand PageHeader;

        // Token: 0x04000A7B RID: 2683
        private XRPivotGridField xrPivotGridField11;

        // Token: 0x04000A7C RID: 2684
        private XRPivotGridField xrPivotGridField12;

        // Token: 0x04000A85 RID: 2693
        private XRPivotGridField xrPivotGridField13;

        // Token: 0x04000A86 RID: 2694
        private XRTable xrTable3;

        // Token: 0x04000A87 RID: 2695
        private XRTableRow xrTableRow9;

        // Token: 0x04000A88 RID: 2696
        private XRTableCell xrTableCell90;

        // Token: 0x04000A89 RID: 2697
        private XRTableCell xrTableCell94;

        // Token: 0x04000A8A RID: 2698
        private PageFooterBand PageFooter;

        // Token: 0x04000A8B RID: 2699
        private XRTableRow xrTableRow2;

        // Token: 0x04000A8C RID: 2700
        private XRTableCell xrTableCell5;

        // Token: 0x04000A8D RID: 2701
        private XRTableCell xrTableCell6;

        // Token: 0x04000A8E RID: 2702
        private XRTableCell xrTableCell19;

        // Token: 0x04000A8F RID: 2703
        private XRTableCell xrTableCell12;
        private XRTable xrTable6;
        private XRTableRow xrTableRow4;
        private XRTableCell xrTableCell23;
        private XRTable xrTable14;
        private XRTableRow xrTableRow29;
        private XRTableCell xrTableCell99;
        private XRTableCell xrTableCell103;
        private XRTableCell xrTableCell107;
        private XRTableCell xrTableCell111;
        private XRTableRow xrTableRow25;
        private XRTableCell xrTableCell52;
        private XRTableCell xrTableCell82;
        private XRTableCell xrTableCell81;
        private XRTableCell xrTableCell68;
        private XRPivotGrid xrPivotGrid1;
        private XRPivotGridField fieldCustomFieldName;
        private XRPivotGridField pivotGridField1;
        private XRPivotGridField fieldValueData;
        private XRPivotGridField xrPivotGridField15;
        private XRPivotGridField xrPivotGridField16;
        private XRPivotGridField xrPivotGridField18;
        private XRPivotGridField xrPivotGridField14;
        private XRPivotGridField xrPivotGridField17;
        private XRPivotGridField xrPivotGridField19;
        private XRTable xrTable16;
        private XRTableRow xrTableRow30;
        private XRTableCell xrTableCell113;
        private XRTableCell xrTableCell114;
        private XRTable xrTable15;
        private XRTableRow xrTableRow28;
        private XRTableCell xrTableCell83;
        private XRTableCell xrTableCell86;
        private DetailReportBand DetailReport5;
        private DetailBand Detail6;
        private GroupHeaderBand GroupHeader5;
        private DetailReportBand DetailReport6;
        private DetailBand Detail7;
        private GroupHeaderBand GroupHeader4;
        private ReportFooterBand ReportFooter1;
    }
}
