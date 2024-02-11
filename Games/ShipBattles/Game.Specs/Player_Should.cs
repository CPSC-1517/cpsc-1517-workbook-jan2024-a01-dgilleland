namespace Game.Specs;
using static Game.CellColumn;
using static Game.CellStatus;
using static Game.Fleet;
using static Game.Grid.Direction;

public class Player_Should
{
    #region Construction
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
    public void Construct_With_Fleet()
    {
        Player sut = new("Player Won");
        sut.ShipCount.Should().Be(5);
    }

    [Fact]
    public void Construct_With_Undeployed_Fleet()
    {
        Player sut = new("Player Won");
        sut.IsReady.Should().BeFalse();
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
    #endregion

    #region Ship Placement
    /*
        The Player class will include some "factory"-like methods that allow for the creation of ships by placing them in available spaces in an "invisible" grid; this grid is different than the Grid property that tracks what shots the player has attempted.
        
        The primary factory methods will be 
        - [ ] Ship Place(ShipProfile ship)
        - [ ] Ship Place(ShipProfile ship, Cell location)
        - [ ] Ship[] Place(ShipProfile[] ships)
     */

    [Fact]
    public void Create_Ship_When_Placing_At_Location()
    {
        // Arrange
        Player sut = new("Player Won");
        CellLocation location = new(A, 1);
        // Act
        Ship actual = sut.Place(Fleet.Sub, location, Grid.Direction.Horizontal);
        // Assert
        actual.Should().NotBeNull();
    }

    [Fact]
    public void Place_Ship_At_Location()
    {
        // Arrange
        Player sut = new("Player Won");
        CellLocation givenStartLocation = new(A, 1);
        var expectedPlacement = new CellLocation[] {new(A, 1), new(A, 2)};
        // Act
        Ship actual = sut.Place(Fleet.PTBoat, givenStartLocation, Grid.Direction.Horizontal);
        // Assert
        actual.Location.Should().BeEquivalentTo(expectedPlacement);
    }

    [Fact(Skip = "TODO: Next")]
    public void Be_Ready_When_All_Ships_Placed()
    {
        // Arrange
        Player sut = new("Player Won");
        // Act
        sut.Place(PTBoat, new(A, 1), Horizontal);
        sut.Place(Sub, new(B, 1), Horizontal);
        sut.Place(Destroyer, new(C, 1), Horizontal);
        sut.Place(Battleship, new(D, 1), Horizontal);
        sut.Place(Carrier, new(E, 1), Horizontal);
        // Assert
        sut.IsReady.Should().BeTrue();
    }
    #endregion
}