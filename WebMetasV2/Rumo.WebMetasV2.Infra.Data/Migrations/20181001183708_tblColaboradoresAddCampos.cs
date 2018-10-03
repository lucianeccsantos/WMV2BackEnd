using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class tblColaboradoresAddCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Colaborador",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DependenciaId",
                table: "Colaborador",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Colaborador",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DependenciaId",
                table: "Colaborador",
                column: "DependenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Dependencia_DependenciaId",
                table: "Colaborador",
                column: "DependenciaId",
                principalTable: "Dependencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Dependencia_DependenciaId",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_DependenciaId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "DependenciaId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Colaborador");
        }
    }
}
