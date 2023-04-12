
namespace hexapod_dotnet.Model.Hexapod
{
    public class HexapodCommand
    {
        public Commands Command {get;set;} 

        public string Parameters {get;set;}

        public override string ToString(){
            return $"{Command}#{Parameters}";
        }
    }
}