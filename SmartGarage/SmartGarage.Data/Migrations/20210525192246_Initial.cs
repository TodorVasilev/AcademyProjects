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
                    { 3, "759a21e0-e531-4b37-a33c-eddd57d092af", "Customer", "CUSTOMER" },
                    { 2, "1b777d12-9255-4b59-ad54-3f163c61e0e8", "Employee", "EMPLOYEE" },
                    { 1, "ec453011-4fd1-4918-bac0-b5d05969b4fa", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "CurrentRole", "DrivingLicenseNumber", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Sofia, Bulgaria", 37, "d6aeb78b-9107-4429-8930-0aacf6e7e4e7", "ADMIN", "93302193", "admin@gmail.com", false, "Admin", false, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMINADMIN", "AQAAAAEAACcQAAAAEEhiJKHpg7F95HBuZ+bXGR67IKD1DRWVRYuxMCFJ5czHpY9Km0SyNoZcO3Cl+g1rjw==", null, false, "f5835126-3f27-44d5-b158-6ffa6f11eb8b", false, "AdminAdmin" },
                    { 3, 0, "Sofia, Bulgaria", 28, "aa2043c7-bc35-4a50-b535-83c5a7bbe324", "CUSTOMER", "13302343", "firstcustomer@gmail.com", false, "First", false, "Customer", false, null, "FIRSTCUSTOMER@GMAIL.COM", "THEVERYFIRSTCUSTOMER", "AQAAAAEAACcQAAAAEHRI69pmxHDiH9vngX9zFn2KCoslnW93nbQe+TrfMIDzBuOMpzEWH6TfytNIAa7Rlg==", null, false, "c2f51e0f-4574-43b1-bcf9-889197257c76", false, "TheVeryFirstCustomer" },
                    { 4, 0, "Burgas, Bulgaria", 40, "8c48982d-c246-41c1-b785-6d21bdf90993", "CUSTOMER", "73322193", "ivangeorgiev14@gmail.com", false, "Ivan", false, "Georgiev", false, null, "IVANGEORGIEV14@GMAIL.COM", "IVANG", "AQAAAAEAACcQAAAAEIfIH8xTFTfrY3zF+BODJU4IazEVP5emqHVnj3Bzs99GEr6TVAw5F8EEA46WZgeOfw==", null, false, "c8a68a01-2336-4f36-99f3-5e91aa54f720", false, "IvanG" },
                    { 5, 0, "Blagoevgrad, Bulgaria", 22, "51005079-0250-492c-aa8e-333fd9566056", "CUSTOMER", "91304433", "californication@gmail.com", false, "Todor", false, "Kolev", false, null, "CALIFORNICATION@GMAIL.COM", "LOVETOACT", "AQAAAAEAACcQAAAAEOW1lbNbpG60+jmPtI4Rm0aRA4G5LW3EgWmHRYvohRCeNexdk8IRUDO+niCHj+DJ3A==", null, false, "c3fe896d-0dc1-41ad-8c2d-5446a5b18d1f", false, "LoveToAct" },
                    { 2, 0, "Sofia, Bulgaria", 28, "276494b5-1e2d-496b-8594-a3ea5d3920f6", "EMPLOYEE", "3241219", "petar@test.com", false, "Petar", false, "Petrov", false, null, "PETAR@TEST.COM", "PETARPETROV", "AQAAAAEAACcQAAAAEPFutue474zMANwbprYqBKxxnyRuISw880OvxxbDYAUa+mwcoGiRp84b0IJDAkATYg==", null, false, "f43827df-8045-40ab-8e56-aeaf99c7e750", false, "PetarPetrov" }
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
                    { 1, false, "Oil change", 74.99m },
                    { 5, false, "Battery replacement", 199.99m },
                    { 4, false, "Pads replacement", 249.99m },
                    { 3, false, "Change a tire", 8.99m },
                    { 2, false, "Change all tires", 24.99m },
                    { 6, false, "Computer diagnostic", 35.99m }
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
                values: new object[] { 1, new DateTime(2021, 5, 26, 22, 22, 46, 343, DateTimeKind.Local).AddTicks(2674), new DateTime(2021, 5, 28, 22, 22, 46, 345, DateTimeKind.Local).AddTicks(3062), 1, false, 2, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "FinishDate", "GarageId", "IsDeleted", "OrderStatusId", "VehicleId" },
                values: new object[] { 2, new DateTime(2021, 5, 27, 22, 22, 46, 345, DateTimeKind.Local).AddTicks(3488), new DateTime(2021, 5, 30, 22, 22, 46, 345, DateTimeKind.Local).AddTicks(3503), 1, false, 1, 3 });

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
