using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Data.Dtos;
using LSEG_Trades.Data.Models;

namespace LSEG_Trades.Api.Service.Payment.Interfaces
{
    public interface ITradeService
    {
        Task SubmitTrade(TradeDto tradeDto);

        Task<decimal?> GetStockValueByTicker(string ticker);

        List<StockDto> GetStockRangeByTickers(string[] tickers);

        List<StockDto> GetAllStocks();
    }
}
