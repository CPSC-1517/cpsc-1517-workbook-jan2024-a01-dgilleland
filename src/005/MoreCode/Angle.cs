namespace Assorted;
public class Angle
{
    // Auto-implemented property
    public double Degrees { get; set; }
    // Explicitly implemented property (get method only)
    public double Radians
    {
        get { return Degrees * (Math.PI / 180); }
    }
    // Explicitly implemented property (get, using a lambda expression)
    public double Grads => Radians * (200 / Math.PI);

    public Angle(double value)
    {
        Degrees = value;
    }

    public override string ToString()
    {
        return $"{Degrees}{'\u00B0'}";
    }

    public static Angle FromRadians(double value)
    {
        double deg = value * (180 / Math.PI);
        return new(deg);
    }
}