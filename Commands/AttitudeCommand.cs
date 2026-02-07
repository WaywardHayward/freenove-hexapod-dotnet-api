namespace Hexapod.Commands;

public class AttitudeCommand
{
    public double Roll { get; set; }
    public double Pitch { get; set; }
    public double Yaw { get; set; }

    public override string ToString() => $"{Commands.CMD_ATTITUDE}#{Roll}#{Pitch}#{Yaw}";
}
