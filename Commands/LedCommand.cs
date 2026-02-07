namespace Hexapod.Commands;

public class LedCommand
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    
    public override string ToString() => $"{Commands.CMD_LED}#{Red}#{Green}#{Blue}";
}
