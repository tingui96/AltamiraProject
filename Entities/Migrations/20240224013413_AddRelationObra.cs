using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "688ca622-7079-49bd-a078-0f84647216c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e8177b-97e7-4592-93b0-87ba2f46fc18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0c552a6-dd53-454a-ba1d-1fbf998c05f5");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Obras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Obras",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65880cd5-4581-44f8-a456-8496f735284c", null, "Visitor", "VISITOR" },
                    { "65e43046-228e-4836-99a5-f6b3bf6c1a1e", null, "Artist", "ARTIST" },
                    { "dc7a0b34-a152-4adb-b57c-a30db6afc6a5", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_UserId1",
                table: "Obras",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_AspNetUsers_UserId1",
                table: "Obras",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_AspNetUsers_UserId1",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_UserId1",
                table: "Obras");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Obras");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "688ca622-7079-49bd-a078-0f84647216c0", null, "Visitor", "VISITOR" },
                    { "94e8177b-97e7-4592-93b0-87ba2f46fc18", null, "Artist", "ARTIST" },
                    { "d0c552a6-dd53-454a-ba1d-1fbf998c05f5", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
