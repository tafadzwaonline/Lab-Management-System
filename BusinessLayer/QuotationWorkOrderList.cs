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
    
    public partial class QuotationWorkOrderList
    {
        public long FKQuotationMasterID { get; set; }
        public int RowStatus { get; set; }

        public long QuotationWorkOrderID { get; set; }
        public string WorkOrderNo { get; set; }
        public Nullable<long> FkQuotationDetailsID { get; set; }
        public Nullable<long> FKAgreementID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string SiteName { get; set; }
        public Nullable<int> ShiftStatus { get; set; }
        public Nullable<decimal> RegularWorkHrs { get; set; }
        public Nullable<decimal> RamadanWorkHrs { get; set; }
        public Nullable<decimal> MonthlyRate { get; set; }
        public string UnitOfAddition { get; set; }
        public Nullable<decimal> ExtraWorkHourRate { get; set; }
        public Nullable<decimal> NightShiftPerc { get; set; }
        public Nullable<System.DateTime> TransDate { get; set; }
        public string Description { get; set; }
    
        public virtual QuotationDetails QuotationDetails { get; set; }
    }
}
