using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrGunnChartData.DataLayer
{
    public interface IPlsTimeChartRepository
    {
        void AddPlsTimeChartData();
        List<PlsTimeDataWriteDto> ReadPlsTimeChartData();
        public List<TimeChartDataWriteDto> ReadTimeDividendChartData();
        LiquidityPairs GetCurrentLiquidyPairs();
    }
}
