namespace Game.Specs;

public class Ship_Should
{
    [Fact]
    public void Construct_With_Profile_And_Location()
    {
        // Arrange
        ShipProfile givenProfile = new("Cruiser", 2);
        Cell givenLocation1 = new(CellColumn.A, 1);
        Cell givenLocation2 = new(CellColumn.A, 2);
        // Act
        Ship actual = new(givenProfile, givenLocation1, givenLocation2);
        // Assert
        actual.Should().NotBeNull();
    }

    private static IEnumerable<Cell> CreateCells(CellColumn col, params int[] rows)
    {
        foreach(int row in rows)
            yield return new(col, row);
    }
    private static IEnumerable<Cell> CreateCells(CellColumn col, CellStatus status, params int[] rows)
    {
        foreach(int row in rows)
            yield return new(col, row, status);
    }

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

    [Theory]
    [InlineData(CellStatus.Hit)]
    [InlineData(CellStatus.Miss)]
    public void Reject_Construction_Within_Targeted_Cells(CellStatus given)
    {
        // Arrange
        ShipProfile givenProfile = new("Cruiser", 2);
        var givenCells = CreateCells(CellColumn.A, given, 1, 2);
        Action act = () => new Ship(givenProfile, givenCells.ToArray());
        // Act/Assert
        act.Should().Throw<GameRuleException>().WithMessage("*Ship cannot be created on a cell that has already been targetted as a hit or miss*");
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
