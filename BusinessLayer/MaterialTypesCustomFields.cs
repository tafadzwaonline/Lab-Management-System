//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialTypesCustomFields
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialTypesCustomFields()
        {
            this.SampleReceiveMaterialCustomField = new HashSet<SampleReceiveMaterialCustomField>();
            this.SampleReceiveMaterialTableCustomField = new HashSet<SampleReceiveMaterialTableCustomField>();
        }
    
        public int CustomFieldID { get; set; }
        public int FKMaterialTypeID { get; set; }
        public string CustomFieldName { get; set; }
        public int DataType { get; set; }
        public bool IsRequired { get; set; }
        public bool IsLocked { get; set; }
    
        public virtual MaterialsTypes MaterialsTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveMaterialCustomField> SampleReceiveMaterialCustomField { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveMaterialTableCustomField> SampleReceiveMaterialTableCustomField { get; set; }
    }
}
