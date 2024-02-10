namespace Game;

public record NaturalInt
{
    public int Value{ get; }
    public NaturalInt(int value)
    {
        if(value <= 0)
            throw new ArgumentOutOfRangeException("Natural integers must be whole numbers greater than zero");
        Value = value;
    }
    public static implicit operator NaturalInt(int value) => new(value);
    public static implicit operator int(NaturalInt number) => number.Value;
}