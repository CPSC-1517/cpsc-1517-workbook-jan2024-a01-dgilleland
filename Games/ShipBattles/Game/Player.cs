using static Game.Grid;

namespace Game;
public class Player
{
    public TrimmedText Name{get;}
    public int ShipCount => Fleet.Count;
    private Fleet Fleet = new();
    public bool IsReady => Fleet.IsDeployed;
    public Grid Grid { get; }
    public Player(TrimmedText name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Player name information cannot be blank");
        Name = name;
        Grid = new();
    }

    public Ship Place(TrimmedText ship, CellLocation startLocation, Direction direction)
    {
        ShipProfile profile = Fleet[ship];
        List<CellLocation> cells = new();
        cells.Add(startLocation);
        if(direction == Direction.Horizontal)
            for(int size = 1; size < profile.Length; size++)
                cells.Add(new(startLocation.Col, size + startLocation.Row));
        else
            for(int size = 1; size < profile.Length; size++)
                cells.Add(new(size + startLocation.Col, startLocation.Row));
        Ship result = new Ship(profile, cells.ToArray());
        
        return result;
    }
}
