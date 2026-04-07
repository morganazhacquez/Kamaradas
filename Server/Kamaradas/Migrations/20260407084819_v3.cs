using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kamaradas.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_1",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_2",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_3",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_4",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_5",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_6",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dad_7",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LicenceID",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreToWithdraw",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_3",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_4",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_5",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_6",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Dad_7",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LicenceID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ScoreToWithdraw",
                table: "Users");
        }
    }
}
