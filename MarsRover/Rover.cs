using MarsRover.Enums;
using MarsRover.Exceptions;
using System;

namespace MarsRover
{
    public class Rover : IRover
    {
        private const char Separator = ' ';
        public bool IsLanded { get; set; }
        private ILand Land { get; }
        private Position Location { get; set; }
        private CompassDirection Direction { get; set; }

        public Rover(ILand land, string coordinate)
        {
            Land = land;
            SetLocation(coordinate);
        }

        /// <summary>
        /// The Rover moves with instructions
        /// </summary>
        /// <param name="instructions">LMLMLMLMM</param>
        public void RePosition(string instructions)
        {
            var commantType = Parser.GetTypeOfCommand(instructions);
            if (commantType == CommandType.Instructions)
            {
                Moving moving;
                for (int i = 0; i < instructions.Length && IsLanded; i++)
                {
                    moving = GetMovement(instructions, i);
                    Move(moving);
                }
            }
            else
            {
                throw new Exceptions.InstructionException($"{instructions} is wrong command. The command only contains L,R,M characters!");
            }
        }

        private void Move(Moving moving)
        {
            switch (moving)
            {
                case Moving.L:
                    switch (Direction)
                    {
                        case CompassDirection.N:
                            Direction = CompassDirection.W;
                            break;
                        case CompassDirection.E:
                            Direction = CompassDirection.N;
                            break;
                        case CompassDirection.S:
                            Direction = CompassDirection.E;
                            break;
                        case CompassDirection.W:
                            Direction = CompassDirection.S;
                            break;
                        default:
                            break;
                    }
                    break;
                case Moving.R:
                    switch (Direction)
                    {
                        case CompassDirection.N:
                            Direction = CompassDirection.E;
                            break;
                        case CompassDirection.E:
                            Direction = CompassDirection.S;
                            break;
                        case CompassDirection.S:
                            Direction = CompassDirection.W;
                            break;
                        case CompassDirection.W:
                            Direction = CompassDirection.N;
                            break;
                        default:
                            break;
                    }
                    break;
                case Moving.M:
                    Position newLocation = new Position(Location);
                    switch (Direction)
                    {
                        case CompassDirection.N:
                            newLocation.Y++;
                            break;
                        case CompassDirection.E:
                            newLocation.X++;
                            break;
                        case CompassDirection.S:
                            newLocation.Y--;
                            break;
                        case CompassDirection.W:
                            newLocation.X--;
                            break;
                        default:
                            break;
                    }

                    if (!Land.CheckCoordinate(newLocation))
                    {
                        Location.X = newLocation.X;
                        Location.Y = newLocation.Y;
                    }

                    break;
                default:
                    break;
            }
        }
        public string GetLocationInfo()
        {
            if (IsLanded)
                return $"{Location.ToString()} {Direction.ToString()}";
            else
                return "The Rover couldn't be landed.";
        }

        private static Moving GetMovement(string instructions, int i)
        {
            try
            {
                return (Moving)Enum.Parse(typeof(Moving), instructions[i].ToString());
            }
            catch (Exception)
            {
                throw new Exceptions.MovementException($"Wrong Instruction:{instructions[i].ToString()}");
            }
        }

        private void SetLocation(string coordinate)
        {
            var commantType = Parser.GetTypeOfCommand(coordinate);
            if (commantType == CommandType.RoverCoordinate)
            {
                var location = new Position(coordinate);
                var compassDirection = coordinate.Split(Separator)[2];

                Direction = (CompassDirection)Enum.Parse(typeof(CompassDirection), compassDirection);

                IsLanded = Land.SetRoverLocation(location);
                if (IsLanded)
                    Location = location;
                else
                    throw new LandingException("The Rover can't land this coordinate!");
            }
        }
    }
}
