using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SomeTestsForIt
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_Spongebob()
        {
            var Tests = new SomeTests.SomeTest();
            Assert.AreEqual("hElLo", Tests.TextToSpongeBobMeme("Hello"));
            Assert.AreEqual("jQuErY iS bEtTeR", Tests.TextToSpongeBobMeme("jQuery is better"));
            Assert.AreEqual("", Tests.TextToSpongeBobMeme(""));
            
        }

        [TestMethod]
        public void Check_Remove_Middle_Word()
        {
            var Tests = new SomeTests.SomeTest();
            Assert.AreEqual("sup dude", Tests.RemoveMiddleWord("sup my dude"));
            Assert.AreEqual("yeet yeet", Tests.RemoveMiddleWord("yeet yeet yeet"));
        }

        [TestMethod]
        public void Check_Sum_Of_Array()
        {
            var Tests = new SomeTests.SomeTest();
            Assert.AreEqual(9, Tests.SumIgnoringMax(new int []{ 2, 3, 4, 5 }));
            Assert.AreEqual(1005, Tests.SumIgnoringMax(new int[] { 999, 1000, 5, 1 }));
            Assert.AreEqual(9, Tests.SumIgnoringMax(new int[] { 1,2,1,1,1,1,1,1,1,1 }));
        }

        [TestMethod]
        public void Check_Pyramid()
        {
            var Tests = new SomeTests.SomeTest();
            CollectionAssert.AreEqual( new char[,] { 
                { ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '*', '*', '*', ' ', ' ', ' ' },
                { ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },
                { ' ', '*', '*', '*', '*', '*', '*', '*', ' ' },
                { '*', '*', '*', '*', '*', '*', '*', '*', '*' }
            }, Tests.Pyramid(5,9));
            CollectionAssert.AreEqual(new char[,] {
                { ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', ' ', '*', '*', '*', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '*', '*', '*', '*', '*', '*', '*', ' ', ' ', ' ' },
                { ' ', ' ', '*', '*', '*', '*', '*', '*', '*', '*', '*', ' ', ' ' },
                { ' ', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', ' ' },
                { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' }
            }, Tests.Pyramid(7, 13));

        }
    }
}
