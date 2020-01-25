using System;

namespace MarsRover.Exceptions
{
    public class MovementException : Exception
    {
        public MovementException(string message) : base(message)
        {
        }
    }
}
