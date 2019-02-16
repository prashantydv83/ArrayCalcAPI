using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayCalcService;
using ArrayCalcContracts;
using System.Text;

namespace ArrayCalcAPI.Tests
{
    [TestClass]
    public class ArrayOperationsTest
    {        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void OnReverseArray_NullArray_IsInvalid()
        {
            //Arrange
            int[] testarraylist = null;
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            arrayOperations.ReverseArray(testarraylist);

            //Assert
            CollectionAssert.AreEqual(null, testarraylist);
        }

        [TestMethod]
        public void OnReverseArray_OneItemArray_Isvalid()
        {
            //Arrange
            int[] testarraylist = new int[] { 1 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            arrayOperations.ReverseArray(testarraylist);

            //Assert
            CollectionAssert.AreEqual(new int[] { 1 }, testarraylist);
        }

        [TestMethod]
        public void OnReverseArray_ArrayList_IsReversed()
        {
            //Arrange
            int[] testarraylist = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            arrayOperations.ReverseArray(testarraylist);

            //Assert
            CollectionAssert.AreEqual(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, testarraylist);
        }


        [TestMethod]
        public void OnReverseArray_unSortedArrayList_IsReversed()
        {
            //Arrange
            int[] testarraylist = new int[] { 15, 11, 19, 8, 6, 02 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            arrayOperations.ReverseArray(testarraylist);

            //Assert
            CollectionAssert.AreEqual(new int[] { 2, 6, 8, 19, 11, 15 }, testarraylist);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void OnDeleteAtPosition_NullArray_IsInvalid()
        {
            //Arrange
            int[] testarraylist = null;
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            var result = arrayOperations.DeleteAtPosition(1, testarraylist);

            //Assert
            CollectionAssert.AreEqual(null, result);
        }

        [TestMethod]
        public void OnDeleteAtPosition_OneItemArray_IsValid()
        {
            //Arrange
            int[] testarraylist = new int[] { 5 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            var result = arrayOperations.DeleteAtPosition(1, testarraylist);

            //Assert
            CollectionAssert.AreEqual(new int[] { }, result);
        }

        [TestMethod]
        public void OnDeleteAtPositionZero_Array_IsValid()
        {
            //Arrange
            int[] testarraylist = new int[] { 1, 2, 3 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            var result = arrayOperations.DeleteAtPosition(0, testarraylist);

            //Assert
            CollectionAssert.AreEqual(testarraylist, result);
        }

        [TestMethod]
        public void OnDeleteAtPosition_OutOfRange_IsValid()
        {
            //Arrange
            int[] testarraylist = new int[] { 10, 20, 30, 40, 50 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            var result = arrayOperations.DeleteAtPosition(6, testarraylist);

            //Assert
            CollectionAssert.AreEqual(testarraylist, result);
        }

        [TestMethod]
        public void OnDeleteAtPosition_Array_Works()
        {
            //Arrange
            int[] testarraylist = new int[] { 1, 2, 3, 4, 5 };
            IArrayOperations arrayOperations = new ArrayOperations();

            //Act
            var result = arrayOperations.DeleteAtPosition(1, testarraylist);

            //Assert
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5 }, result);
        }

    }
}
