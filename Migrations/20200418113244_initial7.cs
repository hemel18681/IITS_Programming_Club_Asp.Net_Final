using Microsoft.EntityFrameworkCore.Migrations;

namespace IITS_Programming_Club.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "change_plan",
                table: "class_info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<string>(nullable: true),
                    student_name = table.Column<string>(nullable: true),
                    codeforces_handle = table.Column<string>(nullable: true),
                    class_advance = table.Column<string>(nullable: true),
                    class_intermediate = table.Column<string>(nullable: true),
                    class_beginner = table.Column<string>(nullable: true),
                    room_advance = table.Column<string>(nullable: true),
                    room_intermediate = table.Column<string>(nullable: true),
                    room_begineer = table.Column<string>(nullable: true),
                    time_advance = table.Column<string>(nullable: true),
                    time_intermediate = table.Column<string>(nullable: true),
                    time_begineer = table.Column<string>(nullable: true),
                    change_plan_advance = table.Column<string>(nullable: true),
                    change_plan_intermediate = table.Column<string>(nullable: true),
                    change_plan_begineer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropColumn(
                name: "change_plan",
                table: "class_info");
        }
    }
}
