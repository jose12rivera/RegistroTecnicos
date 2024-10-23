﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegistroTecnicos.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 100m,
                            Descripcion = "Mouse",
                            Existencia = 50,
                            Precio = 150m
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 80m,
                            Descripcion = "Teclado",
                            Existencia = 40,
                            Precio = 120m
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 200m,
                            Descripcion = "Monitor",
                            Existencia = 20,
                            Precio = 300m
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 250m,
                            Descripcion = "Impresora",
                            Existencia = 15,
                            Precio = 400m
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 50m,
                            Descripcion = "Webcam",
                            Existencia = 25,
                            Precio = 90m
                        },
                        new
                        {
                            ArticuloId = 6,
                            Costo = 15m,
                            Descripcion = "Pendrive",
                            Existencia = 70,
                            Precio = 30m
                        },
                        new
                        {
                            ArticuloId = 7,
                            Costo = 10m,
                            Descripcion = "Cable HDMI",
                            Existencia = 60,
                            Precio = 20m
                        },
                        new
                        {
                            ArticuloId = 8,
                            Costo = 100m,
                            Descripcion = "Disco Duro Externo",
                            Existencia = 30,
                            Precio = 180m
                        },
                        new
                        {
                            ArticuloId = 9,
                            Costo = 60m,
                            Descripcion = "Router",
                            Existencia = 25,
                            Precio = 110m
                        },
                        new
                        {
                            ArticuloId = 10,
                            Costo = 50m,
                            Descripcion = "Altavoces",
                            Existencia = 40,
                            Precio = 90m
                        },
                        new
                        {
                            ArticuloId = 11,
                            Costo = 300m,
                            Descripcion = "Tarjeta Gráfica",
                            Existencia = 10,
                            Precio = 500m
                        },
                        new
                        {
                            ArticuloId = 12,
                            Costo = 800m,
                            Descripcion = "Laptop",
                            Existencia = 8,
                            Precio = 1200m
                        },
                        new
                        {
                            ArticuloId = 13,
                            Costo = 300m,
                            Descripcion = "Smartphone",
                            Existencia = 15,
                            Precio = 500m
                        },
                        new
                        {
                            ArticuloId = 14,
                            Costo = 100m,
                            Descripcion = "Smartwatch",
                            Existencia = 20,
                            Precio = 150m
                        },
                        new
                        {
                            ArticuloId = 15,
                            Costo = 200m,
                            Descripcion = "Tableta",
                            Existencia = 18,
                            Precio = 300m
                        });
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Property<int>("CotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CotizacionId"));

                    b.Property<int?>("ArticulosArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Observacion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CotizacionId");

                    b.HasIndex("ArticulosArticuloId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CotizacionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("CotizacionId");

                    b.ToTable("CotizacionesDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrioridadId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tiempo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrioridadId");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TecnicoId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SueldoHora")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoTecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoTecnicoId")
                        .IsUnique();

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TipoTecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoTecnicoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoTecnicoId");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabajoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TrabajoId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("PrioridadId")
                        .IsUnique();

                    b.HasIndex("TecnicoId")
                        .IsUnique();

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrabajoId")
                        .HasColumnType("int");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("TrabajoId");

                    b.ToTable("TrabajosDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticulosArticuloId");

                    b.HasOne("RegistroTecnicos.Models.Clientes", "Clientes")
                        .WithOne("Cotizaciones")
                        .HasForeignKey("RegistroTecnicos.Models.Cotizaciones", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalle", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Cotizaciones", "Cotizaciones")
                        .WithMany("CotizacionesDetalle")
                        .HasForeignKey("CotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.TiposTecnicos", "TiposTecnicos")
                        .WithOne("Tecnicos")
                        .HasForeignKey("RegistroTecnicos.Models.Tecnicos", "TipoTecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "Clientes")
                        .WithOne("Trabajos")
                        .HasForeignKey("RegistroTecnicos.Models.Trabajos", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Prioridades", "Prioridades")
                        .WithOne("Trabajos")
                        .HasForeignKey("RegistroTecnicos.Models.Trabajos", "PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Tecnicos", "Tecnicos")
                        .WithOne("Trabajos")
                        .HasForeignKey("RegistroTecnicos.Models.Trabajos", "TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Prioridades");

                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalle", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Trabajos", "Trabajo")
                        .WithMany("TrabajosDetalle")
                        .HasForeignKey("TrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Trabajo");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Navigation("Cotizaciones");

                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Navigation("CotizacionesDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Navigation("TrabajosDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
