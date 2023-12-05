using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LSEG_Trades.Api.Data.Dtos
{
    public class TradeDto
    {
        [Required]
        [JsonPropertyName("stock_ticker")]
        public string StockTicker { get; set; }

        [Required]
        [JsonPropertyName("stock_price")]
        public decimal StockPrice { get; set; }

        [Required]
        [JsonPropertyName("share_count")]
        public decimal ShareCount { get; set; }

        [Required]
        [JsonPropertyName("broker_id")]
        public string BrokerId { get; set; }
    }
}
