using Prova.B3.Domain.Model;
using Prova.B3.Repository.Interfaces;
using Prova.B3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Services
{
    public class CdbService : ICdbService
    {
        private readonly ICdbRepository cdbRepository;

        public CdbService(ICdbRepository cdbRepository)
        {
            this.cdbRepository = cdbRepository;
        }

        public async Task<CdbCalc> CarcularAsync(Cdb cdb) => await cdbRepository.CalcularAsync(cdb);
    }
}
