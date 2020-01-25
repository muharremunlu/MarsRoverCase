using MarsRover.Exceptions;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    /// <summary>
    /// The Planet
    /// </summary>
    public class Land : ILand
    {
        private bool AcceptNextLanding { get; set; }
        private List<Position> RoversPosition { get; set; }
        public Land(string sizeCommand)
        {
            AcceptNextLanding = true;
            SetSize(sizeCommand);
            RoversPosition = new List<Position>();
        }
        public LandSize Size { get; set; }

        private void SetSize(string size)
        {
            Size = Parser.ParseSize(size);
        }

        public bool SetRoverLocation(Position position)
        {
            if (AcceptNextLanding)
            {
                if (CheckCoordinate(position))
                {
                    AcceptNextLanding = false;
                    return false;
                }
                else
                {
                    RoversPosition.Add(position);
                    AcceptNextLanding = true;
                    return true;
                }
            }
            else
                return false;
        }
        /// <summary>
        /// Check X,Y coordinate
        /// </summary>
        /// <param name="position"></param>
        /// <returns>If coorditane has a rover returns true</returns>
        public bool CheckCoordinate(Position position)
        {
            return (
              position.X > Size.Width ||
              position.X < 0 ||
              position.Y > Size.Height ||
              position.Y < 0 ||
              RoversPosition.Exists(p => p.X == position.X && p.Y == position.Y));
        }
    }
}
