using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace postapp.Migrations
{
    /// <inheritdoc />
    public partial class ondelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_post_PostId",
                table: "comment");

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
                    { "8a13e599-b5af-454d-b335-5aaf197a4814", null, "Admin", "ADMIN" },
                    { "dc975c7a-158e-4b97-8799-2c81ed6d39ca", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PostId",
                table: "comment",
                column: "PostId",
                principalTable: "post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_post_PostId",
                table: "comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a13e599-b5af-454d-b335-5aaf197a4814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc975c7a-158e-4b97-8799-2c81ed6d39ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d5021fe-5840-485b-ae75-0930382e6882", null, "Admin", "ADMIN" },
                    { "3ea7ef56-8084-433c-9530-3a7c076701fa", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PostId",
                table: "comment",
                column: "PostId",
                principalTable: "post",
                principalColumn: "Id");
        }
    }
}
