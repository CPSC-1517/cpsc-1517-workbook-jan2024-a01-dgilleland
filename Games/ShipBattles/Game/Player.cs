using static Game.Grid;

namespace Game;

public class Player
{
    public TrimmedText Name{get;}
    public int ShipCount = 5;
    public List<ShipProfile> ShipProfiles { get; }
    public Grid Grid { get; }
    public Player(TrimmedText name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Player name information cannot be blank");
        Name = name;
        Grid = new();
        ShipProfiles = new();
        BuildShips();
    }

    private void BuildShips()
    {
        ShipProfiles.Add(new("Cruiser", 2, ShipStatus.Undamaged));
        ShipProfiles.Add(new("Sub", 3, ShipStatus.Undamaged));
        ShipProfiles.Add(new("Destroyer", 3, ShipStatus.Undamaged));
        ShipProfiles.Add(new("Battleship", 4, ShipStatus.Undamaged));
        ShipProfiles.Add(new("Carrier", 5, ShipStatus.Undamaged));
    }
    
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
