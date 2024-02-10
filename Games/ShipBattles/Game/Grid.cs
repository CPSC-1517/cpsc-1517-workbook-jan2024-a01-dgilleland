namespace Game;

public class Grid
{
    public CellStatus[,] Status { get; } = new CellStatus[10,10];
    public Ship Place(ShipProfile profile, Cell location)
    {
        return new Ship(profile, location);
    }
}