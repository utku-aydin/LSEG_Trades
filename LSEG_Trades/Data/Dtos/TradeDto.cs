using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LSEG_Trades.Api.Data.Dtos
{
    // DUA 06-12-2023: Can also use "IValidatableObject" for more complex validation requirements
    public class TradeDto
    {
        [Required]
        [JsonPropertyName("stock_ticker")]
        public string StockTicker { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [JsonPropertyName("stock_price")]
        public decimal StockPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [JsonPropertyName("share_count")]
        public decimal ShareCount { get; set; }

        [Required]
        [JsonPropertyName("broker_id")]
        public string BrokerId { get; set; }
    }
}
