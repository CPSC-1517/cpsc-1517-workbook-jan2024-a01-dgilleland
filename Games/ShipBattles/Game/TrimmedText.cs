namespace Game;

public record TrimmedText
{
    public string Value{ get; }
    public TrimmedText(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException("Text must be a non-null, non-empty string");
        Value = value.Trim();
    }
    public static implicit operator TrimmedText(string value) => new(value);
    public static implicit operator string(TrimmedText text) => text.Value;
}
