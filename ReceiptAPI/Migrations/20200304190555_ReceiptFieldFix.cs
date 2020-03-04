using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceiptAPI.Migrations
{
    public partial class ReceiptFieldFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Receipts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Receipts");
        }
    }
}
