﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiTest.EF;

#nullable disable

namespace WebApiTest.Migrations
{
    [DbContext(typeof(MyDbContext))]
<<<<<<< HEAD:WebApiTest/Migrations/20230405025325_Init.Designer.cs
    [Migration("20230405025325_Init")]
=======
    [Migration("20230405122806_Init")]
>>>>>>> e80bea91ff12b89a6e91339454323c5d64f9b311:WebApiTest/Migrations/20230405122806_Init.Designer.cs
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiTest.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApiTest.Entities.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductDetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("ShellPrice")
                        .HasColumnType("real");

                    b.HasKey("ProductDetailId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("WebApiTest.Entities.ProductDetailPropertyDetail", b =>
                {
                    b.Property<int>("ProductDetailPropertyDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyDetailId")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailPropertyDetailId");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyDetailId");

                    b.ToTable("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("WebApiTest.Entities.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertySort")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("WebApiTest.Entities.PropertyDetail", b =>
                {
                    b.Property<int>("PropertyDetailId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDetailCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDetailDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("PropertyDetailId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("WebApiTest.Entities.ProductDetail", b =>
                {
                    b.HasOne("WebApiTest.Entities.ProductDetail", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("WebApiTest.Entities.ProductDetailPropertyDetail", b =>
                {
                    b.HasOne("WebApiTest.Entities.ProductDetail", null)
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiTest.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("WebApiTest.Entities.PropertyDetail", "PropertyDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("PropertyDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("PropertyDetail");
                });

            modelBuilder.Entity("WebApiTest.Entities.Property", b =>
                {
                    b.HasOne("WebApiTest.Entities.Product", "Products")
                        .WithMany("Properties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebApiTest.Entities.PropertyDetail", b =>
                {
                    b.HasOne("WebApiTest.Entities.Property", "Property")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("WebApiTest.Entities.Product", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("WebApiTest.Entities.ProductDetail", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("WebApiTest.Entities.Property", b =>
                {
                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("WebApiTest.Entities.PropertyDetail", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
