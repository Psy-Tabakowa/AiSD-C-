using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double first = 2;
            double second = 1.444;
            double expected = 0.555;
            Assert.AreEqual(first - second, expected, 0.01, "B³¹d");
        }
    }
}
