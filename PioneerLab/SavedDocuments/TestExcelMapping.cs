namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestExcelMapping")]
    public partial class TestExcelMapping
    {
        [Key]
        public int TestColMapID { get; set; }

        public int FKTestID { get; set; }

        public bool IsForReport { get; set; }

        [Required]
        [StringLength(50)]
        public string FieldName { get; set; }

        [Required]
        [StringLength(10)]
        public string ExcelCell { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
