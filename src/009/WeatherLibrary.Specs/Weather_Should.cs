namespace WeatherSystem.Specs;

public class Weather_Should
{
    [Theory]
    [InlineData("2024-01-30T00:00,3.7,14.1,23.0")]
    [InlineData("2024-01-30T01:00,4.7,16.5,25.9")]
    [InlineData("2024-01-30T23:00,-0.9,10.2,14.8")]
    [InlineData("2024-02-29T00:00,1.0,2.0,3.0")]
    public void Produce_Same_CSV_String_It_Was_Parsed_From(string givenCsv)
    {
        // time,temperature_2m (°C),wind_speed_10m (km/h),wind_gusts_10m (km/h)
        Weather sut = Weather.Parse(givenCsv);
        sut.ToString().Should().Be(givenCsv);
    }
}
