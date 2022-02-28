namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestContractor
    {
        [Key]
        public int TestContractorsID { get; set; }

        public int FKTestID { get; set; }

        public int FKSubContractorID { get; set; }

        public virtual SubcontractorsList SubcontractorsList { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
