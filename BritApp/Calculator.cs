using BritApp.Models;
using BritApp.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;

namespace BritApp
{
    /// <summary>
    /// ConsoleApp service client wrapper
    /// </summary>
    public interface ICalculator
    {
        void Load(string filePath);
        void ValidateLines();
        float ExecuteInstructions();
    }

    public class Calculator : ICalculator
    {
        string[] _lines;

        Instruction _startInstruction;
        IInstructionValidator _instructionValidator;
        List<Instruction> _instructionList = new List<Instruction>();

        public Calculator(IInstructionValidator instructionValidator) { _instructionValidator = instructionValidator; }

        /// <summary>
        /// Load input from file path.
        /// </summary>
        public void Load(string filePath)
        {
            _lines = File.ReadAllLines(filePath);
        }

        public void ValidateLines()
        {
            string[] args;

            _instructionValidator.ThrowIfInstructionNotExist(_lines);

            foreach (var line in _lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                Console.WriteLine(line);

                args = line.Split(' ');

                _instructionValidator.ThrowIfNumberOfArgumentsNotValid(args, line);

                _instructionList.Add(new Instruction
                {
                    Operation = _instructionValidator.ThrowIfKeywordNotValid(args[0], line),
                    Number = _instructionValidator.ThrowIfNumberNotValid(args[1], line)
                });
            }

            _startInstruction = _instructionValidator.ThrowIfLastInstructionNotValid(_instructionList.Last());
        }

        public float ExecuteInstructions()
        {
            IStrategy operation;
            Instruction nextInstruction;

            float result = _startInstruction.Number;

            for (int i = 0; i < _instructionList.Count - 1; i++) // skips last instruction (action)
            {
                nextInstruction = _instructionList[i];
                operation = UnityConfig.Container.Resolve<IStrategy>(nextInstruction.Operation);  // uses Unity as Factory to get calculation strategy
                result = operation.Calculate(result, nextInstruction.Number);
            }

            return result;
        }
    }
}