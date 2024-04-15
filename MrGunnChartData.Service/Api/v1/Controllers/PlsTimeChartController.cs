using Microsoft.AspNetCore.Mvc;
using MrGunnChartData.DataLayer;

namespace MrGunnChartData.Service.Api.v1
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class PlsTimeChartController : ControllerBase
    {
        private readonly ILogger<PlsTimeChartController> _logger;
        private readonly IPlsTimeChartRepository _plsTimeChartRepository;    

        public PlsTimeChartController(ILogger<PlsTimeChartController> logger, IPlsTimeChartRepository plsTimeChartRepository)
        {
            _logger = logger;
            _plsTimeChartRepository = plsTimeChartRepository;
        }

        [HttpGet(Name = "get_pls_time_data")]
        public IEnumerable<PlsTimeDataWriteDto> Get()
        {
            _logger.LogInformation("plsTimeData returned");
            return _plsTimeChartRepository.ReadPlsTimeChartData()
            .ToArray();
        }

        [HttpGet(Name = "get_time_chart_data")]
        public IEnumerable<TimeChartDataWriteDto> GetT()
        {
            _logger.LogInformation("time chart data returned");
            return _plsTimeChartRepository.ReadTimeDividendChartData()
            .ToArray();
        }
    }
}