using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;

namespace PioneerLab.Reports
{
    public partial class SampleReceiptReportNew : DevExpress.XtraReports.UI.XtraReport
    {
        public SampleReceiptReportNew()
        {
            InitializeComponent();
            this.BeforePrint += this.SampleReceiptReportNew_BeforePrint;
        }

        // Token: 0x06000376 RID: 886 RVA: 0x00050040 File Offset: 0x0004E240
        private void SampleReceiptReportNew_BeforePrint(object sender, PrintEventArgs e)
        {
            if (this.FilterExpression.Value.ToString() != "")
            {
                this.FilterString = this.FilterExpression.Value.ToString();
                return;
            }
            if (this.Id.Value.ToString() == "0")
            {
                this.FilterString = "";
            }
        }
        
        private void xrPivotGrid1_CustomRowHeight(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotCustomRowHeightEventArgs e)
        {
            //e.RowHeight = 50;

            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            string value = "";
            try
            {
                 value = e.GetFieldValue(e.Field, e.RowIndex).ToString().Trim();
            }
            catch(Exception ex)
            {
                var test = ex.ToString();
            }
            
            //SizeF size = gr.MeasureString(value, e.Field.Appearance.Cell.Font, e.Field.Width);
            SizeF size = gr.MeasureString(value, e.Field.Appearance.FieldValue.Font, e.Field.Width, StringFormat.GenericTypographic);
            int height = Convert.ToInt32(size.Height);
            e.RowHeight = e.RowHeight > height ? e.RowHeight : height;
        }
    }
}
