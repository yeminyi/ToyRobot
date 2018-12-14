using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public enum CommandNames : byte
    {
        Invalid = 0,
        Place = 1,
        Move = 2,
        Left = 3,
        Right = 4,
        Report = 5,
    }

    public enum FacingDirections : byte
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4,
    }

    public enum TurnDirection : int
    {
        Left = 1,
        Right = -1,
    }
}
