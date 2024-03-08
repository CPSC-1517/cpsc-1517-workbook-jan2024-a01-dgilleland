namespace WeatherSystem;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Elevation { get; set; }
    public int TimeZoneOffsetSeconds { get; set; }
    public string TimeZone { get; set; } = default!; // remove CS8618
    public string TimeZoneAbbreviation { get; set; } = default!; 

    /// <summary>
    /// This will parse the text as CSV content to produce a Location instance.
    /// CSV format is:
    /// latitude,longitude,elevation,utc_offset_seconds,timezone,timezone_abbreviation
    /// </summary>
    /// <param name="text">The CSV line of text to be parse</param>
    /// <returns>A Location object or a <see cref="FormatException"/>.</returns>
    public static Location Parse(string text)
    {
        if(text is null) throw new FormatException("Unable to parse a null string");
        var parts = text.Split(',');
        if(parts.Length != 6) throw new FormatException("The CSV did not have the correct number of values");
        // I expect the order of the CSV contents to match my documentation
        double lat = double.Parse(parts[0]);
        double longitude = double.Parse(parts[1]);
        double elevation = double.Parse(parts[2]);
        int seconds = int.Parse(parts[3]);
        if(string.IsNullOrWhiteSpace(parts[4]) || string.IsNullOrWhiteSpace(parts[5])) throw new FormatException("Expected text for timezone and timezone abbreviation");

        Location result = new(lat, longitude, elevation, seconds, parts[4], parts[5]);

        return result;
    }

    public Location()
    {
        // As a POCO, I want this class to support instantiation
        // "without" values
    }

    public Location(double lat, double lon, double elevation, int timezoneOffeset, string timezone, string timezoneAbbrev)
    {
        this.Latitude = lat;
        this.Longitude = lon;
        this.Elevation = elevation;
        this.TimeZoneOffsetSeconds = timezoneOffeset;
        this.TimeZone = timezone;
        this.TimeZoneAbbreviation = timezoneAbbrev;
    }

    /// <summary>
    /// Return Location information in CSV format.
    /// </summary>
    /// <returns>string: CSV-formatted string</returns>
    /// <remarks>
    /// The CSV format will match that expected by the <see cref="Parse(string)"/> method.
    /// </remarks>
    public override string ToString()
    {
        // TODO: Check what precision needed for Lat/Long
        return $"{Latitude},{Longitude},{Elevation:F1},{TimeZoneOffsetSeconds},{TimeZone},{TimeZoneAbbreviation}";
    }
}
