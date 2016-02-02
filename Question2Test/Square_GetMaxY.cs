using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFT4102.TP1.Question2;

namespace IFT4102.TP1.Question2.Test
{
    [TestClass]
    public class Square_GetMaxY
    {
        [TestMethod]
        public void GIVEN_getMaxY_WHEN_posY_0_order_3_THEN_2()
        {
            //ASSERT
            Assert.AreEqual(2, Square.getMaxY(0, 3));
        }
        [TestMethod]
        public void GIVEN_getMaxY_WHEN_posY_1_order_3_THEN_5()
        {
            //ASSERT
            Assert.AreEqual(5, Square.getMaxY(1, 3));
        }
        [TestMethod]
        public void GIVEN_getMaxY_WHEN_posY_2_order_3_THEN_8()
        {
            //ASSERT
            Assert.AreEqual(8, Square.getMaxY(2, 3));
        }
    }
}
