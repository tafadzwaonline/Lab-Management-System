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
	// Token: 0x02000052 RID: 82
	public class ExpiredValidityDetailsReport : XtraReport
	{
		// Token: 0x06000320 RID: 800 RVA: 0x00003DDD File Offset: 0x00001FDD
		public ExpiredValidityDetailsReport()
		{
			this.InitializeComponent();
			this.BeforePrint += this.ValidityDetailsReport_BeforePrint;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00002071 File Offset: 0x00000271
		private void ValidityDetailsReport_BeforePrint(object sender, PrintEventArgs e)
		{
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00003DFD File Offset: 0x00001FFD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0001F920 File Offset: 0x0001DB20
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ExpiredValidityDetailsReport));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpiredValidityDetailsReport));
            DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
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
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25f;
			this.Detail.KeepTogether = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrTable1.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Times New Roman", 10f);
			this.xrTable1.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(0, 0, 3, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(1088f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3,
				this.xrTableCell4,
				this.xrTableCell5,
				this.xrTableCell6,
				this.xrTableCell7,
				this.xrTableCell9,
				this.xrTableCell12,
				this.xrTableCell10
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.CertificateName")
			});
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Weight = 0.3596744337124881;
			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.CertificateSerialNumber")
			});
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Weight = 0.15464683176516628;
			this.xrTableCell3.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.IDNumber")
			});
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Weight = 0.17645928089820392;
			this.xrTableCell4.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.EnteredBy")
			});
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Weight = 0.12385763292040076;
			this.xrTableCell5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.EntryDate", "{0:dd/MM/yyyy}")
			});
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Weight = 0.13126928467681004;
			this.xrTableCell6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.ExpiryDate", "{0:dd/MM/yyyy}")
			});
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Weight = 0.1510591091211691;
			this.xrTableCell7.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.Responsible")
			});
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Weight = 0.1809211268752949;
			this.xrTableCell9.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.CalibratedBy")
			});
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Weight = 0.14869005937926982;
			this.xrTableCell12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.Status")
			});
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Weight = 0.09220432116154983;
			this.xrTableCell10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.Remarks")
			});
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Weight = 0.32130863486397876;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 22.89581f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 0f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
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
			this.Title.Font = new Font("Times New Roman", 20f, FontStyle.Bold);
			this.Title.ForeColor = Color.Maroon;
			this.Title.Name = "Title";
			this.FieldCaption.BackColor = Color.Transparent;
			this.FieldCaption.BorderColor = Color.Black;
			this.FieldCaption.Borders = BorderSide.None;
			this.FieldCaption.BorderWidth = 1f;
			this.FieldCaption.Font = new Font("Arial", 10f, FontStyle.Bold);
			this.FieldCaption.ForeColor = Color.Maroon;
			this.FieldCaption.Name = "FieldCaption";
			this.PageInfo.BackColor = Color.Transparent;
			this.PageInfo.BorderColor = Color.Black;
			this.PageInfo.Borders = BorderSide.None;
			this.PageInfo.BorderWidth = 1f;
			this.PageInfo.Font = new Font("Times New Roman", 10f, FontStyle.Bold);
			this.PageInfo.ForeColor = Color.Black;
			this.PageInfo.Name = "PageInfo";
			this.DataField.BackColor = Color.Transparent;
			this.DataField.BorderColor = Color.Black;
			this.DataField.Borders = BorderSide.None;
			this.DataField.BorderWidth = 1f;
			this.DataField.Font = new Font("Times New Roman", 10f);
			this.DataField.ForeColor = Color.Black;
			this.DataField.Name = "DataField";
			this.DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(260.0182f, 0f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Validity List Details";
			this.xrLabel26.TextAlignment = TextAlignment.TopCenter;
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel10,
				this.xrLabel6,
				this.xrLabel5,
				this.xrLabel4,
				this.xrLabel26
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 109.0417f;
			this.PageHeader.Name = "PageHeader";
			this.PageHeader.StylePriority.UseTextAlignment = false;
			this.PageHeader.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel10.LocationFloat = new PointFloat(408.4414f, 32.99996f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(29.70132f, 33f);
			this.xrLabel10.StyleName = "Title";
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "-";
			this.xrLabel10.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.ValidityName")
			});
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel6.LocationFloat = new PointFloat(433.5803f, 32.99996f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(464.4378f, 33.00001f);
			this.xrLabel6.StyleName = "Title";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.ValidityCode")
			});
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel5.LocationFloat = new PointFloat(366.2682f, 32.99999f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(42.17325f, 32.99998f);
			this.xrLabel5.StyleName = "Title";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.TextAlignment = TextAlignment.TopRight;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel4.LocationFloat = new PointFloat(260.0182f, 66.04166f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(638f, 33f);
			this.xrLabel4.StyleName = "Title";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Expired";
			this.xrLabel4.TextAlignment = TextAlignment.TopCenter;
			this.GroupHeader2.Controls.AddRange(new XRControl[]
			{
				this.xrTable4
			});
			this.GroupHeader2.Dpi = 100f;
			this.GroupHeader2.HeightF = 39.58333f;
			this.GroupHeader2.Name = "GroupHeader2";
			this.GroupHeader2.RepeatEveryPage = true;
			this.xrTable4.BackColor = Color.LightGray;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrTable4.LocationFloat = new PointFloat(0f, 12.5f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow4
			});
			this.xrTable4.SizeF = new SizeF(1088f, 25f);
			this.xrTable4.StylePriority.UseBackColor = false;
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell8,
				this.xrTableCell18,
				this.xrTableCell19,
				this.xrTableCell20,
				this.xrTableCell21,
				this.xrTableCell22,
				this.xrTableCell23,
				this.xrTableCell25,
				this.xrTableCell13,
				this.xrTableCell14
			});
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 11.5;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Certificate Name";
			this.xrTableCell8.Weight = 0.39859314892039543;
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "Certificate Sr no";
			this.xrTableCell18.Weight = 0.1713803613158021;
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Text = "Equiment Sr no";
			this.xrTableCell19.Weight = 0.195553103362449;
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Text = "Entered By";
			this.xrTableCell20.Weight = 0.13725974516010675;
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Text = "Entry Date";
			this.xrTableCell21.Weight = 0.14547330677602308;
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Text = "Expiry Date";
			this.xrTableCell22.Weight = 0.16740450540049445;
			this.xrTableCell23.Dpi = 100f;
			this.xrTableCell23.Name = "xrTableCell23";
			this.xrTableCell23.Text = "Responsible";
			this.xrTableCell23.Weight = 0.2004977564081386;
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.Text = "Calibrated By";
			this.xrTableCell25.Weight = 0.16477911728780725;
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "Status";
			this.xrTableCell13.Weight = 0.10218131251183545;
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "Remarks";
			this.xrTableCell14.Weight = 0.3560758567941192;
			this.Id.Description = "Id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "ValidityListDetails";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "ValidityName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "ValidityID";
			this.Id.LookUpSettings = dynamicListLookUpSettings;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1,
				this.PageHeader,
				this.GroupHeader2
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "ValidityListDetails";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[ValidityID] = ?Id";
			base.Landscape = true;
			base.Margins = new Margins(0, 2, 23, 0);
			base.PageHeight = 850;
			base.PageWidth = 1100;
			base.Parameters.AddRange(new Parameter[]
			{
				this.Id
			});
			base.RequestParameters = false;
			base.StyleSheet.AddRange(new XRControlStyle[]
			{
				this.Title,
				this.FieldCaption,
				this.PageInfo,
				this.DataField
			});
			base.Version = "18.2";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000565 RID: 1381
		private IContainer components;

		// Token: 0x04000566 RID: 1382
		private DetailBand Detail;

		// Token: 0x04000567 RID: 1383
		private TopMarginBand TopMargin;

		// Token: 0x04000568 RID: 1384
		private BottomMarginBand BottomMargin;

		// Token: 0x04000569 RID: 1385
		private SqlDataSource sqlDataSource1;

		// Token: 0x0400056A RID: 1386
		private PageFooterBand pageFooterBand1;

		// Token: 0x0400056B RID: 1387
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x0400056C RID: 1388
		private XRControlStyle Title;

		// Token: 0x0400056D RID: 1389
		private XRControlStyle FieldCaption;

		// Token: 0x0400056E RID: 1390
		private XRControlStyle PageInfo;

		// Token: 0x0400056F RID: 1391
		private XRControlStyle DataField;

		// Token: 0x04000570 RID: 1392
		private XRLabel xrLabel26;

		// Token: 0x04000571 RID: 1393
		private PageHeaderBand PageHeader;

		// Token: 0x04000572 RID: 1394
		private XRLabel xrLabel4;

		// Token: 0x04000573 RID: 1395
		private GroupHeaderBand GroupHeader2;

		// Token: 0x04000574 RID: 1396
		private Parameter Id;

		// Token: 0x04000575 RID: 1397
		private XRLabel xrLabel10;

		// Token: 0x04000576 RID: 1398
		private XRLabel xrLabel6;

		// Token: 0x04000577 RID: 1399
		private XRLabel xrLabel5;

		// Token: 0x04000578 RID: 1400
		private XRTable xrTable4;

		// Token: 0x04000579 RID: 1401
		private XRTableRow xrTableRow4;

		// Token: 0x0400057A RID: 1402
		private XRTableCell xrTableCell8;

		// Token: 0x0400057B RID: 1403
		private XRTableCell xrTableCell18;

		// Token: 0x0400057C RID: 1404
		private XRTableCell xrTableCell19;

		// Token: 0x0400057D RID: 1405
		private XRTableCell xrTableCell20;

		// Token: 0x0400057E RID: 1406
		private XRTableCell xrTableCell21;

		// Token: 0x0400057F RID: 1407
		private XRTableCell xrTableCell22;

		// Token: 0x04000580 RID: 1408
		private XRTableCell xrTableCell23;

		// Token: 0x04000581 RID: 1409
		private XRTableCell xrTableCell25;

		// Token: 0x04000582 RID: 1410
		private XRTableCell xrTableCell13;

		// Token: 0x04000583 RID: 1411
		private XRTableCell xrTableCell14;

		// Token: 0x04000584 RID: 1412
		private XRTable xrTable1;

		// Token: 0x04000585 RID: 1413
		private XRTableRow xrTableRow1;

		// Token: 0x04000586 RID: 1414
		private XRTableCell xrTableCell1;

		// Token: 0x04000587 RID: 1415
		private XRTableCell xrTableCell2;

		// Token: 0x04000588 RID: 1416
		private XRTableCell xrTableCell3;

		// Token: 0x04000589 RID: 1417
		private XRTableCell xrTableCell4;

		// Token: 0x0400058A RID: 1418
		private XRTableCell xrTableCell5;

		// Token: 0x0400058B RID: 1419
		private XRTableCell xrTableCell6;

		// Token: 0x0400058C RID: 1420
		private XRTableCell xrTableCell7;

		// Token: 0x0400058D RID: 1421
		private XRTableCell xrTableCell9;

		// Token: 0x0400058E RID: 1422
		private XRTableCell xrTableCell12;

		// Token: 0x0400058F RID: 1423
		private XRTableCell xrTableCell10;
	}
}
