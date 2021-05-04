using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrestamos.Migrations
{
    public partial class renameColumnCodigoPin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoPink",
                table: "Clientes",
                newName: "CodigoPin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoPin",
                table: "Clientes",
                newName: "CodigoPink");
        }
    }
}
