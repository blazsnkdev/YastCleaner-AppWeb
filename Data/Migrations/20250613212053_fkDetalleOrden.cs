using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAST_CLENAER_WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class fkDetalleOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenes_Ordenes_OrdenIdOrden",
                table: "DetalleOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenes_Prendas_PrendaIdPrenda",
                table: "DetalleOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenes_TipoServicios_TipoServicioIdTipoServicio",
                table: "DetalleOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenes_OrdenIdOrden",
                table: "DetalleOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenes_PrendaIdPrenda",
                table: "DetalleOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenes_TipoServicioIdTipoServicio",
                table: "DetalleOrdenes");

            migrationBuilder.DropColumn(
                name: "OrdenIdOrden",
                table: "DetalleOrdenes");

            migrationBuilder.DropColumn(
                name: "PrendaIdPrenda",
                table: "DetalleOrdenes");

            migrationBuilder.DropColumn(
                name: "TipoServicioIdTipoServicio",
                table: "DetalleOrdenes");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_IdOrden",
                table: "DetalleOrdenes",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_IdPrenda",
                table: "DetalleOrdenes",
                column: "IdPrenda");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_IdTipoServicio",
                table: "DetalleOrdenes",
                column: "IdTipoServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenes_Ordenes_IdOrden",
                table: "DetalleOrdenes",
                column: "IdOrden",
                principalTable: "Ordenes",
                principalColumn: "IdOrden",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenes_Prendas_IdPrenda",
                table: "DetalleOrdenes",
                column: "IdPrenda",
                principalTable: "Prendas",
                principalColumn: "IdPrenda",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenes_TipoServicios_IdTipoServicio",
                table: "DetalleOrdenes",
                column: "IdTipoServicio",
                principalTable: "TipoServicios",
                principalColumn: "IdTipoServicio",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenes_Ordenes_IdOrden",
                table: "DetalleOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenes_Prendas_IdPrenda",
                table: "DetalleOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenes_TipoServicios_IdTipoServicio",
                table: "DetalleOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenes_IdOrden",
                table: "DetalleOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenes_IdPrenda",
                table: "DetalleOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenes_IdTipoServicio",
                table: "DetalleOrdenes");

            migrationBuilder.AddColumn<int>(
                name: "OrdenIdOrden",
                table: "DetalleOrdenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrendaIdPrenda",
                table: "DetalleOrdenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoServicioIdTipoServicio",
                table: "DetalleOrdenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_OrdenIdOrden",
                table: "DetalleOrdenes",
                column: "OrdenIdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_PrendaIdPrenda",
                table: "DetalleOrdenes",
                column: "PrendaIdPrenda");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_TipoServicioIdTipoServicio",
                table: "DetalleOrdenes",
                column: "TipoServicioIdTipoServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenes_Ordenes_OrdenIdOrden",
                table: "DetalleOrdenes",
                column: "OrdenIdOrden",
                principalTable: "Ordenes",
                principalColumn: "IdOrden",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenes_Prendas_PrendaIdPrenda",
                table: "DetalleOrdenes",
                column: "PrendaIdPrenda",
                principalTable: "Prendas",
                principalColumn: "IdPrenda",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenes_TipoServicios_TipoServicioIdTipoServicio",
                table: "DetalleOrdenes",
                column: "TipoServicioIdTipoServicio",
                principalTable: "TipoServicios",
                principalColumn: "IdTipoServicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
