namespace BeachDayFinder.Prediction.Integrations.OpenWeatherMap;

public class OpenWeatherMapResponse
{
    public List<Daily> Daily { get; set; }
}

public class Daily
{
    public int Dt { get; set; }
    public Temp Temp { get; set; }
    public int Humidity { get; set; }
}

public class Temp
{
    public double Max { get; set; }
}
