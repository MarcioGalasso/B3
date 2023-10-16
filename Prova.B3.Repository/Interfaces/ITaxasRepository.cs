using Prova.B3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Repository.Interfaces
{
    public interface ITaxasRepository
    {
        Task<Taxas> GetAsync(int mont);
        Task PostAsync(IEnumerable<Taxas> taxes);
    }
}
