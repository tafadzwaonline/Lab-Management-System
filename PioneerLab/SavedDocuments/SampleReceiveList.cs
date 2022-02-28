namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleReceiveList")]
    public partial class SampleReceiveList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SampleReceiveList()
        {
            SampleReceiveMaterialCustomFields = new HashSet<SampleReceiveMaterialCustomField>();
            SampleReceiveMaterialTableCustomFields = new HashSet<SampleReceiveMaterialTableCustomField>();
            SampleReceiveTestLists = new HashSet<SampleReceiveTestList>();
        }

        [Key]
        public long SampleID { get; set; }

        [StringLength(50)]
        public string SampleNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceiveDate { get; set; }

        public long? FKJobOrderMasterID { get; set; }

        public int? FKCustomerID { get; set; }

        public long? FKRSSMasterId { get; set; }

        public int? FKProjectID { get; set; }

        [StringLength(200)]
        public string ConsultantName { get; set; }

        [StringLength(50)]
        public string ConsultantMobile { get; set; }

        [StringLength(200)]
        public string SiteContactPerson { get; set; }

        [StringLength(50)]
        public string SiteContactMobile { get; set; }

        [StringLength(200)]
        public string DelivererName { get; set; }

        [StringLength(50)]
        public string DelivererMobile { get; set; }

        [StringLength(200)]
        public string Supplier { get; set; }

        [StringLength(200)]
        public string Source { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SamplingDate { get; set; }

        public string SampleDescription { get; set; }

        public string SampleLocation { get; set; }

        [StringLength(100)]
        public string SampledByID { get; set; }

        [StringLength(200)]
        public string SampledByName { get; set; }

        [StringLength(50)]
        public string SiteRefNo { get; set; }

        [StringLength(100)]
        public string SampleBroughtInByID { get; set; }

        [StringLength(200)]
        public string SampleBroughtInByName { get; set; }

        [StringLength(200)]
        public string LayerNo { get; set; }

        public int? FKMaterialTypeID { get; set; }

        public int? FKMaterialDetailsID { get; set; }

        [StringLength(200)]
        public string MaterialClass { get; set; }

        public decimal? ReceivedQty { get; set; }

        public int? FKPriceUnitID { get; set; }

        public int? RetentionPeriod { get; set; }

        [StringLength(100)]
        public string SampleCondition { get; set; }

        public string ConditionDetails { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SampleBroughtInDate { get; set; }

        public decimal? SampleTemperature { get; set; }

        [StringLength(200)]
        public string ReceiveByName { get; set; }

        public virtual CustomersList CustomersList { get; set; }

        public virtual JobOrderMaster JobOrderMaster { get; set; }

        public virtual MaterialsDetail MaterialsDetail { get; set; }

        public virtual MaterialsType MaterialsType { get; set; }

        public virtual PriceUnitList PriceUnitList { get; set; }

        public virtual ProjectsList ProjectsList { get; set; }

        public virtual RSSMaster RSSMaster { get; set; }

        public virtual SampleReceiveList SampleReceiveList1 { get; set; }

        public virtual SampleReceiveList SampleReceiveList2 { get; set; }

        public virtual SampleReceiveList SampleReceiveList11 { get; set; }

        public virtual SampleReceiveList SampleReceiveList3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveMaterialCustomField> SampleReceiveMaterialCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveMaterialTableCustomField> SampleReceiveMaterialTableCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestList> SampleReceiveTestLists { get; set; }
    }
}
