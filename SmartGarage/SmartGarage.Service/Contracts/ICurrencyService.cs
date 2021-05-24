using System;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface ICurrencyService
    {
        Task<decimal> Convert(DateTime exactDate, decimal sumToConvert, string currencyType);
    }
}