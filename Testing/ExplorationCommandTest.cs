using MarsRovers.Services.Implementations;
using MarsRovers.Services;
using MarsRovers.Model.Commands;
using MarsRovers.Model.Factory;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;
using MarsRovers.Common.Enums;
using MarsRovers.Model;
using System.Collections.Generic;
using FluentAssertions;
using System;

namespace Testing
{
    public class Tests
    {
        private IRoverService _roverService;
        private IPlateauService _plateauService;
        private IExplorationCommand _explorationCommandMock;
        private IExplorationFactory _explorationFactoryMock;
        private ILogger<InstructionService> _loggerInstructionMock;
        private ILogger<RoverService> _loggerRoverMock;
        private ILogger<PlateauService> _loggerPlateauMock;
        public Tests()
        {
            _explorationFactoryMock = Mock.Of<IExplorationFactory>();
            _loggerRoverMock = Mock.Of<ILogger<RoverService>>();
            _loggerPlateauMock = Mock.Of<ILogger<PlateauService>>();
            _loggerInstructionMock = Mock.Of<ILogger<InstructionService>>();
            _explorationCommandMock = Mock.Of<IExplorationCommand>();
        }

        [Theory]
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(5, 5, 1, 2, Directions.West, Directions.North)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(2, 2, 0, 0, Directions.North, Directions.East)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(8, 7, 8, 7, Directions.East, Directions.South)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(4, 5, 3, 5, Directions.South, Directions.West)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
        public void RotateRightCommand_ValidPlateauValidRoverAndValidInstructions_ShouldBeEqualGivenResult(int width, int height, int xPosition, int yPosition, Directions direction, Directions result)
        {
            _plateauService = new PlateauService();
            _roverService = new RoverService(_explorationFactoryMock);

            BaseModels<PlateauModel> basePlateauModel = _plateauService.Create(width, height);

            basePlateauModel.Data.Width.Should().Equals(width);
            basePlateauModel.Data.Height.Should().Equals(height);

            RoverLocationModel roverLocation = new RoverLocationModel()
            {
                Direction = direction,
                XPosition = xPosition,
                YPosition = yPosition
            };

            BaseModels<RoverModel> baseRoverModel = _roverService.Initalize(basePlateauModel.Data, roverLocation);

            _explorationCommandMock = new RotateRightCommand();

            _explorationCommandMock.Explore(_roverService.GetCurrentRover().Data.Location);

            _roverService.GetCurrentRover().Data.Location.Direction.Should().Be(result);
        }

        [Theory]
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(5, 5, 1, 2, Directions.West, Directions.South)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(2, 2, 0, 0, Directions.North, Directions.West)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(8, 7, 8, 7, Directions.East, Directions.North)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
#pragma warning disable xUnit1010 // The value is not convertible to the method parameter type
        [InlineData(4, 5, 3, 5, Directions.South, Directions.East)]
#pragma warning restore xUnit1010 // The value is not convertible to the method parameter type
        public void RotateLeftCommand_ValidPlateauValidRoverAndValidInstructions_ShouldBeEqualGivenResult(int width, int height, int xPosition, int yPosition, Directions direction, Directions result)
        {
            _plateauService = new PlateauService();
            _roverService = new RoverService(_explorationFactoryMock);

            BaseModels<PlateauModel> basePlateauModel = _plateauService.Create(width, height);

            basePlateauModel.Data.Width.Should().Equals(width);
            basePlateauModel.Data.Height.Should().Equals(height);

            RoverLocationModel roverLocation = new RoverLocationModel()
            {
                Direction = direction,
                XPosition = xPosition,
                YPosition = yPosition
            };

            BaseModels<RoverModel> baseRoverModel = _roverService.Initalize(basePlateauModel.Data, roverLocation);

            _explorationCommandMock = new RotateLeftCommand();

            _explorationCommandMock.Explore(_roverService.GetCurrentRover().Data.Location);

            _roverService.GetCurrentRover().Data.Location.Direction.Should().Be(result);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}