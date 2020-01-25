using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendLine("5 5");
            commandBuilder.AppendLine("1 2 N");
            commandBuilder.AppendLine("LMLMLMLMM");
            commandBuilder.AppendLine("3 3 E");
            commandBuilder.AppendLine("MMRMMRMRRM");
            string[] commandList = commandBuilder.ToString().Split(Environment.NewLine);

            ShowCommandList(commandList);

            var rovers = CommandExecuter.Command.Execute(commandList);

            ShowRoversLocations(rovers);

            Console.ReadLine();
        }

        private static void ShowRoversLocations(List<IRover> rovers)
        {
            Console.WriteLine("Outputs:");
            for (int i = 0; i < rovers.Count; i++)
                Console.WriteLine(rovers[i].GetLocationInfo());
        }

        private static void ShowCommandList(string[] commandList)
        {
            Console.WriteLine("Inputs:");
            for (int i = 0; i < commandList.Length; i++)
                Console.WriteLine(commandList[i]);
        }
    }
}
