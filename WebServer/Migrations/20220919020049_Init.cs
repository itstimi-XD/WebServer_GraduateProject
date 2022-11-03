using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NpcDb",
                columns: table => new
                {
                    NpcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpcName = table.Column<string>(nullable: true),
                    NpcMajor = table.Column<string>(nullable: true),
                    NpcPlace = table.Column<string>(nullable: true),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NpcDb", x => x.NpcId);
                });

            migrationBuilder.CreateTable(
                name: "ScriptDb",
                columns: table => new
                {
                    ScriptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScriptText = table.Column<string>(nullable: true),
                    Score = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptDb", x => x.ScriptId);
                    table.ForeignKey(
                        name: "FK_ScriptDb_NpcDb_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "NpcDb",
                        principalColumn: "NpcId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Index_Major",
                table: "NpcDb",
                column: "NpcMajor");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptDb_OwnerId",
                table: "ScriptDb",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScriptDb");

            migrationBuilder.DropTable(
                name: "NpcDb");
        }
    }
}
