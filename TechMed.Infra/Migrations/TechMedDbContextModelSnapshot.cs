﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechMed.Infrastructure.Persistence;

#nullable disable

namespace TechMed.Infra.Migrations
{
    [DbContext(typeof(TechMedDbContext))]
    partial class TechMedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TechMed.Dommain.Entities.Atendimento", b =>
                {
                    b.Property<int>("AtendimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AtendimentoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Atendimentos", (string)null);
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Exame", b =>
                {
                    b.Property<int>("ExameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AtendimentoId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ExameId");

                    b.HasIndex("AtendimentoId");

                    b.ToTable("Exames", (string)null);
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CRM")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MedicoId");

                    b.ToTable("Medicos", (string)null);
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PacienteId");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Atendimento", b =>
                {
                    b.HasOne("TechMed.Dommain.Entities.Medico", "Medico")
                        .WithMany("Atendimentos")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechMed.Dommain.Entities.Paciente", "Paciente")
                        .WithMany("Atendimentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Exame", b =>
                {
                    b.HasOne("TechMed.Dommain.Entities.Atendimento", "Atendimento")
                        .WithMany("Exames")
                        .HasForeignKey("AtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendimento");
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Atendimento", b =>
                {
                    b.Navigation("Exames");
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Medico", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("TechMed.Dommain.Entities.Paciente", b =>
                {
                    b.Navigation("Atendimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
