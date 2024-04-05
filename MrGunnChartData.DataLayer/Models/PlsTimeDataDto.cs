namespace MrGunnChartData.DataLayer
{

    public class PlsTimeDataList
    {
        public List<PlsTimeDataWriteDto> plsTimeDataDtos { get; set; }  
    }
    public class PlsTimeDataDto
    {
        public DateTime Date { get; set; }

        public float PlsPrice { get; set; }

        public float TimeDividendPrice { get; set; }

        public long PlsEarned100KTime { get; set; }
        public double PlsReturn { get; set; }
    }

    public class PlsTimeDataWriteDto
    {
        public string Date { get; set; }

        public string PlsPrice { get; set; }

        public string TimeDividendPrice { get; set; }

        public string PlsEarned100KTime { get; set; }
        public string PlsReturn { get; set; }
    }
}