using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
namespace ToyRobotTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Test_Robot_Place_Return_True()
        {
          
            Robot robot = new Robot();
          
            string result = robot.command("PLACE 0,0,EAST");
            
            Assert.AreEqual(Robot.PLACED_MESSAGE, result);

        }
        [TestMethod]
        public void Test_Robot_Place_Return_OutTable()
        {
           
            Robot robot = new Robot();
            
            string result = robot.command("PLACE 6,0,EAST");

            Assert.AreEqual(Robot.OUT_OF_BOUNDS_MESSAGE, result);

        }
        [TestMethod]
        public void Test_Robot_Place_With_Invalid_Direction()
        {
            
            Robot robot = new Robot();
         
            string result = robot.command("PLACE 6,0,APPLE");

           
            Assert.AreEqual(Robot.NOT_PLACED_YET_MESSAGE, result);

        }
        [TestMethod]
        public void Test_Robot_Place_Invalid_Command()
        {
            
            Robot robot = new Robot();

            string result = robot.command("Test");

            Assert.AreEqual(Robot.NOT_PLACED_YET_MESSAGE, result);

        }
        [TestMethod]
        public void Test_Robot_Place_Return_NotPlaced()
        {
           
            Robot robot = new Robot();
            
            string result = robot.command("Move");
          
            Assert.AreEqual(Robot.NOT_PLACED_YET_MESSAGE, result);

        }
        [TestMethod]
        public void Test_Robot_0_0_1_N_Move_Report()
        {
            
            Robot robot = new Robot();
            
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
           
            Assert.AreEqual("0,1,NORTH", result);
        }
        [TestMethod]
        public void Test_Robot_0_0_1_N_Left_Report()
        {

            Robot robot = new Robot();

            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("LEFT");
            result = robot.command("REPORT");

            Assert.AreEqual("0,0,WEST", result);
        }
        [TestMethod]
        public void Test_Robot_1_2_E_Move_Move_Left_Move_Report()
        {

            Robot robot = new Robot();

            string result = robot.command("PLACE 1,2,EAST");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            result = robot.command("LEFT");
            result = robot.command("MOVE");
            result = robot.command("REPORT");

            Assert.AreEqual("3,3,NORTH", result);
        }
        [TestMethod]
        public void Test_Robot_Turn_Right()
        {
            
            Robot robot = new Robot();
            
            string result = robot.command("PLACE 0,0,EAST");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            
            Assert.AreEqual("0,0,SOUTH", result);
        }
        [TestMethod]
        public void Test_Robot_Turn_Right_Twice()
        {
            
            Robot robot = new Robot();
          
            string result = robot.command("PLACE 0,0,EAST");
            result = robot.command("RIGHT");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
          
            Assert.AreEqual("0,0,WEST", result);
        }
    }
}
