namespace WindChill.Specs;
// To re-run tests, press [ctrl] + ; then a
public class WindChill_Should
{
    [Fact] // Annotation that identifies this as a test
    public void Construct_With_AirTemperature_And_WindSpeed()
    {
        // Arrange - Setup our test condition
        double givenTemp = -10, givenWind = 20;

        // Act - What it is that we are testing
        // - sut - System/Subject Under Test
        WindChill sut = new(givenTemp, givenWind);

        // Assert - Does it do what it should
        sut.AirTemperature.Should().Be(givenTemp);
        sut.WindSpeed.Should().Be(givenWind);

    }

    [Fact]
    public void Use_Celsius_If_Not_Specified()
    {
        // Arrange
        WindChill sut = new(-10, 20);
        // Act
        var actual = sut.TemperatureUnits;
        // Assert
        actual.Should().Be('C');
    }

    [Fact]
    public void Use_KmPerHour_If_Not_Specified()
    {
        // Arrange
        WindChill sut = new(-10, 20);
        // Act
        string actual = sut.WindSpeedUnits;
        // Assert
        actual.Should().Be("km/h");
    }

    [Fact]
    public void Calculate_Wind_Chill_Using_Default_Units()
    {
        // Arrange
        WindChill sut = new(-10, 20);
        double expected = -17.855; // From our table of test data
        // Act
        var actual = sut.FeelsLike;
        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void Represent_WindChill_As_Text()
    {
        // Arrange
        string expected = $"-10{'\u00B0'}C at 20km/h feels like -17.855{'\u00B0'}C";
        var sut = new WindChill(-10, 20);
        // Act
        string actual = sut.ToString();
        // Assert
        actual.Should().Be(expected);
    }

    [Fact(Skip = "Demo In Class")]
    public void Reject_Temperature_Above_Freezing() {}    

    [Fact(Skip = "Demo In Class")]
    public void Reject_WindSpeed_Below_10kph() {}
    
    [Fact(Skip = "Demo In Class")]
    public void Reject_WindSpeed_Over_70kph() {}
    
    [Fact(Skip = "Demo In Class")]
    public void Represent_Temperature_As_Farenhiet() {}    
    
    [Fact(Skip = "Demo In Class")]
    public void Represent_WindSpeed_As_MilesPerHour() {}
}