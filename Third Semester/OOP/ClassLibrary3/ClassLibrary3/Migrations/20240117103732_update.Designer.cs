﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vaccinecalend;

#nullable disable

namespace vaccinecalend.Migrations
{
    [DbContext(typeof(VaccineCalendarContext))]
    [Migration("20240117103732_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VaccinationVaccinationDiary", b =>
                {
                    b.Property<Guid>("VaccinationsDiaryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VaccinationsVaccinationId")
                        .HasColumnType("uuid");

                    b.HasKey("VaccinationsDiaryId", "VaccinationsVaccinationId");

                    b.HasIndex("VaccinationsVaccinationId");

                    b.ToTable("VaccinationVaccinationDiary");
                });

            modelBuilder.Entity("vaccinecalend.CompleteVaccineComponent", b =>
                {
                    b.Property<Guid>("CompleteComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("VaccinationDate")
                        .HasColumnType("date");

                    b.Property<Guid>("VaccinationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VaccineComponentComponentId")
                        .HasColumnType("uuid");

                    b.HasKey("CompleteComponentId");

                    b.HasIndex("VaccinationId");

                    b.HasIndex("VaccineComponentComponentId");

                    b.ToTable("CompleteVaccineComponents");
                });

            modelBuilder.Entity("vaccinecalend.MedicalOrganization", b =>
                {
                    b.Property<Guid>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrganizationId");

                    b.ToTable("MedicalOrganizations");
                });

            modelBuilder.Entity("vaccinecalend.ReactionOnVaccination", b =>
                {
                    b.Property<Guid>("ReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfReaction")
                        .HasColumnType("date");

                    b.Property<string>("DescriptionOfReaction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VaccinationId")
                        .HasColumnType("uuid");

                    b.HasKey("ReactionId");

                    b.HasIndex("VaccinationId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("vaccinecalend.RecordToVaccination", b =>
                {
                    b.Property<Guid>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MedicalOrganizationOrganizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<Guid>("VaccinatedId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VaccineId")
                        .HasColumnType("uuid");

                    b.HasKey("RecordId");

                    b.HasIndex("MedicalOrganizationOrganizationId");

                    b.HasIndex("VaccinatedId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("vaccinecalend.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("vaccinecalend.Vaccinated", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InshuranceNumber")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InshuranceNumber")
                        .IsUnique();

                    b.ToTable("Vaccinated");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vaccinated");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("vaccinecalend.Vaccination", b =>
                {
                    b.Property<Guid>("VaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("FlagIsDone")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MedicalOrganizationOrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TimeInterval")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VaccineId")
                        .HasColumnType("uuid");

                    b.HasKey("VaccinationId");

                    b.HasIndex("MedicalOrganizationOrganizationId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("vaccinecalend.VaccinationDiary", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("VaccinatedId")
                        .HasColumnType("uuid");

                    b.HasKey("DiaryId");

                    b.HasIndex("VaccinatedId");

                    b.ToTable("VaccinationDiary");
                });

            modelBuilder.Entity("vaccinecalend.Vaccine", b =>
                {
                    b.Property<Guid>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ManufactorCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VaccineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ValidPeriod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("vaccinecalend.VaccineComponent", b =>
                {
                    b.Property<Guid>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("IntervalOfComponent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Structure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VaccineId")
                        .HasColumnType("uuid");

                    b.HasKey("ComponentId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("vaccinecalend.Child", b =>
                {
                    b.HasBaseType("vaccinecalend.Vaccinated");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Child");
                });

            modelBuilder.Entity("vaccinecalend.User", b =>
                {
                    b.HasBaseType("vaccinecalend.Vaccinated");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("VaccinationVaccinationDiary", b =>
                {
                    b.HasOne("vaccinecalend.VaccinationDiary", null)
                        .WithMany()
                        .HasForeignKey("VaccinationsDiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vaccinecalend.Vaccination", null)
                        .WithMany()
                        .HasForeignKey("VaccinationsVaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("vaccinecalend.CompleteVaccineComponent", b =>
                {
                    b.HasOne("vaccinecalend.Vaccination", "Vaccination")
                        .WithMany("CompleteVaccineComponents")
                        .HasForeignKey("VaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vaccinecalend.VaccineComponent", "VaccineComponent")
                        .WithMany("CompleteVaccineComponents")
                        .HasForeignKey("VaccineComponentComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaccination");

                    b.Navigation("VaccineComponent");
                });

            modelBuilder.Entity("vaccinecalend.ReactionOnVaccination", b =>
                {
                    b.HasOne("vaccinecalend.Vaccination", "Vaccination")
                        .WithMany("Reactions")
                        .HasForeignKey("VaccinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaccination");
                });

            modelBuilder.Entity("vaccinecalend.RecordToVaccination", b =>
                {
                    b.HasOne("vaccinecalend.MedicalOrganization", null)
                        .WithMany("Records")
                        .HasForeignKey("MedicalOrganizationOrganizationId");

                    b.HasOne("vaccinecalend.Vaccinated", null)
                        .WithMany("Records")
                        .HasForeignKey("VaccinatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vaccinecalend.Vaccine", null)
                        .WithMany("Records")
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("vaccinecalend.UserRole", b =>
                {
                    b.HasOne("vaccinecalend.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("vaccinecalend.Vaccination", b =>
                {
                    b.HasOne("vaccinecalend.MedicalOrganization", "MedicalOrganization")
                        .WithMany("Vaccinations")
                        .HasForeignKey("MedicalOrganizationOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vaccinecalend.Vaccine", "Vaccine")
                        .WithMany("Vaccinations")
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalOrganization");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("vaccinecalend.VaccinationDiary", b =>
                {
                    b.HasOne("vaccinecalend.Vaccinated", "Vaccinated")
                        .WithMany("VaccinationDiary")
                        .HasForeignKey("VaccinatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaccinated");
                });

            modelBuilder.Entity("vaccinecalend.VaccineComponent", b =>
                {
                    b.HasOne("vaccinecalend.Vaccine", "Vaccine")
                        .WithMany("VaccineComponents")
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("vaccinecalend.Child", b =>
                {
                    b.HasOne("vaccinecalend.User", "User")
                        .WithMany("Children")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("vaccinecalend.MedicalOrganization", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("vaccinecalend.Vaccinated", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("VaccinationDiary");
                });

            modelBuilder.Entity("vaccinecalend.Vaccination", b =>
                {
                    b.Navigation("CompleteVaccineComponents");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("vaccinecalend.Vaccine", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("Vaccinations");

                    b.Navigation("VaccineComponents");
                });

            modelBuilder.Entity("vaccinecalend.VaccineComponent", b =>
                {
                    b.Navigation("CompleteVaccineComponents");
                });

            modelBuilder.Entity("vaccinecalend.User", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
