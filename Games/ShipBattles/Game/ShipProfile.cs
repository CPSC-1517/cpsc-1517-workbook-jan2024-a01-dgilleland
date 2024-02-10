namespace Game;

public record ShipProfile(TrimmedText Name, NaturalInt Length, ShipStatus Status = ShipStatus.Undamaged, Ship? Ship = null)
{
    public bool IsPlaced => Ship is not null;
}

public class Ship
{
    public Ship(ShipProfile profile, params Cell[] cellLocations)
    {
        
    }
}