using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Robot
    {

        public int X = 0;
        public int Y = 0;
        public string direction;
       
        public const string OUT_OF_BOUNDS_MESSAGE = "Invalid Command - out of table";
        public const string NOT_PLACED_YET_MESSAGE = "Invalid Command - robot not placed yet";
        public const string PLACED_MESSAGE = "Robot already placed,please input command";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Invalid Command - robot can not understand this command";
        public const string ERROR_MESSAGE = "Error during command handling.";

        private bool isPlaced = false;
        TableRange robotRange = new TableRange();
        
        public string command(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;
            robotRange.Table(5, 5);
            try
            {
                if (command.Contains("PLACE"))
                    result = place(command);

                else if (!isPlaced)
                    result = NOT_PLACED_YET_MESSAGE;

                else if (command.Contains("REPORT"))
                    result = Report();

                else if (command.Contains("MOVE"))
                {
                    int originX = X;
                    int originY = Y;
                    Move();
                    if (!robotRange.validatePosition(X, Y))
                    {
                        X = originX;
                        Y = originY;
                        result = OUT_OF_BOUNDS_MESSAGE;
                    }
                        
                }
                    
                else if (command.Contains("LEFT"))
                    TurnLeft();

                else if (command.Contains("RIGHT"))
                    TurnRight();

                else
                    result = COMMAND_NOT_RECOGNISED_MESSAGE;
            }
            catch
            {
                result = ERROR_MESSAGE;
            }

            return result;
        }
        private string place(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            X = Int32.Parse(wordsInCommand[1]);
            Y = Int32.Parse(wordsInCommand[2]);
            direction = wordsInCommand[3];
            if (validateDirection(direction))
            {
                if (!robotRange.validatePosition(X, Y))
                    result = OUT_OF_BOUNDS_MESSAGE;
                else
                {
                    result = PLACED_MESSAGE;
                    isPlaced = true;
                }
            }
            else
                result = NOT_PLACED_YET_MESSAGE;

            return result;
        }

       
        public void Move()

        {
            switch (direction)
            {
                case "EAST":
                case "E":
                    X += 1;
                    break;
                case "WEST":
                case "W":
                    X -= 1;
                    break;
                case "NORTH":
                case "N":
                    Y += 1;
                    break;
                case "SOUTH":
                case "S":
                    Y -= 1;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (direction)
            {
                case "EAST":
                case "E":
                    direction = "NORTH";
                    break;
                case "SOUTH":
                case "S":
                    direction = "EAST";
                    break;
                case "WEST":
                case "W":
                    direction = "SOUTH";
                    break;
                case "NORTH":
                case "N":
                    direction = "WEST";
                    break;
                
            }
        }

        public void TurnRight()
        {
            switch (direction)
            {
                case "EAST":
                case "E":
                    direction = "SOUTH";
                    break;
                case "SOUTH":
                case "S":
                    direction = "WEST";
                    break;
                case "WEST":
                case "W":
                    direction = "NORTH";
                    break;
                case "NORTH":
                case "N":
                    direction = "EAST";
                    break;
                
            }
        }

        public string Report()
        {
            return X + "," + Y + "," + direction.ToUpper();
        }
        public bool validateDirection(string direction)
        {
            switch (direction)
            {
                case "EAST":
                case "E":
                case "SOUTH":
                case "S":
                case "WEST":
                case "W":
                case "NORTH":
                case "N":
                    return true;
                default:
                    return false;

            }

        }
    }
}
