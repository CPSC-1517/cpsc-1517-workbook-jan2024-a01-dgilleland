namespace Assorted;

public class Fraction
{
    public int Numerator { get; }
    public int Denominator { get; }
    public Fraction(int numerator, int denominator)
    {
        // The purpose of a constructor is to ensure all properties/fields have meaningful values
        Numerator = numerator;
        Denominator = denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public static Fraction Parse(string text)
    {
        // Guard Clause
        if(text is null)
            throw new FormatException("null value is not a valid fraction");
        // Actual work
        string[] parts = text.Split('/');
        if(parts.Length != 2)
            throw new FormatException();
        int num = int.Parse(parts[0]);
        int denom = int.Parse(parts[1]);
        return new(num, denom);
    }

    public static bool TryParse(string given, out Fraction parsed)
    {
        try
        {
            parsed = Parse(given);
            return true;
        }
        catch (System.Exception)
        {
            parsed = default;
            return false;
        }
    }

    #region Operator Overloads
    public static Fraction operator *(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Numerator;
        int denom = a.Denominator * b.Denominator;
        return new(num, denom);
    }
    #endregion
}
