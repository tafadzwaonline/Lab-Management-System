//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimesheetPaySlip
    {
        public long PaySlipID { get; set; }
        public long FKWorkOrderId { get; set; }
        public Nullable<int> NoOfWorkingDays { get; set; }
        public Nullable<decimal> HourlyRate { get; set; }
        public Nullable<decimal> OTRate { get; set; }
        public Nullable<decimal> NormalWorkingHours { get; set; }
        public Nullable<decimal> RamadanWorkingHours { get; set; }
        public Nullable<decimal> OTWorkingHours { get; set; }
    
        public virtual WorkOrderList WorkOrderList { get; set; }
    }
}