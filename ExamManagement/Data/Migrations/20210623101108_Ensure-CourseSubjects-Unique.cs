using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagement.Data.Migrations
{
    public partial class EnsureCourseSubjectsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseId_SubjectId",
                table: "CourseSubjects",
                columns: new[] { "CourseId", "SubjectId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseSubjects_CourseId_SubjectId",
                table: "CourseSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects",
                column: "CourseId");
        }
    }
}
