using System;

namespace MarsRover.Exceptions
{
    public class LandingException : Exception
    {
        public LandingException(string message) : base(message)
        {
        }
    }
}
