namespace MrGunnChartData.EvmLayer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IReadContract _sut;
        [TestMethod]
        public void TestMethod1()
        {
            _sut = Helper.GetRequiredService<IReadContract>() ?? throw new ArgumentNullException(nameof(IReadContract));
            
            var result = _sut.ReturnTotalSupply();
            Assert.AreNotEqual(result, "false");
        }

        [TestMethod]
        //[DataRow("0x00024ab", 9387)]
        [DataRow("0x0000000000000000000000000000000000000000000004e9e8c2e2ff3cde5d6a", "23183087760231315584408")]
        public void TestMethod2(string HexNumber, string expectedResult )
        {
            _sut = Helper.GetRequiredService<IReadContract>() ?? throw new ArgumentNullException(nameof(IReadContract));

            var result = _sut.HexToDecimal(HexNumber);
            Assert.AreNotEqual(result, expectedResult);
        }
    }
}