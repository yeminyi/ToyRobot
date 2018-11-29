using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot

{

    public class TableRange
    {
        public int width;
        public int length;
      
        public void Table(int width, int length)
        {
            this.width = width;
            this.length = length;
        }
        public bool validatePosition(int X, int Y)
        {
            if ((X < 0) || (Y < 0))
                return false;
            else if ((X >width) || (Y >length))
                return false;
            else
                return true;
        }
    }

   
}
