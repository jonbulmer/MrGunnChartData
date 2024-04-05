using MrGunnChartData.DataLayer;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using MrGunnChartData.Utilities;
using MrGunnChartData.EvmLayer;

namespace MrGunnChartData.DataLayer.Test;

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

        services.AddTransient<IPlsTimeChartRepository, PlsTimeChartRepository>();
        services.AddTransient<IReadContract, ReadContract>();
        services.AddTransient<IJsonUtility, JsonUtility>();

        return services.BuildServiceProvider();
    }
}
