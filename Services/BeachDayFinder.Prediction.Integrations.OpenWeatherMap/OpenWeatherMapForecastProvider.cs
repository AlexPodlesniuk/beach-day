using System.Net.Http.Json;
using BeachDayFinder.Prediction.Domain;
using BeachDayFinder.Prediction.Integrations.OpenWeatherMap.Options;
using Microsoft.Extensions.Options;

namespace BeachDayFinder.Prediction.Integrations.OpenWeatherMap;

internal class OpenWeatherMapForecastProvider : IWeatherForecastProvider
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<WeatherApiOptions> _options;

    public OpenWeatherMapForecastProvider(HttpClient httpClient, IOptions<WeatherApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    public async Task<WeatherWeeklyForecast> PredictWarmestDayAsync(Location requestLocation, CancellationToken cancellationToken)
    {
        var url = PrepareRequestUrl(requestLocation);
        
        var weeklyForecastResponse =
            await _httpClient.GetFromJsonAsync<OpenWeatherMapResponse>(url, cancellationToken: cancellationToken);

        var weeklyPrediction = weeklyForecastResponse
            .Daily
            .OrderBy(x => x.Dt)
            .Skip(1)
            .Select(d => new DayPrediction(d.Dt, d.Temp.Max, d.Humidity))
            .ToArray();
        
        return new WeatherWeeklyForecast(weeklyPrediction);
    }

    private string PrepareRequestUrl(Location requestLocation)
    {
        return $"{_options.Value.ProviderEndpoint}lat={requestLocation.Lat.Value()}&lon={requestLocation.Lat.Value()}&exclude=current,minutely,hourly,alerts&appid={_options.Value.ProviderKey}";
    }
}