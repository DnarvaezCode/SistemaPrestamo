using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrestamos.Migrations
{
    public partial class tableComisiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comisione_Clientes_ClienteId",
                table: "Comisione");

            migrationBuilder.DropForeignKey(
                name: "FK_Comisione_Prestamos_PrestamoId",
                table: "Comisione");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comisione",
                table: "Comisione");

            migrationBuilder.RenameTable(
                name: "Comisione",
                newName: "Comisiones");

            migrationBuilder.RenameIndex(
                name: "IX_Comisione_PrestamoId",
                table: "Comisiones",
                newName: "IX_Comisiones_PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comisione_ClienteId",
                table: "Comisiones",
                newName: "IX_Comisiones_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comisiones",
                table: "Comisiones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comisiones_Clientes_ClienteId",
                table: "Comisiones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comisiones_Prestamos_PrestamoId",
                table: "Comisiones",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comisiones_Clientes_ClienteId",
                table: "Comisiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Comisiones_Prestamos_PrestamoId",
                table: "Comisiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comisiones",
                table: "Comisiones");

            migrationBuilder.RenameTable(
                name: "Comisiones",
                newName: "Comisione");

            migrationBuilder.RenameIndex(
                name: "IX_Comisiones_PrestamoId",
                table: "Comisione",
                newName: "IX_Comisione_PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comisiones_ClienteId",
                table: "Comisione",
                newName: "IX_Comisione_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comisione",
                table: "Comisione",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comisione_Clientes_ClienteId",
                table: "Comisione",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comisione_Prestamos_PrestamoId",
                table: "Comisione",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
