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
	public class ServiceVSAccreditationStatusReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(IsPostBack)
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
            PioneerLab.Reports.Menu.ServiceVSAccreditationStatusReport serviceVSAccreditationStatus = new PioneerLab.Reports.Menu.ServiceVSAccreditationStatusReport();
            if (cmbAccreditationStatus.Value != null)
                serviceVSAccreditationStatus.Parameters["AccreditationStatusID"].Value = cmbAccreditationStatus.Value;
            else
                serviceVSAccreditationStatus.Parameters["AccreditationStatusID"].Value = 0;

            serviceVSAccreditationStatus.Parameters["TestAvailabilityID"].Value = ddlTestAvailability.Text;
            serviceVSAccreditationStatus.CreateDocument();
            return serviceVSAccreditationStatus;
		}

		protected HtmlGenericControl ultitle;

		protected HtmlGenericControl divParms;

		protected HtmlGenericControl divValidityDetails;

		protected ASPxLabel ASPxLabel2;

		protected ASPxComboBox cmbAccreditationStatus;

		protected ASPxLabel ASPxLabel1;

		protected DropDownList ddlTestAvailability;

		protected ASPxButton btnGenerate;

		protected ASPxLabel lblError;

		protected ASPxDocumentViewer ReportViewer1;
	}
}
