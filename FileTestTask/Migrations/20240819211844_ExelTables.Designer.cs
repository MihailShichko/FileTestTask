﻿// <auto-generated />
using System;
using FileTestTask.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileTestTask.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240819211844_ExelTables")]
    partial class ExelTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FileTestTask.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<double>("ClosingBalanceActive")
                        .HasColumnType("float");

                    b.Property<double>("ClosingBalancePassive")
                        .HasColumnType("float");

                    b.Property<double>("CreditTurnover")
                        .HasColumnType("float");

                    b.Property<double>("DebitTurnover")
                        .HasColumnType("float");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("OpeningBalanceActive")
                        .HasColumnType("float");

                    b.Property<double>("OpeningBalancePassive")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FileTestTask.Models.AccountClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("ClassEndRow")
                        .HasColumnType("bigint");

                    b.Property<int>("ClassIndex")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ClassStartRow")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("AccountClasses");
                });

            modelBuilder.Entity("FileTestTask.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CyrillicString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("FractionalNum")
                        .HasColumnType("float");

                    b.Property<string>("LatinString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OddNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("FileTestTask.Models.Account", b =>
                {
                    b.HasOne("FileTestTask.Models.AccountClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });
#pragma warning restore 612, 618
        }
    }
}
