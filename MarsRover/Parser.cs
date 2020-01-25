using MarsRover.Enums;
using MarsRover.Exceptions;
using System.Text.RegularExpressions;

namespace MarsRover
{
    internal static class Parser
    {
        public static char Separator = ' ';
        private static readonly Regex rgxLandSizing = new Regex(@"^\b([0-9]+ [0-9]+)\b$", RegexOptions.Singleline);
        private static readonly Regex rgxRoverCoordinate = new Regex(@"\b([0-9]+ [0-9]+ [NESW])\b$", RegexOptions.Singleline);
        private static readonly Regex rgxInstructions = new Regex(@"\b[LRM]+\b$", RegexOptions.Singleline);

        public static CommandType GetTypeOfCommand(string command)
        {
            if (rgxLandSizing.IsMatch(command))
                return CommandType.LandSizing;
            else if (rgxRoverCoordinate.IsMatch(command))
                return CommandType.RoverCoordinate;
            else if (rgxInstructions.IsMatch(command))
                return CommandType.Instructions;
            else return CommandType.Others;
        }

        internal static LandSize ParseSize(string size)
        {
            var commantType = Parser.GetTypeOfCommand(size);
            if (commantType != Enums.CommandType.LandSizing)
                throw new CommandException("Wrong command for the Land size!");

            LandSize landSize = new LandSize()
            {
                Width = byte.Parse(size.Split(Separator)[0]),
                Height = byte.Parse(size.Split(Separator)[1])
            };
            return landSize;
        }
    }
}
