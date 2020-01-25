using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System;
using System.Text;

namespace MarsRover.MSTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void MarsRoverCase()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendLine("5 5");
            commandBuilder.AppendLine("1 2 N");
            commandBuilder.AppendLine("LMLMLMLMM");
            commandBuilder.AppendLine("3 3 E");
            commandBuilder.AppendLine("MMRMMRMRRM");

            string[] commandList = commandBuilder.ToString().Split(Environment.NewLine);

            Land land = new Land(commandList[0]);

            Rover rover = new Rover(land, commandList[1]);
            rover.RePosition(commandList[2]);

            Rover rover2 = new Rover(land, commandList[3]);
            rover2.RePosition(commandList[4]);

            Assert.AreEqual("1 3 N", rover.GetLocationInfo());
            Assert.AreEqual("5 1 E", rover2.GetLocationInfo());
        }

        [TestMethod]
        public void MarsRoverCaseFailIfTheSecondRoverIsSameLocationWithTheFirstRover()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendLine("5 5");
            commandBuilder.AppendLine("1 2 N");
            commandBuilder.AppendLine("LMLMLMLMM");
            commandBuilder.AppendLine("1 3 N");
            commandBuilder.AppendLine("MMRMMRMRRM");

            string[] commandList = commandBuilder.ToString().Split(Environment.NewLine);

            Land land = new Land(commandList[0]);

            Rover rover = new Rover(land, commandList[1]);
            rover.RePosition(commandList[2]);

            Rover rover2 = new Rover(land, commandList[3]);
            rover2.RePosition(commandList[4]);

            Assert.AreEqual("1 3 N", rover.GetLocationInfo());
            Assert.AreEqual(false, rover2.IsLanded);
            Assert.AreEqual("The Rover couldn't be landed.", rover2.GetLocationInfo());
        }

        [TestMethod]
        public void FailAllIfTheFirstRoverPositioningOutsideOfPlanet()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendLine("5 5");
            commandBuilder.AppendLine("6 2 N");
            commandBuilder.AppendLine("LMLMLMLMM");
            commandBuilder.AppendLine("3 3 E");
            commandBuilder.AppendLine("MMRMMRMRRM");

            string[] commandList = commandBuilder.ToString().Split(Environment.NewLine);

            Land land = new Land(commandList[0]);
            Rover rover = null;

            try
            {
                rover = new Rover(land, commandList[1]);
                rover.RePosition(commandList[2]);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(Exceptions.CommandException), ex.GetType());
            }

            Rover rover2 = null;
            try
            {
                rover2 = new Rover(land, commandList[3]);
                rover2.RePosition(commandList[4]);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(Exceptions.CommandException), ex.GetType());
            }

            Assert.AreEqual(false, rover.IsLanded);
            Assert.AreEqual("The Rover couldn't be landed.", rover.GetLocationInfo());
            Assert.AreEqual(false, rover2.IsLanded);
            Assert.AreEqual("The Rover couldn't be landed.", rover2.GetLocationInfo());
        }

        [TestMethod]
        public void AlertMovementExceptionIfInstructionIsWrong()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendLine("5 5");
            commandBuilder.AppendLine("1 2 N");
            commandBuilder.AppendLine("LMXYLMLMM");
            commandBuilder.AppendLine("3 3 E");
            commandBuilder.AppendLine("MMRMMRMRRM");

            string[] commandList = commandBuilder.ToString().Split(Environment.NewLine);

            Land land = new Land(commandList[0]);
            Rover rover = new Rover(land, commandList[1]);

            try
            {
                rover.RePosition(commandList[2]);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(Exceptions.CommandException), ex.GetType());
            }
        }
    }
}
