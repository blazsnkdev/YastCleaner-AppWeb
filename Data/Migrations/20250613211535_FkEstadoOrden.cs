using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAST_CLENAER_WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class FkEstadoOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_ClienteIdCliente",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_ClienteIdCliente",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_IdCliente",
                table: "Ordenes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_IdEstadoOrden",
                table: "Ordenes",
                column: "IdEstadoOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_IdCliente",
                table: "Ordenes",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                column: "EstadoOrdenIdEstadoOrden",
                principalTable: "EstadosOrden",
                principalColumn: "IdEstadoOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_EstadosOrden_IdEstadoOrden",
                table: "Ordenes",
                column: "IdEstadoOrden",
                principalTable: "EstadosOrden",
                principalColumn: "IdEstadoOrden",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_IdCliente",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_EstadosOrden_IdEstadoOrden",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_IdCliente",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_IdEstadoOrden",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteIdCliente",
                table: "Ordenes",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_ClienteIdCliente",
                table: "Ordenes",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                column: "EstadoOrdenIdEstadoOrden",
                principalTable: "EstadosOrden",
                principalColumn: "IdEstadoOrden",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
