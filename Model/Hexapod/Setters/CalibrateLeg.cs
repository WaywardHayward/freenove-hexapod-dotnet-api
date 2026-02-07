namespace hexapod_dotnet.Model.Hexapod.Setters;

public class CalibrateLegCommand
{
    public Legs Leg { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override string ToString() => $"{Commands.CMD_CALIBRATION}#{(int)Leg}#{X}#{Y}#{Z}";
}
