using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotellistingApi.Migrations
{
    public partial class AddedDefultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "728412a2-6697-4568-babf-f702948f760f", "5e848e79-ecf5-4051-b139-dc345515e537", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9c51f18-c382-48c1-bd92-755aa02709a3", "e23e2e74-b75b-4acc-be8c-cfe12765eddb", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728412a2-6697-4568-babf-f702948f760f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9c51f18-c382-48c1-bd92-755aa02709a3");
        }
    }
}
