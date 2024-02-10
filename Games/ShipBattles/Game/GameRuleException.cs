namespace Game;

/*
    This file holds an assorted set of enumerations and record types related to cells in the Grid.
    Because the types are so simple while being closely related, they are being kept in this single file for clarity/cross-referencing.
 */

[System.Serializable]
public class GameRuleException : System.Exception
{
    public GameRuleException() { }
    public GameRuleException(string message) : base(message) { }
    public GameRuleException(string message, System.Exception inner) : base(message, inner) { }
    protected GameRuleException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
