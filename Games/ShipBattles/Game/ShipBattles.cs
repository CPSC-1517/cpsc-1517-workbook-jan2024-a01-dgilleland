namespace Game;

public class ShipBattles
{
    public Random Random { get; } = Random.Shared;
    private Player _PlayerOne;
    private Player _PlayerTwo;
    public TrimmedText PlayerOne => _PlayerOne.Name;
    public TrimmedText PlayerTwo => _PlayerTwo.Name;
    public bool IsReadyToPlay { get; private set; }
    public bool Over => false;
    public string? Winner => null;

    public ShipBattles(string playerOne, string playerTwo)
    {
        _PlayerOne = new(playerOne);
        _PlayerTwo = new(playerTwo);
    }
    public ShipBattles(string playerOne, string playerTwo, int randomSeed) : this(playerOne, playerTwo)
    {
        Random = new(randomSeed);
    }

    public void Setup()
    {
        IsReadyToPlay = true;
    }

    public Grid RevealFleetPositions(string playerName)
    {
        return RevealFleetPositions(new TrimmedText(playerName));
    }
    public Grid RevealFleetPositions(TrimmedText playerName)
    {
        // NOTE: Right now, I'm revealing the player's GRID rather than their fleet positions. I think I need a better property name on the player than "Grid", so as to distinguish between the position of the player's fleet (which this method is supposed to reveal) vs. the player AttackRecord.
        if(PlayerOne == playerName)
            return _PlayerOne.Grid;
        else
            return _PlayerTwo.Grid;
    }

    public int ShotsFired(TrimmedText playerName)
    {
        return 0;
    }
}
