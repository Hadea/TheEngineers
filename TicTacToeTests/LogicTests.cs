using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace TicTacToeTests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void Creation()
        {
            Logic l = new();
            Assert.IsNotNull(l.GameBoard);
        }

        [TestMethod]
        public void PlayerChangeAfterValidTurn()
        {
            Logic l = new();
            bool player = l.GetCurrentPlayer();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreNotEqual(player, l.GetCurrentPlayer());
        }

        [TestMethod]
        public void NoPlayerChangeAfterInValidTurn()
        {
            Logic l = new();
            bool player = l.GetCurrentPlayer();
            Assert.AreEqual(TurnResult.Invalid, l.Turn(0, 3)); // ausserhalb des spielfeldes
            Assert.AreEqual(TurnResult.Invalid, l.Turn(-1, 2)); // ausserhalb des spielfeldes
            Assert.AreEqual(TurnResult.Invalid, l.Turn(3, 3)); // ausserhalb des spielfeldes
            Assert.AreEqual(player, l.GetCurrentPlayer());
        }
        [TestMethod]
        public void WinTopLine()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Win, l.Turn(0, 2));
        }
    }
}
