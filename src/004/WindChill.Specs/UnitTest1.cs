using Xunit.Sdk;

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
        double expected = -17.9; // From our table of test data
        // Act
        var actual = sut.FeelsLike;
        // Assert
        actual.Should().Be(expected);
    }

    [Fact()]
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

    [Fact()]
    public void Reject_Temperature_Above_Freezing()
    {
        // Arrange
        Action act = () => new WindChill(1, 20);
        //           \/    \__________________/
        //            |      |_   <-- Return Value
        //            |_  <-- parameter-less inputs (nothing being input)
        //           \________________________/  <-- A shorthand function declaration
        //    act()
        // Act
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Reject_WindSpeed_Below_10kph()
    {
        // Arrange
        Action act = () => new WindChill(-5, 9);
        // Act
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Wind speeds below 10 kph are not allowed*");
        // Note the * at the start/end of the message - those are "wild cards"
    }

    [Fact]
    public void Reject_WindSpeed_Over_70kph()
    {
        // Arrange
        Action act = () => new WindChill(0, 71);
        // Act/Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Wind speeds above 70 kph are not allowed*");
    }

    [Fact]
    public void Represent_Temperature_As_Farenhiet()
    {
        // Arrange
        WindChill sut = new(32, 'F', 10, "m/h");

        // Act
        var actualTemp = sut.AirTemperature;
        var actualUnits = sut.TemperatureUnits;

        // Assert
        actualTemp.Should().Be(32);
        actualUnits.Should().Be('F');
    }

    [Fact]
    public void Represent_WindSpeed_As_MilesPerHour()
    {
        // Arrange
        WindChill sut = new(32, 'F', 10, "m/h");

        // Act
        var actualSpeed = sut.WindSpeed;
        var actualUnits = sut.WindSpeedUnits;

        // Assert
        actualSpeed.Should().Be(10);
        actualUnits.Should().Be("m/h");
    }

    [Theory]
    [InlineData(-10, 'C', 20, "km/h")]
    [InlineData(32, 'F', 10, "km/h")]
    public void Represent_WindChill_Inputs_With_Explicit_Units(double givenAir, char givenTempUnits, double givenWind, string givenWindUnits)
    {
        // Arrange
        // Act
        WindChill sut = new(givenAir, givenTempUnits, givenWind, givenWindUnits);

        // Assert
        sut.AirTemperature.Should().Be(givenAir);
        sut.TemperatureUnits.Should().Be(givenTempUnits);

        sut.WindSpeed.Should().Be(givenWind);
        sut.WindSpeedUnits.Should().Be(givenWindUnits);
    }

    [Theory]
    [InlineData(-10, 'C', 20, "km/h", -17.9)]
    [InlineData(32, 'F', 10, "m/h", 23.7)]
    public void Calculate_WindChill_From_Explicit_Units(double givenAir, char givenTempUnits, double givenWind, string givenWindUnits, double expectedWindChill)
    {
        // Arrange
        WindChill sut = new(givenAir, givenTempUnits, givenWind, givenWindUnits);

        // Act
        var actual = sut.FeelsLike;
        // Assert
        actual.Should().Be(expectedWindChill);
    }
}