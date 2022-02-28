namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExcelMappingFieldList")]
    public partial class ExcelMappingFieldList
    {
        [Key]
        public int ExcelMappingFieldId { get; set; }

        [Required]
        [StringLength(250)]
        public string FieldName { get; set; }
    }
}
