using Microsoft.EntityFrameworkCore.Migrations;

namespace IITS_Programming_Club.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codefoeces_handle",
                table: "student_info");

            migrationBuilder.AddColumn<string>(
                name: "codeforces_handle",
                table: "student_info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "date_advance",
                table: "Home",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "date_begineer",
                table: "Home",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "date_intermediate",
                table: "Home",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codeforces_handle",
                table: "student_info");

            migrationBuilder.DropColumn(
                name: "date_advance",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "date_begineer",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "date_intermediate",
                table: "Home");

            migrationBuilder.AddColumn<string>(
                name: "codefoeces_handle",
                table: "student_info",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
