using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServer.Migrations
{
    public partial class scoreInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "ScriptDb",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "ScriptDb",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
