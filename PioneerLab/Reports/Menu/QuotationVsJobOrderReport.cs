using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PioneerLab.Reports.Menu
{
    public partial class QuotationVsJobOrderReport : XtraReport
    {
        public QuotationVsJobOrderReport()
        {
            InitializeComponent();
        }

        private void xrLabelPCT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double grossJobOrderTotal = Convert.ToDouble(xrLabelJobOrderTotal.Summary.GetResult());
            double grossQuotNoTotal = Convert.ToDouble(xrLabelQuotNoTotal.Summary.GetResult());
            XRLabel lb = sender as XRLabel;
            lb.Text = string.Format("{0:0.00%}", (grossJobOrderTotal / grossQuotNoTotal));
        }
    }
}
