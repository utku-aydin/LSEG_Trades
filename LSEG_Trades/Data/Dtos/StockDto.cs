﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LSEG_Trades.Data.Dtos
{
    public class StockDto
    {
        [Required]
        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [Required]
        [JsonPropertyName("latest_price")]
        public decimal LatestPrice { get; set; }
    }
}
