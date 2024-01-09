﻿// <auto-generated />
using System;
using MiPrimeraApiRest.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MiPrimeraApiRest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240109175024_datosDeArranque")]
    partial class datosDeArranque
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiPrimeraApiRest.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidades = "Amenidades 1",
                            Detalle = "Villa 1",
                            FechaCreacion = new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1144),
                            FechaModificacion = new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1158),
                            ImagenUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.villas.com%2Fespana%",
                            MetrosCuadrados = 100,
                            Nombre = "Villa 1",
                            Ocupantes = 4,
                            Tarifa = 100.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidades = "Amenidades 2",
                            Detalle = "Villa 2",
                            FechaCreacion = new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1162),
                            FechaModificacion = new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1163),
                            ImagenUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.villas.com%2Fespana%",
                            MetrosCuadrados = 100,
                            Nombre = "Villa 2",
                            Ocupantes = 4,
                            Tarifa = 100.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
