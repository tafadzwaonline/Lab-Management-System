namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomersList")]
    public partial class CustomersList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomersList()
        {
            EnquiryMasters = new HashSet<EnquiryMaster>();
            JobOrderMasters = new HashSet<JobOrderMaster>();
            PaymentMasters = new HashSet<PaymentMaster>();
            QuotationMasters = new HashSet<QuotationMaster>();
            SampleReceiveLists = new HashSet<SampleReceiveList>();
        }

        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string FaxNumber { get; set; }

        [StringLength(50)]
        public string POBox { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public string website { get; set; }

        [StringLength(200)]
        public string ContactName { get; set; }

        [StringLength(50)]
        public string ContactMobileNumber { get; set; }

        public string Address { get; set; }

        public int PaymentMode { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryMaster> EnquiryMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderMaster> JobOrderMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentMaster> PaymentMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationMaster> QuotationMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveList> SampleReceiveLists { get; set; }
    }
}
