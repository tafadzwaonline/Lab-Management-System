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
    
    public partial class ViewJobOrderTestList
    {
        public long JobOrderMasterID { get; set; }
        public Nullable<long> FKQuotationMasterID { get; set; }
        public int FKCustomerID { get; set; }
        public int FKProjectID { get; set; }
        public Nullable<decimal> ReceiveCreditLimit { get; set; }
        public Nullable<decimal> ReportCreditLimit { get; set; }
        public Nullable<int> UnpaidReceiveLimit { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public bool IsClosed { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long JobOrderDetailsID { get; set; }
        public int FKTestID { get; set; }
        public Nullable<int> FKPriceUnitID { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
    }
}
