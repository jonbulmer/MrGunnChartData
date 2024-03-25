using MrGunnChartData.DataLayer;
using System.Security.Cryptography;

namespace MrGunnChartData.DataLayer.Test
{
    [TestClass]
    public class Repositories
    {
        private IPlsTimeChartRepository _sut;
        [TestMethod]
        public void AddNewItem()
        {
            _sut = Helper.GetRequiredService<IPlsTimeChartRepository>() ?? throw new ArgumentNullException(nameof(IPlsTimeChartRepository));

            _sut.AddPlsTimeChartData();
            Assert.AreEqual("", "");
        }
    }
}