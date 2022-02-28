namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentMaster")]
    public partial class PaymentMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentMaster()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        [Key]
        public long PaymentID { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ReferenceNumber { get; set; }

        public int? FKCustomerID { get; set; }

        public int PaymentType { get; set; }

        public decimal PaymentAmount { get; set; }

        public string Remarks { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsApproved { get; set; }

        public long? FKJobOrderMasterID { get; set; }

        [StringLength(200)]
        public string ReceivedBy { get; set; }

        public virtual CustomersList CustomersList { get; set; }

        public virtual JobOrderMaster JobOrderMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
