using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_order_service.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SystemConfiguration_Key",
                table: "SystemConfiguration",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemConfiguration_Key",
                table: "SystemConfiguration");
        }
    }
}
