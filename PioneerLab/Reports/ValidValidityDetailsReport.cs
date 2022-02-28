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
	// Token: 0x02000053 RID: 83
	public class ValidValidityDetailsReport : XtraReport
	{
		// Token: 0x06000324 RID: 804 RVA: 0x00003E1C File Offset: 0x0000201C
		public ValidValidityDetailsReport()
		{
			this.InitializeComponent();
			this.BeforePrint += this.ValidityDetailsReport_BeforePrint;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00002071 File Offset: 0x00000271
		private void ValidityDetailsReport_BeforePrint(object sender, PrintEventArgs e)
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00003E3C File Offset: 0x0000203C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00021024 File Offset: 0x0001F224
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ValidValidityDetailsReport));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidValidityDetailsReport));
            MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
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
			this.xrTableCell13 = new XRTableCell();
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
			masterDetailInfo.DetailQueryName = "ValidityListDetails";
			relationColumnInfo.NestedKeyColumn = "FKValidityID";
			relationColumnInfo.ParentKeyColumn = "ValidityID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo);
			masterDetailInfo.MasterQueryName = "ValidityList";
			masterDetailInfo.Name = "FK_ValidityListDetails_ValidityList";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo
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
				this.xrTableCell13
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
			this.xrTableCell13.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityListDetails.Remarks")
			});
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Weight = 0.32130863486397876;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 21.66667f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 0f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 0.8749326f;
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
			this.xrLabel26.LocationFloat = new PointFloat(218.625f, 0f);
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
			this.PageHeader.HeightF = 102.7917f;
			this.PageHeader.Name = "PageHeader";
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel10.LocationFloat = new PointFloat(365.6657f, 32.99999f);
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
			this.xrLabel6.LocationFloat = new PointFloat(390.8047f, 32.99999f);
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
			this.xrLabel5.LocationFloat = new PointFloat(323.4926f, 33.00002f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(42.17325f, 32.99998f);
			this.xrLabel5.StyleName = "Title";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.TextAlignment = TextAlignment.TopRight;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel4.LocationFloat = new PointFloat(217.2425f, 66.04169f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(638f, 33f);
			this.xrLabel4.StyleName = "Title";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Valid";
			this.xrLabel4.TextAlignment = TextAlignment.TopCenter;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable4
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable4.BackColor = Color.LightGray;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrTable4.LocationFloat = new PointFloat(0f, 0f);
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
				this.xrTableCell10,
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
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Status";
			this.xrTableCell10.Weight = 0.10218131251183545;
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
				this.GroupHeader1
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "ValidityListDetails";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[ValidityID] = ?Id";
			base.Landscape = true;
			base.Margins = new Margins(0, 2, 22, 0);
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

		// Token: 0x04000590 RID: 1424
		private IContainer components;

		// Token: 0x04000591 RID: 1425
		private DetailBand Detail;

		// Token: 0x04000592 RID: 1426
		private TopMarginBand TopMargin;

		// Token: 0x04000593 RID: 1427
		private BottomMarginBand BottomMargin;

		// Token: 0x04000594 RID: 1428
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000595 RID: 1429
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000596 RID: 1430
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000597 RID: 1431
		private XRControlStyle Title;

		// Token: 0x04000598 RID: 1432
		private XRControlStyle FieldCaption;

		// Token: 0x04000599 RID: 1433
		private XRControlStyle PageInfo;

		// Token: 0x0400059A RID: 1434
		private XRControlStyle DataField;

		// Token: 0x0400059B RID: 1435
		private XRLabel xrLabel26;

		// Token: 0x0400059C RID: 1436
		private PageHeaderBand PageHeader;

		// Token: 0x0400059D RID: 1437
		private GroupHeaderBand GroupHeader1;

		// Token: 0x0400059E RID: 1438
		private Parameter Id;

		// Token: 0x0400059F RID: 1439
		private XRLabel xrLabel10;

		// Token: 0x040005A0 RID: 1440
		private XRLabel xrLabel6;

		// Token: 0x040005A1 RID: 1441
		private XRLabel xrLabel5;

		// Token: 0x040005A2 RID: 1442
		private XRLabel xrLabel4;

		// Token: 0x040005A3 RID: 1443
		private XRTable xrTable1;

		// Token: 0x040005A4 RID: 1444
		private XRTableRow xrTableRow1;

		// Token: 0x040005A5 RID: 1445
		private XRTableCell xrTableCell1;

		// Token: 0x040005A6 RID: 1446
		private XRTableCell xrTableCell2;

		// Token: 0x040005A7 RID: 1447
		private XRTableCell xrTableCell3;

		// Token: 0x040005A8 RID: 1448
		private XRTableCell xrTableCell4;

		// Token: 0x040005A9 RID: 1449
		private XRTableCell xrTableCell5;

		// Token: 0x040005AA RID: 1450
		private XRTableCell xrTableCell6;

		// Token: 0x040005AB RID: 1451
		private XRTableCell xrTableCell7;

		// Token: 0x040005AC RID: 1452
		private XRTableCell xrTableCell9;

		// Token: 0x040005AD RID: 1453
		private XRTableCell xrTableCell12;

		// Token: 0x040005AE RID: 1454
		private XRTableCell xrTableCell13;

		// Token: 0x040005AF RID: 1455
		private XRTable xrTable4;

		// Token: 0x040005B0 RID: 1456
		private XRTableRow xrTableRow4;

		// Token: 0x040005B1 RID: 1457
		private XRTableCell xrTableCell8;

		// Token: 0x040005B2 RID: 1458
		private XRTableCell xrTableCell18;

		// Token: 0x040005B3 RID: 1459
		private XRTableCell xrTableCell19;

		// Token: 0x040005B4 RID: 1460
		private XRTableCell xrTableCell20;

		// Token: 0x040005B5 RID: 1461
		private XRTableCell xrTableCell21;

		// Token: 0x040005B6 RID: 1462
		private XRTableCell xrTableCell22;

		// Token: 0x040005B7 RID: 1463
		private XRTableCell xrTableCell23;

		// Token: 0x040005B8 RID: 1464
		private XRTableCell xrTableCell25;

		// Token: 0x040005B9 RID: 1465
		private XRTableCell xrTableCell10;

		// Token: 0x040005BA RID: 1466
		private XRTableCell xrTableCell14;
	}
}
