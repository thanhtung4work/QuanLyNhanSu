﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyNhanSu.Persistence;

#nullable disable

namespace QuanLyNhanSu.Persistence.Migrations
{
    [DbContext(typeof(QuanLyNhanSuDbContext))]
    [Migration("20221021145015_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyNhanSu.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("LocationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinSalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("PorjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.HasIndex("LocationId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.ProjectParticipant", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.ToTable("ProjectParticipants");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Relative", b =>
                {
                    b.Property<int>("RelativeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelativeId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelativeId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Relatives");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Department", b =>
                {
                    b.HasOne("QuanLyNhanSu.Entity.Location", null)
                        .WithMany("Departments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Employee", b =>
                {
                    b.HasOne("QuanLyNhanSu.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyNhanSu.Entity.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Project", b =>
                {
                    b.HasOne("QuanLyNhanSu.Entity.Location", null)
                        .WithMany("Projects")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.ProjectParticipant", b =>
                {
                    b.HasOne("QuanLyNhanSu.Entity.Employee", "Employee")
                        .WithMany("ProjectParticipants")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QuanLyNhanSu.Entity.Project", "Project")
                        .WithMany("ProjectParticipants")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Relative", b =>
                {
                    b.HasOne("QuanLyNhanSu.Entity.Employee", "Employee")
                        .WithOne("Relative")
                        .HasForeignKey("QuanLyNhanSu.Entity.Relative", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Employee", b =>
                {
                    b.Navigation("ProjectParticipants");

                    b.Navigation("Relative");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Location", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("QuanLyNhanSu.Entity.Project", b =>
                {
                    b.Navigation("ProjectParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
