using static System.Console;
using WeatherSystem;
// Presume the first argument is the path to the file
string path = args[0];
Location place = CsvRepository.GetLocation(path);
Clear();
ForegroundColor = ConsoleColor.Yellow;
WriteLine(place);
ResetColor();
