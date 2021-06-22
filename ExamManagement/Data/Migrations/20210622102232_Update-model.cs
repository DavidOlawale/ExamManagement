using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagement.Data.Migrations
{
    public partial class Updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Courses_SubjectCoursesId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectCoursesId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects");

            migrationBuilder.DropColumn(
                name: "SubjectCoursesId",
                table: "Subjects");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "SubjectCoursesId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectCoursesId",
                table: "Subjects",
                column: "SubjectCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Courses_SubjectCoursesId",
                table: "Subjects",
                column: "SubjectCoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
