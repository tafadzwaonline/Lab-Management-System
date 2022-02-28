namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkOrderInvoice")]
    public partial class WorkOrderInvoice
    {
        public long WorkOrderInvoiceId { get; set; }

        public long FkInvoiceId { get; set; }

        public long FkWorkOrderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual WorkOrderList WorkOrderList { get; set; }
    }
}
