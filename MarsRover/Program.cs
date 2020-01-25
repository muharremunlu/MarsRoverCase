using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main()
        {
            string landSize = Console.ReadLine();
            ILand land = new Land(landSize);
            int roverCount = 2;
            string roverCoordinate, instructions;
            List<IRover> rovers = new List<IRover>();
            while (rovers.Count < roverCount)
            {
                roverCoordinate = Console.ReadLine();
                instructions = Console.ReadLine();

                IRover rover = new Rover(land, roverCoordinate);

                rover.RePosition(instructions);
                rovers.Add(rover);
            }

            Console.WriteLine("Output:");
            for (int i = 0; i < rovers.Count; i++)
                Console.WriteLine(rovers[i].GetLocationInfo());

            Console.ReadLine();
        }
    }
}
