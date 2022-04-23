using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Business.Dto
{
    public class CurrentRateDto
    {
        public string Currency { get; set; }
        public string LastUpdated { get; set; }
        public string CurrentRate { get; set; }
    }
}
