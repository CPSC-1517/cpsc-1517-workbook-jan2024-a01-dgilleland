namespace Game;

public class Grid
{
    public enum Direction { Horizontal, Vertical }
    public CellStatus[,] Status { get; } = new CellStatus[10,10];
    public Ship Place(ShipProfile profile, Cell startLocation, Direction direction)
    {
        List<Cell> cells = new();
        cells.Add(startLocation);
        if(direction == Direction.Horizontal)
            for(int size = 1; size < profile.Length; size++)
                cells.Add(new(startLocation.Col, size + startLocation.Row));
        else
            for(int size = 1; size < profile.Length; size++)
                cells.Add(new(size + startLocation.Col, startLocation.Row));
        return new Ship(profile, cells.ToArray());
    }
}