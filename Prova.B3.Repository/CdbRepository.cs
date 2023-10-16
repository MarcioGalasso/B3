using Prova.B3.Domain.Entities;
using Prova.B3.Domain.Model;
using Prova.B3.Repository.Context;
using Prova.B3.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Repository
{
    public class CdbRepository : ICdbRepository
    {
        private readonly ITaxasRepository taxasRepository;
        private const int MesInicial = 1;
        private const int TetoMesesImposto = 24;
        public CdbRepository(ITaxasRepository taxasRepository)
        {
            this.taxasRepository = taxasRepository;
        }

        public async Task<CdbCalc> CalcularAsync(Cdb cdb)
        {
            var configuracaoTaxas = await taxasRepository.GetAsync(cdb.Meses < TetoMesesImposto ? cdb.Meses : default);
            var bruto = Math.Round(CarcularCdb(cdb.Valor, configuracaoTaxas, MesInicial, cdb.Meses), 2, MidpointRounding.AwayFromZero);
            var liquido = bruto - cdb.Valor;
            var imposto = Math.Round(liquido * configuracaoTaxas.Impostos, 2, MidpointRounding.AwayFromZero);
            return new CdbCalc { Bruto = bruto, Liquido = liquido, Meses = cdb.Meses, Valor = cdb.Valor, Imposto = imposto };
        }

        private decimal CarcularCdb(decimal valor, Taxas taxas, int mes, int mesFinal)
        {
            var resultado = valor * (1 + (taxas.Cdi * taxas.Tb));
            if (mes < mesFinal)
                resultado = CarcularCdb(resultado, taxas, (mes + 1), mesFinal);

            return resultado;
        }


    }
}
