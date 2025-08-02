using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SmallEdits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Semesters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "SemesterCourseSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "State",
                table: "SemesterCourseSettings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Courses");
        }
    }
}
