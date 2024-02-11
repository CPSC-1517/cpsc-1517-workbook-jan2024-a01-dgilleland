namespace Game;

public record ShipProfile(TrimmedText Name, NaturalInt Length, ShipStatus Status = ShipStatus.Undamaged, Ship? Ship = null)
{
    public bool IsPlaced => Ship is not null;
}

public class Ship
{
    public IEnumerable<CellLocation> Location { get; }
    private ShipProfile _Profile;
    public ShipStatus Status => _Profile.Status;
    public TrimmedText Name => _Profile.Name;

    public Ship(ShipProfile profile, params CellLocation[] cellLocations)
    {
        if(profile.Length != cellLocations.Length)
            throw new ArgumentOutOfRangeException();
        // if(cellLocations.Any(x => x.Status != CellStatus.Blank))
        //     throw new GameRuleException("Ship cannot be created on a cell that has already been targetted as a hit or miss");
        Location = cellLocations;
        _Profile = profile with { Ship = this };
    }
}