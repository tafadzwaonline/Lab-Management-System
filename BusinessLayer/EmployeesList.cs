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
    
    public partial class EmployeesList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeesList()
        {
            this.EquipmentsList = new HashSet<EquipmentsList>();
            this.RSSMaster = new HashSet<RSSMaster>();
            this.WorkOrderTimeSheet = new HashSet<WorkOrderTimeSheet>();
        }
    
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Profession { get; set; }
        public string QID { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> NormalWorkHrs { get; set; }
        public Nullable<int> RamadanWorkHrs { get; set; }
        public bool IsLocked { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentsList> EquipmentsList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSSMaster> RSSMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderTimeSheet> WorkOrderTimeSheet { get; set; }
    }
}
