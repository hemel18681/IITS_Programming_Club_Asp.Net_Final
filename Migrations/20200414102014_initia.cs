using Microsoft.EntityFrameworkCore.Migrations;

namespace IITS_Programming_Club.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_info",
                columns: table => new
                {
                    admin_id = table.Column<string>(nullable: false),
                    admin_name = table.Column<string>(nullable: true),
                    admin_pass = table.Column<string>(nullable: false),
                    admin_phone = table.Column<string>(nullable: true),
                    admin_mail = table.Column<string>(nullable: true),
                    admin_address = table.Column<string>(nullable: true),
                    active_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_info", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "class_info",
                columns: table => new
                {
                    date = table.Column<string>(nullable: false),
                    group = table.Column<string>(nullable: false),
                    room_no = table.Column<string>(nullable: false),
                    time = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_info", x => x.date);
                });

            migrationBuilder.CreateTable(
                name: "complain_info",
                columns: table => new
                {
                    student_id = table.Column<string>(nullable: false),
                    message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complain_info", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "event_info",
                columns: table => new
                {
                    event_id = table.Column<string>(nullable: false),
                    event_name = table.Column<string>(nullable: false),
                    event_link = table.Column<string>(nullable: false),
                    event_for = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    winner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_info", x => x.event_id);
                });

            migrationBuilder.CreateTable(
                name: "notice",
                columns: table => new
                {
                    notice_id = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    notice = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notice", x => x.notice_id);
                });

            migrationBuilder.CreateTable(
                name: "student_info",
                columns: table => new
                {
                    student_id = table.Column<string>(nullable: false),
                    student_name = table.Column<string>(nullable: true),
                    student_pass = table.Column<string>(nullable: false),
                    student_division = table.Column<string>(nullable: false),
                    student_status = table.Column<string>(nullable: false),
                    codefoeces_handle = table.Column<string>(nullable: true),
                    codechef_handle = table.Column<string>(nullable: true),
                    vjudge_handle = table.Column<string>(nullable: true),
                    atcoder_handle = table.Column<string>(nullable: true),
                    hackerrank_handle = table.Column<string>(nullable: true),
                    active_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_info", x => x.student_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_info");

            migrationBuilder.DropTable(
                name: "class_info");

            migrationBuilder.DropTable(
                name: "complain_info");

            migrationBuilder.DropTable(
                name: "event_info");

            migrationBuilder.DropTable(
                name: "notice");

            migrationBuilder.DropTable(
                name: "student_info");
        }
    }
}
