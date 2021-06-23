using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagement.Data.Migrations
{
    public partial class ChangstudentidToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId1",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId1",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentCourses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId1",
                table: "StudentCourses",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId1",
                table: "StudentCourses",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
