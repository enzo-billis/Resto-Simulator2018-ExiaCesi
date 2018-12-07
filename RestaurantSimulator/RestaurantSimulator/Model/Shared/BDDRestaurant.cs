namespace RestaurantSimulator.Model.Shared
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BDDRestaurant : DbContext
    {
        public BDDRestaurant()
            : base("name=BDDRestaurant")
        {
        }

        public virtual DbSet<composé> composé { get; set; }
        public virtual DbSet<Etape> Etape { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Recette> Recette { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Ustensile> Ustensile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etape>()
                .Property(e => e.nom_etape)
                .IsUnicode(false);

            modelBuilder.Entity<Etape>()
                .HasMany(e => e.composé)
                .WithRequired(e => e.Etape)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.nom_Ingredient)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.composé)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recette>()
                .Property(e => e.liste_etapes_recette)
                .IsUnicode(false);

            modelBuilder.Entity<Recette>()
                .Property(e => e.nom_recette)
                .IsUnicode(false);

            modelBuilder.Entity<Recette>()
                .Property(e => e.categorie)
                .IsUnicode(false);

            modelBuilder.Entity<Ustensile>()
                .Property(e => e.nom_ust_Ustensile)
                .IsUnicode(false);
        }
    }
}
