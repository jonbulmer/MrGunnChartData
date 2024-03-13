using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrGunnChartData.DataLayer
{
    public class PlsTimeChartRepository : IPlsTimeChartRepository
    {
        public List<PlsTimeDataDto> ReadPlsTimeChartData()
        {
            // I need code to a hook into the the contract calls to get the data

            //here I am working out where I can host data from the Time contract

            var result = new List<PlsTimeDataDto>();
            result.Add(new PlsTimeDataDto { Date = new DateTime(2024, 12, 7), PlsEarned100KTime = 1.1, PlsPrice = 2.2, TimeDividendPrice = 3.3 });
            return ReadAndReturnJsonData("plsTimeChart");
        }

        private List<PlsTimeDataDto> ReadAndReturnJsonData(string jsonFileName)
        {
            var jsonChart = ReturnJson(jsonFileName);

            var chartPoints = JsonConvert.DeserializeObject<PlsTimeDataList>(jsonChart).plsTimeDataDtos.ToList();
            

            //for (var j = 0; j < chartPoints.Count(); j++)
            //{
            //}

            return chartPoints;
        }

        private string ReturnJson(string jsonFileName)
        {
            var result = "";
            

            string currentdirectory = Directory.GetParent(System.Environment.CurrentDirectory).FullName;

            var filepath = currentdirectory + "\\Resources\\" + jsonFileName + ".json";


            using (StreamReader r = new StreamReader(filepath))
            {
                result = r.ReadToEnd();
            }

            return result;
        }
    }
}
