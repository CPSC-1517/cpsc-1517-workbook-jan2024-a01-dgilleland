using System.Text;

namespace Game;

public enum CellStatus { Blank, Hit, Miss }
public enum CellColumn { A = 1, B, C, D, E, F, G, H, I, J }
public record CellRow
{
    public int Value { get; init; }
    public CellRow(int value)
    {
        if(value < 1 || value > 10)
            throw new ArgumentOutOfRangeException("Cell rows can only be values from 1 through 10 inclusive");
        Value = value;
    }
    public static implicit operator CellRow(int value) => new(value);
}

public record Cell(CellColumn Col, CellRow Row, CellStatus Status)
{
    public Cell(int col, CellRow row, CellStatus status):this(EnumParser.Parse<CellColumn>(col), row, status){}
}