using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_112_Collections;

namespace Labs_Test
{
    [TestClass]
    public class LabsTest
    {
        [TestMethod]
        public void Lab112CollectionsTest()
        {
            var instance = new Collections();
            Assert.AreEqual(224, instance.Collections20MinLab(1,2,3));
            Assert.AreEqual(22400, instance.Collections20MinLab(10,20,30));
            Assert.AreEqual(464, instance.Collections20MinLab(2,3,4));
        }
    }
}
