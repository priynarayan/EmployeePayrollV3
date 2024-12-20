﻿// <auto-generated />
using System;
using EmployeePayrollV3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeePayrollV3.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230603100132_SameAsInitialModel")]
    partial class SameAsInitialModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.JobClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasicPay")
                        .HasColumnType("int");

                    b.Property<int>("HouseAllowance")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalAllowance")
                        .HasColumnType("int");

                    b.Property<int>("TravelAllowance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobClasses");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Payroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobClassId")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NetSalary")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("jobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("month")
                        .HasColumnType("datetime2");

                    b.Property<int>("salaryId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobClassId");

                    b.HasIndex("salaryId");

                    b.HasIndex("userId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("roleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BankAcc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bonus")
                        .HasColumnType("int");

                    b.Property<int>("JobClassId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("Tax")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobClassId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("roleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Payroll", b =>
                {
                    b.HasOne("EmployeePayrollV3.Models.DBModel.JobClass", "JobClass")
                        .WithMany("Payrolls")
                        .HasForeignKey("JobClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayrollV3.Models.DBModel.Salary", "Salary")
                        .WithMany("Payrolls")
                        .HasForeignKey("salaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayrollV3.Models.DBModel.User", "User")
                        .WithMany("Payrolls")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobClass");

                    b.Navigation("Salary");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Salary", b =>
                {
                    b.HasOne("EmployeePayrollV3.Models.DBModel.JobClass", "JobClass")
                        .WithMany("SalaryList")
                        .HasForeignKey("JobClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobClass");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.User", b =>
                {
                    b.HasOne("EmployeePayrollV3.Models.DBModel.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.JobClass", b =>
                {
                    b.Navigation("Payrolls");

                    b.Navigation("SalaryList");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.Salary", b =>
                {
                    b.Navigation("Payrolls");
                });

            modelBuilder.Entity("EmployeePayrollV3.Models.DBModel.User", b =>
                {
                    b.Navigation("Payrolls");
                });
#pragma warning restore 612, 618
        }
    }
}
