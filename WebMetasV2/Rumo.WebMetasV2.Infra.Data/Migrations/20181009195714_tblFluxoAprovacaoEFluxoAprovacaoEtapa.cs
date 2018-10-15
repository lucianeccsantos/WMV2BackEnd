using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class tblFluxoAprovacaoEFluxoAprovacaoEtapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluxoAprovacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Entidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluxoAprovacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FluxoAprovacaoEtapa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AprovaTudo = table.Column<bool>(nullable: false),
                    FluxoAprovacaoId = table.Column<Guid>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    PerfilId = table.Column<Guid>(nullable: false),
                    Responsavel = table.Column<int>(nullable: false),
                    TipoEtapa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluxoAprovacaoEtapa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FluxoAprovacaoEtapa_FluxoAprovacao_FluxoAprovacaoId",
                        column: x => x.FluxoAprovacaoId,
                        principalTable: "FluxoAprovacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FluxoAprovacaoEtapa_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluxoAprovacaoEtapa_FluxoAprovacaoId",
                table: "FluxoAprovacaoEtapa",
                column: "FluxoAprovacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FluxoAprovacaoEtapa_PerfilId",
                table: "FluxoAprovacaoEtapa",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluxoAprovacaoEtapa");

            migrationBuilder.DropTable(
                name: "FluxoAprovacao");
        }
    }
}
