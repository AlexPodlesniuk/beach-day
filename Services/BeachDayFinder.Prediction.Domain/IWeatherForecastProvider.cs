namespace BeachDayFinder.Prediction.Domain;

public interface IWeatherForecastProvider
{
    Task<WeatherWeeklyForecast> PredictWarmestDayAsync(Location requestLocation, CancellationToken cancellationToken);
}