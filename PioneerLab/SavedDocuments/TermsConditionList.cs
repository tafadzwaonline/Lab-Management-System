namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TermsConditionList")]
    public partial class TermsConditionList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TermsConditionList()
        {
            QuotationMasters = new HashSet<QuotationMaster>();
        }

        [Key]
        public int TermConditionID { get; set; }

        [StringLength(100)]
        public string TermName { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationMaster> QuotationMasters { get; set; }
    }
}
