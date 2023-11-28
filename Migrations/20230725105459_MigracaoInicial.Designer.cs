﻿// <auto-generated />
using System;
using Apiuniversidade.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Apiuniversidade.Migrations
{
    [DbContext(typeof(ApiuniversidadeContext))]
    [Migration("20230725105459_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Apiuniversidade.Model.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Cursoid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Cursoid");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Apiuniversidade.Model.Curso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("duracao")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Apiuniversidade.Model.Disciplina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("integer");

                    b.Property<int?>("Cursoid")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("semestre")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Cursoid");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("Apiuniversidade.Model.Aluno", b =>
                {
                    b.HasOne("Apiuniversidade.Model.Curso", null)
                        .WithMany("Alunos")
                        .HasForeignKey("Cursoid");
                });

            modelBuilder.Entity("Apiuniversidade.Model.Disciplina", b =>
                {
                    b.HasOne("Apiuniversidade.Model.Curso", null)
                        .WithMany("disciplinas")
                        .HasForeignKey("Cursoid");
                });

            modelBuilder.Entity("Apiuniversidade.Model.Curso", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
