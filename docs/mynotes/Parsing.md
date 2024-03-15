# Parsing

## Standard `.Parse(string text)`

## Universal `.TryParse(string text, out type result)`

## Parsing Enumerations

When parsing a string into an enumerated type, you need to use the `Enum.Parse` method and perform an explicit cast to get the appropriate type. Consider the following enumeration type:

```cs
public enum DayOfWeek { Sun, Mon, Tue, Wed, Thu, Fri, Sat }
```

To parse a string into this type, you would code the following.

```cs
DayOfWeek today;
string someText;
// some code that gets a string value from somewhere
today = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), someText);
```

### Creating a Universal Parser

```cs
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
```
