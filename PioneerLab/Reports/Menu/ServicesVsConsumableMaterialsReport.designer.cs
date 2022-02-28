namespace PioneerLab.Reports.Menu
{
    partial class ServicesVsConsumableMaterialsReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesVsConsumableMaterialsReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldJobOrderNumber1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldTestName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldItemName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldQty1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.FromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.JoNo = new DevExpress.XtraReports.Parameters.Parameter();
            this.ServiceID = new DevExpress.XtraReports.Parameters.Parameter();
            this.ItemNos = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrPivotGrid1.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.WordWrap = true;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPivotGrid1.DataMember = "SPGetServicesVsConsumableReport_1";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Dpi = 100F;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldJobOrderNumber1,
            this.fieldTestName1,
            this.fieldItemName1,
            this.fieldQty1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsDataField.ColumnValueLineCount = 3;
            this.xrPivotGrid1.OptionsDataField.RowValueLineCount = 3;
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsPrint.PrintHeadersOnEveryPage = true;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowRowTotals = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(1139.417F, 43.74994F);
            this.xrPivotGrid1.CustomRowHeight += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotCustomRowHeightEventArgs>(this.xrPivotGrid1_CustomRowHeight);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "SPGetServicesVsConsumableReport_1";
            queryParameter1.Name = "@FromDate";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.FromDate]", typeof(string));
            queryParameter2.Name = "@ToDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.ToDate]", typeof(string));
            queryParameter3.Name = "@JoNo";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.JoNo]", typeof(int));
            queryParameter4.Name = "@ServiceNo";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.ServiceID]", typeof(int));
            queryParameter5.Name = "@ItemNos";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.ItemNos]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.StoredProcName = "SPGetServicesVsConsumableReport";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // fieldJobOrderNumber1
            // 
            this.fieldJobOrderNumber1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldJobOrderNumber1.AreaIndex = 0;
            this.fieldJobOrderNumber1.Caption = "JO#";
            this.fieldJobOrderNumber1.FieldName = "JobOrderNumber";
            this.fieldJobOrderNumber1.Name = "fieldJobOrderNumber1";
            this.fieldJobOrderNumber1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldJobOrderNumber1.Width = 61;
            // 
            // fieldTestName1
            // 
            this.fieldTestName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldTestName1.AreaIndex = 1;
            this.fieldTestName1.Caption = "Service Name";
            this.fieldTestName1.FieldName = "TestName";
            this.fieldTestName1.Name = "fieldTestName1";
            this.fieldTestName1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldTestName1.Width = 174;
            // 
            // fieldItemName1
            // 
            this.fieldItemName1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 7F);
            this.fieldItemName1.Appearance.FieldValue.WordWrap = true;
            this.fieldItemName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldItemName1.AreaIndex = 0;
            this.fieldItemName1.FieldName = "ItemName";
            this.fieldItemName1.Name = "fieldItemName1";
            this.fieldItemName1.Options.HideEmptyVariationItems = true;
            this.fieldItemName1.Width = 97;
            // 
            // fieldQty1
            // 
            this.fieldQty1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldQty1.AreaIndex = 0;
            this.fieldQty1.CellFormat.FormatString = "{0.00}";
            this.fieldQty1.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldQty1.ColumnValueLineCount = 3;
            this.fieldQty1.FieldName = "Qty";
            this.fieldQty1.GrandTotalCellFormat.FormatString = "{0.00}";
            this.fieldQty1.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldQty1.Name = "fieldQty1";
            this.fieldQty1.Options.ShowTotals = false;
            this.fieldQty1.RowValueLineCount = 3;
            this.fieldQty1.TotalCellFormat.FormatString = "{0.00}";
            this.fieldQty1.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldQty1.TotalValueFormat.FormatString = "{0.00}";
            this.fieldQty1.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1,
            this.xrLabel1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 89.74994F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1139.417F, 46F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Services Vs Consumable Materials";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // FromDate
            // 
            this.FromDate.Description = "FromDate";
            this.FromDate.Name = "FromDate";
            // 
            // ToDate
            // 
            this.ToDate.Description = "ToDate";
            this.ToDate.Name = "ToDate";
            // 
            // JoNo
            // 
            this.JoNo.Description = "JoNo";
            this.JoNo.Name = "JoNo";
            this.JoNo.Type = typeof(int);
            this.JoNo.ValueInfo = "0";
            // 
            // ServiceID
            // 
            this.ServiceID.Description = "ServiceID";
            this.ServiceID.Name = "ServiceID";
            this.ServiceID.Type = typeof(int);
            this.ServiceID.ValueInfo = "0";
            // 
            // ItemNos
            // 
            this.ItemNos.Description = "ItemNos";
            this.ItemNos.Name = "ItemNos";
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 51.04167F;
            this.PageFooter.Name = "PageFooter";
            // 
            // ServicesVsConsumableMaterialsReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(15, 15, 50, 50);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FromDate,
            this.ToDate,
            this.JoNo,
            this.ServiceID,
            this.ItemNos});
            this.ShowPreviewMarginLines = false;
            this.ShowPrintMarginsWarning = false;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter FromDate;
        private DevExpress.XtraReports.Parameters.Parameter ToDate;
        private DevExpress.XtraReports.Parameters.Parameter JoNo;
        private DevExpress.XtraReports.Parameters.Parameter ServiceID;
        private DevExpress.XtraReports.Parameters.Parameter ItemNos;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldJobOrderNumber1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTestName1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldItemName1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldQty1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
    }
}
