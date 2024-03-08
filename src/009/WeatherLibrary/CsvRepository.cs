namespace WeatherSystem;

public static class CsvRepository
{
    public static Location GetLocation(string filePath)
    {
        // Get all the contents of the file
        string[] lines = File.ReadAllLines(filePath);
        Location result = Location.Parse(lines[1]); // Second line of file
        return result;
    }

    public static IEnumerable<string> GetWeatherCSV(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return lines.Skip(4);
    }

    public static void AddWeatherReport(string filePath, Weather record)
    {
        File.AppendAllLines(filePath, new string[] { record.ToString() });
    }
}
