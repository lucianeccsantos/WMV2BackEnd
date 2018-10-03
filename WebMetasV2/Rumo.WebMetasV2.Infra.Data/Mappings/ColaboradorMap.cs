using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Infra.Data.Mappings
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.Property(c => c.CadastroIncompleto)
                .IsRequired();

            builder.Property(c => c.CargoId)
                .IsRequired();

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.DependenciaId)
                .IsRequired();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            builder.Property(c => c.PerfilId)
                .IsRequired();

            builder.Property(c => c.SuperiorImediatoId)
                .IsRequired(false);

            builder.Property(c => c.UnidadeId)
                .IsRequired();

        }
    }
}
