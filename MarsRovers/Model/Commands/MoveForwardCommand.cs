using MarsRovers.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model.Commands
{
    public class MoveForwardCommand : IExplorationCommand
    {
        public void Explore(RoverLocationModel roverLocation)
        {
            switch (roverLocation.Direction)
            {
                case Directions.North:
                    roverLocation.YPosition += 1;
                    break;
                case Directions.East:
                    roverLocation.XPosition += 1;
                    break;
                case Directions.South:
                    roverLocation.YPosition -= 1;
                    break;
                case Directions.West:
                    roverLocation.XPosition -= 1;
                    break;
            }
        }
    }
}
