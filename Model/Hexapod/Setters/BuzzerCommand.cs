using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hexapod_dotnet.Model.Hexapod.Setters
{
    public class BuzzerCommand
    {
        public bool On { get; set; }

        public override string ToString() => $"{Commands.CMD_BUZZER}#{(On ? 1 : 0)}";
    }
}