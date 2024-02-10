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
    #endregion
}
