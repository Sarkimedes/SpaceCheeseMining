using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceCheeseMining.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void MoveLeft_WherePlayerWouldNotWrapAround_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(3, 0);

            player.MoveLeft(1);

            Assert.AreEqual(2, player.Position.X);
        }

        [TestMethod]
        public void MoveLeft_WherePlayerWouldWrapAround_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(0, 0);

            player.MoveLeft(3);

            Assert.AreEqual(5, player.Position.X);
        }

        [TestMethod]
        public void MoveUp_WherePlayerWouldNotWrapAround_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(0, 3);
            
            player.MoveUp(2);

            Assert.AreEqual(new Square(0, 1), player.Position);
        }

        [TestMethod]
        public void MoveUp_WherePlayerWouldReachNearEdge_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(0, 1);

            player.MoveUp(1);

            Assert.AreEqual(new Square(0, 0), player.Position);
        }

        [TestMethod]
        public void MoveUp_WherePlayerWouldReachOppositeEdgeOfBoard_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(0, 0);

            player.MoveUp(1);

            Assert.AreEqual(new Square(0, 7), player.Position);
        }

        [TestMethod]
        public void MoveUp_WherePlayerWouldWrapAround_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(0, 3);

            player.MoveUp(6);

            Assert.AreEqual(new Square(0, 5), player.Position);
        }

        [TestMethod]
        public void MoveRight_WherePlayerWouldReachEdge_SetsPosition()
        {
            var player = new Player();
            player.Position = new Square(5, 0);

            player.MoveRight(2);

            Assert.AreEqual(new Square(7, 0), player.Position);
        }

        [TestMethod]
        public void MoveRight_WithXLocationOf5AndAmountOf3_WrapsPlayerToOppositeEdge()
        {
            var player = new Player();
            player.Position = new Square(5, 0);
            
            player.MoveRight(3);

            Assert.AreEqual(new Square(0, 0), player.Position);
        }

        [TestMethod]
        public void MoveRight_Moving6SquaresWithPlayerAtPosition3_WrapsPlayerAround()
        {
            var player = new Player();
            player.Position = new Square(3, 3);
            
            player.MoveRight(6);

            Assert.AreEqual(new Square(1, 3), player.Position);
        }

        [TestMethod]
        public void MoveDown_Moving6SquaresWithPlayerAtPosition1_MovesPlayerToEdge()
        {
            var player = new Player();
            player.Position = new Square(3, 1);

            player.MoveDown(6);

            Assert.AreEqual(new Square(3, 7), player.Position);
        }

        [TestMethod]
        public void MoveDown_Moving6SquaresWithPlayerAtPosition2_WrapsPlayerAroundToEdge()
        {
            var player = new Player()
            {
                Position = new Square(3, 2)
            };
            
            player.MoveDown(6);

            Assert.AreEqual(new Square(3, 0), player.Position);
        }
    }
}
