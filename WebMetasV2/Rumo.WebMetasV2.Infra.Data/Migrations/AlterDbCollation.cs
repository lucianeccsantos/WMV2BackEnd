using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Infra.Data.Migrations
{
    partial class AlterDbCollation: Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("COLLATE", "Latin1_General_CI_AS");

        }
    }
}
