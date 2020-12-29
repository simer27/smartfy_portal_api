using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class _0000001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
