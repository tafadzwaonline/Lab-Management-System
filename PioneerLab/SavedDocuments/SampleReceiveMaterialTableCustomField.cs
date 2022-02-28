namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleReceiveMaterialTableCustomField")]
    public partial class SampleReceiveMaterialTableCustomField
    {
        [Key]
        public int SampleReceiveTCFLinkID { get; set; }

        public long? FkSampleID { get; set; }

        public int? FkCustomFieldID { get; set; }

        [StringLength(200)]
        public string Value { get; set; }

        public int? RowIndex { get; set; }

        public virtual MaterialTypesCustomField MaterialTypesCustomField { get; set; }

        public virtual SampleReceiveList SampleReceiveList { get; set; }
    }
}
