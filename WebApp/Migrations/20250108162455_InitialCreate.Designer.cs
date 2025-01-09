﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.Infrastructure.Data;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20250108162455_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Core.Entities.TestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<bool>("IsCodeTest")
                        .HasColumnType("boolean");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<int>("TestNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("WebApp.Core.Entities.TestOptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("TestOptions");
                });

            modelBuilder.Entity("WebApp.Core.Entities.TestSectionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TestSections");
                });

            modelBuilder.Entity("WebApp.Core.Entities.TestEntity", b =>
                {
                    b.HasOne("WebApp.Core.Entities.TestSectionEntity", null)
                        .WithMany("Tests")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Core.Entities.TestOptionEntity", b =>
                {
                    b.HasOne("WebApp.Core.Entities.TestEntity", null)
                        .WithMany("Options")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Core.Entities.TestEntity", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("WebApp.Core.Entities.TestSectionEntity", b =>
                {
                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
