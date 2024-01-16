namespace WindChill.Specs;

public class WindChill_Should
{
    [Fact] // Annotation that identifies this as a test
    public void Construct_With_AirTemperature_And_WindSpeed()
    {
        // Arrange - Setup our test condition
        double givenTemp = -10, givenWind = 20;

        // Act - What it is that we are testing
        // - sut - System Under Test
        WindChill sut = new(givenTemp, givenWind);

        // Assert - Does it do what it should
        sut.AirTemperature.Should().Be(givenTemp);
        sut.WindSpeed.Should().Be(givenWind);
        
    }
}