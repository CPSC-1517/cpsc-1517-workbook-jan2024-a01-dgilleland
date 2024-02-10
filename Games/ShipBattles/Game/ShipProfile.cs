namespace Game;

public record ShipProfile(TrimmedText Name, NaturalInt Length, ShipStatus Status = ShipStatus.Undamaged, Ship? Ship = null)
{
    public bool IsPlaced => Ship is not null;
}

public class Ship
{
    public Ship(ShipProfile profile, params Cell[] cellLocations)
    {
        if(profile.Length != cellLocations.Length)
            throw new ArgumentOutOfRangeException();
        if(cellLocations.Any(x => x.Status != CellStatus.Blank))
            throw new GameRuleException("Ship cannot be created on a cell that has already been targetted as a hit or miss");
    }
}