namespace BeachDayFinder.Prediction.Domain;

public record Location(Coordinate Lat, Coordinate Lon)
{
    public bool IsEnEurope()
    {
        var coordsChecked = Lat.IsValidCoordinate() && Lon.IsValidCoordinate();
        if (!coordsChecked)
            return false;
        var lat = Lat.Value();
        var lon = Lon.Value();

        return lat is >= 34 and <= (decimal)71.0 
               && lon is >= (decimal)-9.5 and <= 60;
    }
}