using System;

namespace MarsRover.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string message) : base(message)
        {
        }
    }
}
