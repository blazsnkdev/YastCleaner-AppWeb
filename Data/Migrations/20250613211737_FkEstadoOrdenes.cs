using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAST_CLENAER_WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class FkEstadoOrdenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_EstadoOrdenIdEstadoOrden",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "EstadoOrdenIdEstadoOrden",
                table: "Ordenes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                column: "EstadoOrdenIdEstadoOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                column: "EstadoOrdenIdEstadoOrden",
                principalTable: "EstadosOrden",
                principalColumn: "IdEstadoOrden");
        }
    }
}
