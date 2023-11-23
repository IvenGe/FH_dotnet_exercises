using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class RemoveSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Name", "Title" },
                values: new object[] { 1, null, "Jarkko", "this is first post using db" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Name", "Title" },
                values: new object[] { 2, null, "erkki", "Yyeyyeyeyeeyeee" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Name", "Title" },
                values: new object[] { 3, null, "Kari", "heihei" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FullName", "PostId", "Timestamp", "Title" },
                values: new object[] { 1, "Database cooooool", "Jarkko", 1, new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "Database" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FullName", "PostId", "Timestamp", "Title" },
                values: new object[] { 2, "okok", "erkki", 1, new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "ok" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FullName", "PostId", "Timestamp", "Title" },
                values: new object[] { 3, "yee", "Kari", 2, new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "yearfeaee" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FullName", "PostId", "Timestamp", "Title" },
                values: new object[] { 4, "sup", "Jarkko", 3, new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "hihsadads" });
        }
    }
}
