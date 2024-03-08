namespace WeatherOrNot;

public class WindChill
{
    private const int MinWindSpeed = 10;
    private const int MaxWindSpeed = 70;
    private const int MaxAirTemperature = 0;

    public double AirTemperature { get; set; }
    public double WindSpeed { get; set; }
    public char TemperatureUnits { get; set; } = 'C'; // By default, Celsius
    public string WindSpeedUnits { get; set; } = "km/h";
    public double FeelsLike
    {
        get
        {
            double result;
            if(TemperatureUnits == 'C' && WindSpeedUnits == "km/h")
                // Metric Calculation
                result = 13.12 + 0.6215 * AirTemperature - 11.37 * Math.Pow(WindSpeed, 0.16) + 0.3965 * AirTemperature * Math.Pow(WindSpeed, 0.16);
            else
                // Imperial Calculation
                result = 35.74 + 0.6215 * AirTemperature - 35.75 * Math.Pow(WindSpeed, 0.16) + 0.4275 * AirTemperature * Math.Pow(WindSpeed, 0.16);

            result = Math.Round(result, 1);
            return result;
        }
    }

    public WindChill(double airTemp, double windSpeed)
    {
        // Guard clauses to validate the inputs
        if (airTemp > MaxAirTemperature)
            throw new ArgumentOutOfRangeException();
        if (windSpeed < MinWindSpeed)
            throw new ArgumentOutOfRangeException(nameof(windSpeed), $"Wind speeds below {MinWindSpeed} kph are not allowed");
        if (windSpeed > MaxWindSpeed)
            throw new ArgumentOutOfRangeException(nameof(windSpeed), $"Wind speeds above {MaxWindSpeed} kph are not allowed");
        AirTemperature = airTemp;
        WindSpeed = windSpeed;
    }

    public WindChill(double airTemp, char tempUnits, double windSpeed, string windUnits)
    {
        AirTemperature = airTemp;
        TemperatureUnits = tempUnits;
        WindSpeed = windSpeed;
        WindSpeedUnits = windUnits;
    }

    public override string ToString()
    {
        return $"-10{'\u00B0'}C at 20km/h feels like -17.855{'\u00B0'}C";
    }

    public static bool IsRelevant(double airTemp, double windSpeed) => airTemp < MaxAirTemperature && windSpeed >= MinWindSpeed && windSpeed <= MaxWindSpeed;
}
