using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class tblColaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_GrupoPool_GrupoPoolId",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEscopoArea_Area_AreaId",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEscopoArea_Escopo_EscopoId",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEscopoArea_Indicador_IndicadorId",
                table: "IndicadorEscopoArea");

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<int>(nullable: false),
                    CadastroIncompleto = table.Column<bool>(nullable: false),
                    CargoId = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PerfilId = table.Column<Guid>(nullable: false),
                    SuperiorImediatoId = table.Column<Guid>(nullable: false),
                    UnidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Colaborador_SuperiorImediatoId",
                        column: x => x.SuperiorImediatoId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CargoId",
                table: "Colaborador",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_PerfilId",
                table: "Colaborador",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_SuperiorImediatoId",
                table: "Colaborador",
                column: "SuperiorImediatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_UnidadeId",
                table: "Colaborador",
                column: "UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_GrupoPool_GrupoPoolId",
                table: "Cargo",
                column: "GrupoPoolId",
                principalTable: "GrupoPool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEscopoArea_Area_AreaId",
                table: "IndicadorEscopoArea",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEscopoArea_Escopo_EscopoId",
                table: "IndicadorEscopoArea",
                column: "EscopoId",
                principalTable: "Escopo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEscopoArea_Indicador_IndicadorId",
                table: "IndicadorEscopoArea",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_GrupoPool_GrupoPoolId",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEscopoArea_Area_AreaId",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEscopoArea_Escopo_EscopoId",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorEscopoArea_Indicador_IndicadorId",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_GrupoPool_GrupoPoolId",
                table: "Cargo",
                column: "GrupoPoolId",
                principalTable: "GrupoPool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEscopoArea_Area_AreaId",
                table: "IndicadorEscopoArea",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEscopoArea_Escopo_EscopoId",
                table: "IndicadorEscopoArea",
                column: "EscopoId",
                principalTable: "Escopo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorEscopoArea_Indicador_IndicadorId",
                table: "IndicadorEscopoArea",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
