namespace BeachDayFinder.Prediction.Integrations.OpenWeatherMap.Options;

public class WeatherApiOptions
{
    public const string SectionName = "WeatherApi";

    public string ProviderKey { get; init; } = default!;
    public Uri ProviderEndpoint { get; init; } = default!;
}