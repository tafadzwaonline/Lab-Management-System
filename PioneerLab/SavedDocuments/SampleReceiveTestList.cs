namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleReceiveTestList")]
    public partial class SampleReceiveTestList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SampleReceiveTestList()
        {
            SampleReceiveTestInvoices = new HashSet<SampleReceiveTestInvoice>();
        }

        [Key]
        public long SampleReceiveTestID { get; set; }

        public long? FKSampleID { get; set; }

        public int? FKTestID { get; set; }

        public int? FKPriceUnitID { get; set; }

        public decimal? Price { get; set; }

        public decimal? Qty { get; set; }

        public bool Witness { get; set; }

        [StringLength(250)]
        public string WitnessName { get; set; }

        public bool Subcontract { get; set; }

        public int? FKSubContractorID { get; set; }

        public string Remarks { get; set; }

        public bool Inactive { get; set; }

        public bool IsInvoiced { get; set; }

        public bool? IsChecked { get; set; }

        public long? CheckedBy { get; set; }

        public DateTime? CheckedDate { get; set; }

        public bool? IsApproved { get; set; }

        public long? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public int? ReportNumber { get; set; }

        public virtual PriceUnitList PriceUnitList { get; set; }

        public virtual SampleReceiveList SampleReceiveList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestInvoice> SampleReceiveTestInvoices { get; set; }

        public virtual SubcontractorsList SubcontractorsList { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
