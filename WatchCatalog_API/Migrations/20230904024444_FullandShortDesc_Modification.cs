using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchCatalog_API.Migrations
{
    public partial class FullandShortDesc_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Short_description",
                table: "tbl_watch",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Full_Description",
                table: "tbl_watch",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Short_description",
                table: "tbl_watch",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Full_Description",
                table: "tbl_watch",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);
        }
    }
}
