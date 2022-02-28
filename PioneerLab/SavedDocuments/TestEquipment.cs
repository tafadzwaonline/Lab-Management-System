namespace PioneerLab.SavedDocuments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestEquipment
    {
        public int TestEquipmentID { get; set; }

        public int FKEquipmentID { get; set; }

        public int FKTestID { get; set; }

        public virtual EquipmentsList EquipmentsList { get; set; }

        public virtual TestsList TestsList { get; set; }
    }
}
