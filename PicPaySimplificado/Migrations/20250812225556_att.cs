using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPaySimplificado.Migrations
{
    /// <inheritdoc />
    public partial class att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransacaoStatus",
                table: "Transacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransacaoStatus",
                table: "Transacoes");
        }
    }
}
