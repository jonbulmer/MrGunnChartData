using MrGunnChartData.EvmLayer;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using MrGunnChartData.Utilities;

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
        services.AddTransient<IJsonUtility, JsonUtility>();

        return services.BuildServiceProvider();
    }
}