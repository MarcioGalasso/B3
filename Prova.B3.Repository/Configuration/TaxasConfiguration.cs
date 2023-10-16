using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prova.B3.Domain.Entities;

namespace Prova.B3.Repository.Configuration
{
    public class TaxasConfiguration : IEntityTypeConfiguration<Taxas>
    {
        public void Configure(EntityTypeBuilder<Taxas> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);
            builder.Property(p => p.Cdi);
            builder.Property(p => p.Tb);
            builder.Property(p => p.Meses);
            builder.Property(p => p.Impostos);
        }
    }
}
