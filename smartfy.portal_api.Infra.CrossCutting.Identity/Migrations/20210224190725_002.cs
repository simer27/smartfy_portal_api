using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beneficio",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salario",
                table: "Funcionario",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beneficio",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Funcionario");
        }
    }
}
