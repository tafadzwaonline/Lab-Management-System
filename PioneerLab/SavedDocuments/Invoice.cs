namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
            SampleReceiveTestInvoices = new HashSet<SampleReceiveTestInvoice>();
            WorkOrderInvoices = new HashSet<WorkOrderInvoice>();
        }

        public long InvoiceId { get; set; }

        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [StringLength(50)]
        public string InvoiceRefNo { get; set; }

        public long FKJobOrderMasterID { get; set; }

        public decimal? SRTTotal { get; set; }

        public decimal? TSTotal { get; set; }

        public decimal? InvoiceTotal { get; set; }

        public decimal? Disount { get; set; }

        public decimal? NetAmount { get; set; }

        public string ProvideDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceEndDate { get; set; }

        public virtual JobOrderMaster JobOrderMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestInvoice> SampleReceiveTestInvoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderInvoice> WorkOrderInvoices { get; set; }
    }
}
