namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkOrderList")]
    public partial class WorkOrderList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkOrderList()
        {
            TimesheetPaySlips = new HashSet<TimesheetPaySlip>();
            WorkOrderInvoices = new HashSet<WorkOrderInvoice>();
            WorkOrderTimeSheets = new HashSet<WorkOrderTimeSheet>();
        }

        [Key]
        public long WorkOrderID { get; set; }

        [StringLength(50)]
        public string WorkOrderNo { get; set; }

        public long? FKJobOrderDetailsID { get; set; }

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

        public virtual JobOrderDetail JobOrderDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimesheetPaySlip> TimesheetPaySlips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderInvoice> WorkOrderInvoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderTimeSheet> WorkOrderTimeSheets { get; set; }
    }
}
