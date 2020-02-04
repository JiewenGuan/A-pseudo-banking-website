using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NwbaExampleWithLogin.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BadAttempt",
                table: "Logins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastBadLogin",
                table: "Logins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadAttempt",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "lastBadLogin",
                table: "Logins");
        }
    }
}
