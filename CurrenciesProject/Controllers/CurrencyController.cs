using CurrenciesProject.Business.Dto;
using CurrenciesProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrenciesProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// dövizlerin satın alım fiyatlarını ve son eklenme tarihlerini listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CurrentRateDto> ListCurrentRate()
        {
            return _currencyService.ListCurrentRate();
        }

        /// <summary>
        /// verilen dövizin gündelik değişimini listeler
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        [HttpGet("ListRateAndShowChanges")]
        public List<ChangesDto> ListRateAndShowChanges(string currency)
        {
            return _currencyService.ListRateAndShowChanges(currency);
        }
    }
}