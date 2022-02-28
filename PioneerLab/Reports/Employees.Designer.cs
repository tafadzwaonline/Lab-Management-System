using DevExpress.DataAccess;
using DevExpress.DataAccess.Native;
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
	public class Employees : XtraReport
	{
		private IContainer components;

		private DetailBand Detail;

		private TopMarginBand TopMargin;

		private BottomMarginBand BottomMargin;

		private XRLabel xrLabel2;

		private XRLabel xrLabel4;

		private XRLabel xrLabel6;

		private XRLabel xrLabel7;

		private XRLabel xrLabel8;

		private XRLabel xrLabel11;

		private XRLabel xrLabel12;

		private XRLabel xrLabel15;

		private XRLabel xrLabel17;

		private XRLabel xrLabel19;

		private XRLabel xrLabel20;

		private XRLabel xrLabel21;

		private XRLabel xrLabel23;

		private XRLabel xrLabel24;

		private SqlDataSource sqlDataSource1;

		private PageFooterBand pageFooterBand1;

		private XRPageInfo xrPageInfo1;

		private XRPageInfo xrPageInfo2;

		private ReportHeaderBand reportHeaderBand1;

		private XRLabel xrLabel26;

		private XRControlStyle Title;

		private XRControlStyle FieldCaption;

		private XRControlStyle PageInfo;

		private XRControlStyle DataField;

		private PageHeaderBand PageHeader;

		private XRCheckBox xrCheckBox1;

		private XRLabel xrLabel9;

		private Parameter EmpID;

		private Parameter FilterExpression;

		private XRPictureBox xrPictureBox2;

		private XRLine xrLine2;

		private XRLabel xrLabel1;

		private XRLabel xrLabel3;

		private XRPictureBox xrPictureBox1;

		private XRLabel xrLabel5;

		private XRLabel xrLabel10;

		private XRLabel xrLabel13;

		private XRLine xrLine1;

		private XRLabel xrLabel14;

		public Employees()
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
				return;
			}
			if (this.EmpID.Value.ToString() == "0")
			{
				this.FilterString = "";
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			QueryParameter queryParameter = new QueryParameter();
			DynamicListLookUpSettings dynamicListLookUpSetting = new DynamicListLookUpSettings();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Employees));
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrCheckBox1 = new XRCheckBox();
			this.xrLabel9 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel19 = new XRLabel();
			this.xrLabel20 = new XRLabel();
			this.xrLabel21 = new XRLabel();
			this.xrLabel23 = new XRLabel();
			this.xrLabel24 = new XRLabel();
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
			this.EmpID = new Parameter();
			this.FilterExpression = new Parameter();
			this.xrLine2 = new XRLine();
			this.xrLabel1 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel5 = new XRLabel();
			this.xrLabel10 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel14 = new XRLabel();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "Query";
			queryParameter.Name = "CustomerID";
			queryParameter.Type = typeof(int);
			queryParameter.ValueInfo = "0";
			customSqlQuery.Parameters.Add(queryParameter);
			customSqlQuery.Sql = "SELECT        EmpID, EmpCode, EmpName, Profession, QID, PhoneNumber, NormalWorkHrs, RamadanWorkHrs, IsLocked\r\nFROM            EmployeesList";
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[] { customSqlQuery });
			XRControlCollection controls = this.Detail.Controls;
			XRControl[] xRControlArrays = new XRControl[] { this.xrCheckBox1, this.xrLabel9, this.xrLabel2, this.xrLabel4, this.xrLabel6, this.xrLabel7, this.xrLabel8, this.xrLabel11, this.xrLabel12, this.xrLabel15, this.xrLabel17, this.xrLabel19, this.xrLabel20, this.xrLabel21, this.xrLabel23, this.xrLabel24 };
			controls.AddRange(xRControlArrays);
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 283.1251f;
			this.Detail.KeepTogether = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.StyleName = "DataField";
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			XRBindingCollection dataBindings = this.xrCheckBox1.DataBindings;
			XRBinding[] xRBinding = new XRBinding[] { new XRBinding("CheckState", null, "Query.IsLocked") };
			dataBindings.AddRange(xRBinding);
			this.xrCheckBox1.Dpi = 100f;
			this.xrCheckBox1.LocationFloat = new PointFloat(573.3171f, 5.000019f);
			this.xrCheckBox1.Name = "xrCheckBox1";
			this.xrCheckBox1.SizeF = new System.Drawing.SizeF(29.19559f, 23f);
			this.xrCheckBox1.StylePriority.UseTextAlignment = false;
			this.xrCheckBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.ForeColor = Color.Black;
			this.xrLabel9.LocationFloat = new PointFloat(602.5128f, 10.00001f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new System.Drawing.SizeF(86.48723f, 18f);
			this.xrLabel9.StyleName = "FieldCaption";
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.Text = "Inactive";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.ForeColor = Color.Black;
			this.xrLabel2.LocationFloat = new PointFloat(380.1743f, 119.9584f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(113.0572f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Telephone No:";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.Black;
			this.xrLabel4.LocationFloat = new PointFloat(11.99999f, 25.66665f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(145.7708f, 18f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Employee Number:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.Black;
			this.xrLabel6.LocationFloat = new PointFloat(11.99999f, 55.12498f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new System.Drawing.SizeF(129.1041f, 18f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Employee Name:";
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.ForeColor = Color.Black;
			this.xrLabel7.LocationFloat = new PointFloat(11.99999f, 149.8334f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new System.Drawing.SizeF(131.1041f, 18.00002f);
			this.xrLabel7.StyleName = "FieldCaption";
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.Text = "Normal Work Hrs:";
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.ForeColor = Color.Black;
			this.xrLabel8.LocationFloat = new PointFloat(380.1743f, 149.8334f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(141.1822f, 18f);
			this.xrLabel8.StyleName = "FieldCaption";
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "Ramadan Work Hrs:";
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.ForeColor = Color.Black;
			this.xrLabel11.LocationFloat = new PointFloat(11.99999f, 84.45835f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel11.SizeF = new System.Drawing.SizeF(129.1041f, 18f);
			this.xrLabel11.StyleName = "FieldCaption";
			this.xrLabel11.StylePriority.UseForeColor = false;
			this.xrLabel11.Text = "Profession";
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.ForeColor = Color.Black;
			this.xrLabel12.LocationFloat = new PointFloat(11.99999f, 119.9584f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new System.Drawing.SizeF(98.3175f, 18f);
			this.xrLabel12.StyleName = "FieldCaption";
			this.xrLabel12.StylePriority.UseForeColor = false;
			this.xrLabel12.Text = "QID/Visa No:";
			this.xrLabel15.Borders = BorderSide.All;
			XRBindingCollection xRBindingCollections = this.xrLabel15.DataBindings;
			XRBinding[] xRBindingArray = new XRBinding[] { new XRBinding("Text", null, "Query.PhoneNumber") };
			xRBindingCollections.AddRange(xRBindingArray);
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.LocationFloat = new PointFloat(521.3565f, 114.9584f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new System.Drawing.SizeF(169.6434f, 23f);
			this.xrLabel15.StylePriority.UseBorders = false;
			this.xrLabel17.Borders = BorderSide.All;
			XRBindingCollection dataBindings1 = this.xrLabel17.DataBindings;
			XRBinding[] xRBinding1 = new XRBinding[] { new XRBinding("Text", null, "Query.EmpCode") };
			dataBindings1.AddRange(xRBinding1);
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.LocationFloat = new PointFloat(157.7708f, 25.66665f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel17.SizeF = new System.Drawing.SizeF(163.23f, 23f);
			this.xrLabel17.StylePriority.UseBorders = false;
			this.xrLabel19.Borders = BorderSide.All;
			XRBindingCollection xRBindingCollections1 = this.xrLabel19.DataBindings;
			XRBinding[] xRBindingArray1 = new XRBinding[] { new XRBinding("Text", null, "Query.EmpName") };
			xRBindingCollections1.AddRange(xRBindingArray1);
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.LocationFloat = new PointFloat(157.7708f, 55.12498f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new System.Drawing.SizeF(533.2292f, 23.00001f);
			this.xrLabel19.StylePriority.UseBorders = false;
			this.xrLabel20.Borders = BorderSide.All;
			XRBindingCollection dataBindings2 = this.xrLabel20.DataBindings;
			XRBinding[] xRBinding2 = new XRBinding[] { new XRBinding("Text", null, "Query.NormalWorkHrs") };
			dataBindings2.AddRange(xRBinding2);
			this.xrLabel20.Dpi = 100f;
			this.xrLabel20.LocationFloat = new PointFloat(157.7708f, 144.8334f);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel20.SizeF = new System.Drawing.SizeF(163.23f, 23f);
			this.xrLabel20.StylePriority.UseBorders = false;
			this.xrLabel21.Borders = BorderSide.All;
			XRBindingCollection xRBindingCollections2 = this.xrLabel21.DataBindings;
			XRBinding[] xRBindingArray2 = new XRBinding[] { new XRBinding("Text", null, "Query.RamadanWorkHrs") };
			xRBindingCollections2.AddRange(xRBindingArray2);
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.LocationFloat = new PointFloat(521.3565f, 144.8334f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new System.Drawing.SizeF(169.6434f, 23f);
			this.xrLabel21.StylePriority.UseBorders = false;
			this.xrLabel23.Borders = BorderSide.All;
			XRBindingCollection dataBindings3 = this.xrLabel23.DataBindings;
			XRBinding[] xRBinding3 = new XRBinding[] { new XRBinding("Text", null, "Query.Profession") };
			dataBindings3.AddRange(xRBinding3);
			this.xrLabel23.Dpi = 100f;
			this.xrLabel23.LocationFloat = new PointFloat(157.7708f, 84.45835f);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel23.SizeF = new System.Drawing.SizeF(533.2292f, 23f);
			this.xrLabel23.StylePriority.UseBorders = false;
			this.xrLabel24.Borders = BorderSide.All;
			XRBindingCollection xRBindingCollections3 = this.xrLabel24.DataBindings;
			XRBinding[] xRBindingArray3 = new XRBinding[] { new XRBinding("Text", null, "Query.QID") };
			xRBindingCollections3.AddRange(xRBindingArray3);
			this.xrLabel24.Dpi = 100f;
			this.xrLabel24.LocationFloat = new PointFloat(157.7708f, 114.9584f);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel24.SizeF = new System.Drawing.SizeF(163.23f, 22.99998f);
			this.xrLabel24.StylePriority.UseBorders = false;
			XRControlCollection xRControlCollection = this.TopMargin.Controls;
			XRControl[] xRControlArrays1 = new XRControl[] { this.xrLine2, this.xrLabel1, this.xrLabel3, this.xrPictureBox1, this.xrLabel5, this.xrLabel10, this.xrLabel13, this.xrLine1, this.xrLabel14 };
			xRControlCollection.AddRange(xRControlArrays1);
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 6f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			XRControlCollection controls1 = this.pageFooterBand1.Controls;
			XRControl[] xRControlArrays2 = new XRControl[] { this.xrPictureBox2, this.xrPageInfo1, this.xrPageInfo2 };
			controls1.AddRange(xRControlArrays2);
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 119.625f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)componentResourceManager.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(136.6667f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new System.Drawing.SizeF(581.3381f, 74.20829f);
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(4.826617f, 93.91664f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(521.3565f, 93.91664f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 6.208324f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(11.99999f, 28.75001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new System.Drawing.SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Employee Information";
			this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
			this.PageHeader.Controls.AddRange(new XRControl[] { this.xrLabel26 });
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 78.125f;
			this.PageHeader.Name = "PageHeader";
			this.EmpID.Description = "EmpID";
			dynamicListLookUpSetting.DataAdapter = null;
			dynamicListLookUpSetting.DataMember = "Query";
			dynamicListLookUpSetting.DataSource = this.sqlDataSource1;
			dynamicListLookUpSetting.DisplayMember = "EmpName";
			dynamicListLookUpSetting.FilterString = null;
			dynamicListLookUpSetting.ValueMember = "EmpID";
			this.EmpID.LookUpSettings = dynamicListLookUpSetting;
			this.EmpID.Name = "EmpID";
			this.EmpID.Type = typeof(int);
			this.EmpID.ValueInfo = "0";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(540.6331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new System.Drawing.SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel1.BackColor = Color.White;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel1.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel1.LocationFloat = new PointFloat(565.9379f, 71.52086f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(249.9936f, 22.99997f);
			this.xrLabel1.StylePriority.UseBackColor = false;
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.StylePriority.UsePadding = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrLabel3.BackColor = Color.White;
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel3.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel3.LocationFloat = new PointFloat(565.9379f, 17.52084f);
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
			this.xrPictureBox1.LocationFloat = new PointFloat(341.0699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new System.Drawing.SizeF(189.2164f, 94.95832f);
			this.xrLabel5.BackColor = Color.White;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel5.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel5.LocationFloat = new PointFloat(565.9379f, 43.47918f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(249.9937f, 22.99997f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			this.xrLabel10.BackColor = Color.White;
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel10.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel10.LocationFloat = new PointFloat(3.964294f, 41.52085f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel10.SizeF = new System.Drawing.SizeF(310.5137f, 25f);
			this.xrLabel10.StylePriority.UseBackColor = false;
			this.xrLabel10.StylePriority.UseFont = false;
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UsePadding = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLabel13.BackColor = Color.White;
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel13.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel13.LocationFloat = new PointFloat(3.964294f, 66.52084f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel13.SizeF = new System.Drawing.SizeF(288.8611f, 24f);
			this.xrLabel13.StylePriority.UseBackColor = false;
			this.xrLabel13.StylePriority.UseFont = false;
			this.xrLabel13.StylePriority.UseForeColor = false;
			this.xrLabel13.StylePriority.UsePadding = false;
			this.xrLabel13.StylePriority.UseTextAlignment = false;
			this.xrLabel13.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(4.826614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new System.Drawing.SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel14.BackColor = Color.White;
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel14.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel14.LocationFloat = new PointFloat(3.964294f, 17.52084f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel14.SizeF = new System.Drawing.SizeF(285.9722f, 24f);
			this.xrLabel14.StylePriority.UseBackColor = false;
			this.xrLabel14.StylePriority.UseFont = false;
			this.xrLabel14.StylePriority.UseForeColor = false;
			this.xrLabel14.StylePriority.UsePadding = false;
			this.xrLabel14.StylePriority.UseTextAlignment = false;
			this.xrLabel14.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			BandCollection bands = base.Bands;
			DevExpress.XtraReports.UI.Band[] detail = new DevExpress.XtraReports.UI.Band[] { this.Detail, this.TopMargin, this.BottomMargin, this.pageFooterBand1, this.reportHeaderBand1, this.PageHeader };
			bands.AddRange(detail);
			base.ComponentStorage.AddRange(new IComponent[] { this.sqlDataSource1 });
			base.DataMember = "Query";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[EmpID] = ?EmpID";
			base.Margins = new System.Drawing.Printing.Margins(5, 0, 130, 6);
			ParameterCollection parameters = base.Parameters;
			Parameter[] empID = new Parameter[] { this.EmpID, this.FilterExpression };
			parameters.AddRange(empID);
			XRControlStyleSheet styleSheet = base.StyleSheet;
			XRControlStyle[] title = new XRControlStyle[] { this.Title, this.FieldCaption, this.PageInfo, this.DataField };
			styleSheet.AddRange(title);
			base.Version = "16.1";
			((ISupportInitialize)this).EndInit();
		}
	}
}