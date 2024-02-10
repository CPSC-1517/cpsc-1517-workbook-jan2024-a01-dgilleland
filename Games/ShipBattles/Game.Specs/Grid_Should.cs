namespace Game.Specs;

public class Grid_Should
{
    #region Grid Construction
    [Fact]
    public void Construct_With_10x10_Status_Array()
    {
        Grid sut = new();
        sut.Status.GetLength(0).Should().Be(10);
        sut.Status.GetLength(1).Should().Be(10);
    }

    [Fact(Skip = "TODO")]
    public void Default_To_Blank_Status_For_All_Positions()
    {

    }
    #endregion

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
        Grid sut = new();
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
        Grid sut = new();
        ShipProfile givenShip = new("Sub", 3);
        Cell location = new(CellColumn.A, 1);
        // Act
        Ship actual = sut.Place(givenShip, location, Grid.Direction.Horizontal);
        // Assert
        // TODO: Make sure that the location on the Grid gets filled with the ship and that the ship's location matches that of the Grid
    }
    #endregion
}
