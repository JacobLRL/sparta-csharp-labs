using NUnit.Framework;
using Lab_118_Array_of_Tests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1000)]
        [TestCase(10000)]
        public void TestFileReadAndWrite(int num)
        {
            var instance = new FileOperationSyncronous();
            Assert.Pass();
        }
    }
}