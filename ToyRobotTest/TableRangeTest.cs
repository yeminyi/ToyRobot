using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
namespace ToyRobotTest
{
    [TestClass]
    public class TableRangeTest
    {
        [TestMethod]
        public void TestRange_Return_True()
        {
            TableRange robotRange = new TableRange();
            robotRange.Table(7,7);
            bool result =robotRange.validatePosition(3,7);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestRange_Return_False_1()
        {
            TableRange robotRange = new TableRange();
            robotRange.Table(7, 7);
            bool result = robotRange.validatePosition(9, 9);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestRange_Return_False_2()
        {
            TableRange robotRange = new TableRange();
            robotRange.Table(5, 5);
            bool result = robotRange.validatePosition(-1, -2);
            Assert.AreEqual(false, result);
        }
    }
}
