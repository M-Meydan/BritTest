using BritApp.Models;
using System;
using System.Collections.Generic;

namespace BritApp
{
    public interface IInstructionValidator
    {
        void ThrowIfInstructionNotExist(string[] lines);
        string ThrowIfKeywordNotValid(string keyword, string line);
        Instruction ThrowIfLastInstructionNotValid(Instruction instruction);
        float ThrowIfNumberNotValid(string number, string line);
        void ThrowIfNumberOfArgumentsNotValid(string[] args, string line);
    }

    public class InstructionValidator : IInstructionValidator
    {
        const string ApplyKeyword = "apply";
        static readonly List<string> Keywords = new List<string>() { "add", "divide", "multiply", "subtract", "apply" };

        public void ThrowIfInstructionNotExist(string[] lines)
        {
            if (lines == null || lines.Length == 0) throw new ArgumentException($"No instructions exist");
        }

        /// <summary>
        /// Number of arguments should be 2 (keyword and number).
        /// </summary>
        public void ThrowIfNumberOfArgumentsNotValid(string[] args, string line)
        {
            if (args.Length != 2) throw new ArgumentException($"Invalid number of arguments: '{line}' ");
        }

        /// <summary>
        /// Keyword should be add, divide, multiply and subtract operators.
        /// </summary>
        public string ThrowIfKeywordNotValid(string keyword, string line)
        {
            keyword = keyword?.ToLower();
            if (string.IsNullOrWhiteSpace(keyword) || !Keywords.Contains(keyword)) throw new ArgumentException($"Invalid keyword: '{line}' ");
            return keyword;
        }

        /// <summary>
        /// Second argument of the instruction should be a number.
        /// </summary>
        public float ThrowIfNumberNotValid(string number, string line)
        {
            if (!float.TryParse(number, out float result)) throw new ArgumentException($"Invalid number: '{line}' ");
            return result;
        }

        /// <summary>
        /// Last instruction should be 'action'.
        /// </summary>
        public Instruction ThrowIfLastInstructionNotValid(Instruction instruction)
        {
            if (instruction.Operation != ApplyKeyword) throw new ArgumentException($"Last instruction should be 'action': 'LastInstruction.Operation' ");
            return instruction;
        }
    }
}