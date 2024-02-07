namespace Game.Specs;

public class Grid_Should
{
    /*
Grid_Should
    - Construct_With_10x10_Status_Array
    - Default_To_Blank_Status_For_All_Positions
    */
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
}
