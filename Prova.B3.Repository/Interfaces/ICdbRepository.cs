using Prova.B3.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Repository.Interfaces
{
    public interface ICdbRepository
    {
        Task<CdbCalc> CalcularAsync(Cdb cdb);
    }
}
