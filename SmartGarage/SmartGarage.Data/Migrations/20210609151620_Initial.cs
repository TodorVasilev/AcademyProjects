using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartGarage.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DrivingLicenseNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CurrentRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    NumberPlate = table.Column<string>(maxLength: 10, nullable: false),
                    VIN = table.Column<string>(maxLength: 17, nullable: false),
                    Colour = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageId = table.Column<int>(nullable: false),
                    OrderStatusId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrders", x => new { x.ServiceId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "2607d08b-6b1b-4fdc-a329-1e7ac65da23e", "Employee", "EMPLOYEE" },
                    { 1, "706160c6-5f17-4452-9840-7c3dbd238f4b", "Admin", "ADMIN" },
                    { 3, "89395fda-e6c5-451a-b319-9dc3f619b4c1", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "CurrentRole", "DrivingLicenseNumber", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Sofia, Bulgaria", 37, "7da60fbc-66b6-4b52-b7af-16b022076e14", "ADMIN", "93302193", "smartgarage@gmail.com", false, "Smart", false, "Garage", false, null, "SMARTGARAGE@GMAIL.COM", "SMARTGARAGE", "AQAAAAEAACcQAAAAEFCWQlwKH7gRQdlf9upJ2mAOJHKek5S7SCa9KpTWesu4I+VsD49ojJathdojtIoT1w==", "0851547896", false, "7c258773-18f9-4240-a5aa-9d1a2d68ca10", false, "SmartGarage" },
                    { 4, 0, "Burgas, Bulgaria", 40, "a51d1efb-72af-4798-a382-48c7a7077486", "CUSTOMER", "73322193", "ivangeorgiev14@gmail.com", false, "Ivan", false, "Georgiev", false, null, "IVANGEORGIEV14@GMAIL.COM", "IVANG", "AQAAAAEAACcQAAAAEKCfDdcXMjEWNTIc3D+kchplYFWQtbn1PQ5MS9zej3UtpuvzY31C85LWqpWE2pCYtg==", "0878647896", false, "ad3f9447-29b5-4458-82b3-64be461128bd", false, "IvanG" },
                    { 5, 0, "Blagoevgrad, Bulgaria", 22, "5a8ad026-5f36-4374-93c9-250c3535a707", "CUSTOMER", "91304433", "californication@gmail.com", false, "Todor", false, "Kolev", false, null, "CALIFORNICATION@GMAIL.COM", "LOVETOACT", "AQAAAAEAACcQAAAAEF89yaexWuBwciKfJXrX8U5JHgWcbrfCTFDUqbSw3X+KHxrEQjfq1FNyRwCx4d9P+g==", "0871247896", false, "91917000-69e2-45bd-830e-6f5f73f40c95", false, "LoveToAct" },
                    { 6, 0, "Blagoevgrad, Bulgaria", 24, "06c84c79-6de7-4fb3-92b0-6fb08d634241", "CUSTOMER", "91304433123", "penkapetrova@gmail.com", false, "Penka", false, "Petrova", false, null, "PENKAPETROVA@GMAIL.COM", "PENKAPETROVA", "AQAAAAEAACcQAAAAEKFd8+uUa2qIvLh/cxoDoAdrqW2XmKGR7wXPDMsAyxUGhTRLI9ygYbQwlzZtgBjcmg==", "0879737896", false, "459cc8c8-08c1-4e1c-887e-f2dfb0feac40", false, "PenkaPetrova" },
                    { 7, 0, "Botevgrad, Bulgaria", 31, "a64066f3-d5e2-46f5-ae19-926baa5bfe8d", "CUSTOMER", "4984654156", "ivandimitrov@gmail.com", false, "Ivan", false, "Dimitrov", false, null, "IVANDIMITROV@GMAIL.COM", "IVANDIMITROV", "AQAAAAEAACcQAAAAEFC2b+Vq2bhcD9F+9SVKl/YHKrIFmoLrgk9ticeiR7nu/UzGs8SiGaf9qhBCOieEjA==", "08897247896", false, "0f7297b0-c2ca-43ee-a3fd-7c7457f03d38", false, "IvanDimitrov" },
                    { 8, 0, "Russe, Bulgaria", 48, "7387d5fc-f375-4c37-a0ad-c59120f31a46", "CUSTOMER", "498124654156", "kuzmov34@gmail.com", false, "Marian", false, "Kuzmov", false, null, "KUZMOV34@GMAIL.COM", "MARIANKUZMOV", "AQAAAAEAACcQAAAAEMtzU6/t/lmmyI1ztHcAPB1jSZ42/oiL+Q1rlTq0ajIfLODoAsZEZlzTSBwpILf88g==", "08897247943", false, "ad161f21-0c8d-4b19-a5ed-8c754a280682", false, "MarianKusmov" },
                    { 9, 0, "Sofia, Bulgaria", 35, "53c25bc0-f281-452b-a48e-fe6d76466291", "CUSTOMER", "49812324654156", "pepilakov34@gmail.com", false, "Petar", false, "Lakov", false, null, "PEPILAKOV34@GMAIL.COM", "PETARLAKOV", "AQAAAAEAACcQAAAAEK6bLBkDhv2oaghpdBu97DvZF91yzEGbxaQCWgM0EGmK2I9MVnQ4LRHXdU1gnsN4Qg==", "08897247444", false, "743f20b9-745d-43ed-8afd-1fd67b5d2d53", false, "PetarLakov" },
                    { 10, 0, "Dobrich, Bulgaria", 24, "594ddcc7-16db-4bec-9f1e-1aab803d2946", "CUSTOMER", "4982124654156", "nikola12@gmail.com", false, "Nikola", false, "Urumov", false, null, "NIKOLA12@GMAIL.COM", "NIKOLAURUMOV", "AQAAAAEAACcQAAAAEAP3R3HsQpX1pgbrLwCtWP9EMLpOoCYmcfslRzpnVcg9ZofaoPiIcd+VSU0+46vMmg==", "08897247111", false, "411410b8-4f6a-43e2-937e-da22b3a7d1f4", false, "NikolaUrumov" },
                    { 11, 0, "Pernik, Bulgaria", 49, "6323ed1e-9986-4d30-9a53-08a324e380bd", "CUSTOMER", "42134654156", "rumi@gmail.com", false, "Roman", false, "Abramovich", false, null, "RUMI@GMAIL.COM", "RUMI123", "AQAAAAEAACcQAAAAEHBNEZbCPwEFT3WQodKurndNfBK8fH8x8wcjoCfqBPHLtY1UcE9zcT6OvnoEG8yzug==", "0889724777", false, "0338a42e-b1cb-4a68-b4cf-952f6ab0202a", false, "Rumi123" },
                    { 3, 0, "Sofia, Bulgaria", 28, "261bede5-6454-4ed1-a892-5e3a143774a2", "CUSTOMER", "13302343", "firstcustomer@gmail.com", false, "First", false, "Customer", false, null, "FIRSTCUSTOMER@GMAIL.COM", "THEVERYFIRSTCUSTOMER", "AQAAAAEAACcQAAAAEEFvNkW3O54BIh4b6U8pgSE2yjn31XP4TQxEOaMGxvhO18sd68ZHovaCoEV9OFiVog==", "0851545496", false, "20fc73e7-6d87-4104-a289-480a80d2c71e", false, "TheVeryFirstCustomer" },
                    { 2, 0, "Sofia, Bulgaria", 28, "8661e004-f254-43d7-80b7-ab806c1ae25f", "EMPLOYEE", "3241219", "petar@test.com", false, "Petar", false, "Petrov", false, null, "PETAR@TEST.COM", "PETARPETROV", "AQAAAAEAACcQAAAAEKiW4KLOl8J0uhOUFgGC98Re35XnjlPZ42jRecVN+jz9aZFZmUZUPADemiBfWRtYYA==", "0851521896", false, "deb6b9eb-6a98-4475-b9e9-6e425c1acb07", false, "PetarPetrov" }
                });

            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "bul.Graf Ignatiev 0", "Insomnia" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Honda" },
                    { 5, "BMW" },
                    { 4, "Daimler" },
                    { 3, "Volkswagen" },
                    { 2, "Toyota" },
                    { 1, "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Ready for pickup" },
                    { 2, "In progress" },
                    { 1, "Not started" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 5, false, "Battery replacement", 199.99m },
                    { 7, false, "Fuel pump replacment", 180.20m },
                    { 6, false, "Computer diagnostic", 35.99m },
                    { 4, false, "Pads replacement", 249.99m },
                    { 3, false, "Change a tire", 8.99m },
                    { 2, false, "Change all tires", 24.99m },
                    { 1, false, "Oil change", 74.99m },
                    { 8, false, "Diagnostic and endgine inspection", 125.30m }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Bus" },
                    { 1, "Car" },
                    { 2, "Motorcycle" },
                    { 4, "Truck" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "ManufacturerId", "Name", "VehicleTypeId" },
                values: new object[,]
                {
                    { 11, 6, "Hornet", 2 },
                    { 12, 6, "Civic", 1 },
                    { 10, 5, "E30", 1 },
                    { 9, 5, "X6", 1 },
                    { 7, 4, "C-class", 1 },
                    { 1, 1, "Model X", 1 },
                    { 5, 3, "Passat", 1 },
                    { 3, 2, "Prius", 1 },
                    { 2, 1, "Model S", 1 },
                    { 4, 2, "HiAce H300", 3 },
                    { 6, 3, "Arteon", 1 },
                    { 8, 4, "Western-Star", 4 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Colour", "IsDeleted", "NumberPlate", "UserId", "VIN", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, "Blue", false, "CA 1994 BC", 3, "1HGCM82633A004352", 2 },
                    { 2, "Black", false, "CA 2011 OC", 3, "1HGCM82633A004352", 11 },
                    { 4, "White", false, "A 1839 BA", 5, "1HGCM82633A004352", 4 },
                    { 3, "Red", false, "E 3994 AC", 4, "1HGCM82633A004352", 8 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "FinishDate", "GarageId", "IsDeleted", "OrderStatusId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 7, 18, 16, 20, 516, DateTimeKind.Local).AddTicks(7531), new DateTime(2021, 6, 9, 18, 16, 20, 518, DateTimeKind.Local).AddTicks(9451), 1, false, 3, 1 },
                    { 5, new DateTime(2021, 6, 8, 18, 16, 20, 518, DateTimeKind.Local).AddTicks(9882), null, 1, false, 1, 1 },
                    { 4, new DateTime(2021, 6, 5, 18, 16, 20, 518, DateTimeKind.Local).AddTicks(9879), null, 1, false, 2, 2 },
                    { 3, new DateTime(2021, 5, 30, 18, 16, 20, 518, DateTimeKind.Local).AddTicks(9874), null, 1, false, 2, 4 },
                    { 2, new DateTime(2021, 6, 6, 18, 16, 20, 518, DateTimeKind.Local).AddTicks(9849), null, 1, false, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceOrders",
                columns: new[] { "ServiceId", "OrderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 3, 5 },
                    { 5, 4 },
                    { 1, 3 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GarageId",
                table: "Orders",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_OrderId",
                table: "ServiceOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_ManufacturerId",
                table: "VehicleModels",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleTypeId",
                table: "VehicleModels",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
