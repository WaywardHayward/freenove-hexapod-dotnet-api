namespace Hexapod.Commands;

public class PositionCommand
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override string ToString() => $"{Commands.CMD_POSITION}#{X}#{Y}#{Z}";
}
