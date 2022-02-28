namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ValidityListDetail
    {
        [Key]
        public int ValidityDetailsID { get; set; }

        public int FKValidityID { get; set; }

        [Required]
        [StringLength(200)]
        public string CertificateName { get; set; }

        [StringLength(50)]
        public string IDNumber { get; set; }

        [StringLength(50)]
        public string EnteredBy { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [StringLength(100)]
        public string Responsible { get; set; }

        public string Remarks { get; set; }

        [StringLength(200)]
        public string CertificateSerialNumber { get; set; }

        [StringLength(500)]
        public string CalibratedBy { get; set; }

        public virtual ValidityList ValidityList { get; set; }
    }
}
