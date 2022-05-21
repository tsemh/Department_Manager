﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWebAPI.Data;

namespace TestWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("TestWebAPI.models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Marketing",
                            Sigla = "M"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Financeiro",
                            Sigla = "F"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Logistica",
                            Sigla = "L"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Informática",
                            Sigla = "I"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Recursos Humanos",
                            Sigla = "RH"
                        });
                });

            modelBuilder.Entity("TestWebAPI.models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Foto")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rg")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Funcionarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Foto = "Foto",
                            IdDepartamento = 1,
                            Nome = "Erica",
                            Rg = "23.024.232-7"
                        },
                        new
                        {
                            Id = 2,
                            Foto = "Foto",
                            IdDepartamento = 2,
                            Nome = "Fernando",
                            Rg = "45.737.728-8"
                        },
                        new
                        {
                            Id = 3,
                            Foto = "Foto",
                            IdDepartamento = 3,
                            Nome = "Moises",
                            Rg = "48.843.809-3"
                        },
                        new
                        {
                            Id = 4,
                            Foto = "Foto",
                            IdDepartamento = 4,
                            Nome = "Alisson",
                            Rg = "39.428.265-6"
                        },
                        new
                        {
                            Id = 5,
                            Foto = "Foto",
                            IdDepartamento = 5,
                            Nome = "Maicon",
                            Rg = "39.428.265-6"
                        },
                        new
                        {
                            Id = 6,
                            Foto = "Foto",
                            IdDepartamento = 4,
                            Nome = "Isaya",
                            Rg = "45.431.451-6"
                        });
                });

            modelBuilder.Entity("TestWebAPI.models.Funcionario", b =>
                {
                    b.HasOne("TestWebAPI.models.Departamento", "Departamento")
                        .WithMany("Funcionarios")
                        .HasForeignKey("DepartamentoId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("TestWebAPI.models.Departamento", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
