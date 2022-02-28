namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialsDetailsTest
    {
        [Key]
        public int MaterialTestID { get; set; }

        public int FKMaterialDetailsID { get; set; }

        public int FKTestID { get; set; }

        public virtual MaterialsDetail MaterialsDetail { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
