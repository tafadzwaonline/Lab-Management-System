namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company_Profile
    {
        [Key]
        public int ProfileID { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(200)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string GM_Name { get; set; }

        [StringLength(50)]
        public string Telephone_No { get; set; }

        [StringLength(200)]
        public string Fax { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

      
        public string image_url { get; set; }

        public string website { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string POBox { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}
