using Microsoft.EntityFrameworkCore.Migrations;

namespace CSO_LF089.Migrations
{
    public partial class ImagepushTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "books");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "books",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "books");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
