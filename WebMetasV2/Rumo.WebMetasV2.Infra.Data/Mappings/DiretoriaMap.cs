using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class DiretoriaMap : IEntityTypeConfiguration<Diretoria>
    {
        public void Configure(EntityTypeBuilder<Diretoria> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");
        }
    }
}
