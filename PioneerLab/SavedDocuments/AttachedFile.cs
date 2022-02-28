namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttachedFile
    {
        [Key]
        public long FileID { get; set; }

        [Required]
        [StringLength(500)]
        public string FileName { get; set; }

        public byte[] FileContent { get; set; }

        [Required]
        [StringLength(50)]
        public string FileExtention { get; set; }

        [StringLength(200)]
        public string FileUrl { get; set; }

        [StringLength(50)]
        public string FileSize { get; set; }

        public bool IsUrl { get; set; }

        public int FKTransTypeID { get; set; }

        public long FKTransID { get; set; }

        public string Keywords { get; set; }

        public virtual AttachFileTransType AttachFileTransType { get; set; }
    }
}
