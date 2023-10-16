using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Domain.Entities
{
    public class Taxas
    {
        

        public Guid Id { get; set; }
        public decimal Tb { get; set; }
        public decimal Cdi { get; set; }
        public DateTime DataDesativacao { get; set; }
        public int? Meses { get; set; }
        public decimal Impostos { get; set; }
    }
}
