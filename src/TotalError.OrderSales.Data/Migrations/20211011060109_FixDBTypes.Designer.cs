﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotalError.OrderSales.Data;

namespace TotalError.OrderSales.Data.Migrations
{
    [DbContext(typeof(TotalErrorDbContext))]
    [Migration("20211011060109_FixDBTypes")]
    partial class FixDBTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("smallmoney");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderPriority")
                        .HasColumnType("int");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SalesChannel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SaleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.RegionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.SaleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalProfit")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalRevenue")
                        .HasColumnType("money");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.Property<int>("UnitsSold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.CountryEntity", b =>
                {
                    b.HasOne("TotalError.OrderSales.Data.Entities.RegionEntity", "Region")
                        .WithMany("Countries")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.OrderEntity", b =>
                {
                    b.HasOne("TotalError.OrderSales.Data.Entities.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalError.OrderSales.Data.Entities.RegionEntity", "Region")
                        .WithMany("Orders")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TotalError.OrderSales.Data.Entities.SaleEntity", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Region");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.SaleEntity", b =>
                {
                    b.HasOne("TotalError.OrderSales.Data.Entities.ItemEntity", "Item")
                        .WithMany("Sales")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.ItemEntity", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("TotalError.OrderSales.Data.Entities.RegionEntity", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
