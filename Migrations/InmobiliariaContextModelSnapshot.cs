﻿// <auto-generated />
using Inmobiliaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inmobiliaria.Migrations
{
    [DbContext(typeof(InmobiliariaContext))]
    partial class InmobiliariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Inmobiliaria.Models.Oferta", b =>
                {
                    b.Property<int>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OperacionId")
                        .HasColumnType("int");

                    b.Property<float>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("ViviendaId")
                        .HasColumnType("int");

                    b.HasKey("OfertaId");

                    b.HasIndex("OperacionId");

                    b.HasIndex("ViviendaId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("Inmobiliaria.Models.Operacion", b =>
                {
                    b.Property<int>("OperacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<float>("Tolerancia")
                        .HasColumnType("float");

                    b.HasKey("OperacionId");

                    b.ToTable("Operacion");
                });

            modelBuilder.Entity("Inmobiliaria.Models.Propietario", b =>
                {
                    b.Property<int>("PropietarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("text");

                    b.Property<long>("DNI")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("PropietarioId");

                    b.ToTable("Propietario");
                });

            modelBuilder.Entity("Inmobiliaria.Models.TipoVivienda", b =>
                {
                    b.Property<int>("TipoViviendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("TipoViviendaId");

                    b.ToTable("TipoVivienda");
                });

            modelBuilder.Entity("Inmobiliaria.Models.Vivienda", b =>
                {
                    b.Property<int>("ViviendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescripcionCorta")
                        .HasColumnType("text");

                    b.Property<string>("DescripcionLarga")
                        .HasColumnType("text");

                    b.Property<string>("DomicilioCalle")
                        .HasColumnType("text");

                    b.Property<string>("DomicilioNumero")
                        .HasColumnType("text");

                    b.Property<bool>("GasNatural")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("Latitud")
                        .HasColumnType("float");

                    b.Property<float>("Longitud")
                        .HasColumnType("float");

                    b.Property<int>("TipoViviendaId")
                        .HasColumnType("int");

                    b.HasKey("ViviendaId");

                    b.HasIndex("TipoViviendaId");

                    b.ToTable("Vivienda");
                });

            modelBuilder.Entity("PropietarioVivienda", b =>
                {
                    b.Property<int>("PropietariosPropietarioId")
                        .HasColumnType("int");

                    b.Property<int>("ViviendasViviendaId")
                        .HasColumnType("int");

                    b.HasKey("PropietariosPropietarioId", "ViviendasViviendaId");

                    b.HasIndex("ViviendasViviendaId");

                    b.ToTable("PropietarioVivienda");
                });

            modelBuilder.Entity("Inmobiliaria.Models.Oferta", b =>
                {
                    b.HasOne("Inmobiliaria.Models.Operacion", "Operacion")
                        .WithMany("Ofertas")
                        .HasForeignKey("OperacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Models.Vivienda", "Vivienda")
                        .WithMany()
                        .HasForeignKey("ViviendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operacion");

                    b.Navigation("Vivienda");
                });

            modelBuilder.Entity("Inmobiliaria.Models.Vivienda", b =>
                {
                    b.HasOne("Inmobiliaria.Models.TipoVivienda", "TipoVivienda")
                        .WithMany("Viviendas")
                        .HasForeignKey("TipoViviendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVivienda");
                });

            modelBuilder.Entity("PropietarioVivienda", b =>
                {
                    b.HasOne("Inmobiliaria.Models.Propietario", null)
                        .WithMany()
                        .HasForeignKey("PropietariosPropietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Models.Vivienda", null)
                        .WithMany()
                        .HasForeignKey("ViviendasViviendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inmobiliaria.Models.Operacion", b =>
                {
                    b.Navigation("Ofertas");
                });

            modelBuilder.Entity("Inmobiliaria.Models.TipoVivienda", b =>
                {
                    b.Navigation("Viviendas");
                });
#pragma warning restore 612, 618
        }
    }
}
