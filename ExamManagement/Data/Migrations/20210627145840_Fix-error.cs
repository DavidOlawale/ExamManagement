using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagement.Data.Migrations
{
    public partial class Fixerror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamScheduleEnrollments_AspNetUsers_StudentId1",
                table: "ExamScheduleEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_ExamScheduleEnrollments_StudentId1",
                table: "ExamScheduleEnrollments");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "ExamScheduleEnrollments");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "ExamScheduleEnrollments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ExamScheduleEnrollments_StudentId",
                table: "ExamScheduleEnrollments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamScheduleEnrollments_AspNetUsers_StudentId",
                table: "ExamScheduleEnrollments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamScheduleEnrollments_AspNetUsers_StudentId",
                table: "ExamScheduleEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_ExamScheduleEnrollments_StudentId",
                table: "ExamScheduleEnrollments");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "ExamScheduleEnrollments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "ExamScheduleEnrollments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamScheduleEnrollments_StudentId1",
                table: "ExamScheduleEnrollments",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamScheduleEnrollments_AspNetUsers_StudentId1",
                table: "ExamScheduleEnrollments",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
