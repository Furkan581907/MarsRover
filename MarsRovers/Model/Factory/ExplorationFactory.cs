using MarsRovers.Common.Enums;
using MarsRovers.Model.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model.Factory
{
    public class ExplorationFactory : IExplorationFactory
    {
        public IExplorationCommand ExecuteInstruction(Instruction instruction)
        {
            IExplorationCommand explorationCommand = null;

            switch (instruction)
            {
                case Instruction.Right:
                    explorationCommand = new RotateRightCommand();
                    break;
                case Instruction.Left:
                    explorationCommand = new RotateLeftCommand();
                    break;
                case Instruction.Forward:
                    explorationCommand = new MoveForwardCommand();
                    break;
            }

            return explorationCommand;
        }
    }
}