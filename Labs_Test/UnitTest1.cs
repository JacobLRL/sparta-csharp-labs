using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_112_Collections;
using Lab_113_ArrayList;

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

        [TestMethod]
        public void Lab113ArrayListTest()
        {
            var instance = new arrayList();
            Assert.AreEqual(480, instance.arrayListMethod(1,2,3,4));
            Assert.AreEqual(48000, instance.arrayListMethod(10,20,30,40));
        }
    }
}
