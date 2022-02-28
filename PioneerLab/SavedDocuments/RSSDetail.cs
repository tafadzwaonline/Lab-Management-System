namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RSSDetail
    {
        [Key]
        public long RSSDteailsId { get; set; }

        public long FkRSSMasterId { get; set; }

        public int? FkTestId { get; set; }

        public virtual RSSMaster RSSMaster { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
