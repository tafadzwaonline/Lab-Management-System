using DevExpress.DataAccess;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;

namespace PioneerLab.Reports
{
	public class AccreditionList : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private SqlDataSource sqlDataSource1;

		private PageFooterBand pageFooterBand1;

		private XRPageInfo xrPageInfo1;

		private XRPageInfo xrPageInfo2;

		private XRControlStyle Title;

		private XRControlStyle FieldCaption;

		private XRControlStyle PageInfo;

		private XRControlStyle DataField;

		private GroupHeaderBand GroupHeader1;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell2;

		private XRTableCell xrTableCell3;

		private XRTableCell xrTableCell4;

		private XRTable xrTable2;

		private XRTableRow xrTableRow2;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell5;

		private XRTableCell xrTableCell6;

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

		private XRPictureBox xrPictureBox2;

		private PageHeaderBand PageHeader;

		private XRLabel xrLabel26;

		public AccreditionList()
		{
			this.InitializeComponent();
			this.BeforePrint += new PrintEventHandler(this.Employees_BeforePrint);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Employees_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AccreditionList));
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			this.Detail = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
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
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.pageFooterBand1 = new PageFooterBand();
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo2 = new XRPageInfo();
			this.xrPageInfo1 = new XRPageInfo();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.FilterExpression = new Parameter();
			this.PageHeader = new PageHeaderBand();
			this.xrLabel26 = new XRLabel();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.Detail.Controls.AddRange(new XRControl[] { this.xrTable1 });
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25.00001f;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.StyleName = "DataField";
			this.Detail.StylePriority.UseBorders = false;
			this.Detail.StylePriority.UseTextAlignment = false;
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.LocationFloat = new PointFloat(60.75595f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Rows.AddRange(new XRTableRow[] { this.xrTableRow1 });
			this.xrTable1.SizeF = new System.Drawing.SizeF(648.0834f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection cells = this.xrTableRow1.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell2, this.xrTableCell3, this.xrTableCell4 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			XRBindingCollection dataBindings = this.xrTableCell2.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "AccreditionList.AccreditionName") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "xrTableCell2";
			this.xrTableCell2.Weight = 0.525758230983274;
			XRBindingCollection xRBindingCollections = this.xrTableCell3.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "AccreditionList.Remarks") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Weight = 0.56438008579171;
			XRBindingCollection dataBindings1 = this.xrTableCell4.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "AccreditionList.Column4") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Weight = 0.236194834574085;
			XRControlCollection controls = this.TopMargin.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrLine2, this.xrLabel7, this.xrLabel3, this.xrPictureBox1, this.xrLabel8, this.xrLabel4, this.xrLabel5, this.xrLine1, this.xrLabel2 };
			controls.AddRange(xRControlArrays);
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 129f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(540.1331f, 93.52082f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new System.Drawing.SizeF(300.4026f, 23f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(565.4379f, 65.56252f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel7.SizeF = new System.Drawing.SizeF(249.9936f, 22.99997f);
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
			this.xrLabel3.LocationFloat = new PointFloat(565.4379f, 11.56251f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(249.9937f, 23.99999f);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)componentResourceManager.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(340.5699f, 11.5625f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new System.Drawing.SizeF(189.2164f, 108.125f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(565.4379f, 37.52084f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(249.9937f, 22.99997f);
			this.xrLabel8.StylePriority.UseBackColor = false;
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.StylePriority.UsePadding = false;
			this.xrLabel8.StylePriority.UseTextAlignment = false;
			this.xrLabel8.Text = "تربة - اسفلت - حصي - كوتكريت - اسمنت - ماء";
			this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrLabel4.BackColor = Color.White;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel4.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel4.LocationFloat = new PointFloat(3.464294f, 35.56251f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(310.5137f, 25f);
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
			this.xrLabel5.LocationFloat = new PointFloat(3.464294f, 60.56251f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(288.8611f, 24f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(4.326614f, 93.52082f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new System.Drawing.SizeF(300.4026f, 23f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(3.464294f, 11.5625f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(285.9722f, 24f);
			this.xrLabel2.StylePriority.UseBackColor = false;
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.StylePriority.UsePadding = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 0f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "AccreditionList";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { customSqlQuery });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			XRControlCollection xRControlCollection = this.pageFooterBand1.Controls;
			XRControl[] xRControlArrays1 = new XRControl[] { this.xrPictureBox2, this.xrPageInfo2, this.xrPageInfo1 };
			xRControlCollection.AddRange(xRControlArrays1);
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 131.5f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)componentResourceManager.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(104.0369f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new System.Drawing.SizeF(581.3381f, 74.20829f);
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(521f, 108.5f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(4.326614f, 108.5f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
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
			this.GroupHeader1.Controls.AddRange(new XRControl[] { this.xrTable2 });
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.GroupHeader1.StylePriority.UseBorders = false;
			this.xrTable2.BackColor = Color.Gainsboro;
			this.xrTable2.Borders = BorderSide.All;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12f, FontStyle.Bold);
			this.xrTable2.LocationFloat = new PointFloat(60.75595f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new XRTableRow[] { this.xrTableRow2 });
			this.xrTable2.SizeF = new System.Drawing.SizeF(648.0834f, 25f);
			this.xrTable2.StylePriority.UseBackColor = false;
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UseTextAlignment = false;
			this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow2.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell1, this.xrTableCell5, this.xrTableCell6 };
			xRTableCellCollections.AddRange(xRTableCellArray1);
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "Accredition Name";
			this.xrTableCell1.Weight = 0.525758230983274;
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Text = "Remarks";
			this.xrTableCell5.Weight = 0.56438008579171;
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Text = "Inactive";
			this.xrTableCell6.Weight = 0.236194834574085;
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.PageHeader.Controls.AddRange(new XRControl[] { this.xrLabel26 });
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 69.79166f;
			this.PageHeader.Name = "PageHeader";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(100f, 12.5f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Accredition Status";
			this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			BandCollection bands = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.pageFooterBand1, this.GroupHeader1, this.PageHeader };
			bands.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "AccreditionList";
			base.DataSource = this.sqlDataSource1;
			base.Margins = new System.Drawing.Printing.Margins(0, 0, 129, 0);
			base.Parameters.AddRange(new Parameter[] { this.FilterExpression });
			XRControlStyleSheet styleSheet = base.StyleSheet;
			XRControlStyle[] title = new XRControlStyle[] { this.Title, this.FieldCaption, this.PageInfo, this.DataField };
			styleSheet.AddRange(title);
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this).EndInit();
		}
	}
}