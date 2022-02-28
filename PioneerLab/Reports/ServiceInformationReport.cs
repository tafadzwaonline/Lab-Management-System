using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

namespace PioneerLab.Reports
{
	// Token: 0x0200006C RID: 108
	public class ServiceInformationReport : XtraReport
	{
		// Token: 0x06000380 RID: 896 RVA: 0x000045E2 File Offset: 0x000027E2
		public ServiceInformationReport()
		{
			this.InitializeComponent();
			this.BeforePrint += this.ServiceInformationReport_BeforePrint;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00059FD4 File Offset: 0x000581D4
		private void ServiceInformationReport_BeforePrint(object sender, PrintEventArgs e)
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

		// Token: 0x06000382 RID: 898 RVA: 0x00004602 File Offset: 0x00002802
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0005A03C File Offset: 0x0005823C
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
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
            DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column9 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression9 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column10 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression10 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column11 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression11 = new DevExpress.DataAccess.Sql.ColumnExpression();
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
            DevExpress.DataAccess.Sql.Column column22 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression22 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column23 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression23 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column24 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression24 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column25 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression25 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column26 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression26 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column27 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression27 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery2 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column28 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression28 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table3 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column29 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression29 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column30 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression30 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column31 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression31 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column32 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression32 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.AllColumns allColumns1 = new DevExpress.DataAccess.Sql.AllColumns();
            DevExpress.DataAccess.Sql.Table table4 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Join join2 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery3 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column33 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression33 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table5 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column34 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression34 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column35 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression35 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column36 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression36 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table6 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column37 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression37 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column38 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression38 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column39 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression39 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column40 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression40 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column41 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression41 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column42 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression42 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column43 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression43 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join3 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo3 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery4 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column44 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression44 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table7 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column45 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression45 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column46 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression46 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column47 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression47 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column48 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression48 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column49 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression49 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column50 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression50 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table8 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column51 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression51 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column52 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression52 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join4 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo4 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo5 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo2 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo6 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo3 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo7 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo4 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo8 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox2 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox3 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox4 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport2 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport3 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail4 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport5 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail6 = new DevExpress.XtraReports.UI.DetailBand();
            this.FilterExpression = new DevExpress.XtraReports.Parameters.Parameter();
            this.Id = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "TestID";
            table1.MetaSerializable = "<Meta X=\"30\" Y=\"30\" Width=\"125\" Height=\"480\" />";
            table1.Name = "TestsList";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "StandardNumber";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "AshghalTestNumber";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "TestName";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "TestDescription";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "ShortName";
            columnExpression6.Table = table1;
            column6.Expression = columnExpression6;
            columnExpression7.ColumnName = "FKAccreditionID";
            columnExpression7.Table = table1;
            column7.Expression = columnExpression7;
            columnExpression8.ColumnName = "FKLabID";
            columnExpression8.Table = table1;
            column8.Expression = columnExpression8;
            columnExpression9.ColumnName = "ResultUnit";
            columnExpression9.Table = table1;
            column9.Expression = columnExpression9;
            columnExpression10.ColumnName = "ResultSpecs";
            columnExpression10.Table = table1;
            column10.Expression = columnExpression10;
            columnExpression11.ColumnName = "SamplingMethod";
            columnExpression11.Table = table1;
            column11.Expression = columnExpression11;
            columnExpression12.ColumnName = "WorkFormFileName";
            columnExpression12.Table = table1;
            column12.Expression = columnExpression12;
            columnExpression13.ColumnName = "WorkFormWorksheet";
            columnExpression13.Table = table1;
            column13.Expression = columnExpression13;
            columnExpression14.ColumnName = "ReportFileName";
            columnExpression14.Table = table1;
            column14.Expression = columnExpression14;
            columnExpression15.ColumnName = "ReportWorksheet";
            columnExpression15.Table = table1;
            column15.Expression = columnExpression15;
            columnExpression16.ColumnName = "DefaultPrice";
            columnExpression16.Table = table1;
            column16.Expression = columnExpression16;
            columnExpression17.ColumnName = "MinimumPrice";
            columnExpression17.Table = table1;
            column17.Expression = columnExpression17;
            columnExpression18.ColumnName = "IsLocked";
            columnExpression18.Table = table1;
            column18.Expression = columnExpression18;
            columnExpression19.ColumnName = "IsSubcontractedTest";
            columnExpression19.Table = table1;
            column19.Expression = columnExpression19;
            columnExpression20.ColumnName = "IsSiteTest";
            columnExpression20.Table = table1;
            column20.Expression = columnExpression20;
            columnExpression21.ColumnName = "FKTestID";
            columnExpression21.Table = table1;
            column21.Expression = columnExpression21;
            columnExpression22.ColumnName = "IsUnavailable";
            columnExpression22.Table = table1;
            column22.Expression = columnExpression22;
            columnExpression23.ColumnName = "LabID";
            table2.MetaSerializable = "<Meta X=\"185\" Y=\"30\" Width=\"125\" Height=\"140\" />";
            table2.Name = "LabsList";
            columnExpression23.Table = table2;
            column23.Expression = columnExpression23;
            columnExpression24.ColumnName = "LabName";
            columnExpression24.Table = table2;
            column24.Expression = columnExpression24;
            columnExpression25.ColumnName = "Remarks";
            columnExpression25.Table = table2;
            column25.Expression = columnExpression25;
            columnExpression26.ColumnName = "LabInCharge";
            columnExpression26.Table = table2;
            column26.Expression = columnExpression26;
            column27.Alias = "LabsList_IsLocked";
            columnExpression27.ColumnName = "IsLocked";
            columnExpression27.Table = table2;
            column27.Expression = columnExpression27;
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
            selectQuery1.Columns.Add(column21);
            selectQuery1.Columns.Add(column22);
            selectQuery1.Columns.Add(column23);
            selectQuery1.Columns.Add(column24);
            selectQuery1.Columns.Add(column25);
            selectQuery1.Columns.Add(column26);
            selectQuery1.Columns.Add(column27);
            selectQuery1.Name = "TestsList";
            relationColumnInfo1.NestedKeyColumn = "LabID";
            relationColumnInfo1.ParentKeyColumn = "FKLabID";
            join1.KeyColumns.Add(relationColumnInfo1);
            join1.Nested = table2;
            join1.Parent = table1;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Tables.Add(table1);
            selectQuery1.Tables.Add(table2);
            customSqlQuery1.Name = "TestItems";
            customSqlQuery1.Sql = null;
            columnExpression28.ColumnName = "TestPriceID";
            table3.MetaSerializable = "<Meta X=\"30\" Y=\"30\" Width=\"125\" Height=\"140\" />";
            table3.Name = "TestPrices";
            columnExpression28.Table = table3;
            column28.Expression = columnExpression28;
            columnExpression29.ColumnName = "FKTestID";
            columnExpression29.Table = table3;
            column29.Expression = columnExpression29;
            columnExpression30.ColumnName = "FKPriceUnitID";
            columnExpression30.Table = table3;
            column30.Expression = columnExpression30;
            columnExpression31.ColumnName = "DefaultPrice";
            columnExpression31.Table = table3;
            column31.Expression = columnExpression31;
            columnExpression32.ColumnName = "MinimumPrice";
            columnExpression32.Table = table3;
            column32.Expression = columnExpression32;
            table4.MetaSerializable = "<Meta X=\"185\" Y=\"30\" Width=\"125\" Height=\"140\" />";
            table4.Name = "PriceUnitList";
            allColumns1.Table = table4;
            selectQuery2.Columns.Add(column28);
            selectQuery2.Columns.Add(column29);
            selectQuery2.Columns.Add(column30);
            selectQuery2.Columns.Add(column31);
            selectQuery2.Columns.Add(column32);
            selectQuery2.Columns.Add(allColumns1);
            selectQuery2.Name = "TestPrices";
            relationColumnInfo2.NestedKeyColumn = "PriceUnitID";
            relationColumnInfo2.ParentKeyColumn = "FKPriceUnitID";
            join2.KeyColumns.Add(relationColumnInfo2);
            join2.Nested = table4;
            join2.Parent = table3;
            selectQuery2.Relations.Add(join2);
            selectQuery2.Tables.Add(table3);
            selectQuery2.Tables.Add(table4);
            columnExpression33.ColumnName = "TestEquipmentID";
            table5.MetaSerializable = "<Meta X=\"30\" Y=\"30\" Width=\"125\" Height=\"100\" />";
            table5.Name = "TestEquipments";
            columnExpression33.Table = table5;
            column33.Expression = columnExpression33;
            columnExpression34.ColumnName = "FKEquipmentID";
            columnExpression34.Table = table5;
            column34.Expression = columnExpression34;
            columnExpression35.ColumnName = "FKTestID";
            columnExpression35.Table = table5;
            column35.Expression = columnExpression35;
            columnExpression36.ColumnName = "EquipmentID";
            table6.MetaSerializable = "<Meta X=\"185\" Y=\"30\" Width=\"125\" Height=\"200\" />";
            table6.Name = "EquipmentsList";
            columnExpression36.Table = table6;
            column36.Expression = columnExpression36;
            columnExpression37.ColumnName = "EquipmentName";
            columnExpression37.Table = table6;
            column37.Expression = columnExpression37;
            columnExpression38.ColumnName = "FKLabID";
            columnExpression38.Table = table6;
            column38.Expression = columnExpression38;
            columnExpression39.ColumnName = "CalibrationDate";
            columnExpression39.Table = table6;
            column39.Expression = columnExpression39;
            columnExpression40.ColumnName = "ExpiryDate";
            columnExpression40.Table = table6;
            column40.Expression = columnExpression40;
            columnExpression41.ColumnName = "FKEmpID";
            columnExpression41.Table = table6;
            column41.Expression = columnExpression41;
            columnExpression42.ColumnName = "CalibratedBy";
            columnExpression42.Table = table6;
            column42.Expression = columnExpression42;
            columnExpression43.ColumnName = "Remarks";
            columnExpression43.Table = table6;
            column43.Expression = columnExpression43;
            selectQuery3.Columns.Add(column33);
            selectQuery3.Columns.Add(column34);
            selectQuery3.Columns.Add(column35);
            selectQuery3.Columns.Add(column36);
            selectQuery3.Columns.Add(column37);
            selectQuery3.Columns.Add(column38);
            selectQuery3.Columns.Add(column39);
            selectQuery3.Columns.Add(column40);
            selectQuery3.Columns.Add(column41);
            selectQuery3.Columns.Add(column42);
            selectQuery3.Columns.Add(column43);
            selectQuery3.Name = "TestEquipments";
            relationColumnInfo3.NestedKeyColumn = "EquipmentID";
            relationColumnInfo3.ParentKeyColumn = "FKEquipmentID";
            join3.KeyColumns.Add(relationColumnInfo3);
            join3.Nested = table6;
            join3.Parent = table5;
            selectQuery3.Relations.Add(join3);
            selectQuery3.Tables.Add(table5);
            selectQuery3.Tables.Add(table6);
            columnExpression44.ColumnName = "SubContractorID";
            table7.MetaSerializable = "<Meta X=\"185\" Y=\"30\" Width=\"125\" Height=\"160\" />";
            table7.Name = "SubcontractorsList";
            columnExpression44.Table = table7;
            column44.Expression = columnExpression44;
            columnExpression45.ColumnName = "SubContractorCode";
            columnExpression45.Table = table7;
            column45.Expression = columnExpression45;
            columnExpression46.ColumnName = "SubContractorName";
            columnExpression46.Table = table7;
            column46.Expression = columnExpression46;
            columnExpression47.ColumnName = "AccreditationExpiryDate";
            columnExpression47.Table = table7;
            column47.Expression = columnExpression47;
            columnExpression48.ColumnName = "Address";
            columnExpression48.Table = table7;
            column48.Expression = columnExpression48;
            columnExpression49.ColumnName = "IsLocked";
            columnExpression49.Table = table7;
            column49.Expression = columnExpression49;
            columnExpression50.ColumnName = "TestContractorsID";
            table8.MetaSerializable = "<Meta X=\"30\" Y=\"30\" Width=\"125\" Height=\"100\" />";
            table8.Name = "TestContractors";
            columnExpression50.Table = table8;
            column50.Expression = columnExpression50;
            columnExpression51.ColumnName = "FKTestID";
            columnExpression51.Table = table8;
            column51.Expression = columnExpression51;
            columnExpression52.ColumnName = "FKSubContractorID";
            columnExpression52.Table = table8;
            column52.Expression = columnExpression52;
            selectQuery4.Columns.Add(column44);
            selectQuery4.Columns.Add(column45);
            selectQuery4.Columns.Add(column46);
            selectQuery4.Columns.Add(column47);
            selectQuery4.Columns.Add(column48);
            selectQuery4.Columns.Add(column49);
            selectQuery4.Columns.Add(column50);
            selectQuery4.Columns.Add(column51);
            selectQuery4.Columns.Add(column52);
            selectQuery4.Name = "TestContractors";
            relationColumnInfo4.NestedKeyColumn = "SubContractorID";
            relationColumnInfo4.ParentKeyColumn = "FKSubContractorID";
            join4.KeyColumns.Add(relationColumnInfo4);
            join4.Nested = table7;
            join4.Parent = table8;
            selectQuery4.Relations.Add(join4);
            selectQuery4.Tables.Add(table8);
            selectQuery4.Tables.Add(table7);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1,
            customSqlQuery1,
            selectQuery2,
            selectQuery3,
            selectQuery4});
            masterDetailInfo1.DetailQueryName = "TestContractors";
            relationColumnInfo5.NestedKeyColumn = "FKTestID";
            relationColumnInfo5.ParentKeyColumn = "TestID";
            masterDetailInfo1.KeyColumns.Add(relationColumnInfo5);
            masterDetailInfo1.MasterQueryName = "TestsList";
            masterDetailInfo1.Name = "FK_TestContractors_TestsList";
            masterDetailInfo2.DetailQueryName = "TestEquipments";
            relationColumnInfo6.NestedKeyColumn = "FKTestID";
            relationColumnInfo6.ParentKeyColumn = "TestID";
            masterDetailInfo2.KeyColumns.Add(relationColumnInfo6);
            masterDetailInfo2.MasterQueryName = "TestsList";
            masterDetailInfo2.Name = "FK_TestEquipments_TestsList";
            masterDetailInfo3.DetailQueryName = "TestPrices";
            relationColumnInfo7.NestedKeyColumn = "FKTestID";
            relationColumnInfo7.ParentKeyColumn = "TestID";
            masterDetailInfo3.KeyColumns.Add(relationColumnInfo7);
            masterDetailInfo3.MasterQueryName = "TestsList";
            masterDetailInfo3.Name = "FK_TestPrices_TestsList";
            masterDetailInfo4.DetailQueryName = "TestItems";
            relationColumnInfo8.NestedKeyColumn = "FKTestID";
            relationColumnInfo8.ParentKeyColumn = "TestID";
            masterDetailInfo4.KeyColumns.Add(relationColumnInfo8);
            masterDetailInfo4.MasterQueryName = "TestsList";
            this.sqlDataSource1.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1,
            masterDetailInfo2,
            masterDetailInfo3,
            masterDetailInfo4});
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine3,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel27,
            this.xrCheckBox1,
            this.xrCheckBox2,
            this.xrCheckBox3,
            this.xrCheckBox4,
            this.xrLabel31,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLine1});
            this.Detail.Expanded = false;
            this.Detail.HeightF = 226.1946F;
            this.Detail.KeepTogether = true;
            this.Detail.KeepTogetherWithDetailReports = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(5.833313F, 219.3942F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(838F, 2F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(268.0233F, 46.37508F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(165.9348F, 18F);
            this.xrLabel1.StyleName = "FieldCaption";
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.Text = "Ashghal Test Number:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(6.416609F, 126.7501F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(142.5763F, 18.00001F);
            this.xrLabel3.StyleName = "FieldCaption";
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.Text = "Accredition Status:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(579.6666F, 126.7501F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(97.92957F, 18.00001F);
            this.xrLabel4.StyleName = "FieldCaption";
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.Text = "Lab Section:";
            // 
            // xrLabel5
            // 
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(570.2144F, 184.7501F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(136.0355F, 18F);
            this.xrLabel5.StyleName = "FieldCaption";
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.Text = "Mandatory Service:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(659.125F, 10.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(162F, 23F);
            this.xrLabel6.StyleName = "FieldCaption";
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.Text = "Inactive";
            // 
            // xrLabel7
            // 
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(525.7917F, 10.00001F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(68.25F, 23F);
            this.xrLabel7.StyleName = "FieldCaption";
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.Text = "Site Test";
            // 
            // xrLabel8
            // 
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(254.7084F, 10.00001F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(190.125F, 23F);
            this.xrLabel8.StyleName = "FieldCaption";
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.Text = "Service to be subcontracted";
            // 
            // xrLabel9
            // 
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(33.12505F, 10.00001F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(178.875F, 23F);
            this.xrLabel9.StyleName = "FieldCaption";
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.Text = "Test not available\r\n\r\n";
            // 
            // xrLabel13
            // 
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(286.1666F, 156.6251F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(94.62494F, 18F);
            this.xrLabel13.StyleName = "FieldCaption";
            this.xrLabel13.StylePriority.UseForeColor = false;
            this.xrLabel13.Text = "Result Specs";
            // 
            // xrLabel14
            // 
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(8.001344F, 156.6251F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(116.8319F, 18.00002F);
            this.xrLabel14.StyleName = "FieldCaption";
            this.xrLabel14.StylePriority.UseForeColor = false;
            this.xrLabel14.Text = "Result Unit:";
            // 
            // xrLabel15
            // 
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(6.416609F, 184.7501F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(142.5763F, 18F);
            this.xrLabel15.StyleName = "FieldCaption";
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.Text = "Sampling Method:";
            // 
            // xrLabel16
            // 
            this.xrLabel16.ForeColor = System.Drawing.Color.Black;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(579.6666F, 70.37508F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(97.92963F, 18F);
            this.xrLabel16.StyleName = "FieldCaption";
            this.xrLabel16.StylePriority.UseForeColor = false;
            this.xrLabel16.Text = "Short Name:";
            // 
            // xrLabel17
            // 
            this.xrLabel17.ForeColor = System.Drawing.Color.Black;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(579.6666F, 46.37508F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(126.5833F, 18F);
            this.xrLabel17.StyleName = "FieldCaption";
            this.xrLabel17.StylePriority.UseForeColor = false;
            this.xrLabel17.Text = "Standard Number:";
            // 
            // xrLabel18
            // 
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(6.416609F, 98.41676F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(150.9797F, 18F);
            this.xrLabel18.StyleName = "FieldCaption";
            this.xrLabel18.StylePriority.UseForeColor = false;
            this.xrLabel18.Text = "Standard Description:";
            // 
            // xrLabel19
            // 
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(6.416609F, 46.37508F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(116.8319F, 18F);
            this.xrLabel19.StyleName = "FieldCaption";
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.Text = "Service Number:";
            // 
            // xrLabel20
            // 
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(6.416609F, 70.37508F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(116.8319F, 18F);
            this.xrLabel20.StyleName = "FieldCaption";
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.Text = "Service Name:";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.AshghalTestNumber")});
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(435.2276F, 46.37508F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(117.6891F, 18F);
            this.xrLabel23.StyleName = "DataField";
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.Text = "xrLabel23";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.AccreditionName")});
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(162.6484F, 126.7501F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(255.9583F, 18F);
            this.xrLabel25.StyleName = "DataField";
            this.xrLabel25.StylePriority.UseBorders = false;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.LabName")});
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(706.2499F, 126.7501F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(131.7501F, 17.99999F);
            this.xrLabel26.StyleName = "DataField";
            this.xrLabel26.StylePriority.UseBorders = false;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.FKTestID")});
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(706.2499F, 184.75F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(131.7501F, 18F);
            this.xrLabel27.StyleName = "DataField";
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.Text = "xrLabel27";
            // 
            // xrCheckBox1
            // 
            this.xrCheckBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "TestsList.IsLocked")});
            this.xrCheckBox1.LocationFloat = new DevExpress.Utils.PointFloat(638.0833F, 10.00001F);
            this.xrCheckBox1.Name = "xrCheckBox1";
            this.xrCheckBox1.SizeF = new System.Drawing.SizeF(21.04169F, 23F);
            this.xrCheckBox1.StyleName = "DataField";
            // 
            // xrCheckBox2
            // 
            this.xrCheckBox2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "TestsList.IsSiteTest")});
            this.xrCheckBox2.LocationFloat = new DevExpress.Utils.PointFloat(501.625F, 10.00001F);
            this.xrCheckBox2.Name = "xrCheckBox2";
            this.xrCheckBox2.SizeF = new System.Drawing.SizeF(24.16669F, 23F);
            this.xrCheckBox2.StyleName = "DataField";
            // 
            // xrCheckBox3
            // 
            this.xrCheckBox3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "TestsList.IsSubcontractedTest")});
            this.xrCheckBox3.LocationFloat = new DevExpress.Utils.PointFloat(229.5F, 10.00001F);
            this.xrCheckBox3.Name = "xrCheckBox3";
            this.xrCheckBox3.SizeF = new System.Drawing.SizeF(25.20837F, 23F);
            this.xrCheckBox3.StyleName = "DataField";
            // 
            // xrCheckBox4
            // 
            this.xrCheckBox4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "TestsList.IsUnavailable")});
            this.xrCheckBox4.LocationFloat = new DevExpress.Utils.PointFloat(5.833308F, 10.00001F);
            this.xrCheckBox4.Name = "xrCheckBox4";
            this.xrCheckBox4.SizeF = new System.Drawing.SizeF(27.29169F, 23F);
            this.xrCheckBox4.StyleName = "DataField";
            // 
            // xrLabel31
            // 
            this.xrLabel31.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.ResultSpecs")});
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(380.7916F, 156.6251F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(457.2084F, 18.00002F);
            this.xrLabel31.StyleName = "DataField";
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.Text = "xrLabel31";
            // 
            // xrLabel32
            // 
            this.xrLabel32.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.ResultUnit")});
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(162.6484F, 156.6251F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(109.5833F, 18F);
            this.xrLabel32.StyleName = "DataField";
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.Text = "xrLabel32";
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.SamplingMethod")});
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(162.6484F, 184.75F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(193.0416F, 18F);
            this.xrLabel33.StyleName = "DataField";
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.Text = "xrLabel33";
            // 
            // xrLabel34
            // 
            this.xrLabel34.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.ShortName")});
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(706.2499F, 70.37508F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(131.7501F, 18F);
            this.xrLabel34.StyleName = "DataField";
            this.xrLabel34.StylePriority.UseBorders = false;
            this.xrLabel34.Text = "xrLabel34";
            // 
            // xrLabel35
            // 
            this.xrLabel35.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.StandardNumber")});
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(706.2499F, 46.37508F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(131.7501F, 18F);
            this.xrLabel35.StyleName = "DataField";
            this.xrLabel35.StylePriority.UseBorders = false;
            this.xrLabel35.Text = "xrLabel35";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.TestDescription")});
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(162.6484F, 98.41676F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(667.9987F, 18F);
            this.xrLabel36.StyleName = "DataField";
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.Text = "xrLabel36";
            // 
            // xrLabel37
            // 
            this.xrLabel37.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.TestID")});
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(162.6484F, 46.37508F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(100.2083F, 18F);
            this.xrLabel37.StyleName = "DataField";
            this.xrLabel37.StylePriority.UseBorders = false;
            this.xrLabel37.Text = "xrLabel37";
            // 
            // xrLabel38
            // 
            this.xrLabel38.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.TestName")});
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(162.6484F, 70.37508F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(362.8751F, 18F);
            this.xrLabel38.StyleName = "DataField";
            this.xrLabel38.StylePriority.UseBorders = false;
            this.xrLabel38.Text = "xrLabel38";
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(2.874978F, 33.00002F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(838F, 2F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 8.125003F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 9.095637F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60.80884F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(162F, 18F);
            this.xrLabel11.StyleName = "FieldCaption";
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.Text = "Report File Name";
            // 
            // xrLabel12
            // 
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(435.2276F, 60.80884F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(162F, 18F);
            this.xrLabel12.StyleName = "FieldCaption";
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.Text = "Report Worksheet";
            // 
            // xrLabel21
            // 
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.05885F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(162F, 18F);
            this.xrLabel21.StyleName = "FieldCaption";
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.Text = "Work Form File Name";
            // 
            // xrLabel22
            // 
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(435.2276F, 32.05885F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(162F, 18F);
            this.xrLabel22.StyleName = "FieldCaption";
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.Text = "Work Form Worksheet";
            // 
            // xrLabel29
            // 
            this.xrLabel29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.ReportFileName")});
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(177.2521F, 60.80884F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(203.5394F, 18F);
            this.xrLabel29.StyleName = "DataField";
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.Text = "xrLabel29";
            // 
            // xrLabel30
            // 
            this.xrLabel30.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.ReportWorksheet")});
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(608.0419F, 60.80884F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(232.8332F, 18F);
            this.xrLabel30.StyleName = "DataField";
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.Text = "xrLabel30";
            // 
            // xrLabel39
            // 
            this.xrLabel39.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.WorkFormFileName")});
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(177.2521F, 32.05885F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(203.5394F, 18F);
            this.xrLabel39.StyleName = "DataField";
            this.xrLabel39.StylePriority.UseBorders = false;
            this.xrLabel39.Text = "xrLabel39";
            // 
            // xrLabel40
            // 
            this.xrLabel40.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.WorkFormWorksheet")});
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(605.1668F, 32.05885F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(232.8332F, 18F);
            this.xrLabel40.StyleName = "DataField";
            this.xrLabel40.StylePriority.UseBorders = false;
            this.xrLabel40.Text = "xrLabel40";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox2,
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.pageFooterBand1.HeightF = 109.2083F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(136.4583F, 0F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(581.3381F, 74.20829F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2.000022F, 86.20828F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StyleName = "PageInfo";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(530.8333F, 86.20828F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrPageInfo2.TextFormatString = "Page {0} of {1}";
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.HeightF = 14F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
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
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(2.875032F, 0F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(838F, 2F);
            // 
            // xrLine4
            // 
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(2.000023F, 9.999989F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(838F, 2F);
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1});
            this.DetailReport.DataMember = "TestsList.FK_TestPrices_TestsList";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Level = 3;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail1.HeightF = 25F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(110.4167F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(651.0416F, 25F);
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBorders = false;
            this.xrTableRow1.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.FK_TestPrices_TestsList.UnitName")});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Weight = 0.30989015821614896D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.FK_TestPrices_TestsList.DefaultPrice")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Weight = 0.0743794589257129D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.FK_TestPrices_TestsList.MinimumPrice")});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Weight = 0.071665734586234084D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine5,
            this.xrTable2});
            this.GroupHeader1.HeightF = 57.53676F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(2.875032F, 9.999989F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(838F, 2F);
            // 
            // xrTable2
            // 
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(110.4167F, 32.53674F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(651.0416F, 25F);
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 11.5D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.Text = "Unit";
            this.xrTableCell4.Weight = 0.30989015821614896D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.Text = "Default Price";
            this.xrTableCell5.Weight = 0.0743794589257129D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.Text = "Minimum Price";
            this.xrTableCell6.Weight = 0.071665734586234084D;
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2,
            this.GroupHeader2});
            this.DetailReport1.DataMember = "TestsList.TestsListTestItems";
            this.DetailReport1.DataSource = this.sqlDataSource1;
            this.DetailReport1.Level = 4;
            this.DetailReport1.Name = "DetailReport1";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.Detail2.HeightF = 29.16667F;
            this.Detail2.Name = "Detail2";
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(110.4167F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(651.0416F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseTextAlignment = false;
            this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 11.5D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.TestsListTestItems.ItemName")});
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Weight = 0.24235486300179698D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.TestsListTestItems.Unit")});
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Weight = 0.11870718774371006D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.TestsListTestItems.Qty")});
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Weight = 0.12661284150014712D;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrLine4});
            this.GroupHeader2.HeightF = 52.18135F;
            this.GroupHeader2.KeepTogether = true;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(110.4167F, 27.18135F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(651.0416F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 11.5D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Material Name";
            this.xrTableCell7.Weight = 0.24235486300179698D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Unit Of Measure";
            this.xrTableCell8.Weight = 0.11870718774371006D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Qty";
            this.xrTableCell9.Weight = 0.12661284150014712D;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2});
            this.PageHeader.HeightF = 59.65512F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(92.70834F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(638F, 33F);
            this.xrLabel2.StyleName = "Title";
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Service Information";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // DetailReport2
            // 
            this.DetailReport2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail3,
            this.GroupHeader3});
            this.DetailReport2.DataMember = "TestsList.FK_TestEquipments_TestsList";
            this.DetailReport2.DataSource = this.sqlDataSource1;
            this.DetailReport2.Level = 0;
            this.DetailReport2.Name = "DetailReport2";
            // 
            // Detail3
            // 
            this.Detail3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10});
            this.Detail3.HeightF = 27.52102F;
            this.Detail3.Name = "Detail3";
            // 
            // xrLabel10
            // 
            this.xrLabel10.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.FK_TestEquipments_TestsList.EquipmentName")});
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(220.5598F, 6.075659F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(160.2317F, 21.44536F);
            this.xrLabel10.StylePriority.UseBorders = false;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel28});
            this.GroupHeader3.HeightF = 29.62186F;
            this.GroupHeader3.Name = "GroupHeader3";
            this.GroupHeader3.StylePriority.UseBorders = false;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(11.76828F, 2.924398F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(160.2317F, 23F);
            this.xrLabel28.StylePriority.UseBorders = false;
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Equipment List:";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // DetailReport3
            // 
            this.DetailReport3.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail4,
            this.GroupHeader4});
            this.DetailReport3.DataMember = "TestsList.FK_TestContractors_TestsList";
            this.DetailReport3.DataSource = this.sqlDataSource1;
            this.DetailReport3.Level = 1;
            this.DetailReport3.Name = "DetailReport3";
            // 
            // Detail4
            // 
            this.Detail4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel24});
            this.Detail4.HeightF = 28.57145F;
            this.Detail4.Name = "Detail4";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestsList.FK_TestContractors_TestsList.SubContractorName")});
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(220.5598F, 5.571445F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(160.2317F, 23F);
            this.xrLabel24.StylePriority.UseBorders = false;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel41});
            this.GroupHeader4.HeightF = 28.57144F;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // xrLabel41
            // 
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(11.76828F, 0F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(200.2318F, 23F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "Recommended Subcontractor:";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // DetailReport5
            // 
            this.DetailReport5.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail6});
            this.DetailReport5.Level = 2;
            this.DetailReport5.Name = "DetailReport5";
            // 
            // Detail6
            // 
            this.Detail6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel39,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel22,
            this.xrLabel40,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLine2});
            this.Detail6.HeightF = 83.19329F;
            this.Detail6.Name = "Detail6";
            // 
            // FilterExpression
            // 
            this.FilterExpression.Description = "FilterExpression";
            this.FilterExpression.Name = "FilterExpression";
            // 
            // Id
            // 
            this.Id.Description = "Id";
            dynamicListLookUpSettings1.DataMember = "TestsList";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "TestName";
            dynamicListLookUpSettings1.FilterString = null;
            dynamicListLookUpSettings1.ValueMember = "TestID";
            this.Id.LookUpSettings = dynamicListLookUpSettings1;
            this.Id.Name = "Id";
            this.Id.Type = typeof(int);
            this.Id.ValueInfo = "0";
            // 
            // ServiceInformationReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.DetailReport,
            this.DetailReport1,
            this.PageHeader,
            this.DetailReport2,
            this.DetailReport3,
            this.DetailReport5});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "TestsList";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[TestID] = ?Id";
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 8, 9);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FilterExpression,
            this.Id});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		// Token: 0x04000AE8 RID: 2792
		private IContainer components;

		// Token: 0x04000AE9 RID: 2793
		private DetailBand Detail;

		// Token: 0x04000AEA RID: 2794
		private TopMarginBand TopMargin;

		// Token: 0x04000AEB RID: 2795
		private BottomMarginBand BottomMargin;

		// Token: 0x04000AEC RID: 2796
		private XRLabel xrLabel1;

		// Token: 0x04000AED RID: 2797
		private XRLabel xrLabel3;

		// Token: 0x04000AEE RID: 2798
		private XRLabel xrLabel4;

		// Token: 0x04000AEF RID: 2799
		private XRLabel xrLabel5;

		// Token: 0x04000AF0 RID: 2800
		private XRLabel xrLabel6;

		// Token: 0x04000AF1 RID: 2801
		private XRLabel xrLabel7;

		// Token: 0x04000AF2 RID: 2802
		private XRLabel xrLabel8;

		// Token: 0x04000AF3 RID: 2803
		private XRLabel xrLabel9;

		// Token: 0x04000AF4 RID: 2804
		private XRLabel xrLabel11;

		// Token: 0x04000AF5 RID: 2805
		private XRLabel xrLabel12;

		// Token: 0x04000AF6 RID: 2806
		private XRLabel xrLabel13;

		// Token: 0x04000AF7 RID: 2807
		private XRLabel xrLabel14;

		// Token: 0x04000AF8 RID: 2808
		private XRLabel xrLabel15;

		// Token: 0x04000AF9 RID: 2809
		private XRLabel xrLabel16;

		// Token: 0x04000AFA RID: 2810
		private XRLabel xrLabel17;

		// Token: 0x04000AFB RID: 2811
		private XRLabel xrLabel18;

		// Token: 0x04000AFC RID: 2812
		private XRLabel xrLabel19;

		// Token: 0x04000AFD RID: 2813
		private XRLabel xrLabel20;

		// Token: 0x04000AFE RID: 2814
		private XRLabel xrLabel21;

		// Token: 0x04000AFF RID: 2815
		private XRLabel xrLabel22;

		// Token: 0x04000B00 RID: 2816
		private XRLabel xrLabel23;

		// Token: 0x04000B01 RID: 2817
		private XRLabel xrLabel25;

		// Token: 0x04000B02 RID: 2818
		private XRLabel xrLabel26;

		// Token: 0x04000B03 RID: 2819
		private XRLabel xrLabel27;

		// Token: 0x04000B04 RID: 2820
		private XRCheckBox xrCheckBox1;

		// Token: 0x04000B05 RID: 2821
		private XRCheckBox xrCheckBox2;

		// Token: 0x04000B06 RID: 2822
		private XRCheckBox xrCheckBox3;

		// Token: 0x04000B07 RID: 2823
		private XRCheckBox xrCheckBox4;

		// Token: 0x04000B08 RID: 2824
		private XRLabel xrLabel29;

		// Token: 0x04000B09 RID: 2825
		private XRLabel xrLabel30;

		// Token: 0x04000B0A RID: 2826
		private XRLabel xrLabel31;

		// Token: 0x04000B0B RID: 2827
		private XRLabel xrLabel32;

		// Token: 0x04000B0C RID: 2828
		private XRLabel xrLabel33;

		// Token: 0x04000B0D RID: 2829
		private XRLabel xrLabel34;

		// Token: 0x04000B0E RID: 2830
		private XRLabel xrLabel35;

		// Token: 0x04000B0F RID: 2831
		private XRLabel xrLabel36;

		// Token: 0x04000B10 RID: 2832
		private XRLabel xrLabel37;

		// Token: 0x04000B11 RID: 2833
		private XRLabel xrLabel38;

		// Token: 0x04000B12 RID: 2834
		private XRLabel xrLabel39;

		// Token: 0x04000B13 RID: 2835
		private XRLabel xrLabel40;

		// Token: 0x04000B14 RID: 2836
		private XRLine xrLine1;

		// Token: 0x04000B15 RID: 2837
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000B16 RID: 2838
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000B17 RID: 2839
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000B18 RID: 2840
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000B19 RID: 2841
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000B1A RID: 2842
		private XRControlStyle Title;

		// Token: 0x04000B1B RID: 2843
		private XRControlStyle FieldCaption;

		// Token: 0x04000B1C RID: 2844
		private XRControlStyle PageInfo;

		// Token: 0x04000B1D RID: 2845
		private XRControlStyle DataField;

		// Token: 0x04000B1E RID: 2846
		private XRLine xrLine4;

		// Token: 0x04000B1F RID: 2847
		private XRLine xrLine3;

		// Token: 0x04000B20 RID: 2848
		private XRLine xrLine2;

		// Token: 0x04000B21 RID: 2849
		private DetailReportBand DetailReport;

		// Token: 0x04000B22 RID: 2850
		private DetailBand Detail1;

		// Token: 0x04000B23 RID: 2851
		private GroupHeaderBand GroupHeader1;

		// Token: 0x04000B24 RID: 2852
		private DetailReportBand DetailReport1;

		// Token: 0x04000B25 RID: 2853
		private DetailBand Detail2;

		// Token: 0x04000B26 RID: 2854
		private GroupHeaderBand GroupHeader2;

		// Token: 0x04000B27 RID: 2855
		private XRTable xrTable1;

		// Token: 0x04000B28 RID: 2856
		private XRTableRow xrTableRow1;

		// Token: 0x04000B29 RID: 2857
		private XRTableCell xrTableCell1;

		// Token: 0x04000B2A RID: 2858
		private XRTableCell xrTableCell2;

		// Token: 0x04000B2B RID: 2859
		private XRTableCell xrTableCell3;

		// Token: 0x04000B2C RID: 2860
		private PageHeaderBand PageHeader;

		// Token: 0x04000B2D RID: 2861
		private XRLabel xrLabel2;

		// Token: 0x04000B2E RID: 2862
		private DetailReportBand DetailReport2;

		// Token: 0x04000B2F RID: 2863
		private DetailBand Detail3;

		// Token: 0x04000B30 RID: 2864
		private XRLabel xrLabel10;

		// Token: 0x04000B31 RID: 2865
		private GroupHeaderBand GroupHeader3;

		// Token: 0x04000B32 RID: 2866
		private XRLabel xrLabel28;

		// Token: 0x04000B33 RID: 2867
		private DetailReportBand DetailReport3;

		// Token: 0x04000B34 RID: 2868
		private DetailBand Detail4;

		// Token: 0x04000B35 RID: 2869
		private XRLabel xrLabel24;

		// Token: 0x04000B36 RID: 2870
		private GroupHeaderBand GroupHeader4;

		// Token: 0x04000B37 RID: 2871
		private XRLabel xrLabel41;

		// Token: 0x04000B38 RID: 2872
		private DetailReportBand DetailReport5;

		// Token: 0x04000B39 RID: 2873
		private DetailBand Detail6;

		// Token: 0x04000B3A RID: 2874
		private XRLine xrLine5;

		// Token: 0x04000B3B RID: 2875
		private XRTable xrTable2;

		// Token: 0x04000B3C RID: 2876
		private XRTableRow xrTableRow2;

		// Token: 0x04000B3D RID: 2877
		private XRTableCell xrTableCell4;

		// Token: 0x04000B3E RID: 2878
		private XRTableCell xrTableCell5;

		// Token: 0x04000B3F RID: 2879
		private XRTableCell xrTableCell6;

		// Token: 0x04000B40 RID: 2880
		private XRTable xrTable4;

		// Token: 0x04000B41 RID: 2881
		private XRTableRow xrTableRow4;

		// Token: 0x04000B42 RID: 2882
		private XRTableCell xrTableCell10;

		// Token: 0x04000B43 RID: 2883
		private XRTableCell xrTableCell11;

		// Token: 0x04000B44 RID: 2884
		private XRTableCell xrTableCell12;

		// Token: 0x04000B45 RID: 2885
		private XRTable xrTable3;

		// Token: 0x04000B46 RID: 2886
		private XRTableRow xrTableRow3;

		// Token: 0x04000B47 RID: 2887
		private XRTableCell xrTableCell7;

		// Token: 0x04000B48 RID: 2888
		private XRTableCell xrTableCell8;

		// Token: 0x04000B49 RID: 2889
		private XRTableCell xrTableCell9;

		// Token: 0x04000B4A RID: 2890
		private Parameter FilterExpression;

		// Token: 0x04000B4B RID: 2891
		private Parameter Id;

		// Token: 0x04000B4C RID: 2892
		private XRPictureBox xrPictureBox2;
	}
}
