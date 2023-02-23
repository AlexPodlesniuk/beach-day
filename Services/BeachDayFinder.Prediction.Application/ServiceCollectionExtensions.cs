using System.Reflection;
using BeachDayFinder.BuildingBlocks.Application;
using BeachDayFinder.BuildingBlocks.Application.Behaviors;
using BeachDayFinder.Prediction.Integrations.OpenWeatherMap;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeachDayFinder.Prediction.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddBuildingBlockApplication();
        serviceCollection.UseOpenWeatherMapIntegration(configuration);
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        return serviceCollection;
    }
}