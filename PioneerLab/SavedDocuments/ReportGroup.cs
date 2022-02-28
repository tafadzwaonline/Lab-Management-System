namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportGroup")]
    public partial class ReportGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportGroup()
        {
            TestsLists = new HashSet<TestsList>();
        }

        [Key]
        public int GroupID { get; set; }

        [Required]
        [StringLength(200)]
        public string GroupName { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestsList> TestsLists { get; set; }
    }
}
