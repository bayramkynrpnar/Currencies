using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Business.Dto
{
    public class ChangesDto
    {
        public string Currency { get; set; }
        public string Date { get; set; }
        public string Rate { get; set; }
        public string Changes { get; set; }
    }
}
