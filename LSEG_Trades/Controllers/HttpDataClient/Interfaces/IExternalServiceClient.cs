using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Data.Dtos;

namespace LSEG_Trades.Api.Controllers.HttpDataClient.Interfaces
{
    public interface IExternalServiceClient
    {
        Task<StockDto> GetPaymentResponse(StockDto bankRequestDto);
    }
}
