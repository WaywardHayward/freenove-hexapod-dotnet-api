namespace hexapod_dotnet.Model.Hexapod.Setters;

public class ReadyCommand
{
    public bool Ready { get; set; }

    public override string ToString() => $"{Commands.CMD_SERVOPOWER}#{(Ready ? 1 : 0)}";
}
