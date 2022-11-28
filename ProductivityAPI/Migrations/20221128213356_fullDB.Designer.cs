﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductivityAPI.Data;

#nullable disable

namespace ProductivityAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221128213356_fullDB")]
    partial class fullDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductivityAPI.Model.BloodPressure", b =>
                {
                    b.Property<int>("BloodPressureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BloodPressureId"), 1L, 1);

                    b.Property<DateTime>("BMeasurementDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BNotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("DiastolicPressure")
                        .HasColumnType("float");

                    b.Property<double>("SystolicPressure")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BloodPressureId");

                    b.HasIndex("UserId");

                    b.ToTable("BloodPressures");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Medications", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicationId"), 1L, 1);

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicationUse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MedicationId");

                    b.HasIndex("UserId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Saturation", b =>
                {
                    b.Property<int>("SaturationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaturationId"), 1L, 1);

                    b.Property<DateTime>("SMeasurementDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SNotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("SaturationO2")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SaturationId");

                    b.HasIndex("UserId");

                    b.ToTable("Saturations");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Temperature", b =>
                {
                    b.Property<int>("TemperatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemperatureId"), 1L, 1);

                    b.Property<DateTime>("TMeasurementDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TNotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("TemperatureParameter")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TemperatureId");

                    b.HasIndex("UserId");

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("ProductivityAPI.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Weight", b =>
                {
                    b.Property<int>("WeightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeightId"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WMeasurementDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("WNotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("WeightKg")
                        .HasColumnType("float");

                    b.HasKey("WeightId");

                    b.HasIndex("UserId");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("ProductivityAPI.Model.BloodPressure", b =>
                {
                    b.HasOne("ProductivityAPI.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Medications", b =>
                {
                    b.HasOne("ProductivityAPI.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Notification", b =>
                {
                    b.HasOne("ProductivityAPI.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Saturation", b =>
                {
                    b.HasOne("ProductivityAPI.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Temperature", b =>
                {
                    b.HasOne("ProductivityAPI.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProductivityAPI.Model.Weight", b =>
                {
                    b.HasOne("ProductivityAPI.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}