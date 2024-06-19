﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papeleria.AccesoDatos.EF;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    [DbContext(typeof(PapeleriaContext))]
    partial class PapeleriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Empresa.LogicaDeNegocio.Entidades.Articulo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("PrecioVP")
                        .HasColumnType("float");

                    b.ComplexProperty<Dictionary<string, object>>("CodigoProveedor", "Empresa.LogicaDeNegocio.Entidades.Articulo.CodigoProveedor#CodigoProveedorArticulos", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<long>("codigo")
                                .HasColumnType("bigint");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Descripcion", "Empresa.LogicaDeNegocio.Entidades.Articulo.Descripcion#DescripcionArticulo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Descripcion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("NombreArticulo", "Empresa.LogicaDeNegocio.Entidades.Articulo.NombreArticulo#NombreArticulo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("ID");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Empresa.LogicaDeNegocio.Sistema.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.ComplexProperty<Dictionary<string, object>>("Contrasenia", "Empresa.LogicaDeNegocio.Sistema.Usuario.Contrasenia#ContraseniaUsuario", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Email", "Empresa.LogicaDeNegocio.Sistema.Usuario.Email#EmailUsuario", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Direccion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("NombreCompleto", "Empresa.LogicaDeNegocio.Sistema.Usuario.NombreCompleto#NombreCompleto", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Apellido")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("ID");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.MovimientoStock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ArticuloID")
                        .HasColumnType("int");

                    b.Property<int>("CtdUnidadesXMovimiento")
                        .HasColumnType("int");

                    b.Property<DateTime>("FecHorMovRealizado")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovimientoID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioRealizaMovimientoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArticuloID");

                    b.HasIndex("MovimientoID");

                    b.HasIndex("UsuarioRealizaMovimientoID");

                    b.ToTable("MovimientoStocks");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.TipoMovimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TiposMovimientos");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.EncargadoDeposito", b =>
                {
                    b.HasBaseType("Empresa.LogicaDeNegocio.Sistema.Usuario");

                    b.HasDiscriminator().HasValue("EncargadoDeposito");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.MovimientoStock", b =>
                {
                    b.HasOne("Empresa.LogicaDeNegocio.Entidades.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papeleria.LogicaNegocio.Entidades.TipoMovimiento", "Movimiento")
                        .WithMany()
                        .HasForeignKey("MovimientoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Papeleria.LogicaNegocio.Entidades.EncargadoDeposito", "UsuarioRealizaMovimiento")
                        .WithMany()
                        .HasForeignKey("UsuarioRealizaMovimientoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Movimiento");

                    b.Navigation("UsuarioRealizaMovimiento");
                });
#pragma warning restore 612, 618
        }
    }
}