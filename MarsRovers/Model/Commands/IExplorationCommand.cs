using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model.Commands
{
    public interface IExplorationCommand
    {
        void Explore(RoverLocationModel roverLocation);
    }
}
