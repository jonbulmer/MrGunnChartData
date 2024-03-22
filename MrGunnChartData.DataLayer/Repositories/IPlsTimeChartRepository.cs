﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrGunnChartData.DataLayer
{
    public interface IPlsTimeChartRepository
    {
        List<PlsTimeDataDto> ReadPlsTimeChartData();
        LiquidityPairs GetCurrentLiquidyParirs();
    }
}
