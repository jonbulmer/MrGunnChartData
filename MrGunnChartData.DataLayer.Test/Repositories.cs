using Moq;
using MrGunnChartData.DataLayer;
using System.Security.Cryptography;

namespace MrGunnChartData.DataLayer.Test
{
    [TestClass]
    public class Repositories
    {
        private IPlsTimeChartRepository _sut;
        [TestMethod]
        public void AddNewPlsTimeChatItem_WithValid_Data_UpdatesFile()
        {
            _sut = Helper.GetRequiredService<IPlsTimeChartRepository>() ?? throw new ArgumentNullException(nameof(IPlsTimeChartRepository));
            var plsTimeChartRepo = new Mock<IPlsTimeChartRepository>();
            List<Pairs> pairs = new List<Pairs>() { new Pairs() { PriceNative = 21.3F, PriceUsd = 23.2F } };
            LiquidityPairs lquPrs = new LiquidityPairs() { SchemaVersion = "", Pairs = pairs} ;
            //plsTimeChartRepo.Setup(x => x.GetCurrentLiquidyPairs());

            //var _systemUnderTest = new MeterReads(fileTypeValidator.Object, meterReadsRepository.Object);

            //var _systemUnderTest = new PlsTimeChartRepository(plsTimeChartRepo.Object());

            _sut.AddPlsTimeChartData();
            
            Assert.AreEqual("", "");
        }
    }
}