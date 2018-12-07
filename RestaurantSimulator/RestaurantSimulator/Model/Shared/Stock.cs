namespace RestaurantSimulator.Model.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public long id_stock { get; set; }

        public TimeSpan? date_expire_Ingredient { get; set; }

        public long? quantité_Stock { get; set; }

        public long? id_Ingredient { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
