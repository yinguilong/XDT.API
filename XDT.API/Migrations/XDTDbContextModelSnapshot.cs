﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using XDT.Repositories.EntityFramework;
using XDT.Model.Enums;

namespace XDT.API.Migrations
{
    [DbContext(typeof(XDTDbContext))]
    partial class XDTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("XDT.Domain.Model.Box", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Box");
                });

            modelBuilder.Entity("XDT.Domain.Model.BoxItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BoxID");

                    b.Property<DateTime>("CreateTime");

                    b.Property<long?>("WareItemID");

                    b.HasKey("ID");

                    b.HasIndex("BoxID");

                    b.HasIndex("WareItemID");

                    b.ToTable("BoxItem");
                });

            modelBuilder.Entity("XDT.Domain.Model.NoticeMessage", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<byte>("Status");

                    b.Property<long?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("NoticeMessage");
                });

            modelBuilder.Entity("XDT.Domain.Model.PriceItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("ActivityPrice");

                    b.Property<string>("Note");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<long?>("WareItemID");

                    b.HasKey("ID");

                    b.HasIndex("WareItemID");

                    b.ToTable("PriceItem");
                });

            modelBuilder.Entity("XDT.Domain.Model.UrlHistoryItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Url")
                        .HasMaxLength(500);

                    b.Property<long?>("WareItemID");

                    b.HasKey("ID");

                    b.HasIndex("WareItemID");

                    b.ToTable("UrlHistoryItems");
                });

            modelBuilder.Entity("XDT.Domain.Model.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Career")
                        .HasMaxLength(10);

                    b.Property<string>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("HeaderImg");

                    b.Property<bool>("IsDisabled");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<string>("LoginAccount")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("RegisteredDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("XDT.Domain.Model.UserAdvice", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<byte>("Level");

                    b.Property<byte>("Status");

                    b.Property<long?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserAdvice");
                });

            modelBuilder.Entity("XDT.Domain.Model.WareItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("FirstListenTime");

                    b.Property<string>("ItemImage")
                        .HasMaxLength(500);

                    b.Property<string>("ItemName")
                        .HasMaxLength(50);

                    b.Property<byte>("ItemSource");

                    b.Property<int>("ItemType");

                    b.Property<DateTime?>("LastListenTime");

                    b.Property<string>("ListenUrl")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<long?>("OperatorID");

                    b.Property<byte>("Status");

                    b.Property<byte>("Trend");

                    b.HasKey("ID");

                    b.HasIndex("OperatorID");

                    b.ToTable("WareItem");
                });

            modelBuilder.Entity("XDT.Domain.Model.WareItemDiscuss", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Additional")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Discuss")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ResId");

                    b.Property<long?>("UserID");

                    b.Property<long?>("WareItemID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.HasIndex("WareItemID");

                    b.ToTable("WareItemDiscuss");
                });

            modelBuilder.Entity("XDT.Domain.Model.Box", b =>
                {
                    b.HasOne("XDT.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("XDT.Domain.Model.BoxItem", b =>
                {
                    b.HasOne("XDT.Domain.Model.Box", "Box")
                        .WithMany()
                        .HasForeignKey("BoxID");

                    b.HasOne("XDT.Domain.Model.WareItem", "WareItem")
                        .WithMany()
                        .HasForeignKey("WareItemID");
                });

            modelBuilder.Entity("XDT.Domain.Model.NoticeMessage", b =>
                {
                    b.HasOne("XDT.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("XDT.Domain.Model.PriceItem", b =>
                {
                    b.HasOne("XDT.Domain.Model.WareItem", "WareItem")
                        .WithMany()
                        .HasForeignKey("WareItemID");
                });

            modelBuilder.Entity("XDT.Domain.Model.UrlHistoryItem", b =>
                {
                    b.HasOne("XDT.Domain.Model.WareItem", "WareItem")
                        .WithMany()
                        .HasForeignKey("WareItemID");
                });

            modelBuilder.Entity("XDT.Domain.Model.UserAdvice", b =>
                {
                    b.HasOne("XDT.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("XDT.Domain.Model.WareItem", b =>
                {
                    b.HasOne("XDT.Domain.Model.User", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorID");
                });

            modelBuilder.Entity("XDT.Domain.Model.WareItemDiscuss", b =>
                {
                    b.HasOne("XDT.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.HasOne("XDT.Domain.Model.WareItem", "WareItem")
                        .WithMany()
                        .HasForeignKey("WareItemID");
                });
        }
    }
}