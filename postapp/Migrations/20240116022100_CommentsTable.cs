using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace postapp.Migrations
{
    /// <inheritdoc />
    public partial class CommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf8452e6-de52-444b-80ce-7eca7973055c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f90caa2c-4497-4871-9924-10fe988d3666");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4da1971e-5099-483f-9fde-2374ad38ef49", null, "Admin", "ADMIN" },
                    { "61ea9349-ea8d-4eef-ae5f-8fe5e251ed50", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da1971e-5099-483f-9fde-2374ad38ef49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61ea9349-ea8d-4eef-ae5f-8fe5e251ed50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf8452e6-de52-444b-80ce-7eca7973055c", null, "Admin", "ADMIN" },
                    { "f90caa2c-4497-4871-9924-10fe988d3666", null, "User", "USER" }
                });
        }
    }
}
