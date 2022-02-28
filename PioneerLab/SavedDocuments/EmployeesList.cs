namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeesList")]
    public partial class EmployeesList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeesList()
        {
            EquipmentsLists = new HashSet<EquipmentsList>();
            RSSMasters = new HashSet<RSSMaster>();
            WorkOrderTimeSheets = new HashSet<WorkOrderTimeSheet>();
        }

        [Key]
        public int EmpID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpCode { get; set; }

        [Required]
        [StringLength(200)]
        public string EmpName { get; set; }

        [StringLength(200)]
        public string Profession { get; set; }

        [StringLength(50)]
        public string QID { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public int? NormalWorkHrs { get; set; }

        public int? RamadanWorkHrs { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentsList> EquipmentsLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSSMaster> RSSMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderTimeSheet> WorkOrderTimeSheets { get; set; }
    }
}
