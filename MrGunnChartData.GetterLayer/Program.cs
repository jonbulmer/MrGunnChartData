using Microsoft.Extensions.DependencyInjection;
using MrGunnChartData.DataLayer;
using MrGunnChartData.Utilities;
using MrGunnChartData.EvmLayer;
using static System.Net.Mime.MediaTypeNames;

var builder = new ServiceCollection()
    .AddSingleton<IPlsTimeChartRepository, PlsTimeChartRepository>()
    .AddSingleton<IReadContract, ReadContract>()
    .AddSingleton<IJsonUtility, JsonUtility>()
    .BuildServiceProvider();

PlsTimeChartRepository app = (PlsTimeChartRepository)builder.GetRequiredService<IPlsTimeChartRepository>();

app.AddPlsTimeChartData();
Console.WriteLine("Hello, World!");
