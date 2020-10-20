using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickMoviePicks.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "124e3053-cee8-4646-8b2a-f7a3d233a2d8", "a27e8576-c5d2-43b2-9c5f-aa8534d26754", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "124e3053-cee8-4646-8b2a-f7a3d233a2d8", "a27e8576-c5d2-43b2-9c5f-aa8534d26754" });
        }
    }
}
