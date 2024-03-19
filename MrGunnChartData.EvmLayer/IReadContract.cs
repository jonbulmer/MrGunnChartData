namespace MrGunnChartData.EvmLayer
{
    public interface IReadContract
    {
        long ReturnTotalSupply();
        long HexToDecimal(string HexNumber);
    }
}
