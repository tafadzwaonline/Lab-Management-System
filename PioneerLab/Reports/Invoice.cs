//using System;
//using System.ComponentModel;
//using System.Drawing;
//using System.Drawing.Printing;
//using DevExpress.DataAccess.Sql;
//using DevExpress.Utils;
//using DevExpress.XtraPrinting;
//using DevExpress.XtraReports.Parameters;
//using DevExpress.XtraReports.UI;

//namespace PioneerLab.Reports
//{
//	// Token: 0x02000058 RID: 88
//	public class Invoice : XtraReport
//	{
//		// Token: 0x06000337 RID: 823 RVA: 0x00003FE1 File Offset: 0x000021E1
//		public Invoice()
//		{
//			this.InitializeComponent();
//		}

//		// Token: 0x06000338 RID: 824 RVA: 0x00003FEF File Offset: 0x000021EF
//		protected override void Dispose(bool disposing)
//		{
//			if (disposing && this.components != null)
//			{
//				this.components.Dispose();
//			}
//			base.Dispose(disposing);
//		}

//		// Token: 0x06000339 RID: 825 RVA: 0x000290F4 File Offset: 0x000272F4
//		private void InitializeComponent()
//		{
//			this.components = new Container();
//			SelectQuery selectQuery = new SelectQuery();
//			Column column = new Column();
//			ColumnExpression columnExpression = new ColumnExpression();
//			Table table = new Table();
//			Column column2 = new Column();
//			ColumnExpression columnExpression2 = new ColumnExpression();
//			Column column3 = new Column();
//			ColumnExpression columnExpression3 = new ColumnExpression();
//			Column column4 = new Column();
//			ColumnExpression columnExpression4 = new ColumnExpression();
//			Column column5 = new Column();
//			ColumnExpression columnExpression5 = new ColumnExpression();
//			Column column6 = new Column();
//			ColumnExpression columnExpression6 = new ColumnExpression();
//			Column column7 = new Column();
//			ColumnExpression columnExpression7 = new ColumnExpression();
//			Column column8 = new Column();
//			ColumnExpression columnExpression8 = new ColumnExpression();
//			Column column9 = new Column();
//			ColumnExpression columnExpression9 = new ColumnExpression();
//			Column column10 = new Column();
//			ColumnExpression columnExpression10 = new ColumnExpression();
//			Column column11 = new Column();
//			ColumnExpression columnExpression11 = new ColumnExpression();
//			Column column12 = new Column();
//			ColumnExpression columnExpression12 = new ColumnExpression();
//			Table table2 = new Table();
//			Column column13 = new Column();
//			ColumnExpression columnExpression13 = new ColumnExpression();
//			Table table3 = new Table();
//			Column column14 = new Column();
//			ColumnExpression columnExpression14 = new ColumnExpression();
//			Column column15 = new Column();
//			ColumnExpression columnExpression15 = new ColumnExpression();
//			Column column16 = new Column();
//			ColumnExpression columnExpression16 = new ColumnExpression();
//			Column column17 = new Column();
//			ColumnExpression columnExpression17 = new ColumnExpression();
//			Column column18 = new Column();
//			ColumnExpression columnExpression18 = new ColumnExpression();
//			Table table4 = new Table();
//			Join join = new Join();
//			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
//			Join join2 = new Join();
//			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
//			Join join3 = new Join();
//			RelationColumnInfo relationColumnInfo3 = new RelationColumnInfo();
//			Join join4 = new Join();
//			RelationColumnInfo relationColumnInfo4 = new RelationColumnInfo();
//			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
//			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Invoice));
//			CustomSqlQuery customSqlQuery2 = new CustomSqlQuery();
//			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
//			RelationColumnInfo relationColumnInfo5 = new RelationColumnInfo();
//			MasterDetailInfo masterDetailInfo2 = new MasterDetailInfo();
//			RelationColumnInfo relationColumnInfo6 = new RelationColumnInfo();
//			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
//			this.sqlDataSource1 = new SqlDataSource(this.components);
//			this.Detail = new DetailBand();
//			this.xrTable1 = new XRTable();
//			this.xrTableRow1 = new XRTableRow();
//			this.xrTableCell1 = new XRTableCell();
//			this.xrTableRow2 = new XRTableRow();
//			this.xrTableCell2 = new XRTableCell();
//			this.xrTableRow4 = new XRTableRow();
//			this.xrTableCell21 = new XRTableCell();
//			this.xrTableRow7 = new XRTableRow();
//			this.xrTableCell22 = new XRTableCell();
//			this.xrTableRow9 = new XRTableRow();
//			this.xrTableCell24 = new XRTableCell();
//			this.xrTableRow8 = new XRTableRow();
//			this.xrTableCell23 = new XRTableCell();
//			this.xrLabel3 = new XRLabel();
//			this.xrLabel5 = new XRLabel();
//			this.xrLabel15 = new XRLabel();
//			this.xrLabel16 = new XRLabel();
//			this.xrLabel17 = new XRLabel();
//			this.xrLabel18 = new XRLabel();
//			this.TopMargin = new TopMarginBand();
//			this.xrLabel2 = new XRLabel();
//			this.xrLabel9 = new XRLabel();
//			this.xrLabel1 = new XRLabel();
//			this.xrLabel6 = new XRLabel();
//			this.xrLabel8 = new XRLabel();
//			this.xrLabel22 = new XRLabel();
//			this.xrLabel20 = new XRLabel();
//			this.BottomMargin = new BottomMarginBand();
//			this.pageFooterBand1 = new PageFooterBand();
//			this.reportHeaderBand1 = new ReportHeaderBand();
//			this.Title = new XRControlStyle();
//			this.FieldCaption = new XRControlStyle();
//			this.PageInfo = new XRControlStyle();
//			this.DataField = new XRControlStyle();
//			this.DetailReport = new DetailReportBand();
//			this.Detail1 = new DetailBand();
//			this.xrTable3 = new XRTable();
//			this.xrTableRow5 = new XRTableRow();
//			this.xrTableCell4 = new XRTableCell();
//			this.xrTableCell9 = new XRTableCell();
//			this.xrTableCell10 = new XRTableCell();
//			this.xrTableCell11 = new XRTableCell();
//			this.xrTableCell12 = new XRTableCell();
//			this.xrTableCell13 = new XRTableCell();
//			this.GroupHeader1 = new GroupHeaderBand();
//			this.xrTable4 = new XRTable();
//			this.xrTableRow6 = new XRTableRow();
//			this.xrTableCell3 = new XRTableCell();
//			this.xrTableCell14 = new XRTableCell();
//			this.xrTableCell15 = new XRTableCell();
//			this.xrTableCell16 = new XRTableCell();
//			this.xrTableCell17 = new XRTableCell();
//			this.xrTableCell18 = new XRTableCell();
//			this.DetailReport2 = new DetailReportBand();
//			this.Detail3 = new DetailBand();
//			this.xrTable2 = new XRTable();
//			this.xrTableRow3 = new XRTableRow();
//			this.xrTableCell5 = new XRTableCell();
//			this.xrTableCell6 = new XRTableCell();
//			this.xrTableCell7 = new XRTableCell();
//			this.xrTableCell8 = new XRTableCell();
//			this.xrTableCell19 = new XRTableCell();
//			this.xrTableCell20 = new XRTableCell();
//			this.DetailReport1 = new DetailReportBand();
//			this.Detail2 = new DetailBand();
//			this.xrLabel21 = new XRLabel();
//			this.xrLabel19 = new XRLabel();
//			this.InvoiceID = new Parameter();
//			this.JONumber = new CalculatedField();
//			this.WONumber = new CalculatedField();
//			this.xrLabel4 = new XRLabel();
//			this.xrLabel7 = new XRLabel();
//			this.xrLabel10 = new XRLabel();
//			this.xrLabel11 = new XRLabel();
//			((ISupportInitialize)this.xrTable1).BeginInit();
//			((ISupportInitialize)this.xrTable3).BeginInit();
//			((ISupportInitialize)this.xrTable4).BeginInit();
//			((ISupportInitialize)this.xrTable2).BeginInit();
//			((ISupportInitialize)this).BeginInit();
//			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
//			this.sqlDataSource1.Name = "sqlDataSource1";
//			columnExpression.ColumnName = "InvoiceId";
//			table.MetaSerializable = "30|30|125|300";
//			table.Name = "Invoice";
//			columnExpression.Table = table;
//			column.Expression = columnExpression;
//			columnExpression2.ColumnName = "InvoiceNumber";
//			columnExpression2.Table = table;
//			column2.Expression = columnExpression2;
//			columnExpression3.ColumnName = "InvoiceDate";
//			columnExpression3.Table = table;
//			column3.Expression = columnExpression3;
//			columnExpression4.ColumnName = "InvoiceRefNo";
//			columnExpression4.Table = table;
//			column4.Expression = columnExpression4;
//			columnExpression5.ColumnName = "FKJobOrderMasterID";
//			columnExpression5.Table = table;
//			column5.Expression = columnExpression5;
//			columnExpression6.ColumnName = "SRTTotal";
//			columnExpression6.Table = table;
//			column6.Expression = columnExpression6;
//			columnExpression7.ColumnName = "TSTotal";
//			columnExpression7.Table = table;
//			column7.Expression = columnExpression7;
//			columnExpression8.ColumnName = "InvoiceTotal";
//			columnExpression8.Table = table;
//			column8.Expression = columnExpression8;
//			columnExpression9.ColumnName = "Disount";
//			columnExpression9.Table = table;
//			column9.Expression = columnExpression9;
//			columnExpression10.ColumnName = "NetAmount";
//			columnExpression10.Table = table;
//			column10.Expression = columnExpression10;
//			columnExpression11.ColumnName = "ProvideDescription";
//			columnExpression11.Table = table;
//			column11.Expression = columnExpression11;
//			columnExpression12.ColumnName = "CustomerName";
//			table2.MetaSerializable = "340|30|125|300";
//			table2.Name = "CustomersList";
//			columnExpression12.Table = table2;
//			column12.Expression = columnExpression12;
//			columnExpression13.ColumnName = "PaymentTerms";
//			table3.MetaSerializable = "495|30|125|360";
//			table3.Name = "QuotationMaster";
//			columnExpression13.Table = table3;
//			column13.Expression = columnExpression13;
//			columnExpression14.ColumnName = "PhoneNumber";
//			columnExpression14.Table = table2;
//			column14.Expression = columnExpression14;
//			columnExpression15.ColumnName = "FaxNumber";
//			columnExpression15.Table = table2;
//			column15.Expression = columnExpression15;
//			columnExpression16.ColumnName = "Email";
//			columnExpression16.Table = table2;
//			column16.Expression = columnExpression16;
//			columnExpression17.ColumnName = "Address";
//			columnExpression17.Table = table2;
//			column17.Expression = columnExpression17;
//			columnExpression18.ColumnName = "JobOrderNumber";
//			table4.MetaSerializable = "185|30|125|360";
//			table4.Name = "JobOrderMaster";
//			columnExpression18.Table = table4;
//			column18.Expression = columnExpression18;
//			selectQuery.Columns.Add(column);
//			selectQuery.Columns.Add(column2);
//			selectQuery.Columns.Add(column3);
//			selectQuery.Columns.Add(column4);
//			selectQuery.Columns.Add(column5);
//			selectQuery.Columns.Add(column6);
//			selectQuery.Columns.Add(column7);
//			selectQuery.Columns.Add(column8);
//			selectQuery.Columns.Add(column9);
//			selectQuery.Columns.Add(column10);
//			selectQuery.Columns.Add(column11);
//			selectQuery.Columns.Add(column12);
//			selectQuery.Columns.Add(column13);
//			selectQuery.Columns.Add(column14);
//			selectQuery.Columns.Add(column15);
//			selectQuery.Columns.Add(column16);
//			selectQuery.Columns.Add(column17);
//			selectQuery.Columns.Add(column18);
//			selectQuery.Name = "Invoice";
//			relationColumnInfo.NestedKeyColumn = "JobOrderMasterID";
//			relationColumnInfo.ParentKeyColumn = "FKJobOrderMasterID";
//			join.KeyColumns.Add(relationColumnInfo);
//			join.Nested = table4;
//			join.Parent = table;
//			relationColumnInfo2.NestedKeyColumn = "CustomerID";
//			relationColumnInfo2.ParentKeyColumn = "FKCustomerID";
//			join2.KeyColumns.Add(relationColumnInfo2);
//			join2.Nested = table2;
//			join2.Parent = table4;
//			relationColumnInfo3.NestedKeyColumn = "FKCustomerID";
//			relationColumnInfo3.ParentKeyColumn = "CustomerID";
//			join3.KeyColumns.Add(relationColumnInfo3);
//			join3.Nested = table3;
//			join3.Parent = table2;
//			relationColumnInfo4.NestedKeyColumn = "QuotationMasterID";
//			relationColumnInfo4.ParentKeyColumn = "FKQuotationMasterID";
//			join4.KeyColumns.Add(relationColumnInfo4);
//			join4.Nested = table3;
//			join4.Parent = table4;
//			selectQuery.Relations.Add(join);
//			selectQuery.Relations.Add(join2);
//			selectQuery.Relations.Add(join3);
//			selectQuery.Relations.Add(join4);
//			selectQuery.Tables.Add(table);
//			selectQuery.Tables.Add(table4);
//			selectQuery.Tables.Add(table2);
//			selectQuery.Tables.Add(table3);
//			customSqlQuery.Name = "SampleReceiveTestInvoice";
//			customSqlQuery.Sql = componentResourceManager.GetString("customSqlQuery1.Sql");
//			customSqlQuery2.Name = "WorkOrderList";
//			customSqlQuery2.Sql = componentResourceManager.GetString("customSqlQuery2.Sql");
//			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
//			{
//				selectQuery,
//				customSqlQuery,
//				customSqlQuery2
//			});
//			masterDetailInfo.DetailQueryName = "SampleReceiveTestInvoice";
//			relationColumnInfo5.NestedKeyColumn = "InvoiceId";
//			relationColumnInfo5.ParentKeyColumn = "InvoiceId";
//			masterDetailInfo.KeyColumns.Add(relationColumnInfo5);
//			masterDetailInfo.MasterQueryName = "Invoice";
//			masterDetailInfo2.DetailQueryName = "WorkOrderList";
//			relationColumnInfo6.NestedKeyColumn = "InvoiceId";
//			relationColumnInfo6.ParentKeyColumn = "InvoiceId";
//			masterDetailInfo2.KeyColumns.Add(relationColumnInfo6);
//			masterDetailInfo2.MasterQueryName = "Invoice";
//			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
//			{
//				masterDetailInfo,
//				masterDetailInfo2
//			});
//			this.sqlDataSource1.ResultSchemaSerializable = componentResourceManager.GetString("sqlDataSource1.ResultSchemaSerializable");
//			this.Detail.Controls.AddRange(new XRControl[]
//			{
//				this.xrTable1,
//				this.xrLabel3,
//				this.xrLabel5,
//				this.xrLabel15,
//				this.xrLabel16,
//				this.xrLabel17,
//				this.xrLabel18
//			});
//			this.Detail.Dpi = 100f;
//			this.Detail.HeightF = 196.0834f;
//			this.Detail.KeepTogether = true;
//			this.Detail.KeepTogetherWithDetailReports = true;
//			this.Detail.Name = "Detail";
//			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
//			this.Detail.PageBreak = PageBreak.BeforeBand;
//			this.Detail.TextAlignment = TextAlignment.TopLeft;
//			this.xrTable1.Borders = BorderSide.All;
//			this.xrTable1.Dpi = 100f;
//			this.xrTable1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrTable1.LocationFloat = new PointFloat(30.55554f, 11.4584f);
//			this.xrTable1.Name = "xrTable1";
//			this.xrTable1.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
//			this.xrTable1.Rows.AddRange(new XRTableRow[]
//			{
//				this.xrTableRow1,
//				this.xrTableRow2,
//				this.xrTableRow4,
//				this.xrTableRow7,
//				this.xrTableRow9,
//				this.xrTableRow8
//			});
//			this.xrTable1.SizeF = new SizeF(440.625f, 130.9634f);
//			this.xrTable1.StylePriority.UseBorders = false;
//			this.xrTable1.StylePriority.UseFont = false;
//			this.xrTable1.StylePriority.UsePadding = false;
//			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell1
//			});
//			this.xrTableRow1.Dpi = 100f;
//			this.xrTableRow1.Name = "xrTableRow1";
//			this.xrTableRow1.Weight = 2.230034235914813;
//			this.xrTableCell1.BackColor = Color.Gainsboro;
//			this.xrTableCell1.Dpi = 100f;
//			this.xrTableCell1.Name = "xrTableCell1";
//			this.xrTableCell1.StylePriority.UseBackColor = false;
//			this.xrTableCell1.Text = "Bill To:";
//			this.xrTableCell1.Weight = 1.0;
//			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell2
//			});
//			this.xrTableRow2.Dpi = 100f;
//			this.xrTableRow2.Name = "xrTableRow2";
//			this.xrTableRow2.Weight = 2.3116326342023745;
//			this.xrTableCell2.Borders = (BorderSide.Left | BorderSide.Right);
//			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.CustomerName")
//			});
//			this.xrTableCell2.Dpi = 100f;
//			this.xrTableCell2.Name = "xrTableCell2";
//			this.xrTableCell2.StylePriority.UseBorders = false;
//			this.xrTableCell2.Weight = 1.0;
//			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell21
//			});
//			this.xrTableRow4.Dpi = 100f;
//			this.xrTableRow4.Name = "xrTableRow4";
//			this.xrTableRow4.Weight = 2.3116326342023745;
//			this.xrTableCell21.Borders = (BorderSide.Left | BorderSide.Right);
//			this.xrTableCell21.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.Address")
//			});
//			this.xrTableCell21.Dpi = 100f;
//			this.xrTableCell21.Name = "xrTableCell21";
//			this.xrTableCell21.StylePriority.UseBorders = false;
//			this.xrTableCell21.Weight = 1.0;
//			this.xrTableRow7.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell22
//			});
//			this.xrTableRow7.Dpi = 100f;
//			this.xrTableRow7.Name = "xrTableRow7";
//			this.xrTableRow7.Weight = 2.3116326342023745;
//			this.xrTableCell22.Borders = (BorderSide.Left | BorderSide.Right);
//			this.xrTableCell22.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.Email")
//			});
//			this.xrTableCell22.Dpi = 100f;
//			this.xrTableCell22.Name = "xrTableCell22";
//			this.xrTableCell22.StylePriority.UseBorders = false;
//			this.xrTableCell22.Weight = 1.0;
//			this.xrTableRow9.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell24
//			});
//			this.xrTableRow9.Dpi = 100f;
//			this.xrTableRow9.Name = "xrTableRow9";
//			this.xrTableRow9.Weight = 2.3116326342023745;
//			this.xrTableCell24.Borders = (BorderSide.Left | BorderSide.Right);
//			this.xrTableCell24.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.PhoneNumber")
//			});
//			this.xrTableCell24.Dpi = 100f;
//			this.xrTableCell24.Name = "xrTableCell24";
//			this.xrTableCell24.StylePriority.UseBorders = false;
//			this.xrTableCell24.Weight = 1.0;
//			this.xrTableRow8.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell23
//			});
//			this.xrTableRow8.Dpi = 100f;
//			this.xrTableRow8.Name = "xrTableRow8";
//			this.xrTableRow8.Weight = 2.3116326342023745;
//			this.xrTableCell23.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
//			this.xrTableCell23.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.FaxNumber")
//			});
//			this.xrTableCell23.Dpi = 100f;
//			this.xrTableCell23.Name = "xrTableCell23";
//			this.xrTableCell23.StylePriority.UseBorders = false;
//			this.xrTableCell23.Weight = 1.0;
//			this.xrLabel3.BackColor = Color.Gainsboro;
//			this.xrLabel3.Borders = BorderSide.All;
//			this.xrLabel3.Dpi = 100f;
//			this.xrLabel3.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrLabel3.LocationFloat = new PointFloat(29.505f, 154.7916f);
//			this.xrLabel3.Name = "xrLabel3";
//			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel3.SizeF = new SizeF(259.1894f, 20.64583f);
//			this.xrLabel3.StylePriority.UseBackColor = false;
//			this.xrLabel3.StylePriority.UseBorders = false;
//			this.xrLabel3.StylePriority.UseFont = false;
//			this.xrLabel3.StylePriority.UsePadding = false;
//			this.xrLabel3.StylePriority.UseTextAlignment = false;
//			this.xrLabel3.Text = "Customer ID";
//			this.xrLabel3.TextAlignment = TextAlignment.TopCenter;
//			this.xrLabel5.BackColor = Color.Gainsboro;
//			this.xrLabel5.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
//			this.xrLabel5.Dpi = 100f;
//			this.xrLabel5.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrLabel5.LocationFloat = new PointFloat(288.8194f, 154.7916f);
//			this.xrLabel5.Name = "xrLabel5";
//			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel5.SizeF = new SizeF(257.5545f, 20.64583f);
//			this.xrLabel5.StylePriority.UseBackColor = false;
//			this.xrLabel5.StylePriority.UseBorders = false;
//			this.xrLabel5.StylePriority.UseFont = false;
//			this.xrLabel5.StylePriority.UsePadding = false;
//			this.xrLabel5.StylePriority.UseTextAlignment = false;
//			this.xrLabel5.Text = "Customer PO";
//			this.xrLabel5.TextAlignment = TextAlignment.TopCenter;
//			this.xrLabel15.BackColor = Color.Gainsboro;
//			this.xrLabel15.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
//			this.xrLabel15.Dpi = 100f;
//			this.xrLabel15.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrLabel15.LocationFloat = new PointFloat(546.4989f, 154.7918f);
//			this.xrLabel15.Name = "xrLabel15";
//			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel15.SizeF = new SizeF(278.1797f, 20.64584f);
//			this.xrLabel15.StylePriority.UseBackColor = false;
//			this.xrLabel15.StylePriority.UseBorders = false;
//			this.xrLabel15.StylePriority.UseFont = false;
//			this.xrLabel15.StylePriority.UsePadding = false;
//			this.xrLabel15.StylePriority.UseTextAlignment = false;
//			this.xrLabel15.Text = "Payment Terms";
//			this.xrLabel15.TextAlignment = TextAlignment.TopCenter;
//			this.xrLabel16.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
//			this.xrLabel16.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.CustomerName")
//			});
//			this.xrLabel16.Dpi = 100f;
//			this.xrLabel16.LocationFloat = new PointFloat(29.37842f, 175.4375f);
//			this.xrLabel16.Name = "xrLabel16";
//			this.xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel16.SizeF = new SizeF(259.4409f, 20.64583f);
//			this.xrLabel16.StylePriority.UseBorders = false;
//			this.xrLabel16.StylePriority.UsePadding = false;
//			this.xrLabel16.StylePriority.UseTextAlignment = false;
//			this.xrLabel16.Text = "xrLabel16";
//			this.xrLabel16.TextAlignment = TextAlignment.TopCenter;
//			this.xrLabel17.Borders = (BorderSide.Right | BorderSide.Bottom);
//			this.xrLabel17.Dpi = 100f;
//			this.xrLabel17.LocationFloat = new PointFloat(288.9444f, 175.4375f);
//			this.xrLabel17.Name = "xrLabel17";
//			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel17.SizeF = new SizeF(257.4295f, 20.64583f);
//			this.xrLabel17.StylePriority.UseBorders = false;
//			this.xrLabel17.StylePriority.UsePadding = false;
//			this.xrLabel17.StylePriority.UseTextAlignment = false;
//			this.xrLabel17.TextAlignment = TextAlignment.TopCenter;
//			this.xrLabel18.Borders = (BorderSide.Right | BorderSide.Bottom);
//			this.xrLabel18.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.PaymentTerms")
//			});
//			this.xrLabel18.Dpi = 100f;
//			this.xrLabel18.LocationFloat = new PointFloat(546.4989f, 175.4375f);
//			this.xrLabel18.Name = "xrLabel18";
//			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel18.SizeF = new SizeF(278.3888f, 20.64584f);
//			this.xrLabel18.StylePriority.UseBorders = false;
//			this.xrLabel18.StylePriority.UsePadding = false;
//			this.xrLabel18.StylePriority.UseTextAlignment = false;
//			this.xrLabel18.TextAlignment = TextAlignment.TopCenter;
//			this.TopMargin.Controls.AddRange(new XRControl[]
//			{
//				this.xrLabel2,
//				this.xrLabel9,
//				this.xrLabel1,
//				this.xrLabel6,
//				this.xrLabel8,
//				this.xrLabel22,
//				this.xrLabel20
//			});
//			this.TopMargin.Dpi = 100f;
//			this.TopMargin.Font = new Font("Traditional Arabic", 9.75f);
//			this.TopMargin.HeightF = 109.5833f;
//			this.TopMargin.Name = "TopMargin";
//			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
//			this.TopMargin.StylePriority.UseFont = false;
//			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
//			this.xrLabel2.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.JobOrderNumber", "{0:dd MMM yyyy}")
//			});
//			this.xrLabel2.Dpi = 100f;
//			this.xrLabel2.LocationFloat = new PointFloat(650.2617f, 88.33334f);
//			this.xrLabel2.Name = "xrLabel2";
//			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel2.SizeF = new SizeF(147.2084f, 18f);
//			this.xrLabel2.StyleName = "DataField";
//			this.xrLabel9.Dpi = 100f;
//			this.xrLabel9.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel9.LocationFloat = new PointFloat(536.5832f, 88.33334f);
//			this.xrLabel9.Name = "xrLabel9";
//			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel9.SizeF = new SizeF(113.6785f, 18f);
//			this.xrLabel9.StyleName = "FieldCaption";
//			this.xrLabel9.StylePriority.UseForeColor = false;
//			this.xrLabel9.Text = "Job Order No:";
//			this.xrLabel1.Dpi = 100f;
//			this.xrLabel1.Font = new Font("Arial", 36f, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
//			this.xrLabel1.ForeColor = Color.FromArgb(126, 126, 126);
//			this.xrLabel1.LocationFloat = new PointFloat(269.5137f, 28.00001f);
//			this.xrLabel1.Name = "xrLabel1";
//			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel1.SizeF = new SizeF(237.2084f, 61.74999f);
//			this.xrLabel1.StyleName = "FieldCaption";
//			this.xrLabel1.StylePriority.UseFont = false;
//			this.xrLabel1.StylePriority.UseForeColor = false;
//			this.xrLabel1.Text = "INVOICE";
//			this.xrLabel6.Dpi = 100f;
//			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel6.LocationFloat = new PointFloat(536.4582f, 65.33334f);
//			this.xrLabel6.Name = "xrLabel6";
//			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel6.SizeF = new SizeF(94.29169f, 18f);
//			this.xrLabel6.StyleName = "FieldCaption";
//			this.xrLabel6.StylePriority.UseForeColor = false;
//			this.xrLabel6.Text = "Invoice Date:";
//			this.xrLabel8.Dpi = 100f;
//			this.xrLabel8.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel8.LocationFloat = new PointFloat(536.4582f, 41.54167f);
//			this.xrLabel8.Name = "xrLabel8";
//			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel8.SizeF = new SizeF(116.8333f, 18f);
//			this.xrLabel8.StyleName = "FieldCaption";
//			this.xrLabel8.StylePriority.UseForeColor = false;
//			this.xrLabel8.Text = "Invoice Number:";
//			this.xrLabel22.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceNumber")
//			});
//			this.xrLabel22.Dpi = 100f;
//			this.xrLabel22.LocationFloat = new PointFloat(653.2915f, 41.54167f);
//			this.xrLabel22.Name = "xrLabel22";
//			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel22.SizeF = new SizeF(108.5f, 18f);
//			this.xrLabel22.StyleName = "DataField";
//			this.xrLabel22.Text = "xrLabel22";
//			this.xrLabel20.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceDate", "{0:dd MMM yyyy}")
//			});
//			this.xrLabel20.Dpi = 100f;
//			this.xrLabel20.LocationFloat = new PointFloat(650.2618f, 65.33334f);
//			this.xrLabel20.Name = "xrLabel20";
//			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel20.SizeF = new SizeF(147.2084f, 18f);
//			this.xrLabel20.StyleName = "DataField";
//			this.xrLabel20.Text = "xrLabel20";
//			this.BottomMargin.Controls.AddRange(new XRControl[]
//			{
//				this.xrLabel11,
//				this.xrLabel10,
//				this.xrLabel7,
//				this.xrLabel4
//			});
//			this.BottomMargin.Dpi = 100f;
//			this.BottomMargin.HeightF = 72.91666f;
//			this.BottomMargin.Name = "BottomMargin";
//			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
//			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
//			this.pageFooterBand1.Dpi = 100f;
//			this.pageFooterBand1.HeightF = 0f;
//			this.pageFooterBand1.Name = "pageFooterBand1";
//			this.reportHeaderBand1.Dpi = 100f;
//			this.reportHeaderBand1.HeightF = 3.083324f;
//			this.reportHeaderBand1.Name = "reportHeaderBand1";
//			this.Title.BackColor = Color.Transparent;
//			this.Title.BorderColor = Color.Black;
//			this.Title.Borders = BorderSide.None;
//			this.Title.BorderWidth = 1f;
//			this.Title.Font = new Font("Times New Roman", 20f, FontStyle.Bold);
//			this.Title.ForeColor = Color.Maroon;
//			this.Title.Name = "Title";
//			this.FieldCaption.BackColor = Color.Transparent;
//			this.FieldCaption.BorderColor = Color.Black;
//			this.FieldCaption.Borders = BorderSide.None;
//			this.FieldCaption.BorderWidth = 1f;
//			this.FieldCaption.Font = new Font("Arial", 10f, FontStyle.Bold);
//			this.FieldCaption.ForeColor = Color.Maroon;
//			this.FieldCaption.Name = "FieldCaption";
//			this.PageInfo.BackColor = Color.Transparent;
//			this.PageInfo.BorderColor = Color.Black;
//			this.PageInfo.Borders = BorderSide.None;
//			this.PageInfo.BorderWidth = 1f;
//			this.PageInfo.Font = new Font("Times New Roman", 10f, FontStyle.Bold);
//			this.PageInfo.ForeColor = Color.Black;
//			this.PageInfo.Name = "PageInfo";
//			this.DataField.BackColor = Color.Transparent;
//			this.DataField.BorderColor = Color.Black;
//			this.DataField.Borders = BorderSide.None;
//			this.DataField.BorderWidth = 1f;
//			this.DataField.Font = new Font("Times New Roman", 10f);
//			this.DataField.ForeColor = Color.Black;
//			this.DataField.Name = "DataField";
//			this.DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.DetailReport.Bands.AddRange(new Band[]
//			{
//				this.Detail1,
//				this.GroupHeader1
//			});
//			this.DetailReport.DataMember = "Invoice.InvoiceSampleReceiveTestInvoice";
//			this.DetailReport.DataSource = this.sqlDataSource1;
//			this.DetailReport.Dpi = 100f;
//			this.DetailReport.Level = 0;
//			this.DetailReport.Name = "DetailReport";
//			this.Detail1.Controls.AddRange(new XRControl[]
//			{
//				this.xrTable3
//			});
//			this.Detail1.Dpi = 100f;
//			this.Detail1.HeightF = 25f;
//			this.Detail1.Name = "Detail1";
//			this.xrTable3.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
//			this.xrTable3.Dpi = 100f;
//			this.xrTable3.LocationFloat = new PointFloat(29.37842f, 0f);
//			this.xrTable3.Name = "xrTable3";
//			this.xrTable3.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
//			this.xrTable3.Rows.AddRange(new XRTableRow[]
//			{
//				this.xrTableRow5
//			});
//			this.xrTable3.SizeF = new SizeF(794.8868f, 25f);
//			this.xrTable3.StylePriority.UseBorders = false;
//			this.xrTable3.StylePriority.UsePadding = false;
//			this.xrTableRow5.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell4,
//				this.xrTableCell9,
//				this.xrTableCell10,
//				this.xrTableCell11,
//				this.xrTableCell12,
//				this.xrTableCell13
//			});
//			this.xrTableRow5.Dpi = 100f;
//			this.xrTableRow5.Name = "xrTableRow5";
//			this.xrTableRow5.Weight = 11.5;
//			this.xrTableCell4.Dpi = 100f;
//			this.xrTableCell4.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrTableCell4.Name = "xrTableCell4";
//			this.xrTableCell4.StylePriority.UseFont = false;
//			this.xrTableCell4.Text = "[JONumber]";
//			this.xrTableCell4.Weight = 0.27176981193497723;
//			this.xrTableCell9.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceSampleReceiveTestInvoice.ProvideDescription")
//			});
//			this.xrTableCell9.Dpi = 100f;
//			this.xrTableCell9.Name = "xrTableCell9";
//			this.xrTableCell9.Weight = 0.585982501021398;
//			this.xrTableCell10.Dpi = 100f;
//			this.xrTableCell10.Name = "xrTableCell10";
//			this.xrTableCell10.Weight = 0.18558069704145005;
//			this.xrTableCell11.Dpi = 100f;
//			this.xrTableCell11.Name = "xrTableCell11";
//			this.xrTableCell11.Weight = 0.15497312919983713;
//			this.xrTableCell12.Dpi = 100f;
//			this.xrTableCell12.Name = "xrTableCell12";
//			this.xrTableCell12.Weight = 0.22687084460359533;
//			this.xrTableCell13.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceSampleReceiveTestInvoice.SRTTotal", "{0:n2}")
//			});
//			this.xrTableCell13.Dpi = 100f;
//			this.xrTableCell13.Name = "xrTableCell13";
//			this.xrTableCell13.Padding = new PaddingInfo(5, 10, 0, 0, 100f);
//			this.xrTableCell13.StylePriority.UsePadding = false;
//			this.xrTableCell13.StylePriority.UseTextAlignment = false;
//			this.xrTableCell13.TextAlignment = TextAlignment.TopRight;
//			this.xrTableCell13.Weight = 0.2607067388278664;
//			this.GroupHeader1.Controls.AddRange(new XRControl[]
//			{
//				this.xrTable4
//			});
//			this.GroupHeader1.Dpi = 100f;
//			this.GroupHeader1.HeightF = 35.00001f;
//			this.GroupHeader1.Name = "GroupHeader1";
//			this.GroupHeader1.RepeatEveryPage = true;
//			this.xrTable4.BackColor = Color.Gainsboro;
//			this.xrTable4.Borders = BorderSide.All;
//			this.xrTable4.Dpi = 100f;
//			this.xrTable4.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrTable4.LocationFloat = new PointFloat(29.37842f, 10.00001f);
//			this.xrTable4.Name = "xrTable4";
//			this.xrTable4.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
//			this.xrTable4.Rows.AddRange(new XRTableRow[]
//			{
//				this.xrTableRow6
//			});
//			this.xrTable4.SizeF = new SizeF(795.1752f, 25f);
//			this.xrTable4.StylePriority.UseBackColor = false;
//			this.xrTable4.StylePriority.UseBorders = false;
//			this.xrTable4.StylePriority.UseFont = false;
//			this.xrTable4.StylePriority.UsePadding = false;
//			this.xrTableRow6.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell3,
//				this.xrTableCell14,
//				this.xrTableCell15,
//				this.xrTableCell16,
//				this.xrTableCell17,
//				this.xrTableCell18
//			});
//			this.xrTableRow6.Dpi = 100f;
//			this.xrTableRow6.Name = "xrTableRow6";
//			this.xrTableRow6.Weight = 11.5;
//			this.xrTableCell3.Dpi = 100f;
//			this.xrTableCell3.Name = "xrTableCell3";
//			this.xrTableCell3.Text = "Items";
//			this.xrTableCell3.Weight = 0.23169373091866735;
//			this.xrTableCell14.Dpi = 100f;
//			this.xrTableCell14.Name = "xrTableCell14";
//			this.xrTableCell14.Text = "Service Description";
//			this.xrTableCell14.Weight = 0.49937634799881603;
//			this.xrTableCell15.Dpi = 100f;
//			this.xrTableCell15.Name = "xrTableCell15";
//			this.xrTableCell15.Text = "Qty";
//			this.xrTableCell15.Weight = 0.15806374148159258;
//			this.xrTableCell16.Dpi = 100f;
//			this.xrTableCell16.Name = "xrTableCell16";
//			this.xrTableCell16.Text = "Unit";
//			this.xrTableCell16.Weight = 0.13212670427602136;
//			this.xrTableCell17.Dpi = 100f;
//			this.xrTableCell17.Name = "xrTableCell17";
//			this.xrTableCell17.Text = "Unit Price";
//			this.xrTableCell17.Weight = 0.19359577011541057;
//			this.xrTableCell18.Dpi = 100f;
//			this.xrTableCell18.Name = "xrTableCell18";
//			this.xrTableCell18.StylePriority.UseBackColor = false;
//			this.xrTableCell18.Text = "Amount";
//			this.xrTableCell18.Weight = 0.22176756035868483;
//			this.DetailReport2.Bands.AddRange(new Band[]
//			{
//				this.Detail3
//			});
//			this.DetailReport2.DataMember = "Invoice.InvoiceWorkOrderList";
//			this.DetailReport2.DataSource = this.sqlDataSource1;
//			this.DetailReport2.Dpi = 100f;
//			this.DetailReport2.Level = 1;
//			this.DetailReport2.Name = "DetailReport2";
//			this.Detail3.Controls.AddRange(new XRControl[]
//			{
//				this.xrTable2
//			});
//			this.Detail3.Dpi = 100f;
//			this.Detail3.HeightF = 25f;
//			this.Detail3.Name = "Detail3";
//			this.xrTable2.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
//			this.xrTable2.Dpi = 100f;
//			this.xrTable2.LocationFloat = new PointFloat(29.38f, 0f);
//			this.xrTable2.Name = "xrTable2";
//			this.xrTable2.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
//			this.xrTable2.Rows.AddRange(new XRTableRow[]
//			{
//				this.xrTableRow3
//			});
//			this.xrTable2.SizeF = new SizeF(795.0118f, 25f);
//			this.xrTable2.StylePriority.UseBorders = false;
//			this.xrTable2.StylePriority.UsePadding = false;
//			this.xrTableRow3.Cells.AddRange(new XRTableCell[]
//			{
//				this.xrTableCell5,
//				this.xrTableCell6,
//				this.xrTableCell7,
//				this.xrTableCell8,
//				this.xrTableCell19,
//				this.xrTableCell20
//			});
//			this.xrTableRow3.Dpi = 100f;
//			this.xrTableRow3.Name = "xrTableRow3";
//			this.xrTableRow3.Weight = 11.5;
//			this.xrTableCell5.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderList.WONumber")
//			});
//			this.xrTableCell5.Dpi = 100f;
//			this.xrTableCell5.Name = "xrTableCell5";
//			this.xrTableCell5.Weight = 0.271765779240925;
//			this.xrTableCell6.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderList.Description")
//			});
//			this.xrTableCell6.Dpi = 100f;
//			this.xrTableCell6.Name = "xrTableCell6";
//			this.xrTableCell6.Weight = 0.585973521838421;
//			this.xrTableCell7.Dpi = 100f;
//			this.xrTableCell7.Name = "xrTableCell7";
//			this.xrTableCell7.Weight = 0.1858429821618165;
//			this.xrTableCell8.Dpi = 100f;
//			this.xrTableCell8.Name = "xrTableCell8";
//			this.xrTableCell8.Weight = 0.15490523600192738;
//			this.xrTableCell19.Dpi = 100f;
//			this.xrTableCell19.Name = "xrTableCell19";
//			this.xrTableCell19.Weight = 0.22692879039817404;
//			this.xrTableCell20.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderList.Amount", "{0:n2}")
//			});
//			this.xrTableCell20.Dpi = 100f;
//			this.xrTableCell20.Name = "xrTableCell20";
//			this.xrTableCell20.Padding = new PaddingInfo(5, 10, 0, 0, 100f);
//			this.xrTableCell20.StylePriority.UsePadding = false;
//			this.xrTableCell20.StylePriority.UseTextAlignment = false;
//			this.xrTableCell20.TextAlignment = TextAlignment.TopRight;
//			this.xrTableCell20.Weight = 0.26070686190194386;
//			this.DetailReport1.Bands.AddRange(new Band[]
//			{
//				this.Detail2
//			});
//			this.DetailReport1.Dpi = 100f;
//			this.DetailReport1.Level = 2;
//			this.DetailReport1.Name = "DetailReport1";
//			this.Detail2.Controls.AddRange(new XRControl[]
//			{
//				this.xrLabel21,
//				this.xrLabel19
//			});
//			this.Detail2.Dpi = 100f;
//			this.Detail2.HeightF = 20.83333f;
//			this.Detail2.Name = "Detail2";
//			this.xrLabel21.BackColor = Color.WhiteSmoke;
//			this.xrLabel21.Borders = BorderSide.All;
//			this.xrLabel21.DataBindings.AddRange(new XRBinding[]
//			{
//				new XRBinding("Text", null, "Invoice.NetAmount", "{0:n2}")
//			});
//			this.xrLabel21.Dpi = 100f;
//			this.xrLabel21.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrLabel21.LocationFloat = new PointFloat(701.8046f, 0.1874924f);
//			this.xrLabel21.Name = "xrLabel21";
//			this.xrLabel21.Padding = new PaddingInfo(2, 10, 0, 0, 100f);
//			this.xrLabel21.SizeF = new SizeF(123.0831f, 20.64583f);
//			this.xrLabel21.StylePriority.UseBackColor = false;
//			this.xrLabel21.StylePriority.UseBorders = false;
//			this.xrLabel21.StylePriority.UseFont = false;
//			this.xrLabel21.StylePriority.UsePadding = false;
//			this.xrLabel21.StylePriority.UseTextAlignment = false;
//			this.xrLabel21.TextAlignment = TextAlignment.TopRight;
//			this.xrLabel19.BackColor = Color.WhiteSmoke;
//			this.xrLabel19.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
//			this.xrLabel19.Dpi = 100f;
//			this.xrLabel19.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
//			this.xrLabel19.LocationFloat = new PointFloat(433.8049f, 0.1874924f);
//			this.xrLabel19.Name = "xrLabel19";
//			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel19.SizeF = new SizeF(268.1248f, 20.64583f);
//			this.xrLabel19.StylePriority.UseBackColor = false;
//			this.xrLabel19.StylePriority.UseBorders = false;
//			this.xrLabel19.StylePriority.UseFont = false;
//			this.xrLabel19.StylePriority.UsePadding = false;
//			this.xrLabel19.StylePriority.UseTextAlignment = false;
//			this.xrLabel19.Text = "TOTAL INVOICE AMOUNT (QAR):";
//			this.xrLabel19.TextAlignment = TextAlignment.TopCenter;
//			this.InvoiceID.Description = "Parameter1";
//			dynamicListLookUpSettings.DataAdapter = null;
//			dynamicListLookUpSettings.DataMember = "Invoice";
//			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
//			dynamicListLookUpSettings.DisplayMember = "InvoiceNumber";
//			dynamicListLookUpSettings.FilterString = null;
//			dynamicListLookUpSettings.ValueMember = "InvoiceId";
//			this.InvoiceID.LookUpSettings = dynamicListLookUpSettings;
//			this.InvoiceID.Name = "InvoiceID";
//			this.InvoiceID.Type = typeof(int);
//			this.InvoiceID.ValueInfo = "0";
//			this.JONumber.DataMember = "Invoice.InvoiceSampleReceiveTestInvoice";
//			this.JONumber.Expression = " ('Job Order :') + [JobOrderNumber]";
//			this.JONumber.Name = "JONumber";
//			this.WONumber.DataMember = "Invoice.InvoiceWorkOrderList";
//			this.WONumber.Expression = "('Work Order : ') + [WorkOrderNo]";
//			this.WONumber.Name = "WONumber";
//			this.xrLabel4.Dpi = 100f;
//			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel4.LocationFloat = new PointFloat(594.6489f, 20.83333f);
//			this.xrLabel4.Name = "xrLabel4";
//			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel4.SizeF = new SizeF(116.8333f, 18f);
//			this.xrLabel4.StyleName = "FieldCaption";
//			this.xrLabel4.StylePriority.UseForeColor = false;
//			this.xrLabel4.Text = "Checked by";
//			this.xrLabel7.Dpi = 100f;
//			this.xrLabel7.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel7.LocationFloat = new PointFloat(101.1667f, 20.83333f);
//			this.xrLabel7.Name = "xrLabel7";
//			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel7.SizeF = new SizeF(116.8333f, 18f);
//			this.xrLabel7.StyleName = "FieldCaption";
//			this.xrLabel7.StylePriority.UseForeColor = false;
//			this.xrLabel7.Text = "Approved by";
//			this.xrLabel10.BorderDashStyle = BorderDashStyle.Dot;
//			this.xrLabel10.Borders = BorderSide.Top;
//			this.xrLabel10.Dpi = 100f;
//			this.xrLabel10.Font = new Font("Arial", 5f, FontStyle.Bold);
//			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel10.LocationFloat = new PointFloat(81.5f, 54.91664f);
//			this.xrLabel10.Name = "xrLabel10";
//			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel10.SizeF = new SizeF(147.8333f, 18f);
//			this.xrLabel10.StyleName = "FieldCaption";
//			this.xrLabel10.StylePriority.UseBorderDashStyle = false;
//			this.xrLabel10.StylePriority.UseBorders = false;
//			this.xrLabel10.StylePriority.UseFont = false;
//			this.xrLabel10.StylePriority.UseForeColor = false;
//			this.xrLabel11.BorderDashStyle = BorderDashStyle.Dot;
//			this.xrLabel11.Borders = BorderSide.Top;
//			this.xrLabel11.Dpi = 100f;
//			this.xrLabel11.Font = new Font("Arial Narrow", 2.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
//			this.xrLabel11.ForeColor = Color.FromArgb(0, 0, 0);
//			this.xrLabel11.LocationFloat = new PointFloat(578.9995f, 54.91664f);
//			this.xrLabel11.Name = "xrLabel11";
//			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
//			this.xrLabel11.SizeF = new SizeF(143.6666f, 18f);
//			this.xrLabel11.StyleName = "FieldCaption";
//			this.xrLabel11.StylePriority.UseBorderDashStyle = false;
//			this.xrLabel11.StylePriority.UseBorders = false;
//			this.xrLabel11.StylePriority.UseFont = false;
//			this.xrLabel11.StylePriority.UseForeColor = false;
//			base.Bands.AddRange(new Band[]
//			{
//				this.Detail,
//				this.TopMargin,
//				this.BottomMargin,
//				this.pageFooterBand1,
//				this.reportHeaderBand1,
//				this.DetailReport,
//				this.DetailReport2,
//				this.DetailReport1
//			});
//			base.CalculatedFields.AddRange(new CalculatedField[]
//			{
//				this.JONumber,
//				this.WONumber
//			});
//			base.ComponentStorage.AddRange(new IComponent[]
//			{
//				this.sqlDataSource1
//			});
//			base.DataMember = "Invoice";
//			base.DataSource = this.sqlDataSource1;
//			this.FilterString = "[InvoiceId] = ?InvoiceID";
//			base.Margins = new Margins(3, 1, 110, 73);
//			base.Parameters.AddRange(new Parameter[]
//			{
//				this.InvoiceID
//			});
//			base.StyleSheet.AddRange(new XRControlStyle[]
//			{
//				this.Title,
//				this.FieldCaption,
//				this.PageInfo,
//				this.DataField
//			});
//			base.Version = "18.2";
//			((ISupportInitialize)this.xrTable1).EndInit();
//			((ISupportInitialize)this.xrTable3).EndInit();
//			((ISupportInitialize)this.xrTable4).EndInit();
//			((ISupportInitialize)this.xrTable2).EndInit();
//			((ISupportInitialize)this).EndInit();
//		}

//		// Token: 0x04000655 RID: 1621
//		private IContainer components;

//		// Token: 0x04000656 RID: 1622
//		private DetailBand Detail;

//		// Token: 0x04000657 RID: 1623
//		private TopMarginBand TopMargin;

//		// Token: 0x04000658 RID: 1624
//		private BottomMarginBand BottomMargin;

//		// Token: 0x04000659 RID: 1625
//		private XRTable xrTable1;

//		// Token: 0x0400065A RID: 1626
//		private XRTableRow xrTableRow1;

//		// Token: 0x0400065B RID: 1627
//		private XRTableCell xrTableCell1;

//		// Token: 0x0400065C RID: 1628
//		private XRTableRow xrTableRow2;

//		// Token: 0x0400065D RID: 1629
//		private XRTableCell xrTableCell2;

//		// Token: 0x0400065E RID: 1630
//		private XRLabel xrLabel1;

//		// Token: 0x0400065F RID: 1631
//		private XRLabel xrLabel6;

//		// Token: 0x04000660 RID: 1632
//		private XRLabel xrLabel8;

//		// Token: 0x04000661 RID: 1633
//		private XRLabel xrLabel22;

//		// Token: 0x04000662 RID: 1634
//		private XRLabel xrLabel20;

//		// Token: 0x04000663 RID: 1635
//		private SqlDataSource sqlDataSource1;

//		// Token: 0x04000664 RID: 1636
//		private PageFooterBand pageFooterBand1;

//		// Token: 0x04000665 RID: 1637
//		private ReportHeaderBand reportHeaderBand1;

//		// Token: 0x04000666 RID: 1638
//		private XRControlStyle Title;

//		// Token: 0x04000667 RID: 1639
//		private XRControlStyle FieldCaption;

//		// Token: 0x04000668 RID: 1640
//		private XRControlStyle PageInfo;

//		// Token: 0x04000669 RID: 1641
//		private XRControlStyle DataField;

//		// Token: 0x0400066A RID: 1642
//		private DetailReportBand DetailReport;

//		// Token: 0x0400066B RID: 1643
//		private DetailBand Detail1;

//		// Token: 0x0400066C RID: 1644
//		private XRTable xrTable3;

//		// Token: 0x0400066D RID: 1645
//		private XRTableRow xrTableRow5;

//		// Token: 0x0400066E RID: 1646
//		private XRTableCell xrTableCell9;

//		// Token: 0x0400066F RID: 1647
//		private XRTableCell xrTableCell10;

//		// Token: 0x04000670 RID: 1648
//		private XRTableCell xrTableCell11;

//		// Token: 0x04000671 RID: 1649
//		private XRTableCell xrTableCell12;

//		// Token: 0x04000672 RID: 1650
//		private XRTableCell xrTableCell13;

//		// Token: 0x04000673 RID: 1651
//		private GroupHeaderBand GroupHeader1;

//		// Token: 0x04000674 RID: 1652
//		private XRTable xrTable4;

//		// Token: 0x04000675 RID: 1653
//		private XRTableRow xrTableRow6;

//		// Token: 0x04000676 RID: 1654
//		private XRTableCell xrTableCell14;

//		// Token: 0x04000677 RID: 1655
//		private XRTableCell xrTableCell15;

//		// Token: 0x04000678 RID: 1656
//		private XRTableCell xrTableCell16;

//		// Token: 0x04000679 RID: 1657
//		private XRTableCell xrTableCell17;

//		// Token: 0x0400067A RID: 1658
//		private XRTableCell xrTableCell18;

//		// Token: 0x0400067B RID: 1659
//		private DetailReportBand DetailReport2;

//		// Token: 0x0400067C RID: 1660
//		private DetailBand Detail3;

//		// Token: 0x0400067D RID: 1661
//		private XRLabel xrLabel3;

//		// Token: 0x0400067E RID: 1662
//		private XRLabel xrLabel5;

//		// Token: 0x0400067F RID: 1663
//		private XRLabel xrLabel15;

//		// Token: 0x04000680 RID: 1664
//		private XRLabel xrLabel16;

//		// Token: 0x04000681 RID: 1665
//		private XRLabel xrLabel17;

//		// Token: 0x04000682 RID: 1666
//		private XRLabel xrLabel18;

//		// Token: 0x04000683 RID: 1667
//		private DetailReportBand DetailReport1;

//		// Token: 0x04000684 RID: 1668
//		private DetailBand Detail2;

//		// Token: 0x04000685 RID: 1669
//		private XRLabel xrLabel21;

//		// Token: 0x04000686 RID: 1670
//		private XRLabel xrLabel19;

//		// Token: 0x04000687 RID: 1671
//		private Parameter InvoiceID;

//		// Token: 0x04000688 RID: 1672
//		private XRTableCell xrTableCell4;

//		// Token: 0x04000689 RID: 1673
//		private XRTableCell xrTableCell3;

//		// Token: 0x0400068A RID: 1674
//		private XRTable xrTable2;

//		// Token: 0x0400068B RID: 1675
//		private XRTableRow xrTableRow3;

//		// Token: 0x0400068C RID: 1676
//		private XRTableCell xrTableCell5;

//		// Token: 0x0400068D RID: 1677
//		private XRTableCell xrTableCell6;

//		// Token: 0x0400068E RID: 1678
//		private XRTableCell xrTableCell7;

//		// Token: 0x0400068F RID: 1679
//		private XRTableCell xrTableCell8;

//		// Token: 0x04000690 RID: 1680
//		private XRTableCell xrTableCell19;

//		// Token: 0x04000691 RID: 1681
//		private XRTableCell xrTableCell20;

//		// Token: 0x04000692 RID: 1682
//		private CalculatedField JONumber;

//		// Token: 0x04000693 RID: 1683
//		private CalculatedField WONumber;

//		// Token: 0x04000694 RID: 1684
//		private XRTableRow xrTableRow4;

//		// Token: 0x04000695 RID: 1685
//		private XRTableCell xrTableCell21;

//		// Token: 0x04000696 RID: 1686
//		private XRTableRow xrTableRow7;

//		// Token: 0x04000697 RID: 1687
//		private XRTableCell xrTableCell22;

//		// Token: 0x04000698 RID: 1688
//		private XRTableRow xrTableRow9;

//		// Token: 0x04000699 RID: 1689
//		private XRTableCell xrTableCell24;

//		// Token: 0x0400069A RID: 1690
//		private XRTableRow xrTableRow8;

//		// Token: 0x0400069B RID: 1691
//		private XRTableCell xrTableCell23;

//		// Token: 0x0400069C RID: 1692
//		private XRLabel xrLabel2;

//		// Token: 0x0400069D RID: 1693
//		private XRLabel xrLabel9;

//		// Token: 0x0400069E RID: 1694
//		private XRLabel xrLabel11;

//		// Token: 0x0400069F RID: 1695
//		private XRLabel xrLabel10;

//		// Token: 0x040006A0 RID: 1696
//		private XRLabel xrLabel7;

//		// Token: 0x040006A1 RID: 1697
//		private XRLabel xrLabel4;
//	}
//}
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
    // Token: 0x02000058 RID: 88
    public class Invoice : XtraReport
    {
        // Token: 0x06000337 RID: 823 RVA: 0x00003FE1 File Offset: 0x000021E1
        public Invoice()
        {
            InitializeComponent();
            //this.BeforePrint += this.Invoice_BeforePrint;
        }

        private XRLabel xrLabel12;
        //private Parameter FilterExpression;

        //private Parameter InvoiceID;

        //private void Invoice_BeforePrint(object sender, PrintEventArgs e)
        //{
        //    if (this.FilterExpression.Value.ToString() != "")
        //    {
        //        this.FilterString = this.FilterExpression.Value.ToString();
        //        return;
        //    }
        //    if (this.InvoiceID.Value.ToString() == "0")
        //    {
        //        this.FilterString = "";
        //    }
        //}

        // Token: 0x06000338 RID: 824 RVA: 0x00003FEF File Offset: 0x000021EF
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x06000339 RID: 825 RVA: 0x000290F4 File Offset: 0x000272F4
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
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column13 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression13 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table3 = new DevExpress.DataAccess.Sql.Table();
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
            DevExpress.DataAccess.Sql.Table table4 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Join join2 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Join join3 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo3 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Join join4 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo4 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo5 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo2 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo6 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport2 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.InvoiceID = new DevExpress.XtraReports.Parameters.Parameter();
            this.JONumber = new DevExpress.XtraReports.UI.CalculatedField();
            this.WONumber = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "InvoiceId";
            table1.MetaSerializable = "<Meta X=\"30\" Y=\"30\" Width=\"125\" Height=\"300\" />";
            table1.Name = "Invoice";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "InvoiceNumber";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "InvoiceDate";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "InvoiceRefNo";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "FKJobOrderMasterID";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "SRTTotal";
            columnExpression6.Table = table1;
            column6.Expression = columnExpression6;
            columnExpression7.ColumnName = "TSTotal";
            columnExpression7.Table = table1;
            column7.Expression = columnExpression7;
            columnExpression8.ColumnName = "InvoiceTotal";
            columnExpression8.Table = table1;
            column8.Expression = columnExpression8;
            columnExpression9.ColumnName = "Disount";
            columnExpression9.Table = table1;
            column9.Expression = columnExpression9;
            columnExpression10.ColumnName = "NetAmount";
            columnExpression10.Table = table1;
            column10.Expression = columnExpression10;
            columnExpression11.ColumnName = "ProvideDescription";
            columnExpression11.Table = table1;
            column11.Expression = columnExpression11;
            columnExpression12.ColumnName = "CustomerName";
            table2.MetaSerializable = "<Meta X=\"340\" Y=\"30\" Width=\"125\" Height=\"300\" />";
            table2.Name = "CustomersList";
            columnExpression12.Table = table2;
            column12.Expression = columnExpression12;
            columnExpression13.ColumnName = "PaymentTerms";
            table3.MetaSerializable = "<Meta X=\"495\" Y=\"30\" Width=\"125\" Height=\"360\" />";
            table3.Name = "QuotationMaster";
            columnExpression13.Table = table3;
            column13.Expression = columnExpression13;
            columnExpression14.ColumnName = "PhoneNumber";
            columnExpression14.Table = table2;
            column14.Expression = columnExpression14;
            columnExpression15.ColumnName = "FaxNumber";
            columnExpression15.Table = table2;
            column15.Expression = columnExpression15;
            columnExpression16.ColumnName = "Email";
            columnExpression16.Table = table2;
            column16.Expression = columnExpression16;
            columnExpression17.ColumnName = "Address";
            columnExpression17.Table = table2;
            column17.Expression = columnExpression17;
            columnExpression18.ColumnName = "JobOrderNumber";
            table4.MetaSerializable = "<Meta X=\"185\" Y=\"30\" Width=\"125\" Height=\"360\" />";
            table4.Name = "JobOrderMaster";
            columnExpression18.Table = table4;
            column18.Expression = columnExpression18;
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
            selectQuery1.MetaSerializable = "<Meta X=\"260\" Y=\"20\" Width=\"100\" Height=\"343\" />";
            selectQuery1.Name = "Invoice";
            relationColumnInfo1.NestedKeyColumn = "JobOrderMasterID";
            relationColumnInfo1.ParentKeyColumn = "FKJobOrderMasterID";
            join1.KeyColumns.Add(relationColumnInfo1);
            join1.Nested = table4;
            join1.Parent = table1;
            relationColumnInfo2.NestedKeyColumn = "CustomerID";
            relationColumnInfo2.ParentKeyColumn = "FKCustomerID";
            join2.KeyColumns.Add(relationColumnInfo2);
            join2.Nested = table2;
            join2.Parent = table4;
            relationColumnInfo3.NestedKeyColumn = "FKCustomerID";
            relationColumnInfo3.ParentKeyColumn = "CustomerID";
            join3.KeyColumns.Add(relationColumnInfo3);
            join3.Nested = table3;
            join3.Parent = table2;
            relationColumnInfo4.NestedKeyColumn = "QuotationMasterID";
            relationColumnInfo4.ParentKeyColumn = "FKQuotationMasterID";
            join4.KeyColumns.Add(relationColumnInfo4);
            join4.Nested = table3;
            join4.Parent = table4;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Relations.Add(join2);
            selectQuery1.Relations.Add(join3);
            selectQuery1.Relations.Add(join4);
            selectQuery1.Tables.Add(table1);
            selectQuery1.Tables.Add(table4);
            selectQuery1.Tables.Add(table2);
            selectQuery1.Tables.Add(table3);
            customSqlQuery1.MetaSerializable = "<Meta X=\"20\" Y=\"20\" Width=\"100\" Height=\"88\" />";
            customSqlQuery1.Name = "SampleReceiveTestInvoice";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            customSqlQuery2.Name = "WorkOrderList";
            customSqlQuery2.Sql = "SELECT * FROM [LabSys].[dbo].[WorkOrderInvoice] a inner join [WorkOrderList] b on" +
    " a.FkWorkOrderId=b.WorkOrderID inner join Invoice c on a.FkInvoiceId = c.Invoice" +
    "Id";
            customSqlQuery3.Name = "Query";
            customSqlQuery3.Sql = "SELECT top 1 * FROM [LabSys].[dbo].[Company_Profile] order by profileid desc";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1,
            customSqlQuery1,
            customSqlQuery2,
            customSqlQuery3});
            masterDetailInfo1.DetailQueryName = "SampleReceiveTestInvoice";
            relationColumnInfo5.NestedKeyColumn = "FkInvoiceId";
            relationColumnInfo5.ParentKeyColumn = "InvoiceId";
            masterDetailInfo1.KeyColumns.Add(relationColumnInfo5);
            masterDetailInfo1.MasterQueryName = "Invoice";
            masterDetailInfo2.DetailQueryName = "WorkOrderList";
            relationColumnInfo6.NestedKeyColumn = "WorkOrderID";
            relationColumnInfo6.ParentKeyColumn = "InvoiceId";
            masterDetailInfo2.KeyColumns.Add(relationColumnInfo6);
            masterDetailInfo2.MasterQueryName = "Invoice";
            this.sqlDataSource1.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1,
            masterDetailInfo2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18});
            this.Detail.HeightF = 196.0834F;
            this.Detail.KeepTogether = true;
            this.Detail.KeepTogetherWithDetailReports = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(30.55554F, 11.4584F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.xrTableRow4,
            this.xrTableRow7,
            this.xrTableRow9,
            this.xrTableRow8});
            this.xrTable1.SizeF = new System.Drawing.SizeF(440.625F, 130.9634F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 2.2300342359148129D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.Text = "Bill To:";
            this.xrTableCell1.Weight = 1D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 2.3116326342023745D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.CustomerName")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.Weight = 1D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 2.3116326342023745D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.Address")});
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.Weight = 1D;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 2.3116326342023745D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.Email")});
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.Weight = 1D;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell24});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 2.3116326342023745D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.PhoneNumber")});
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.Weight = 1D;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 2.3116326342023745D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.FaxNumber")});
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.Weight = 1D;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.Gainsboro;
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(29.505F, 154.7916F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(259.1894F, 20.64583F);
            this.xrLabel3.StylePriority.UseBackColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Customer ID";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.Gainsboro;
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(288.8194F, 154.7916F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(257.5545F, 20.64583F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Customer PO";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.BackColor = System.Drawing.Color.Gainsboro;
            this.xrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(546.4989F, 154.7918F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(278.1797F, 20.64584F);
            this.xrLabel15.StylePriority.UseBackColor = false;
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Payment Terms";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.CustomerName")});
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(29.37842F, 175.4375F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(259.4409F, 20.64583F);
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UsePadding = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(288.9444F, 175.4375F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(257.4295F, 20.64583F);
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UsePadding = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.PaymentTerms")});
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(546.4989F, 175.4375F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(278.3888F, 20.64584F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UsePadding = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel9,
            this.xrLabel1,
            this.xrLabel6,
            this.xrLabel8,
            this.xrLabel22,
            this.xrLabel20});
            this.TopMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.TopMargin.HeightF = 109.5833F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseFont = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.JobOrderNumber", "{0:dd MMM yyyy}")});
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(650.2617F, 88.33334F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(147.2084F, 18F);
            this.xrLabel2.StyleName = "DataField";
            // 
            // xrLabel9
            // 
            this.xrLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(536.5832F, 88.33334F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(113.6785F, 18F);
            this.xrLabel9.StyleName = "FieldCaption";
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.Text = "Job Order No:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 36F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(269.5137F, 28.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(237.2084F, 61.74999F);
            this.xrLabel1.StyleName = "FieldCaption";
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.Text = "INVOICE";
            // 
            // xrLabel6
            // 
            this.xrLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(536.4582F, 65.33334F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(94.29169F, 18F);
            this.xrLabel6.StyleName = "FieldCaption";
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.Text = "Invoice Date:";
            // 
            // xrLabel8
            // 
            this.xrLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(536.4582F, 41.54167F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(116.8333F, 18F);
            this.xrLabel8.StyleName = "FieldCaption";
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.Text = "Invoice Number:";
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceNumber")});
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(653.2915F, 41.54167F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(108.5F, 18F);
            this.xrLabel22.StyleName = "DataField";
            this.xrLabel22.Text = "xrLabel22";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceDate", "{0:dd MMM yyyy}")});
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(650.2618F, 65.33334F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(147.2084F, 18F);
            this.xrLabel20.StyleName = "DataField";
            this.xrLabel20.Text = "xrLabel20";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel7,
            this.xrLabel4});
            this.BottomMargin.HeightF = 72.91666F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.NetAmount", "{0:n2}")});
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(383.764F, 20.83333F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(137.7523F, 42.08335F);
            this.xrLabel12.StylePriority.UseBackColor = false;
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel11.Font = new System.Drawing.Font("Arial Narrow", 2.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(578.9995F, 54.91664F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(143.6666F, 18F);
            this.xrLabel11.StyleName = "FieldCaption";
            this.xrLabel11.StylePriority.UseBorderDashStyle = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 5F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(81.5F, 54.91664F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(147.8333F, 18F);
            this.xrLabel10.StyleName = "FieldCaption";
            this.xrLabel10.StylePriority.UseBorderDashStyle = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(101.1667F, 20.83333F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(116.8333F, 18F);
            this.xrLabel7.StyleName = "FieldCaption";
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.Text = "Approved by";
            // 
            // xrLabel4
            // 
            this.xrLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(594.6489F, 20.83333F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(116.8333F, 18F);
            this.xrLabel4.StyleName = "FieldCaption";
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.Text = "Checked by";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.HeightF = 0F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.HeightF = 3.083324F;
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
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1});
            this.DetailReport.DataMember = "Invoice.InvoiceSampleReceiveTestInvoice";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail1.HeightF = 25F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(29.37842F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable3.SizeF = new System.Drawing.SizeF(794.8868F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 11.5D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "[JONumber]";
            this.xrTableCell4.Weight = 0.27176981193497723D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSampleReceiveTestInvoice.ProvideDescription")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Weight = 0.585982501021398D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Weight = 0.18558069704145006D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Weight = 0.15497312919983713D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Weight = 0.22687084460359533D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSampleReceiveTestInvoice.SRTTotal", "{0:n2}")});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 10, 0, 0, 100F);
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell13.Weight = 0.26070673882786638D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.GroupHeader1.HeightF = 35.00001F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrTable4
            // 
            this.xrTable4.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(29.37842F, 10.00001F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable4.SizeF = new System.Drawing.SizeF(795.1752F, 25F);
            this.xrTable4.StylePriority.UseBackColor = false;
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            this.xrTable4.StylePriority.UsePadding = false;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 11.5D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Items";
            this.xrTableCell3.Weight = 0.23169373091866735D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Service Description";
            this.xrTableCell14.Weight = 0.49937634799881603D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Qty";
            this.xrTableCell15.Weight = 0.15806374148159258D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "Unit";
            this.xrTableCell16.Weight = 0.13212670427602136D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Unit Price";
            this.xrTableCell17.Weight = 0.19359577011541057D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseBackColor = false;
            this.xrTableCell18.Text = "Amount";
            this.xrTableCell18.Weight = 0.22176756035868483D;
            // 
            // DetailReport2
            // 
            this.DetailReport2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail3});
            this.DetailReport2.DataMember = "Invoice.InvoiceWorkOrderList";
            this.DetailReport2.DataSource = this.sqlDataSource1;
            this.DetailReport2.Level = 1;
            this.DetailReport2.Name = "DetailReport2";
            // 
            // Detail3
            // 
            this.Detail3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail3.HeightF = 25F;
            this.Detail3.Name = "Detail3";
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(29.38F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(795.0118F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UsePadding = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell19,
            this.xrTableCell20});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 11.5D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceWorkOrderList.WONumber")});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Weight = 0.271765779240925D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceWorkOrderList.Description")});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 0.585973521838421D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Weight = 0.1858429821618165D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Weight = 0.15490523600192738D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.22692879039817404D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceWorkOrderList.Amount", "{0:n2}")});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 10, 0, 0, 100F);
            this.xrTableCell20.StylePriority.UsePadding = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell20.Weight = 0.26070686190194386D;
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2});
            this.DetailReport1.Level = 2;
            this.DetailReport1.Name = "DetailReport1";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel19});
            this.Detail2.HeightF = 22.91667F;
            this.Detail2.Name = "Detail2";
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.NetAmount", "{0:n2}")});
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(701.8046F, 0.1874924F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(123.0831F, 20.64583F);
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel19
            // 
            this.xrLabel19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(433.8049F, 0.1874924F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(268.1248F, 20.64583F);
            this.xrLabel19.StylePriority.UseBackColor = false;
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "TOTAL INVOICE AMOUNT (QAR):";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // InvoiceID
            // 
            this.InvoiceID.Description = "Parameter1";
            dynamicListLookUpSettings1.DataMember = "Invoice";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "InvoiceNumber";
            dynamicListLookUpSettings1.FilterString = null;
            dynamicListLookUpSettings1.ValueMember = "InvoiceId";
            this.InvoiceID.LookUpSettings = dynamicListLookUpSettings1;
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Type = typeof(int);
            this.InvoiceID.ValueInfo = "0";
            // 
            // JONumber
            // 
            this.JONumber.DataMember = "Invoice.InvoiceSampleReceiveTestInvoice";
            this.JONumber.Expression = " (\'Job Order :\') + [JobOrderNumber]";
            this.JONumber.Name = "JONumber";
            // 
            // WONumber
            // 
            this.WONumber.DataMember = "Invoice.InvoiceWorkOrderList";
            this.WONumber.Expression = "(\'Work Order : \') + [WorkOrderNo]";
            this.WONumber.Name = "WONumber";
            // 
            // Invoice
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.DetailReport,
            this.DetailReport2,
            this.DetailReport1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.JONumber,
            this.WONumber});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Invoice";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[InvoiceId] = ?InvoiceID";
            this.Margins = new System.Drawing.Printing.Margins(3, 1, 110, 73);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.InvoiceID});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        // Token: 0x04000655 RID: 1621
        //private IContainer components;

        private System.ComponentModel.IContainer components = null;

        // Token: 0x04000656 RID: 1622
        private DetailBand Detail;

        // Token: 0x04000657 RID: 1623
        private TopMarginBand TopMargin;

        // Token: 0x04000658 RID: 1624
        private BottomMarginBand BottomMargin;

        // Token: 0x04000659 RID: 1625
        private XRTable xrTable1;

        // Token: 0x0400065A RID: 1626
        private XRTableRow xrTableRow1;

        // Token: 0x0400065B RID: 1627
        private XRTableCell xrTableCell1;

        // Token: 0x0400065C RID: 1628
        private XRTableRow xrTableRow2;

        // Token: 0x0400065D RID: 1629
        private XRTableCell xrTableCell2;

        // Token: 0x0400065E RID: 1630
        private XRLabel xrLabel1;

        // Token: 0x0400065F RID: 1631
        private XRLabel xrLabel6;

        // Token: 0x04000660 RID: 1632
        private XRLabel xrLabel8;

        // Token: 0x04000661 RID: 1633
        private XRLabel xrLabel22;

        // Token: 0x04000662 RID: 1634
        private XRLabel xrLabel20;

        // Token: 0x04000663 RID: 1635
        private SqlDataSource sqlDataSource1;

        // Token: 0x04000664 RID: 1636
        private PageFooterBand pageFooterBand1;

        // Token: 0x04000665 RID: 1637
        private ReportHeaderBand reportHeaderBand1;

        // Token: 0x04000666 RID: 1638
        private XRControlStyle Title;

        // Token: 0x04000667 RID: 1639
        private XRControlStyle FieldCaption;

        // Token: 0x04000668 RID: 1640
        private XRControlStyle PageInfo;

        // Token: 0x04000669 RID: 1641
        private XRControlStyle DataField;

        // Token: 0x0400066A RID: 1642
        private DetailReportBand DetailReport;

        // Token: 0x0400066B RID: 1643
        private DetailBand Detail1;

        // Token: 0x0400066C RID: 1644
        private XRTable xrTable3;

        // Token: 0x0400066D RID: 1645
        private XRTableRow xrTableRow5;

        // Token: 0x0400066E RID: 1646
        private XRTableCell xrTableCell9;

        // Token: 0x0400066F RID: 1647
        private XRTableCell xrTableCell10;

        // Token: 0x04000670 RID: 1648
        private XRTableCell xrTableCell11;

        // Token: 0x04000671 RID: 1649
        private XRTableCell xrTableCell12;

        // Token: 0x04000672 RID: 1650
        private XRTableCell xrTableCell13;

        // Token: 0x04000673 RID: 1651
        private GroupHeaderBand GroupHeader1;

        // Token: 0x04000674 RID: 1652
        private XRTable xrTable4;

        // Token: 0x04000675 RID: 1653
        private XRTableRow xrTableRow6;

        // Token: 0x04000676 RID: 1654
        private XRTableCell xrTableCell14;

        // Token: 0x04000677 RID: 1655
        private XRTableCell xrTableCell15;

        // Token: 0x04000678 RID: 1656
        private XRTableCell xrTableCell16;

        // Token: 0x04000679 RID: 1657
        private XRTableCell xrTableCell17;

        // Token: 0x0400067A RID: 1658
        private XRTableCell xrTableCell18;

        // Token: 0x0400067B RID: 1659
        private DetailReportBand DetailReport2;

        // Token: 0x0400067C RID: 1660
        private DetailBand Detail3;

        // Token: 0x0400067D RID: 1661
        private XRLabel xrLabel3;

        // Token: 0x0400067E RID: 1662
        private XRLabel xrLabel5;

        // Token: 0x0400067F RID: 1663
        private XRLabel xrLabel15;

        // Token: 0x04000680 RID: 1664
        private XRLabel xrLabel16;

        // Token: 0x04000681 RID: 1665
        private XRLabel xrLabel17;

        // Token: 0x04000682 RID: 1666
        private XRLabel xrLabel18;

        // Token: 0x04000683 RID: 1667
        private DetailReportBand DetailReport1;

        // Token: 0x04000684 RID: 1668
        private DetailBand Detail2;

        // Token: 0x04000685 RID: 1669
        private XRLabel xrLabel21;

        // Token: 0x04000686 RID: 1670
        private XRLabel xrLabel19;

        // Token: 0x04000687 RID: 1671
        private Parameter InvoiceID;

        // Token: 0x04000688 RID: 1672
        private XRTableCell xrTableCell4;

        // Token: 0x04000689 RID: 1673
        private XRTableCell xrTableCell3;

        // Token: 0x0400068A RID: 1674
        private XRTable xrTable2;

        // Token: 0x0400068B RID: 1675
        private XRTableRow xrTableRow3;

        // Token: 0x0400068C RID: 1676
        private XRTableCell xrTableCell5;

        // Token: 0x0400068D RID: 1677
        private XRTableCell xrTableCell6;

        // Token: 0x0400068E RID: 1678
        private XRTableCell xrTableCell7;

        // Token: 0x0400068F RID: 1679
        private XRTableCell xrTableCell8;

        // Token: 0x04000690 RID: 1680
        private XRTableCell xrTableCell19;

        // Token: 0x04000691 RID: 1681
        private XRTableCell xrTableCell20;

        // Token: 0x04000692 RID: 1682
        private CalculatedField JONumber;

        // Token: 0x04000693 RID: 1683
        private CalculatedField WONumber;

        // Token: 0x04000694 RID: 1684
        private XRTableRow xrTableRow4;

        // Token: 0x04000695 RID: 1685
        private XRTableCell xrTableCell21;

        // Token: 0x04000696 RID: 1686
        private XRTableRow xrTableRow7;

        // Token: 0x04000697 RID: 1687
        private XRTableCell xrTableCell22;

        // Token: 0x04000698 RID: 1688
        private XRTableRow xrTableRow9;

        // Token: 0x04000699 RID: 1689
        private XRTableCell xrTableCell24;

        // Token: 0x0400069A RID: 1690
        private XRTableRow xrTableRow8;

        // Token: 0x0400069B RID: 1691
        private XRTableCell xrTableCell23;

        // Token: 0x0400069C RID: 1692
        private XRLabel xrLabel2;

        // Token: 0x0400069D RID: 1693
        private XRLabel xrLabel9;

        // Token: 0x0400069E RID: 1694
        private XRLabel xrLabel11;

        // Token: 0x0400069F RID: 1695
        private XRLabel xrLabel10;

        // Token: 0x040006A0 RID: 1696
        private XRLabel xrLabel7;

        // Token: 0x040006A1 RID: 1697
        private XRLabel xrLabel4;
    }
}

