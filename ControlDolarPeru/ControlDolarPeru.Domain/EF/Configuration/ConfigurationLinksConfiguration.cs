using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.EF.Configuration
{
    public class ConfigurationLinksConfiguration: IEntityTypeConfiguration<ConfigurationLinks>
    {
        public void Configure(EntityTypeBuilder<ConfigurationLinks> builder) {
            builder.ToTable("ConfigurationLinks").HasKey(x=>x.IdProvider);
        }
    }
}
