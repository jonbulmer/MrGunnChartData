namespace MrGunnChartData.DataLayer
{

    public class PlsTimeDataList
    {
        public List<PlsTimeDataDto> plsTimeDataDtos { get; set; }  
    }
    public class PlsTimeDataDto
    {
        public DateTime Date { get; set; }

        public float PlsPrice { get; set; }

        public float TimeDividendPrice { get; set; }

        public long PlsEarned100KTime { get; set; }
        public double PlsReturn { get; set; }
    }
}