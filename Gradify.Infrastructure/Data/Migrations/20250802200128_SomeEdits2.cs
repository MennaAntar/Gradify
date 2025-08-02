using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SomeEdits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "RegistrationArchives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Registration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "RegistrationArchives");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Registration");
        }
    }
}
