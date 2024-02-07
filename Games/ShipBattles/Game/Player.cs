namespace Game;

public class Player
{
    public string Name{get;}
    public int ShipCount = 5;
    public List<ShipProfile> ShipProfiles { get; }
    public Player(string name)
    {
        Name = name;
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
}
