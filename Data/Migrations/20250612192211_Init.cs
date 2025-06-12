using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAST_CLENAER_WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "EstadosOrden",
                columns: table => new
                {
                    IdEstadoOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosOrden", x => x.IdEstadoOrden);
                });

            migrationBuilder.CreateTable(
                name: "Prendas",
                columns: table => new
                {
                    IdPrenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPrenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prendas", x => x.IdPrenda);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicios",
                columns: table => new
                {
                    IdTipoServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoServicio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicios", x => x.IdTipoServicio);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEmpleadoAuth0 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoOrden = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntregaEstimada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregaReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false),
                    EstadoOrdenIdEstadoOrden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_EstadosOrden_EstadoOrdenIdEstadoOrden",
                        column: x => x.EstadoOrdenIdEstadoOrden,
                        principalTable: "EstadosOrden",
                        principalColumn: "IdEstadoOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenes",
                columns: table => new
                {
                    IdDetalleOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    IdTipoServicio = table.Column<int>(type: "int", nullable: false),
                    IdPrenda = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenIdOrden = table.Column<int>(type: "int", nullable: false),
                    TipoServicioIdTipoServicio = table.Column<int>(type: "int", nullable: false),
                    PrendaIdPrenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenes", x => x.IdDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_Ordenes_OrdenIdOrden",
                        column: x => x.OrdenIdOrden,
                        principalTable: "Ordenes",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_Prendas_PrendaIdPrenda",
                        column: x => x.PrendaIdPrenda,
                        principalTable: "Prendas",
                        principalColumn: "IdPrenda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_TipoServicios_TipoServicioIdTipoServicio",
                        column: x => x.TipoServicioIdTipoServicio,
                        principalTable: "TipoServicios",
                        principalColumn: "IdTipoServicio",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteIdCliente",
                table: "Ordenes",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EstadoOrdenIdEstadoOrden",
                table: "Ordenes",
                column: "EstadoOrdenIdEstadoOrden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrdenes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Prendas");

            migrationBuilder.DropTable(
                name: "TipoServicios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadosOrden");
        }
    }
}
