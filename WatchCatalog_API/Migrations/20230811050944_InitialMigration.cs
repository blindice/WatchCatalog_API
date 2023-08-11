using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchCatalog_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_watch",
                columns: table => new
                {
                    WatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WatchName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Short_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Full_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Caliber = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Diameter = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Thickness = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Jewel = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Case = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Strap = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_watc__3BA3DAA3319953BA", x => x.WatchId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_watch");
        }
    }
}
