namespace Game;
public class Fleet
{
    #region Properties, Fields, Constants
    #region Named Ship Types
    public const string PTBoat = nameof(PTBoat);
    public const string Sub = nameof(Sub);
    public const string Destroyer = nameof(Destroyer);
    public const string Battleship = nameof(Battleship);
    public const string Carrier = nameof(Carrier);
    #endregion

    private Dictionary<string, ShipProfile> _Profiles = new();
    public ShipProfile this[string ship] => _Profiles[ship];
    public int Count => _Profiles.Count;
    public bool IsDeployed => _Profiles.All(x => x.Value.Ship is not null);
    #endregion

    public Fleet()
    {
        _Profiles.Add(PTBoat, new ShipProfile(PTBoat, 2));
        _Profiles.Add(Sub, new ShipProfile(Sub, 3));
        _Profiles.Add(Destroyer, new ShipProfile(Destroyer, 4));
        _Profiles.Add(Battleship, new ShipProfile(Battleship, 4));
        _Profiles.Add(Carrier, new ShipProfile(Carrier, 5));
    }

    public void Deploy(Ship ship)
    {
        if(IsShipDeployed(ship.Name))
            throw new GameRuleException($"{ship.Name.Value} is already deployed");
        this._Profiles[ship.Name] = _Profiles[ship.Name] with { Ship = ship };
    }
    public bool IsShipDeployed(TrimmedText name)
    {
        bool result = this[name].Ship is not null;
        return result;
    }
}
