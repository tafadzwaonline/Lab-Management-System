using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using PioneerLab.Reports;
using PioneerLab.Reports.Menu;

namespace PioneerLab.Pages.Reports
{
	public class ActiveWorkOrdersReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            this.ReportViewer1.Report = this.GetReport();
            if (this.ReportViewer1.Report.RowCount == 0)
            {
                this.ReportViewer1.Visible = false;
                this.lblError.Text = "No Data";
            }
            else
            {
                this.lblError.Text = "";
                this.ReportViewer1.Visible = true;
            }
        }

		protected XtraReport GetReport()
		{
            PioneerLab.Reports.Menu.ActiveWorkOrdersReport activeWorkOrders = new PioneerLab.Reports.Menu.ActiveWorkOrdersReport();
            activeWorkOrders.CreateDocument();
            return activeWorkOrders;
		}

		protected HtmlGenericControl ultitle;

		protected ASPxLabel lblError;

		protected ASPxDocumentViewer ReportViewer1;
	}
}
