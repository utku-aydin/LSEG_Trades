using LSEG_Trades.Api.Data.Models;
using LSEG_Trades.Data.Models;

namespace LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task<Stock?> GetStockByTicker(string ticker);
        List<Stock> GetAllStocks();
        List<Stock> GetStockRangeByTickers(string[] tickers);
        void AddTrade(Trade trade);
        void AddStock(Stock stock);
        void UpdateStock(Stock stock);
        bool SaveChanges();
    }
}
