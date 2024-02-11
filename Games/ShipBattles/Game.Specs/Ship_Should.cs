namespace Game.Specs;
using static Game.CellColumn;

public class Ship_Should
{
    [Fact]
    public void Construct_With_Profile_And_Location()
    {
        // Arrange
        ShipProfile givenProfile = new("Cruiser", 2);
        CellLocation givenLocation1 = new(A, 1);
        CellLocation givenLocation2 = new(A, 2);
        // Act
        Ship actual = new(givenProfile, givenLocation1, givenLocation2);
        // Assert
        actual.Should().NotBeNull();
    }
    [Fact]
    public void Be_Undamaged_After_Construction()
    {
        Ship sut = new(new(Fleet.PTBoat, 2), new(A,1), new (A,2));
        sut.Status.Should().Be(ShipStatus.Undamaged);
    }
    
    #region Helper methods
    private static IEnumerable<CellLocation> CreateCells(CellColumn col, params int[] rows)
    {
        foreach(int row in rows)
            yield return new(col, row);
    }
    #endregion

    [Theory]
    [InlineData(1)]
    [InlineData(1, 2, 3)]
    public void Require_Cell_Locations_Size_To_Match_Ship_Length(params int[] givenRows)
    {
        // Arrange
        ShipProfile givenProfile = new("Cruiser", 2);
        var givenCells = CreateCells(CellColumn.A,givenRows);
        Action act = () => new Ship(givenProfile, givenCells.ToArray());
        // Act/Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }


    /*
Ship_Should
    - Construct_Within_Blank_Cells
    -
    - Reject_Non_Adjacent_Cells_Horizontally
    - Reject_Non_Adjacent_Cells_Vertically
    - Reject_Disjointed_Cells
    -

    */
}
