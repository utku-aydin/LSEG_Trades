using System.ComponentModel.DataAnnotations;

namespace LSEG_Trades.Data.Models
{
    public class Stock
    {
        [Key]
        [Required]
        public Guid UniqueReference { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public decimal LatestPrice { get; set; }
    }
}
