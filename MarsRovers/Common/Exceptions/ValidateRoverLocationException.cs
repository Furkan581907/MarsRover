using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Common.Exceptions
{
    public class ValidateRoverLocationException : Exception
    {
        public ValidateRoverLocationException() : base(@"Rover location not validated on the plateau with given parameters.")
        {

        }
    }
}
