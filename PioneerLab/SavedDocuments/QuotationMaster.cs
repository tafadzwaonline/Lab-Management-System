namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuotationMaster")]
    public partial class QuotationMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuotationMaster()
        {
            JobOrderMasters = new HashSet<JobOrderMaster>();
            QuotationDetails = new HashSet<QuotationDetail>();
        }

        public long QuotationMasterID { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public long? FKEnquiryMasterID { get; set; }

        public int FKCustomerID { get; set; }

        public int FKProjectID { get; set; }

        public string Remarks { get; set; }

        public bool IsClosed { get; set; }

        public bool IsActive { get; set; }

        public int StatusID { get; set; }

        public string PaymentTerms { get; set; }

        public int? FKTermsConditionsID { get; set; }

        [StringLength(50)]
        public string QuotationNo { get; set; }

        public bool ShowTotal { get; set; }

        [StringLength(200)]
        public string ApprovedBy { get; set; }

        public bool? IsAddedTojo { get; set; }

        public virtual CustomersList CustomersList { get; set; }

        public virtual EnquiryMaster EnquiryMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderMaster> JobOrderMasters { get; set; }

        public virtual ProjectsList ProjectsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }

        public virtual TermsConditionList TermsConditionList { get; set; }
    }
}
