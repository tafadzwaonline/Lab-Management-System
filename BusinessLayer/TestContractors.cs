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
    
    public partial class TestContractors
    {
        public int TestContractorsID { get; set; }
        public int FKTestID { get; set; }
        public int FKSubContractorID { get; set; }
    
        public virtual SubcontractorsList SubcontractorsList { get; set; }
        public virtual TestsList TestsList { get; set; }
    }
}
