using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFT4102.TP1.Question2;

namespace IFT4102.TP1.Question2.Test
{
    [TestClass]
    public class Square_GetSqaureY
    {
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_0_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getSquareY(0, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_1_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getSquareY(1, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_2_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getSquareY(2, 3));
        }

        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_3_order_3_THEN_1()
        {
            //ASSERT
            Assert.AreEqual(1, Square.getSquareY(3, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_4_order_3_THEN_1()
        {
            //ASSERT
            Assert.AreEqual(1, Square.getSquareY(4, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_5_order_3_THEN_1()
        {
            //ASSERT
            Assert.AreEqual(1, Square.getSquareY(5, 3));
        }


        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_6_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getSquareY(6, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_7_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getSquareY(7, 3));
        }
        [TestMethod]
        public void GIVEN_getSquareY_WHEN_posY_8_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getSquareY(8, 3));
        }
    }
}
