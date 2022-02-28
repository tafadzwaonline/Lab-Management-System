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
	public class RSSVsTimeReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (IsPostBack)
                this.ReportViewer1.Report = this.GetReport();
        }

		protected void btnGenerate_Click(object sender, EventArgs e)
		{
            //this.ReportViewer1.Report = this.GetReport();
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
            //select jo.*, RM.*
            //from RSSMaster RM JOin JobOrderMaster JO ON RM.FKJobOrderMasterID = JO.JobOrderMasterID
            //join ProjectsList PL ON JO.FKProjectID = PL.ProjectID
            //join SampleReceiveList SR ON SR.FKJobOrderMasterID = JO.JobOrderMasterID and SR.FKProjectID = PL.ProjectID and SR.FKCustomerID = JO.FKCustomerID
            //where jo.IsClosed <> 0

            PioneerLab.Reports.Menu.RSSVsTimeReport rSSVsTime = new PioneerLab.Reports.Menu.RSSVsTimeReport();
            if (dtDateFrom.Text != "")
                rSSVsTime.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                rSSVsTime.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            rSSVsTime.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            rSSVsTime.CreateDocument();
            return rSSVsTime;
		}

		protected HtmlGenericControl ultitle;

		protected HtmlGenericControl divParms;

		protected HtmlGenericControl divValidityDetails;

		protected ASPxLabel ASPxLabel2;

        protected ASPxDateEdit dtDateFrom;

        protected ASPxLabel ASPxLabel1;

        protected ASPxDateEdit dtDateTo;

        protected ASPxButton btnGenerate;

        protected ASPxLabel lblError;

        protected ASPxDocumentViewer ReportViewer1;

        protected ASPxComboBox cmbJobOrderNo;
    }
}
