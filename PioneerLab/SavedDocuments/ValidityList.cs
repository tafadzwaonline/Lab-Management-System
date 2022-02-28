namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValidityList")]
    public partial class ValidityList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ValidityList()
        {
            ValidityListDetails = new HashSet<ValidityListDetail>();
        }

        [Key]
        public int ValidityID { get; set; }

        [Required]
        [StringLength(50)]
        public string ValidityCode { get; set; }

        [Required]
        [StringLength(200)]
        public string ValidityName { get; set; }

        public int FKLabID { get; set; }

        public bool IsLocked { get; set; }

        public virtual LabsList LabsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValidityListDetail> ValidityListDetails { get; set; }
    }
}
