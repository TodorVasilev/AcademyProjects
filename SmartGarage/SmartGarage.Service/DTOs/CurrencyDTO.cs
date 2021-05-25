using Newtonsoft.Json;

namespace SmartGarage.Service.DTOs
{
    public class CurrencyDTO
    {
        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public Currency Rates { get; set; }
    }

    public class Currency
    {
        [JsonProperty("USD")]
        public decimal USD { get; set; }

        [JsonProperty("GBP")]
        public decimal GBP { get; set; }

    }

}
