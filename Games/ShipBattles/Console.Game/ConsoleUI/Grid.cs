namespace ConsoleUI;
using Game;

public class Grid
{
    public Grid(CellStatus[,] cells)
    {

    }
    const char Blank = ' ';
    const char Miss = '-';
    const char Hit = 'H';
    private static class Border
    {
        const char TopLeft = '╭';
        const char TopRight = '╮';
        const char BottomLeft = '╰';
        const char BottomRight = '╯';
        const char Horizontal = '─';
        const char Vertical = '│';
        const char TopDivider = '┬';
        const char BottomDivider = '┴';
        const char LeftDivider = '├';
        const char RightDivider = '┤';
        const char Divider = '┼';
    }
}
