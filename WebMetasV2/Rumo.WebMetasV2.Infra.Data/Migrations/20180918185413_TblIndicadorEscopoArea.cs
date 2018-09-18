using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class TblIndicadorEscopoArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicadorEscopoArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: true),
                    EscopoId = table.Column<Guid>(nullable: true),
                    IdArea = table.Column<Guid>(nullable: false),
                    IdEscopo = table.Column<Guid>(nullable: false),
                    IdIndicador = table.Column<Guid>(nullable: false),
                    IndicadorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorEscopoArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorEscopoArea_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndicadorEscopoArea_Escopo_EscopoId",
                        column: x => x.EscopoId,
                        principalTable: "Escopo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndicadorEscopoArea_Indicador_IndicadorId",
                        column: x => x.IndicadorId,
                        principalTable: "Indicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEscopoArea_AreaId",
                table: "IndicadorEscopoArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEscopoArea_EscopoId",
                table: "IndicadorEscopoArea",
                column: "EscopoId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEscopoArea_IndicadorId",
                table: "IndicadorEscopoArea",
                column: "IndicadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadorEscopoArea");
        }
    }
}
