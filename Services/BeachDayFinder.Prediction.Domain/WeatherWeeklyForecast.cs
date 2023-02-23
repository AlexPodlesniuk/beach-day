namespace BeachDayFinder.Prediction.Domain;

public class WeatherWeeklyForecast
{
    private readonly DayPrediction[] _weeklyForecast;

    public WeatherWeeklyForecast(DayPrediction[] weeklyForecast)
    {
        _weeklyForecast = weeklyForecast;
    }

    public string PerfectBeachDay()
    {
        var perfectDay = _weeklyForecast
            .OrderByDescending(x => x.Temp)
            .ThenBy(x => x.Humidity)
            .First();
        
        var date = DateTimeOffset.FromUnixTimeSeconds(perfectDay.Timestamp);
        
        return date.DayOfWeek.ToString();
    }
}

public record DayPrediction(int Timestamp, double Temp, int Humidity);