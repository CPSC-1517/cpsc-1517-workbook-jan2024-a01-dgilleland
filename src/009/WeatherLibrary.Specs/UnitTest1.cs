namespace WeatherSystem.Specs;

public class Location_Should
{
    [Fact]
    public void Produce_Same_CSV_String_It_Was_Parsed_From()
    {
        // CSV format is:
        // latitude,longitude,elevation,utc_offset_seconds,timezone,timezone_abbreviation
        string givenCSV = "53.60281,-113.27586,614.0,-25200,America/Edmonton,MST";
        Location sut = Location.Parse(givenCSV);
        string actual = sut.ToString();
        actual.Should().Be(givenCSV);
    }
}