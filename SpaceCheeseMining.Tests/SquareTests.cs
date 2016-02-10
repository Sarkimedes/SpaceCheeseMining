using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceCheeseMining.Tests
{
    /// <summary>
    /// Summary description for SquareTests
    /// </summary>
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void HasCheese_OnCheeseSquare_ReturnsTrue()
        {
            var square = new Square(1, 0);

            Assert.IsTrue(square.HasCheese);
        }

        [TestMethod]
        public void HasCheese_OnNonCheeseSquare_ReturnsFalse()
        {
            var square = new Square(1, 1);

            Assert.IsFalse(square.HasCheese);
        }
    }
}
