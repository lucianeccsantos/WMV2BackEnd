using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class FluxoAprovacaoEtapaMap : IEntityTypeConfiguration<FluxoAprovacaoEtapa>
    {
        public void Configure(EntityTypeBuilder<FluxoAprovacaoEtapa> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.AprovaTudo)
                .IsRequired();

            builder.Property(c => c.Ordem)
                .IsRequired();

            builder.Property(c => c.Responsavel)
                .IsRequired();

            builder.Property(c => c.TipoEtapa)
                .IsRequired();

            builder.Property(c => c.FluxoAprovacaoId)
                .IsRequired();
        }
    }
}
