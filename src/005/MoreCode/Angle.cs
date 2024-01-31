namespace Assorted;

public class Angle
{
    public double Degrees { get; set; }
    public double Radians
    {
        get
        {
            return Degrees * (Math.PI / 180);
        }
    }

    public Angle(double value)
    {
        Degrees = value;
    }
}