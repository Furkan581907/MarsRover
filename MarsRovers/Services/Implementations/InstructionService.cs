using MarsRovers.Common.Enums;
using MarsRovers.Common.Exceptions;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MarsRovers.Services.Implementations
{
    public class InstructionService : IInstructionService
    {

        public BaseModels<List<Instruction>> GetInstructions(string instruction)
        {
            BaseModels<List<Instruction>> baseInstructionModel = new BaseModels<List<Instruction>>();

            baseInstructionModel.Data = new List<Instruction>();

            if (!string.IsNullOrEmpty(instruction))
            {
                char[] instructions = instruction.ToCharArray();
                foreach (char instruction1 in instructions)
                {
                    switch (instruction1)
                    {
                        case (char)Instruction.Right:
                            baseInstructionModel.Data.Add(Instruction.Right);
                            break;
                        case (char)Instruction.Left:
                            baseInstructionModel.Data.Add(Instruction.Left);
                            break;
                        case (char)Instruction.Forward:
                            baseInstructionModel.Data.Add(Instruction.Forward);
                            break;
                        default:
                            Console.WriteLine("Invalid instruction");
                            throw new InvalidInstructionException();
                    }
                }
            }
            else
            {
                Console.WriteLine("Instructions not found");
                throw new ArgumentNullException();
            }
            Console.WriteLine("Instructions setteled successfully");
            return baseInstructionModel;
        }
    }
}
