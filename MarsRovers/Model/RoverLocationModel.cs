using MarsRovers.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model
{
    public class RoverLocationModel
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Directions Direction { get; set; }
    }
}
