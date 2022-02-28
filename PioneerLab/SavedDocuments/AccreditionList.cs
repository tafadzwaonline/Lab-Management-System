namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccreditionList")]
    public partial class AccreditionList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccreditionList()
        {
            TestsLists = new HashSet<TestsList>();
        }

        [Key]
        public int AccreditionID { get; set; }

        [Required]
        [StringLength(200)]
        public string AccreditionName { get; set; }

        public string Remarks { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestsList> TestsLists { get; set; }
    }
}
