using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Common.Exceptions
{
    public class ValidatePlateauException : Exception
    {
        public ValidatePlateauException() : base(@"Plateau not validated with given parameters.")
        {

        }
    }
}
