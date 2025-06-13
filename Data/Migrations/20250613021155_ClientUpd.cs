using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAST_CLENAER_WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoCliente",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoCliente",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Clientes");
        }
    }
}
