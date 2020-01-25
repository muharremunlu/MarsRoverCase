using System;

namespace MarsRover.Exceptions
{
    public class InstructionException : Exception
    {
        public InstructionException(string message) : base(message)
        {
        }
    }
}
