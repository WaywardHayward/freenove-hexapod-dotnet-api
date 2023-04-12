using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hexapod_dotnet.Model.Hexapod.Setters
{
    public class RelaxCommand
    {
        public override string ToString() =>  $"{Commands.CMD_SERVOPOWER}#0";
    }
}