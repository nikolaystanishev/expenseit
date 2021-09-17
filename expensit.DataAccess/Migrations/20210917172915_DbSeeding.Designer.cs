﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using expensit.DataAccess;

namespace expensit.DataAccess.Migrations
{
    [DbContext(typeof(ExpenseContext))]
    [Migration("20210917172915_DbSeeding")]
    partial class DbSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("expensit.Model.Model.ExpenseRecord", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19,2)");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("ExpenseRecords");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Amount = 1000m,
                            PayDate = new DateTime(2021, 9, 17, 20, 29, 14, 249, DateTimeKind.Local).AddTicks(5364),
                            ProfileId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "2",
                            Amount = 2000m,
                            PayDate = new DateTime(2021, 9, 18, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4901),
                            ProfileId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "3",
                            Amount = 3000m,
                            PayDate = new DateTime(2021, 12, 26, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4983),
                            ProfileId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "4",
                            Amount = 4000m,
                            PayDate = new DateTime(2021, 12, 26, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4995),
                            ProfileId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "5",
                            Amount = 5000m,
                            PayDate = new DateTime(2021, 12, 26, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4999),
                            ProfileId = "2",
                            Type = 0
                        });
                });

            modelBuilder.Entity("expensit.Model.Model.Group", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpenseRecordId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseRecordId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Color = "#123456",
                            ExpenseRecordId = "2",
                            Name = "group1"
                        },
                        new
                        {
                            Id = "2",
                            Color = "#123457",
                            ExpenseRecordId = "2",
                            Name = "group2"
                        },
                        new
                        {
                            Id = "3",
                            Color = "#123457",
                            ExpenseRecordId = "3",
                            Name = "group2"
                        },
                        new
                        {
                            Id = "4",
                            Color = "#123458",
                            ExpenseRecordId = "3",
                            Name = "group3"
                        },
                        new
                        {
                            Id = "5",
                            Color = "#123459",
                            ExpenseRecordId = "5",
                            Name = "group4"
                        },
                        new
                        {
                            Id = "6",
                            Color = "#123450",
                            ExpenseRecordId = "5",
                            Name = "group5"
                        });
                });

            modelBuilder.Entity("expensit.Model.Model.Profile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "profile1"
                        },
                        new
                        {
                            Id = "2",
                            Name = "profile2"
                        },
                        new
                        {
                            Id = "3",
                            Name = "profile3"
                        });
                });

            modelBuilder.Entity("expensit.Model.Model.ExpenseRecord", b =>
                {
                    b.HasOne("expensit.Model.Model.Profile", null)
                        .WithMany("ExpenseRecords")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("expensit.Model.Model.Group", b =>
                {
                    b.HasOne("expensit.Model.Model.ExpenseRecord", null)
                        .WithMany("Groups")
                        .HasForeignKey("ExpenseRecordId");
                });

            modelBuilder.Entity("expensit.Model.Model.ExpenseRecord", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("expensit.Model.Model.Profile", b =>
                {
                    b.Navigation("ExpenseRecords");
                });
#pragma warning restore 612, 618
        }
    }
}