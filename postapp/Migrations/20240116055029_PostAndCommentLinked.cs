using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace postapp.Migrations
{
    /// <inheritdoc />
    public partial class PostAndCommentLinked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16abb7f0-053e-4515-8373-8a58191cc989");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6114030-14fe-4078-a1fe-3e1445bc3f06");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d5021fe-5840-485b-ae75-0930382e6882", null, "Admin", "ADMIN" },
                    { "3ea7ef56-8084-433c-9530-3a7c076701fa", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5021fe-5840-485b-ae75-0930382e6882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea7ef56-8084-433c-9530-3a7c076701fa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16abb7f0-053e-4515-8373-8a58191cc989", null, "Admin", "ADMIN" },
                    { "b6114030-14fe-4078-a1fe-3e1445bc3f06", null, "User", "USER" }
                });
        }
    }
}
