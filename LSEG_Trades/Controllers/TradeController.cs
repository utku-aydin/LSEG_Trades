using Microsoft.AspNetCore.Mvc;
using LSEG_Trades.Api.Controllers.HttpDataClient.Interfaces;
using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Api.Service.Payment.Interfaces;
using LSEG_Trades.Data.Dtos;

namespace LSEG_Trades.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    // DUA - Eliminates need for ModelState.IsValid
    [ApiController]
    public class TradeController : ControllerBase
    {
        private ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        // DUA 05-12-2023 - Async endpoint demo (for freeing up threads for to threadpool
        [HttpPost]
        public async Task<ActionResult> SubmitTrade([FromBody] TradeDto tradeDto)
        {
            await _tradeService.SubmitTrade(tradeDto);
            // DUA 05-12-2023 - If we had a single stock retrieval endpoint the URI and created stock could go here
            return Created("", "");
        }

        [HttpGet]
        public async Task<ActionResult<decimal>> GetStockValueByTicker(string ticker)
        {
            return await _tradeService.GetStockValueByTicker(ticker);
        }

        [HttpGet]
        public ActionResult<List<StockDto>> GetStocksByTickers([FromQuery] string[] tickers)
        {
            return _tradeService.GetStockRangeByTickers(tickers);
        }

        [HttpGet]
        public ActionResult<List<StockDto>> GetAllStocks()
        {
            return _tradeService.GetAllStocks();
        }
    }
}
