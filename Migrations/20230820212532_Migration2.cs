using Microsoft.EntityFrameworkCore.Migrations;

namespace VoorraadSysteem.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7b1a08c-63a7-45cd-9f00-4a42189cfab4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec229e9d-bf72-4d1f-8baa-9f814b3d0416");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ba3539f-d5ef-42c4-8257-88380f2bde86", "1418aa34-f9ac-4b84-93d3-eb93d5d8d220", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5acefaf2-48f4-47eb-9ac2-471cca7c9ba7", "63a4c58c-5acf-4bce-a30e-6d286023e7c0", "Gebruiker", "GEBRUIKER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5acefaf2-48f4-47eb-9ac2-471cca7c9ba7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ba3539f-d5ef-42c4-8257-88380f2bde86");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec229e9d-bf72-4d1f-8baa-9f814b3d0416", "b26e6f2f-c82c-4cf3-a4fa-6c23629cff81", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7b1a08c-63a7-45cd-9f00-4a42189cfab4", "9a05b398-26f8-4f4c-baae-cda3bcac4f74", "Gebruiker", "GEBRUIKER" });
        }
    }
}
