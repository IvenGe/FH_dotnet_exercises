using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class AddedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "this is first post using db", "Jarkko" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Yyeyyeyeyeeyeee", "erkki" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "heihei", "Kari" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Name", "PostId", "Text" },
                values: new object[] { 1, "Mike", 1, "Database cooooool" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Name", "PostId", "Text" },
                values: new object[] { 2, "Tim", 1, "okok" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Name", "PostId", "Text" },
                values: new object[] { 3, "Al", 2, "yee" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Name", "PostId", "Text" },
                values: new object[] { 4, "user", 3, "sup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
