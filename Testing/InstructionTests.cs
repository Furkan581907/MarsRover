using FluentAssertions;
using MarsRovers.Common.Enums;
using MarsRovers.Model;
using MarsRovers.Services;
using MarsRovers.Services.Implementations;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class InstructionTests
    {
        private IInstructionService _instructionService;
        private ILogger<InstructionService> _loggerMock;
        public InstructionTests()
        {
            _loggerMock = Mock.Of<ILogger<InstructionService>>();
        }

        [Theory]
        [InlineData(null)]
        public void GetInstructions_IsNull_ThrowsValidatePlateauException(string instruction)
        {
            _instructionService = new InstructionService();

            Assert.Throws<ArgumentNullException>(() => _instructionService.GetInstructions(instruction));
        }

        [Theory]
        [InlineData("LMLMLMLMM")]
        [InlineData("MMRMMRMRRM")]
        public void GetInstructions_IsNotNullAndValidInstruction_ShouldReturnInstructionList_CountShouldEqualWithInstructionLength(string instruction)
        {
            _instructionService = new InstructionService();

            BaseModels<List<Instruction>> baseInstructionModel = _instructionService.GetInstructions(instruction);

            baseInstructionModel.Data.Count.Should().Equals(instruction.Length);
        }
    }
}
