using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_16_NUnit_XUnit_Tests;
using System;

namespace Lab_16_MSTest
{
    [TestClass]
    public class Lab_16_Test_Class
    {
        [TestInitialize]
        public void Initialize() {
            Console.WriteLine("Initialized");
        }

        [TestMethod]
        public void TestLab16MSTest()
        {
            // arrange act assert
            var instance = new TestMeNow();
            Assert.AreEqual(216, instance.TestThisMethodWorks(2,3,3));
        }

        [TestCleanup]
        public void Cleanup() {
            Console.WriteLine("Cleaning up after tests");
        }
    }
}
