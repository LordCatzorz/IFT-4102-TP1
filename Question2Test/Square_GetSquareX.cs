using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFT4102.TP1.Question2;

namespace IFT4102.TP1.Question2.Test
{
    [TestClass]
    public class Square_GetSquareX
    {
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_0_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getSquareX(0, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_1_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getSquareX(1, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_2_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getSquareX(2, 3));
        }

        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_3_order_3_THEN_1()
        {
            //ASSERT
            Assert.AreEqual(1, Square.getSquareX(3, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_4_order_3_THEN_1()
        {
            //ASSERT
            Assert.AreEqual(1, Square.getSquareX(4, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_5_order_3_THEN_1()
        {
            //ASSERT
            Assert.AreEqual(1, Square.getSquareX(5, 3));
        }


        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_6_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getSquareX(6, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_7_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getSquareX(7, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareX_WHEN_posX_8_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getSquareX(8, 3));
        }
    }
}
