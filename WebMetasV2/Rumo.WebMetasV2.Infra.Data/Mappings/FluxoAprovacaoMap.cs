using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class FluxoAprovacaoMap : IEntityTypeConfiguration<FluxoAprovacao>
    {
        public void Configure(EntityTypeBuilder<FluxoAprovacao> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Entidade)
                .IsRequired();
        }
    }
}
