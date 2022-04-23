using CurrenciesProject.Business.Dto;
using CurrenciesProject.Core.Helper;
using CurrenciesProject.Data;
using CurrenciesProject.Data.Context;
using CurrenciesProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Business.Services
{
    public class CurrencyService : ICurrencyService
    {
        /// <summary>
        /// En son kayıt atılan tariha ait döviz listesini getirir
        /// </summary>
        /// <returns></returns>
        public List<CurrentRateDto> ListCurrentRate()
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var date = uow.GetRepository<Dates>().GetAll(x => true).Include(x => x.Currency).OrderBy(x => x.Date).LastOrDefault();
                var currentList = new List<CurrentRateDto>();
                foreach (var item in date.Currency.OrderBy(x => x.ForexSelling))
                {
                    currentList.Add(new CurrentRateDto
                    {
                        Currency = item.CurrencyCode,
                        LastUpdated = item.Date,
                        CurrentRate = item.ForexSelling
                    });
                }
                return currentList;
            }
        }

        /// <summary>
        /// Bir günden fazla kayıt varsa günlük değişimi hesaplar
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public List<ChangesDto> ListRateAndShowChanges(string currency)
        {
            var changesDto = new List<ChangesDto>();
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var currencies = uow.GetRepository<Currency>().GetAll(x => x.CurrencyCode == currency).OrderBy(x => x.Date).ToList();
                if (currencies == null)
                {
                    return null;
                }
                if (currencies.Count >= 2)
                {
                    changesDto.Add(new ChangesDto
                    {
                        Currency = currencies[0].CurrencyCode,
                        Date = currencies[0].Date,
                        Rate = currencies[0].ForexSelling,
                        Changes = null
                    });
                    for (int i = 0; i < currencies.Count - 1; i++)
                    {
                        var rate = Helper.Instance.CalculatePercentage(Convert.ToDouble(currencies[i].ForexSelling), Convert.ToDouble(currencies[i + 1].ForexSelling));
                        changesDto.Add(new ChangesDto
                        {
                            Currency = currencies[i + 1].CurrencyCode,
                            Date = currencies[i + 1].Date,
                            Rate = currencies[i + 1].ForexSelling,
                            Changes = rate
                        });
                    }
                    return changesDto;
                }
                else if (currencies.Count == 1)
                {
                    changesDto.Add(new ChangesDto
                    {
                        Currency = currencies[0].CurrencyCode,
                        Date = currencies[0].Date,
                        Rate = currencies[0].ForexSelling,
                        Changes = null
                    });
                    return changesDto;
                }
                return changesDto;
            };
        }


    }
}
