namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleReceiveTestInvoice")]
    public partial class SampleReceiveTestInvoice
    {
        public long SampleReceiveTestInvoiceID { get; set; }

        public long FkInvoiceId { get; set; }

        public long FkSampleReceiveTestID { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual SampleReceiveTestList SampleReceiveTestList { get; set; }
    }
}
