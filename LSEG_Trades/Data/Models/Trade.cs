using System.ComponentModel.DataAnnotations;

namespace LSEG_Trades.Api.Data.Models
{
    public class Trade
    {
        [Key]
        [Required]
        public Guid UniqueReference { get; set; }
        [Required]
        public string StockTicker { get; set; }
        [Required]
        public decimal StockPrice { get; set; }
        [Required]
        public decimal ShareCount { get; set; }
        [Required]
        public string BrokerId { get; set; }
    }
}
