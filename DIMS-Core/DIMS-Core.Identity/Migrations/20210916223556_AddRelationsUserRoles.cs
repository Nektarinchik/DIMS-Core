using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS_Core.Identity.Migrations
{
    public partial class AddRelationsUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f6d6ee09-602d-439c-a2e1-7fd04399c46d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "156f9574-cecd-416f-89e3-b7b1d4d13960");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c2ff1daf-ff50-4dcc-973a-11e25b1fbda4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "1fa93b53-d6c1-4e2a-acd3-9fecc8d6f9d3", "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEGgk7/rQE8Px8QhEFy8EgMLp+nvqXE/QgwLiXF6iBGDQdhZiQU0xwEJ37+teH+KiaQ==", null, false, "YNRCWJ3ODXVDWQIR3UCA4MHNLWH424ZS", false, "admin@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "425b0a6a-71aa-4523-b6bb-edc6a8b9cddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e7c1ba3e-771d-4ba2-9620-4a58c1ee7da6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e8546d82-8f96-4fad-8f6e-e176087ed111");
        }
    }
}
