using System.ComponentModel.DataAnnotations;
using WeatherOrNot;

namespace WeatherSystem;

public class Weather
{
    public Weather() { }
    // public Weather(DateTime time, double temp, double wind, double gust)
    // {
    //     this.Time = time;
    //     this.Temperature = temp;
    //     this.WindSpeed = wind;
    //     this.WindGusts = gust;
    // }

    [Required]
    public DateTime Time { get; set; }

    [Range(-100, 100, ErrorMessage = "Non-typical temperature range for our planet")]
    public double Temperature { get; set; }

    [Range(0, 120, ErrorMessage = "Sustained winds over 120 are considered unrealistic.")]
    public double WindSpeed { get; set; }

    [Range(0, 200, ErrorMessage = "Wind gusts over 200 are likely to be damaging the instruments; please check your input")]
    public double WindGusts { get; set; }

    public WindChill? WindChill => WindChill.IsRelevant(Temperature, WindSpeed) ? new(Temperature, WindSpeed) : default;
    public WindChill? MaxWindChill => WindChill.IsRelevant(Temperature, WindGusts) ? new(Temperature, WindGusts) : default;

    public override string ToString()
    {
        return $"{Time.ToString("yyyy-MM-ddTHH:mm")},{Temperature:F1},{WindSpeed:F1},{WindGusts:F1}";
    }

    public static Weather Parse(string text)
    {
        if (text is null) throw new FormatException("Cannot parse weather data from a null string");
        string[] parts = text.Split(',');
        if (parts.Length != 4) throw new FormatException($"Expected 4 parts to the Weather CSV string, but found {parts.Length} parts");
        DateTime time = DateTime.Parse(parts[0]);
        double temp = double.Parse(parts[1]);
        double wind = double.Parse(parts[2]);
        double gust = double.Parse(parts[3]);
        // NOTE: I switched from my greedy constructor to 
        // an initializer list
        Weather result = new()
        {
            Time = time,
            Temperature = temp,
            WindSpeed = wind,
            WindGusts = gust
        };
        return result;
    }
}
