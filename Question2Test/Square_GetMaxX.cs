using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFT4102.TP1.Question2;

namespace IFT4102.TP1.Question2.Test
{
    [TestClass]
    public class Square_GetMaxX
    {
        [TestMethod]
        public void GIVEN_getMaxX_WHEN_posX_0_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getMaxX(0, 3));
        }
        [TestMethod]
        public void GIVEN_getMaxX_WHEN_posX_1_order_3_THEN_5()
        {
            //ASSERT
            Assert.AreEqual(5, Square.getMaxX(1, 3));
        }
        [TestMethod]
        public void GIVEN_getMaxX_WHEN_posX_2_order_3_THEN_8()
        {
            //ASSERT
            Assert.AreEqual(8, Square.getMaxX(2, 3));
        }
    }
}
