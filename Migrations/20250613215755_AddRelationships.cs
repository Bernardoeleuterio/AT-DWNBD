using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT_DWNBD.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CidadeDestino_PaisDestino_PaisDestinoId",
                table: "CidadeDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_PacoteTuristico_PacoteTuristicoId",
                table: "Reserva");

            migrationBuilder.CreateTable(
                name: "CidadeDestinoPacoteTuristico",
                columns: table => new
                {
                    CidadesDestinoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PacotesTuristicosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeDestinoPacoteTuristico", x => new { x.CidadesDestinoId, x.PacotesTuristicosId });
                    table.ForeignKey(
                        name: "FK_CidadeDestinoPacoteTuristico_CidadeDestino_CidadesDestinoId",
                        column: x => x.CidadesDestinoId,
                        principalTable: "CidadeDestino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CidadeDestinoPacoteTuristico_PacoteTuristico_PacotesTuristicosId",
                        column: x => x.PacotesTuristicosId,
                        principalTable: "PacoteTuristico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CidadeDestinoPacoteTuristico_PacotesTuristicosId",
                table: "CidadeDestinoPacoteTuristico",
                column: "PacotesTuristicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CidadeDestino_PaisDestino_PaisDestinoId",
                table: "CidadeDestino",
                column: "PaisDestinoId",
                principalTable: "PaisDestino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_PacoteTuristico_PacoteTuristicoId",
                table: "Reserva",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CidadeDestino_PaisDestino_PaisDestinoId",
                table: "CidadeDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_PacoteTuristico_PacoteTuristicoId",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "CidadeDestinoPacoteTuristico");

            migrationBuilder.AddForeignKey(
                name: "FK_CidadeDestino_PaisDestino_PaisDestinoId",
                table: "CidadeDestino",
                column: "PaisDestinoId",
                principalTable: "PaisDestino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_PacoteTuristico_PacoteTuristicoId",
                table: "Reserva",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
