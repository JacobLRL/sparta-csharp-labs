using NUnit.Framework;
using Lab_16_NUnit_XUnit_Tests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Lab_16_NUnit_Test_01() {
            var instance = new TestMeNow();
            Assert.AreEqual(216, instance.TestThisMethodWorks(2,3,3));
            Assert.AreEqual(36, instance.TestThisMethodWorks(2,3,2));
        }
    }
}