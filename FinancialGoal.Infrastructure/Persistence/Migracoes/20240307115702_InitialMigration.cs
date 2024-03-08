using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialGoal.Infrastructure.Persistence.Migracoes
{
    /// <inheritdoc />
    public partial class InitialMigration : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetivoFinanceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeAlvo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Prazo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusObj = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaDeletado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivoFinanceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaDeletado = table.Column<bool>(type: "bit", nullable: true),
                    IdObjetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_ObjetivoFinanceiro_IdObjetivo",
                        column: x => x.IdObjetivo,
                        principalTable: "ObjetivoFinanceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_IdObjetivo",
                table: "Transacoes",
                column: "IdObjetivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "ObjetivoFinanceiro");
        }
    }
}
