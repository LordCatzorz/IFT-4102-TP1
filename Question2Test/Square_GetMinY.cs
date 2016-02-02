using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IFT4102.TP1.Question2;

namespace IFT4102.TP1.Question2.Test
{
    [TestClass]
    public class Square_GetMinY
    {
        [TestMethod]
        public void GIVEN_getMinY_WHEN_posY_0_order_3_THEN_0()
        {
            //ASSERT
            Assert.AreEqual(0, Square.getMinY(0, 3));
        }
        [TestMethod]
        public void GIVEN_getMinY_WHEN_posY_1_order_3_THEN_3()
        {
            //ASSERT
            Assert.AreEqual(3, Square.getMinY(1, 3));
        }
        [TestMethod]
        public void GIVEN_getMinY_WHEN_posY_2_order_3_THEN_6()
        {
            //ASSERT
            Assert.AreEqual(6, Square.getMinY(2, 3));
        }
    }
}
