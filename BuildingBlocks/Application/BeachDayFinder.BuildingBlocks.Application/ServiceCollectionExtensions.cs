using Microsoft.Extensions.DependencyInjection;

namespace BeachDayFinder.BuildingBlocks.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBuildingBlockApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}