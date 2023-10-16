using Microsoft.EntityFrameworkCore;
using Prova.B3.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Repository.Context
{
    public class B3Context : DbContext
    {
        public B3Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxasConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
