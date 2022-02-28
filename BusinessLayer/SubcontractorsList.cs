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
    
    public partial class SubcontractorsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubcontractorsList()
        {
            this.SampleReceiveTestList = new HashSet<SampleReceiveTestList>();
            this.TestContractors = new HashSet<TestContractors>();
        }
    
        public int SubContractorID { get; set; }
        public string SubContractorCode { get; set; }
        public string SubContractorName { get; set; }
        public Nullable<System.DateTime> AccreditationExpiryDate { get; set; }
        public string Address { get; set; }
        public bool IsLocked { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestList> SampleReceiveTestList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestContractors> TestContractors { get; set; }
    }
}
