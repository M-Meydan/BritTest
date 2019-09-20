using BritApp.UnitTest;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace BritApp.Strategies.UnitTests
{
    [TestFixture(Category = "Operation: subtract")]
    public class SubtractionTests : GlobalTestSetup
    {
        IStrategy _subtractionStrategy;
       
        #region Setup
        [SetUp]
        public void Setup()
        {
            _subtractionStrategy = UnityConfig.Container.Resolve<IStrategy>("subtract");
        }

        // [TearDown]
        public void Teardown() { }

        #endregion

        [TestCase(1, 1, ExpectedResult = 0)]
        [TestCase(1, -1, ExpectedResult = 2)]
        [TestCase(10,  02, ExpectedResult = 8)]
        [TestCase(0100, 20, ExpectedResult = 80)]
        public float SubtractTest(float leftOperand,float rightOperand)
        {
            return _subtractionStrategy.Calculate(leftOperand,rightOperand);
        }
    }
}