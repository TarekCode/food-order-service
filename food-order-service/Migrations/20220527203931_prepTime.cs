using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace food_order_service.Migrations
{
    public partial class prepTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "PreparationTime",
                table: "MenuItems",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "MenuItems");
        }
    }
}
