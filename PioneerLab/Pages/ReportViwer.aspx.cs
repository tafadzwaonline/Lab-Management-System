using System;
using System.Web.UI;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using PioneerLab.Reports;

namespace PioneerLab.Pages
{
	// Token: 0x02000029 RID: 41
	public class ReportViwer : Page
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0000C734 File Offset: 0x0000A934
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.Page.IsPostBack)
			{
				string report = base.Request["source"];
				int id = Convert.ToInt32(base.Request["Id"]);
				string text = base.Request["Filter"];
				if (text == "undefined")
				{
					text = "";
				}
				this.ShowReport(report, id, text);
				this.SetControls();
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00002071 File Offset: 0x00000271
		private void SetControls()
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000C7A8 File Offset: 0x0000A9A8
		protected void ShowReport(string Report, int id, string FilterExpression)
		{
			this.ReportViewer1.Report = this.GetReport(Report, id, FilterExpression);
			if (this.ReportViewer1.Report.RowCount == 0)
			{
				this.ReportViewer1.Visible = false;
				this.LblError.Text = "No Data";
				return;
			}
			this.LblError.Text = "";
			this.ReportViewer1.Visible = true;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000C814 File Offset: 0x0000AA14
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
				validityDetailsReport.Parameters["ValidityID"].Value = id;
				validityDetailsReport.Parameters["FilterExpression"].Value = FilterExpression;
				validityDetailsReport.CreateDocument();
				return validityDetailsReport;
			}
			if (Report == "ValidValidityDetailsReport")
			{
                ValidValidityDetailsReport validValidityDetailsReport = new ValidValidityDetailsReport();
                validValidityDetailsReport.CreateDocument();
                return validValidityDetailsReport;
            }
			if (Report == "ExpiredValidityDetailsReport")
			{
				ExpiredValidityDetailsReport expiredValidityDetailsReport = new ExpiredValidityDetailsReport();
				expiredValidityDetailsReport.CreateDocument();
				return expiredValidityDetailsReport;
			}
			if (Report == "LateValidityDetailsReport")
			{
				LateValidityDetailsReport lateValidityDetailsReport = new LateValidityDetailsReport();
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
                return null;              
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
				SampleReceiptReportNew sampleReceiptReport = new SampleReceiptReportNew();
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
            if (Report == "Invoice")
            {
                Invoice invoice = new Invoice();
                //invoice.Parameters["InvoiceID"].Value = id;
                invoice.CreateDocument();
                return invoice;
            }
            if (Report == "Invoicee")
            {
                Invoicee invoicee = new Invoicee();
                invoicee.Parameters["PaymentID"].Value = id;
                invoicee.CreateDocument();
                return invoicee;
            }
            if (Report == "XtraReportTest")
            {
                XtraReportTest invoicee = new XtraReportTest();
            //    invoicee.Parameters["PaymentID"].Value = id;
                invoicee.CreateDocument();
                return invoicee;
            }


            if (!(Report == "InvoiceList") && !(Report == "Invoice"))
			{
				if (Report == "InvoiceTimeSheetReport")
				{
					InvoiceTimeSheetReport invoiceTimeSheetReport = new InvoiceTimeSheetReport();
					invoiceTimeSheetReport.Parameters["InvoiceId"].Value = id;
					invoiceTimeSheetReport.CreateDocument();
					return invoiceTimeSheetReport;
				}
				if (Report == "SampleResiveTestInvoiced")
				{
					SampleResiveTestInvoicedNew sampleResiveTestInvoiced = new SampleResiveTestInvoicedNew();
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
			}
			return null;
		}

		// Token: 0x040001FC RID: 508
		protected ASPxLabel LblError;

		// Token: 0x040001FD RID: 509
		protected ASPxDocumentViewer ReportViewer1;
	}
}
