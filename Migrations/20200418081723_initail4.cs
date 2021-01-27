using Microsoft.EntityFrameworkCore.Migrations;

namespace IITS_Programming_Club.Migrations
{
    public partial class initail4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "class_info",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "prog_of_week",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    week = table.Column<string>(nullable: false),
                    id = table.Column<string>(nullable: false),
                    isDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prog_of_week", x => x.key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prog_of_week");

            migrationBuilder.DropColumn(
                name: "isDone",
                table: "class_info");
        }
    }
}
