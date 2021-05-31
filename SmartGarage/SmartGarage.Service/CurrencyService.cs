using Newtonsoft.Json;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
	public class CurrencyService : ICurrencyService
	{
		public async Task<decimal> Convert(DateTime exactDate, string currencyType)
		{
			if (currencyType == "EUR")
			{
				return 1;
			}
			if (currencyType == "USD" || currencyType == "GBP")
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
						return rates.Rates.USD;
					}
					else
					{
						return rates.Rates.GBP;
					}
				}
			}
			throw new ArgumentNullException("Enter Valid currency type! (USD, GBP)");
		}
		public async Task<GetOrderDTO> ConvertOrderDTO(DateTime exactDate, GetOrderDTO orderToConvert, string currencyType)
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
					foreach (var item in orderToConvert.ServicesDTO)
					{
						item.Price = rates.Rates.USD * item.Price;
					}
					orderToConvert.TotalPrice *= rates.Rates.USD;
					return orderToConvert;
				}

				if (currencyType == "GBP")
				{
					foreach (var item in orderToConvert.ServicesDTO)
					{
						item.Price = rates.Rates.GBP * item.Price;
					}
					orderToConvert.TotalPrice *= rates.Rates.GBP;
					return orderToConvert;
				}
				else
				{
					throw new ArgumentNullException("Enter Valid currency type! (USD, GBP)");
				}
			}
		}
	}
}