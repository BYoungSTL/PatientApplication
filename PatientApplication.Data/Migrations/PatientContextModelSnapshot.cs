﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientApplication.Data;

#nullable disable

namespace PatientApplication.Data.Migrations
{
    [DbContext(typeof(PatientContext))]
    partial class PatientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PatientApplication.Data.Entities.Name", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Family");

                    b.Property<string>("Given")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Given");

                    b.Property<string>("Use")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Use");

                    b.HasKey("Id");

                    b.ToTable("Name", (string)null);
                });

            modelBuilder.Entity("PatientApplication.Data.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NameId");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.HasKey("Id");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("PatientApplication.Data.Entities.Name", b =>
                {
                    b.HasOne("PatientApplication.Data.Entities.Patient", "Patient")
                        .WithOne("Name")
                        .HasForeignKey("PatientApplication.Data.Entities.Name", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientApplication.Data.Entities.Patient", b =>
                {
                    b.Navigation("Name")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
