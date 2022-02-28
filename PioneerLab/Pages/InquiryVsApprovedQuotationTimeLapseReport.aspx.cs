﻿using System;
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
	public class InquiryVsApprovedQuotationTimeLapseReport : Page
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
            PioneerLab.Reports.Menu.InquiryVsApprovedQuotationTimeLapseReport inquiryVsApprovedQuotationTimeLapse = new PioneerLab.Reports.Menu.InquiryVsApprovedQuotationTimeLapseReport();
            if (dtDateFrom.Text != "")
                inquiryVsApprovedQuotationTimeLapse.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                inquiryVsApprovedQuotationTimeLapse.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            inquiryVsApprovedQuotationTimeLapse.CreateDocument();
            return inquiryVsApprovedQuotationTimeLapse;
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
	}
}
