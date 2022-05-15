using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class CriandoRoleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "6b416ccb-e2a4-45dd-a156-f04437bafd29");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "1685c142-8656-4836-82f5-fce703690eff", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9169f25f-6ac4-47bc-8f93-5040915efd89", "AQAAAAEAACcQAAAAEOTA63eMvyNPoqxhoAJxGXjYSV9hD0hfjvsO42dezVyz1D3v6IpQnMxNjwrpQ0WMJA==", "bfa38a98-8144-4b26-9c3b-175d4a589d23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "1be2e5bf-b4eb-404b-88eb-cae8a624e1f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae35b732-1895-4f58-801a-eadb60d00bae", "AQAAAAEAACcQAAAAEFCgywyGEmzNwU+6o3wHt0VjIAIfr8XPuJDPAMm+iFc86wV7W9qlguxYwyAshkR2UA==", "d932d368-74ad-4462-88f3-def3ae7a44df" });
        }
    }
}
