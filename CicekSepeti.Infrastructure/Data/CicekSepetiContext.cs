using CicekSepeti.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.Infrastructure.Data
{
    public class CicekSepetiContext : DbContext
    {
        public CicekSepetiContext(DbContextOptions<CicekSepetiContext> options) : base(options)
        {

        }

        public DbSet<CicekSepeti.Core.Entities.Basket> Baskets { get; set; }
        public DbSet<CicekSepeti.Core.Entities.Product> Products { get; set; }
        public DbSet<CicekSepeti.Core.Entities.Stock> Stocks { get; set; }
        public DbSet<CicekSepeti.Core.Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("basket_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Piece).HasDefaultValueSql("1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("basket_product_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("basket_user_id_fk");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("product_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Price).HasDefaultValueSql("0.00");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("stock_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stock_product_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("user_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
