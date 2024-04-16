using Microsoft.AspNetCore.Mvc;
using MrGunnChartData.DataLayer;

namespace MrGunnChartData.Service.Api.v1
{
    [ApiController]
    [Route("v1/[controller]/[Action]")]
    public class ChartsController : ControllerBase
    {
        private readonly ILogger<ChartsController> _logger;
        private readonly IPlsTimeChartRepository _plsTimeChartRepository;    

        public ChartsController(ILogger<ChartsController> logger, IPlsTimeChartRepository plsTimeChartRepository)
        {
            _logger = logger;
            _plsTimeChartRepository = plsTimeChartRepository;
        }

        [HttpGet(Name = "get_pls_time_data")]
        public IEnumerable<PlsTimeDataWriteDto> PlsTimeChart()
        {
            _logger.LogInformation("plsTimeData returned");
            return _plsTimeChartRepository.ReadPlsTimeChartData()
            .ToArray();
        }

        [HttpGet(Name = "get_time_chart_data")]
        public IEnumerable<TimeChartDataWriteDto> TimeChartData()
        {
            _logger.LogInformation("time chart data returned");
            return _plsTimeChartRepository.ReadTimeDividendChartData()
            .ToArray();
        }
    }
}