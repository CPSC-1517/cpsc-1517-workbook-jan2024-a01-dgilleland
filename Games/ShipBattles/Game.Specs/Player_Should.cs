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
        Player sut = new("Player Won");
        sut.Name.Should().Be("Player Won");
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

    [Fact(Skip = "TODO")]
    public void Construct_With_Grid()
    {
    }

    [Fact(Skip = "TODO")]
    public void Reject_Blank_PlayerName()
    {
    }
}