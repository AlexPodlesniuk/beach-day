using BeachDayFinder.BuildingBlocks.Persistence.Mongo;
using BeachDayFinder.Reporting.Domain.HistoryItem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeachDayFinder.Reporting.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDbPersistence(configuration);
        services.AddTransient<IHistoryItemRepository, MongoHistoryItemRepository>();
        return services;
    }
}