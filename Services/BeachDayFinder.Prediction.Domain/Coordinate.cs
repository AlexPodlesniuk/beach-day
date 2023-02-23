using System.Globalization;
using System.Text.RegularExpressions;

namespace BeachDayFinder.Prediction.Domain;

public class Coordinate
{
    private readonly bool _isValid;
    private readonly decimal _value;
    public Coordinate(string coord)
    {
        _isValid = Regex.Match(coord, @"^\d{0,2}([.,]\d{0,6})?$").Success;
        _value = _isValid ? decimal.Parse(coord, NumberStyles.Float, CultureInfo.InvariantCulture) : 0;
    }

    public bool IsValidCoordinate() => _isValid;
    
    public decimal Value() => _value;
}