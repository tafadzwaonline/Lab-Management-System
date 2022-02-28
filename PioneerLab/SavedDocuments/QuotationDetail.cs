namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuotationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuotationDetail()
        {
            JobOrderDetails = new HashSet<JobOrderDetail>();
            QuotationWorkOrderLists = new HashSet<QuotationWorkOrderList>();
        }

        [Key]
        public long QuotationDetailsID { get; set; }

        public long FKQuotationMasterID { get; set; }

        public int FKTestID { get; set; }

        public int FKPriceUnitID { get; set; }

        public long? FKEnquiryDetailsID { get; set; }

        public decimal? Price { get; set; }

        public decimal? MinQty { get; set; }

        public string Remarks { get; set; }

        public int? FKMaterialTypeID { get; set; }

        public int? FKMaterialDetailsID { get; set; }

        public virtual EnquiryDetail EnquiryDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderDetail> JobOrderDetails { get; set; }

        public virtual MaterialsDetail MaterialsDetail { get; set; }

        public virtual MaterialsType MaterialsType { get; set; }

        public virtual PriceUnitList PriceUnitList { get; set; }

        public virtual QuotationMaster QuotationMaster { get; set; }

        public virtual TestsList TestsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationWorkOrderList> QuotationWorkOrderLists { get; set; }
    }
}
