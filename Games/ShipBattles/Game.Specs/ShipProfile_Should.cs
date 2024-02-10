namespace Game.Specs;

public class ShipProfile_Should
{
    /*
    ShipProfile_Should
    - 
    - 
    - 
    */
    [Fact]
    public void Construct_With_Undamaged_ShipStatus_By_Default()
    {
        ShipProfile sut = new("Sub", 3);
        sut.Status.Should().Be(ShipStatus.Undamaged);
    }
 
    [Fact]
    public void Construct_Without_A_Placed_Ship()
    {
        ShipProfile sut = new("Sub", 3);
        sut.Ship.Should().BeNull();
    }

    [Fact]
    public void Construct_As_Not_Placed_On_A_Grid()
    {
        ShipProfile sut = new("Sub", 3);
        sut.IsPlaced.Should().BeFalse();
    }
}
