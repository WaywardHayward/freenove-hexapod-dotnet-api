using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hexapod_dotnet.Model.Hexapod
{
    public enum Commands
    {
        CMD_MOVE,
        CMD_LED_MOD,
        CMD_LED,
        CMD_SONIC,
        CMD_BUZZER,
        CMD_HEAD,
        CMD_BALANCE,
        CMD_ATTITUDE,
        CMD_POSITION,
        CMD_RELAX,
        CMD_POWER,
        CMD_CALIBRATION,
        CMD_CAMERA,
        CMD_SERVOPOWER
    }
}