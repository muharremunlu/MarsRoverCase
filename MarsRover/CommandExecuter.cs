using System.Collections.Generic;

namespace MarsRover
{
    public class CommandExecuter
    {
        private CommandExecuter() { }
        public static CommandExecuter Command = new CommandExecuter();
        public List<IRover> Execute(string[] commandList)
        {
            List<IRover> rovers = new List<IRover>();
            ILand land = new Land(commandList[0]);

            IRover rover = new Rover(land, commandList[1]);
            rover.RePosition(commandList[2]);
            rovers.Add(rover);

            IRover rover2 = new Rover(land, commandList[3]);
            rover2.RePosition(commandList[4]);
            rovers.Add(rover2);
            return rovers;
        }

    }
}
