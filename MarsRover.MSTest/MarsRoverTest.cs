using MarsRover.Exceptions;
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

            var rovers = CommandExecuter.Command.Execute(commandList);


            Assert.AreEqual("1 3 N", rovers[0].GetLocationInfo());
            Assert.AreEqual("5 1 E", rovers[1].GetLocationInfo());
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
            try
            {
                var rovers = CommandExecuter.Command.Execute(commandList);
            }
            catch (LandingException ex)
            {
                Assert.AreEqual(typeof(LandingException), ex.GetType());
            }
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

            try
            {
                var rovers = CommandExecuter.Command.Execute(commandList);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(LandingException), ex.GetType());
            }
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

            try
            {
                var rovers = CommandExecuter.Command.Execute(commandList);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(InstructionException), ex.GetType());
            }
        }
    }
}
