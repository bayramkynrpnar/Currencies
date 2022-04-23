using CurrenciesProject.Business.Services;
using Xunit;

namespace CurrenciesProject.Business.Test
{
    public class CurrencyServiceTest : IClassFixture<CurrencyServiceFixture>
    {
        private readonly CurrencyServiceFixture _currencyServiceFixture;
        public CurrencyServiceTest(CurrencyServiceFixture currencyService)
        {
            _currencyServiceFixture = currencyService;
        }
        [Fact]
        public void ListCurrentRate_Response_Test()
        {
            var response = _currencyServiceFixture.CurrencyService.ListCurrentRate();
            Assert.True(response.Count >= 1);
        }
        [Fact]
        public void ListRateAndShowChanges_Response_Test()
        {
            var response = _currencyServiceFixture.CurrencyService.ListRateAndShowChanges("USD");
            Assert.NotNull(response);
            Assert.True(response.Count >= 1);
        }
    }
}