using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Domain;
using ControlDolarPeru.Domain.EF.Configuration;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.EF
{
    public class DollarContext : DbContext
    {
        public DollarContext(DbContextOptions<DollarContext> options) : base(options) { }
        public DbSet<HistoricalAverage> HistoricalAverages { get; set; } 
        public DbSet<ConfigurationLinks> ConfigurationLinks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistoricalAverageConfiguration());
            modelBuilder.ApplyConfiguration(new  ConfigurationLinksConfiguration());
        }
    }
}
