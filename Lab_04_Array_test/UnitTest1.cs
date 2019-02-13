using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_04_Array;

namespace Lab_04_Array_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_Array_Sum()
        {
            //arrange (setup)
            var arrayInstance = new Lab_04_Array.Array();
            var expectedOutput = -1;
            //act (run code)
            var actualOutput = arrayInstance.CreateArray();
            //assert (see if tests pass/fail)
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void Check_Sum_Of_Squares() {
            var arrayInstance = new Lab_04_Array.Array();
            Assert.AreEqual(111895, arrayInstance.SumOfSquares(69));
            Assert.AreEqual(385, arrayInstance.SumOfSquares(10));
            Assert.AreEqual(285, arrayInstance.SumOfSquares(9));
            Assert.AreEqual(204, arrayInstance.SumOfSquares(8));
        }
    }
}
