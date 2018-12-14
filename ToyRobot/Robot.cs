using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Robot
    {
        public const string OUT_OF_BOUNDS_MESSAGE = "Invalid Command - out of table";
        public const string NOT_PLACED_YET_MESSAGE = "Invalid Command - robot not placed yet";
        public const string PLACED_MESSAGE = "Robot already placed,please input command";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Invalid Command - robot can not understand this command";
        public const string ERROR_MESSAGE = "Error during command handling.";

       
        TableRange robotRange = new TableRange();
        private int? _x;
        private int? _y;
        private FacingDirections _facing;

        private bool TryGetFacingDirection(string direction, out FacingDirections facing)
        {
            return Enum.TryParse<FacingDirections>(direction, true, out facing);
        }
        public string ValidateBeforePlace(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            int x, y;
            FacingDirections facing;

            x = Int32.Parse(wordsInCommand[1]);
            y = Int32.Parse(wordsInCommand[2]);
            string direction = wordsInCommand[3];
          
            TryGetFacingDirection(direction,out facing);
            robotRange.Table(5, 5);
            if (!robotRange.validatePosition(x, y))
                result = OUT_OF_BOUNDS_MESSAGE;
            else
            {
                Place(x,y,facing);
                result = PLACED_MESSAGE;
                   
            }
            

            return result;
        }
        public bool Place(int x, int y, FacingDirections facing)
        {

                _x = x;
                _y = y;
                _facing = facing;
                return true;
        }


        public bool Move()
        {
           
            int newx = GetPositonAfterMove(_x,_y,_facing);
            int newy = GetPositonAfterMove(_x,_y,_facing);
            if (newx > 0 && newy > 0)
            {
                _x = newx;
                _y = newy;
                return true;
            }
            else
                return false;
                
        }
        private int GetPositonAfterMove(int? x, int? y, FacingDirections facing)
        {
            switch (facing)
            {
                case FacingDirections.East:
                    return (int)x + 1;
                    
                case FacingDirections.West:
                    return (int)x - 1;

                case FacingDirections.North:
                    return (int)y + 1;
                case FacingDirections.South:
                    return (int)y - 1;
                default:
                    return -1;
            }        
      
        }

        public bool TurnLeft()
        {
            return Turn(TurnDirection.Left);
        }

        public bool TurnRight()
        {
            return Turn(TurnDirection.Right);
        }

        private bool Turn(TurnDirection direction)
        {
           
            var facingAsNumber = (int)_facing;
            facingAsNumber += 1 * (direction == TurnDirection.Right ? 1 : -1);
            if (facingAsNumber == 5) facingAsNumber = 1;
            if (facingAsNumber == 0) facingAsNumber = 4;
            _facing = (FacingDirections)facingAsNumber;
            return true;
           
        }

        public string Report()
        {
            return _x+ "," + _y + "," + _facing.ToString();
        }

    }
}
