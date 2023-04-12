using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hexapod_dotnet.Model.Hexapod.Setters
{
    public class AttitudeCommand
    {
        public double Roll { get; set; }
        public double Pitch { get; set; }
        public double Yaw { get; set; }

        public override string ToString() => $"{Commands.CMD_ATTITUDE}#{Roll}#{Pitch}#{Yaw}";
    }
}