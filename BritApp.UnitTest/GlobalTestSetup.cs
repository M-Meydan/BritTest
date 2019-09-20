using NUnit.Framework;

namespace BritApp.UnitTest
{
    [TestFixture]
    public class GlobalTestSetup
    {
        [OneTimeSetUp]
        public void Init()
        { UnityConfig.RegisterTypes(); }

        [OneTimeTearDown]
        public void Cleanup()
        {
        }
    }
}
