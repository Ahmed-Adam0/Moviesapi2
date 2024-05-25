using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moviesapi2.Migrations
{
    public partial class Addmovietable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    rate = table.Column<double>(type: "float", nullable: false),
                    storeline = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    poster = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    generId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.id);
                    table.ForeignKey(
                        name: "FK_movies_gener_generId",
                        column: x => x.generId,
                        principalTable: "gener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_generId",
                table: "movies",
                column: "generId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
