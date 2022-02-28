namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EnquiryDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnquiryDetail()
        {
            QuotationDetails = new HashSet<QuotationDetail>();
        }

        [Key]
        public long EnquiryDetailsID { get; set; }

        public long FKEnquiryMasterID { get; set; }

        public int? FKMaterialTypeID { get; set; }

        public int? FKMaterialDetailsID { get; set; }

        public int FKTestID { get; set; }

        public int FKPriceUnitID { get; set; }

        public string Remarks { get; set; }

        public virtual EnquiryMaster EnquiryMaster { get; set; }

        public virtual MaterialsDetail MaterialsDetail { get; set; }

        public virtual MaterialsType MaterialsType { get; set; }

        public virtual PriceUnitList PriceUnitList { get; set; }

        public virtual TestsList TestsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
    }
}
