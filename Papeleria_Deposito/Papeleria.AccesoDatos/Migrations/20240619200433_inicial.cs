using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioVP = table.Column<double>(type: "float", nullable: false),
                    CodigoProveedor_codigo = table.Column<long>(type: "bigint", nullable: false),
                    Descripcion_Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreArticulo_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TiposMovimientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMovimientos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Contrasenia_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto_Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoStocks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FecHorMovRealizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticuloID = table.Column<int>(type: "int", nullable: false),
                    MovimientoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioRealizaMovimientoID = table.Column<int>(type: "int", nullable: false),
                    CtdUnidadesXMovimiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoStocks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovimientoStocks_Articulos_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoStocks_TiposMovimientos_MovimientoID",
                        column: x => x.MovimientoID,
                        principalTable: "TiposMovimientos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoStocks_Usuarios_UsuarioRealizaMovimientoID",
                        column: x => x.UsuarioRealizaMovimientoID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoStocks_ArticuloID",
                table: "MovimientoStocks",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoStocks_MovimientoID",
                table: "MovimientoStocks",
                column: "MovimientoID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoStocks_UsuarioRealizaMovimientoID",
                table: "MovimientoStocks",
                column: "UsuarioRealizaMovimientoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientoStocks");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "TiposMovimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
