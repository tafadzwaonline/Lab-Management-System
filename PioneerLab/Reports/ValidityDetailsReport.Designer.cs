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
	public class ValidityDetailsReport : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private SqlDataSource sqlDataSource1;

		private PageFooterBand pageFooterBand1;

		private ReportHeaderBand reportHeaderBand1;

		private XRControlStyle Title;

		private XRControlStyle FieldCaption;

		private XRControlStyle PageInfo;

		private XRControlStyle DataField;

		private DetailReportBand DetailReport;

		private DetailBand Detail1;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell2;

		private XRTableCell xrTableCell3;

		private XRTableCell xrTableCell4;

		private XRTableCell xrTableCell5;

		private XRTableCell xrTableCell6;

		private XRTableCell xrTableCell7;

		private GroupHeaderBand GroupHeader1;

		private XRTableCell xrTableCell9;

		private XRTable xrTable4;

		private XRTableRow xrTableRow4;

		private XRTableCell xrTableCell8;

		private XRTableCell xrTableCell18;

		private XRTableCell xrTableCell19;

		private XRTableCell xrTableCell20;

		private XRTableCell xrTableCell21;

		private XRTableCell xrTableCell22;

		private XRTableCell xrTableCell23;

		private XRTableCell xrTableCell25;

		private XRLabel xrLabel26;

		private PageHeaderBand PageHeader;

		private Parameter ValidityID;

		private Parameter FilterExpression;

		private XRTableCell xrTableCell12;

		private XRTableCell xrTableCell13;

		private XRTableCell xrTableCell10;

		private XRTableCell xrTableCell11;

		private XRLabel xrLabel10;

		private XRLabel xrLabel6;

		private XRLabel xrLabel5;

		public ValidityDetailsReport()
		{
			this.InitializeComponent();
			this.BeforePrint += new PrintEventHandler(this.ValidityDetailsReport_BeforePrint);
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
			Table table1 = new Table();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ValidityDetailsReport));
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo1 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSetting = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.pageFooterBand1 = new PageFooterBand();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable4 = new XRTable();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell23 = new XRTableCell();
			this.xrTableCell25 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrLabel26 = new XRLabel();
			this.PageHeader = new PageHeaderBand();
			this.ValidityID = new Parameter();
			this.FilterExpression = new Parameter();
			this.xrLabel10 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "ValidityID";
			table.MetaSerializable = "30|30|125|140";
			table.Name = "ValidityList";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression1.ColumnName = "ValidityCode";
			columnExpression1.Table = table;
			column1.Expression = columnExpression1;
			columnExpression2.ColumnName = "ValidityName";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "FKLabID";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "IsLocked";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "LabName";
			table1.MetaSerializable = "185|30|125|140";
			table1.Name = "LabsList";
			columnExpression5.Table = table1;
			column5.Expression = columnExpression5;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column1);
			selectQuery.Columns.Add(column2);
			selectQuery.Columns.Add(column3);
			selectQuery.Columns.Add(column4);
			selectQuery.Columns.Add(column5);
			selectQuery.Name = "ValidityList";
			relationColumnInfo.NestedKeyColumn = "LabID";
			relationColumnInfo.ParentKeyColumn = "FKLabID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table1;
			join.Parent = table;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table1);
			customSqlQuery.Name = "ValidityListDetails";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { selectQuery, customSqlQuery });
			masterDetailInfo.DetailQueryName = "ValidityListDetails";
			relationColumnInfo1.NestedKeyColumn = "FKValidityID";
			relationColumnInfo1.ParentKeyColumn = "ValidityID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo1);
			masterDetailInfo.MasterQueryName = "ValidityList";
			masterDetailInfo.Name = "FK_ValidityListDetails_ValidityList";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[] { masterDetailInfo });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			XRControlCollection controls = this.Detail.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrLabel10, this.xrLabel6, this.xrLabel5, this.xrLabel26 };
			controls.AddRange(xRControlArrays);
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 108f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 23.75f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 3.458405f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 0.8749326f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 2.541669f;
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
			this.DetailReport.DataMember = "ValidityList.FK_ValidityListDetails_ValidityList";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[] { this.xrTable1 });
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 10f);
			this.xrTable1.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(0, 0, 3, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[] { this.xrTableRow1 });
			this.xrTable1.SizeF = new System.Drawing.SizeF(1088f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection cells = this.xrTableRow1.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell1, this.xrTableCell2, this.xrTableCell3, this.xrTableCell4, this.xrTableCell5, this.xrTableCell6, this.xrTableCell7, this.xrTableCell9, this.xrTableCell12, this.xrTableCell13 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			XRBindingCollection dataBindings = this.xrTableCell1.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.CertificateName") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "xrTableCell1";
			this.xrTableCell1.Weight = 0.359674433712488;
			XRBindingCollection xRBindingCollections = this.xrTableCell2.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.CertificateSerialNumber") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "xrTableCell2";
			this.xrTableCell2.Weight = 0.172264040134855;
			XRBindingCollection dataBindings1 = this.xrTableCell3.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.IDNumber") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Weight = 0.153708008817917;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell4.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.EnteredBy") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Weight = 0.128991696630998;
			XRBindingCollection dataBindings2 = this.xrTableCell5.DataBindings;
			XRBinding[] xRBinding2 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.EntryDate", "{0:dd/MM/yyyy}") };
			dataBindings2.AddRange(xRBinding2);
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Weight = 0.13126928467681;
			XRBindingCollection xRBindingCollections2 = this.xrTableCell6.DataBindings;
			XRBinding[] xRBindingArray2 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.ExpiryDate", "{0:dd/MM/yyyy}") };
			xRBindingCollections2.AddRange(xRBindingArray2);
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Weight = 0.151059109121169;
			XRBindingCollection dataBindings3 = this.xrTableCell7.DataBindings;
			XRBinding[] xRBinding3 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.Responsible") };
			dataBindings3.AddRange(xRBinding3);
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "xrTableCell7";
			this.xrTableCell7.Weight = 0.180921126875295;
			XRBindingCollection xRBindingCollections3 = this.xrTableCell9.DataBindings;
			XRBinding[] xRBindingArray3 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.CalibratedBy") };
			xRBindingCollections3.AddRange(xRBindingArray3);
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Weight = 0.14869005937927;
			XRBindingCollection dataBindings4 = this.xrTableCell12.DataBindings;
			XRBinding[] xRBinding4 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.Status") };
			dataBindings4.AddRange(xRBinding4);
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Weight = 0.0922043211615498;
			XRBindingCollection xRBindingCollections4 = this.xrTableCell13.DataBindings;
			XRBinding[] xRBindingArray4 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.Remarks") };
			xRBindingCollections4.AddRange(xRBindingArray4);
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Weight = 0.321308634863979;
			this.GroupHeader1.Controls.AddRange(new XRControl[] { this.xrTable4 });
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable4.BackColor = Color.LightGray;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrTable4.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Rows.AddRange(new XRTableRow[] { this.xrTableRow4 });
			this.xrTable4.SizeF = new System.Drawing.SizeF(1088f, 25f);
			this.xrTable4.StylePriority.UseBackColor = false;
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow4.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell8, this.xrTableCell18, this.xrTableCell19, this.xrTableCell20, this.xrTableCell21, this.xrTableCell22, this.xrTableCell23, this.xrTableCell25, this.xrTableCell10, this.xrTableCell11 };
			xRTableCellCollections.AddRange(xRTableCellArray1);
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 11.5;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Certificate Name";
			this.xrTableCell8.Weight = 0.398593148920395;
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "Certificate Sr no";
			this.xrTableCell18.Weight = 0.190903915836067;
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Text = "Equiment Sr no";
			this.xrTableCell19.Weight = 0.170339895223007;
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Text = "Entered By";
			this.xrTableCell20.Weight = 0.142949398779283;
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Text = "Entry Date";
			this.xrTableCell21.Weight = 0.145473306776023;
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Text = "Expiry Date";
			this.xrTableCell22.Weight = 0.167404505400494;
			this.xrTableCell23.Dpi = 100f;
			this.xrTableCell23.Name = "xrTableCell23";
			this.xrTableCell23.Text = "Responsible";
			this.xrTableCell23.Weight = 0.200497756408139;
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.Text = "Calibrated By";
			this.xrTableCell25.Weight = 0.164779117287807;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Status";
			this.xrTableCell10.Weight = 0.102181312511835;
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "Remarks";
			this.xrTableCell11.Weight = 0.356075856794119;
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(185.2082f, 10.00001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Validity List Details";
			this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 1.749992f;
			this.PageHeader.Name = "PageHeader";
			this.ValidityID.Description = "ValidityID";
			dynamicListLookUpSetting.DataAdapter = null;
			dynamicListLookUpSetting.DataMember = "ValidityList";
			dynamicListLookUpSetting.DataSource = this.sqlDataSource1;
			dynamicListLookUpSetting.DisplayMember = "ValidityName";
			dynamicListLookUpSetting.FilterString = null;
			dynamicListLookUpSetting.ValueMember = "ValidityID";
			this.ValidityID.LookUpSettings = dynamicListLookUpSetting;
			this.ValidityID.Name = "ValidityID";
			this.ValidityID.Type = typeof(int);
			this.ValidityID.ValueInfo = "0";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel10.LocationFloat = new PointFloat(333.6316f, 64.99999f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new System.Drawing.SizeF(29.70132f, 33f);
			this.xrLabel10.StyleName = "Title";
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "-";
			this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRBindingCollection dataBindings5 = this.xrLabel6.DataBindings;
			XRBinding[] xRBinding5 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.ValidityName") };
			dataBindings5.AddRange(xRBinding5);
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel6.LocationFloat = new PointFloat(358.7705f, 64.99999f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new System.Drawing.SizeF(464.4378f, 33.00001f);
			this.xrLabel6.StyleName = "Title";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			XRBindingCollection xRBindingCollections5 = this.xrLabel5.DataBindings;
			XRBinding[] xRBindingArray5 = new XRBinding[] { new XRBinding("Text", null, "ValidityList.ValidityCode") };
			xRBindingCollections5.AddRange(xRBindingArray5);
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel5.LocationFloat = new PointFloat(291.4584f, 65.00002f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(42.17325f, 32.99998f);
			this.xrLabel5.StyleName = "Title";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			BandCollection bandCollections = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.pageFooterBand1, this.reportHeaderBand1, this.DetailReport, this.PageHeader };
			bandCollections.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "ValidityList";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[ValidityID] = ?ValidityID";
			base.Landscape = true;
			base.Margins = new System.Drawing.Printing.Margins(0, 2, 24, 3);
			base.PageHeight = 850;
			base.PageWidth = 1100;
			ParameterCollection parameters = base.Parameters;
			Parameter[] validityID = new Parameter[] { this.ValidityID, this.FilterExpression };
			parameters.AddRange(validityID);
			XRControlStyleSheet styleSheet = base.StyleSheet;
			XRControlStyle[] title = new XRControlStyle[] { this.Title, this.FieldCaption, this.PageInfo, this.DataField };
			styleSheet.AddRange(title);
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		private void ValidityDetailsReport_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
				return;
			}
			if (this.ValidityID.Value.ToString() == "0")
			{
				this.FilterString = "";
			}
		}
	}
}