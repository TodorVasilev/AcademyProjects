using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarage.Data.Migrations
{
    public partial class User_Role_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

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
                value: "93f6f1f4-2025-4066-9b6d-c10b290ec029");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "44a23d5a-638d-4a27-9439-6590b195e79d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4de66319-9dda-432a-a435-c1bb7415ad88");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09d72031-2fe4-4aef-90a6-0737f86eedb1", "AQAAAAEAACcQAAAAEGNC9W+CAlpPM/NaF+fKPiJctoYYwEvsxEaPa8D51MnOBWk64MPsRM/B+F0aTl1B9Q==", "4dbe739b-4f57-4545-bbe7-fb73caa18b5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "593f837d-5d74-4cec-a2a4-b3497879c3c3", "AQAAAAEAACcQAAAAEPzMYY3wGKvXBGu4aMCdAVA3aZ0DRo0FIIv1EXjUkQhLxdJWMzTpis+NWA6+S57xTw==", "80a1695a-27b1-4788-bf17-7681a5efd4e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbd66391-635f-4d20-ab82-50bf85c9404e", "AQAAAAEAACcQAAAAEEbKj+6t7ttJ4ST5xiw2iniKlXiCSYJVVHd8Rh+cOXE/XVDwFTJ/2T0jz9uyJk8Spg==", "5616aaaf-d977-40de-a502-26902eb82a8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5daae3df-70ef-49e7-b903-737c6b3a0672", "AQAAAAEAACcQAAAAEOA47PC+o89azlQ9FXgJr4yUwB+2hJBAUjTI4EjoCdQU6NivsnpblGYHaNKc4Do4wA==", "ae984ab3-ef9a-4a5e-9b75-826bcebbac91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adca7f5c-0062-47d1-a982-9e35f2b9df77", "AQAAAAEAACcQAAAAEORTanZ1jyKXDCvsO7vWFfnBY8KsPpyRYyiXJ1/5rH2brg0YptS0/w+TXvacy64+Bw==", "563dd730-f0a8-4a34-96ff-f7a014699489" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ea336d4-da9f-402c-a4af-2bc16ae1c8cc", null, "84fce666-ac29-4357-a9b5-3040da0c6549" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ef55ac9-593e-4636-9046-6b439b09c333", null, "7abe6e08-0fd8-43b4-b917-d0a5a645130e" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);
        }
    }
}
