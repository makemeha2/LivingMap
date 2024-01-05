﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistences;

#nullable disable

namespace Persistences.Migrations
{
    [DbContext(typeof(LivingMapContext))]
    [Migration("20240105091545_InitialTable")]
    partial class InitialTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Persistences.Models.CommonCode", b =>
                {
                    b.Property<string>("CodeGroup")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("UseYn")
                        .HasColumnType("bit");

                    b.HasKey("CodeGroup", "Code");

                    b.ToTable("CommonCode");
                });

            modelBuilder.Entity("Persistences.Models.InterfaceTarget", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idx"));

                    b.Property<string>("Area1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CompletedIf")
                        .HasColumnType("bit");

                    b.Property<string>("Div")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Ifdate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("RegistDate")
                        .HasColumnType("date");

                    b.HasKey("Idx");

                    b.ToTable("InterfaceTarget");
                });

            modelBuilder.Entity("Persistences.Models.LocationInfo", b =>
                {
                    b.Property<string>("Div")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Area1")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Area2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Area3")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateOnly>("RegistDate")
                        .HasColumnType("date");

                    b.Property<bool>("UseYN")
                        .HasColumnType("bit");

                    b.HasKey("Div", "Address");

                    b.ToTable("LocationInfo");
                });
#pragma warning restore 612, 618
        }
    }
}