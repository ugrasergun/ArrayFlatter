using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayFlatterTest
{
    [TestClass]
    public class ArrayFlatterTest
    {
        [TestMethod]
        public void intsToArray()
        {
            object[] intList = { 0, 2, 45, 5 };
            int[] flattedIntList = ArrayFlatter.ArrayFlatter.FlatArray(intList);
            Assert.IsTrue(flattedIntList.Length == 4);
            Assert.IsTrue(flattedIntList[0] == 0);
            Assert.IsFalse(flattedIntList[0] == 2);
        }

        [TestMethod]
        public void NestedArraysToArray()
        {
            object[] intList = { new object[] { 0, 2 }, new object[] { 45, 5 }, 8 }; 
            int[] flattedIntList = ArrayFlatter.ArrayFlatter.FlatArray(intList);
            Assert.IsTrue(flattedIntList.Length == 5);
            Assert.IsTrue(flattedIntList[0] == 0);
            Assert.IsFalse(flattedIntList[0] == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectDataType()
        {
            object[] wrongList = { 0, 2, 45, "5" };
            int[] flattedIntList = ArrayFlatter.ArrayFlatter.FlatArray(wrongList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nullData()
        {
            object[] ListWithNull = { 0, 2, null,5 };
            int[] flattedIntList = ArrayFlatter.ArrayFlatter.FlatArray(ListWithNull);
        }

        [TestMethod]
        public void nullList()
        {
            object[] nullList = null;
            int[] flattedIntList = ArrayFlatter.ArrayFlatter.FlatArray(nullList);
            Assert.IsTrue(flattedIntList == null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nestedNullList()
        {
            object[] nullList = null;
            object[] ListWithNullList = { 0, 2, nullList, 5 };
            int[] flattedIntList = ArrayFlatter.ArrayFlatter.FlatArray(ListWithNullList);
        }
    }
}
