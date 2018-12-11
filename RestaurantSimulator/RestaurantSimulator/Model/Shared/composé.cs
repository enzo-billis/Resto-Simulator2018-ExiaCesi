namespace RestaurantSimulator.Model.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class composé
    {
        [Key]
        public long id_compose { get; set; }

        public long id_etape { get; set; }

        public long id_Ingredient { get; set; }

        public virtual Etape Etape { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
