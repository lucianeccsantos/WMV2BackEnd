using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class IndicadorEscopoAreaMap : IEntityTypeConfiguration<IndicadorEscopoArea>
    {
        public void Configure(EntityTypeBuilder<IndicadorEscopoArea> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.AreaId)
                .IsRequired();

            builder.Property(c => c.EscopoId)
                .IsRequired();

            builder.Property(c => c.IndicadorId)
                .IsRequired();
        }
    }
}
