using FluentValidation;
using Prova.B3.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Domain.Validator
{
    public class CdbValidator : AbstractValidator<Cdb>
    {
        public CdbValidator()
        {
            RuleFor(x => x.Meses).GreaterThanOrEqualTo(1).WithMessage(Resource.MesNaoPodeSerMenorUm);
            RuleFor(x => x.Valor).GreaterThanOrEqualTo(0).WithMessage(Resource.ValorNaoPodeSerMenoZero);
        }
    }
}
