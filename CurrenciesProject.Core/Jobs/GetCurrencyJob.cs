﻿using CurrenciesProject.Data;
using CurrenciesProject.Data.Context;
using CurrenciesProject.DataAccess;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesProject.Core.Jobs
{
    public class GetCurrencyScheduler
    {
        private IScheduler Start()
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler().Result;
            if (!scheduler.IsStarted)
                scheduler.Start();
            return scheduler;
        }
        /// <summary>
        /// Her gün sabah 8 de job tetiklenir
        /// </summary>
        public void TriggerCurrency()
        {
            IScheduler scheduler = Start();
            IJobDetail jobCurrency = JobBuilder.Create<GetCurrencyJob>().WithIdentity("GetCurrencyJob", null).Build();
            var simpleTrigger = TriggerBuilder.Create().WithIdentity("GetCurrencyJob").StartAt(DateTime.UtcNow).WithCronSchedule("0 49 05 ? * *").Build();
            scheduler.ScheduleJob(jobCurrency, simpleTrigger);
        }
    }
    /// <summary>
    /// çekilen veriyi kayıt işlemi yapar
    /// </summary>
    public class GetCurrencyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var xmlString = Helper.Helper.Instance.GetData().Result;
            var data = Helper.Helper.Instance.XmlDeserialize<Dates>(xmlString);
            string[] name = new[]
            {
                "USD",
                "EUR",
                "GBP",
                "CHF",
                "KWD",
                "SAR",
                "RUB"
            };
            var currency = new List<Currency>();
            foreach (var item in data.Currency)
            {
                if (name.Contains(item.CurrencyCode))
                {
                    currency.Add(item);
                }
            }
            data.Currency = currency;

            using (var uow = new UnitOfWork<MasterContext>())
            {
                uow.GetRepository<Dates>().Add(data);
                uow.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
