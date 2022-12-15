﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockVision.Data.Data;

#nullable disable

namespace StockVision.Data.Migrations
{
    [DbContext(typeof(StockVisionContext))]
    [Migration("20221215191840_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockVision.Core.Models.AskOrderBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("AskOrderBooks");
                });

            modelBuilder.Entity("StockVision.Core.Models.BidOrderBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("BidOrderBooks");
                });

            modelBuilder.Entity("StockVision.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrderBookId")
                        .HasColumnType("int");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("OrderBookId")
                        .IsUnique();

                    b.HasIndex("SectorId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockVision.Core.Models.IndexAssignment", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("StockIndexId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId", "StockIndexId");

                    b.HasIndex("StockIndexId");

                    b.ToTable("IndexAssignment");
                });

            modelBuilder.Entity("StockVision.Core.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AskOrderBookId")
                        .HasColumnType("int");

                    b.Property<int?>("BidOrderBookId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrdersValue")
                        .HasPrecision(13, 4)
                        .HasColumnType("decimal(13,4)");

                    b.Property<decimal>("Price")
                        .HasPrecision(9, 4)
                        .HasColumnType("decimal(9,4)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SharePercentage")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AskOrderBookId");

                    b.HasIndex("BidOrderBookId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StockVision.Core.Models.OrderBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AskOrderBookId")
                        .HasColumnType("int");

                    b.Property<int>("BidOrderBookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AskOrderBookId")
                        .IsUnique();

                    b.HasIndex("BidOrderBookId")
                        .IsUnique();

                    b.ToTable("OrderBooks");
                });

            modelBuilder.Entity("StockVision.Core.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("StockVision.Core.Models.StockIndex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StockIndexes");
                });

            modelBuilder.Entity("StockVision.Core.Models.Company", b =>
                {
                    b.HasOne("StockVision.Core.Models.OrderBook", "OrderBook")
                        .WithOne()
                        .HasForeignKey("StockVision.Core.Models.Company", "OrderBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockVision.Core.Models.Sector", "Sector")
                        .WithMany("Companies")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderBook");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("StockVision.Core.Models.IndexAssignment", b =>
                {
                    b.HasOne("StockVision.Core.Models.Company", "Company")
                        .WithMany("IndexAssignment")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockVision.Core.Models.StockIndex", "StockIndex")
                        .WithMany("IndexAssignment")
                        .HasForeignKey("StockIndexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("StockIndex");
                });

            modelBuilder.Entity("StockVision.Core.Models.Order", b =>
                {
                    b.HasOne("StockVision.Core.Models.AskOrderBook", null)
                        .WithMany("Orders")
                        .HasForeignKey("AskOrderBookId");

                    b.HasOne("StockVision.Core.Models.BidOrderBook", null)
                        .WithMany("Orders")
                        .HasForeignKey("BidOrderBookId");
                });

            modelBuilder.Entity("StockVision.Core.Models.OrderBook", b =>
                {
                    b.HasOne("StockVision.Core.Models.AskOrderBook", "AskOrderBook")
                        .WithOne()
                        .HasForeignKey("StockVision.Core.Models.OrderBook", "AskOrderBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockVision.Core.Models.BidOrderBook", "BidOrderBook")
                        .WithOne()
                        .HasForeignKey("StockVision.Core.Models.OrderBook", "BidOrderBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AskOrderBook");

                    b.Navigation("BidOrderBook");
                });

            modelBuilder.Entity("StockVision.Core.Models.AskOrderBook", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StockVision.Core.Models.BidOrderBook", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StockVision.Core.Models.Company", b =>
                {
                    b.Navigation("IndexAssignment");
                });

            modelBuilder.Entity("StockVision.Core.Models.Sector", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("StockVision.Core.Models.StockIndex", b =>
                {
                    b.Navigation("IndexAssignment");
                });
#pragma warning restore 612, 618
        }
    }
}