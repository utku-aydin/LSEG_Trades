using LSEG_Trades.Api.Service.Date.Interfaces;

namespace LSEG_Trades.Api.Service.Date
{
    // DUA 05-12-2023: Currently unused but very likely to require date mocking for unit tests
    public class SystemDate : ISystemDate
    {
        public DateTime GetDate() { return DateTime.Now; }
    }
}
