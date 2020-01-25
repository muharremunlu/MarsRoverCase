using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class CommandExecuter
    {
        public void Execute(string command)
        {
            string[] commandList = command.ToString().Split(Environment.NewLine);
            ILand land = new Land(commandList[0]);

            IRover rover = new Rover(land, commandList[1]);
            rover.RePosition(commandList[2]);

            IRover rover2 = new Rover(land, commandList[3]);
            rover2.RePosition(commandList[4]);
        }

    }
}
