namespace MrGunnChartData.EvmLayer
{
    public interface IReadContract
    {
        long ReturnPlsEarned100KTime(long lastPlsEarned);
        string HexToDecimal(string HexNumber);
    }
}
