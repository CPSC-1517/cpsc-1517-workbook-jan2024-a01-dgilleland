namespace Game.Specs;
using static Game.CellStatus;
using static Game.CellColumn;

/*
Unit tests always test the behaviour of your code
- Creating your objects
- Using your objects
*/
public class Cell_Should
{
    /*
Cell_Should
    - Construct_With_Column_Row_Status
    - Reject_Invalid_Column
    - Reject_Invalid_Row
    */
    [Fact]
    public void Construct_With_Column_Row_Status()
    {
        Cell sut = new(A, 4, Hit);
        sut.Status.Should().Be(Hit);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(11)]
    public void Reject_Invalid_Column(int given)
    {
        Action act = () => new Cell(given, 4, Blank);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(11)]
    public void Reject_Invalid_Row(int given)
    {
        Action act = () => new Cell(A, given, Blank);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}

