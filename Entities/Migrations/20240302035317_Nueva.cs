using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Nueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a307940-bec7-4d4e-89f1-fa4bb6ccb35c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e218c4d-8ead-42d7-9beb-6032f67f1a62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a698efbe-9b12-450b-98d8-b18f5fa10a04");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16fab165-7984-49bd-b855-d18d28797474", null, "Artist", "ARTIST" },
                    { "50e7ad1a-305a-49b0-b305-1d31af4db0c8", null, "Administrador", "ADMINISTRADOR" },
                    { "ba53957e-51f1-4706-bbb9-a7274169440b", null, "Viewer", "VIEWER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16fab165-7984-49bd-b855-d18d28797474");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e7ad1a-305a-49b0-b305-1d31af4db0c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba53957e-51f1-4706-bbb9-a7274169440b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a307940-bec7-4d4e-89f1-fa4bb6ccb35c", null, "Viewer", "VIEWER" },
                    { "3e218c4d-8ead-42d7-9beb-6032f67f1a62", null, "Artist", "ARTIST" },
                    { "a698efbe-9b12-450b-98d8-b18f5fa10a04", null, "Administrador", "ADMINISTRADOR" }
                });
        }
    }
}
