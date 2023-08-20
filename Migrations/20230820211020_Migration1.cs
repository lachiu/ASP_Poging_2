using Microsoft.EntityFrameworkCore.Migrations;

namespace VoorraadSysteem.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf6341f1-d67c-43ca-bd21-c40e87d66238");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c81f5906-f6d7-4328-8849-842c3bdcc152");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Products",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Locations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c81f5906-f6d7-4328-8849-842c3bdcc152", "84e53e62-aa4a-4e52-bafb-99a99ecc2308", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf6341f1-d67c-43ca-bd21-c40e87d66238", "3445b310-33fd-4bb6-b300-a0c2372bd7da", "Gebruiker", null });
        }
    }
}
