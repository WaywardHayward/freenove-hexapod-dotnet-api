
namespace hexapod_dotnet.Model.Hexapod.Setters
{
    public class MoveCommand
    {
        public int GaitMode { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public int Speed { get; set; }

        public int Angle { get; set; }

        public int ActionMode { get; set; }

        public override string ToString() =>
            $"{Commands.CMD_MOVE}#{GaitMode}#{X}#{Y}#{Speed}#{Angle}";
    }
}
