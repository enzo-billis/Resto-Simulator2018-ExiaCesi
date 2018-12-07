namespace RestaurantSimulator.Model.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ustensile")]
    public partial class Ustensile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ustensile()
        {
            Etape = new HashSet<Etape>();
        }

        [Key]
        public long id_Ustensile { get; set; }

        [StringLength(50)]
        public string nom_ust_Ustensile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etape> Etape { get; set; }
    }
}
