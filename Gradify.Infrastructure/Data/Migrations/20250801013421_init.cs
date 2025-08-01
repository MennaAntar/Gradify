using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreditHrs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterName);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CGPA = table.Column<double>(type: "float", nullable: false),
                    NetHrs = table.Column<int>(type: "int", nullable: false),
                    CurrentPoints = table.Column<int>(type: "int", nullable: false),
                    LastCalculationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemesterCourseSettings",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SemesterName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CourseWorkValue = table.Column<double>(type: "float", nullable: false),
                    FinalValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterCourseSettings", x => new { x.CourseCode, x.SemesterName });
                    table.ForeignKey(
                        name: "FK_SemesterCourseSettings_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterCourseSettings_Semesters_SemesterName",
                        column: x => x.SemesterName,
                        principalTable: "Semesters",
                        principalColumn: "SemesterName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalMarks = table.Column<double>(type: "float", nullable: false),
                    IsAbsentFinal = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Semesters_SemesterName",
                        column: x => x.SemesterName,
                        principalTable: "Semesters",
                        principalColumn: "SemesterName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalMarks = table.Column<double>(type: "float", nullable: false),
                    IsAbsentFinal = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationArchives_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrationArchives_Semesters_SemesterName",
                        column: x => x.SemesterName,
                        principalTable: "Semesters",
                        principalColumn: "SemesterName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrationArchives_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayMarks = table.Column<double>(type: "float", nullable: false),
                    RealMarks = table.Column<double>(type: "float", nullable: false),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: false),
                    IsSame = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationID = table.Column<int>(type: "int", nullable: true),
                    RegistrationAID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_RegistrationArchives_RegistrationAID",
                        column: x => x.RegistrationAID,
                        principalTable: "RegistrationArchives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Registration_RegistrationID",
                        column: x => x.RegistrationID,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_RegistrationAID",
                table: "Exams",
                column: "RegistrationAID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_RegistrationID",
                table: "Exams",
                column: "RegistrationID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CourseCode",
                table: "Registration",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_SemesterName",
                table: "Registration",
                column: "SemesterName");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_StudentId",
                table: "Registration",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchives_CourseCode",
                table: "RegistrationArchives",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchives_SemesterName",
                table: "RegistrationArchives",
                column: "SemesterName");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationArchives_StudentId",
                table: "RegistrationArchives",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCourseSettings_SemesterName",
                table: "SemesterCourseSettings",
                column: "SemesterName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "SemesterCourseSettings");

            migrationBuilder.DropTable(
                name: "RegistrationArchives");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
