namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractorsList")]
    public partial class ContractorsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractorsList()
        {
            ProjectsLists = new HashSet<ProjectsList>();
        }

        [Key]
        public int ContractorID { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractorCode { get; set; }

        [Required]
        [StringLength(200)]
        public string ContractorName { get; set; }

        [StringLength(200)]
        public string ContractorCarrier { get; set; }

        public string Location { get; set; }

        [StringLength(200)]
        public string GMName { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string FaxNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string website { get; set; }

        public string Address { get; set; }

        public bool IsLocked { get; set; }

        public int? ContractorType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectsList> ProjectsLists { get; set; }
    }
}
