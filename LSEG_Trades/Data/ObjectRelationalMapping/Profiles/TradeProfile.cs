using AutoMapper;
using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Api.Data.Models;
using LSEG_Trades.Data.Dtos;
using LSEG_Trades.Data.Models;

namespace LSEG_Trades.Api.Data.ObjectRelationalMapping.Profiles
{
    public class TradeProfile : Profile
    {
        public TradeProfile() 
        {
            CreateMap<Trade, TradeDto>();
            CreateMap<Stock, StockDto>();
        }
    }
}
