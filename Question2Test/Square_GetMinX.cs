using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFT4102.TP1.Question2;

namespace IFT4102.TP1.Question2.Test
{
    [TestClass]
    public class Square_GetMinX
    {
        [TestMethod]
        public void GIVEN_getMinX_WHEN_posX_0_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getMinX(0, 3));
        }
        [TestMethod]
        public void GIVEN_getMinX_WHEN_posX_1_order_3_THEN_3()
        {
            //ASSERT
            Assert.AreEqual(3, Square.getMinX(1, 3));
        }
        [TestMethod]
        public void GIVEN_getMinX_WHEN_posX_2_order_3_THEN_6()
        {
            //ASSERT
            Assert.AreEqual(6, Square.getMinX(2, 3));
        }
    }
}
