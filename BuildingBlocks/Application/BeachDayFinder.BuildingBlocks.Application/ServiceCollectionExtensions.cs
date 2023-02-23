using BeachDayFinder.BuildingBlocks.Domain.Time;
using Microsoft.Extensions.DependencyInjection;

namespace BeachDayFinder.BuildingBlocks.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBuildingBlockApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IClock, SystemClock>();
        return serviceCollection;
    }
}