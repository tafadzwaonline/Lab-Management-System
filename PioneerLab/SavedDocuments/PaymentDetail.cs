namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentDetail
    {
        [Key]
        public long PaymentDetID { get; set; }

        public long FKPaymentID { get; set; }

        public long FKInvoiceId { get; set; }

        public decimal PaidAmount { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual PaymentMaster PaymentMaster { get; set; }
    }
}
