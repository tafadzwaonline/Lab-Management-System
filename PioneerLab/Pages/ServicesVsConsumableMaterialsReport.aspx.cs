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
	public class ServicesVsConsumableMaterialsReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (IsPostBack)
            {
                if (ASPxDropDownEdit1.Value != null && !string.IsNullOrWhiteSpace(ASPxDropDownEdit1.Value.ToString()))
                    this.ReportViewer1.Report = this.GetReport();
                else
                {
                    this.ReportViewer1.Visible = false;
                    this.lblError.Text = "Please select Consumable Number and try again";
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

		protected XtraReport GetReport()
		{
            PioneerLab.Reports.Menu.ServicesVsConsumableMaterialsReport servicesVsConsumableMaterials = new PioneerLab.Reports.Menu.ServicesVsConsumableMaterialsReport();
            if (dtDateFrom.Text != "")
                servicesVsConsumableMaterials.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                servicesVsConsumableMaterials.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            if (cmbJobOrderNo.Value != null)
                servicesVsConsumableMaterials.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            else
                servicesVsConsumableMaterials.Parameters["JoNo"].Value = 0;

            if (cmbServiceName.Value != null)
                servicesVsConsumableMaterials.Parameters["ServiceID"].Value = cmbServiceName.Value;
            else
                servicesVsConsumableMaterials.Parameters["ServiceID"].Value = 0;

            servicesVsConsumableMaterials.Parameters["ItemNos"].Value = ASPxDropDownEdit1.Value;
            servicesVsConsumableMaterials.CreateDocument();
            return servicesVsConsumableMaterials;
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

        protected ASPxComboBox cmbServiceName;

        protected ASPxListBox listBox;

        protected ASPxDropDownEdit ASPxDropDownEdit1;
    }
}
