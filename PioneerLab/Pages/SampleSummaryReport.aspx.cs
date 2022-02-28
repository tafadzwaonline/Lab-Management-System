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
	public class SampleSummaryReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (IsPostBack)
            {
                Tuple<bool, string> valid = Validate();
                if (valid.Item1)
                    this.ReportViewer1.Report = this.GetReport();
                else
                {
                    this.ReportViewer1.Visible = false;
                    this.lblError.Text = valid.Item2;
                }
            }
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

        protected Tuple<bool, string> Validate()
        {
            bool valid = false;
            string error = "";
            if (dtDateFrom.Text != "")
            {
                var diffMonths = (dtDateTo.Date.Month + dtDateTo.Date.Year * 12) - (dtDateFrom.Date.Month + dtDateFrom.Date.Year * 12);
                if (diffMonths <= 6)
                {
                    valid = true;
                    error = "From and To Date should not more than 6 month difference.";
                }
            }
            else
            {
                if (cmbJobOrderNo.Value != null)
                    valid = true;
                else if (cmbServiceName.Value != null)
                    valid = true;
                else if (!string.IsNullOrWhiteSpace(tbSampleNo.Text))
                    valid = true;

                if (!valid)
                    error = "Select at least one filter and then try again!";
            }

            return new Tuple<bool, string>(valid, error);
        }

		protected XtraReport GetReport()
		{
            PioneerLab.Reports.Menu.SampleSummaryReport sampleSummary = new PioneerLab.Reports.Menu.SampleSummaryReport();
            if (dtDateFrom.Text != "")
                sampleSummary.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                sampleSummary.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            sampleSummary.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            sampleSummary.Parameters["ServiceNameID"].Value = cmbServiceName.Value;
            sampleSummary.Parameters["SampleNo"].Value = tbSampleNo.Text;
            sampleSummary.CreateDocument();
            return sampleSummary;
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

        protected ASPxTextBox tbSampleNo;

        protected ASPxComboBox cmbServiceName;
    }
}
