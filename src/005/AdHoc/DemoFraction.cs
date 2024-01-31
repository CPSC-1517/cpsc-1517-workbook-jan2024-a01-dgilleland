namespace AdHoc;
using static System.Console;
using Assorted;

public class DemoFraction
{
    public static void Run(string[] args)
    {
        if(args.Length > 2 && args[0] == "-f")
        {
            // Treat all the args except the first as fraction strings
            string[] values = args.Skip(1).ToArray();
            var fractions = parseFractions(values);
            Fraction result = new(1,1);
            foreach(var number in fractions)
                result = result * number;
            Write("The final value is ");
            ForegroundColor = ConsoleColor.Green;
            Write(result);
            ResetColor();
            WriteLine($" (from {fractions.Count} numbers)");
        }
        else
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("No values supplied for multiplying fractions");
        }
        ResetColor();
    }
    private static List<Fraction> parseFractions(string[] strings)
    {
        List<Fraction> result = new();
        foreach(var item in strings)
            result.Add(Fraction.Parse(item));
        return result;
    }
}
