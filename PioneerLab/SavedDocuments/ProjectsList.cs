namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectsList")]
    public partial class ProjectsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectsList()
        {
            EnquiryMasters = new HashSet<EnquiryMaster>();
            JobOrderMasters = new HashSet<JobOrderMaster>();
            QuotationMasters = new HashSet<QuotationMaster>();
            SampleReceiveLists = new HashSet<SampleReceiveList>();
        }

        [Key]
        public int ProjectID { get; set; }

        [StringLength(200)]
        public string ProjectCode { get; set; }

        public string ProjectName { get; set; }

        [StringLength(150)]
        public string AshghalCode { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ProjectLocation { get; set; }

        public int FKProjectTypeID { get; set; }

        [StringLength(300)]
        public string ProjectConsultant { get; set; }

        public int? FKContractorID { get; set; }

        [StringLength(500)]
        public string ProjectOwner { get; set; }

        public bool IsClosed { get; set; }

        public virtual ContractorsList ContractorsList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryMaster> EnquiryMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderMaster> JobOrderMasters { get; set; }

        public virtual ProjectsType ProjectsType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationMaster> QuotationMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveList> SampleReceiveLists { get; set; }
    }
}
