using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hexapod_dotnet.Model.Hexapod.Setters
{
    public class BalanceCommand
    {
        public bool Balance { get; set; }

        public override string ToString() => $"{Commands.CMD_BALANCE}#{(Balance ? 1 : 0)}";
    }
}