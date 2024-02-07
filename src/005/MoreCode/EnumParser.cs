namespace System.Text;

public static class EnumParser
{
    public static T Parse<T>(string text)
    {
        return (T) Enum.Parse(typeof(T), text);
    }

    public static bool TryParse<T>(string text, out T result)
    {
        try
        {
            result = Parse<T>(text);
            return true;
        }
        catch
        {   
            result = default;
            return false;
        }
    }
}
