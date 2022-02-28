namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemsList")]
    public partial class ItemsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemsList()
        {
            TestItems = new HashSet<TestItem>();
        }

        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        public int? ItemNumber { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public bool IsLocked { get; set; }

        [StringLength(50)]
        public string UnitOfMeasure { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestItem> TestItems { get; set; }
    }
}
