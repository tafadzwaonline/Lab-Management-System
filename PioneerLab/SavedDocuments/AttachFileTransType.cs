namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttachFileTransType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttachFileTransType()
        {
            AttachedFiles = new HashSet<AttachedFile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransTypeID { get; set; }

        [StringLength(50)]
        public string TransName { get; set; }

        public int? FKModuleID { get; set; }

        [StringLength(100)]
        public string TableName { get; set; }

        [StringLength(150)]
        public string PageUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}
