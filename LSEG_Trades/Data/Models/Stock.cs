using LSEG_Trades.Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace LSEG_Trades.Data.Models
{
    public class Stock
    {
        [Key]
        [Required]
        public Guid StockId { get; set; } = Guid.NewGuid();
        [Required]
        public string Ticker { get; set; }
        [Required]
        public decimal LatestPrice { get; set; }
        public List<Trade> Trades { get; set; } = new List<Trade>();
    }
}
