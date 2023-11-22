using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class UpdateCommentConstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Timestamp", "Title" },
                values: new object[] { "Jarkko", new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "Database" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "Timestamp", "Title" },
                values: new object[] { "erkki", new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "ok" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FullName", "Timestamp", "Title" },
                values: new object[] { "Kari", new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "yearfeaee" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FullName", "Timestamp", "Title" },
                values: new object[] { "Jarkko", new DateTime(2023, 11, 22, 18, 5, 48, 967, DateTimeKind.Utc).AddTicks(7600), "hihsadads" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Comments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "Text");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mike");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Tim");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Al");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "user");
        }
    }
}
