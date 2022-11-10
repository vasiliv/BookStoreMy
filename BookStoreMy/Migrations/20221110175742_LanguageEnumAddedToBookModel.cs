using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreMy.Migrations
{
    public partial class LanguageEnumAddedToBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageEnum",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageEnum",
                table: "Books");
        }
    }
}
