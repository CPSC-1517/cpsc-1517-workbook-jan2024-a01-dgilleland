namespace Game;

public class GameRuleException : System.Exception
{
    public GameRuleException() { }
    public GameRuleException(string message) : base(message) { }
    public GameRuleException(string message, System.Exception inner) : base(message, inner) { }
}
