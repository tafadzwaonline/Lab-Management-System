namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestItem
    {
        [Key]
        public int TestItemsID { get; set; }

        public int FKTestID { get; set; }

        public int FKItemID { get; set; }

        public decimal? Qty { get; set; }

        [StringLength(50)]
        public string UnitOfMeasure { get; set; }

        public virtual ItemsList ItemsList { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
