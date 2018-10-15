using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class tblIndicadorAddColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ColaboradorId",
                table: "Indicador",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_ColaboradorId",
                table: "Indicador",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Indicador_Colaborador_ColaboradorId",
                table: "Indicador",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indicador_Colaborador_ColaboradorId",
                table: "Indicador");

            migrationBuilder.DropIndex(
                name: "IX_Indicador_ColaboradorId",
                table: "Indicador");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Indicador");
        }
    }
}
