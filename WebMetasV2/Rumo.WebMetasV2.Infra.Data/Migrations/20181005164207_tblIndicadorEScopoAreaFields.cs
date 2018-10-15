using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    public partial class tblIndicadorEScopoAreaFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdArea",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropColumn(
                name: "IdEscopo",
                table: "IndicadorEscopoArea");

            migrationBuilder.DropColumn(
                name: "IdIndicador",
                table: "IndicadorEscopoArea");

            migrationBuilder.AlterColumn<Guid>(
                name: "IndicadorId",
                table: "IndicadorEscopoArea",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EscopoId",
                table: "IndicadorEscopoArea",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "IndicadorEscopoArea",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IndicadorId",
                table: "IndicadorEscopoArea",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "EscopoId",
                table: "IndicadorEscopoArea",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "IndicadorEscopoArea",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "IdArea",
                table: "IndicadorEscopoArea",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdEscopo",
                table: "IndicadorEscopoArea",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdIndicador",
                table: "IndicadorEscopoArea",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
