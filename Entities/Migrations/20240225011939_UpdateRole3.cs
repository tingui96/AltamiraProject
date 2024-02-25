using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRole3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b12f85e-5b6a-4810-befe-0ad1d0b3e190");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a82af65e-897a-4d56-9f58-ccb1ef3144c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd82a766-df1c-4812-9890-a5607bbf90fd");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1b12f85e-5b6a-4810-befe-0ad1d0b3e190", null, "Viewer", "VIEWER" },
                    { "a82af65e-897a-4d56-9f58-ccb1ef3144c8", null, "ARTIST", null },
                    { "cd82a766-df1c-4812-9890-a5607bbf90fd", null, "ADMINISTRADOR", null }
                });
        }
    }
}
