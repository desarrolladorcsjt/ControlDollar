using ControlDolarPeru.Domain.HistoricalAverageAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.EF.Configuration
{
    public class HistoricalAverageConfiguration : IEntityTypeConfiguration<HistoricalAverage>
    {
        public void Configure(EntityTypeBuilder<HistoricalAverage> builder)
        {
            builder.ToTable("HistoricalAverage").HasKey(x=>x.Id);
            builder.Property(x => x.PurchasePrice).HasPrecision(13, 7);
            builder.Property(x => x.SalePrice).HasPrecision(13, 5);
        }
    }
}
