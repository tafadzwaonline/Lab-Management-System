namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LabsList")]
    public partial class LabsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LabsList()
        {
            EquipmentsLists = new HashSet<EquipmentsList>();
            MaterialsTypes = new HashSet<MaterialsType>();
            TestsLists = new HashSet<TestsList>();
            ValidityLists = new HashSet<ValidityList>();
        }

        [Key]
        public int LabID { get; set; }

        [Required]
        [StringLength(200)]
        public string LabName { get; set; }

        public string Remarks { get; set; }

        [StringLength(250)]
        public string LabInCharge { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentsList> EquipmentsLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsType> MaterialsTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestsList> TestsLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidityList> ValidityLists { get; set; }
    }
}
