using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagement.Data.Migrations
{
    public partial class UpdateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastName",
                table: "AspNetUsers",
                type: "int",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "int",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);
        }
    }
}
