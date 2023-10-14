﻿// <auto-generated />
using System;
using LightFireMoreTech5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    [DbContext(typeof(BankServicesContext))]
    partial class BankServicesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<bool>("AllDay")
                        .HasColumnType("boolean")
                        .HasColumnName("allday");

                    b.Property<int>("BlindCapability")
                        .HasColumnType("int")
                        .HasColumnName("blindcapability");

                    b.Property<int>("BlindChairActivity")
                        .HasColumnType("int")
                        .HasColumnName("blindchairactivity");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography (Point,4326)")
                        .HasColumnName("location");

                    b.Property<int>("NfcBankCardsActivity")
                        .HasColumnType("int")
                        .HasColumnName("nfcbankcardsactivity");

                    b.Property<int>("NfcBankCardsCapability")
                        .HasColumnType("int")
                        .HasColumnName("nfcbankcardscapability");

                    b.Property<int>("QrReadActivity")
                        .HasColumnType("int")
                        .HasColumnName("qrreadactivity");

                    b.Property<int>("QrReadCapability")
                        .HasColumnType("int")
                        .HasColumnName("qrreadcapability");

                    b.Property<int>("SupportChargeRubActivity")
                        .HasColumnType("int")
                        .HasColumnName("supportchargerubactivity");

                    b.Property<int>("SupportChargeRubCapability")
                        .HasColumnType("int")
                        .HasColumnName("supportchargerubcapability");

                    b.Property<int>("SupportEurActivity")
                        .HasColumnType("int")
                        .HasColumnName("supporteuractivity");

                    b.Property<int>("SupportEurCapability")
                        .HasColumnType("int")
                        .HasColumnName("supporteurcapability");

                    b.Property<int>("SupportRubActivity")
                        .HasColumnType("integer")
                        .HasColumnName("supportrubactivity");

                    b.Property<int>("SupportRubCapability")
                        .HasColumnType("int")
                        .HasColumnName("supportrubcapability");

                    b.Property<int>("SupportUsdActivity")
                        .HasColumnType("int")
                        .HasColumnName("supportusdactivity");

                    b.Property<int>("SupportUsdCapability")
                        .HasColumnType("int")
                        .HasColumnName("supportusdcapability");

                    b.Property<int>("WheelChairActivity")
                        .HasColumnType("int")
                        .HasColumnName("wheelchairactivity");

                    b.Property<int>("WheelChairCapability")
                        .HasColumnType("int")
                        .HasColumnName("wheelchaircapability");

                    b.HasKey("Id")
                        .HasName("pk_atms");

                    b.HasIndex("Location")
                        .HasDatabaseName("ix_atms_location");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Location"), "GIST");

                    b.ToTable("atms", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.AtmService", b =>
                {
                    b.Property<long>("atmId")
                        .HasColumnType("bigint")
                        .HasColumnName("atmid");

                    b.Property<long>("serviceId")
                        .HasColumnType("bigint")
                        .HasColumnName("serviceid");

                    b.HasKey("atmId", "serviceId")
                        .HasName("pk_atm_service");

                    b.HasIndex("serviceId")
                        .HasDatabaseName("ix_atm_service_serviceid");

                    b.ToTable("atm_service", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.Office", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<bool?>("AllDay")
                        .HasColumnType("bool")
                        .HasColumnName("allday");

                    b.Property<bool?>("HasRamp")
                        .HasColumnType("bool")
                        .HasColumnName("hasramp");

                    b.Property<long>("IndividualShceduleId")
                        .HasColumnType("bigint")
                        .HasColumnName("individualshceduleid");

                    b.Property<long?>("Kep")
                        .HasColumnType("bigint")
                        .HasColumnName("kep");

                    b.Property<long>("LegalEntityShceduleId")
                        .HasColumnType("bigint")
                        .HasColumnName("legalentityshceduleid");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography (Point,4326)")
                        .HasColumnName("location");

                    b.Property<string>("MetroStation")
                        .HasColumnType("text")
                        .HasColumnName("metrostation");

                    b.Property<bool?>("MyOffice")
                        .HasColumnType("bool")
                        .HasColumnName("myoffice");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("OfficeType")
                        .HasColumnType("text")
                        .HasColumnName("officetype");

                    b.Property<bool?>("Rko")
                        .HasColumnType("bool")
                        .HasColumnName("rko");

                    b.Property<string>("SalePointFormat")
                        .HasColumnType("text")
                        .HasColumnName("salepointformat");

                    b.HasKey("Id")
                        .HasName("pk_offices");

                    b.HasIndex("IndividualShceduleId")
                        .HasDatabaseName("ix_offices_individualshceduleid");

                    b.HasIndex("LegalEntityShceduleId")
                        .HasDatabaseName("ix_offices_legalentityshceduleid");

                    b.HasIndex("Location")
                        .HasDatabaseName("ix_offices_location");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Location"), "GIST");

                    b.ToTable("offices", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.OfficeSchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FridayEnd")
                        .HasColumnType("text")
                        .HasColumnName("fridayend");

                    b.Property<string>("FridayStart")
                        .HasColumnType("text")
                        .HasColumnName("fridaystart");

                    b.Property<string>("MondayEnd")
                        .HasColumnType("text")
                        .HasColumnName("mondayend");

                    b.Property<string>("MondayStart")
                        .HasColumnType("text")
                        .HasColumnName("mondaystart");

                    b.Property<string>("SaturdayEnd")
                        .HasColumnType("text")
                        .HasColumnName("saturdayend");

                    b.Property<string>("SaturdayStart")
                        .HasColumnType("text")
                        .HasColumnName("saturdaystart");

                    b.Property<string>("SundayEnd")
                        .HasColumnType("text")
                        .HasColumnName("sundayend");

                    b.Property<string>("SundayStart")
                        .HasColumnType("text")
                        .HasColumnName("sundaystart");

                    b.Property<string>("ThursdayEnd")
                        .HasColumnType("text")
                        .HasColumnName("thursdayend");

                    b.Property<string>("ThursdayStart")
                        .HasColumnType("text")
                        .HasColumnName("thursdaystart");

                    b.Property<string>("TuesdayEnd")
                        .HasColumnType("text")
                        .HasColumnName("tuesdayend");

                    b.Property<string>("TuesdayStart")
                        .HasColumnType("text")
                        .HasColumnName("tuesdaystart");

                    b.Property<string>("WednesdayEnd")
                        .HasColumnType("text")
                        .HasColumnName("wednesdayend");

                    b.Property<string>("WednesdayStart")
                        .HasColumnType("text")
                        .HasColumnName("wednesdaystart");

                    b.HasKey("Id")
                        .HasName("pk_office_schedule");

                    b.ToTable("office_schedule", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.OfficeService", b =>
                {
                    b.Property<long>("officeId")
                        .HasColumnType("bigint")
                        .HasColumnName("officeid");

                    b.Property<long>("serviceId")
                        .HasColumnType("bigint")
                        .HasColumnName("serviceid");

                    b.HasKey("officeId", "serviceId")
                        .HasName("pk_office_service");

                    b.HasIndex("serviceId")
                        .HasDatabaseName("ix_office_service_serviceid");

                    b.ToTable("office_service", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer")
                        .HasColumnName("category");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_service");

                    b.ToTable("service", (string)null);
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.AtmService", b =>
                {
                    b.HasOne("LightFireMoreTech5.Data.Entities.Atm", "Atm")
                        .WithMany()
                        .HasForeignKey("atmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_atm_service_atms_atmid");

                    b.HasOne("LightFireMoreTech5.Data.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_atm_service_service_serviceid");

                    b.Navigation("Atm");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.Office", b =>
                {
                    b.HasOne("LightFireMoreTech5.Data.Entities.OfficeSchedule", "IndividualSchedule")
                        .WithMany("IndividualOffices")
                        .HasForeignKey("IndividualShceduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offices_officeschedules_individualscheduleid");

                    b.HasOne("LightFireMoreTech5.Data.Entities.OfficeSchedule", "LegalEntitySchedule")
                        .WithMany("LegalEntitiesOffices")
                        .HasForeignKey("LegalEntityShceduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offices_officeschedules_legalentityscheduleid");

                    b.Navigation("IndividualSchedule");

                    b.Navigation("LegalEntitySchedule");
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.OfficeService", b =>
                {
                    b.HasOne("LightFireMoreTech5.Data.Entities.Office", "Office")
                        .WithMany()
                        .HasForeignKey("officeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_office_service_offices_officeid");

                    b.HasOne("LightFireMoreTech5.Data.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_office_service_service_serviceid");

                    b.Navigation("Office");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LightFireMoreTech5.Data.Entities.OfficeSchedule", b =>
                {
                    b.Navigation("IndividualOffices");

                    b.Navigation("LegalEntitiesOffices");
                });
#pragma warning restore 612, 618
        }
    }
}
