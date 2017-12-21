namespace PapaBobs.Persistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PapaBobsEntities : DbContext
    {
        public PapaBobsEntities()
            : base("name=PapaBobsEntities")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PizzaPrice> PizzaPrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.TotalCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.SmallSizeCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.MediumSizeCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.LargeSizeCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.RegularCrustCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.ThinCrustCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.ThickCrustCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.SausageCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.PepperoniCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.OnionsCost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<PizzaPrice>()
                .Property(e => e.GreenPeppersCost)
                .HasPrecision(10, 4);
        }
    }
}
