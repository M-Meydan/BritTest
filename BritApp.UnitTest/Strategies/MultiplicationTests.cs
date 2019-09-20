using AutoFixture;
using BritApp.UnitTest;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace BritApp.Strategies.UnitTests
{
    [TestFixture(Category = "Operation: multiply")]
    public class MultiplicationTests: GlobalTestSetup
    {
        IStrategy _multiplyStrategy;

        #region Setup
        [SetUp]
        public void Setup()
        {
            _multiplyStrategy = UnityConfig.Container.Resolve<IStrategy>("multiply");
        }

        // [TearDown]
        public void Teardown() { }

        #endregion

        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(1, -1, ExpectedResult = -1)]
        [TestCase(10,  02, ExpectedResult = 20)]
        [TestCase(0100, 5, ExpectedResult = 500)]
        public float MultiplyTest(float leftOperand,float rightOperand)
        {
            return _multiplyStrategy.Calculate(leftOperand,rightOperand);
        }
    }
}