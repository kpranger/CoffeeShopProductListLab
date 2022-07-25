using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoffeeShopProductListLab.Models
{
    public partial class CoffeeShopProductListDBContext : DbContext
    {
        public CoffeeShopProductListDBContext()
        {
        }

        public CoffeeShopProductListDBContext(DbContextOptions<CoffeeShopProductListDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> ProductDetails{ get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=BirdDB; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(75)
                    .HasColumnName("Name");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("Description");

                entity.Property(e => e.Price).HasColumnName("Price");

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .HasColumnName("Category");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
