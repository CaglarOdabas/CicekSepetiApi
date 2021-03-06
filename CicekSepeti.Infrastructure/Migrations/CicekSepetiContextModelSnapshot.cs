// <auto-generated />
using CicekSepeti.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CicekSepeti.Infrastructure.Migrations
{
    [DbContext(typeof(CicekSepetiContext))]
    partial class CicekSepetiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("CicekSepeti.Core.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Piece")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValueSql("1");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("basket_id_uindex");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("0.00");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("product_id_uindex");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Piece")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("stock_id_uindex");

                    b.HasIndex("ProductId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("user_id_uindex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.Basket", b =>
                {
                    b.HasOne("CicekSepeti.Core.Entities.Product", "Product")
                        .WithMany("Basket")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("basket_product_id_fk")
                        .IsRequired();

                    b.HasOne("CicekSepeti.Core.Entities.User", "User")
                        .WithMany("Basket")
                        .HasForeignKey("UserId")
                        .HasConstraintName("basket_user_id_fk")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.Stock", b =>
                {
                    b.HasOne("CicekSepeti.Core.Entities.Product", "Product")
                        .WithMany("Stock")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("stock_product_id_fk")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.Product", b =>
                {
                    b.Navigation("Basket");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("CicekSepeti.Core.Entities.User", b =>
                {
                    b.Navigation("Basket");
                });
#pragma warning restore 612, 618
        }
    }
}
