namespace Game.Specs;
using Game = Game.ShipBattles;
using static Randomness_Should;

public class Game_Should
{
    /*
Game_Should
    - 
    */
    #region Test Helper Fields/Properties
    #region Private fields and constants
    const string PlayerOne = "Player Won";
    const string PlayerTwo = "Player Too";
    static IEnumerable<int> Sequence = Predictable_For_Next_1_To_11;
    #endregion

    #region Properties for SUT testing
    private Game TwoPlayerRandomGame => new(PlayerOne, PlayerTwo);
    private Game TwoPlayerPredictableGame => new(PlayerOne, PlayerTwo, _Seed);
    #endregion
    #endregion

    #region Construct Game (before Setup)
    [Fact]
    public void Construct_With_Two_Players()
    {
        Game sut = TwoPlayerRandomGame;
        string actualPlayerOne = 
        sut.PlayerOne;
        string actualPlayerTwo = sut.PlayerTwo;
        
        actualPlayerOne.Should().Be(PlayerOne);
        actualPlayerTwo.Should().Be(PlayerTwo);
    }

    [Fact]
    public void Not_Be_Over()
    {
        var sut = TwoPlayerRandomGame;
        sut.Over.Should().BeFalse();
    }

    [Fact]
    public void Not_Have_Winner_At_Start()
    {
        var sut = TwoPlayerRandomGame;
        sut.Winner.Should().BeNull();
    }

    [Fact]
    public void Not_Be_Ready_At_First()
    {
        Game sut = TwoPlayerRandomGame;
        sut.IsReadyToPlay.Should().BeFalse();
    }
    
    [Fact]
    public void Reveal_Empty_Grid_Player_One_After_Construction()
    {
        Game sut = TwoPlayerRandomGame;
        Grid expected = new Grid();
        Grid actual = sut.RevealFleetPositions(PlayerOne);
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(PlayerOne)]
    [InlineData(PlayerTwo)]
    public void Reveal_No_Shots_Fired(string givenName)
    {
        Game sut = TwoPlayerRandomGame;
        int actual = sut.ShotsFired(PlayerOne);
        actual.Should().Be(0);
    }

    [Fact]
    public void Use_Shared_Random_By_Default()
    {
        Game sut = TwoPlayerRandomGame;
        sut.Random.Should().Be(Random.Shared);
    }

    [Fact]
    public void Allow_Random_Number_Generator_Injection()
    {
        // Arrange
        var expected = Sequence.Take(5);
        // Act
        Game sut = new(PlayerOne, PlayerTwo, _Seed);
        // Assert
        sut.Random.Should().NotBe(Random.Shared);
        // Act 2
        var actualSequence = Enumerable.Range(1,5).Select(x => sut.Random.Next(1, 11));
        // Assert 2
        actualSequence.Should().BeEquivalentTo(expected);
    }
    #endregion

    #region Game Immediately After Setup
    [Fact]
    public void Ready_To_Play_After_Setup()
    {
        Game sut = TwoPlayerRandomGame;
        sut.Setup();
        sut.IsReadyToPlay.Should().BeTrue();
    }
    #endregion

    #region Queue/Sort
    [Fact(Skip = "TODO: Plan out how I might handle tracking randomness through the game...")]
    public void Not_Have_Shared_Sequence_Logger()
    {
        
    }
    #endregion
}
