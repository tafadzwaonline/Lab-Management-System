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
    
    public partial class ViewSampleReceiveTests
    {
        public Nullable<long> JobOrderMasterID { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string JobOrderNumber { get; set; }
        public string SampleNo { get; set; }
        public Nullable<long> SampleID { get; set; }
        public Nullable<System.DateTime> SamplingDate { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public Nullable<int> FKTestID { get; set; }
        public Nullable<int> FKPriceUnitID { get; set; }
        public Nullable<long> FKSampleID { get; set; }
        public long SampleReceiveTestID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public bool Witness { get; set; }
        public bool IsInvoiced { get; set; }
        public Nullable<bool> IsChecked { get; set; }
        public Nullable<long> CheckedBy { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.DateTime> CheckedDate { get; set; }
        public Nullable<long> ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<int> FKCustomerID { get; set; }
        public long FkInvoiceId { get; set; }
        public long InvoiceId { get; set; }
        public Nullable<long> FkSampleReceiveTestID { get; set; }
        public Nullable<int> UnitType { get; set; }
    }
}
