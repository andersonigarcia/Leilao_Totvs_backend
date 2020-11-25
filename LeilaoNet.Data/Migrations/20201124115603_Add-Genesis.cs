using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeilaoNet.Data.Migrations
{
    public partial class AddGenesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(400)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(20)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leilao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CascadeMode = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Responsavel = table.Column<string>(nullable: true),
                    Abertura = table.Column<DateTime>(nullable: false),
                    Encerramento = table.Column<DateTime>(nullable: false),
                    LanceMinimo = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leilao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leilao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Usado = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    LeilaoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Leilao_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leilao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leilao_UsuarioId",
                table: "Leilao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_LeilaoId",
                table: "Produto",
                column: "LeilaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Leilao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
