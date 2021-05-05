﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaPrestamos.Context;

namespace SistemaPrestamos.Migrations
{
    [DbContext(typeof(PrestamosContext))]
    [Migration("20210505031538_tableComisiones")]
    partial class tableComisiones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SistemaPrestamos.Models.Abono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Capital")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float>("Interes")
                        .HasColumnType("real");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Abonos");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoPin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Comisione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<float>("Porcentaje")
                        .HasColumnType("real");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Comisiones");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.FormaPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormaPagos");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoComision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoPrestamo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaPagoId")
                        .HasColumnType("int");

                    b.Property<float>("Interes")
                        .HasColumnType("real");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FormaPagoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Abono", b =>
                {
                    b.HasOne("SistemaPrestamos.Models.Prestamo", "Prestamo")
                        .WithMany("Abonos")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Comisione", b =>
                {
                    b.HasOne("SistemaPrestamos.Models.Cliente", "Cliente")
                        .WithMany("Comisiones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaPrestamos.Models.Prestamo", "Prestamo")
                        .WithMany("Comisiones")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Prestamo", b =>
                {
                    b.HasOne("SistemaPrestamos.Models.Cliente", "Cliente")
                        .WithMany("ListaPrestamos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaPrestamos.Models.FormaPago", "FormaPago")
                        .WithMany()
                        .HasForeignKey("FormaPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("FormaPago");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Cliente", b =>
                {
                    b.Navigation("Comisiones");

                    b.Navigation("ListaPrestamos");
                });

            modelBuilder.Entity("SistemaPrestamos.Models.Prestamo", b =>
                {
                    b.Navigation("Abonos");

                    b.Navigation("Comisiones");
                });
#pragma warning restore 612, 618
        }
    }
}
