namespace Hexapod.Commands;

public class HeadPositionCommand
{
    public int Channel { get; set; }
    public int Angle { get; set; }

    public override string ToString() => $"{Commands.CMD_HEAD}#{Channel}#{Angle}";
}
