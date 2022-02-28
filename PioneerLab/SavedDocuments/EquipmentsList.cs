namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipmentsList")]
    public partial class EquipmentsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipmentsList()
        {
            TestEquipments = new HashSet<TestEquipment>();
        }

        [Key]
        public int EquipmentID { get; set; }

        [Required]
        [StringLength(200)]
        public string EquipmentName { get; set; }

        public int FKLabID { get; set; }

        public DateTime? CalibrationDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int FKEmpID { get; set; }

        [StringLength(200)]
        public string CalibratedBy { get; set; }

        public string Remarks { get; set; }

        public virtual EmployeesList EmployeesList { get; set; }

        public virtual LabsList LabsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestEquipment> TestEquipments { get; set; }
    }
}
