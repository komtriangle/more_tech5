﻿// <auto-generated />
using LightFireMoreTech5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    [DbContext(typeof(BankServicesContext))]
    [Migration("20231013174914_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.Atm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography (Point,4326)")
                        .HasColumnName("location");

                    b.HasKey("Id")
                        .HasName("pk_atms");

                    b.HasIndex("Location")
                        .HasDatabaseName("ix_atms_location");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Location"), "GIST");

                    b.ToTable("atms", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.Office", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography (Point,4326)")
                        .HasColumnName("location");

                    b.HasKey("Id")
                        .HasName("pk_offices");

                    b.HasIndex("Location")
                        .HasDatabaseName("ix_offices_location");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Location"), "GIST");

                    b.ToTable("offices", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}