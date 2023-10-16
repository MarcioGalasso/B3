using Microsoft.EntityFrameworkCore;
using Prova.B3.Domain.Entities;
using Prova.B3.Repository.Context;
using Prova.B3.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Repository
{
    public class TaxaRepository : ITaxasRepository
    {
        private readonly B3Context b3Context;
        private readonly DbSet<Taxas> taxasDbSet;

        public TaxaRepository(B3Context b3Context)
        {
            taxasDbSet = b3Context.Set<Taxas>();
            this.b3Context = b3Context;
        }

        public Task<Taxas> GetAsync(int month) => taxasDbSet.OrderBy(c=> c.Meses).FirstAsync(c=> c.DataDesativacao == default && c.Meses >= month );
        public async Task PostAsync(IEnumerable<Taxas> taxes) 
        {
            await taxasDbSet.AddRangeAsync(taxes);
            await b3Context.SaveChangesAsync();
        }

    }
}
