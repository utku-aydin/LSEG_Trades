using AutoMapper;
using LSEG_Trades.Api.Data.Dtos;
using LSEG_Trades.Api.Data.ObjectRelationalMapping.Profiles;
using LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories.Interfaces;
using LSEG_Trades.Api.Service.Date.Interfaces;
using LSEG_Trades.Api.Service.Payment;
using LSEG_Trades.Data.Models;
using Moq;

namespace LSEG_TradesTests.Service
{
    public class TradeServiceTests
    {
        private Mock<ITradeRepository> _tradeRepositoryMock;
        private Mock<ISystemDate> _systemDateMock;
        private IMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var profile = new TradeProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(config);
        }

        [SetUp]
        public void Setup()
        {
            _systemDateMock = new Mock<ISystemDate>();
            _tradeRepositoryMock = new Mock<ITradeRepository>();
        }

        [Test]
        public async Task Given_NonExistentStockTrade_Verify_SubmitTrade_CreatesStock()
        {
            #region Arrange
            var trdDto = new TradeDto()
            {
                StockTicker = "ticker1",
                StockPrice = 100,
                ShareCount = 1,
                BrokerId = "id1"
            };

            _tradeRepositoryMock.Setup(tr => tr.AddStock(It.IsAny<Stock>()));

            var tradeService = new TradeService(_tradeRepositoryMock.Object, _mapper);
            #endregion

            #region Act
            await tradeService.SubmitTrade(trdDto);
            #endregion

            #region Assert
            _tradeRepositoryMock.Verify(tr => tr.AddStock(It.IsAny<Stock>()));
            #endregion
        }

        [Test]
        public async Task Given_ExistingStockTrade_Verify_SubmitTrade_UpdatesStock()
        {
            #region Arrange
            var ticker = "ticker1";

            var trdDto = new TradeDto()
            {
                StockTicker = ticker,
                StockPrice = 100,
                ShareCount = 1,
                BrokerId = "id1"
            };

            var stock = new Stock()
            {
                Ticker = ticker,
                LatestPrice = 10
            };

            _tradeRepositoryMock.Setup(tr => tr.UpdateStock(It.IsAny<Stock>()));
            _tradeRepositoryMock.Setup(tr => tr.GetStockByTicker(ticker)).Returns(Task.FromResult(stock));

            var tradeService = new TradeService(_tradeRepositoryMock.Object, _mapper);
            #endregion

            #region Act
            await tradeService.SubmitTrade(trdDto);
            #endregion

            #region Assert
            Assert.That(stock.LatestPrice, Is.EqualTo(100));
            #endregion
        }
    }
}