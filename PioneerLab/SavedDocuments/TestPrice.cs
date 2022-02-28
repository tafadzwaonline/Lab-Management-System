namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestPrice
    {
        public int TestPriceID { get; set; }

        public int FKTestID { get; set; }

        public int FKPriceUnitID { get; set; }

        public decimal? DefaultPrice { get; set; }

        public decimal? MinimumPrice { get; set; }

        public virtual PriceUnitList PriceUnitList { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
