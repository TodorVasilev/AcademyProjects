using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarage.Data.Migrations
{
    public partial class User_Role_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ec739475-f982-455b-a160-9e14d1dbc6d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f61877bc-808f-49e6-a458-86f71cf2f029");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1b3d1451-342a-44fe-ad3c-6a4f2f0cacf7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88bb364f-8e04-4615-a21d-4124f60936da", "AQAAAAEAACcQAAAAEPZo+eSzJs/N1iMpz16RADYg3/emXvu2pIEQgKyLF6Q9U8V2+ZemDUrZKvULiW7rQA==", "7424827b-9bc9-462c-a665-f710252ecd5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e08c2c56-6fc9-498a-a36f-dd7c827ac4d9", "AQAAAAEAACcQAAAAEGNfRWinrlTSd4yTP8QQhySgGQUgqDxrUATCzE2xIp97LqMXvoJeO+1906/JLkJfeA==", "87d5fb84-eebe-4008-8f63-d320056f0c72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6826c7ff-07cf-4b00-8fa9-fb71205ae927", "AQAAAAEAACcQAAAAEIrKQvoQup8On5aYvrRzUNSPxxXF2lox+Hdj71LI053CNv1Z3AcW32A2sBFLqvIlBQ==", "9f73e5ab-0f2d-4373-9fd1-c551b5e1038f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f81ef981-e41b-44ff-a8f2-5cc85bb2255e", "44c16d4f-3e4e-448a-bf5a-d1edbb9b980e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a29b4c36-94ca-4563-863b-869b409b6e71", "206a943b-a98f-4b3e-b5dd-d16c443cc913" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "00b0b5d6-fa3c-4bdc-aca7-7ba0b83d8300");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7193d733-f1e6-44d0-89cc-0c304e0e0380");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6f3b3d46-8cf7-45e5-99ab-3d60b971ccde");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9065a6d1-2b0b-4c34-a175-3ddafa65cfc6", "AQAAAAEAACcQAAAAEAZf9Vkty+fIxxo5+NaIOMS6uGgmQinJ2HZp4D8XRdYX5G1+2slKapc3VQkK5LiFdg==", "b4c39172-fb0e-4260-9650-0916f98ec382" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a32c987-ffbf-4a18-9d31-94f515a6e8d2", "AQAAAAEAACcQAAAAEONPjfmn4sI/atBFLzc0mXrwDebPRhctsRbtPc9S4TfDqnhLg8SLu6djXq0AdXrqlg==", "7ea20ec6-a31b-4fa2-94ba-433febfde413" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d8c5257-1ecd-4847-9216-734120659131", "AQAAAAEAACcQAAAAEIp9JifHqX0paG0UC40ToPIS6Rd5QB0azvJseTt0BkncngbXB1QNm/7q3MV8ooOCMw==", "e797fc6a-3134-410f-b6ec-fef41502fa33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4ea336d4-da9f-402c-a4af-2bc16ae1c8cc", "84fce666-ac29-4357-a9b5-3040da0c6549" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ef55ac9-593e-4636-9046-6b439b09c333", "7abe6e08-0fd8-43b4-b917-d0a5a645130e" });
        }
    }
}
