using AutoFixture;
using BritApp.UnitTest;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace BritApp.Strategies.UnitTests
{
    [TestFixture(Category = "Operation: divide")]
    public class DivisionTests : GlobalTestSetup
    {
        IStrategy _divideStrategy;

        #region Setup
        [SetUp]
        public void Setup()
        {
            _divideStrategy = UnityConfig.Container.Resolve<IStrategy>("divide");
        }

        // [TearDown]
        public void Teardown() { }

        #endregion

        [TestCase(10, 2, ExpectedResult = 5)]
        [TestCase(12, -2, ExpectedResult = -6)]
        [TestCase(1,  2, ExpectedResult = 0.5)]
        [TestCase(0100, 5, ExpectedResult = 20)]
        public float DivideTest(float leftOperand,float rightOperand)
        {
            return _divideStrategy.Calculate(leftOperand,rightOperand);
        }
    }
}