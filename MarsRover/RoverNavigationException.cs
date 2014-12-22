using System;

namespace MarsRover
{
    public class RoverNavigationException : ApplicationException
    {
        public RoverNavigationException()
        {
            
        }

        public RoverNavigationException(string message) : base(message)
        {

        }
    }
}
