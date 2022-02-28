namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkOrderTimeSheet")]
    public partial class WorkOrderTimeSheet
    {
        public long WorkOrderTimeSheetId { get; set; }

        public long FkWorkOrderID { get; set; }

        public int? FkEmpID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [StringLength(50)]
        public string Day { get; set; }

        [StringLength(200)]
        public string WorkStatus { get; set; }

        public decimal? Breake { get; set; }

        public bool? IsRamadan { get; set; }

        public bool? IsInvoiced { get; set; }

        [StringLength(200)]
        public string InvoiceNumber { get; set; }

        public decimal? WorkHrs { get; set; }

        public string Remarks { get; set; }

        public bool? IsChecked { get; set; }

        public long? CheckedBy { get; set; }

        public DateTime? CheckedDate { get; set; }

        public bool? IsApproved { get; set; }

        public long? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? OTRate { get; set; }

        public decimal? NormalWorkingHours { get; set; }

        public decimal? RamadanWorkingHours { get; set; }

        public decimal? OTWorkingHours { get; set; }

        public decimal? TotalWorkingPrice { get; set; }

        public decimal? TotalAdditionalPrice { get; set; }

        public int? ShiftStatus { get; set; }

        public virtual EmployeesList EmployeesList { get; set; }

        public virtual WorkOrderList WorkOrderList { get; set; }
    }
}
