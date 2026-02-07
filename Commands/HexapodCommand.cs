namespace Hexapod.Commands;

public class HexapodCommand
{
    public Commands Command { get; set; }
    public string? Parameters { get; set; }

    public override string ToString() => $"{Command}#{Parameters}";
}
