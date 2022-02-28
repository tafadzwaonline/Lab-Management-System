namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestsList")]
    public partial class TestsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestsList()
        {
            EnquiryDetails = new HashSet<EnquiryDetail>();
            JobOrderDetails = new HashSet<JobOrderDetail>();
            MaterialsDetailsTests = new HashSet<MaterialsDetailsTest>();
            QuotationDetails = new HashSet<QuotationDetail>();
            RSSDetails = new HashSet<RSSDetail>();
            SampleReceiveTestLists = new HashSet<SampleReceiveTestList>();
            TestContractors = new HashSet<TestContractor>();
            TestEquipments = new HashSet<TestEquipment>();
            TestExcelMappings = new HashSet<TestExcelMapping>();
            TestItems = new HashSet<TestItem>();
            TestPrices = new HashSet<TestPrice>();
        }

        [Key]
        public int TestID { get; set; }

        [Required]
        [StringLength(200)]
        public string StandardNumber { get; set; }

        [StringLength(200)]
        public string AshghalTestNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string TestName { get; set; }

        public string TestDescription { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        public int FKAccreditionID { get; set; }

        public int FKLabID { get; set; }

        [StringLength(100)]
        public string ResultUnit { get; set; }

        [StringLength(200)]
        public string ResultSpecs { get; set; }

        [StringLength(50)]
        public string SamplingMethod { get; set; }

        [StringLength(200)]
        public string WorkFormFileName { get; set; }

        [StringLength(100)]
        public string WorkFormWorksheet { get; set; }

        [StringLength(200)]
        public string ReportFileName { get; set; }

        [StringLength(100)]
        public string ReportWorksheet { get; set; }

        public decimal? DefaultPrice { get; set; }

        public decimal? MinimumPrice { get; set; }

        public bool IsLocked { get; set; }

        public bool IsSubcontractedTest { get; set; }

        public bool IsSiteTest { get; set; }

        public int? FKTestID { get; set; }

        public bool IsUnavailable { get; set; }

        public int? FkGroupId { get; set; }

        public string Image { get; set; }

        public virtual AccreditionList AccreditionList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryDetail> EnquiryDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderDetail> JobOrderDetails { get; set; }

        public virtual LabsList LabsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsDetailsTest> MaterialsDetailsTests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }

        public virtual ReportGroup ReportGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSSDetail> RSSDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestList> SampleReceiveTestLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestContractor> TestContractors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestEquipment> TestEquipments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestExcelMapping> TestExcelMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestItem> TestItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestPrice> TestPrices { get; set; }
    }
}
