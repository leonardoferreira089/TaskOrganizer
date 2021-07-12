using Microsoft.EntityFrameworkCore.Migrations;

namespace CSO_LF089.Migrations
{
    public partial class IformFileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
