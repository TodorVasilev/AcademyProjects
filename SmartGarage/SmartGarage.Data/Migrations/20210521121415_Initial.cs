using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: true),
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
                    Name = table.Column<string>(nullable: false)
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
                    Price = table.Column<double>(nullable: false),
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
                    Name = table.Column<string>(nullable: false),
                    PriceCoefficient = table.Column<double>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 3, "484c7eb2-7055-4cfb-b2b9-581c39e72a12", "Customer", "CUSTOMER" },
                    { 2, "6bc239c9-29c5-4ff9-8d84-8c186c3d44a0", "Employee", "EMPLOYEE" },
                    { 1, "d753c488-a127-4acb-ac90-0e0b7bc28b7a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "CurrentRole", "DrivingLicenseNumber", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Sofia, Bulgaria", 37, "54bd3f16-7f06-48e0-8925-d68806d5560e", "ADMIN", "93302193", "admin@gmail.com", false, "Admin", false, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMINADMIN", "AQAAAAEAACcQAAAAENQqM6vGop/puzLTOK7OrDVLaNBusbvod9bUj7ZCNSPQURwR2s9bVC4TV3fDL0L0QA==", null, false, "7971d536-97ec-485f-8111-cb0d2985d1d7", false, "AdminAdmin" },
                    { 3, 0, "Sofia, Bulgaria", 28, "72210220-299f-4a89-af8c-09b24f6c0c35", "CUSTOMER", "13302343", "firstcustomer@gmail.com", false, "First", false, "Customer", false, null, "FIRSTCUSTOMER@GMAIL.COM", "THEVERYFIRSTCUSTOMER", "AQAAAAEAACcQAAAAEL3v48U58fKG0mKDyJe3DASeZ/CUivY1Nt3Lzc7Bos3yo2vvbiZIbjdeLlgQ9bKGAg==", null, false, "8f420d49-471b-4737-b93f-0b8939e93124", false, "TheVeryFirstCustomer" },
                    { 4, 0, "Burgas, Bulgaria", 40, "bcbff06c-5a18-4b76-a264-1e70d4733176", "CUSTOMER", "73322193", "ivangeorgiev14@gmail.com", false, "Ivan", false, "Georgiev", false, null, "IVANGEORGIEV14@GMAIL.COM", "IVANG", "AQAAAAEAACcQAAAAEAcRHKErCE77SeENkOJKT5Cb0A1l+j6dZBgPWLVMKc6+DCKQwoR7yj2nffE5np6EWw==", null, false, "5888f7d6-23a2-4b2f-b431-8dc5eaf78186", false, "IvanG" },
                    { 5, 0, "Blagoevgrad, Bulgaria", 22, "74de2ca9-5e7e-456f-acb1-530f621c4d6e", "CUSTOMER", "91304433", "californication@gmail.com", false, "Todor", false, "Kolev", false, null, "CALIFORNICATION@GMAIL.COM", "LOVETOACT", "AQAAAAEAACcQAAAAEFVYebjG0UXrSmsXjTn+pAJpaDCrudPxlEbpSWCoj3a/7q/yvBTlfGiZu0ahKS28Vw==", null, false, "1af2a447-ef15-4716-9d13-0afc5dce0dbe", false, "LoveToAct" },
                    { 2, 0, "Sofia, Bulgaria", 28, "ce550b27-19e2-492b-a97f-37b014e8e2ad", "EMPLOYEE", "3241219", "employee@gmail.com", false, "Emlpoyee", false, "Emlpoyee", false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE", "AQAAAAEAACcQAAAAEEAqa8mr3xn/+fX8hRbGQXgJoHVYCxa3zIiSBc4as2FbCjhCt71p06mC87sdtMVX5Q==", null, false, "4cf040b8-3ea4-405d-bb33-25cb2d64399a", false, "EmlpoyeeEmlpoyee" }
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
                    { 1, "Not started" },
                    { 2, "In progress" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Oil change", 74.989999999999995 },
                    { 5, false, "Battery replacement", 199.99000000000001 },
                    { 4, false, "Pads replacement", 249.99000000000001 },
                    { 3, false, "Change a tire", 8.9900000000000002 },
                    { 2, false, "Change all tires", 24.989999999999998 },
                    { 6, false, "Computer diagnostic", 35.990000000000002 }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name", "PriceCoefficient" },
                values: new object[,]
                {
                    { 3, "Bus", 2.0 },
                    { 1, "Car", 1.0 },
                    { 2, "Motorcycle", 0.90000000000000002 },
                    { 4, "Truck", 2.5 }
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
                    { 5, 3 }
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
                    { 5, 3, "Passat", 1 },
                    { 4, 2, "HiAce H300", 3 },
                    { 3, 2, "Prius", 1 },
                    { 2, 1, "Model S", 1 },
                    { 1, 1, "Model X", 1 },
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
                values: new object[] { 1, new DateTime(2021, 5, 22, 15, 14, 15, 241, DateTimeKind.Local).AddTicks(4748), new DateTime(2021, 5, 24, 15, 14, 15, 243, DateTimeKind.Local).AddTicks(5429), 1, false, 2, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "FinishDate", "GarageId", "IsDeleted", "OrderStatusId", "VehicleId" },
                values: new object[] { 2, new DateTime(2021, 5, 23, 15, 14, 15, 243, DateTimeKind.Local).AddTicks(6009), new DateTime(2021, 5, 26, 15, 14, 15, 243, DateTimeKind.Local).AddTicks(6027), 1, false, 1, 3 });

            migrationBuilder.InsertData(
                table: "ServiceOrders",
                columns: new[] { "ServiceId", "OrderId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ServiceOrders",
                columns: new[] { "ServiceId", "OrderId" },
                values: new object[] { 2, 2 });

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
