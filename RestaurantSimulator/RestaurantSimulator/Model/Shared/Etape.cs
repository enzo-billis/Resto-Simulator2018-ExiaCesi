namespace RestaurantSimulator.Model.Shared
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Etape")]
    public partial class Etape
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Etape()
        {
            composé = new HashSet<composé>();
        }

        [Key]
        public long id_etape { get; set; }

        [StringLength(50)]
        public string nom_etape { get; set; }

        public long? temps_etape { get; set; }

        public int? sync_etape { get; set; }

        public long? id_Ustensile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<composé> composé { get; set; }

        public virtual Ustensile Ustensile { get; set; }
    }
}
