using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Reservado = table.Column<int>(nullable: false),
                    PrecoTotalEstoque = table.Column<double>(nullable: false),
                    PrecoTotalReservado = table.Column<double>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");
        }
    }
}
