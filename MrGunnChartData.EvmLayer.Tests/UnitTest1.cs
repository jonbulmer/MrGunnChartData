using System.Security.Cryptography;

namespace MrGunnChartData.EvmLayer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IReadContract _sutReadContract;


        [TestMethod]
        public void TestMethod1()
        {
            _sutReadContract = Helper.GetRequiredService<IReadContract>() ?? throw new ArgumentNullException(nameof(IReadContract));
            
            var result = _sutReadContract.ReturnPlsEarned100KTime(100);
            Assert.AreNotEqual(result, "false");
        }

        [TestMethod]
        //[DataRow("0x00024ab", 9387)]
        [DataRow("0x0000000000000000000000000000000000000000000004e9e8c2e2ff3cde5d6a", "23204329518201053273450")]
        public void TestMethod2(string HexNumber, string expectedResult )
        {
            _sutReadContract = Helper.GetRequiredService<IReadContract>() ?? throw new ArgumentNullException(nameof(IReadContract));

            var result = _sutReadContract.HexToDecimal(HexNumber);
            Assert.AreEqual(result, expectedResult);
        }

        //[TestMethod]
        //public void GetDataTest()
        //{
        //    _sutTimeChartRepository = Helper.GetRequiredService<IPlsTimeChartRepository>() ?? throw new ArgumentNullException(nameof(IPlsTimeChartRepository));

        //    var result = _sutTimeChartRepository.GetCurrentLiquidyParirs();
        //    Assert.AreEqual(result.Pairs.First().PriceNative, 24.8235F);
        //}

    }
}