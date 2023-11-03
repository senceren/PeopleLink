﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(PeopleLinkContext))]
    partial class PeopleLinkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Entities.Advance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvanceType")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Advances");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Advance");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApplicationCore.Entities.CityAndDistrictEntities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CityAndDistrictEntities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("int");

                    b.Property<int>("EstablishmentYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MERSISNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpenseType")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Expenses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Expense");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApplicationCore.Entities.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Leaves");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Leave");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApplicationCore.Entities.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AccruedLeave")
                        .HasColumnType("int");

                    b.Property<decimal>("AdvanceAllowance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BirthPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("BirthPlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleLastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OccupationId")
                        .HasColumnType("int");

                    b.Property<string>("OccupationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PictureUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("ApplicationCore.Entities.AdvanceEntities.IndividualAdvance", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Advance");

                    b.HasDiscriminator().HasValue("IndividualAdvance");
                });

            modelBuilder.Entity("CorporateAdvance", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Advance");

                    b.HasDiscriminator().HasValue("CorporateAdvance");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ExpenseEntities.AccommodationExpense", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Expense");

                    b.HasDiscriminator().HasValue("AccommodationExpense");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ExpenseEntities.HealtInsuranceAndOtherBenefitsExpense", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Expense");

                    b.HasDiscriminator().HasValue("HealtInsuranceAndOtherBenefitsExpense");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ExpenseEntities.MealExpense", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Expense");

                    b.HasDiscriminator().HasValue("MealExpense");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ExpenseEntities.PhoneAndInternetExpense", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Expense");

                    b.HasDiscriminator().HasValue("PhoneAndInternetExpense");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ExpenseEntities.ProfessionalDevelopmentExpense", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Expense");

                    b.HasDiscriminator().HasValue("ProfessionalDevelopmentExpense");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ExpenseEntities.TransportationExpense", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Expense");

                    b.HasDiscriminator().HasValue("TransportationExpense");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.AnnualLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("AnnualLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.BereavementLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("BereavementLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.CompassionateLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("CompassionateLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.MarriageLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("MarriageLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.MaternityLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("MaternityLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.PaternityLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("PaternityLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.LeaveEntities.SickLeave", b =>
                {
                    b.HasBaseType("ApplicationCore.Entities.Leave");

                    b.HasDiscriminator().HasValue("SickLeave");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CityAndDistrictEntities.District", b =>
                {
                    b.HasOne("ApplicationCore.Entities.CityAndDistrictEntities.City", null)
                        .WithMany("Districts")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("ApplicationCore.Entities.CityAndDistrictEntities.City", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
