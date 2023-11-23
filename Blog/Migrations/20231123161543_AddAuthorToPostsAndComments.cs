using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class AddAuthorToPostsAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Comments",
                newName: "AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Comments",
                newName: "FullName");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
