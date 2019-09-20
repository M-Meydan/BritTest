using AutoFixture;
using BritApp.UnitTest;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace BritApp.Strategies.UnitTests
{
    [TestFixture(Category = "Operation: add")]
    public class AdditionTests: GlobalTestSetup
    {
        IStrategy _addStrategy;
       
        #region Setup
        [SetUp]
        public void Setup()
        {
            _addStrategy = UnityConfig.Container.Resolve<IStrategy>("add");
        }

        // [TearDown]
        public void Teardown() { }

        #endregion

        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(1, -1, ExpectedResult = 0)]
        [TestCase(10,  02, ExpectedResult = 12)]
        [TestCase(0100, 22, ExpectedResult = 122)]
        public float AddTest(float leftOperand,float rightOperand)
        {
            return _addStrategy.Calculate(leftOperand,rightOperand);
        }
    }
}