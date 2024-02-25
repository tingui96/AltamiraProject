using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51e9dee4-b48e-47a6-a3ae-1e1c45ad9d1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bb70f1d-a270-4cc3-af9e-5d62b84e52f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92645984-af35-4ca7-bd15-4904224bd25f");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "51e9dee4-b48e-47a6-a3ae-1e1c45ad9d1e", null, "Artist", null },
                    { "6bb70f1d-a270-4cc3-af9e-5d62b84e52f6", null, "Viewer", null },
                    { "92645984-af35-4ca7-bd15-4904224bd25f", null, "Administrador", null }
                });
        }
    }
}
