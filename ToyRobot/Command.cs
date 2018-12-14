using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Command
    {
        //public int X = 0;
        //public int Y = 0;
        //public string direction;

        public const string OUT_OF_BOUNDS_MESSAGE = "Invalid Command - out of table";
        public const string NOT_PLACED_YET_MESSAGE = "Invalid Command - robot not placed yet";
        public const string PLACED_MESSAGE = "Robot already placed,please input command";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Invalid Command - robot can not understand this command";
        public const string ERROR_MESSAGE = "Error during command handling.";

        private bool isPlaced = false;
        TableRange robotRange = new TableRange();

        public int X { get; set; }
        public int Y { get; set; }
        public FacingDirections Facing { get; set; }

        public Command(Robot robot)
        {
            this.Robot = robot;
        }

        public Robot Robot { get; set; }


        public string ProcessCommand(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;
            robotRange.Table(5, 5);
            try
            {
                if (command.Contains("PLACE"))
                {
                    result = Robot.ValidateBeforePlace(command);
                    isPlaced = true;
                }
                   
                else if (!isPlaced)
                    result = NOT_PLACED_YET_MESSAGE;

                else if (command.Contains("REPORT"))
                    result = Robot.Report();

                else if (command.Contains("MOVE"))
                {
                    int originX = X;
                    int originY = Y;
                    Robot.Move();
                    if (!robotRange.validatePosition(X, Y))
                    {
                        X = originX;
                        Y = originY;
                        result = OUT_OF_BOUNDS_MESSAGE;
                    }

                }

                else if (command.Contains("LEFT"))
                    Robot.TurnLeft();

                else if (command.Contains("RIGHT"))
                    Robot.TurnRight();

                else
                    result = COMMAND_NOT_RECOGNISED_MESSAGE;
            }
            catch (Exception e)
            {
                result = ERROR_MESSAGE+e;
            }

            return result;
        }
    }
}
