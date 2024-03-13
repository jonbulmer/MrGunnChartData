namespace MrGunnChartData.DataLayer
{

    public class PlsTimeDataList
    {
        public List<PlsTimeDataDto> plsTimeDataDtos { get; set; }  
    }
    public class PlsTimeDataDto
    {
        public DateTime Date { get; set; }

        public double PlsPrice { get; set; }

        public double TimeDividendPrice { get; set; }

        public double PlsEarned100KTime { get; set; }
        public double PlsReturn { get; set; }
    }
}