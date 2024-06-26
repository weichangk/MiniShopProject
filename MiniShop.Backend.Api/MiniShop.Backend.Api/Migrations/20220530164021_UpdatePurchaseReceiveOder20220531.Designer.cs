﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniShop.Backend.Model.Code;

namespace MiniShop.Backend.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220530164021_UpdatePurchaseReceiveOder20220531")]
    partial class UpdatePurchaseReceiveOder20220531
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MiniShop.Backend.Model.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ParentCode")
                        .HasColumnType("int");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId", "Code")
                        .IsUnique();

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("PriceType")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("UnitId");

                    b.HasIndex("ShopId", "Code")
                        .IsUnique();

                    b.ToTable("Item");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseOder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuditOperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("AuditState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("OderAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OderNo")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("ShopId", "OderNo")
                        .IsUnique();

                    b.ToTable("PurchaseOder");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseOderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("GiveNumber")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PurchaseOderId")
                        .HasColumnType("int");

                    b.Property<decimal>("RealPurchasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseOderId");

                    b.ToTable("PurchaseOderItem");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReceiveOder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuditOperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("AuditState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("OderAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OderNo")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<string>("PurchaseOderNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("ShopId", "OderNo")
                        .IsUnique();

                    b.ToTable("PurchaseReceiveOder");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReceiveOderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("GiveNumber")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PurchaseReceiveOderId")
                        .HasColumnType("int");

                    b.Property<decimal>("RealPurchasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseReceiveOderId");

                    b.ToTable("PurchaseReceiveOderItem");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReturnOder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuditOperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("AuditState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("OderAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OderNo")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("ShopId", "OderNo")
                        .IsUnique();

                    b.ToTable("PurchaseReturnOder");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReturnOderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("GiveNumber")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("PurchaseReturnOderId")
                        .HasColumnType("int");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseReturnOderId");

                    b.ToTable("PurchaseReturnOderItem");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contacts")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ValidDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId")
                        .IsUnique();

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contacts")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId", "Name")
                        .IsUnique();

                    b.HasIndex("ShopId", "StoreId")
                        .IsUnique();

                    b.ToTable("Store");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Contacts")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId", "Code")
                        .IsUnique();

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId", "Code")
                        .IsUnique();

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Vip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OperatorName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("char(36)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("VipType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId", "Code")
                        .IsUnique();

                    b.ToTable("Vip");
                });

            modelBuilder.Entity("MiniShop.Backend.Model.Item", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniShop.Backend.Model.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseOder", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseOderItem", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniShop.Backend.Model.PurchaseOder", "PurchaseOder")
                        .WithMany()
                        .HasForeignKey("PurchaseOderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReceiveOder", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReceiveOderItem", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniShop.Backend.Model.PurchaseReceiveOder", "PurchaseReceiveOder")
                        .WithMany()
                        .HasForeignKey("PurchaseReceiveOderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReturnOder", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniShop.Backend.Model.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniShop.Backend.Model.PurchaseReturnOderItem", b =>
                {
                    b.HasOne("MiniShop.Backend.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniShop.Backend.Model.PurchaseReturnOder", "PurchaseReturnOder")
                        .WithMany("PurchaseReturnOderItem")
                        .HasForeignKey("PurchaseReturnOderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
