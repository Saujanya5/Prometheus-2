using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prometheus_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<decimal>(type: "numeric(5,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Homework",
                columns: table => new
                {
                    HomeWorkID = table.Column<decimal>(type: "numeric(5,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Deadline = table.Column<DateTime>(type: "date", nullable: true),
                    ReqTime = table.Column<int>(type: "int", nullable: true),
                    LongDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homework", x => x.HomeWorkID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<decimal>(type: "numeric(5,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    City = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MobileNo = table.Column<decimal>(type: "numeric(10,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<decimal>(type: "numeric(5,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    City = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MobileNo = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    HomeWorkID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    TeacherID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    CourseID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assignme__1C8A785DD0D14792", x => new { x.HomeWorkID, x.TeacherID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Assignmen__Cours__46E78A0C",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Assignmen__HomeW__47DBAE45",
                        column: x => x.HomeWorkID,
                        principalTable: "Homework",
                        principalColumn: "HomeWorkID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    CourseID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    StudentID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__5E57FD61E27A644E", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Enrollmen__Cours__412EB0B6",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Enrollmen__Stude__4222D4EF",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    TeacherID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    CourseID = table.Column<decimal>(type: "numeric(5,0)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teaches__81608E5CD8B8E599", x => new { x.TeacherID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Teaches__CourseI__3E52440B",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Teaches__Teacher__3D5E1FD2",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CourseID",
                table: "Assignment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseID",
                table: "Teaches",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.DropTable(
                name: "Homework");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
