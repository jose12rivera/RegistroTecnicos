﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicoss.DAL;

#nullable disable

namespace RegistroTecnicoss.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240525154359_IncentivosTecnicos")]
    partial class IncentivosTecnicos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("RegistroTecnicoss.Modelss.IncentivosTecnicos", b =>
                {
                    b.Property<int>("IncentivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadServicios")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IncentivoId");

                    b.ToTable("IncentivosTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicoss.Modelss.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Sueldohora")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicoss.Modelss.TiposTecnicos", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Incentivo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IncentivoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoId");

                    b.ToTable("TipoTecnico");
                });

            modelBuilder.Entity("RegistroTecnicoss.Modelss.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicoss.Modelss.TiposTecnicos", "TiposTecnicos")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposTecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}
