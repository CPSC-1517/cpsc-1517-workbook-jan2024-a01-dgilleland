namespace Game.Specs;

// TODO: Consider publishing as a NuGet package for controlled testing
public class Randomness_Should
{
    #region Shared for testing game parts that use randomness
    public const int _Seed = 42;
    public static IEnumerable<int> Predictable_For_Next_1_To_11 => new List<int>()
        { 7, 2, 2, 6, 2, 3, 8, 6, 2, 8, 3, 3, 6, 4, 4, 3, 6, 1, 9, 6 };

    #endregion

    [Fact]
    public void Be_Predictable_For_First_Number()
    {
        Random sut = new Random(_Seed);
        var actual = sut.Next(1,11);
        actual.Should().Be(7);
    }

    [Fact]
    public void Be_Predictable_20_Number_For_Next_1_To_11()
    {
        Random sut = new Random(_Seed);
        IEnumerable<int> expected = Predictable_For_Next_1_To_11.Take(20);

        var actual = Enumerable.Range(1, 20).Select(x => sut.Next(1, 11));

        actual.Should().BeEquivalentTo(expected);
    }
}
