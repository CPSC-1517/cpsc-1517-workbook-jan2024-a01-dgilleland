using static System.Console;
namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        if (args.Length == 0)
            WriteLine("\tNo information was passed to this program.");
        else
            foreach (string info in args)
                WriteLine($"\t{info}");

    }
}