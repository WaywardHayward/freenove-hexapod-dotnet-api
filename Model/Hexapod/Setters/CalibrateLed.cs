using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hexapod_dotnet.Model.Hexapod.Setters
{
    public class CalibrateLedCommand
    {
        public int Mode { get; set; }

        public override string ToString() => $"{Commands.CMD_LED_MOD}#{Mode}";
        
    }
}