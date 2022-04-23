using CurrenciesProject.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Business.Services
{
    public interface ICurrencyService
    {
        List<CurrentRateDto> ListCurrentRate();
        List<ChangesDto> ListRateAndShowChanges(string currency);
    }
}
