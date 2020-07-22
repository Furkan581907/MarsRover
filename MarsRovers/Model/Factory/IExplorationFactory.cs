using MarsRovers.Common.Enums;
using MarsRovers.Model.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model.Factory
{
    public interface IExplorationFactory
    {
        IExplorationCommand ExecuteInstruction(Instruction instruction);
    }
}
