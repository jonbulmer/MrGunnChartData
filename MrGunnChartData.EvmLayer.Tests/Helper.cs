using MrGunnChartData.EvmLayer;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using MrGunnChartData.DataLayer;

namespace MrGunnChartData.EvmLayer.Tests;

[ExcludeFromCodeCoverage]
public static class Helper
{

    public static T GetRequiredService<T>()
    {
        var provider = Provider();

        return provider.GetRequiredService<T>();
    }

    private static IServiceProvider Provider()
    {
        var services = new ServiceCollection();

        services.AddTransient<IReadContract, ReadContract>();
        services.AddTransient<IPlsTimeChartRepository, PlsTimeChartRepository>();

        return services.BuildServiceProvider();
    }
}