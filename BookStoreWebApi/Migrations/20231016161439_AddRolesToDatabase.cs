using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38dbb5e3-76a6-4110-9aee-c8e2e63b5744", "ba4b6fb3-7437-4706-bfab-82fc3adf9489", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7babc514-ef3a-4015-90e3-96fc6f921e66", "6c0a53c2-873a-47d6-9d6b-55d58966f8e9", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ead82646-2be8-482c-bd9f-57588c6e696c", "031a7b20-e59e-4552-9c78-999c589847e4", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38dbb5e3-76a6-4110-9aee-c8e2e63b5744");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7babc514-ef3a-4015-90e3-96fc6f921e66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ead82646-2be8-482c-bd9f-57588c6e696c");
        }
    }
}
