using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagement.Data.Migrations
{
    public partial class AddExamScheduleVenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExamDate",
                table: "ExamSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ExamVenue",
                table: "ExamSchedules",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDate",
                table: "ExamSchedules");

            migrationBuilder.DropColumn(
                name: "ExamVenue",
                table: "ExamSchedules");
        }
    }
}
