using Microsoft.AspNetCore.Mvc;
using MrGunnChartData.DataLayer;

namespace MrGunnChartData.Service.Api.v1
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<PlsTimeDataDto> Get()
        {
            
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Console.WriteLine(AppContext.BaseDirectory);

            return _plsTimeChartRepository.ReadPlsTimeChartData()
            .ToArray();
        }
    }
}