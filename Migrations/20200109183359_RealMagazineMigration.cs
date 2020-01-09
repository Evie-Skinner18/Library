using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class RealMagazineMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasCollectibleInside",
                table: "LibraryItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "LibraryItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCollectibleInside",
                table: "LibraryItems");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "LibraryItems");
        }
    }
}
