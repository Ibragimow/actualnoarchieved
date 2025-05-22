using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp1
{
    public partial class ObrazPlusIbragimov : DbContext
    {
        public ObrazPlusIbragimov()
            : base("name=ObrazPlusIbragimov")
        {
        }

        public virtual DbSet<MaterialProduct> MaterialProducts { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialProducts)
                .WithOptional(e => e.Material)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MaterialType>()
                .HasMany(e => e.Materials)
                .WithOptional(e => e.MaterialType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.MaterialProducts)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();
        }
    }
}
