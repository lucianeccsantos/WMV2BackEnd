using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rumo.WebMetasV2.Domain.Core.Events;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Mappings;
using System.IO;

namespace Rumo.WebMetasV2.Infra.Data.Context
{
    public class WebMetasContext : DbContext
    {
        
        public DbSet<StoredEvent> StoredEvent { get; set; }
        public DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

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
