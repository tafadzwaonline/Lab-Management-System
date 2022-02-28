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
	// Token: 0x0200005D RID: 93
	public class Customers : XtraReport
	{
		// Token: 0x06000349 RID: 841 RVA: 0x0000411F File Offset: 0x0000231F
		public Customers()
		{
			this.InitializeComponent();
			this.BeforePrint += this.Customers_BeforePrint;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000338A4 File Offset: 0x00031AA4
		private void Customers_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
				return;
			}
			if (this.CustomerID.Value.ToString() == "0")
			{
				this.FilterString = "";
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000413F File Offset: 0x0000233F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0003390C File Offset: 0x00031B0C
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			QueryParameter queryParameter = new QueryParameter();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Customers));
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrLabel1 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrLabel10 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLabel14 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.xrLabel16 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel19 = new XRLabel();
			this.xrLabel20 = new XRLabel();
			this.xrLabel21 = new XRLabel();
			this.xrCheckBox1 = new XRCheckBox();
			this.xrLabel22 = new XRLabel();
			this.xrLabel23 = new XRLabel();
			this.xrLabel24 = new XRLabel();
			this.xrLabel25 = new XRLabel();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.pageFooterBand1 = new PageFooterBand();
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPageInfo2 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.xrLabel26 = new XRLabel();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.PageHeader = new PageHeaderBand();
			this.CustomerID = new Parameter();
			this.FilterExpression = new Parameter();
			this.xrLine2 = new XRLine();
			this.xrLabel5 = new XRLabel();
			this.xrLabel18 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel27 = new XRLabel();
			this.xrLabel28 = new XRLabel();
			this.xrLabel29 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel30 = new XRLabel();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "Query";
			queryParameter.Name = "CustomerID";
			queryParameter.Type = typeof(int);
			queryParameter.ValueInfo = "0";
			customSqlQuery.Parameters.Add(queryParameter);
			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery
			});
			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrLabel1,
				this.xrLabel2,
				this.xrLabel3,
				this.xrLabel4,
				this.xrLabel6,
				this.xrLabel7,
				this.xrLabel8,
				this.xrLabel9,
				this.xrLabel10,
				this.xrLabel11,
				this.xrLabel12,
				this.xrLabel13,
				this.xrLabel14,
				this.xrLabel15,
				this.xrLabel16,
				this.xrLabel17,
				this.xrLabel19,
				this.xrLabel20,
				this.xrLabel21,
				this.xrCheckBox1,
				this.xrLabel22,
				this.xrLabel23,
				this.xrLabel24,
				this.xrLabel25
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 317.5001f;
			this.Detail.KeepTogether = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.StyleName = "DataField";
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.ForeColor = Color.Black;
			this.xrLabel1.LocationFloat = new PointFloat(10.00001f, 250.5833f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new SizeF(70.1925f, 18f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Address:";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.ForeColor = Color.Black;
			this.xrLabel2.LocationFloat = new PointFloat(327.7147f, 221.1249f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(113.0572f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Mobile Number:";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.ForeColor = Color.Black;
			this.xrLabel3.LocationFloat = new PointFloat(10.00001f, 221.1249f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(110.2464f, 18f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "Contact Name:";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.Black;
			this.xrLabel4.LocationFloat = new PointFloat(10.00001f, 37.12498f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(110.2464f, 18f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "C.R. Number:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.Black;
			this.xrLabel6.LocationFloat = new PointFloat(10.00001f, 66.58331f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(129.1041f, 18f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Customer Name:";
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.ForeColor = Color.Black;
			this.xrLabel7.LocationFloat = new PointFloat(10.00001f, 161.2917f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new SizeF(52.6444f, 18f);
			this.xrLabel7.StyleName = "FieldCaption";
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.Text = "Email:";
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.ForeColor = Color.Black;
			this.xrLabel8.LocationFloat = new PointFloat(328.2304f, 95.91669f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new SizeF(106.5422f, 18f);
			this.xrLabel8.StyleName = "FieldCaption";
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "Fax No:";
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.ForeColor = Color.Black;
			this.xrLabel9.LocationFloat = new PointFloat(551.5128f, 10.00001f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new SizeF(86.48723f, 18f);
			this.xrLabel9.StyleName = "FieldCaption";
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.Text = "Inactive";
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.Black;
			this.xrLabel10.LocationFloat = new PointFloat(9.999974f, 281.0833f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(129.1041f, 18f);
			this.xrLabel10.StyleName = "FieldCaption";
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.Text = "Creditor Mode:";
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.ForeColor = Color.Black;
			this.xrLabel11.LocationFloat = new PointFloat(10.00001f, 95.91669f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel11.SizeF = new SizeF(129.1041f, 18f);
			this.xrLabel11.StyleName = "FieldCaption";
			this.xrLabel11.StylePriority.UseForeColor = false;
			this.xrLabel11.Text = "Telephone No:";
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.ForeColor = Color.Black;
			this.xrLabel12.LocationFloat = new PointFloat(10.00001f, 131.4167f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(70.1925f, 18f);
			this.xrLabel12.StyleName = "FieldCaption";
			this.xrLabel12.StylePriority.UseForeColor = false;
			this.xrLabel12.Text = "P.O.Box:";
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.ForeColor = Color.Black;
			this.xrLabel13.LocationFloat = new PointFloat(10.00001f, 189.3333f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel13.SizeF = new SizeF(70.1925f, 18f);
			this.xrLabel13.StyleName = "FieldCaption";
			this.xrLabel13.StylePriority.UseForeColor = false;
			this.xrLabel13.Text = "Website:";
			this.xrLabel14.Borders = BorderSide.All;
			this.xrLabel14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.Address")
			});
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.LocationFloat = new PointFloat(155.7699f, 250.5834f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel14.SizeF = new SizeF(454.6453f, 23.00002f);
			this.xrLabel14.StylePriority.UseBorders = false;
			this.xrLabel14.Text = "xrLabel14";
			this.xrLabel15.Borders = BorderSide.All;
			this.xrLabel15.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.ContactMobileNumber")
			});
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.LocationFloat = new PointFloat(440.7719f, 221.1249f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new SizeF(169.6434f, 23f);
			this.xrLabel15.StylePriority.UseBorders = false;
			this.xrLabel15.Text = "xrLabel15";
			this.xrLabel16.Borders = BorderSide.All;
			this.xrLabel16.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.ContactName")
			});
			this.xrLabel16.Dpi = 100f;
			this.xrLabel16.LocationFloat = new PointFloat(155.77f, 221.125f);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel16.SizeF = new SizeF(163.23f, 23f);
			this.xrLabel16.StylePriority.UseBorders = false;
			this.xrLabel16.Text = "xrLabel16";
			this.xrLabel17.Borders = BorderSide.All;
			this.xrLabel17.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.CustomerCode")
			});
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.LocationFloat = new PointFloat(155.7708f, 37.12498f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel17.SizeF = new SizeF(163.23f, 23f);
			this.xrLabel17.StylePriority.UseBorders = false;
			this.xrLabel17.Text = "xrLabel17";
			this.xrLabel19.Borders = BorderSide.All;
			this.xrLabel19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.CustomerName")
			});
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.LocationFloat = new PointFloat(155.7708f, 66.58331f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new SizeF(454.6453f, 23.00001f);
			this.xrLabel19.StylePriority.UseBorders = false;
			this.xrLabel19.Text = "xrLabel19";
			this.xrLabel20.Borders = BorderSide.All;
			this.xrLabel20.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.Email")
			});
			this.xrLabel20.Dpi = 100f;
			this.xrLabel20.LocationFloat = new PointFloat(155.7708f, 156.2917f);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel20.SizeF = new SizeF(454.6453f, 23f);
			this.xrLabel20.StylePriority.UseBorders = false;
			this.xrLabel20.Text = "xrLabel20";
			this.xrLabel21.Borders = BorderSide.All;
			this.xrLabel21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.FaxNumber")
			});
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.LocationFloat = new PointFloat(447.1862f, 95.91669f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new SizeF(163.23f, 23f);
			this.xrLabel21.StylePriority.UseBorders = false;
			this.xrLabel21.Text = "xrLabel21";
			this.xrCheckBox1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "Query.IsLocked")
			});
			this.xrCheckBox1.Dpi = 100f;
			this.xrCheckBox1.LocationFloat = new PointFloat(522.3172f, 5.000019f);
			this.xrCheckBox1.Name = "xrCheckBox1";
			this.xrCheckBox1.SizeF = new SizeF(29.19559f, 23f);
			this.xrCheckBox1.StylePriority.UseTextAlignment = false;
			this.xrCheckBox1.TextAlignment = TextAlignment.MiddleCenter;
			this.xrLabel22.Borders = BorderSide.All;
			this.xrLabel22.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.Column13")
			});
			this.xrLabel22.Dpi = 100f;
			this.xrLabel22.LocationFloat = new PointFloat(155.7701f, 281.0833f);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel22.SizeF = new SizeF(454.6453f, 23f);
			this.xrLabel22.StylePriority.UseBorders = false;
			this.xrLabel23.Borders = BorderSide.All;
			this.xrLabel23.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.PhoneNumber")
			});
			this.xrLabel23.Dpi = 100f;
			this.xrLabel23.LocationFloat = new PointFloat(155.7708f, 95.91669f);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel23.SizeF = new SizeF(163.2292f, 23f);
			this.xrLabel23.StylePriority.UseBorders = false;
			this.xrLabel23.Text = "xrLabel23";
			this.xrLabel24.Borders = BorderSide.All;
			this.xrLabel24.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.POBox")
			});
			this.xrLabel24.Dpi = 100f;
			this.xrLabel24.LocationFloat = new PointFloat(155.7708f, 126.4167f);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel24.SizeF = new SizeF(454.6453f, 22.99999f);
			this.xrLabel24.StylePriority.UseBorders = false;
			this.xrLabel24.Text = "xrLabel24";
			this.xrLabel25.Borders = BorderSide.All;
			this.xrLabel25.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.website")
			});
			this.xrLabel25.Dpi = 100f;
			this.xrLabel25.LocationFloat = new PointFloat(155.7709f, 189.3333f);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel25.SizeF = new SizeF(454.6453f, 23f);
			this.xrLabel25.StylePriority.UseBorders = false;
			this.xrLabel25.Text = "xrLabel25";
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine2,
				this.xrLabel5,
				this.xrLabel18,
				this.xrPictureBox1,
				this.xrLabel27,
				this.xrLabel28,
				this.xrLabel29,
				this.xrLine1,
				this.xrLabel30
			});
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 6f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.pageFooterBand1.Controls.AddRange(new XRControl[]
			{
				this.xrPictureBox2,
				this.xrPageInfo1,
				this.xrPageInfo2
			});
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 114.4166f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)componentResourceManager.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(137.5f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(3.978006f, 91.41661f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(522.3172f, 81.41657f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 6.208324f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(11.99999f, 28.75001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Customer Information";
			this.xrLabel26.TextAlignment = TextAlignment.TopCenter;
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
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel26
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 78.125f;
			this.PageHeader.Name = "PageHeader";
			this.CustomerID.Description = "CustomerID";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "Query";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "CustomerName";
			dynamicListLookUpSettings.ValueMember = "CustomerID";
			this.CustomerID.LookUpSettings = dynamicListLookUpSettings;
			this.CustomerID.Name = "CustomerID";
			this.CustomerID.Type = typeof(int);
			this.CustomerID.ValueInfo = "0";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(543.1331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel5.BackColor = Color.White;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel5.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel5.LocationFloat = new PointFloat(568.4379f, 71.52086f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new SizeF(249.9936f, 22.99997f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel5.TextAlignment = TextAlignment.TopRight;
			this.xrLabel18.BackColor = Color.White;
			this.xrLabel18.Dpi = 100f;
			this.xrLabel18.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel18.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel18.LocationFloat = new PointFloat(568.4379f, 17.52084f);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel18.SizeF = new SizeF(249.9937f, 24f);
			this.xrLabel18.StylePriority.UseBackColor = false;
			this.xrLabel18.StylePriority.UseFont = false;
			this.xrLabel18.StylePriority.UseForeColor = false;
			this.xrLabel18.StylePriority.UsePadding = false;
			this.xrLabel18.StylePriority.UseTextAlignment = false;
			this.xrLabel18.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel18.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)componentResourceManager.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(343.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel27.BackColor = Color.White;
			this.xrLabel27.Dpi = 100f;
			this.xrLabel27.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel27.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel27.LocationFloat = new PointFloat(568.4379f, 43.47918f);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel27.SizeF = new SizeF(249.9937f, 22.99997f);
			this.xrLabel27.StylePriority.UseBackColor = false;
			this.xrLabel27.StylePriority.UseFont = false;
			this.xrLabel27.StylePriority.UseForeColor = false;
			this.xrLabel27.StylePriority.UsePadding = false;
			this.xrLabel27.StylePriority.UseTextAlignment = false;
			this.xrLabel27.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel27.TextAlignment = TextAlignment.TopRight;
			this.xrLabel28.BackColor = Color.White;
			this.xrLabel28.Dpi = 100f;
			this.xrLabel28.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel28.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel28.LocationFloat = new PointFloat(6.464294f, 41.52085f);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel28.SizeF = new SizeF(310.5137f, 25f);
			this.xrLabel28.StylePriority.UseBackColor = false;
			this.xrLabel28.StylePriority.UseFont = false;
			this.xrLabel28.StylePriority.UseForeColor = false;
			this.xrLabel28.StylePriority.UsePadding = false;
			this.xrLabel28.StylePriority.UseTextAlignment = false;
			this.xrLabel28.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel28.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel29.BackColor = Color.White;
			this.xrLabel29.Dpi = 100f;
			this.xrLabel29.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel29.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel29.LocationFloat = new PointFloat(6.464294f, 66.52084f);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel29.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel29.StylePriority.UseBackColor = false;
			this.xrLabel29.StylePriority.UseFont = false;
			this.xrLabel29.StylePriority.UseForeColor = false;
			this.xrLabel29.StylePriority.UsePadding = false;
			this.xrLabel29.StylePriority.UseTextAlignment = false;
			this.xrLabel29.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel29.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(7.326614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel30.BackColor = Color.White;
			this.xrLabel30.Dpi = 100f;
			this.xrLabel30.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel30.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel30.LocationFloat = new PointFloat(6.464294f, 17.52084f);
			this.xrLabel30.Name = "xrLabel30";
			this.xrLabel30.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel30.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel30.StylePriority.UseBackColor = false;
			this.xrLabel30.StylePriority.UseFont = false;
			this.xrLabel30.StylePriority.UseForeColor = false;
			this.xrLabel30.StylePriority.UsePadding = false;
			this.xrLabel30.StylePriority.UseTextAlignment = false;
			this.xrLabel30.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel30.TextAlignment = TextAlignment.TopLeft;
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1,
				this.PageHeader
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "Query";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[CustomerID] = ?CustomerID";
			base.Margins = new Margins(0, 0, 130, 6);
			base.Parameters.AddRange(new Parameter[]
			{
				this.CustomerID,
				this.FilterExpression
			});
			base.StyleSheet.AddRange(new XRControlStyle[]
			{
				this.Title,
				this.FieldCaption,
				this.PageInfo,
				this.DataField
			});
			base.Version = "18.2";
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000741 RID: 1857
		private IContainer components;

		// Token: 0x04000742 RID: 1858
		private DetailBand Detail;

		// Token: 0x04000743 RID: 1859
		private TopMarginBand TopMargin;

		// Token: 0x04000744 RID: 1860
		private BottomMarginBand BottomMargin;

		// Token: 0x04000745 RID: 1861
		private XRLabel xrLabel1;

		// Token: 0x04000746 RID: 1862
		private XRLabel xrLabel2;

		// Token: 0x04000747 RID: 1863
		private XRLabel xrLabel3;

		// Token: 0x04000748 RID: 1864
		private XRLabel xrLabel4;

		// Token: 0x04000749 RID: 1865
		private XRLabel xrLabel6;

		// Token: 0x0400074A RID: 1866
		private XRLabel xrLabel7;

		// Token: 0x0400074B RID: 1867
		private XRLabel xrLabel8;

		// Token: 0x0400074C RID: 1868
		private XRLabel xrLabel9;

		// Token: 0x0400074D RID: 1869
		private XRLabel xrLabel10;

		// Token: 0x0400074E RID: 1870
		private XRLabel xrLabel11;

		// Token: 0x0400074F RID: 1871
		private XRLabel xrLabel12;

		// Token: 0x04000750 RID: 1872
		private XRLabel xrLabel13;

		// Token: 0x04000751 RID: 1873
		private XRLabel xrLabel14;

		// Token: 0x04000752 RID: 1874
		private XRLabel xrLabel15;

		// Token: 0x04000753 RID: 1875
		private XRLabel xrLabel16;

		// Token: 0x04000754 RID: 1876
		private XRLabel xrLabel17;

		// Token: 0x04000755 RID: 1877
		private XRLabel xrLabel19;

		// Token: 0x04000756 RID: 1878
		private XRLabel xrLabel20;

		// Token: 0x04000757 RID: 1879
		private XRLabel xrLabel21;

		// Token: 0x04000758 RID: 1880
		private XRCheckBox xrCheckBox1;

		// Token: 0x04000759 RID: 1881
		private XRLabel xrLabel22;

		// Token: 0x0400075A RID: 1882
		private XRLabel xrLabel23;

		// Token: 0x0400075B RID: 1883
		private XRLabel xrLabel24;

		// Token: 0x0400075C RID: 1884
		private XRLabel xrLabel25;

		// Token: 0x0400075D RID: 1885
		private SqlDataSource sqlDataSource1;

		// Token: 0x0400075E RID: 1886
		private PageFooterBand pageFooterBand1;

		// Token: 0x0400075F RID: 1887
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000760 RID: 1888
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000761 RID: 1889
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000762 RID: 1890
		private XRLabel xrLabel26;

		// Token: 0x04000763 RID: 1891
		private XRControlStyle Title;

		// Token: 0x04000764 RID: 1892
		private XRControlStyle FieldCaption;

		// Token: 0x04000765 RID: 1893
		private XRControlStyle PageInfo;

		// Token: 0x04000766 RID: 1894
		private XRControlStyle DataField;

		// Token: 0x04000767 RID: 1895
		private PageHeaderBand PageHeader;

		// Token: 0x04000768 RID: 1896
		private Parameter CustomerID;

		// Token: 0x04000769 RID: 1897
		private Parameter FilterExpression;

		// Token: 0x0400076A RID: 1898
		private XRPictureBox xrPictureBox2;

		// Token: 0x0400076B RID: 1899
		private XRLine xrLine2;

		// Token: 0x0400076C RID: 1900
		private XRLabel xrLabel5;

		// Token: 0x0400076D RID: 1901
		private XRLabel xrLabel18;

		// Token: 0x0400076E RID: 1902
		private XRPictureBox xrPictureBox1;

		// Token: 0x0400076F RID: 1903
		private XRLabel xrLabel27;

		// Token: 0x04000770 RID: 1904
		private XRLabel xrLabel28;

		// Token: 0x04000771 RID: 1905
		private XRLabel xrLabel29;

		// Token: 0x04000772 RID: 1906
		private XRLine xrLine1;

		// Token: 0x04000773 RID: 1907
		private XRLabel xrLabel30;
	}
}
