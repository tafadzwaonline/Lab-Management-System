namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialsDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialsDetail()
        {
            EnquiryDetails = new HashSet<EnquiryDetail>();
            JobOrderDetails = new HashSet<JobOrderDetail>();
            MaterialsDetailsTests = new HashSet<MaterialsDetailsTest>();
            QuotationDetails = new HashSet<QuotationDetail>();
            SampleReceiveLists = new HashSet<SampleReceiveList>();
        }

        [Key]
        public int MaterialDetailsID { get; set; }

        public int FKMaterialTypeID { get; set; }

        [Required]
        [StringLength(500)]
        public string MaterialName { get; set; }

        public string MaterialDescription { get; set; }

        [StringLength(500)]
        public string MaterialUse { get; set; }

        [StringLength(500)]
        public string StandardSpecs { get; set; }

        [StringLength(50)]
        public string StandardNumber { get; set; }

        public bool IsLocked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryDetail> EnquiryDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderDetail> JobOrderDetails { get; set; }

        public virtual MaterialsType MaterialsType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsDetailsTest> MaterialsDetailsTests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveList> SampleReceiveLists { get; set; }
    }
}
