using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using PioneerLab.Reports;

namespace PioneerLab.Pages
{
	// Token: 0x0200001A RID: 26
	public class ValidityDetailsReports : Page
	{
		// Token: 0x060000DF RID: 223 RVA: 0x000086C0 File Offset: 0x000068C0
		protected void Page_Load(object sender, EventArgs e)
		{
			string text = (string)this.Session["ReportName"];
			if (!string.IsNullOrEmpty(text) && this.cmbValidityName.Value != null)
			{
				this.ReportViewer1.Report = this.GetReport(text, (int)this.cmbValidityName.Value, null);
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000871C File Offset: 0x0000691C
		protected void btnGenerate_Click(object sender, EventArgs e)
		{
			int id = 0;
			string a = this.cmbStatus.Value.ToString();
			if (this.cmbValidityName.Value != null)
			{
				id = (int)this.cmbValidityName.Value;
			}
			if (a == "Valid")
			{
				this.ShowReport("ValidValidityDetailsReport", id, null);
				return;
			}
			if (a == "Expired")
			{
				this.ShowReport("ExpiredValidityDetailsReport", id, null);
				return;
			}
			if (a == "Late")
			{
				this.ShowReport("LateValidityDetailsReport", id, null);
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000087AC File Offset: 0x000069AC
		protected void ShowReport(string Report, int id, string FilterExpression)
		{
			this.ReportViewer1.Report = this.GetReport(Report, id, FilterExpression);
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
			this.Session["ReportName"] = Report;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000882C File Offset: 0x00006A2C
		protected XtraReport GetReport(string Report, int id, string FilterExpression)
		{
			if (Report == "AccreditionList")
			{
				AccreditionList accreditionList = new AccreditionList();
				accreditionList.Parameters["FilterExpression"].Value = FilterExpression;
				accreditionList.CreateDocument();
				return accreditionList;
			}
			if (Report == "Contractor")
			{
				Contractor contractor = new Contractor();
				contractor.Parameters["Id"].Value = id;
				contractor.Parameters["FilterExpression"].Value = FilterExpression;
				contractor.CreateDocument();
				return contractor;
			}
			if (Report == "ContractorsInformationList")
			{
				ContractorsInformationList contractorsInformationList = new ContractorsInformationList();
				contractorsInformationList.Parameters["FilterExpression"].Value = FilterExpression;
				contractorsInformationList.CreateDocument();
				return contractorsInformationList;
			}
			if (Report == "Equipments")
			{
				Equipment equipment = new Equipment();
				equipment.Parameters["Id"].Value = id;
				equipment.Parameters["FilterExpression"].Value = FilterExpression;
				equipment.CreateDocument();
				return equipment;
			}
			if (Report == "EquipmentList")
			{
				EquipmentList equipmentList = new EquipmentList();
				equipmentList.Parameters["FilterExpression"].Value = FilterExpression;
				equipmentList.CreateDocument();
				return equipmentList;
			}
			if (Report == "Customers")
			{
				Customers customers = new Customers();
				customers.Parameters["CustomerID"].Value = id;
				customers.Parameters["FilterExpression"].Value = FilterExpression;
				customers.CreateDocument();
				return customers;
			}
			if (Report == "CustomersList")
			{
				CustomersList customersList = new CustomersList();
				customersList.Parameters["FilterExpression"].Value = FilterExpression;
				customersList.CreateDocument();
				return customersList;
			}
			if (Report == "Employees")
			{
				Employees employees = new Employees();
				employees.Parameters["EmpID"].Value = id;
				employees.Parameters["FilterExpression"].Value = FilterExpression;
				employees.CreateDocument();
				return employees;
			}
			if (Report == "EmployeeList")
			{
				EmployeeList employeeList = new EmployeeList();
				employeeList.Parameters["FilterExpression"].Value = FilterExpression;
				employeeList.CreateDocument();
				return employeeList;
			}
			if (Report == "Items")
			{
				Items items = new Items();
				items.Parameters["Id"].Value = id;
				items.Parameters["FilterExpression"].Value = FilterExpression;
				items.CreateDocument();
				return items;
			}
			if (Report == "ValidityDetailsReport")
			{
				ValidityDetailsReport validityDetailsReport = new ValidityDetailsReport();
				validityDetailsReport.CreateDocument();
				return validityDetailsReport;
			}
			if (Report == "ValidValidityDetailsReport")
			{
				ValidValidityDetailsReport validValidityDetailsReport = new ValidValidityDetailsReport();
				validValidityDetailsReport.Parameters["Id"].Value = id;
				validValidityDetailsReport.CreateDocument();
				return validValidityDetailsReport;
			}
			if (Report == "ExpiredValidityDetailsReport")
			{
				ExpiredValidityDetailsReport expiredValidityDetailsReport = new ExpiredValidityDetailsReport();
				expiredValidityDetailsReport.Parameters["Id"].Value = id;
				expiredValidityDetailsReport.CreateDocument();
				return expiredValidityDetailsReport;
			}
			if (Report == "LateValidityDetailsReport")
			{
				LateValidityDetailsReport lateValidityDetailsReport = new LateValidityDetailsReport();
				lateValidityDetailsReport.Parameters["Id"].Value = id;
				lateValidityDetailsReport.CreateDocument();
				return lateValidityDetailsReport;
			}
			if (Report == "ServiceInformation")
			{
				ServiceInformationReport serviceInformationReport = new ServiceInformationReport();
				serviceInformationReport.Parameters["Id"].Value = id;
				serviceInformationReport.Parameters["FilterExpression"].Value = FilterExpression;
				serviceInformationReport.CreateDocument();
				return serviceInformationReport;
			}
			if (Report == "ServiceInformationList")
			{
				ServiceInformationList serviceInformationList = new ServiceInformationList();
				serviceInformationList.Parameters["FilterExpression"].Value = FilterExpression;
				serviceInformationList.CreateDocument();
				return serviceInformationList;
			}
			if (Report == "QuotationReport")
			{
				QuotationReport quotationReport = new QuotationReport();
				quotationReport.Parameters["Id"].Value = id;
				quotationReport.Parameters["FilterExpression"].Value = FilterExpression;
				quotationReport.CreateDocument();
				return quotationReport;
			}
			if (Report == "QuotationReport2")
			{
				QuotationReportFinal quotationReportFinal = new QuotationReportFinal();
				quotationReportFinal.Parameters["QID"].Value = id;
				quotationReportFinal.CreateDocument();
				return quotationReportFinal;
			}
			if (Report == "SampleReceiptReport")
			{
				SampleReceiptReport sampleReceiptReport = new SampleReceiptReport();
				sampleReceiptReport.Parameters["Id"].Value = id;
				sampleReceiptReport.Parameters["FilterExpression"].Value = FilterExpression;
				sampleReceiptReport.CreateDocument();
				return sampleReceiptReport;
			}
			if (Report == "LabSections")
			{
				LabSection labSection = new LabSection();
				labSection.Parameters["FilterExpression"].Value = FilterExpression;
				labSection.CreateDocument();
				return labSection;
			}
			if (Report == "LabSubcontractors")
			{
				LabSubcontractor labSubcontractor = new LabSubcontractor();
				labSubcontractor.Parameters["FilterExpression"].Value = FilterExpression;
				labSubcontractor.CreateDocument();
				return labSubcontractor;
			}
			if (Report == "Material_Information")
			{
				Material_Information material_Information = new Material_Information();
				material_Information.Parameters["Id"].Value = id;
				material_Information.CreateDocument();
				return material_Information;
			}
			if (Report == "MaterialList")
			{
				MaterialList materialList = new MaterialList();
				materialList.Parameters["FilterExpression"].Value = FilterExpression;
				materialList.CreateDocument();
				return materialList;
			}
			if (Report == "PriceUnitReport")
			{
				PriceUnitReport priceUnitReport = new PriceUnitReport();
				priceUnitReport.Parameters["FilterExpression"].Value = FilterExpression;
				priceUnitReport.CreateDocument();
				return priceUnitReport;
			}
			if (Report == "Projects_Information")
			{
				Projects_Information projects_Information = new Projects_Information();
				projects_Information.Parameters["Id"].Value = id;
				projects_Information.CreateDocument();
				return projects_Information;
			}
			if (Report == "ProjectsList")
			{
				ProjectsList projectsList = new ProjectsList();
				projectsList.Parameters["FilterExpression"].Value = FilterExpression;
				projectsList.CreateDocument();
				return projectsList;
			}
			if (Report == "ServiceSection")
			{
				ServiceSection serviceSection = new ServiceSection();
				serviceSection.Parameters["Id"].Value = id;
				serviceSection.CreateDocument();
				return serviceSection;
			}
			if (Report == "ServiceSectionList")
			{
				ServiceSectionList serviceSectionList = new ServiceSectionList();
				serviceSectionList.Parameters["FilterExpression"].Value = FilterExpression;
				serviceSectionList.CreateDocument();
				return serviceSectionList;
			}
			if (Report == "Terms_Conditions")
			{
				Terms_Conditions terms_Conditions = new Terms_Conditions();
				terms_Conditions.Parameters["FilterExpression"].Value = FilterExpression;
				terms_Conditions.CreateDocument();
				return terms_Conditions;
			}
			if (Report == "InvoiceList")
			{
				InvoiceList invoiceList = new InvoiceList();
				invoiceList.Parameters["FilterExpression"].Value = FilterExpression;
				invoiceList.CreateDocument();
				return invoiceList;
			}
			if (Report == "Invoice")
			{
				Invoice invoice = new Invoice();
				invoice.Parameters["InvoiceID"].Value = id;
				invoice.CreateDocument();
				return invoice;
			}
			if (Report == "InvoiceTimeSheetReport")
			{
				InvoiceTimeSheetReport invoiceTimeSheetReport = new InvoiceTimeSheetReport();
				invoiceTimeSheetReport.Parameters["InvoiceId"].Value = id;
				invoiceTimeSheetReport.CreateDocument();
				return invoiceTimeSheetReport;
			}
			if (Report == "SampleResiveTestInvoiced")
			{
				SampleResiveTestInvoiced sampleResiveTestInvoiced = new SampleResiveTestInvoiced();
				sampleResiveTestInvoiced.Parameters["InvoiceId"].Value = id;
				sampleResiveTestInvoiced.CreateDocument();
				return sampleResiveTestInvoiced;
			}
			if (Report == "RSSReport")
			{
				RSSReport rssreport = new RSSReport();
				rssreport.Parameters["RSSID"].Value = id;
				rssreport.CreateDocument();
				return rssreport;
			}
			return null;
		}

		// Token: 0x040000DB RID: 219
		protected HtmlGenericControl ultitle;

		// Token: 0x040000DC RID: 220
		protected HtmlGenericControl divParms;

		// Token: 0x040000DD RID: 221
		protected HtmlGenericControl divValidityDetails;

		// Token: 0x040000DE RID: 222
		protected ASPxLabel ASPxLabel2;

		// Token: 0x040000DF RID: 223
		protected ASPxComboBox cmbValidityName;

		// Token: 0x040000E0 RID: 224
		protected ASPxLabel ASPxLabel1;

		// Token: 0x040000E1 RID: 225
		protected ASPxComboBox cmbStatus;

		// Token: 0x040000E2 RID: 226
		protected ASPxButton btnGenerate;

		// Token: 0x040000E3 RID: 227
		protected ASPxLabel lblError;

		// Token: 0x040000E4 RID: 228
		protected ASPxDocumentViewer ReportViewer1;

		// Token: 0x040000E5 RID: 229
		protected ObjectDataSource ValidityListDS;
	}
}
