namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialsType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialsType()
        {
            EnquiryDetails = new HashSet<EnquiryDetail>();
            JobOrderDetails = new HashSet<JobOrderDetail>();
            MaterialsDetails = new HashSet<MaterialsDetail>();
            MaterialTypesCustomFields = new HashSet<MaterialTypesCustomField>();
            QuotationDetails = new HashSet<QuotationDetail>();
            SampleReceiveLists = new HashSet<SampleReceiveList>();
        }

        [Key]
        public int MaterialTypeID { get; set; }

        [Required]
        [StringLength(200)]
        public string MaterialName { get; set; }

        public int FKLabID { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryDetail> EnquiryDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderDetail> JobOrderDetails { get; set; }

        public virtual LabsList LabsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsDetail> MaterialsDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialTypesCustomField> MaterialTypesCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveList> SampleReceiveLists { get; set; }
    }
}
