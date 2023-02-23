using BeachDayFinder.Prediction.Domain;
using BeachDayFinder.Prediction.Integrations.OpenWeatherMap.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeachDayFinder.Prediction.Integrations.OpenWeatherMap;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseOpenWeatherMapIntegration(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<WeatherApiOptions>(configuration.GetSection(WeatherApiOptions.SectionName));
        serviceCollection.AddHttpClient();
        serviceCollection.AddTransient<IWeatherForecastProvider, OpenWeatherMapForecastProvider>();
        return serviceCollection;
    }
}