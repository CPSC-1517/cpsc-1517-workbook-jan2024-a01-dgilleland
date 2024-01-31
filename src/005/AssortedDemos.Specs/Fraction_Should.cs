using Assorted;

namespace AssortedDemos.Specs;

public class Fraction_Should
{
    [Fact]
    public void Construct_With_Numerator_And_Denominator()
    {
        // Arrange (Given)
        int givenNumerator = 1, givenDenominator = 10;
        // Act     (When)
        Fraction sut = new(givenNumerator, givenDenominator);
        // Assert  (Then)
        sut.Numerator.Should().Be(givenNumerator);
        sut.Denominator.Should().Be(givenDenominator);
    }

    [Fact]
    public void Represent_As_Text()
    {
        // Arrange
        string expected = "4/5";
        Fraction sut = new(4, 5);
        // Act
        string actual = sut.ToString();
        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void Parse_Text_To_Fraction_Object()
    {
        // Arrange
        string given = "3/7";
        int expectedNumerator = 3, expectedDenominator = 7;
        // Act
        Fraction actual = Fraction.Parse(given);
        // Assert
        actual.Numerator.Should().Be(expectedNumerator);
        actual.Denominator.Should().Be(expectedDenominator);
    }

    [Fact]
    public void TryParse_Text_To_Fraction_Object()
    {
        // Arrange
        string given = "5/7";
        int expectedNumerator = 5, expectedDenominator = 7;
        Fraction parsed;
        // Act
        bool actual = Fraction.TryParse(given, out parsed);
        // Assert
        actual.Should().BeTrue();
        parsed.Numerator.Should().Be(expectedNumerator);
        parsed.Denominator.Should().Be(expectedDenominator);
    }

    [Theory]
    [InlineData("bob")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("4/bob")]
    [InlineData("4")]
    [InlineData("4/5/6")]
    public void Reject_Invalid_Text_When_Parsing(string given)
    {
        // Arrange
        Action act = () => Fraction.Parse(given);
        // Act
        // Assert
        act.Should().Throw<FormatException>();
    }


    [Theory]
    [InlineData("bob")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("4/bob")]
    [InlineData("4")]
    [InlineData("4/5/6")]
    public void Reject_Invalid_Text_When_TryParse(string given)
    {
        // Arrange
        Fraction output;
        // Act
        bool actual = Fraction.TryParse(given, out output);
        // Assert
        actual.Should().BeFalse();
        output.Should().BeNull();
    }
}