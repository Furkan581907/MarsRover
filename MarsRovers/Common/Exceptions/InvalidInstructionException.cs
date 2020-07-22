using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Common.Exceptions
{
    public class InvalidInstructionException : Exception
    {
        public InvalidInstructionException() : base(@"Invalid instruction.")
        {

        }
    }
}
