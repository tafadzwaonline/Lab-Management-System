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
	public class ExpiredValidityDetailsReport : XtraReport
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

		private XRLabel xrLabel26;

		private PageHeaderBand PageHeader;

		private XRLabel xrLabel4;

		private GroupHeaderBand GroupHeader2;

		private Parameter Id;

		private XRLabel xrLabel10;

		private XRLabel xrLabel6;

		private XRLabel xrLabel5;

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

		private XRTableCell xrTableCell13;

		private XRTableCell xrTableCell14;

		private XRTable xrTable1;

		private XRTableRow xrTableRow1;

		private XRTableCell xrTableCell1;

		private XRTableCell xrTableCell2;

		private XRTableCell xrTableCell3;

		private XRTableCell xrTableCell4;

		private XRTableCell xrTableCell5;

		private XRTableCell xrTableCell6;

		private XRTableCell xrTableCell7;

		private XRTableCell xrTableCell9;

		private XRTableCell xrTableCell12;

		private XRTableCell xrTableCell10;

		public ExpiredValidityDetailsReport()
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
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ExpiredValidityDetailsReport));
			DynamicListLookUpSettings dynamicListLookUpSetting = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
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
			this.xrTableCell10 = new XRTableCell();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.pageFooterBand1 = new PageFooterBand();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.xrLabel26 = new XRLabel();
			this.PageHeader = new PageHeaderBand();
			this.xrLabel10 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.GroupHeader2 = new GroupHeaderBand();
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
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.Id = new Parameter();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "ValidityListDetails";
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { customSqlQuery });
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[] { this.xrTable1 });
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25f;
			this.Detail.KeepTogether = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
			XRTableCell[] xRTableCellArray = new XRTableCell[] { this.xrTableCell1, this.xrTableCell2, this.xrTableCell3, this.xrTableCell4, this.xrTableCell5, this.xrTableCell6, this.xrTableCell7, this.xrTableCell9, this.xrTableCell12, this.xrTableCell10 };
			cells.AddRange(xRTableCellArray);
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			XRBindingCollection dataBindings = this.xrTableCell1.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.CertificateName") };
			dataBindings.AddRange(xRBinding);
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Weight = 0.359674433712488;
			XRBindingCollection xRBindingCollections = this.xrTableCell2.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.CertificateSerialNumber") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Weight = 0.154646831765166;
			XRBindingCollection dataBindings1 = this.xrTableCell3.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.IDNumber") };
			dataBindings1.AddRange(xRBinding1);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Weight = 0.176459280898204;
			XRBindingCollection xRBindingCollections1 = this.xrTableCell4.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.EnteredBy") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Weight = 0.123857632920401;
			XRBindingCollection dataBindings2 = this.xrTableCell5.DataBindings;
			XRBinding[] xRBinding2 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.EntryDate", "{0:dd/MM/yyyy}") };
			dataBindings2.AddRange(xRBinding2);
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Weight = 0.13126928467681;
			XRBindingCollection xRBindingCollections2 = this.xrTableCell6.DataBindings;
			XRBinding[] xRBindingArray2 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.ExpiryDate", "{0:dd/MM/yyyy}") };
			xRBindingCollections2.AddRange(xRBindingArray2);
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Weight = 0.151059109121169;
			XRBindingCollection dataBindings3 = this.xrTableCell7.DataBindings;
			XRBinding[] xRBinding3 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.Responsible") };
			dataBindings3.AddRange(xRBinding3);
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Weight = 0.180921126875295;
			XRBindingCollection xRBindingCollections3 = this.xrTableCell9.DataBindings;
			XRBinding[] xRBindingArray3 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.CalibratedBy") };
			xRBindingCollections3.AddRange(xRBindingArray3);
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Weight = 0.14869005937927;
			XRBindingCollection dataBindings4 = this.xrTableCell12.DataBindings;
			XRBinding[] xRBinding4 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.Status") };
			dataBindings4.AddRange(xRBinding4);
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Weight = 0.0922043211615498;
			XRBindingCollection xRBindingCollections4 = this.xrTableCell10.DataBindings;
			XRBinding[] xRBindingArray4 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.Remarks") };
			xRBindingCollections4.AddRange(xRBindingArray4);
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Weight = 0.321308634863979;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 22.89581f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 0f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 0f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 4.625002f;
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
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(260.0182f, 0f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Validity List Details";
			this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRControlCollection controls = this.PageHeader.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrLabel10, this.xrLabel6, this.xrLabel5, this.xrLabel4, this.xrLabel26 };
			controls.AddRange(xRControlArrays);
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 109.0417f;
			this.PageHeader.Name = "PageHeader";
			this.PageHeader.StylePriority.UseTextAlignment = false;
			this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel10.LocationFloat = new PointFloat(408.4414f, 32.99996f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new System.Drawing.SizeF(29.70132f, 33f);
			this.xrLabel10.StyleName = "Title";
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "-";
			this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRBindingCollection dataBindings5 = this.xrLabel6.DataBindings;
			XRBinding[] xRBinding5 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.ValidityName") };
			dataBindings5.AddRange(xRBinding5);
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel6.LocationFloat = new PointFloat(433.5803f, 32.99996f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new System.Drawing.SizeF(464.4378f, 33.00001f);
			this.xrLabel6.StyleName = "Title";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			XRBindingCollection xRBindingCollections5 = this.xrLabel5.DataBindings;
			XRBinding[] xRBindingArray5 = new XRBinding[] { new XRBinding("Text", null, "ValidityListDetails.ValidityCode") };
			xRBindingCollections5.AddRange(xRBindingArray5);
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel5.LocationFloat = new PointFloat(366.2682f, 32.99999f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(42.17325f, 32.99998f);
			this.xrLabel5.StyleName = "Title";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel4.LocationFloat = new PointFloat(260.0182f, 66.04166f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel4.StyleName = "Title";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Expired";
			this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.GroupHeader2.Controls.AddRange(new XRControl[] { this.xrTable4 });
			this.GroupHeader2.Dpi = 100f;
			this.GroupHeader2.HeightF = 39.58333f;
			this.GroupHeader2.Name = "GroupHeader2";
			this.GroupHeader2.RepeatEveryPage = true;
			this.xrTable4.BackColor = Color.LightGray;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrTable4.LocationFloat = new PointFloat(0f, 12.5f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Rows.AddRange(new XRTableRow[] { this.xrTableRow4 });
			this.xrTable4.SizeF = new System.Drawing.SizeF(1088f, 25f);
			this.xrTable4.StylePriority.UseBackColor = false;
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			XRTableCellCollection xRTableCellCollections = this.xrTableRow4.Cells;
			XRTableCell[] xRTableCellArray1 = new XRTableCell[] { this.xrTableCell8, this.xrTableCell18, this.xrTableCell19, this.xrTableCell20, this.xrTableCell21, this.xrTableCell22, this.xrTableCell23, this.xrTableCell25, this.xrTableCell13, this.xrTableCell14 };
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
			this.xrTableCell18.Weight = 0.171380361315802;
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Text = "Equiment Sr no";
			this.xrTableCell19.Weight = 0.195553103362449;
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Text = "Entered By";
			this.xrTableCell20.Weight = 0.137259745160107;
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
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "Status";
			this.xrTableCell13.Weight = 0.102181312511835;
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "Remarks";
			this.xrTableCell14.Weight = 0.356075856794119;
			this.Id.Description = "Id";
			dynamicListLookUpSetting.DataAdapter = null;
			dynamicListLookUpSetting.DataMember = "ValidityListDetails";
			dynamicListLookUpSetting.DataSource = this.sqlDataSource1;
			dynamicListLookUpSetting.DisplayMember = "ValidityName";
			dynamicListLookUpSetting.FilterString = null;
			dynamicListLookUpSetting.ValueMember = "ValidityID";
			this.Id.LookUpSettings = dynamicListLookUpSetting;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			BandCollection bands = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.pageFooterBand1, this.reportHeaderBand1, this.PageHeader, this.GroupHeader2 };
			bands.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "ValidityListDetails";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[ValidityID] = ?Id";
			base.Landscape = true;
			base.Margins = new System.Drawing.Printing.Margins(0, 2, 23, 0);
			base.PageHeight = 850;
			base.PageWidth = 1100;
			base.Parameters.AddRange(new Parameter[] { this.Id });
			base.RequestParameters = false;
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
		}
	}
}