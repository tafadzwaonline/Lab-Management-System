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
    
    public partial class TestPrices
    {
        public int TestPriceID { get; set; }
        public int FKTestID { get; set; }
        public int FKPriceUnitID { get; set; }
        public Nullable<decimal> DefaultPrice { get; set; }
        public Nullable<decimal> MinimumPrice { get; set; }
    
        public virtual PriceUnitList PriceUnitList { get; set; }
        public virtual TestsList TestsList { get; set; }
    }
}