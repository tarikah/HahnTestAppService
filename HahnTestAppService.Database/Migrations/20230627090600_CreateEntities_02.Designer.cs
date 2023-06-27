﻿// <auto-generated />
using System;
using HahnTestAppService.Repository.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HahnTestAppService.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230627090600_CreateEntities_02")]
    partial class CreateEntities_02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.CarPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Composition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MadeOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ValidTill")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId")
                        .IsUnique();

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.Brand", b =>
                {
                    b.HasOne("HahnTestAppService.Domain.Entities.CarPart", "Part")
                        .WithMany("Brands")
                        .HasForeignKey("PartId");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.CarPart", b =>
                {
                    b.HasOne("HahnTestAppService.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithOne("Part")
                        .HasForeignKey("HahnTestAppService.Domain.Entities.CarPart", "ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.CarPart", b =>
                {
                    b.Navigation("Brands");
                });

            modelBuilder.Entity("HahnTestAppService.Domain.Entities.Manufacturer", b =>
                {
                    b.Navigation("Part")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
