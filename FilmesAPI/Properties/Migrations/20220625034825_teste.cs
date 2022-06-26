using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "FILME",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    diretor = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    genero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    duracao = table.Column<int>(type: "integer", nullable: false),
                    imdb = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILME", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SITE",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    filmeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SITE_FILME_filmeId",
                        column: x => x.filmeId,
                        principalSchema: "public",
                        principalTable: "FILME",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SITE_filmeId",
                schema: "public",
                table: "SITE",
                column: "filmeId");

            migrationBuilder.CreateIndex(
                name: "IX_SITE_url",
                schema: "public",
                table: "SITE",
                column: "url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SITE",
                schema: "public");

            migrationBuilder.DropTable(
                name: "FILME",
                schema: "public");
        }
    }
}
