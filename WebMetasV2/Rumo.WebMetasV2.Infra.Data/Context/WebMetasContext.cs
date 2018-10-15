using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rumo.WebMetasV2.Domain.Core.Events;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Mappings;
using System.IO;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Context
{
    public class WebMetasContext : DbContext
    {
        public DbSet<Area> Area { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Dependencia> Dependencia { get; set; }
        public DbSet<Diretoria> Diretoria { get; set; }
        public DbSet<Escopo> Escopo { get; set; }
        public DbSet<GrupoPool> GrupoPool { get; set; }
        public DbSet<Indicador> Indicador { get; set; }
        public DbSet<IndicadorEscopoArea> IndicadorEscopoArea { get; set; }
        public DbSet<FluxoAprovacao> FluxoAprovacao { get; set; }
        public DbSet<FluxoAprovacaoEtapa> FluxoAprovacaoEtapa { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<StoredEvent> StoredEvent { get; set; }
        public DbSet<Unidade> Unidade { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new DependenciaMap());
            modelBuilder.ApplyConfiguration(new DiretoriaMap());
            modelBuilder.ApplyConfiguration(new EscopoMap());
            modelBuilder.ApplyConfiguration(new GrupoPoolMap());
            modelBuilder.ApplyConfiguration(new IndicadorMap());
            modelBuilder.ApplyConfiguration(new IndicadorEscopoAreaMap());
            modelBuilder.ApplyConfiguration(new FluxoAprovacaoMap());
            modelBuilder.ApplyConfiguration(new FluxoAprovacaoEtapaMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            modelBuilder.ApplyConfiguration(new UnidadeMap());

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.SuperiorImediato)
                .WithMany(c => c.Colaboradores)
                .OnDelete(DeleteBehavior.Cascade);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
