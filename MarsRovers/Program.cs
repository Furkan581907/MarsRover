using MarsRovers.Common.Enums;
using MarsRovers.Model;
using MarsRovers.Model.Commands;
using MarsRovers.Model.Factory;
using MarsRovers.Services;
using MarsRovers.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<IExplorationFactory, ExplorationFactory>()
            .AddSingleton<IExplorationCommand, RotateRightCommand>()
            .AddSingleton<IExplorationCommand, RotateLeftCommand>()
            .AddSingleton<IExplorationCommand, MoveForwardCommand>()
            .AddSingleton<IPlateauService, PlateauService>()
            .AddSingleton<IRoverService, RoverService>()
            .AddSingleton<IInstructionService, InstructionService>()
            .BuildServiceProvider();


            IPlateauService plateauService = serviceProvider.GetService<IPlateauService>();
            IRoverService roverService = serviceProvider.GetService<IRoverService>();
            IInstructionService instructionService = serviceProvider.GetService<IInstructionService>();

            List<RoverModel> rovers = new List<RoverModel>();

            BaseModels<PlateauModel> basePlateauModel = plateauService.Create(5, 5);
            Console.WriteLine("5 5");
            RoverLocationModel firstRoverLocation = new RoverLocationModel()
            {
                XPosition = 1,
                YPosition = 2,
                Direction = Directions.North
            };
            Console.WriteLine("1 2 N");
            BaseModels<RoverModel> baseRoverModel = roverService.Initalize(basePlateauModel.Data, firstRoverLocation);
            rovers.Add(baseRoverModel.Data);
            Console.WriteLine("LMLMLMLMM");
            BaseModels<List<Instruction>> baseInstructionModel = instructionService.GetInstructions("LMLMLMLMM");

            foreach (Instruction instruction in baseInstructionModel.Data)
            {
                roverService.ExplorePlateau(instruction);
            }
            Console.WriteLine("3 3 E");
            RoverLocationModel secondRoverLocation = new RoverLocationModel()
            {
                XPosition = 3,
                YPosition = 3,
                Direction = Directions.East
            };

            baseRoverModel = roverService.Initalize(basePlateauModel.Data, secondRoverLocation);
            rovers.Add(baseRoverModel.Data);
            Console.WriteLine("MMRMMRMRRM");
            baseInstructionModel = instructionService.GetInstructions("MMRMMRMRRM");

            foreach (Instruction instruction in baseInstructionModel.Data)
            {
                roverService.ExplorePlateau(instruction);
            }
            Console.ReadLine();
        }
        

    }
}

