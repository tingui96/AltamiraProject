using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06f2f818-f798-4e1f-88c2-4b5d640c7005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0712f005-198e-4d1f-abfc-2dc6d4cb781d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17bcddfb-7b53-4a6e-81ea-9382cece18c2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "06f2f818-f798-4e1f-88c2-4b5d640c7005", null, "Visitor", "VISITOR" },
                    { "0712f005-198e-4d1f-abfc-2dc6d4cb781d", null, "Artist", "ARTIST" },
                    { "17bcddfb-7b53-4a6e-81ea-9382cece18c2", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
