using MarsRovers.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model.Commands
{
    public class RotateRightCommand : IExplorationCommand
    {
        public void Explore(RoverLocationModel roverLocation)
        {
            switch (roverLocation.Direction)
            {
                case Directions.North:
                    roverLocation.Direction = Directions.East;
                    break;
                case Directions.East:
                    roverLocation.Direction = Directions.South;
                    break;
                case Directions.South:
                    roverLocation.Direction = Directions.West;
                    break;
                case Directions.West:
                    roverLocation.Direction = Directions.North;
                    break;
            }
        }
    }
}
