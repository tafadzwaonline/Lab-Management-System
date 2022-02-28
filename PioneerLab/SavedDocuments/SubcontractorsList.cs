namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubcontractorsList")]
    public partial class SubcontractorsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubcontractorsList()
        {
            SampleReceiveTestLists = new HashSet<SampleReceiveTestList>();
            TestContractors = new HashSet<TestContractor>();
        }

        [Key]
        public int SubContractorID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubContractorCode { get; set; }

        [StringLength(200)]
        public string SubContractorName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AccreditationExpiryDate { get; set; }

        public string Address { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestList> SampleReceiveTestLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestContractor> TestContractors { get; set; }
    }
}
