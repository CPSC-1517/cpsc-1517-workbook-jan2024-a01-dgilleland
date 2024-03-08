using static System.Console;
using WeatherSystem;
using System.Threading.Tasks.Dataflow;

// Expect the following arguments in my CLI:
// - Path to the file
// - A flag indicating which type of data to show
//   - -l or --location for the Location data
//   - -w or --weather for the Weather information
//   - -a or --add to add weather information as a string to be parsed and appended to the file

Clear(); // clear my console

if(args.Length == 2 || args.Length == 3)
{
    string path = args[0];
    string dataFlag = args[1];
    if(dataFlag == "-l" || dataFlag == "--location")
    {
        // retrieve and display the location portion of the CSV data
        try
        {
            Location loc = CsvRepository.GetLocation(path);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(loc);
        }
        catch (System.Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(ex.Message);
            WriteLine(ex.StackTrace);
        }
    }
    else if(dataFlag == "-w" || dataFlag == "--weather")
    {
        try
        {
            var rawData = CsvRepository.GetWeatherCSV(path);
            ForegroundColor = ConsoleColor.Green;
            DateOnly day = DateOnly.MinValue;
            foreach(string row in rawData)
            {
                try
                {
                    // Parse the weather
                    Weather data = Weather.Parse(row);
                    // Show the weather with WindChill if applicable
                    if(day != DateOnly.FromDateTime(data.Time))
                    {
                        day = DateOnly.FromDateTime(data.Time);
                        // Print a "header" for the new day
                        ForegroundColor = ConsoleColor.DarkGreen;
                        WriteLine(day.ToLongDateString());
                        ForegroundColor = ConsoleColor.Green;
                    }
                    Write($"{data.Time.ToShortTimeString()} - {data.Temperature}");
                    if(data.WindChill is not null)
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine($" (feels like {data.WindChill.FeelsLike})");
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        WriteLine();
                    }
                }
                catch (System.Exception ex)
                {
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine(ex.Message);
                    ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        catch (System.Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(ex.Message);
            WriteLine(ex.StackTrace);
        }
    }
    else if(dataFlag == "-a" || dataFlag == "--add")
    {
        if(args.Length != 3)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Expected to be supplied a single CSV string to append to the file when presented with the -a/--add flag");
        }
        else
        {
            try
            {
                // Parse the CSV to see if it's valid
                Weather record = Weather.Parse(args[2]);
                CsvRepository.AddWeatherReport(path, record);
            }
            catch (System.Exception ex)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(ex.Message);
                WriteLine(ex.StackTrace);
            }
        }
    }
}
else
{
    ForegroundColor = ConsoleColor.DarkCyan;
    WriteLine("WeatherCLI Usage");
    WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
    WriteLine("WeatherCLI <path> <option>");
    WriteLine();
    WriteLine("-l, --location     Display location information from the file");
    WriteLine("-w, --weather      List weather records from the file");
    WriteLine("-a, --add <csv>    Add/append a weather record to the file; <csv> must be a valid Weather record");
    WriteLine();
}
// final steps
ResetColor();
