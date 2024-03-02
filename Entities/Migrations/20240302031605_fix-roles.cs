using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class fixroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6de4ea4c-8a22-48e2-82eb-c6ff33616b0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75b031ee-58f3-421c-9690-931ff7626cfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89909dc5-3ff7-4659-a657-1c7a73b2a478");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6de4ea4c-8a22-48e2-82eb-c6ff33616b0f", null, "Artist", "ARTIST" },
                    { "75b031ee-58f3-421c-9690-931ff7626cfc", null, "Viewer", "VIEWER" },
                    { "89909dc5-3ff7-4659-a657-1c7a73b2a478", null, "ADMINISTRADOR", "ADMINISTRADOR" }
                });
        }
    }
}
