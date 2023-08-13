﻿// <auto-generated />
using System;
using CiaAerea.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CiaAerea.Migrations
{
    [DbContext(typeof(CiaAereaContexts))]
    [Migration("20230715221527_EstruturaInicial")]
    partial class EstruturaInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CiaAerea.Entities.Aeronave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Aenonaves", (string)null);
                });

            modelBuilder.Entity("CiaAerea.Entities.Cancelamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraNotificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VooId")
                        .IsUnique();

                    b.ToTable("Cancelamentos", (string)null);
                });

            modelBuilder.Entity("CiaAerea.Entities.Manutencao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AeronaveId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AeronaveId");

                    b.ToTable("Manutencoes", (string)null);
                });

            modelBuilder.Entity("CiaAerea.Entities.Piloto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Matricula")
                        .IsUnique();

                    b.ToTable("Pilotos", (string)null);
                });

            modelBuilder.Entity("CiaAerea.Entities.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AeronaveId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraChegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraPartida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("PilotoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AeronaveId");

                    b.HasIndex("PilotoId");

                    b.ToTable("Voos", (string)null);
                });

            modelBuilder.Entity("CiaAerea.Entities.Cancelamento", b =>
                {
                    b.HasOne("CiaAerea.Entities.Voo", "Voo")
                        .WithOne("Cancelamento")
                        .HasForeignKey("CiaAerea.Entities.Cancelamento", "VooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("CiaAerea.Entities.Manutencao", b =>
                {
                    b.HasOne("CiaAerea.Entities.Aeronave", "Aeronave")
                        .WithMany("Manutencoes")
                        .HasForeignKey("AeronaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeronave");
                });

            modelBuilder.Entity("CiaAerea.Entities.Voo", b =>
                {
                    b.HasOne("CiaAerea.Entities.Aeronave", "Aeronave")
                        .WithMany("Voos")
                        .HasForeignKey("AeronaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CiaAerea.Entities.Piloto", "Piloto")
                        .WithMany("Voos")
                        .HasForeignKey("PilotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeronave");

                    b.Navigation("Piloto");
                });

            modelBuilder.Entity("CiaAerea.Entities.Aeronave", b =>
                {
                    b.Navigation("Manutencoes");

                    b.Navigation("Voos");
                });

            modelBuilder.Entity("CiaAerea.Entities.Piloto", b =>
                {
                    b.Navigation("Voos");
                });

            modelBuilder.Entity("CiaAerea.Entities.Voo", b =>
                {
                    b.Navigation("Cancelamento");
                });
#pragma warning restore 612, 618
        }
    }
}