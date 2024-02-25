using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65880cd5-4581-44f8-a456-8496f735284c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65e43046-228e-4836-99a5-f6b3bf6c1a1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc7a0b34-a152-4adb-b57c-a30db6afc6a5");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4049313d-7274-4fab-b0bf-6bc8fd2fef86", null, "Administrator", "ADMINISTRATOR" },
                    { "8d507a1a-6b05-44fc-a8f2-ad7370b0ef03", null, "Visitor", "VISITOR" },
                    { "cf1be5d1-b1ba-4138-ba04-b635afb8c3b0", null, "Artist", "ARTIST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4049313d-7274-4fab-b0bf-6bc8fd2fef86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d507a1a-6b05-44fc-a8f2-ad7370b0ef03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf1be5d1-b1ba-4138-ba04-b635afb8c3b0");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65880cd5-4581-44f8-a456-8496f735284c", null, "Visitor", "VISITOR" },
                    { "65e43046-228e-4836-99a5-f6b3bf6c1a1e", null, "Artist", "ARTIST" },
                    { "dc7a0b34-a152-4adb-b57c-a30db6afc6a5", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
