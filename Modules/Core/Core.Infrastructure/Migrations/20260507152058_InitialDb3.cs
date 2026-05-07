using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.RenameTable(
                name: "Outboxes",
                newName: "Outboxes",
                newSchema: "Core");

            migrationBuilder.RenameTable(
                name: "Features",
                newName: "Features",
                newSchema: "Core");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Devices",
                newSchema: "Core");

            migrationBuilder.RenameTable(
                name: "CardFormats",
                newName: "CardFormats",
                newSchema: "Core");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "Core",
                table: "Devices",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Outboxes",
                schema: "Core",
                newName: "Outboxes");

            migrationBuilder.RenameTable(
                name: "Features",
                schema: "Core",
                newName: "Features");

            migrationBuilder.RenameTable(
                name: "Devices",
                schema: "Core",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "CardFormats",
                schema: "Core",
                newName: "CardFormats");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Devices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
