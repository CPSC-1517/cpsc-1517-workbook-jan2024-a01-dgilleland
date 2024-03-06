namespace WeatherSystem;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Elevation { get; set; }
    public int TimeZoneOffsetSeconds { get; set; }
    public string TimeZone { get; set; } = default!; // remove CS8618
    public string TimeZoneAbbreviation { get; set; } = default!;

    public Location()
    {
        // As a POCO, I want this class to support instantiation
        // "without" values
    }

    public Location(double lat, double lon, double elevation, int timezoneOffset, string timezone, string timezoneAbbrev)
    {
        this.Latitude = lat;
        this.Longitude = lon;
        this.Elevation = elevation;
        this.TimeZoneOffsetSeconds = timezoneOffset;
        this.TimeZone = timezone;
        this.TimeZoneAbbreviation = timezoneAbbrev;
    }

    public override string ToString()
    {
        return $"{Latitude:F5},{Longitude:F5},{Elevation:F1},{TimeZoneOffsetSeconds},{TimeZone},{TimeZoneAbbreviation}";
    }


    public static Location Parse(string text)
    {
        if(text is null) throw new FormatException("Cannot create a Location from a null string");
        
        string[] parts = text.Split(',');
        if(parts.Length != 6) throw new FormatException("Expected 6 parts to the CSV structure in order to generate Location information");

        double lat = double.Parse(parts[0]);
        double lng = double.Parse(parts[1]);
        double elevation = double.Parse(parts[2]);
        int timeOffset = int.Parse(parts[3]);
        if(string.IsNullOrWhiteSpace(parts[4]))
            throw new FormatException("timezone information is missing");
        if(string.IsNullOrWhiteSpace(parts[5]))
            throw new FormatException("timezone abbreviation is missing");
        
        Location result = new(lat, lng, elevation, timeOffset, parts[4], parts[5]);

        return result;
    }
}
