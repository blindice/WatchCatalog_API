using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchCatalog_API.Migrations
{
    public partial class Price_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "tbl_watch",
                type: "decimal(13,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "tbl_watch",
                type: "decimal(13,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13,2)");
        }
    }
}
