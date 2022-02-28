namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JobOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobOrderDetail()
        {
            WorkOrderLists = new HashSet<WorkOrderList>();
        }

        [Key]
        public long JobOrderDetailsID { get; set; }

        public long FKJobOrderMasterID { get; set; }

        public int FKTestID { get; set; }

        public int FKPriceUnitID { get; set; }

        public long? FKQuotationDetailsID { get; set; }

        public decimal? Price { get; set; }

        public decimal? MinQty { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        public string Remarks { get; set; }

        public bool Inactive { get; set; }

        public int? FKMaterialTypeID { get; set; }

        public int? FKMaterialDetailsID { get; set; }

        public bool IsEnable { get; set; }

        public virtual JobOrderMaster JobOrderMaster { get; set; }

        public virtual MaterialsDetail MaterialsDetail { get; set; }

        public virtual MaterialsType MaterialsType { get; set; }

        public virtual PriceUnitList PriceUnitList { get; set; }

        public virtual QuotationDetail QuotationDetail { get; set; }

        public virtual TestsList TestsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderList> WorkOrderLists { get; set; }
    }
}
