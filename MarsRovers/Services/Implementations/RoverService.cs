using MarsRovers.Common.Enums;
using MarsRovers.Common.Exceptions;
using MarsRovers.Model;
using MarsRovers.Model.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services.Implementations
{
    public class RoverService : IRoverService
    {
        private RoverModel CurrentRover { get; set; }
        private IExplorationFactory _explorationFactory;
        public RoverService(IExplorationFactory explorationFactory)
        {
            _explorationFactory = explorationFactory;
        }

        public BaseModels<RoverModel> Initalize(PlateauModel plateauModel, RoverLocationModel roverLocation)
        {
            BaseModels<RoverModel> model = new BaseModels<RoverModel>();

            BaseModels<bool> validateLocationModel = ValidateLocation(plateauModel, roverLocation);

            if (validateLocationModel.Data)
            {
                model.Data = new RoverModel();
                model.Data.Id = Guid.NewGuid();
                model.Data.Location.Direction = roverLocation.Direction;
                model.Data.Location.XPosition = roverLocation.XPosition;
                model.Data.Location.YPosition = roverLocation.YPosition;
                CurrentRover = model.Data;
                Console.WriteLine("Rover initialized successfully.");

            }

            return model;
        }
        public BaseModels<bool> ValidateLocation(PlateauModel plateauModel, RoverLocationModel roverLocation)
        {
            BaseModels<bool> model = new BaseModels<bool>();

            bool isValidDirection = IsValidDirection(roverLocation.Direction);
            bool isValidXPosition = IsValidXPosition(plateauModel.Width, roverLocation.XPosition);
            bool isValidYPosition = IsValidYPosition(plateauModel.Height, roverLocation.YPosition);

            if (isValidDirection && isValidXPosition && isValidYPosition)
            {
                model.Data = true;
                Console.WriteLine($"Given location ({roverLocation.XPosition}-{roverLocation.YPosition}-{roverLocation.Direction}) for the rover is valid on the given plateau ({plateauModel.Width}-{plateauModel.Height}).");
            }
            else
            {
                ValidateRoverLocationException exception = new ValidateRoverLocationException();
                Console.WriteLine(exception.Message);
                throw exception;
            }

            return model;
        }

        public BaseModels<RoverModel> GetCurrentRover()
        {
            BaseModels<RoverModel> model = new BaseModels<RoverModel>();

            if (CurrentRover != null)
            {
                model.Data = CurrentRover;
            }
            else
            {
                model.Errors.Add("Rover not found.");
            }

            return model;
        }

        public void ExplorePlateau(Instruction instruction)
        {
            _explorationFactory.ExecuteInstruction(instruction).Explore(CurrentRover.Location);
            Console.WriteLine($"Rover location is ({CurrentRover.Location.XPosition}-{CurrentRover.Location.YPosition}-{CurrentRover.Location.Direction})");
        }

        private bool IsValidDirection(Directions direction)
        {
            if (direction == Directions.West ||
                direction == Directions.East ||
                direction == Directions.North ||
                direction == Directions.South)
            {
                return true;
            }

            return false;
        }
        private bool IsValidXPosition(int width, int xPosition)
        {
            return xPosition >= 0 && xPosition <= width;
        }
        private bool IsValidYPosition(int height, int yPosition)
        {
            return yPosition >= 0 && yPosition <= height;
        }
    }
}
