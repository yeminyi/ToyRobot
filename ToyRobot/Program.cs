using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputCommand = String.Empty;

            Robot robot = new Robot();

            Console.Write("Robot initialised. \nPlease place the Robot firstly.\nThe right commands as follows\n-------------\nPLACE X,Y,DIRECTION e.g. PLACE 1,2,NORTH\nMOVE\nRIGHT\nLEFT\nREPORT\n-------------\n(Q at any time to quit)\n");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("Q"))
                    break;

                Console.WriteLine(robot.command(inputCommand));
                Console.WriteLine();
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
