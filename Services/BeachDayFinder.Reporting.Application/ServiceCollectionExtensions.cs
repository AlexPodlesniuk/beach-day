using System.Reflection;
using BeachDayFinder.BuildingBlocks.Application.Behaviors;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeachDayFinder.Reporting.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return serviceCollection;
    }
}