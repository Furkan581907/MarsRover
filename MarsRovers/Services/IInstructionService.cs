using MarsRovers.Common.Enums;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services
{
    public interface IInstructionService
    {
        BaseModels<List<Instruction>> GetInstructions(string instruction);
    }
}
