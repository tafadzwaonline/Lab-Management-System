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
	public class LabSubcontractor : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private SqlDataSource sqlDataSource1;

		private PageHeaderBand PageHeader;

		private XRLabel xrLabel26;

		private GroupHeaderBand GroupHeader1;

		private ReportFooterBand ReportFooter;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell2;

		private XRTableCell xrTableCell3;

		private XRTableCell xrTableCell4;

		private XRTableCell xrTableCell5;

		private XRTable xrTable2;

		private XRTableRow xrTableRow2;

		private XRTableCell xrTableCell6;

		private XRTableCell xrTableCell7;

		private XRTableCell xrTableCell8;

		private XRTableCell xrTableCell9;

		private XRTableCell xrTableCell10;

		private XRPageInfo xrPageInfo2;

		private XRPageInfo xrPageInfo1;

		private XRPictureBox xrPictureBox2;

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

		public LabSubcontractor()
		{
			this.InitializeComponent();
			this.BeforePrint += new PrintEventHandler(this.LabSubcontractors_BeforePrint);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LabSubcontractor));
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			this.Detail = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
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
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPageInfo2 = new XRPageInfo();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.PageHeader = new PageHeaderBand();
			this.xrLabel26 = new XRLabel();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.ReportFooter = new ReportFooterBand();
			this.FilterExpression = new Parameter();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.Detail.Controls.AddRange(new XRControl[] { this.xrTable1 });
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25f;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Rows.AddRange(new XRTableRow[] { this.xrTableRow1 });
			this.xrTable1.SizeF = new System.Drawing.SizeF(849f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			XRTableCellCollection cells = this.xrTableRow1.Cells;
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell1, this.xrTableCell2, this.xrTableCell3, this.xrTableCell4, this.xrTableCell5 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			XRBindingCollection dataBindings = this.xrTableCell1.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "SubcontractorsList.SubContractorCode") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseTextAlignment = false;
			this.xrTableCell1.Text = "xrTableCell1";
			this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell1.Weight = 0.138879032420757;
			XRBindingCollection xRBindingCollections = this.xrTableCell2.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "SubcontractorsList.SubContractorName") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Padding = new PaddingInfo(4, 0, 0, 0, 100f);
			this.xrTableCell2.StylePriority.UsePadding = false;
			this.xrTableCell2.Text = "xrTableCell2";
			this.xrTableCell2.Weight = 0.358630936887533;
			XRBindingCollection dataBindings1 = this.xrTableCell3.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "SubcontractorsList.AccreditationExpiryDate", "{0:dd MMM yyyy}") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.xrTableCell3.StylePriority.UsePadding = false;
			this.xrTableCell3.StylePriority.UseTextAlignment = false;
			this.xrTableCell3.Text = "xrTableCell3";
			this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell3.Weight = 0.362088884559905;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell4.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "SubcontractorsList.Address") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Padding = new PaddingInfo(4, 0, 0, 0, 100f);
			this.xrTableCell4.StylePriority.UsePadding = false;
			this.xrTableCell4.Text = "xrTableCell4";
			this.xrTableCell4.Weight = 0.407819985360906;
			XRBindingCollection dataBindings2 = this.xrTableCell5.DataBindings;
			XRBinding[] xRBinding2 = new XRBinding[] { new XRBinding("Text", null, "SubcontractorsList.Column7") };
			dataBindings2.AddRange(xRBinding2);
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.StylePriority.UseTextAlignment = false;
			this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrTableCell5.Weight = 0.16524591721789;
			XRControlCollection controls = this.TopMargin.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrLine2, this.xrLabel7, this.xrLabel3, this.xrPictureBox1, this.xrLabel8, this.xrLabel4, this.xrLabel5, this.xrLine1, this.xrLabel2 };
			controls.AddRange(xRControlArrays);
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 152f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(542.6331f, 110.4792f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new System.Drawing.SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(567.9379f, 82.52086f);
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
			this.xrLabel3.LocationFloat = new PointFloat(567.9379f, 28.52084f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(249.9937f, 24f);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)componentResourceManager.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(343.0699f, 28.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new System.Drawing.SizeF(189.2164f, 94.95832f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(567.9379f, 54.47918f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(249.9937f, 22.99997f);
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
			this.xrLabel4.LocationFloat = new PointFloat(5.964294f, 52.52085f);
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
			this.xrLabel5.LocationFloat = new PointFloat(5.964294f, 77.52084f);
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
			this.xrLine1.LocationFloat = new PointFloat(6.826614f, 110.4792f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new System.Drawing.SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(5.964294f, 28.52084f);
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
			XRControlCollection xRControlCollection = this.BottomMargin.Controls;
			XRControl[] xRControlArrays1 = new XRControl[] { this.xrPictureBox2, this.xrPageInfo1, this.xrPageInfo2 };
			xRControlCollection.AddRange(xRControlArrays1);
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 123.7917f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)componentResourceManager.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(114.7459f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new System.Drawing.SizeF(581.3381f, 74.20829f);
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(0f, 100.7917f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(497.2608f, 90.79164f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "SubcontractorsList";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { customSqlQuery });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.PageHeader.Controls.AddRange(new XRControl[] { this.xrLabel26 });
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 63.54167f;
			this.PageHeader.Name = "PageHeader";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 20f, FontStyle.Bold);
			this.xrLabel26.ForeColor = Color.Maroon;
			this.xrLabel26.LocationFloat = new PointFloat(91.66666f, 10.00001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel26.StylePriority.UseFont = false;
			this.xrLabel26.StylePriority.UseForeColor = false;
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Lab Subcontractors";
			this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.GroupHeader1.Controls.AddRange(new XRControl[] { this.xrTable2 });
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable2.Borders = BorderSide.All;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable2.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new XRTableRow[] { this.xrTableRow2 });
			this.xrTable2.SizeF = new System.Drawing.SizeF(849f, 25f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UseTextAlignment = false;
			this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow2.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell6, this.xrTableCell7, this.xrTableCell8, this.xrTableCell9, this.xrTableCell10 };
			xRTableCellCollections.AddRange(xRTableCellArray1);
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Text = "CR#";
			this.xrTableCell6.Weight = 0.138879032420757;
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "Subcontractor Name";
			this.xrTableCell7.Weight = 0.358630936887533;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Accreditation Expiry Date";
			this.xrTableCell8.Weight = 0.362088884559905;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Text = "Location/Address";
			this.xrTableCell9.Weight = 0.407819985360906;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Inactive";
			this.xrTableCell10.Weight = 0.16524591721789;
			this.ReportFooter.Dpi = 100f;
			this.ReportFooter.HeightF = 7.124964f;
			this.ReportFooter.Name = "ReportFooter";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			BandCollection bands = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.PageHeader, this.GroupHeader1, this.ReportFooter };
			bands.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "SubcontractorsList";
			base.DataSource = this.sqlDataSource1;
			base.Margins = new System.Drawing.Printing.Margins(0, 1, 152, 124);
			base.Parameters.AddRange(new Parameter[] { this.FilterExpression });
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		private void LabSubcontractors_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
			}
		}
	}
}