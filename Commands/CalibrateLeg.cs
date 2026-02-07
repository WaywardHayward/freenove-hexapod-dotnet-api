namespace Hexapod.Commands;

public class CalibrateLegCommand
{
    private static readonly string[] LegNames = ["", "one", "two", "three", "four", "five", "six"];

    public Legs Leg { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override string ToString() => $"{Commands.CMD_CALIBRATION}#{LegNames[(int)Leg]}#{X}#{Y}#{Z}";
}

public class SaveCalibrationCommand
{
    public override string ToString() => $"{Commands.CMD_CALIBRATION}#save";
}
