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
	public class InvoiceList : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private SqlDataSource sqlDataSource1;

		private XRLabel xrLabel29;

		private XRTable xrTable2;

		private XRTableRow xrTableRow2;

		private XRTableCell xrTableCell18;

		private XRTableCell xrTableCell19;

		private XRTableCell xrTableCell20;

		private XRTableCell xrTableCell21;

		private XRPageInfo xrPageInfo2;

		private XRPageInfo xrPageInfo1;

		private XRPictureBox xrPictureBox2;

		private ReportHeaderBand ReportHeader;

		private PageHeaderBand PageHeader;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell2;

		private XRTableCell xrTableCell3;

		private XRTableCell xrTableCell4;

		private Parameter FilterExpression;

		private XRLine xrLine2;

		private XRLabel xrLabel7;

		private XRLabel xrLabel3;

		private XRPictureBox xrPictureBox1;

		private XRLabel xrLabel8;

		private XRLabel xrLabel4;

		private XRLabel xrLabel5;

		private XRLine xrLine1;

		private XRLabel xrLabel2;

		public InvoiceList()
		{
			this.InitializeComponent();
			this.BeforePrint += new PrintEventHandler(this.InvoiceList_BeforePrint);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InvoiceList));
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
			Table table1 = new Table();
			Column column4 = new Column();
			ColumnExpression columnExpression4 = new ColumnExpression();
			Column column5 = new Column();
			ColumnExpression columnExpression5 = new ColumnExpression();
			Column column6 = new Column();
			ColumnExpression columnExpression6 = new ColumnExpression();
			Column column7 = new Column();
			ColumnExpression columnExpression7 = new ColumnExpression();
			Column column8 = new Column();
			ColumnExpression columnExpression8 = new ColumnExpression();
			Column column9 = new Column();
			ColumnExpression columnExpression9 = new ColumnExpression();
			Column column10 = new Column();
			ColumnExpression columnExpression10 = new ColumnExpression();
			Column column11 = new Column();
			ColumnExpression columnExpression11 = new ColumnExpression();
			Column column12 = new Column();
			ColumnExpression columnExpression12 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			this.Detail = new DetailBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.TopMargin = new TopMarginBand();
			this.xrLine2 = new XRLine();
			this.xrLabel7 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel8 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel2 = new XRLabel();
			this.BottomMargin = new BottomMarginBand();
			this.xrPageInfo2 = new XRPageInfo();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPictureBox2 = new XRPictureBox();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.xrLabel29 = new XRLabel();
			this.ReportHeader = new ReportHeaderBand();
			this.PageHeader = new PageHeaderBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.FilterExpression = new Parameter();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.Detail.Controls.AddRange(new XRControl[] { this.xrTable2 });
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25f;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTable2.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.LocationFloat = new PointFloat(10f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable2.Rows.AddRange(new XRTableRow[] { this.xrTableRow2 });
			this.xrTable2.SizeF = new System.Drawing.SizeF(785.1666f, 25f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UsePadding = false;
			XRTableCellCollection cells = this.xrTableRow2.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell18, this.xrTableCell19, this.xrTableCell20, this.xrTableCell21 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			XRBindingCollection dataBindings = this.xrTableCell18.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceNumber") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "xrTableCell18";
			this.xrTableCell18.Weight = 0.223749273508465;
			XRBindingCollection xRBindingCollections = this.xrTableCell19.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "Invoice.InvoiceDate", "{0:dd MMM yyyy}") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Weight = 0.223891798808556;
			XRBindingCollection dataBindings1 = this.xrTableCell20.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "Invoice.CustomerName") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Weight = 0.234565313781622;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell21.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "Invoice.NetAmount") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Text = "xrTableCell21";
			this.xrTableCell21.Weight = 0.212933215839324;
			XRControlCollection controls = this.TopMargin.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrLine2, this.xrLabel7, this.xrLabel3, this.xrPictureBox1, this.xrLabel8, this.xrLabel4, this.xrLabel5, this.xrLine1, this.xrLabel2 };
			controls.AddRange(xRControlArrays);
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(528.7581f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new System.Drawing.SizeF(282.2419f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(554.0629f, 71.52087f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel7.SizeF = new System.Drawing.SizeF(231.8328f, 22.99997f);
			this.xrLabel7.StylePriority.UseBackColor = false;
			this.xrLabel7.StylePriority.UseFont = false;
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.StylePriority.UsePadding = false;
			this.xrLabel7.StylePriority.UseTextAlignment = false;
			this.xrLabel7.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrLabel3.BackColor = Color.White;
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel3.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel3.LocationFloat = new PointFloat(554.0629f, 17.52084f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(231.833f, 24f);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)componentResourceManager.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(329.1949f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new System.Drawing.SizeF(171.0558f, 94.95831f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(554.0629f, 43.47919f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(231.833f, 22.99997f);
			this.xrLabel8.StylePriority.UseBackColor = false;
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.StylePriority.UsePadding = false;
			this.xrLabel8.StylePriority.UseTextAlignment = false;
			this.xrLabel8.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrLabel4.BackColor = Color.White;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel4.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel4.LocationFloat = new PointFloat(0.1250029f, 41.52085f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(292.3529f, 25f);
			this.xrLabel4.StylePriority.UseBackColor = false;
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.StylePriority.UsePadding = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLabel5.BackColor = Color.White;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel5.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel5.LocationFloat = new PointFloat(0.1250029f, 66.52085f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(270.7004f, 24f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(0.1250029f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new System.Drawing.SizeF(282.2419f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(0.1250029f, 17.52084f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(267.8115f, 24f);
			this.xrLabel2.StylePriority.UseBackColor = false;
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.StylePriority.UsePadding = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			XRControlCollection xRControlCollection = this.BottomMargin.Controls;
			XRControl[] xRControlArrays1 = new XRControl[] { this.xrPageInfo2, this.xrPageInfo1, this.xrPictureBox2 };
			xRControlCollection.AddRange(xRControlArrays1);
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 153f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(457.6012f, 114.9375f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(6.732147f, 114.9375f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)componentResourceManager.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(136.3154f, 15.18753f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new System.Drawing.SizeF(581.3381f, 74.20829f);
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "CustomerID";
			table.MetaSerializable = "185|30|125|300";
			table.Name = "CustomersList";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression1.ColumnName = "CustomerCode";
			columnExpression1.Table = table;
			column1.Expression = columnExpression1;
			columnExpression2.ColumnName = "CustomerName";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "InvoiceId";
			table1.MetaSerializable = "30|30|125|240";
			table1.Name = "Invoice";
			columnExpression3.Table = table1;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "InvoiceNumber";
			columnExpression4.Table = table1;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "InvoiceDate";
			columnExpression5.Table = table1;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "InvoiceRefNo";
			columnExpression6.Table = table1;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "FkCustomerId";
			columnExpression7.Table = table1;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "SRTTotal";
			columnExpression8.Table = table1;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "TSTotal";
			columnExpression9.Table = table1;
			column9.Expression = columnExpression9;
			columnExpression10.ColumnName = "InvoiceTotal";
			columnExpression10.Table = table1;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "Disount";
			columnExpression11.Table = table1;
			column11.Expression = columnExpression11;
			columnExpression12.ColumnName = "NetAmount";
			columnExpression12.Table = table1;
			column12.Expression = columnExpression12;
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
			selectQuery.Columns.Add(column10);
			selectQuery.Columns.Add(column11);
			selectQuery.Columns.Add(column12);
			selectQuery.Name = "Invoice";
			relationColumnInfo.NestedKeyColumn = "CustomerID";
			relationColumnInfo.ParentKeyColumn = "FkCustomerId";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table;
			join.Parent = table1;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table1);
			selectQuery.Tables.Add(table);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { selectQuery });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.xrLabel29.Dpi = 100f;
			this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 20f, FontStyle.Bold);
			this.xrLabel29.ForeColor = Color.Maroon;
			this.xrLabel29.LocationFloat = new PointFloat(44.91666f, 9.083335f);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel29.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel29.StylePriority.UseFont = false;
			this.xrLabel29.StylePriority.UseForeColor = false;
			this.xrLabel29.StylePriority.UseTextAlignment = false;
			this.xrLabel29.Text = "Invoice";
			this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.ReportHeader.Controls.AddRange(new XRControl[] { this.xrLabel29 });
			this.ReportHeader.Dpi = 100f;
			this.ReportHeader.HeightF = 73.95834f;
			this.ReportHeader.Name = "ReportHeader";
			this.PageHeader.Controls.AddRange(new XRControl[] { this.xrTable1 });
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 38.95833f;
			this.PageHeader.Name = "PageHeader";
			this.xrTable1.BackColor = Color.LightGray;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable1.LocationFloat = new PointFloat(10.125f, 13.95833f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(6, 0, 0, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[] { this.xrTableRow1 });
			this.xrTable1.SizeF = new System.Drawing.SizeF(785.0416f, 25f);
			this.xrTable1.StylePriority.UseBackColor = false;
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow1.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell1, this.xrTableCell2, this.xrTableCell3, this.xrTableCell4 };
			xRTableCellCollections.AddRange(xRTableCellArray1);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "Invoice No";
			this.xrTableCell1.Weight = 0.223713646532438;
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "Date";
			this.xrTableCell2.Weight = 0.223713646532438;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Customer";
			this.xrTableCell3.Weight = 0.234670504239268;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "Net Amount";
			this.xrTableCell4.Weight = 0.212756788825609;
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			BandCollection bands = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.ReportHeader, this.PageHeader };
			bands.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "Invoice";
			base.DataSource = this.sqlDataSource1;
			base.Margins = new System.Drawing.Printing.Margins(3, 26, 130, 153);
			base.Parameters.AddRange(new Parameter[] { this.FilterExpression });
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		private void InvoiceList_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
			}
		}
	}
}