namespace Game;

public record ShipProfile(TrimmedText Name, NaturalInt Length, ShipStatus Status = ShipStatus.Undamaged, Ship? Ship = null);

public class Ship
{

}