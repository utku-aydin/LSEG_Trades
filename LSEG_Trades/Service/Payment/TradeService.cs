using AutoMapper;
using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Api.Data.Models;
using LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories.Interfaces;
using LSEG_Trades.Api.Service.Date.Interfaces;
using LSEG_Trades.Api.Service.Payment.Interfaces;
using LSEG_Trades.Data.Dtos;
using LSEG_Trades.Data.Models;
using System.Collections.Generic;

namespace LSEG_Trades.Api.Service.Payment
{
    public class TradeService : ITradeService
    {
        private ITradeRepository _repository;
        private IMapper _mapper;

        public TradeService(ITradeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task SubmitTrade(TradeDto tradeDto)
        {
            _repository.AddTrade(_mapper.Map<Trade>(tradeDto));
            Stock? stock = await _repository.GetStockByTicker(tradeDto.StockTicker);

            if (stock != null)
            {
                stock.LatestPrice = tradeDto.StockPrice;
                _repository.UpdateStock(stock);
            }
            else
            {
                stock = new Stock()
                {
                    UniqueReference = Guid.NewGuid(),
                    Ticker = tradeDto.StockTicker,
                    LatestPrice = tradeDto.StockPrice
                };

                _repository.AddStock(stock);
            }
            
            _repository.SaveChanges();
        }

        // DUA 05-12-2023: Only returns decimal as client already knows ticker
        public async Task<decimal?> GetStockValueByTicker(string ticker)
        {
            Stock? stock = await _repository.GetStockByTicker(ticker);
            if (stock != null)
                return stock.LatestPrice;
            else
                return null;
        }

        public List<StockDto> GetStockRangeByTickers(string[] tickers)
        {
            return _mapper.Map<List<StockDto>>(_repository.GetStockRangeByTickers(tickers));
        }

        public List<StockDto> GetAllStocks()
        {
            return _mapper.Map<List<StockDto>>(_repository.GetAllStocks());
        }
    }
}
