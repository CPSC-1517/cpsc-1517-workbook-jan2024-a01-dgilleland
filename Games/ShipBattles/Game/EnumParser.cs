namespace System.Text;

public static class EnumParser
{
    public static TEnum Parse<TEnum>(string text)
    {
        return (TEnum) Enum.Parse(typeof(TEnum), text);
    }

    public static bool TryParse<TEnum>(string text, out TEnum result)
    {
        try
        {
            result = Parse<TEnum>(text);
            return true;
        }
        catch
        {   
            result = default;
            return false;
        }
    }

    public static TEnum Parse<TEnum>(int value)
    {
        if (!typeof(TEnum).IsEnumDefined(value))
            throw new ArgumentOutOfRangeException($"The underlying value {value} is not defined for {typeof(TEnum)}");
        return (TEnum)(object)value;
    }
}
