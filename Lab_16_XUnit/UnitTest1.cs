using System;
using Xunit;
using Lab_16_NUnit_XUnit_Tests;

namespace Lab_16_XUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var instance = new TestMeNow();
            Assert.Equal(216, instance.TestThisMethodWorks(2,3,3));
        }
    }
}
