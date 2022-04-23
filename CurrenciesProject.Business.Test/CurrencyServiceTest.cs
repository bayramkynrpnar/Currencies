using CurrenciesProject.Business.Services;
using System;
using Xunit;

namespace CurrenciesProject.Business.Test
{
    public class CurrencyServiceTest : IClassFixture<CurrencyServiceFixture>
    {
        private readonly CurrencyServiceFixture _currencyServiceFixture;
        
        public CurrencyServiceTest(CurrencyServiceFixture currencyService)
        {
            _currencyServiceFixture = currencyService;
            Environment.SetEnvironmentVariable("PostgreUri", "host=localhost;port=5432;database=databaseName;userid=root;password=root");
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