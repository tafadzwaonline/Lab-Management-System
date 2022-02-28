using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraPivotGrid;

namespace PioneerLab.Reports.Menu
{
    public partial class ServicesVsConsumableMaterialsReport : XtraReport
    {
        public ServicesVsConsumableMaterialsReport()
        {
            InitializeComponent();
        }

        //Graphics gr = Graphics.FromHwnd(IntPtr.Zero);

        private void xrPivotGrid1_CustomRowHeight(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotCustomRowHeightEventArgs e)
        {
            e.RowHeight = 30;
            //for (int i = 0; i < e.ColumnCount; i++)
            //{
            //    string value = e.GetRowCellValue(i).ToString();
            //    SizeF size = gr.MeasureString(value, e.DataField.Appearance.Cell.Font, e.DataField.Width);
            //    int height = Convert.ToInt32(size.Height + 0.5);
            //    e.RowHeight = e.RowHeight > height ? e.RowHeight : height;
            //}
        }

        //private void xrPivotGrid1_PrintHeader(object sender, DevExpress.XtraReports.UI.PivotGrid.CustomExportHeaderEventArgs e)
        //{
        //    e.Rect = new Rectangle(e.Rect.X, e.Rect.Y, e.Rect.Width, 40);
        //}
    }
}
