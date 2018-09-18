using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class IndicadorMap : IEntityTypeConfiguration<Indicador>
    {
        public void Configure(EntityTypeBuilder<Indicador> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.DirecaoIndicador)
                .IsRequired();

            builder.Property(c => c.MesFim)
                .IsRequired();

            builder.Property(c => c.MesInicio)
                .IsRequired();

            builder.Property(c => c.TipoIndicador)
                .IsRequired();
        }
    }
}
