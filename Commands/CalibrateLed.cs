namespace Hexapod.Commands;

public class CalibrateLedCommand
{
    public int Mode { get; set; }

    public override string ToString() => $"{Commands.CMD_LED_MOD}#{Mode}";
}
