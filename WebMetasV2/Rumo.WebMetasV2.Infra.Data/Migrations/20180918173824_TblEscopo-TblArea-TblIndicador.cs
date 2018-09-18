using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class TblEscopoTblAreaTblIndicador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escopo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escopo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DirecaoIndicador = table.Column<int>(nullable: false),
                    MesFim = table.Column<int>(nullable: false),
                    MesInicio = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoIndicador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicador", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Escopo");

            migrationBuilder.DropTable(
                name: "Indicador");
        }
    }
}
