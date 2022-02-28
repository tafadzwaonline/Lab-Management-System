namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobOrderMaster")]
    public partial class JobOrderMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobOrderMaster()
        {
            Invoices = new HashSet<Invoice>();
            JobOrderDetails = new HashSet<JobOrderDetail>();
            PaymentMasters = new HashSet<PaymentMaster>();
            RSSMasters = new HashSet<RSSMaster>();
            SampleReceiveLists = new HashSet<SampleReceiveList>();
        }

        public long JobOrderMasterID { get; set; }

        public DateTime? TransactionDate { get; set; }

        public long? FKQuotationMasterID { get; set; }

        public int FKCustomerID { get; set; }

        [StringLength(250)]
        public string LPONumber { get; set; }

        public decimal? ReceiveCreditLimit { get; set; }

        public decimal? ReportCreditLimit { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int FKProjectID { get; set; }

        public string Remarks { get; set; }

        public bool IsClosed { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int? UnpaidReceiveLimit { get; set; }

        [StringLength(50)]
        public string JobOrderNumber { get; set; }

        public int StatusID { get; set; }

        public virtual CustomersList CustomersList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderDetail> JobOrderDetails { get; set; }

        public virtual ProjectsList ProjectsList { get; set; }

        public virtual QuotationMaster QuotationMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentMaster> PaymentMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSSMaster> RSSMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveList> SampleReceiveLists { get; set; }
    }
}
