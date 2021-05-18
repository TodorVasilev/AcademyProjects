﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGarage.Data;

namespace SmartGarage.Data.Migrations
{
    [DbContext(typeof(SmartGarageContext))]
    partial class SmartGarageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Garages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "bil.Graf Ignatiev 0",
                            Name = "Insomnia"
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tesla"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Daimler"
                        },
                        new
                        {
                            Id = 5,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Honda"
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GarageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GarageId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SmartGarage.Data.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Not started"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ready for pickup"
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "99123926-73cc-4237-ae09-999156c2158a",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "7c20a4c2-22f2-421b-bcef-47d1f8c201c6",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "fed794c9-679b-477c-b4ef-3fb88709c3f3",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Oil change",
                            Price = 74.989999999999995
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Change all tires",
                            Price = 24.989999999999998
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Change a tire",
                            Price = 8.9900000000000002
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Pads replacement",
                            Price = 249.99000000000001
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Battery replacement",
                            Price = 199.99000000000001
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Computer diagnostic",
                            Price = 35.990000000000002
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.ServiceOrder", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("SmartGarage.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrivingLicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Address = "Sofia, Bulgaria",
                            Age = 37,
                            ConcurrencyStamp = "706a80b1-b11d-499c-bc35-cef172630e3c",
                            DrivingLicenseNumber = "93302193",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            IsDeleted = false,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMINADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEBDGpv0fQhU/RwSzd4F4F7A8hM1BfQ+7NXrhQ8fkF2WhaCuGDI8J5WrWRKbraQTsZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "44292128-886c-402a-b6e4-54d9bfdcc6d0",
                            TwoFactorEnabled = false,
                            UserName = "AdminAdmin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Address = "Sofia, Bulgaria",
                            Age = 28,
                            ConcurrencyStamp = "63d05b2f-a8e1-44c0-86f0-9699e68bbe01",
                            DrivingLicenseNumber = "3241219",
                            Email = "employee@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Emlpoyee",
                            IsDeleted = false,
                            LastName = "Emlpoyee",
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                            NormalizedUserName = "EMPLOYEE",
                            PasswordHash = "AQAAAAEAACcQAAAAEAn5vYaJeWFcSbs8O2ZnYIkHWMF2Awd+PxAY7s9NNT85ORs7Bi5s1khbNuBAgtZqOg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5f662847-6130-4ccd-9573-1663446967fb",
                            TwoFactorEnabled = false,
                            UserName = "EmlpoyeeEmlpoyee"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Address = "Sofia, Bulgaria",
                            Age = 28,
                            ConcurrencyStamp = "ebc161a8-a04e-46bc-a5b1-98cb16add2b8",
                            DrivingLicenseNumber = "13302343",
                            Email = "firstcustomer@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "First",
                            IsDeleted = false,
                            LastName = "Customer",
                            LockoutEnabled = false,
                            NormalizedEmail = "FIRSTCUSTOMER@GMAIL.COM",
                            NormalizedUserName = "THEVERYFIRSTCUSTOMER",
                            PasswordHash = "AQAAAAEAACcQAAAAEMOvMIImBW91lPu6tAKx9DPMaG7ANKLGN9QerG+tAds+73tzOpDYQSqfTf6yhd2VYQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "73b4c0af-8566-4117-b084-2b184f14b60e",
                            TwoFactorEnabled = false,
                            UserName = "TheVeryFirstCustomer"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            Address = "Burgas, Bulgaria",
                            Age = 40,
                            ConcurrencyStamp = "ef4e2313-ef54-4480-838f-b20093680cfe",
                            DrivingLicenseNumber = "73322193",
                            Email = "ivangeorgiev14@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ivan",
                            IsDeleted = false,
                            LastName = "Georgiev",
                            LockoutEnabled = false,
                            NormalizedEmail = "IVANGEORGIEV14@GMAIL.COM",
                            NormalizedUserName = "IVANG",
                            PasswordHash = "AQAAAAEAACcQAAAAENQHJTKsZvzpw+XqtUJXUpesDCCB4MF/dfaPy2OcXmF43BGIV0NJnouIgieDXK2O9Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a821e47b-d5b6-4072-91f1-e92a0cc252f7",
                            TwoFactorEnabled = false,
                            UserName = "IvanG"
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            Address = "Blagoevgrad, Bulgaria",
                            Age = 22,
                            ConcurrencyStamp = "cd19de74-26c3-4d28-98f3-6b4e3be853fb",
                            DrivingLicenseNumber = "91304433",
                            Email = "californication@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Todor",
                            IsDeleted = false,
                            LastName = "Kolev",
                            LockoutEnabled = false,
                            NormalizedEmail = "CALIFORNICATION@GMAIL.COM",
                            NormalizedUserName = "LOVETOACT",
                            PasswordHash = "AQAAAAEAACcQAAAAEK6xMCZZGoV7vWonO/4a5ixYeYPA8MHfc2CVXsz9Kqrekpvo7jovnXeaQRPI6Ym1bw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f932e946-9f03-48b4-aab4-b09fd378d0fa",
                            TwoFactorEnabled = false,
                            UserName = "LoveToAct"
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Colour = "Blue",
                            IsDeleted = false,
                            NumberPlate = "CA 1994 BC",
                            UserId = 3,
                            VIN = "1HGCM82633A004352",
                            VehicleModelId = 2
                        },
                        new
                        {
                            Id = 2,
                            Colour = "Black",
                            IsDeleted = false,
                            NumberPlate = "CA 2011 OC",
                            UserId = 3,
                            VIN = "1HGCM82633A004352",
                            VehicleModelId = 11
                        },
                        new
                        {
                            Id = 3,
                            Colour = "Red",
                            IsDeleted = false,
                            NumberPlate = "E 3994 AC",
                            UserId = 4,
                            VIN = "1HGCM82633A004352",
                            VehicleModelId = 8
                        },
                        new
                        {
                            Id = 4,
                            Colour = "White",
                            IsDeleted = false,
                            NumberPlate = "A 1839 BA",
                            UserId = 5,
                            VIN = "1HGCM82633A004352",
                            VehicleModelId = 4
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("VehicleModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManufacturerId = 1,
                            Name = "Model X",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            ManufacturerId = 1,
                            Name = "Model S",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            ManufacturerId = 2,
                            Name = "Prius",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            ManufacturerId = 2,
                            Name = "HiAce H300",
                            VehicleTypeId = 3
                        },
                        new
                        {
                            Id = 5,
                            ManufacturerId = 3,
                            Name = "Passat",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            ManufacturerId = 3,
                            Name = "Arteon",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            ManufacturerId = 4,
                            Name = "C-class",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 8,
                            ManufacturerId = 4,
                            Name = "Western-Star",
                            VehicleTypeId = 4
                        },
                        new
                        {
                            Id = 9,
                            ManufacturerId = 5,
                            Name = "X6",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 10,
                            ManufacturerId = 5,
                            Name = "E30",
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 11,
                            ManufacturerId = 6,
                            Name = "Hornet",
                            VehicleTypeId = 2
                        },
                        new
                        {
                            Id = 12,
                            ManufacturerId = 6,
                            Name = "Civic",
                            VehicleTypeId = 1
                        });
                });

            modelBuilder.Entity("SmartGarage.Data.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceCoefficient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Car",
                            PriceCoefficient = 1.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Motorcycle",
                            PriceCoefficient = 0.90000000000000002
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bus",
                            PriceCoefficient = 2.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Truck",
                            PriceCoefficient = 2.5
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartGarage.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Order", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.Garage", "Garage")
                        .WithMany("Orders")
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartGarage.Data.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartGarage.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Orders")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartGarage.Data.Models.ServiceOrder", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.Order", "Order")
                        .WithMany("ServiceOrder")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartGarage.Data.Models.Service", "Service")
                        .WithMany("ServiceOrder")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartGarage.Data.Models.Vehicle", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartGarage.Data.Models.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartGarage.Data.Models.VehicleModel", b =>
                {
                    b.HasOne("SmartGarage.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartGarage.Data.Models.VehicleType", "VehicleType")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
