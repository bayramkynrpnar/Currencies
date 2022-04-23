using CurrenciesProject.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Business.Test
{
    public class CurrencyServiceFixture : IDisposable
    {
        public ICurrencyService CurrencyService { get; set; }
        public CurrencyServiceFixture()
        {
            CurrencyService = new CurrencyService();

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
