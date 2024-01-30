namespace Assorted;

public class Coin
{
    public enum CoinFace { Heads, Tails }

    private static Random Rnd = new Random();
    public CoinFace FaceShowing { get; private set; }
    public Coin()
    {
        Toss();
    }

    public void Toss()
    {
        // Set the coin face to randomly be heads or tails
        if(Rnd.Next(2) == 0)
            FaceShowing = CoinFace.Heads;
        else
            FaceShowing = CoinFace.Tails;
    }
}
