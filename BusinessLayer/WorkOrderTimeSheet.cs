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
    
    public partial class WorkOrderTimeSheet
    {
        public long WorkOrderTimeSheetId { get; set; }
        public long FkWorkOrderID { get; set; }
        public Nullable<int> FkEmpID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Day { get; set; }
        public string WorkStatus { get; set; }
        public Nullable<decimal> Breake { get; set; }
        public Nullable<bool> IsRamadan { get; set; }
        public Nullable<bool> IsInvoiced { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<decimal> WorkHrs { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsChecked { get; set; }
        public Nullable<long> CheckedBy { get; set; }
        public Nullable<System.DateTime> CheckedDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<long> ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<decimal> HourlyRate { get; set; }
        public Nullable<decimal> OTRate { get; set; }
        public Nullable<decimal> NormalWorkingHours { get; set; }
        public Nullable<decimal> RamadanWorkingHours { get; set; }
        public Nullable<decimal> OTWorkingHours { get; set; }
        public Nullable<decimal> TotalWorkingPrice { get; set; }
        public Nullable<decimal> TotalAdditionalPrice { get; set; }
        public Nullable<int> ShiftStatus { get; set; }
    
        public virtual EmployeesList EmployeesList { get; set; }
        public virtual WorkOrderList WorkOrderList { get; set; }
    }
}
