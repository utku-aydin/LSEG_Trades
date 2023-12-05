using Microsoft.EntityFrameworkCore;

using LSEG_Trades.Api.Data.Models;
using LSEG_Trades.Data.Models;

namespace LSEG_Trades.Api.Data.ObjectRelationalMapping
{
    public class TradeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TradeDbContext(DbContextOptions<TradeDbContext> options, IConfiguration configuration) : base(options) 
        { 
            _configuration = configuration; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMem");
        }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
