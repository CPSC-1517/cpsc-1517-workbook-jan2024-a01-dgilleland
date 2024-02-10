namespace Game.Specs;

public class Ship_Should
{
    /*
Ship_Should
    - Construct_With_Profile
    - Construct_With_Location
    - Construct_With_Default_Status_Undamaged
    - Reject_Construction_With_Damaged_Status
    */
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
}
