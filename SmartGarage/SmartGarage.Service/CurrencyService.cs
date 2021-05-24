using Newtonsoft.Json;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<decimal> Convert(DateTime exactDate, decimal sumToConvert, string currencyType)
        {
            string baseCurrency = "EUR";
            var date = exactDate.ToString("yyyy-MM-dd");
            currencyType.ToUpper();

            var currencyToGet = "USD,GBP";

            var key = "ca74fdc30cc94eb11b8e5f72cb12f1dd";
            var CurrencyApi = " http://data.fixer.io/api/";
            var client = new HttpClient();

            using (var response = await client.GetAsync($"{CurrencyApi}{date}?access_key={key}&base={baseCurrency}&symbols={currencyToGet}"))
            {
                var result = await response.Content.ReadAsStringAsync();

                var rates = JsonConvert.DeserializeObject<CurrencyDTO>(result);

                if (currencyType == "USD")
                {
                    return rates.Rates.USD * sumToConvert;
                }

                if (currencyType == "GBP")
                {
                    return rates.Rates.GBP * sumToConvert;
                }
                else
                {
                    throw new ArgumentNullException("Enter Valid currency type! (USD, GBP)");
                }
            }
        }
    }
}