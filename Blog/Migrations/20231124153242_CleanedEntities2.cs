using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class CleanedEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "TEXT",
                nullable: true);
        }
    }
}
