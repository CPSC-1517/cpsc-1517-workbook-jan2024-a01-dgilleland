namespace Game;

public class Grid
{
    public enum Direction { Horizontal, Vertical }
    public CellStatus[,] Status { get; } = new CellStatus[10,10];
}