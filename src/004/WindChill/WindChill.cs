namespace WindChill;

public class WindChill
{
    public double AirTemperature { get; set; }
    public double WindSpeed { get; set; }
    public char TemperatureUnits { get; set; } = 'C'; // By default, Celsius

    public WindChill(double airTemp, double windSpeed)
    {
        AirTemperature = airTemp;
        WindSpeed = windSpeed;
    }
}
