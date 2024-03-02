using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class updateall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "144fa421-8872-4585-b0be-8cb55427c34b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d48e8f6-79a8-47ed-b7a7-cb8afc5f7300");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d27a4922-7dba-4278-83e6-c1473a16214a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "144fa421-8872-4585-b0be-8cb55427c34b", null, "Administrador", "ADMINISTRADOR" },
                    { "6d48e8f6-79a8-47ed-b7a7-cb8afc5f7300", null, "Artist", "ARTIST" },
                    { "d27a4922-7dba-4278-83e6-c1473a16214a", null, "Viewer", "VIEWER" }
                });
        }
    }
}
