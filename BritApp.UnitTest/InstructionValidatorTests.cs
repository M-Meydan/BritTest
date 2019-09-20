using AutoFixture;
using NUnit.Framework;
using System;
using Microsoft.Practices.Unity;
using BritApp.Models;

namespace BritApp.UnitTest
{
    [TestFixture(Category = "Instruction_Validator_Tests")]
    public class InstructionValidatorTests: GlobalTestSetup
    {
        IInstructionValidator _instructorValidator;
        Fixture _fixture = new Fixture();

        #region Setup
        [SetUp]
        public void Setup()
        {
            _instructorValidator = UnityConfig.Container.Resolve<IInstructionValidator>();
        }

       // [TearDown]
        public void Teardown(){}

        #endregion

        [Test()]
        public void InstructionNotExist()
        {
            string[] lines = null;
            Assert.Throws(typeof(ArgumentException), ()=> _instructorValidator.ThrowIfInstructionNotExist(lines));
        }

        [Test()]
        public void InstructionEmpty()
        {
            var lines = new string[] { };
            Assert.Throws(typeof(ArgumentException), () => _instructorValidator.ThrowIfInstructionNotExist(lines));
        }

        [Test()]
        public void InstructionExist()
        {
            var lines = new string[] {"add" };
            _instructorValidator.ThrowIfInstructionNotExist(lines);
        }


        [TestCase("add")]
        [TestCase("add divide 2")]
        public void NumberOfArgumentsNotValid(string line)
        {
            var lines = line.Split(' ');
            Assert.Throws<ArgumentException>(() => _instructorValidator.ThrowIfNumberOfArgumentsNotValid(lines, string.Empty));
        }

        [TestCase("add 2")]
        public void NumberOfArgumentsValid(string line)
        {
            var lines = line.Split(' ');
            _instructorValidator.ThrowIfNumberOfArgumentsNotValid(lines, string.Empty);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("add_s")]
        [TestCase("subtract_s")]
        [TestCase("multiplie_s")]
        [TestCase("divide_s")]
        public void KeywordNotValid(string line)
        {
           var ex = Assert.Throws<ArgumentException>(() => _instructorValidator.ThrowIfKeywordNotValid(line, string.Empty));
        }

        [TestCase("add")]
        [TestCase("subtract")]
        [TestCase("multiply")]
        [TestCase("divide")]
        public void KeywordValid(string line)
        {
            _instructorValidator.ThrowIfKeywordNotValid(line, string.Empty);
        }

        [TestCase(" ")]
        [TestCase("$1")]
        [TestCase("1E")]
        [TestCase("abcd")]
        public void NumberNotValid(string line)
        {
            var ex = Assert.Throws<ArgumentException>(() => _instructorValidator.ThrowIfNumberNotValid(line, string.Empty));
        }

        [TestCase("1")]
        [TestCase("099")]
        [TestCase("1000")]
        [TestCase("-1")]
        [TestCase("+1")]
        [TestCase("1.0")]
        [TestCase("0.15")]
        public void NumberValid(string line)
        {
             _instructorValidator.ThrowIfNumberNotValid(line, string.Empty);
        }

        [TestCase("add", 1)]
        [TestCase("subtract",2)]
        [TestCase("multiply",3)]
        [TestCase("divide",4)]
        public void LastInstructionNotValid(string keyword,int number)
        {
            var instruction = new Instruction { Operation = keyword, Number = number };
            var ex = Assert.Throws<ArgumentException>(() => _instructorValidator.ThrowIfLastInstructionNotValid(instruction));
        }

        [Test]
        public void LastInstructionValid()
        {
            var instruction = new Instruction { Operation = "apply", Number = 1 };
            _instructorValidator.ThrowIfLastInstructionNotValid(instruction);
        }
    }
}