using LSEG_Trades.Api.Data.Models;
using LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories.Interfaces;
using LSEG_Trades.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories
{
    public class TradeRepository : ITradeRepository, IDisposable
    {
        private readonly TradeDbContext _context;

        public TradeRepository(TradeDbContext context)
        {
            _context = context;
        }

        public void AddTrade(Trade paymentResponse)
        {
            _context.Trades.Add(paymentResponse);
        }

        public void AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
        }

        public async Task<Stock?> GetStockByTicker(string ticker)
        {
            return await _context.Stocks.FirstOrDefaultAsync(stock => stock.Ticker == ticker);
        }

        public void UpdateStock(Stock stock)
        {
            _context.Stocks.Update(stock);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public List<Stock> GetAllStocks()
        {
            return _context.Stocks.ToList();
        }

        public List<Stock> GetStockRangeByTickers(string[] tickers)
        {
            return _context.Stocks.Where(s => tickers.Contains(s.Ticker)).ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
