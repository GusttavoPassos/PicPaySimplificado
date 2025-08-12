using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPaySimplificado.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPFCNPJ = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Saldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Limite = table.Column<decimal>(type: "TEXT", nullable: false),
                    UsuarioTypeEntityType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    IdTransferencia = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdPagador = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdRecebedor = table.Column<Guid>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipoTransacao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.IdTransferencia);
                    table.ForeignKey(
                        name: "FK_Transacoes_Carteiras_IdPagador",
                        column: x => x.IdPagador,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacoes_Carteiras_IdRecebedor",
                        column: x => x.IdRecebedor,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_IdPagador",
                table: "Transacoes",
                column: "IdPagador");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_IdRecebedor",
                table: "Transacoes",
                column: "IdRecebedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Carteiras");
        }
    }
}
