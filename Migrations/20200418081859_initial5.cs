using Microsoft.EntityFrameworkCore.Migrations;

namespace IITS_Programming_Club.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_class_info",
                table: "class_info");

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "class_info",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "key",
                table: "class_info",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_class_info",
                table: "class_info",
                column: "key");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_class_info",
                table: "class_info");

            migrationBuilder.DropColumn(
                name: "key",
                table: "class_info");

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "class_info",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_class_info",
                table: "class_info",
                column: "date");
        }
    }
}
