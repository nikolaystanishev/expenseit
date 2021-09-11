﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using expensit.UI.DataAccess;

namespace expensit.DataAccess.Migrations
{
    [DbContext(typeof(ExpenseContext))]
    partial class ExpenseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ExpenseRecords");
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
#pragma warning restore 612, 618
        }
    }
}