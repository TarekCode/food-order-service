using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_order_service.Migrations
{
    public partial class requireAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModifications_ItemOptions_ItemOptionId",
                table: "ItemModifications");

            migrationBuilder.AlterColumn<int>(
                name: "ItemOptionId",
                table: "ItemModifications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModifications_ItemOptions_ItemOptionId",
                table: "ItemModifications",
                column: "ItemOptionId",
                principalTable: "ItemOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModifications_ItemOptions_ItemOptionId",
                table: "ItemModifications");

            migrationBuilder.AlterColumn<int>(
                name: "ItemOptionId",
                table: "ItemModifications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModifications_ItemOptions_ItemOptionId",
                table: "ItemModifications",
                column: "ItemOptionId",
                principalTable: "ItemOptions",
                principalColumn: "Id");
        }
    }
}
