using MarsRovers.Common.Enums;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services
{
    public interface IRoverService
    {
        BaseModels<RoverModel> Initalize(PlateauModel plateauModel, RoverLocationModel roverLocation);
        BaseModels<bool> ValidateLocation(PlateauModel plateauModel, RoverLocationModel roverLocation);
        BaseModels<RoverModel> GetCurrentRover();
        void ExplorePlateau(Instruction instruction);
    }
}
