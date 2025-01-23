﻿// <auto-generated />
using Basket.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Basket.API.Migrations
{
    [DbContext(typeof(BasketDbContext))]
    [Migration("20250120074126_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Basket.API.Models.ShoppingCart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_shopping_carts");

                    b.ToTable("shopping_carts", (string)null);
                });

            modelBuilder.Entity("Basket.API.Models.ShoppingCart", b =>
                {
                    b.OwnsMany("Basket.API.Models.ShoppingCartItem", "Items", b1 =>
                        {
                            b1.Property<long>("ShoppingCartId")
                                .HasColumnType("bigint")
                                .HasColumnName("shopping_cart_id");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasColumnName("id");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("color");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("price");

                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint")
                                .HasColumnName("product_id");

                            b1.Property<string>("ProductName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("product_name");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int")
                                .HasColumnName("quantity");

                            b1.HasKey("ShoppingCartId", "Id")
                                .HasName("pk_shopping_cart_item");

                            b1.ToTable("shopping_cart_item", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ShoppingCartId")
                                .HasConstraintName("fk_shopping_cart_item_shopping_carts_shopping_cart_id");
                        });

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
