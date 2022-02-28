namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleReceiveMaterialCustomField")]
    public partial class SampleReceiveMaterialCustomField
    {
        [Key]
        public long SampleReceiveCFLinkID { get; set; }

        public long FkSampleID { get; set; }

        public int FkCustomFieldID { get; set; }

        [StringLength(200)]
        public string Value { get; set; }

        public virtual MaterialTypesCustomField MaterialTypesCustomField { get; set; }

        public virtual SampleReceiveList SampleReceiveList { get; set; }
    }
}
