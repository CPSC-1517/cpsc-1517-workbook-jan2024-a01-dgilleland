namespace Game.Specs;
/*
Unit tests always test the behaviour of your code
- Creating your objects
- Using your objects

Game_Should
    - Construct_With_Two_Players
    - Identify_Winning_Player
Ship_Should
    - Construct_With_Length
    - Construct_With_Location
    - Construct_With_Default_Status_Undamaged
Cell_Should
    - Construct_With_Column_Row_Status
    - Reject_Invalid_Column
    - Reject_Invalid_Row
Grid_Should
    - Construct_With_10x10_Status_Array
    - Default_To_Blank_Status_For_All_Positions
Player_Should
    - Construct_With_PlayerName
    - Construct_With_5_Ships
    - Construct_With_Grid
    - Reject_Blank_PlayerName
*/

public class Player_Should
{
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

    [Fact]
    public void Construct_With_Grid()
    {
    }

    [Fact]
    public void Reject_Blank_PlayerName()
    {
    }
}