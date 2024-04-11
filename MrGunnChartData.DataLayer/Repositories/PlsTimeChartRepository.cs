using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using MrGunnChartData.Utilities;
using MrGunnChartData.EvmLayer;

namespace MrGunnChartData.DataLayer
{
    public class PlsTimeChartRepository : IPlsTimeChartRepository
    {

        private readonly IJsonUtility _jsonUtility;
        private readonly IReadContract _readContract;

         public PlsTimeChartRepository(IJsonUtility jsonUtility, IReadContract readContract)
        {
            _jsonUtility = jsonUtility;
            _readContract = readContract;
        }
        public List<PlsTimeDataWriteDto> ReadPlsTimeChartData()
        {
            List<PlsTimeDataWriteDto> chartPoints = new List<PlsTimeDataWriteDto>();
            return ReadAndReturnJsonData("plsTimeChart", chartPoints);
        }

        public List<TimeChartDataWriteDto> ReadTimeDividendChartData()
        {
            List<TimeChartDataWriteDto> chartPoints = new List<TimeChartDataWriteDto>();
            return ReadAndReturnJsonData("TIMEDividendChartData", chartPoints);
        }

        public void AddPlsTimeChartData()
        {
            var currentLiquidity = GetCurrentLiquidyParirs();

            var timeDividendPrice = currentLiquidity.Pairs.First().PriceUsd;
            var plsPrice = timeDividendPrice / currentLiquidity.Pairs.First().PriceNative;
            List<PlsTimeDataWriteDto> chartPoints = new List<PlsTimeDataWriteDto>();
            var originalPlsTimeData = ReadAndReturnJsonData("plsTimeChart", chartPoints);
            var pls100K = originalPlsTimeData.Sum(x => int.Parse(x.PlsEarned100KTime));
            double lastPlsEarned = (double)pls100K / 100;
            lastPlsEarned = lastPlsEarned * 137;
            lastPlsEarned = lastPlsEarned + 27048;
            var newPlsEarned = _readContract.ReturnPlsEarned100KTime((long)lastPlsEarned);

            originalPlsTimeData.Add(new PlsTimeDataWriteDto() 
                    { 
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        PlsEarned100KTime = newPlsEarned.ToString(), 
                        PlsPrice = plsPrice.ToString("0.0000000"), 
                        PlsReturn = (plsPrice * newPlsEarned).ToString(), 
                        TimeDividendPrice = timeDividendPrice.ToString("0.00000")  
                    });

            var jsonToOutput = "{\r\n \"plsTimeDataDtos\": ";
            jsonToOutput = jsonToOutput + JsonConvert.SerializeObject(originalPlsTimeData, Formatting.Indented);
            jsonToOutput = jsonToOutput + "\r\n}";

            string currentdirectory = Directory.GetParent(System.Environment.CurrentDirectory).FullName;

            var filepath = currentdirectory + "/Resources/" + "plsTimeChart" + ".json";

            File.WriteAllText(filepath , jsonToOutput);
        }

        private List<TDto> ReadAndReturnJsonData<TDto>(string jsonFileName, List<TDto> chartPoints)
        {
            var jsonChart = _jsonUtility.ReturnJson(jsonFileName);

            chartPoints = JsonConvert.DeserializeObject<DataList<TDto>>(jsonChart).dataDtos.ToList();

            return chartPoints;
        }

        public LiquidityPairs GetCurrentLiquidyParirs()
        {
            var url = "https://api.dexscreener.com/latest/dex/pairs/pulsechain/0xEFab2c9c33C42960F2fF653aDb39dC5C4c10630e";

            var json = new WebClient().DownloadString(url);

            LiquidityPairs result = JsonConvert.DeserializeObject<LiquidityPairs>(json);

            return result;
        }
    }

    public class LiquidityPairs
    {
        public string SchemaVersion { get; set; }
        public List<Pairs> Pairs { get; set; }
        //public List<Pair> { get; set; }
    }

    public class Pairs
    {
        public float PriceNative { get; set; }
        public float PriceUsd { get; set; }
    }

}