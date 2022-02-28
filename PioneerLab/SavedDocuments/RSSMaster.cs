namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RSSMaster")]
    public partial class RSSMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RSSMaster()
        {
            RSSDetails = new HashSet<RSSDetail>();
            SampleReceiveLists = new HashSet<SampleReceiveList>();
        }

        public long RSSMasterId { get; set; }

        public long FKJobOrderMasterID { get; set; }

        [Required]
        [StringLength(200)]
        public string RSSNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime RSSDate { get; set; }

        public string ContactPersonAtSite { get; set; }

        public string ContactMobile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestDate { get; set; }

        public string RequestBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestTestDate { get; set; }

        public DateTime? TestTime { get; set; }

        public string SiteLocation { get; set; }

        public int? FkEmpId { get; set; }

        public string Note { get; set; }

        public string ReportedBy { get; set; }

        public bool? IsSampled { get; set; }

        public virtual EmployeesList EmployeesList { get; set; }

        public virtual JobOrderMaster JobOrderMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSSDetail> RSSDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveList> SampleReceiveLists { get; set; }
    }
}
