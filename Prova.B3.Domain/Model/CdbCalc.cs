using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.B3.Domain.Model
{
    public class CdbCalc : Cdb
    {
        public decimal Bruto { get; set; }
        public decimal Liquido { get; set; }
        public decimal Imposto { get; set; }
    }
}
