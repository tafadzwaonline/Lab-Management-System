namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialTypesCustomField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialTypesCustomField()
        {
            SampleReceiveMaterialCustomFields = new HashSet<SampleReceiveMaterialCustomField>();
            SampleReceiveMaterialTableCustomFields = new HashSet<SampleReceiveMaterialTableCustomField>();
        }

        [Key]
        public int CustomFieldID { get; set; }

        public int FKMaterialTypeID { get; set; }

        [StringLength(200)]
        public string CustomFieldName { get; set; }

        public int DataType { get; set; }

        public bool IsRequired { get; set; }

        public bool IsLocked { get; set; }

        public virtual MaterialsType MaterialsType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveMaterialCustomField> SampleReceiveMaterialCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveMaterialTableCustomField> SampleReceiveMaterialTableCustomFields { get; set; }
    }
}
