// See https://aka.ms/new-console-template for more information
// Using statements must be at the top of the file
using static System.Console; // so we can use Console.WriteLine() as WriteLine()
WriteLine("Hello, Wind-Chill!");
// Check the arguments
int exitCode = 0;
if (args.Length < 2)
{
    if(args.Length == 0 || (args[0] != "--help" && args[0] != "-h"))
        exitCode = ProcessError("Invalid arguments.");

    ShowHelp();
}
else if (args.Length < 4)
{
    // TODO: Parse the arguments and calculate the wind chill
    ForegroundColor = ConsoleColor.Yellow;
    WriteLine("Not Yet Implemented");
    ResetColor();
}
else
{
    exitCode = ProcessError("Invalid arguments.");
    ShowHelp();
}
return exitCode;

void ShowHelp()
{
    WriteLine("This is a CLI to calculate wind chill.");
    WriteLine("Usage: dotnet run -- <temperature> <wind speed> <options>");
    WriteLine();
    WriteLine("Arguments:");
    WriteLine("  <temperature>\tAir Temperature (in Celsius by default)");
    WriteLine("  <wind speed>\tWind Speed (in km/h by default)");
    WriteLine();
    WriteLine("Options:");
    WriteLine("  -f\t\tTemperature in Fahrenheit");
    WriteLine("  -m\t\tWind speed in m/h");
    WriteLine("  --help\tShow this help message");
}

int ProcessError(string message)
{
    ForegroundColor = ConsoleColor.Red;
    WriteLine($"Error: {message}");
    WriteLine("Review the --help for usage information.");
    ResetColor();
    return 1;
}
