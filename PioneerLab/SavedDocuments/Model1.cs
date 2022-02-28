namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AccreditionList> AccreditionLists { get; set; }
        public virtual DbSet<AttachedFile> AttachedFiles { get; set; }
        public virtual DbSet<AttachFileTransType> AttachFileTransTypes { get; set; }
        public virtual DbSet<Company_Profile> Company_Profile { get; set; }
        public virtual DbSet<ContractorsList> ContractorsLists { get; set; }
        public virtual DbSet<CustomersList> CustomersLists { get; set; }
        public virtual DbSet<EmployeesList> EmployeesLists { get; set; }
        public virtual DbSet<EnquiryDetail> EnquiryDetails { get; set; }
        public virtual DbSet<EnquiryMaster> EnquiryMasters { get; set; }
        public virtual DbSet<EquipmentsList> EquipmentsLists { get; set; }
        public virtual DbSet<ExcelMappingFieldList> ExcelMappingFieldLists { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<ItemsList> ItemsLists { get; set; }
        public virtual DbSet<JobOrderDetail> JobOrderDetails { get; set; }
        public virtual DbSet<JobOrderMaster> JobOrderMasters { get; set; }
        public virtual DbSet<LabsList> LabsLists { get; set; }
        public virtual DbSet<MaterialsDetail> MaterialsDetails { get; set; }
        public virtual DbSet<MaterialsDetailsTest> MaterialsDetailsTests { get; set; }
        public virtual DbSet<MaterialsType> MaterialsTypes { get; set; }
        public virtual DbSet<MaterialTypesCustomField> MaterialTypesCustomFields { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentMaster> PaymentMasters { get; set; }
        public virtual DbSet<PriceUnitList> PriceUnitLists { get; set; }
        public virtual DbSet<ProjectsList> ProjectsLists { get; set; }
        public virtual DbSet<ProjectsType> ProjectsTypes { get; set; }
        public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }
        public virtual DbSet<QuotationMaster> QuotationMasters { get; set; }
        public virtual DbSet<QuotationWorkOrderList> QuotationWorkOrderLists { get; set; }
        public virtual DbSet<ReportGroup> ReportGroups { get; set; }
        public virtual DbSet<RSSDetail> RSSDetails { get; set; }
        public virtual DbSet<RSSMaster> RSSMasters { get; set; }
        public virtual DbSet<SampleReceiveList> SampleReceiveLists { get; set; }
        public virtual DbSet<SampleReceiveMaterialCustomField> SampleReceiveMaterialCustomFields { get; set; }
        public virtual DbSet<SampleReceiveMaterialTableCustomField> SampleReceiveMaterialTableCustomFields { get; set; }
        public virtual DbSet<SampleReceiveTestInvoice> SampleReceiveTestInvoices { get; set; }
        public virtual DbSet<SampleReceiveTestList> SampleReceiveTestLists { get; set; }
        public virtual DbSet<SubcontractorsList> SubcontractorsLists { get; set; }
        public virtual DbSet<TermsConditionList> TermsConditionLists { get; set; }
        public virtual DbSet<TestContractor> TestContractors { get; set; }
        public virtual DbSet<TestEquipment> TestEquipments { get; set; }
        public virtual DbSet<TestExcelMapping> TestExcelMappings { get; set; }
        public virtual DbSet<TestItem> TestItems { get; set; }
        public virtual DbSet<TestPrice> TestPrices { get; set; }
        public virtual DbSet<TestsList> TestsLists { get; set; }
        public virtual DbSet<TimesheetPaySlip> TimesheetPaySlips { get; set; }
        public virtual DbSet<ValidityList> ValidityLists { get; set; }
        public virtual DbSet<ValidityListDetail> ValidityListDetails { get; set; }
        public virtual DbSet<WorkOrderInvoice> WorkOrderInvoices { get; set; }
        public virtual DbSet<WorkOrderList> WorkOrderLists { get; set; }
        public virtual DbSet<WorkOrderTimeSheet> WorkOrderTimeSheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccreditionList>()
                .HasMany(e => e.TestsLists)
                .WithRequired(e => e.AccreditionList)
                .HasForeignKey(e => e.FKAccreditionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AttachFileTransType>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachFileTransType>()
                .HasMany(e => e.AttachedFiles)
                .WithRequired(e => e.AttachFileTransType)
                .HasForeignKey(e => e.FKTransTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company_Profile>()
                .Property(e => e.GM_Name)
                .IsUnicode(false);

            modelBuilder.Entity<ContractorsList>()
                .HasMany(e => e.ProjectsLists)
                .WithOptional(e => e.ContractorsList)
                .HasForeignKey(e => e.FKContractorID);

            modelBuilder.Entity<CustomersList>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CustomersList>()
                .HasMany(e => e.EnquiryMasters)
                .WithRequired(e => e.CustomersList)
                .HasForeignKey(e => e.FKCustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomersList>()
                .HasMany(e => e.JobOrderMasters)
                .WithRequired(e => e.CustomersList)
                .HasForeignKey(e => e.FKCustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomersList>()
                .HasMany(e => e.PaymentMasters)
                .WithOptional(e => e.CustomersList)
                .HasForeignKey(e => e.FKCustomerID);

            modelBuilder.Entity<CustomersList>()
                .HasMany(e => e.QuotationMasters)
                .WithRequired(e => e.CustomersList)
                .HasForeignKey(e => e.FKCustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomersList>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.CustomersList)
                .HasForeignKey(e => e.FKCustomerID);

            modelBuilder.Entity<EmployeesList>()
                .HasMany(e => e.EquipmentsLists)
                .WithRequired(e => e.EmployeesList)
                .HasForeignKey(e => e.FKEmpID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeesList>()
                .HasMany(e => e.RSSMasters)
                .WithOptional(e => e.EmployeesList)
                .HasForeignKey(e => e.FkEmpId);

            modelBuilder.Entity<EmployeesList>()
                .HasMany(e => e.WorkOrderTimeSheets)
                .WithOptional(e => e.EmployeesList)
                .HasForeignKey(e => e.FkEmpID);

            modelBuilder.Entity<EnquiryDetail>()
                .HasMany(e => e.QuotationDetails)
                .WithOptional(e => e.EnquiryDetail)
                .HasForeignKey(e => e.FKEnquiryDetailsID);

            modelBuilder.Entity<EnquiryMaster>()
                .HasMany(e => e.EnquiryDetails)
                .WithRequired(e => e.EnquiryMaster)
                .HasForeignKey(e => e.FKEnquiryMasterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnquiryMaster>()
                .HasMany(e => e.QuotationMasters)
                .WithOptional(e => e.EnquiryMaster)
                .HasForeignKey(e => e.FKEnquiryMasterID);

            modelBuilder.Entity<EquipmentsList>()
                .HasMany(e => e.TestEquipments)
                .WithRequired(e => e.EquipmentsList)
                .HasForeignKey(e => e.FKEquipmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.PaymentDetails)
                .WithRequired(e => e.Invoice)
                .HasForeignKey(e => e.FKInvoiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.SampleReceiveTestInvoices)
                .WithRequired(e => e.Invoice)
                .HasForeignKey(e => e.FkInvoiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.WorkOrderInvoices)
                .WithRequired(e => e.Invoice)
                .HasForeignKey(e => e.FkInvoiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemsList>()
                .HasMany(e => e.TestItems)
                .WithRequired(e => e.ItemsList)
                .HasForeignKey(e => e.FKItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobOrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 3);

            modelBuilder.Entity<JobOrderDetail>()
                .Property(e => e.MinQty)
                .HasPrecision(18, 3);

            modelBuilder.Entity<JobOrderDetail>()
                .HasMany(e => e.WorkOrderLists)
                .WithOptional(e => e.JobOrderDetail)
                .HasForeignKey(e => e.FKJobOrderDetailsID);

            modelBuilder.Entity<JobOrderMaster>()
                .Property(e => e.ReceiveCreditLimit)
                .HasPrecision(18, 3);

            modelBuilder.Entity<JobOrderMaster>()
                .Property(e => e.ReportCreditLimit)
                .HasPrecision(18, 3);

            modelBuilder.Entity<JobOrderMaster>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.JobOrderMaster)
                .HasForeignKey(e => e.FKJobOrderMasterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobOrderMaster>()
                .HasMany(e => e.JobOrderDetails)
                .WithRequired(e => e.JobOrderMaster)
                .HasForeignKey(e => e.FKJobOrderMasterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobOrderMaster>()
                .HasMany(e => e.PaymentMasters)
                .WithOptional(e => e.JobOrderMaster)
                .HasForeignKey(e => e.FKJobOrderMasterID);

            modelBuilder.Entity<JobOrderMaster>()
                .HasMany(e => e.RSSMasters)
                .WithRequired(e => e.JobOrderMaster)
                .HasForeignKey(e => e.FKJobOrderMasterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobOrderMaster>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.JobOrderMaster)
                .HasForeignKey(e => e.FKJobOrderMasterID);

            modelBuilder.Entity<LabsList>()
                .HasMany(e => e.EquipmentsLists)
                .WithRequired(e => e.LabsList)
                .HasForeignKey(e => e.FKLabID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LabsList>()
                .HasMany(e => e.MaterialsTypes)
                .WithRequired(e => e.LabsList)
                .HasForeignKey(e => e.FKLabID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LabsList>()
                .HasMany(e => e.TestsLists)
                .WithRequired(e => e.LabsList)
                .HasForeignKey(e => e.FKLabID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LabsList>()
                .HasMany(e => e.ValidityLists)
                .WithRequired(e => e.LabsList)
                .HasForeignKey(e => e.FKLabID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialsDetail>()
                .HasMany(e => e.EnquiryDetails)
                .WithOptional(e => e.MaterialsDetail)
                .HasForeignKey(e => e.FKMaterialDetailsID);

            modelBuilder.Entity<MaterialsDetail>()
                .HasMany(e => e.JobOrderDetails)
                .WithOptional(e => e.MaterialsDetail)
                .HasForeignKey(e => e.FKMaterialDetailsID);

            modelBuilder.Entity<MaterialsDetail>()
                .HasMany(e => e.MaterialsDetailsTests)
                .WithRequired(e => e.MaterialsDetail)
                .HasForeignKey(e => e.FKMaterialDetailsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialsDetail>()
                .HasMany(e => e.QuotationDetails)
                .WithOptional(e => e.MaterialsDetail)
                .HasForeignKey(e => e.FKMaterialDetailsID);

            modelBuilder.Entity<MaterialsDetail>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.MaterialsDetail)
                .HasForeignKey(e => e.FKMaterialDetailsID);

            modelBuilder.Entity<MaterialsType>()
                .HasMany(e => e.EnquiryDetails)
                .WithOptional(e => e.MaterialsType)
                .HasForeignKey(e => e.FKMaterialTypeID);

            modelBuilder.Entity<MaterialsType>()
                .HasMany(e => e.JobOrderDetails)
                .WithOptional(e => e.MaterialsType)
                .HasForeignKey(e => e.FKMaterialTypeID);

            modelBuilder.Entity<MaterialsType>()
                .HasMany(e => e.MaterialsDetails)
                .WithRequired(e => e.MaterialsType)
                .HasForeignKey(e => e.FKMaterialTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialsType>()
                .HasMany(e => e.MaterialTypesCustomFields)
                .WithRequired(e => e.MaterialsType)
                .HasForeignKey(e => e.FKMaterialTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialsType>()
                .HasMany(e => e.QuotationDetails)
                .WithOptional(e => e.MaterialsType)
                .HasForeignKey(e => e.FKMaterialTypeID);

            modelBuilder.Entity<MaterialsType>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.MaterialsType)
                .HasForeignKey(e => e.FKMaterialTypeID);

            modelBuilder.Entity<MaterialTypesCustomField>()
                .HasMany(e => e.SampleReceiveMaterialCustomFields)
                .WithRequired(e => e.MaterialTypesCustomField)
                .HasForeignKey(e => e.FkCustomFieldID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialTypesCustomField>()
                .HasMany(e => e.SampleReceiveMaterialTableCustomFields)
                .WithOptional(e => e.MaterialTypesCustomField)
                .HasForeignKey(e => e.FkCustomFieldID);

            modelBuilder.Entity<PaymentMaster>()
                .HasMany(e => e.PaymentDetails)
                .WithRequired(e => e.PaymentMaster)
                .HasForeignKey(e => e.FKPaymentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceUnitList>()
                .HasMany(e => e.EnquiryDetails)
                .WithRequired(e => e.PriceUnitList)
                .HasForeignKey(e => e.FKPriceUnitID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceUnitList>()
                .HasMany(e => e.JobOrderDetails)
                .WithRequired(e => e.PriceUnitList)
                .HasForeignKey(e => e.FKPriceUnitID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceUnitList>()
                .HasMany(e => e.QuotationDetails)
                .WithRequired(e => e.PriceUnitList)
                .HasForeignKey(e => e.FKPriceUnitID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceUnitList>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.PriceUnitList)
                .HasForeignKey(e => e.FKPriceUnitID);

            modelBuilder.Entity<PriceUnitList>()
                .HasMany(e => e.SampleReceiveTestLists)
                .WithOptional(e => e.PriceUnitList)
                .HasForeignKey(e => e.FKPriceUnitID);

            modelBuilder.Entity<PriceUnitList>()
                .HasMany(e => e.TestPrices)
                .WithRequired(e => e.PriceUnitList)
                .HasForeignKey(e => e.FKPriceUnitID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectsList>()
                .HasMany(e => e.EnquiryMasters)
                .WithRequired(e => e.ProjectsList)
                .HasForeignKey(e => e.FKProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectsList>()
                .HasMany(e => e.JobOrderMasters)
                .WithRequired(e => e.ProjectsList)
                .HasForeignKey(e => e.FKProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectsList>()
                .HasMany(e => e.QuotationMasters)
                .WithRequired(e => e.ProjectsList)
                .HasForeignKey(e => e.FKProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectsList>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.ProjectsList)
                .HasForeignKey(e => e.FKProjectID);

            modelBuilder.Entity<ProjectsType>()
                .HasMany(e => e.ProjectsLists)
                .WithRequired(e => e.ProjectsType)
                .HasForeignKey(e => e.FKProjectTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuotationDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 3);

            modelBuilder.Entity<QuotationDetail>()
                .Property(e => e.MinQty)
                .HasPrecision(18, 3);

            modelBuilder.Entity<QuotationDetail>()
                .HasMany(e => e.JobOrderDetails)
                .WithOptional(e => e.QuotationDetail)
                .HasForeignKey(e => e.FKQuotationDetailsID);

            modelBuilder.Entity<QuotationDetail>()
                .HasMany(e => e.QuotationWorkOrderLists)
                .WithOptional(e => e.QuotationDetail)
                .HasForeignKey(e => e.FkQuotationDetailsID);

            modelBuilder.Entity<QuotationMaster>()
                .HasMany(e => e.JobOrderMasters)
                .WithOptional(e => e.QuotationMaster)
                .HasForeignKey(e => e.FKQuotationMasterID);

            modelBuilder.Entity<QuotationMaster>()
                .HasMany(e => e.QuotationDetails)
                .WithRequired(e => e.QuotationMaster)
                .HasForeignKey(e => e.FKQuotationMasterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReportGroup>()
                .HasMany(e => e.TestsLists)
                .WithOptional(e => e.ReportGroup)
                .HasForeignKey(e => e.FkGroupId);

            modelBuilder.Entity<RSSMaster>()
                .HasMany(e => e.RSSDetails)
                .WithRequired(e => e.RSSMaster)
                .HasForeignKey(e => e.FkRSSMasterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RSSMaster>()
                .HasMany(e => e.SampleReceiveLists)
                .WithOptional(e => e.RSSMaster)
                .HasForeignKey(e => e.FKRSSMasterId);

            modelBuilder.Entity<SampleReceiveList>()
                .Property(e => e.ReceivedQty)
                .HasPrecision(18, 3);

            modelBuilder.Entity<SampleReceiveList>()
                .HasOptional(e => e.SampleReceiveList1)
                .WithRequired(e => e.SampleReceiveList2);

            modelBuilder.Entity<SampleReceiveList>()
                .HasOptional(e => e.SampleReceiveList11)
                .WithRequired(e => e.SampleReceiveList3);

            modelBuilder.Entity<SampleReceiveList>()
                .HasMany(e => e.SampleReceiveMaterialCustomFields)
                .WithRequired(e => e.SampleReceiveList)
                .HasForeignKey(e => e.FkSampleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SampleReceiveList>()
                .HasMany(e => e.SampleReceiveMaterialTableCustomFields)
                .WithOptional(e => e.SampleReceiveList)
                .HasForeignKey(e => e.FkSampleID);

            modelBuilder.Entity<SampleReceiveList>()
                .HasMany(e => e.SampleReceiveTestLists)
                .WithOptional(e => e.SampleReceiveList)
                .HasForeignKey(e => e.FKSampleID);

            modelBuilder.Entity<SampleReceiveTestList>()
                .Property(e => e.Price)
                .HasPrecision(18, 3);

            modelBuilder.Entity<SampleReceiveTestList>()
                .Property(e => e.Qty)
                .HasPrecision(18, 3);

            modelBuilder.Entity<SampleReceiveTestList>()
                .HasMany(e => e.SampleReceiveTestInvoices)
                .WithRequired(e => e.SampleReceiveTestList)
                .HasForeignKey(e => e.FkSampleReceiveTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubcontractorsList>()
                .HasMany(e => e.SampleReceiveTestLists)
                .WithOptional(e => e.SubcontractorsList)
                .HasForeignKey(e => e.FKSubContractorID);

            modelBuilder.Entity<SubcontractorsList>()
                .HasMany(e => e.TestContractors)
                .WithRequired(e => e.SubcontractorsList)
                .HasForeignKey(e => e.FKSubContractorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TermsConditionList>()
                .HasMany(e => e.QuotationMasters)
                .WithOptional(e => e.TermsConditionList)
                .HasForeignKey(e => e.FKTermsConditionsID);

            modelBuilder.Entity<TestPrice>()
                .Property(e => e.DefaultPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TestPrice>()
                .Property(e => e.MinimumPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TestsList>()
                .Property(e => e.DefaultPrice)
                .HasPrecision(23, 2);

            modelBuilder.Entity<TestsList>()
                .Property(e => e.MinimumPrice)
                .HasPrecision(23, 2);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.EnquiryDetails)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.JobOrderDetails)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.MaterialsDetailsTests)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.QuotationDetails)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.RSSDetails)
                .WithOptional(e => e.TestsList)
                .HasForeignKey(e => e.FkTestId);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.SampleReceiveTestLists)
                .WithOptional(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.TestContractors)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.TestEquipments)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.TestExcelMappings)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.TestItems)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestsList>()
                .HasMany(e => e.TestPrices)
                .WithRequired(e => e.TestsList)
                .HasForeignKey(e => e.FKTestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ValidityList>()
                .HasMany(e => e.ValidityListDetails)
                .WithRequired(e => e.ValidityList)
                .HasForeignKey(e => e.FKValidityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkOrderList>()
                .HasMany(e => e.TimesheetPaySlips)
                .WithRequired(e => e.WorkOrderList)
                .HasForeignKey(e => e.FKWorkOrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkOrderList>()
                .HasMany(e => e.WorkOrderInvoices)
                .WithRequired(e => e.WorkOrderList)
                .HasForeignKey(e => e.FkWorkOrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkOrderList>()
                .HasMany(e => e.WorkOrderTimeSheets)
                .WithRequired(e => e.WorkOrderList)
                .HasForeignKey(e => e.FkWorkOrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.HourlyRate)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.OTRate)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.NormalWorkingHours)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.RamadanWorkingHours)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.OTWorkingHours)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.TotalWorkingPrice)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WorkOrderTimeSheet>()
                .Property(e => e.TotalAdditionalPrice)
                .HasPrecision(18, 12);
        }
    }
}
