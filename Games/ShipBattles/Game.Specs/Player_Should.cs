namespace Game.Specs;

public class Player_Should
{
    /*
Player_Should
    - Construct_With_PlayerName
    - Construct_With_5_Ships
    - Construct_With_Grid
    - Reject_Blank_PlayerName
    */
    [Fact]
    public void Construct_With_PlayerName()
    {
        TrimmedText expected = "Player Won";
        Player sut = new("Player Won");
        sut.Name.Should().Be(expected);
    }

    [Fact]
    public void Construct_With_5_Ships()
    {
        var expected = new List<ShipProfile>
        {
            new("Cruiser", 2, ShipStatus.Undamaged),
            new("Sub", 3, ShipStatus.Undamaged),
            new("Destroyer", 3, ShipStatus.Undamaged),
            new("Battleship", 4, ShipStatus.Undamaged),
            new("Carrier", 5, ShipStatus.Undamaged)
        };
        Player sut = new("Player Won");
        sut.ShipCount.Should().Be(5);
        sut.ShipProfiles.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Construct_With_Grid()
    {
        Player sut = new("Player Won");
        sut.Grid.Should().NotBeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Reject_Blank_PlayerName(string givenName)
    {
        Action act = () => new Player(givenName);
        act.Should().Throw<ArgumentNullException>();
    }

    #region Ship Placement
    /*
        The Grid class will include some "factory"-like methods that allow for the creation of ships by placing them on the grid. The primary factory methods will be 
        Ship Place(ShipProfile ship)
        Ship Place(ShipProfile ship, Cell location)
        Ship[] Place(ShipProfile[] ships)
     */
    [Fact]
    public void Create_Ship_When_Placing_At_Location()
    {
        // Arrange
        Player sut = new("Player Won");
        ShipProfile givenShip = new("Sub", 3);
        Cell location = new(CellColumn.A, 1);
        // Act
        Ship actual = sut.Place(givenShip, location, Grid.Direction.Horizontal);
        // Assert
        actual.Should().NotBeNull();
    }

    [Fact(Skip = "TODO")]
    public void Place_Ship_At_Location()
    {
        // Arrange
        Player sut = new("Player Won");
        ShipProfile givenShip = new("Sub", 3);
        Cell location = new(CellColumn.A, 1);
        // Act
        Ship actual = sut.Place(givenShip, location, Grid.Direction.Horizontal);
        // Assert
        // TODO: Make sure that the location on the Grid gets filled with the ship and that the ship's location matches that of the Grid
    }
    #endregion
}