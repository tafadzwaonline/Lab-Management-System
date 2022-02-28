namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimesheetPaySlip")]
    public partial class TimesheetPaySlip
    {
        [Key]
        public long PaySlipID { get; set; }

        public long FKWorkOrderId { get; set; }

        public int? NoOfWorkingDays { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? OTRate { get; set; }

        public decimal? NormalWorkingHours { get; set; }

        public decimal? RamadanWorkingHours { get; set; }

        public decimal? OTWorkingHours { get; set; }

        public virtual WorkOrderList WorkOrderList { get; set; }
    }
}
