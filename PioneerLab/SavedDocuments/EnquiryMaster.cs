namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EnquiryMaster")]
    public partial class EnquiryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnquiryMaster()
        {
            EnquiryDetails = new HashSet<EnquiryDetail>();
            QuotationMasters = new HashSet<QuotationMaster>();
        }

        public long EnquiryMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string EnquiryCode { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime? EntryDate { get; set; }

        public int FKCustomerID { get; set; }

        public int FKProjectID { get; set; }

        public int? EnquiryMethodID { get; set; }

        [StringLength(100)]
        public string CustomerReference { get; set; }

        [StringLength(150)]
        public string ContactPerson { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        [StringLength(100)]
        public string ContactJobTitle { get; set; }

        [StringLength(100)]
        public string ContactEmail { get; set; }

        public string Remarks { get; set; }

        [StringLength(100)]
        public string EnterdBy { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? ReceivingDate { get; set; }

        public virtual CustomersList CustomersList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryDetail> EnquiryDetails { get; set; }

        public virtual ProjectsList ProjectsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationMaster> QuotationMasters { get; set; }
    }
}
