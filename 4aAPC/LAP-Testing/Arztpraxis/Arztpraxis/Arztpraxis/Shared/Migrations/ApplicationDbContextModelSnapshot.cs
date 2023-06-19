﻿// <auto-generated />
using System;
using Arztpraxis.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arztpraxis.Shared.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Arztpraxis.Shared.Diagnose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosen");
                });

            modelBuilder.Entity("Arztpraxis.Shared.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("GebDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("NName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("svnr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patienten");
                });

            modelBuilder.Entity("Arztpraxis.Shared.Termin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Beginn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bemerkung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiagnoseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ende")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Uhrzeit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiagnoseId");

                    b.HasIndex("PatientId");

                    b.ToTable("Termine");
                });

            modelBuilder.Entity("Arztpraxis.Shared.Termin", b =>
                {
                    b.HasOne("Arztpraxis.Shared.Diagnose", "Diagnose")
                        .WithMany()
                        .HasForeignKey("DiagnoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arztpraxis.Shared.Person", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnose");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}