using Prova.B3.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Services.Interfaces
{
    public interface ICdbService
    {
        Task<CdbCalc> CarcularAsync(Cdb cdbCalc);
    }
}
