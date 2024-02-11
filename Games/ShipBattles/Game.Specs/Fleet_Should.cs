namespace Game.Specs;
using static Game.Fleet;
using static Game.CellColumn;

public class Fleet_Should
{
    /*
        A fleet should consist of a standard set of static ship profiles:
        - Cruiser
        - Sub
        - Destroyer
        - Battleship
        - Carrier

        A new fleet should have all ship profiles start as Undamaged.
    */
    [Theory]
    [InlineData(PTBoat, 2)]
    [InlineData(Sub, 3)]
    [InlineData(Destroyer, 4)]
    [InlineData(Battleship, 4)]
    [InlineData(Carrier, 5)]
    public void Have_Specific_Ship_Profile(string name, int length)
    {
        // Arrange
        NaturalInt expectedLength = length;
        Fleet sut = new();
        // Act
        var actual = sut[name];
        // Assert
        actual.Should().NotBeNull();
        actual.Length.Should().Be(expectedLength);
        actual.IsPlaced.Should().BeFalse();
        actual.Name.Value.Should().Be(name);
    }

    [Fact]
    public void Deploy_Ship()
    {
        Fleet sut = new();
        Ship given = new(sut[PTBoat], new (A,1), new(A,2));
        sut.Deploy(given);
        bool actual = sut.IsShipDeployed(PTBoat);
    }

    [Theory]
    [InlineData(PTBoat)]
    [InlineData(Sub)]
    [InlineData(Destroyer)]
    [InlineData(Battleship)]
    [InlineData(Carrier)]
    public void Not_Have_Ship_Deployed(string givenName)
    {
        Fleet sut = new();
        var actual = sut.IsShipDeployed(givenName);
        actual.Should().BeFalse();
    }

    [Fact]
    public void Reject_Deploying_Same_Ship_Twice()
    {
        // Arrange
        Fleet sut = new();
        Ship given = new(sut[PTBoat], new (A,1), new(A,2));
        Action act = () => sut.Deploy(given);
        // Act
        act(); // First deployment
        // Assert
        act.Should().Throw<GameRuleException>().WithMessage("PTBoat is already deployed");
    }

}
