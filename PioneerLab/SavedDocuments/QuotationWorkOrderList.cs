namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuotationWorkOrderList")]
    public partial class QuotationWorkOrderList
    {
        [Key]
        public long QuotationWorkOrderID { get; set; }

        [StringLength(50)]
        public string WorkOrderNo { get; set; }

        public long? FkQuotationDetailsID { get; set; }

        public long? FKAgreementID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(200)]
        public string SiteName { get; set; }

        public int? ShiftStatus { get; set; }

        public decimal? RegularWorkHrs { get; set; }

        public decimal? RamadanWorkHrs { get; set; }

        public decimal? MonthlyRate { get; set; }

        [StringLength(50)]
        public string UnitOfAddition { get; set; }

        public decimal? ExtraWorkHourRate { get; set; }

        public decimal? NightShiftPerc { get; set; }

        public DateTime? TransDate { get; set; }

        public string Description { get; set; }

        public virtual QuotationDetail QuotationDetail { get; set; }
    }
}
