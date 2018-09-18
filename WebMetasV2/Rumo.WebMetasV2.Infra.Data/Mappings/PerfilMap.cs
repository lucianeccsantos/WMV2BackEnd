using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Situacao)
                .IsRequired()
                .HasColumnType("bit");
                

        }
    }
}
