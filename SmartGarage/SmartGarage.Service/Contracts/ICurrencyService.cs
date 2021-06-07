using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface ICurrencyService
    {
        Task<decimal> Convert(DateTime exactDate, string currencyType);
        Task<GetOrderDTO> ConvertOrderDTO(DateTime exactDate, GetOrderDTO orderToConvert, string currencyType);

    }
}